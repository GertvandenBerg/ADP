namespace adp;

public class DequeImplementation<T>
{
    private class Node
    {
        public T Data;
        public Node? Next;
        public Node? Prev;

        public Node(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    private Node? _head;
    private Node? _tail;
    private int _size;

    public DequeImplementation()
    {
        _head = null;
        _tail = null;
        _size = 0;
    }

    /// <summary>
    /// Inserts an element at the front (left end) of the deque.
    /// </summary>
    public void InsertLeft(T item)
    {
        var newNode = new Node(item);

        if (_head == null)
        {
            // Deque is empty
            _head = _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }

        _size++;
    }

    /// <summary>
    /// Inserts an element at the back (right end) of the deque.
    /// </summary>
    public void InsertRight(T item)
    {
        var newNode = new Node(item);

        if (_tail == null)
        {
            // Deque is empty
            _head = _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }

        _size++;
    }

    /// <summary>
    /// Removes and returns the element from the front (left end) of the deque.
    /// </summary>
    public T DeleteLeft()
    {
        if (_head == null)
            throw new InvalidOperationException("Deque is empty.");

        T data = _head.Data;
        _head = _head.Next;

        if (_head != null)
            _head.Prev = null;
        else
            _tail = null; // Deque is now empty

        _size--;
        return data;
    }

    /// <summary>
    /// Removes and returns the element from the back (right end) of the deque.
    /// </summary>
    public T DeleteRight()
    {
        if (_tail == null)
            throw new InvalidOperationException("Deque is empty.");

        T data = _tail.Data;
        _tail = _tail.Prev;

        if (_tail != null)
            _tail.Next = null;
        else
            _head = null; // Deque is now empty

        _size--;
        return data;
    }

    /// <summary>
    /// Returns the number of elements in the deque.
    /// </summary>
    public int Size()
    {
        return _size;
    }
}