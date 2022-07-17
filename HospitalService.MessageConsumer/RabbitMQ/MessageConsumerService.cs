using HospitalService.DTOs;
using HospitalService.MessageConsumer.Data;
using HospitalService.MessageConsumer.Models;
using MassTransit;

namespace HospitalService.MessageConsumer.RabbitMQ
{
    public class MessageConsumerService : IConsumer<CreateObjectMessageDto>
    {
        private readonly MessageDbContext _dbContext;

        public MessageConsumerService(MessageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<CreateObjectMessageDto> context)
        {
            var obj = new Message
            {
                Value = context.Message.Value
            };
            await _dbContext.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
        }
    }
}
