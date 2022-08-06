using System.Threading.Tasks;

namespace HospitalService.Services.Interfaces
{
    public interface IMessagePublisher
    {
        Task SendMessageAsync(string serviceBusMessage, string queueName);
    }
}
