using HospitalService.DTOs;
using MassTransit;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalService.RabbitMQ.Sender
{
    public class RabbitMqSender:IEventSender
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
