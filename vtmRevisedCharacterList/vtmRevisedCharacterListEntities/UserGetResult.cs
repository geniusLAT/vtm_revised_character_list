namespace vtmRevisedCharacterListEntities
{
    public class UserGetResult
    {
        public required Guid UserUuid { get; set; }

        public required UserEntity User { get; set; }
    }
}
