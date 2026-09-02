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
        public IActionResult GetUser([FromQuery] Guid userGuid)
        {
            var user = UserManager.GetUser(userGuid);
            return Ok(user);
        }

        [HttpGet("all", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserEntity>))]
        public IActionResult GetAllUsers([FromQuery] Guid adminId)
        {
            var adminGuid = CharacterManager.GetAdminGuid();
            if (adminGuid == adminId)
            {
                var users = UserManager.GetAllUsers();
                return Ok(users);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost(Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateUser([FromBody] UserUpdateRequest request)
        {
            var adminGuid = CharacterManager.GetAdminGuid();
            if (adminGuid == request.AdminUuid)
            {
                var user = UserManager.UpdateUser(request.UserUuid, request.User);
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
                var guid = UserManager.CreateUser( request.User);
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
                var guid = UserManager.DeleteUser(request.UserUuid);
                return Ok(guid);
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
