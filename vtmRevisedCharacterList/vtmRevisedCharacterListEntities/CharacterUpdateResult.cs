namespace vtmRevisedCharacterListEntities
{
    public class CharacterUpdateResult
    {
        public required Guid CharacterUuid { get; set; }

        public required Character UpdatedCharacter { get; set; }

        public string ChangeLog { get; set; } = string.Empty;
    }
}
