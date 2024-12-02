namespace adp;

public class PriorityQueueItem<T>
{
    public int Priority { get; set; }
    public T Value { get; set; }

    public PriorityQueueItem(int priority, T value)
    {
        Priority = priority;
        Value = value;
    }
}

public class PriorityQueueImplementation<T>
{
    private PriorityQueueItem<T>[] _queue;
    private int _size;

    public PriorityQueueImplementation()
    {
        _queue = new PriorityQueueItem<T>[2];
        _size = 0;
    }

    public void Add(T value, int priority)
    {
        EnsureCapacity();

        var newItem = new PriorityQueueItem<T>(priority, value);
        int index = _size;

        while (index > 0 && _queue[index - 1].Priority > priority)
        {
            _queue[index] = _queue[index - 1];
            index--;
        }

        _queue[index] = newItem;
        _size++;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Priority Queue is empty.");
        }

        return _queue[0].Value;
    }

    public T Poll()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Priority Queue is empty.");
        }

        var highestPriorityItem = _queue[0];

        for (int i = 1; i < _size; i++)
        {
            _queue[i - 1] = _queue[i];
        }

        _queue[_size - 1] = null;
        _size--;

        ShrinkCapacityIfNeeded();
        return highestPriorityItem.Value;
    }

    public int Size()
    {
        return _size;
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }

    private void EnsureCapacity()
    {
        if (_size >= _queue.Length)
        {
            Resize(_queue.Length * 2);
        }
    }

    private void ShrinkCapacityIfNeeded()
    {
        if (_size > 0 && _size <= _queue.Length / 4)
        {
            Resize(_queue.Length / 2);
        }
    }

    private void Resize(int newCapacity)
    {
        var newQueue = new PriorityQueueItem<T>[newCapacity];
        for (int i = 0; i < _size; i++)
        {
            newQueue[i] = _queue[i];
        }

        _queue = newQueue;
    }
}