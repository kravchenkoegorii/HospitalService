using HospitalService.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalService.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext() { }     
        public HospitalDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Doctor> Doctors { get; set; }   
    }
}