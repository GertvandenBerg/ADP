namespace adp;

public class DynamicArrayImplementation<T>
{
    private T[] _array = new T[2];
    private int _size;

    public void Add(T element)
    {
        EnsureCapacity();
        _array[_size++] = element;
    }

    public T Get(int index)
    {
        ValidateIndex(index);
        return _array[index];
    }

    public void Set(int index, T element)
    {
        ValidateIndex(index);
        _array[index] = element;
    }

    public void Remove(int index)
    {
        ValidateIndex(index);

        for (int i = index; i < _size - 1; i++)
        {
            _array[i] = _array[i + 1];
        }

        _size--;
        _array[_size] = default!;
        ShrinkCapacityIfNeeded();
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < _size; i++)
        {
            if (_array[i]!.AreEqual(element))
            {
                return true;
            }
        }

        return false;
    }

    public int IndexOf(T element)
    {
        for (int i = 0; i < _size; i++)
        {
            if (_array[i]!.AreEqual(element))
            {
                return i;
            }
        }

        return -1;
    }

    private void EnsureCapacity()
    {
        if (_size >= _array.Length)
        {
            ResizeArray(_array.Length * 2);
        }
    }

    private void ShrinkCapacityIfNeeded()
    {
        var newCapacity = _array.Length * 2;

        if (_size > 0 && _size <= newCapacity)
        {
            ResizeArray(newCapacity);
        }
    }

    private void ResizeArray(int newCapacity)
    {
        var newArray = new T[newCapacity];
        for (int i = 0; i < _size; i++)
        {
            newArray[i] = _array[i];
        }

        _array = newArray;
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException($"Index {index} is out of range. Size: {_size}");
        }
    }
}