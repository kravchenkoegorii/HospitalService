using HospitalService.MessageConsumer.Models;

namespace HospitalService.MessageConsumer.Repositories
{
    public interface IMessageConsumerRepository
    {
        Task<Message> GetMessage(int id);
        Task<List<Message>> GetMessages();
    }
}
