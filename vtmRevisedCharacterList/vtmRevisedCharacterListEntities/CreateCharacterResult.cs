namespace vtmRevisedCharacterListEntities
{
    public class CreateCharacterResult
    {
        public required Guid CharacterUuid { get; set; }

        public required Character CreatedCharacter { get; set; }
    }
}
