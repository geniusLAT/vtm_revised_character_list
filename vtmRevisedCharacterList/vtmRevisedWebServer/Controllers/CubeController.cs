using Microsoft.AspNetCore.Mvc;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedWebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CubeController : ControllerBase
    {
        
        private readonly ILogger<CubeController> _logger;

        public CubeController(ILogger<CubeController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "RollCubes")]
        public string Post([FromBody] CubeRollRequest request)
        {
            var result = CubeManager.EnqueueRequest(request);
            return $"{result} text test {request.CubesToRoll} {request.Difficulty} {request.Comment}";
        }

        [HttpGet(Name = "GetCubeStats")]
        public IActionResult Get()
        {
            var request = CubeManager.DequeueRequest();
            
            var currentCount = CubeManager.queue.Count;

            return Ok(new
            {
                Value = request,
                Count = currentCount
            });
        }
    }
}
