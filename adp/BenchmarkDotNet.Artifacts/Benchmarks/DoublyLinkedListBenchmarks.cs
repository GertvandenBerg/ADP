using BenchmarkDotNet.Attributes;

namespace adp.BenchmarkDotNet.Artifacts.Benchmarks;

[MemoryDiagnoser]
public class DoublyLinkedListBenchmarks
{
    private int[] _randomNumbers;
    private DoublyLinkedListImplementation<int> _list;

    [Params(1_000, 10_000)] public int ItemCount;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random();
        _randomNumbers = new int[ItemCount];
        _list = new DoublyLinkedListImplementation<int>();

        for (int i = 0; i < ItemCount; i++)
        {
            _randomNumbers[i] = random.Next(1, ItemCount);
        }
    }

    [Benchmark]
    public void AddElements()
    {
        var list = new DoublyLinkedListImplementation<int>();
        foreach (var number in _randomNumbers)
        {
            list.Add(number);
        }
    }

    [Benchmark]
    public void GetElements()
    {
        foreach (var number in _randomNumbers)
        {
            _list.Add(number);
        }

        for (int i = 0; i < ItemCount; i++)
        {
            _ = _list.Get(i);
        }
    }

    [Benchmark]
    public void SetElements()
    {
        foreach (var number in _randomNumbers)
        {
            _list.Add(number);
        }

        for (int i = 0; i < ItemCount; i++)
        {
            _list.Set(i, _randomNumbers[i] * 2);
        }
    }

    [Benchmark]
    public void RemoveAtIndex()
    {
        foreach (var number in _randomNumbers)
        {
            _list.Add(number);
        }

        for (int i = ItemCount - 1; i >= 0; i--)
        {
            _list.RemoveAtIndex(i);
        }
    }

    [Benchmark]
    public void ContainsElements()
    {
        foreach (var number in _randomNumbers)
        {
            _list.Add(number);
        }

        foreach (var number in _randomNumbers)
        {
            _ = _list.Contains(number);
        }
    }

    [Benchmark]
    public void IndexOfElements()
    {
        foreach (var number in _randomNumbers)
        {
            _list.Add(number);
        }

        foreach (var number in _randomNumbers)
        {
            _ = _list.IndexOf(number);
        }
    }

    [Benchmark]
    public void RemoveByValue()
    {
        foreach (var number in _randomNumbers)
        {
            _list.Add(number);
        }

        foreach (var number in _randomNumbers)
        {
            _list.Remove(number);
        }
    }
}
