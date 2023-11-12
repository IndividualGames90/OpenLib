/// <summary>
/// Unity Game Optimization 3rdEd Messaging System.F
/// </summary>

public class Message
{
    public string type;
    public Message() { type = GetType().Name; }
}


public delegate bool MessageHandlerDelegate(Message message);//why is this barebones delegate and not some class?


/*public class MessagingSystem : SingletonComponent<MessagingSystem>
{

    public static MessagingSystem Instance
    {
        get
        {
            return (MessagingSystem)_Instance;
        }
        set
        {
            _Instance = value;// why is instance exposed like that?
        }


        private Dictionary<string, List<MessageHandlerDelegate>> _listenerDict = new(); //CHANGE STRING TO INT OR KEY
    private Queue<Message> _messageQueue = new();
    private const int _maxQueueProcessingTime = 16667;
    private System.Diagnostics.Stopwatch timer = new();

    void Update()
    {
        ProcessMessageQueue();
    }

    private void ProcessMessageQueue()
    {//provides a time interval to process messages, then leaves the rest to the next frame. makes sense.
        timer.Start();
        while (_messageQueue.Count > 0)
        {
            if (_maxQueueProcessingTime > 0.0f)
            {
                if (timer.Elapsed.Milliseconds > _maxQueueProcessingTime)
                {
                    timer.Stop();
                    return;
                }
            }
            Message msg = _messageQueue.Dequeue();
            if (!TriggerMessage(msg))
            {
                Debug.Log($"Error processing message: {msg.type}");
            }
        }
    }

    public bool AttachListener(System.Type type, MessageHandlerDelegate handler)
    {

        if (type == null)
        {
            Debug.Log($"MessagingSystem: AttachListener failed due to having no {type}");
            return false;
        }

        string msgType = type.Name;//CONTAINS WITH INT OR KEY NOT STRING

        if (!_listenerDict.ContainsKey(msgType))
        {
            _listenerDict.Add(msgType, new List<MessageHandlerDelegate>());
        }

        List<MessageHandlerDelegate> listenerList = _listenerDict[msgType];

        if (listenerList.Contains(handler))
        {
            return false;
        }

        listenerList.Add(handler);
        return true;
    }

    public bool QueueMessage(Message msg)
    {
        if (!_listenerDict.ContainsKey(msg.type))
        {
            return false;
        }
        _messageQueue.Enqueue(msg);
        return true;
    }

    public bool TriggerMessage(Message msg)
    {
        string msgType = msg.type;

        if (!_listenerDict.ContainsKey(msgType))
        {
            Debug.Log($"MessagingSystem: Message {msgType} has no listeners.");
            return false;
        }

        List<MessageHandlerDelegate> listenerList = _listenerDict[msgType];

        for (int i = 0; i < listenerList.Count; i++)
        {//this is really weird, why are we firing a return if we 
            if (listenerList[i](msg))
            {
                return true;
            }
            return true;
        }
    }
}*/