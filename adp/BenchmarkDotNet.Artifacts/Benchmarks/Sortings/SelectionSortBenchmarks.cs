using adp.Sortings;
using BenchmarkDotNet.Attributes;

namespace adp.BenchmarkDotNet.Artifacts.Benchmarks.Sortings;

[MemoryDiagnoser]
public class SelectionSortBenchmarks
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
    public void SelectionSort_RandomArray()
    {
        var sorter = new SelectionSortImplementation();
        var arrayToSort = (int[])_randomArray.Clone();
        SelectionSortImplementation.SelectionSort(arrayToSort, (a, b) => a.CompareTo(b));
    }

    [Benchmark]
    public void SelectionSort_SortedArray()
    {
        var sorter = new SelectionSortImplementation();
        var arrayToSort = (int[])_sortedArray.Clone();
        SelectionSortImplementation.SelectionSort(arrayToSort, (a, b) => a.CompareTo(b));
    }

    [Benchmark]
    public void SelectionSort_ReverseSortedArray()
    {
        var sorter = new SelectionSortImplementation();
        var arrayToSort = (int[])_reverseSortedArray.Clone();
        SelectionSortImplementation.SelectionSort(arrayToSort, (a, b) => a.CompareTo(b));
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