using HospitalService.DTOs;
using MassTransit;
using System.Threading.Tasks;

namespace HospitalService.RabbitMQ
{
    public class RabbitMqSender : IEventSender
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public RabbitMqSender(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendMessage(string message)
        {
            await _publishEndpoint.Publish<CreateObjectMessageDto>(new
            {
                Value = message
            });
        }
    }
}
