using Microsoft.AspNetCore.Mvc;

namespace vtmRevisedWebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        
        private readonly ILogger<MessageController> _logger;

        public UserController(ILogger<MessageController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAdminStatus", Name = "GetAdminStatus")]
        public IActionResult GetAdminStatus(Guid userId)
        {
            var adminGuid = CharacterManager.GetAdminGuid();
            
            return Ok(new
            {
                Status = adminGuid == userId
            });
        }
    }
}
