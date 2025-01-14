using BenchmarkDotNet.Attributes;
using adp.Searches;

namespace Benchmarks.Searches;

[MemoryDiagnoser] // Ensures memory allocations are measured
public class BinarySearchTreeBenchmarks
{
    private BinarySearchTreeImplementation<int> _bstSorted;
    private BinarySearchTreeImplementation<int> _bstRandom;
    private BinarySearchTreeImplementation<int> _bstRepeated;

    private int[] _sortedDataset;
    private int[] _randomDataset;
    private int[] _repeatedDataset;

    private int _target;
    private int _nonExistentTarget;

    [Params(100, 1_000)] // Benchmark for dataset sizes 100 and 1,000
    public int DatasetSize;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random();

        // Prepare datasets
        _sortedDataset = Enumerable.Range(1, DatasetSize).ToArray(); // Sorted dataset
        _randomDataset = Enumerable.Range(1, DatasetSize).OrderBy(_ => random.Next()).ToArray(); // Random dataset
        _repeatedDataset = Enumerable.Repeat(1, DatasetSize).ToArray(); // Repeated values dataset

        // Initialize trees
        _bstSorted = new BinarySearchTreeImplementation<int>((x, y) => x.CompareTo(y));
        _bstRandom = new BinarySearchTreeImplementation<int>((x, y) => x.CompareTo(y));
        _bstRepeated = new BinarySearchTreeImplementation<int>((x, y) => x.CompareTo(y));

        // Populate trees
        foreach (var value in _sortedDataset)
        {
            _bstSorted.Insert(value);
        }
        foreach (var value in _randomDataset)
        {
            _bstRandom.Insert(value);
        }
        foreach (var value in _repeatedDataset)
        {
            _bstRepeated.Insert(value);
        }

        // Define target values
        _target = DatasetSize / 2; // A value in the middle of the dataset
        _nonExistentTarget = DatasetSize + 1; // A value outside the dataset
    }

    [Benchmark]
    public void InsertSortedDataset()
    {
        var bst = new BinarySearchTreeImplementation<int>((x, y) => x.CompareTo(y));
        foreach (var value in _sortedDataset)
        {
            bst.Insert(value);
        }
    }

    [Benchmark]
    public void InsertRandomDataset()
    {
        var bst = new BinarySearchTreeImplementation<int>((x, y) => x.CompareTo(y));
        foreach (var value in _randomDataset)
        {
            bst.Insert(value);
        }
    }

    [Benchmark]
    public void InsertRepeatedDataset()
    {
        var bst = new BinarySearchTreeImplementation<int>((x, y) => x.CompareTo(y));
        foreach (var value in _repeatedDataset)
        {
            bst.Insert(value);
        }
    }

    [Benchmark]
    public void FindInSortedDataset()
    {
        _bstSorted.Find(_target);
    }

    [Benchmark]
    public void FindNonExistentInSortedDataset()
    {
        _bstSorted.Find(_nonExistentTarget);
    }

    [Benchmark]
    public void RemoveFromSortedDataset()
    {
        var bst = new BinarySearchTreeImplementation<int>((x, y) => x.CompareTo(y));
        foreach (var value in _sortedDataset)
        {
            bst.Insert(value);
        }

        foreach (var value in _sortedDataset)
        {
            bst.Remove(value);
        }
    }

    [Benchmark]
    public void FindMinInSortedDataset()
    {
        _bstSorted.FindMin();
    }

    [Benchmark]
    public void FindMaxInSortedDataset()
    {
        _bstSorted.FindMax();
    }
}
