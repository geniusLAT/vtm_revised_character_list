using System.Text.Json;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedWebServer;

public static class CharacterManager
{
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

    public static UserEntity? GetUser(Guid userGuid)
    {
        string filePath = Path.Combine("userRights", $"{userGuid}.txt");

        if (!File.Exists(filePath))
        {
            return null;
        }

        try
        {
            string content = File.ReadAllText(filePath);

            var result = JsonSerializer.Deserialize<UserEntity>(content);

            return result;
        }
        catch (Exception)
        {
            return null;
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

            var newContent = JsonSerializer.Serialize(newCharacter);
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
            // В случае любых ошибок чтения или некорректного JSON возвращаем null
            return null;
        }
    }
}
