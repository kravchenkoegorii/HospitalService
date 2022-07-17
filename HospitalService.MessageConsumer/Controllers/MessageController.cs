using HospitalService.MessageConsumer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HospitalService.MessageConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageConsumerRepository _messageConsumer;

        public MessageController(IMessageConsumerRepository messageConsumer)
        {
            _messageConsumer = messageConsumer;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _messageConsumer.GetMessage(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _messageConsumer.GetMessages());
        }
    }
}
