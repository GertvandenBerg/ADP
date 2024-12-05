namespace adp;

public class PriorityQueueItem<T>
{
    public int Priority { get; set; }
    public T Value { get; set; }
    public PriorityQueueItem<T>? Next { get; set; }

    public PriorityQueueItem(int priority, T value)
    {
        Priority = priority;
        Value = value;
        Next = null;
    }
}

public class PriorityQueueImplementation<T>
{
    private PriorityQueueItem<T>? _head = null;

    public void Add(T value, int priority)
    {
        var newItem = new PriorityQueueItem<T>(priority, value);

        if (_head == null || _head.Priority > priority)
        {
            newItem.Next = _head;
            _head = newItem;
            return;
        }

        var current = _head;
        while (current.Next != null && current.Next.Priority <= priority)
        {
            current = current.Next;
        }

        newItem.Next = current.Next;
        current.Next = newItem;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Priority Queue is empty.");
        }

        return _head.Value; 
    }

    public T Poll()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Priority Queue is empty.");
        }

        var highestPriorityItem = _head; 
        _head = _head.Next; 
        return highestPriorityItem.Value;
    }

    public int Size()
    {
        int count = 0;
        var current = _head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    public bool IsEmpty()
    {
        return _head == null;
    }
}