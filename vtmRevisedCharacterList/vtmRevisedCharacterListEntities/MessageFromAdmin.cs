namespace vtmRevisedCharacterListEntities;

public class MessageFromAdmin
{
   public Guid UserId {  get; set; }

   public required MessageToShow Message { get; set; }
}