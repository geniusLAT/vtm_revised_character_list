using System.Text.Json;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedWebServer;

public static class UserManager
{
    public static UserGetResult[] GetAllUsers()
    {
        string folderPath = "userRights";

        if (!Directory.Exists(folderPath))
        {
            return Array.Empty<UserGetResult>();
        }

        try
        {
            List<UserGetResult> users = new();
            foreach (string filePath in Directory.EnumerateFiles(folderPath, "*.txt"))
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                string content = File.ReadAllText(filePath);

                var result = JsonSerializer.Deserialize<UserEntity>(content);

                if (result != null)
                {
                    users.Add(new()
                    {
                        User = result,
                        UserUuid = new Guid(fileName),
                    });
                }
            }

            return users.ToArray();
        }
        catch (Exception)
        {
            return Array.Empty<UserGetResult>();
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

    public static UserUpdateResult? UpdateUser(Guid userGuid, UserEntity newUser)
    {
        string filePath = Path.Combine("userRights", $"{userGuid}.txt");

        if (!File.Exists(filePath))
        {
            return null;
        }

        try
        {
            string content = File.ReadAllText(filePath);

            UserEntity? oldUser = JsonSerializer.Deserialize<UserEntity>(content);

            if (oldUser is null)
            {
                throw new ApplicationException("No such user");
            }

            var newContent = JsonSerializer.Serialize(newUser);
            File.WriteAllText(filePath, newContent);

            Console.WriteLine(oldUser!.Name);

            return new()
            {
                UserUuid = userGuid,
                UpdatedUser = newUser,
            };
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static bool DeleteUser(Guid userGuid)
    {
        string filePath = Path.Combine("userRights", $"{userGuid}.txt");

        if (!File.Exists(filePath))
        {
            return false;
        }

        try
        {
            string content = File.ReadAllText(filePath);

            UserEntity? oldUser = JsonSerializer.Deserialize<UserEntity>(content);

            if (oldUser is null)
            {
                throw new ApplicationException("No such user");
            }

            File.Delete(filePath);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static Guid? CreateUser(UserEntity newUser)
    {
        string filePath = string.Empty;
        Guid? userGuid = null;

        while (File.Exists(filePath) || string.IsNullOrWhiteSpace(filePath))
        {
            userGuid = Guid.NewGuid();
            filePath = Path.Combine("userRights", $"{userGuid}.txt");
        }

        try
        {
            var newContent = JsonSerializer.Serialize(newUser);
            File.WriteAllText(filePath, newContent);

            return userGuid;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
