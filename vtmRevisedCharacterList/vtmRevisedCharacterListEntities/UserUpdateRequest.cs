namespace vtmRevisedCharacterListEntities;

public class UserUpdateRequest
{
    public required Guid AdminUuid { get; set; }

    public required Guid UserUuid {  get; set; }

    public required UserEntity User { get; set; }
}
