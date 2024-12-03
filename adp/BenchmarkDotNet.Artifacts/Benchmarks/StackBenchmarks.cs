using BenchmarkDotNet.Attributes;

namespace adp.Benchmarks;

[MemoryDiagnoser]
public class StackBenchmarks
{
    private int[] _randomNumbers;

    [Params(1_000, 10_000)] public int ItemCount;

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
    public void PushElements()
    {
        var stack = new StackImplementation<int>();
        for (int i = 0; i < ItemCount; i++)
        {
            stack.Push(_randomNumbers[i]);
        }
    }

    [Benchmark]
    public void PopElements()
    {
        var stack = new StackImplementation<int>();
        for (int i = 0; i < ItemCount; i++)
        {
            stack.Push(_randomNumbers[i]);
        }

        while (!stack.IsEmpty())
        {
            stack.Pop();
        }
    }

    [Benchmark]
    public void PeekElement()
    {
        var stack = new StackImplementation<int>();
        for (int i = 0; i < ItemCount; i++)
        {
            stack.Push(_randomNumbers[i]);
        }

        _ = stack.Peek();
    }
}