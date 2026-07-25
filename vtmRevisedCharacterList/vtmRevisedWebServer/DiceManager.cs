using vtmRevisedCharacterListEntities;

namespace vtmRevisedWebServer;

public static class DiceManager
{
    public static Queue<DicesRollRequest> queue = new Queue<DicesRollRequest>();

    public static DicesRollRequest? DequeueRequest()
    {
        if (queue.Count == 0)
        {
            return null;
        }

        return queue.Dequeue();
    }

    public static bool EnqueueRequest(DicesRollRequest request)
    {
        if (queue.Count > 1000)
        {
            //too much
            return false;
        }
        queue.Enqueue(request);
        return true;
    }
}
