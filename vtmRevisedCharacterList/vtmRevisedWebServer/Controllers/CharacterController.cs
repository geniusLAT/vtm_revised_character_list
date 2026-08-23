using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedWebServer.Controllers;

[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{

    private readonly ILogger<CharacterController> _logger;

    public CharacterController(ILogger<CharacterController> logger)
    {
        _logger = logger;
    }

    [HttpPost("serializeCharacter")]
    public ActionResult<string> SerializeCharacter([FromBody] Character request)
    {
        var serialized = JsonConvert.SerializeObject(request);
        return Ok(serialized);
    }

    [HttpPost("GetCharacterList")]
    public ActionResult<List<CharacterListMember>> GetCharacterList([FromBody] CharacterListRequest request)
    {
        List<CharacterListMember> result = [];
        Guid[] charactersToAccess;
        
        var adminGuid = CharacterManager.GetAdminGuid();
        //throw new NotImplementedException($"{adminGuid}");
        if (adminGuid != request.UserUuid)
        {
            charactersToAccess = CharacterManager.GetUserRights(request.UserUuid);
        }
        else
        {
            charactersToAccess = CharacterManager.GetAllCharacters();
        }

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

    [HttpPost("UpdateCharacter")]
    public ActionResult<CharacterUpdateResult> UpdateCharacter ([FromBody] CharacterUpdateRequest request)
    {
        var adminGuid = CharacterManager.GetAdminGuid();
        if (adminGuid != request.UserUuid)
        {
            var charactersToAccess = CharacterManager.GetUserRights(request.UserUuid);

            if (!charactersToAccess.Contains(request.CharacterUuid))
            {
                return BadRequest("not your character");
            }
        }

        var characterUpdateResult = CharacterManager.UpdateCharacter(request.CharacterUuid, request.CharacterToUpdate);
        if (characterUpdateResult == null)
        {
            return NotFound();
        }
        MessageManager.EnqueueRequest(new() { Hidden = false, Text = characterUpdateResult.ChangeLog });
        return characterUpdateResult;
    }

    [HttpPost("GetCharacter")]
    public ActionResult<Character> GetCharacter([FromBody] CharacterRequest request)
    {
        var adminGuid = CharacterManager.GetAdminGuid();
        if (adminGuid != request.UserUuid)
        {
            var charactersToAccess = CharacterManager.GetUserRights(request.UserUuid);

            if (!charactersToAccess.Contains(request.CharacterUuid))
            {
                return BadRequest("not your character");
            }
        }

        var character = CharacterManager.GetCharacter(request.CharacterUuid);
        if (character == null)
        {
            return NotFound();
        }

        return character;
    }
}
