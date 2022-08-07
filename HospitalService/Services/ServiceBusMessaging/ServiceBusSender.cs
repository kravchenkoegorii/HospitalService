using Azure.Messaging.ServiceBus;
using HospitalService.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace HospitalService.Services.ServiceBusMessaging
{
    public class ServiceBusSender : IServiceBusSender
    {
        private readonly ServiceBusClient _client;
        private readonly Azure.Messaging.ServiceBus.ServiceBusSender _clientSender;
        private const string QUEUE_NAME = "message-queue";

        public ServiceBusSender()
        {
            var connectionString = Environment.GetEnvironmentVariable("HOSPITALBUS_KEY");
            _client = new ServiceBusClient(connectionString);
            _clientSender = _client.CreateSender(QUEUE_NAME);
        }

        public async Task SendMessageAsync(string serviceBusMessage)
        {
            var message = new ServiceBusMessage(serviceBusMessage);
            await _clientSender.SendMessageAsync(new ServiceBusMessage(serviceBusMessage));
        }
    }
}