using adp.Sortings;
using BenchmarkDotNet.Attributes;

namespace adp.BenchmarkDotNet.Artifacts.Benchmarks.Sortings;

[MemoryDiagnoser]
public class QuickSortBenchmarks
{
    private int[] _randomArray;
    private int[] _sortedArray;
    private int[] _reverseSortedArray;

    [Params(1_000, 10_000, 100_000)]
    public int ArraySize;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random();

        _randomArray = Enumerable.Range(1, ArraySize).OrderBy(_ => random.Next()).ToArray();
        _sortedArray = Enumerable.Range(1, ArraySize).ToArray();
        _reverseSortedArray = Enumerable.Range(1, ArraySize).Reverse().ToArray();
    }

    [Benchmark]
    public void QuickSort_RandomArray()
    {
        var arrayToSort = (int[])_randomArray.Clone(); // Clone to avoid modifying the original
        QuickSortImplementation.QuickSort(arrayToSort, (a, b) => a.CompareTo(b));
    }

    [Benchmark]
    public void QuickSort_SortedArray()
    {
        var arrayToSort = (int[])_sortedArray.Clone();
        QuickSortImplementation.QuickSort(arrayToSort, (a, b) => a.CompareTo(b));
    }

    [Benchmark]
    public void QuickSort_ReverseSortedArray()
    {
        var arrayToSort = (int[])_reverseSortedArray.Clone();
        QuickSortImplementation.QuickSort(arrayToSort, (a, b) => a.CompareTo(b));
    }

    [Benchmark]
    public void ArraySort_RandomArray()
    {
        var arrayToSort = (int[])_randomArray.Clone();
        Array.Sort(arrayToSort);
    }

    [Benchmark]
    public void ArraySort_SortedArray()
    {
        var arrayToSort = (int[])_sortedArray.Clone();
        Array.Sort(arrayToSort);
    }

    [Benchmark]
    public void ArraySort_ReverseSortedArray()
    {
        var arrayToSort = (int[])_reverseSortedArray.Clone();
        Array.Sort(arrayToSort);
    }
}