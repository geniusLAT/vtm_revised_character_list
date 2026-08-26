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

        [HttpPost(Name = "SendMessage")]
        public IActionResult Post([FromBody] MessageFromAdmin message)
        {
            var adminGuid = CharacterManager.GetAdminGuid();
            if (adminGuid != message.UserId)
            {
                return Unauthorized();
            }
            var request = MessageManager.EnqueueRequest(message.Message);

            return Ok();
        }
    }
}
