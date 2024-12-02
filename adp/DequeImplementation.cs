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

    public void InsertLeft(T item)
    {
        var newNode = new Node(item);

        if (_head == null)
        {
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

    public void InsertRight(T item)
    {
        var newNode = new Node(item);

        if (_tail == null)
        {
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

    public T DeleteLeft()
    {
        if (_head == null)
            throw new InvalidOperationException("Deque is empty.");

        T data = _head.Data;
        _head = _head.Next;

        if (_head != null)
            _head.Prev = null;
        else
            _tail = null;

        _size--;
        return data;
    }

    public T DeleteRight()
    {
        if (_tail == null)
            throw new InvalidOperationException("Deque is empty.");

        T data = _tail.Data;
        _tail = _tail.Prev;

        if (_tail != null)
            _tail.Next = null;
        else
            _head = null;

        _size--;
        return data;
    }

    public int Size()
    {
        return _size;
    }
}