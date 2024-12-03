using BenchmarkDotNet.Attributes;

namespace adp.Benchmarks;

[MemoryDiagnoser]
public class PriorityQueueBenchmarks
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
    public void AddElements()
    {
        var priorityQueue = new PriorityQueueImplementation<int>();
        for (int i = 0; i < ItemCount; i++)
        {
            priorityQueue.Add(_randomNumbers[i], _randomNumbers[i]);
        }
    }

    [Benchmark]
    public void PollElements()
    {
        var priorityQueue = new PriorityQueueImplementation<int>();
        for (int i = 0; i < ItemCount; i++)
        {
            priorityQueue.Add(_randomNumbers[i], _randomNumbers[i]);
        }

        while (!priorityQueue.IsEmpty())
        {
            priorityQueue.Poll();
        }
    }

    [Benchmark]
    public void PeekElement()
    {
        var priorityQueue = new PriorityQueueImplementation<int>();
        priorityQueue.Add(42, 1);
        _ = priorityQueue.Peek();
    }
}