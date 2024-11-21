namespace adp;

public class DynamicArrayImplementation<T>
{
    private T[] _array = [];
    private int _size;
    
    public void Add(T element)
    {
        if (_array.Length == _size)
        {
            var newArray = new T[_size + 1];
            for (int i = 0; i < _size; i++)
            {
                newArray[i] = _array[i];
            }
            _array = newArray;
        }
        _array[_size++] = element;
    }
    
    public T Get(int index)
    {
        return _array[index];
    }
    
    public void Set(int index, T element)
    {
        _array[index] = element;
    }

    public void Remove(int index)
    {
        for (int i = index; i < _size - 1; i++)
        {
            _array[i] = _array[i + 1];
        }
        
        _size--;
        
        if (_size < _array.Length)
        {
            var newArray = new T[_size];
            for (var i = 0; i < _size; i++)
            {
                newArray[i] = _array[i];
            }
            _array = newArray;
        }
    }
    
    public bool Contains(T element)
    {
        for (int i = 0; i < _size; i++)
        {
            if (_array[i]!.Equals(element))
            {
                return true;
            }
        }
        return false;
    }
    
    public int IndexOf(T element)
    {
        for (var i = 0; i < _size; i++)
        {
            if (_array[i]!.Equals(element))
            {
                return i;
            }
        }
        return -1;
    }
}