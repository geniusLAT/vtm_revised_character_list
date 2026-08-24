namespace vtmRevisedCharacterListEntities
{
    public class CharacterUpdateRequest
    {
        public Guid UserUuid {  get; set; }

        public Guid CharacterUuid { get; set; }

        public required Character CharacterToUpdate { get; set; }

        public bool Hidden { get; set; }
    }
}
