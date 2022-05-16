using HospitalService.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HospitalService.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}