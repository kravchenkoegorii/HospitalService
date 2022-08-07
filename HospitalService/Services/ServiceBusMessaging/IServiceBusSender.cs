using System.Threading.Tasks;

namespace HospitalService.Services.ServiceBusMessaging
{
    public interface IServiceBusSender
    {
        Task SendMessageAsync(string serviceBusMessage);
    }
}
