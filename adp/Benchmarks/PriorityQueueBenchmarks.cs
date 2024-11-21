using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using BenchmarkDotNet.Attributes;

namespace adp.Benchmarks;

[Config(typeof(AntiVirusFriendlyConfig))]
public class PriorityQueueBenchmarks
{
    private PriorityQueueImplementation<int> _priorityQueue;
    private int[] _randomNumbers;

    [Params(1_000, 10_000, 100_000)]
    public int ItemCount;

    [GlobalSetup]
    public void Setup()
    {
        System.Diagnostics.Debugger.Launch();
        _priorityQueue = new PriorityQueueImplementation<int>(ItemCount);
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
        _priorityQueue = new PriorityQueueImplementation<int>(ItemCount);
        for (int i = 0; i < ItemCount; i++)
        {
            _priorityQueue.Add(_randomNumbers[i]);
        }
    }

    [Benchmark]
    public void PollElements()
    {
        // Fill the queue before polling
        for (int i = 0; i < ItemCount; i++)
        {
            _priorityQueue.Add(_randomNumbers[i]);
        }

        while (!_priorityQueue.IsEmpty())
        {
            _priorityQueue.Poll();
        }
    }

    [Benchmark]
    public int PeekElement()
    {
        // Fill the queue with one element
        _priorityQueue.Add(42);

        return _priorityQueue.Peek();
    }
}