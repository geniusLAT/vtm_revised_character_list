using Microsoft.AspNetCore.Mvc;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedWebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiceController : ControllerBase
    {
        
        private readonly ILogger<DiceController> _logger;

        public DiceController(ILogger<DiceController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "RollDices")]
        public ActionResult<DicesRollRequest> Post([FromBody] DicesRollRequest request)
        {
            var result = DiceManager.EnqueueRequest(request);
            request.Roll();

            return Ok(request);
        }

        [HttpGet(Name = "GetDiceStats")]
        public IActionResult Get()
        {
            var request = DiceManager.DequeueRequest();
            
            var currentCount = DiceManager.queue.Count;

            return Ok(new
            {
                Value = request,
                Count = currentCount
            });
        }
    }
}
