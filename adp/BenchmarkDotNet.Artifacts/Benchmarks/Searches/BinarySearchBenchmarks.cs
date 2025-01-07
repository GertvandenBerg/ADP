using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace adp.Benchmarks;

[MemoryDiagnoser]
public class BinarySearchBenchmarks
{
    private int[] _sortedArray;
    private int _targetExists;
    private int _targetDoesNotExist;

    [Params(1_000, 10_000, 100_000)]
    public int ArraySize;

    [GlobalSetup]
    public void Setup()
    {
        _sortedArray = Enumerable.Range(1, ArraySize).ToArray();
        _targetExists = _sortedArray[ArraySize / 2]; // Middle element
        _targetDoesNotExist = ArraySize + 1; // Element guaranteed to not exist
    }

    [Benchmark]
    public int SearchExistingElement()
    {
        var searcher = new BinarySearchImplementation();
        return BinarySearchImplementation.BinarySearch(_sortedArray, _targetExists, (a, b) => a.CompareTo(b));
    }

    [Benchmark]
    public int SearchNonExistingElement()
    {
        var searcher = new BinarySearchImplementation();
        return BinarySearchImplementation.BinarySearch(_sortedArray, _targetDoesNotExist, (a, b) => a.CompareTo(b));
    }
}