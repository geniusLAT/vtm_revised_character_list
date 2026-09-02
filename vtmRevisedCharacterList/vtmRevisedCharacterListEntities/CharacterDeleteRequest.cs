namespace vtmRevisedCharacterListEntities;

public class CharacterDeleteRequest
{
    public required Guid AdminUuid { get; set; }

    public required Guid CharacterUuid { get; set; }
}
