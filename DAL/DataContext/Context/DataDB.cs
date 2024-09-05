using DataContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataContext.Context
{
    /// <summary>
    /// Контекст подключения к базе данных
    /// </summary>
    public class DataDB : DbContext
    {
        public DataDB(DbContextOptions<DataDB> options) : base(options) { }

        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
