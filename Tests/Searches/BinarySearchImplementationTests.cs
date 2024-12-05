using adp;

namespace Tests;

public class BinarySearchImplementationTests
{
    [Fact]
    public void BinarySearch_FindsElementInArray()
    {
        var searcher = new BinarySearchImplementation();
        int[] sortedArray = [1, 3, 5, 7, 9];

        var result = searcher.BinarySearch(sortedArray, 5, (a, b) => a.CompareTo(b));

        Assert.Equal(2, result);
    }

    [Fact]
    public void BinarySearch_ReturnsNegativeOne_WhenElementNotFound()
    {
        var searcher = new BinarySearchImplementation();
        int[] sortedArray = [1, 3, 5, 7, 9];

        var result = searcher.BinarySearch(sortedArray, 4, (a, b) => a.CompareTo(b));

        Assert.Equal(-1, result);
    }

    [Fact]
    public void BinarySearch_FindsFirstElement()
    {
        var searcher = new BinarySearchImplementation();
        int[] sortedArray = [1, 3, 5, 7, 9];

        var result = searcher.BinarySearch(sortedArray, 1, (a, b) => a.CompareTo(b));

        Assert.Equal(0, result);
    }

    [Fact]
    public void BinarySearch_FindsLastElement()
    {
        var searcher = new BinarySearchImplementation();
        int[] sortedArray = [1, 3, 5, 7, 9];

        var result = searcher.BinarySearch(sortedArray, 9, (a, b) => a.CompareTo(b));

        Assert.Equal(4, result);
    }

    [Fact]
    public void BinarySearch_HandlesEmptyArray()
    {
        var searcher = new BinarySearchImplementation();
        int[] sortedArray = [];

        var result = searcher.BinarySearch(sortedArray, 5, (a, b) => a.CompareTo(b));

        Assert.Equal(-1, result);
    }

    [Fact]
    public void BinarySearch_FindsElementInSingleElementArray()
    {
        var searcher = new BinarySearchImplementation();
        int[] sortedArray = { 5 };

        var result = searcher.BinarySearch(sortedArray, 5, (a, b) => a.CompareTo(b));

        Assert.Equal(0, result);
    }

    [Fact]
    public void BinarySearch_ReturnsNegativeOne_WhenSingleElementNotFound()
    {
        var searcher = new BinarySearchImplementation();
        int[] sortedArray = [5];

        var result = searcher.BinarySearch(sortedArray, 3, (a, b) => a.CompareTo(b));

        Assert.Equal(-1, result);
    }

    [Fact]
    public void BinarySearch_WorksForStrings()
    {
        var searcher = new BinarySearchImplementation();
        string[] sortedArray = ["apple", "banana", "cherry", "date", "fig"];

        var result = searcher.BinarySearch(sortedArray, "cherry", (a, b) => string.Compare(a, b));

        Assert.Equal(2, result);
    }

    [Fact]
    public void BinarySearch_ReturnsNegativeOne_WhenStringNotFound()
    {
        var searcher = new BinarySearchImplementation();
        string[] sortedArray = ["apple", "banana", "cherry", "date", "fig"];

        var result = searcher.BinarySearch(sortedArray, "grape", (a, b) => string.Compare(a, b));

        Assert.Equal(-1, result);
    }
        
    [Fact]
    public void BinarySearch_HandlesLargeDataset_CorrectlyAndCountsSteps()
    {
        var searcher = new BinarySearchImplementation();
        var largeArray = Enumerable.Range(0, 1_000_001).ToArray();
        const int target = 987_654;
        var steps = 0;

        var result = searcher.BinarySearch(largeArray, target, (a, b) =>
        {
            steps++;
            return a.CompareTo(b);
        });

        // Verify that the target is found
        Assert.Equal(target, largeArray[result]);
        // Verify the number of steps is within the expected range for binary search
        Assert.True(steps <= Math.Ceiling(Math.Log2(largeArray.Length)), "Too many steps taken in binary search.");
    }

}