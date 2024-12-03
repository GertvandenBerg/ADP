namespace adp;

public class DoublyLinkedListImplementation<T>
{
    private class Node
    {
        public T Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    private Node? _head;
    private Node? _tail;

    public DoublyLinkedListImplementation()
    {
        _head = null;
        _tail = null;
    }

    public void Add(T data)
    {
        var newNode = new Node(data);
        if (_head == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            if (_tail != null)
            {
                _tail.Next = newNode;
                newNode.Prev = _tail;
            }

            _tail = newNode;
        }
    }

    public T Get(int index)
    {
        var current = _head;
        for (var i = 0; i < index; i++)
        {
            if (current == null)
            {
                throw new IndexOutOfRangeException();
            }

            current = current.Next;
        }

        if (current == null)
        {
            throw new IndexOutOfRangeException();
        }

        return current.Data;
    }

    public void Set(int index, T data)
    {
        var current = _head;
        for (var i = 0; i < index; i++)
        {
            if (current == null)
            {
                throw new IndexOutOfRangeException();
            }

            current = current.Next;
        }

        if (current == null)
        {
            throw new IndexOutOfRangeException();
        }

        current.Data = data;
    }

    public bool RemoveAtIndex(int index)
    {
        if (_head == null)
            return false;

        var current = _head;
        for (var i = 0; i < index; i++)
        {
            if (current == null)
            {
                return false;
            }

            current = current.Next;
        }

        if (current == null)
        {
            return false;
        }

        if (current.Prev != null)
        {
            current.Prev.Next = current.Next;
        }
        else
        {
            _head = current.Next;
        }

        if (current.Next != null)
        {
            current.Next.Prev = current.Prev;
        }
        else
        {
            _tail = current.Prev;
        }

        return true;
    }

    public bool Contains(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data != null && DynamicComparable.AreEqual(current.Data,data))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public int IndexOf(T data)
    {
        var current = _head;
        var index = 0;
        while (current != null)
        {
            if (current.Data != null &&  DynamicComparable.AreEqual(current.Data,data))
            {
                return index;
            }

            current = current.Next;
            index++;
        }

        return -1;
    }

    public bool Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data != null &&  DynamicComparable.AreEqual(current.Data,data))
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    _head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    _tail = current.Prev;
                }

                return true;
            }

            current = current.Next;
        }

        return false;
    }
}