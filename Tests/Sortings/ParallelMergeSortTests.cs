using adp;
using adp.Sortings;

namespace Tests.Sortings;

public class ParallelMergeSortImplementationTests
{
    [Fact]
    public void ParallelMergeSort_SortsIntegersInAscendingOrder()
    {
        int[] array = [9, 7, 5, 3, 1];

        ParallelMergeSortImplementation.ParallelMergeSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal([1, 3, 5, 7, 9], array);
    }

    [Fact]
    public void ParallelMergeSort_SortsIntegersInDescendingOrder()
    {
        int[] array = [1, 3, 5, 7, 9];

        ParallelMergeSortImplementation.ParallelMergeSort(array, (a, b) => b.CompareTo(a));

        Assert.Equal([9, 7, 5, 3, 1], array);
    }

    [Fact]
    public void ParallelMergeSort_SortsStringArrayAlphabetically()
    {
        string[] array = ["banana", "apple", "cherry", "date"];

        ParallelMergeSortImplementation.ParallelMergeSort(array, (a, b) => string.Compare(a, b));

        Assert.Equal(["apple", "banana", "cherry", "date"], array);
    }

    [Fact]
    public void ParallelMergeSort_SortsStringArrayInReverseAlphabeticalOrder()
    {
        string[] array = ["banana", "apple", "cherry", "date"];

        ParallelMergeSortImplementation.ParallelMergeSort(array, (a, b) => string.Compare(b, a));

        Assert.Equal(["date", "cherry", "banana", "apple"], array);
    }

    [Fact]
    public void ParallelMergeSort_HandlesEmptyArray()
    {
        int[] array = [];

        ParallelMergeSortImplementation.ParallelMergeSort(array, (a, b) => a.CompareTo(b));

        Assert.Empty(array);
    }

    [Fact]
    public void ParallelMergeSort_HandlesSingleElementArray()
    {
        int[] array = [42];

        ParallelMergeSortImplementation.ParallelMergeSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal([42], array);
    }

    [Fact]
    public void ParallelMergeSort_HandlesAlreadySortedArray()
    {
        int[] array = { 1, 2, 3, 4, 5 };

        ParallelMergeSortImplementation.ParallelMergeSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal([1, 2, 3, 4, 5], array);
    }

    [Fact]
    public void ParallelMergeSort_HandlesReverseSortedArray()
    {
        int[] array = [5, 4, 3, 2, 1];

        ParallelMergeSortImplementation.ParallelMergeSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal([1, 2, 3, 4, 5], array);
    }

    [Fact]
    public void ParallelMergeSort_SortsCustomObjectsByProperty()
    {
        var people = new[]
        {
            new Person { Name = "John", Age = 25 },
            new Person { Name = "Alice", Age = 30 },
            new Person { Name = "Bob", Age = 20 }
        };

        ParallelMergeSortImplementation.ParallelMergeSort(people, (a, b) => a.Age.CompareTo(b.Age));

        Assert.Equal("Bob", people[0].Name);
        Assert.Equal("John", people[1].Name);
        Assert.Equal("Alice", people[2].Name);
    }

    [Fact]
    public void ParallelMergeSort_SortsCustomObjectsInDescendingOrder()
    {
        var people = new[]
        {
            new Person { Name = "John", Age = 25 },
            new Person { Name = "Alice", Age = 30 },
            new Person { Name = "Bob", Age = 20 }
        };

        ParallelMergeSortImplementation.ParallelMergeSort(people, (a, b) => b.Age.CompareTo(a.Age));

        Assert.Equal("Alice", people[0].Name);
        Assert.Equal("John", people[1].Name);
        Assert.Equal("Bob", people[2].Name);
    }

    private class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}