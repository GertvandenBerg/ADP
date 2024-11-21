namespace adp;

public class PriorityQueueImplementation<T> where T : IComparable<T>
{
    private T[] _queue;
    private int _size;

    /// <summary>
    /// Initializes a priority queue with a specified initial capacity.
    /// </summary>
    public PriorityQueueImplementation(int initialCapacity = 16)
    {
        if (initialCapacity <= 0)
        {
            throw new ArgumentException("Initial capacity must be greater than 0.");
        }

        _queue = new T[initialCapacity];
        _size = 0;
    }

    /// <summary>
    /// Adds an element to the priority queue.
    /// </summary>
    public void Add(T element)
    {
        if (_size == _queue.Length)
        {
            Resize(_queue.Length * 2);
        }

        _queue[_size] = element;
        BubbleUp(_size);
        _size++;
    }

    /// <summary>
    /// Returns the element with the highest priority without removing it.
    /// </summary>
    public T Peek()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Priority Queue is empty.");
        }

        return _queue[0];
    }

    /// <summary>
    /// Removes and returns the element with the highest priority.
    /// </summary>
    public T Poll()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Priority Queue is empty.");
        }

        T highestPriority = _queue[0];
        _queue[0] = _queue[_size - 1];
        _size--;
        BubbleDown(0);

        // Optionally shrink the array if it's less than a quarter full
        if (_size > 0 && _size <= _queue.Length / 4)
        {
            Resize(_queue.Length / 2);
        }

        return highestPriority;
    }

    /// <summary>
    /// Returns the number of elements in the priority queue.
    /// </summary>
    public int Size() => _size;

    /// <summary>
    /// Checks if the priority queue is empty.
    /// </summary>
    public bool IsEmpty() => _size == 0;

    private void BubbleUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;

            if (_queue[index].CompareTo(_queue[parentIndex]) >= 0)
            {
                break;
            }

            SwapElements(index, parentIndex);
            index = parentIndex;
        }
    }

    private void BubbleDown(int index)
    {
        while (index < _size / 2)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            int smallerChildIndex = leftChildIndex;
            if (rightChildIndex < _size && _queue[rightChildIndex].CompareTo(_queue[leftChildIndex]) < 0)
            {
                smallerChildIndex = rightChildIndex;
            }

            if (_queue[index].CompareTo(_queue[smallerChildIndex]) <= 0)
            {
                break;
            }

            SwapElements(index, smallerChildIndex);
            index = smallerChildIndex;
        }
    }

    private void SwapElements(int i, int j)
    {
        (_queue[i], _queue[j]) = (_queue[j], _queue[i]);
    }

    private void Resize(int newCapacity)
    {
        T[] newQueue = new T[newCapacity];
        Array.Copy(_queue, newQueue, _size);
        _queue = newQueue;
    }
}