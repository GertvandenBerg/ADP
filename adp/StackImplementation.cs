namespace adp;

public class StackImplementation<T>
{
    private T[] _array = [];
    private int _size;
    
    public void Push(T element)
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
    
    public T Pop()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException();
        }
        
        var element = _array[--_size];
        
        if (_size < _array.Length)
        {
            var newArray = new T[_size];
            for (var i = 0; i < _size; i++)
            {
                newArray[i] = _array[i];
            }
            _array = newArray;
        }
        
        return element;
    }
    
    public T Peek() => Top();
    
    public T Top()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException();
        }
        
        return _array[_size - 1];
    }
    
    public bool IsEmpty() => _size == 0;
    public int Size() => _size;
}