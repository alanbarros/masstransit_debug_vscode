using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using messages_contracts;
using messages_publisher.Application.Boudaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            //await Task.FromResult("");

            return Ok("Message has been sended!");
        }
    }
}
