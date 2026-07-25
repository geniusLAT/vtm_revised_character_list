using vtmRevisedCharacterListEntities;

namespace vtmRevisedWebServer;

public static class CubeManager
{
    public static Queue<CubeRollRequest> queue = new Queue<CubeRollRequest>();

    public static CubeRollRequest? DequeueRequest()
    {
        if (queue.Count == 0)
        {
            return null;
        }

        return queue.Dequeue();
    }

    public static bool EnqueueRequest(CubeRollRequest request)
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
