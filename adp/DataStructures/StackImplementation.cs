namespace adp;

public class StackImplementation<T>
{
    private T[] _array = new T[4];
    private int _size;

    public void Push(T element)
    {
        EnsureCapacity();
        _array[_size++] = element;
    }

    public T Pop()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        var element = _array[--_size];
        _array[_size] = default!;

        ShrinkCapacity();
        return element;
    }

    public T Peek() => Top();

    public T Top()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _array[_size - 1];
    }

    public bool IsEmpty() => _size == 0;

    public int Size() => _size;

    private void EnsureCapacity()
    {
        if (_size >= _array.Length)
        {
            ResizeArray(_array.Length * 2);
        }
    }

    private void ShrinkCapacity()
    {
        if (_size > 0 && _size <= _array.Length / 2)
        {
            ResizeArray(_array.Length / 2);
        }
    }

    private void ResizeArray(int newCapacity)
    {
        var newArray = new T[newCapacity];
        for (var i = 0; i < _size; i++)
        {
            newArray[i] = _array[i];
        }

        _array = newArray;
    }
}