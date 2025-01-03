﻿using adp;
using adp.Sortings;

namespace Tests.Sortings;

public class QuickSortImplementationTests
{
    [Fact]
    public void QuickSort_SortsIntegersInAscendingOrder()
    {
        var sorter = new QuickSortImplementation();
        int[] array = [9, 7, 5, 3, 1];

        QuickSortImplementation.QuickSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal([1, 3, 5, 7, 9], array);
    }

    [Fact]
    public void QuickSort_SortsIntegersInDescendingOrder()
    {
        var sorter = new QuickSortImplementation();
        int[] array = [1, 3, 5, 7, 9];

        QuickSortImplementation.QuickSort(array, (a, b) => b.CompareTo(a));

        Assert.Equal([9, 7, 5, 3, 1], array);
    }

    [Fact]
    public void QuickSort_SortsStringArrayAlphabetically()
    {
        var sorter = new QuickSortImplementation();
        string[] array = { "banana", "apple", "cherry", "date" };

        QuickSortImplementation.QuickSort(array, (a, b) => string.CompareOrdinal(a, b));

        Assert.Equal(["apple", "banana", "cherry", "date"], array);
    }

    [Fact]
    public void QuickSort_SortsStringArrayInReverseAlphabeticalOrder()
    {
        var sorter = new QuickSortImplementation();
        string[] array = { "banana", "apple", "cherry", "date" };

        QuickSortImplementation.QuickSort(array, (a, b) => string.CompareOrdinal(b, a));

        Assert.Equal(["date", "cherry", "banana", "apple"], array);
    }

    [Fact]
    public void QuickSort_HandlesEmptyArray()
    {
        var sorter = new QuickSortImplementation();
        int[] array = [];

        QuickSortImplementation.QuickSort(array, (a, b) => a.CompareTo(b));

        Assert.Empty(array);
    }

    [Fact]
    public void QuickSort_HandlesSingleElementArray()
    {
        var sorter = new QuickSortImplementation();
        int[] array = [42];

        QuickSortImplementation.QuickSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal([42], array);
    }

    [Fact]
    public void QuickSort_HandlesAlreadySortedArray()
    {
        var sorter = new QuickSortImplementation();
        int[] array = [1, 2, 3, 4, 5];

        QuickSortImplementation.QuickSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal([1, 2, 3, 4, 5], array);
    }

    [Fact]
    public void QuickSort_HandlesReverseSortedArray()
    {
        var sorter = new QuickSortImplementation();
        int[] array = { 5, 4, 3, 2, 1 };

        QuickSortImplementation.QuickSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal([1, 2, 3, 4, 5], array);
    }

    [Fact]
    public void QuickSort_SortsCustomObjects()
    {
        var sorter = new QuickSortImplementation();
        var people = new[]
        {
            new Person { Name = "John", Age = 25 },
            new Person { Name = "Alice", Age = 30 },
            new Person { Name = "Bob", Age = 20 }
        };

        QuickSortImplementation.QuickSort(people, (a, b) => a.Age.CompareTo(b.Age));

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