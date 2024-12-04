using adp;

namespace Tests;

public class SelectionSortImplementationTests
{
    [Fact]
    public void SelectionSort_SortsIntegersInAscendingOrder()
    {
        var sorter = new SelectionSortImplementation();
        int[] array = { 9, 7, 5, 3, 1 };

        sorter.SelectionSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal(new int[] { 1, 3, 5, 7, 9 }, array);
    }

    [Fact]
    public void SelectionSort_SortsIntegersInDescendingOrder()
    {
        var sorter = new SelectionSortImplementation();
        int[] array = { 1, 3, 5, 7, 9 };

        sorter.SelectionSort(array, (a, b) => b.CompareTo(a));

        Assert.Equal(new int[] { 9, 7, 5, 3, 1 }, array);
    }

    [Fact]
    public void SelectionSort_SortsStringArrayAlphabetically()
    {
        var sorter = new SelectionSortImplementation();
        string[] array = { "banana", "apple", "cherry", "date" };

        sorter.SelectionSort(array, (a, b) => string.Compare(a, b));

        Assert.Equal(new string[] { "apple", "banana", "cherry", "date" }, array);
    }

    [Fact]
    public void SelectionSort_HandlesEmptyArray()
    {
        var sorter = new SelectionSortImplementation();
        int[] array = { };

        sorter.SelectionSort(array, (a, b) => a.CompareTo(b));

        Assert.Empty(array);
    }

    [Fact]
    public void SelectionSort_HandlesSingleElementArray()
    {
        var sorter = new SelectionSortImplementation();
        int[] array = { 42 };

        sorter.SelectionSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal(new int[] { 42 }, array);
    }

    [Fact]
    public void SelectionSort_HandlesAlreadySortedArray()
    {
        var sorter = new SelectionSortImplementation();
        int[] array = { 1, 2, 3, 4, 5 };

        sorter.SelectionSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, array);
    }

    [Fact]
    public void SelectionSort_HandlesReverseSortedArray()
    {
        var sorter = new SelectionSortImplementation();
        int[] array = { 5, 4, 3, 2, 1 };

        sorter.SelectionSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, array);
    }

    [Fact]
    public void SelectionSort_SortsCustomObjects()
    {
        var sorter = new SelectionSortImplementation();
        var people = new[]
        {
            new Person { Name = "John", Age = 25 },
            new Person { Name = "Alice", Age = 30 },
            new Person { Name = "Bob", Age = 20 }
        };

        sorter.SelectionSort(people, (a, b) => a.Age.CompareTo(b.Age));

        Assert.Equal("Bob", people[0].Name);
        Assert.Equal("John", people[1].Name);
        Assert.Equal("Alice", people[2].Name);
    }

    private class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}