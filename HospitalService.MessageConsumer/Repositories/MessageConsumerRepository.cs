using HospitalService.MessageConsumer.Data;
using HospitalService.MessageConsumer.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalService.MessageConsumer.Repositories
{
    public class MessageConsumerRepository : IMessageConsumerRepository
    {
        private readonly MessageDbContext _dbContext;

        public MessageConsumerRepository(MessageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Message> GetMessage(int id) => await _dbContext.Messages.FindAsync(id);

        public async Task<List<Message>> GetMessages() => await _dbContext.Messages.ToListAsync();
    }
}
