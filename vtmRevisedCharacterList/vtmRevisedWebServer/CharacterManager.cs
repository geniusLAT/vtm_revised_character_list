using System.Text.Json;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedWebServer;

public static class CharacterManager
{
    public static Guid[] GetUserRights(Guid userGuid)
    {
        // Формируем путь к файлу с учетом операционной системы
        string filePath = Path.Combine("userRights", $"{userGuid}.txt");

        // Если файла нет, сразу возвращаем пустой массив
        if (!File.Exists(filePath))
        {
            return Array.Empty<Guid>();
        }

        try
        {
            string content = File.ReadAllText(filePath);

            // Десериализуем JSON-массив в Guid[]
            Guid[]? rights = JsonSerializer.Deserialize<Guid[]>(content);

            // Если файл содержал "null" или десериализация вернула null
            return rights ?? Array.Empty<Guid>();
        }
        catch (Exception)
        {
            // В случае любых ошибок чтения или поврежденного JSON 
            // (например, JsonException, IOException) возвращаем пустой массив
            return Array.Empty<Guid>();
        }
    }

    public static Character? GetCharacter(Guid characterGuid)
    {
        // Формируем путь к файлу в папке characters
        string filePath = Path.Combine("characters", $"{characterGuid}.txt");

        // Если файла нет — возвращаем null
        if (!File.Exists(filePath))
        {
            return null;
        }

        try
        {
            string content = File.ReadAllText(filePath);

            // Десериализуем JSON в объект Character
            Character? character = JsonSerializer.Deserialize<Character>(content);

            return character;
        }
        catch (Exception)
        {
            // В случае любых ошибок чтения или некорректного JSON возвращаем null
            return null;
        }
    }
}
