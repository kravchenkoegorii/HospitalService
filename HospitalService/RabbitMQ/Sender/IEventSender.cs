using System.Threading.Tasks;

namespace HospitalService.RabbitMQ.Sender
{
    public interface IEventSender
    {
        Task SendMessage(string message);
    }
}
