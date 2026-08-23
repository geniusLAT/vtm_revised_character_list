using System.Text.Json;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedWebServer;

public static class CharacterManager
{
    public static Guid[] GetAllCharacters() // или GetUserRightsAdmin()
    {
        string folderPath = "characters";

        // Если папки с персонажами нет, сразу возвращаем пустой массив
        if (!Directory.Exists(folderPath))
        {
            return Array.Empty<Guid>();
        }

        try
        {
            List<Guid> characterGuids = new();

            // Перебираем все файлы с расширением .txt
            foreach (string filePath in Directory.EnumerateFiles(folderPath, "*.txt"))
            {
                // Получаем имя файла без пути и без расширения .txt
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                // Валидируем: проверяем, что имя файла — это корректный GUID
                if (Guid.TryParse(fileName, out Guid characterGuid))
                {
                    characterGuids.Add(characterGuid);
                }
            }

            return characterGuids.ToArray();
        }
        catch (Exception)
        {
            // При ошибках доступа к ФС или вводу/выводу возвращаем пустой массив
            return Array.Empty<Guid>();
        }
    }

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

    public static Guid? GetAdminGuid()
    {
        // Формируем путь к файлу с учетом операционной системы
        string filePath = "admin.txt";

        // Если файла нет, сразу возвращаем пустой массив
        if (!File.Exists(filePath))
        {
            return null;
        }

        try
        {
            string content = File.ReadAllText(filePath);

            // Десериализуем JSON-массив в Guid[]
            Guid adminGuid = Guid.Parse(content);//JsonSerializer.Deserialize<Guid>(content);

            // Если файл содержал "null" или десериализация вернула null
            return adminGuid;
        }
        catch (Exception)
        {
            // В случае любых ошибок чтения или поврежденного JSON 
            // (например, JsonException, IOException) возвращаем пустой массив
            return null;
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

            Console.WriteLine(character!.CharacterName);

            return character;
        }
        catch (Exception)
        {
            // В случае любых ошибок чтения или некорректного JSON возвращаем null
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

            // Десериализуем JSON в объект Character
            Character? oldCharacter = JsonSerializer.Deserialize<Character>(content);

            Console.WriteLine(oldCharacter!.CharacterName);

            return oldCharacter;
        }
        catch (Exception)
        {
            // В случае любых ошибок чтения или некорректного JSON возвращаем null
            return null;
        }
    }
}
