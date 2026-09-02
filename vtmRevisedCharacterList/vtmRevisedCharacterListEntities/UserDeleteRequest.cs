namespace vtmRevisedCharacterListEntities;

public class UserDeleteRequest
{
    public required Guid AdminUuid { get; set; }

    public required Guid UserUuid { get; set; }
}
