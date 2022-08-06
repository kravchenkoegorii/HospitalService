using Azure.Messaging.ServiceBus;
using HospitalService.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace HospitalService.Services
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly ServiceBusClient _serviceBusClient;

        public MessagePublisher()
        {
            _serviceBusClient = new ServiceBusClient(Environment.GetEnvironmentVariable("HOSPITALBUS_KEY"));
        }

        public async Task SendMessageAsync(string serviceBusMessage, string queueName)
        {
            var _serviceBusSender = _serviceBusClient.CreateSender(queueName);
            await _serviceBusSender.SendMessageAsync(new ServiceBusMessage(serviceBusMessage));
        }
    }
}