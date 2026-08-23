using Microsoft.AspNetCore.Mvc;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedWebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        
        private readonly ILogger<MessageController> _logger;

        public MessageController(ILogger<MessageController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetMessage")]
        public IActionResult Get()
        {
            var request = MessageManager.DequeueRequest();
            
            var currentCount = MessageManager.queue.Count;

            return Ok(new
            {
                Value = request,
                Count = currentCount
            });
        }
    }
}
