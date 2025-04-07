using Bogus;
using HealthApp.Domain.Entities;
using HealthApp.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HealthApp.Razor.Data;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<Program>>();

        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            await context.Database.MigrateAsync();
            logger.LogInformation("Database migrations applied");

            await SeedRoles(roleManager);

            var adminUser = await SeedAdminUser(userManager, context);

            await SeedDoctors(userManager, context);

            await SeedPatients(userManager, context, adminUser.Id, logger);

            await SeedAppointments(context, logger);

            logger.LogInformation("Database seeding completed successfully");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database");
            throw;
        }
    }

    private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        string[] roleNames = { "Admin", "Doctor", "Patient" };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }

    private static async Task<IdentityUser> SeedAdminUser(UserManager<IdentityUser> userManager, ApplicationDbContext context)
    {
        const string adminEmail = "admin@healthapp.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(adminUser, "Admin123!");
            await userManager.AddToRoleAsync(adminUser, "Admin");

            context.Set<Patient>().Add(new Patient
            {
                UserId = adminUser.Id,
                Name = "Admin User",
                DateOfBirth = new DateTime(1980, 1, 1),
                PhoneNumber = "1234567890",
                Email = adminEmail // Added email to match earlier requirements
            });

            await context.SaveChangesAsync();
        }

        return adminUser;
    }

    private static async Task SeedDoctors(UserManager<IdentityUser> userManager, ApplicationDbContext context)
    {
        if (await context.Set<Doctor>().AnyAsync()) return;

        var specialties = new[] { "Cardiology", "Neurology", "Pediatrics", "Orthopedics", "Dermatology" };

        var doctorFaker = new Faker<Doctor>()
            .RuleFor(d => d.Name, f => f.Name.FullName())
            .RuleFor(d => d.Specialization, f => f.PickRandom(specialties))
            .RuleFor(d => d.Bio, f => f.Lorem.Paragraph())
            .RuleFor(d => d.LicenseNumber, f => f.Random.AlphaNumeric(10))
            .RuleFor(d => d.YearsOfExperience, f => f.Random.Number(1, 30))
            .RuleFor(d => d.HospitalAffiliation, f => f.Company.CompanyName())
            .RuleFor(d => d.Email, (f, d) => $"{d.Name.Replace(" ", "").ToLower()}@healthapp.com");

        var doctors = doctorFaker.Generate(10);

        foreach (var doctor in doctors)
        {
            var doctorUser = new IdentityUser
            {
                UserName = doctor.Email,
                Email = doctor.Email,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(doctorUser, "Doctor123!");
            await userManager.AddToRoleAsync(doctorUser, "Doctor");

            doctor.UserId = doctorUser.Id;
            context.Set<Doctor>().Add(doctor);
        }

        await context.SaveChangesAsync();

        foreach (var doctor in context.Set<Doctor>())
        {
            for (int i = 0; i < 5; i++)
            {
                context.Set<Schedule>().Add(new Schedule
                {
                    DoctorId = doctor.Id,
                    DayOfWeek = (DayOfWeek)((i + 1) % 7),
                    StartTime = TimeSpan.FromHours(9),
                    EndTime = TimeSpan.FromHours(17),
                    MaxAppointments = 8
                });
            }
        }

        await context.SaveChangesAsync();
    }
