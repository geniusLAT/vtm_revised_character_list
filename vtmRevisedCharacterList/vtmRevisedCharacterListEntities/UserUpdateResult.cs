namespace vtmRevisedCharacterListEntities
{
    public class UserUpdateResult
    {

        public required Guid UserUuid { get; set; }

        public required UserEntity UpdatedUser { get; set; }
    }
}
