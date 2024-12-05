using BenchmarkDotNet.Attributes;

namespace adp.Benchmarks;

[MemoryDiagnoser]
public class PriorityQueueBenchmarks
{
    private int[] _randomNumbers;
    private PriorityQueueImplementation<int> _priorityQueue;

    [Params(1_000, 10_000)] public int ItemCount;

    [GlobalSetup]
    public void Setup()
    {
        _priorityQueue = new PriorityQueueImplementation<int>();
        var random = new Random();
        _randomNumbers = new int[ItemCount];
        for (int i = 0; i < ItemCount; i++)
        {
            _randomNumbers[i] = random.Next(1, ItemCount);
        }
        
        for (int i = 0; i < ItemCount; i++)
        {
            _priorityQueue.Add(_randomNumbers[i], _randomNumbers[i]);
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
    public void PollWithCreatinElements()
    {
        var priorityQueue = new PriorityQueueImplementation<int>();
        for (int i = 0; i < ItemCount; i++)
        {
            priorityQueue.Add(_randomNumbers[i], _randomNumbers[i]);
        }
        
        priorityQueue.Poll();
    }
    
    [Benchmark]
    public void PollElements()
    {
        var priorityQueue = new PriorityQueueImplementation<int>();
        priorityQueue.Add(3, 1);
        
        priorityQueue.Poll();
    }

    [Benchmark]
    public void PeekElement()
    {
        _ = _priorityQueue.Peek();
    }
}