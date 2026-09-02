namespace vtmRevisedCharacterListEntities;

public class UserCreateRequest
{
    public required Guid AdminUuid { get; set; }

    public required UserEntity User { get; set; }
}
