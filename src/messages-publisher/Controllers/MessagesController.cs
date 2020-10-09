using System.Threading.Tasks;
using messages_publisher.Application.Boudaries;
using Microsoft.AspNetCore.Mvc;

namespace messages_publisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IValuePublisher _publisher;

        public MessagesController(IValuePublisher publisher)
        {
            _publisher = publisher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string message)
        {
            await _publisher.PublishMessage(message);

            return Ok("Message has been sended!");
        }
    }
}
