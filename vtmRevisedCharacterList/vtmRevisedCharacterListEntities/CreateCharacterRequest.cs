namespace vtmRevisedCharacterListEntities
{
    public class CreateCharacterRequest
    {
        public Guid AdminUuid {  get; set; }

        public required Character CharacterToCreate{ get; set; }
    }
}
