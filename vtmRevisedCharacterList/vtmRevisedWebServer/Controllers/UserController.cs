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

        [HttpPost(Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateUser([FromBody] UserUpdateRequest request)
        {
            var adminGuid = CharacterManager.GetAdminGuid();
            if (adminGuid == request.AdminUuid)
            {
                var user = CharacterManager.UpdateUser(request.UserUuid, request.User);
                return Ok(user);
            }
            else
            {
                return Unauthorized();
            }
           
        }

        [HttpPost("create", Name = "CreateUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateUser([FromBody] UserCreateRequest request)
        {
            var adminGuid = CharacterManager.GetAdminGuid();
            if (adminGuid == request.AdminUuid)
            {
                var guid = CharacterManager.CreateUser( request.User);
                return Ok(guid);
            }
            else
            {
                return Unauthorized();
            }

        }

        [HttpDelete(Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateUser([FromBody] UserDeleteRequest request)
        {
            var adminGuid = CharacterManager.GetAdminGuid();
            if (adminGuid == request.AdminUuid)
            {
                var guid = CharacterManager.DeleteUser(request.UserUuid);
                return Ok(guid);
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
