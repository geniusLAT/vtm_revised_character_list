using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedWebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        
        private readonly ILogger<DiceController> _logger;

        public CharacterController(ILogger<DiceController> logger)
        {
            _logger = logger;
        }

        [Route("serializeCharacter")]
        public ActionResult<string> Get([FromBody] Character request)
        {
            var serialized = JsonConvert.SerializeObject(request);
            return Ok(serialized);
        }

        [HttpGet(Name = "GetCharacterList")]
        public ActionResult<List<CharacterListMember>> Get([FromBody] CharacterListRequest request)
        {
            List<CharacterListMember> result = [];

            var charactersToAccess = CharacterManager.GetUserRights(request.UserUuid);

            foreach (var characterUuid in charactersToAccess)
            {
                var character = CharacterManager.GetCharacter(characterUuid);
                if (character == null)
                {
                    Console.WriteLine($"no character {characterUuid}");
                    continue;
                }
                result.Add(new()
                {
                    CharacterName = character.CharacterName,
                    CharacterUuid = characterUuid
                    
                }
                    );
            }
            return result;
        }
    }
}
