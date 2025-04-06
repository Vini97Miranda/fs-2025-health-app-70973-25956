﻿using HealthApp.Razor.Data;
using HealthApp.Domain.Entities;
using HealthApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthApp.Domain.Services;

public class AppointmentService : IAppointmentRepository
{
    private readonly ApplicationDbContext _context;
    private readonly INotificationService _notificationService;

    public AppointmentService(ApplicationDbContext context, INotificationService notificationService)
    {
        _context = context;
        _notificationService = notificationService;
    }

    public async Task<Appointment> GetByIdAsync(int id)
    {
        return await _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .FirstOrDefaultAsync(a => a.Id == id)
            ?? throw new InvalidOperationException($"Appointment with ID {id} not found.");
    }

    public async Task<IEnumerable<Appointment>> GetAllAsync()
    {
        return await _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> GetByPatientIdAsync(int patientId)
    {
        return await _context.Appointments
            .Where(a => a.PatientId == patientId)
            .Include(a => a.Doctor)
            .OrderBy(a => a.AppointmentDateTime)
            .ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> GetByDoctorIdAsync(int doctorId)
    {
        return await _context.Appointments
            .Where(a => a.DoctorId == doctorId)
            .Include(a => a.Patient)
            .OrderBy(a => a.AppointmentDateTime)
            .ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> GetByDateRangeAsync(DateTime start, DateTime end)
    {
        return await _context.Appointments
            .Where(a => a.AppointmentDateTime >= start && a.AppointmentDateTime <= end)
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .OrderBy(a => a.AppointmentDateTime)
            .ToListAsync();
    }

    public async Task AddAsync(Appointment appointment)
    {
        if (await IsTimeSlotAvailableAsync(appointment.DoctorId, appointment.AppointmentDateTime, appointment.EndDateTime))
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            // Send notification
            await _notificationService.SendAppointmentConfirmationAsync(appointment);
        }
        else
        {
            throw new InvalidOperationException("The selected time slot is not available.");
        }
    }

    public async Task UpdateAsync(Appointment appointment)
    {
        _context.Entry(appointment).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var appointment = await GetByIdAsync(id);
        if (appointment != null)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Appointments.AnyAsync(e => e.Id == id);
    }

    public async Task<bool> IsTimeSlotAvailableAsync(int doctorId, DateTime start, DateTime end)
    {
        return !await _context.Appointments
            .Where(a => a.DoctorId == doctorId)
            .Where(a => a.Status != "Cancelled")
            .AnyAsync(a =>
                (start >= a.AppointmentDateTime && start < a.EndDateTime) ||
                (end > a.AppointmentDateTime && end <= a.EndDateTime) ||
                (start <= a.AppointmentDateTime && end >= a.EndDateTime));
    }

    public async Task<IEnumerable<Appointment>> GetPendingAppointmentsAsync(int doctorId)
    {
        return await _context.Appointments
            .Where(a => a.DoctorId == doctorId && a.Status == "Pending")
            .Include(a => a.Patient)
            .OrderBy(a => a.AppointmentDateTime)
            .ToListAsync();
    }

    public async Task<int> GetAppointmentCountByStatusAsync(string status)
    {
        return await _context.Appointments.CountAsync(a => a.Status == status);
    }

    public async Task<bool> CancelAppointmentAsync(int appointmentId, string reason)
    {
        var appointment = await GetByIdAsync(appointmentId);
        if (appointment == null) return false;

        // Check if cancellation is within 48 hours
        if (appointment.AppointmentDateTime.Subtract(DateTime.Now).TotalHours < 48)
        {
            return false;
        }

        appointment.IsCancelled = true;
        appointment.Status = "Cancelled";
        appointment.CancellationDate = DateTime.UtcNow;
        appointment.CancellationReason = reason;

        await UpdateAsync(appointment);
        await _notificationService.SendAppointmentCancellationAsync(appointment);

        return true;
    }
}
