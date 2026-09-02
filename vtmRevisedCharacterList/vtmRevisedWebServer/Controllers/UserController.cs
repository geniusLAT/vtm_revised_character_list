using Microsoft.AspNetCore.Mvc;
using vtmRevisedCharacterListEntities;

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
        public IActionResult GetAdminStatus([FromQuery] Guid userId) 
        {
            var adminGuid = CharacterManager.GetAdminGuid();
            return Ok(adminGuid == userId);
        }

        [HttpGet(Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserEntity))]
        public IActionResult GetUser([FromQuery] Guid userId)
        {
            var user = CharacterManager.GetUser(userId);
            return Ok(user);
        }
    }
}
