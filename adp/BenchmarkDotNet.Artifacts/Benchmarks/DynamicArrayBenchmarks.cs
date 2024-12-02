using BenchmarkDotNet.Attributes;

namespace adp.BenchmarkDotNet.Artifacts.Benchmarks;

[MemoryDiagnoser]
public class DynamicArrayBenchmarks
{
    private int[] _randomNumbers;

    [Params(1_000, 10_000, 100_000)] public int ItemCount;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random();
        _randomNumbers = new int[ItemCount];
        for (int i = 0; i < ItemCount; i++)
        {
            _randomNumbers[i] = random.Next(1, ItemCount);
        }
    }

    [Benchmark]
    public void AddElements()
    {
        var dynamicArray = new DynamicArrayImplementation<int>();
        for (int i = 0; i < ItemCount; i++)
        {
            dynamicArray.Add(_randomNumbers[i]);
        }
    }

    [Benchmark]
    public void GetElements()
    {
        var dynamicArray = new DynamicArrayImplementation<int>();
        for (int i = 0; i < ItemCount; i++)
        {
            dynamicArray.Add(_randomNumbers[i]);
        }

        for (int i = 0; i < ItemCount; i++)
        {
            _ = dynamicArray.Get(i);
        }
    }

    [Benchmark]
    public void SetElements()
    {
        var dynamicArray = new DynamicArrayImplementation<int>();
        for (int i = 0; i < ItemCount; i++)
        {
            dynamicArray.Add(_randomNumbers[i]);
        }

        for (int i = 0; i < ItemCount; i++)
        {
            dynamicArray.Set(i, _randomNumbers[i] * 2);
        }
    }

    [Benchmark]
    public void RemoveElements()
    {
        var dynamicArray = new DynamicArrayImplementation<int>();
        for (int i = 0; i < ItemCount; i++)
        {
            dynamicArray.Add(_randomNumbers[i]);
        }

        for (int i = ItemCount - 1; i >= 0; i--)
        {
            dynamicArray.Remove(i);
        }
    }

    [Benchmark]
    public void ContainsElements()
    {
        var dynamicArray = new DynamicArrayImplementation<int>();
        for (int i = 0; i < ItemCount; i++)
        {
            dynamicArray.Add(_randomNumbers[i]);
        }

        foreach (var number in _randomNumbers)
        {
            _ = dynamicArray.Contains(number);
        }
    }

    [Benchmark]
    public void IndexOfElements()
    {
        var dynamicArray = new DynamicArrayImplementation<int>();
        for (int i = 0; i < ItemCount; i++)
        {
            dynamicArray.Add(_randomNumbers[i]);
        }

        foreach (var number in _randomNumbers)
        {
            _ = dynamicArray.IndexOf(number);
        }
    }
}