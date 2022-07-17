using HospitalService.MessageConsumer.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalService.MessageConsumer.Data
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Message> Messages { get; set; }
    }
}
