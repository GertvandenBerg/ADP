using adp.Sortings;
using BenchmarkDotNet.Attributes;

namespace adp.BenchmarkDotNet.Artifacts.Benchmarks.Sortings;

[MemoryDiagnoser]
public class InsertionSortBenchmarks
{
    private int[] _randomIntArray;
    private int[] _sortedIntArray;
    private int[] _reverseSortedIntArray;
    private string[] _randomStringArray;

    [Params(1_000, 10_000, 100_000)]
    public int ArraySize;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random();

        _randomIntArray = Enumerable.Range(1, ArraySize).OrderBy(_ => random.Next()).ToArray();
        _sortedIntArray = Enumerable.Range(1, ArraySize).ToArray();
        _reverseSortedIntArray = Enumerable.Range(1, ArraySize).Reverse().ToArray();
        _randomStringArray = Enumerable.Range(1, ArraySize)
            .Select(_ => Guid.NewGuid().ToString())
            .ToArray();
    }

    [Benchmark]
    public void SortRandomIntArray()
    {
        var sorter = new InsertionSortImplementation();
        var arrayToSort = (int[])_randomIntArray.Clone();
        InsertionSortImplementation.InsertionSort(arrayToSort, (a, b) => a.CompareTo(b));
    }

    [Benchmark]
    public void SortSortedIntArray()
    {
        var sorter = new InsertionSortImplementation();
        var arrayToSort = (int[])_sortedIntArray.Clone();
        InsertionSortImplementation.InsertionSort(arrayToSort, (a, b) => a.CompareTo(b));
    }

    [Benchmark]
    public void SortReverseSortedIntArray()
    {
        var sorter = new InsertionSortImplementation();
        var arrayToSort = (int[])_reverseSortedIntArray.Clone();
        InsertionSortImplementation.InsertionSort(arrayToSort, (a, b) => a.CompareTo(b));
    }

    [Benchmark]
    public void SortRandomStringArray()
    {
        var sorter = new InsertionSortImplementation();
        var arrayToSort = (string[])_randomStringArray.Clone();
        InsertionSortImplementation.InsertionSort(arrayToSort, (a, b) => string.Compare(a, b));
    }
}