using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DoctorAppointment.Persistence.Context
{
    public class DoctorAppointmentContextFactory : IDesignTimeDbContextFactory<DoctorAppointmentContext>
    {
        public DoctorAppointmentContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<DoctorAppointmentContext> optionsBuilder = new();

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DoctorAppointmentDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new DoctorAppointmentContext(optionsBuilder.Options);
        }
    }
}
