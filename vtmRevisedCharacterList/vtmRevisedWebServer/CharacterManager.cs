using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedWebServer;

public static class CharacterManager
{
    private static JsonSerializerOptions options = new JsonSerializerOptions
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
    };

    public static Guid[] GetAllCharacters() 
    {
        string folderPath = "characters";

        if (!Directory.Exists(folderPath))
        {
            return Array.Empty<Guid>();
        }

        try
        {
            List<Guid> characterGuids = new();
            foreach (string filePath in Directory.EnumerateFiles(folderPath, "*.txt"))
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                if (Guid.TryParse(fileName, out Guid characterGuid))
                {
                    characterGuids.Add(characterGuid);
                }
            }

            return characterGuids.ToArray();
        }
        catch (Exception)
        {
            return Array.Empty<Guid>();
        }
    }

    public static Guid[] GetUserRights(Guid userGuid)
    {
        string filePath = Path.Combine("userRights", $"{userGuid}.txt");

        if (!File.Exists(filePath))
        {
            return Array.Empty<Guid>();
        }

        try
        {
            string content = File.ReadAllText(filePath);

            Guid[]? rights = JsonSerializer.Deserialize<UserEntity>(content)?.AccessedCharacters.ToArray();

            return rights ?? Array.Empty<Guid>();
        }
        catch (Exception)
        {
            return Array.Empty<Guid>();
        }
    }

    public static Guid? GetAdminGuid()
    {
        string filePath = "admin.txt";

        if (!File.Exists(filePath))
        {
            return null;
        }

        try
        {
            string content = File.ReadAllText(filePath);

            Guid adminGuid = Guid.Parse(content);

            return adminGuid;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static Character? GetCharacter(Guid characterGuid)
    {
        string filePath = Path.Combine("characters", $"{characterGuid}.txt");

        if (!File.Exists(filePath))
        {
            return null;
        }

        try
        {
            string content = File.ReadAllText(filePath);

            Character? character = JsonSerializer.Deserialize<Character>(content);

            Console.WriteLine(character!.CharacterName);

            return character;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static bool DeleteCharacter(Guid characterGuid)
    {
        string filePath = Path.Combine("characters", $"{characterGuid}.txt");

        if (!File.Exists(filePath))
        {
            return false;
        }

        try
        {
            File.Delete(filePath);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static CharacterUpdateResult? UpdateCharacter(Guid characterGuid, Character newCharacter)
    {
        string filePath = Path.Combine("characters", $"{characterGuid}.txt");

        if (!File.Exists(filePath))
        {
            return null;
        }

        try
        {
            string content = File.ReadAllText(filePath);

            Character? oldCharacter = JsonSerializer.Deserialize<Character>(content);

            if (oldCharacter is null)
            {
                throw new ApplicationException("No such character");
            }

            var changeLog = ChangeLogGenerator.GenerateChangeLog(oldCharacter, newCharacter);

            var newContent = JsonSerializer.Serialize(newCharacter, options);
            File.WriteAllText(filePath, newContent);

            Console.WriteLine(oldCharacter!.CharacterName);

            return new()
            {
                CharacterUuid = characterGuid,
                UpdatedCharacter = newCharacter,
                ChangeLog = changeLog
            };
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static CreateCharacterResult? CreateCharacter(Character newCharacter)
    {
        string filePath = string.Empty;
        Guid? characterGuid = null;

        while (File.Exists(filePath) || string.IsNullOrWhiteSpace(filePath))
        {
            characterGuid = Guid.NewGuid();
            filePath = Path.Combine("characters", $"{characterGuid}.txt");
        }

        try
        {
            var newContent = JsonSerializer.Serialize(newCharacter, options);
            File.WriteAllText(filePath, newContent);

            return new()
            {
                CharacterUuid = (Guid)characterGuid,
                CreatedCharacter = newCharacter
            };
        }
        catch (Exception)
        {
            return null;
        }
    }
}
