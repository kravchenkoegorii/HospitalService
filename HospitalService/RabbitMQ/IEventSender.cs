using System.Threading.Tasks;

namespace HospitalService.RabbitMQ
{
    public interface IEventSender
    {
        Task SendMessage(string message);
    }
}
