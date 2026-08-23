using vtmRevisedCharacterListEntities;

namespace vtmRevisedWebServer;

public static class MessageManager
{
    public static Queue<MessageToShow> queue = new Queue<MessageToShow>();

    public static MessageToShow? DequeueRequest()
    {
        if (queue.Count == 0)
        {
            return null;
        }

        return queue.Dequeue();
    }

    public static bool EnqueueRequest(MessageToShow message)
    {
        if (queue.Count > 1000)
        {
            //too much
            return false;
        }
        queue.Enqueue(message);
        return true;
    }
}
