using adp;

namespace Tests;

public class BinarySearchImplementationTests
{
    [Fact]
    public void BinarySearch_FindsElementInArray()
    {
        int[] sortedArray = [1, 3, 5, 7, 9];

        var result = BinarySearchImplementation.BinarySearch(sortedArray, 5, (a, b) => a.CompareTo(b));

        Assert.Equal(2, result);
    }

    [Fact]
    public void BinarySearch_ReturnsNegativeOne_WhenElementNotFound()
    {
        int[] sortedArray = [1, 3, 5, 7, 9];

        var result = BinarySearchImplementation.BinarySearch(sortedArray, 4, (a, b) => a.CompareTo(b));

        Assert.Equal(-1, result);
    }

    [Fact]
    public void BinarySearch_FindsFirstElement()
    {
        int[] sortedArray = [1, 3, 5, 7, 9];

        var result = BinarySearchImplementation.BinarySearch(sortedArray, 1, (a, b) => a.CompareTo(b));

        Assert.Equal(0, result);
    }

    [Fact]
    public void BinarySearch_FindsLastElement()
    {
        int[] sortedArray = [1, 3, 5, 7, 9];

        var result = BinarySearchImplementation.BinarySearch(sortedArray, 9, (a, b) => a.CompareTo(b));

        Assert.Equal(4, result);
    }

    [Fact]
    public void BinarySearch_HandlesEmptyArray()
    {
        int[] sortedArray = [];

        var result = BinarySearchImplementation.BinarySearch(sortedArray, 5, (a, b) => a.CompareTo(b));

        Assert.Equal(-1, result);
    }

    [Fact]
    public void BinarySearch_FindsElementInSingleElementArray()
    {
        var searcher = new BinarySearchImplementation();
        int[] sortedArray = { 5 };

        var result = BinarySearchImplementation.BinarySearch(sortedArray, 5, (a, b) => a.CompareTo(b));

        Assert.Equal(0, result);
    }

    [Fact]
    public void BinarySearch_ReturnsNegativeOne_WhenSingleElementNotFound()
    {
        int[] sortedArray = [5];

        var result = BinarySearchImplementation.BinarySearch(sortedArray, 3, (a, b) => a.CompareTo(b));

        Assert.Equal(-1, result);
    }

    [Fact]
    public void BinarySearch_WorksForStrings()
    {
        string[] sortedArray = ["apple", "banana", "cherry", "date", "fig"];

        var result = BinarySearchImplementation.BinarySearch(sortedArray, "cherry", (a, b) => string.Compare(a, b));

        Assert.Equal(2, result);
    }

    [Fact]
    public void BinarySearch_ReturnsNegativeOne_WhenStringNotFound()
    {
        string[] sortedArray = ["apple", "banana", "cherry", "date", "fig"];

        var result = BinarySearchImplementation.BinarySearch(sortedArray, "grape", (a, b) => string.Compare(a, b));

        Assert.Equal(-1, result);
    }
        
    [Fact]
    public void BinarySearch_HandlesLargeDataset_CorrectlyAndCountsSteps()
    {
        var largeArray = Enumerable.Range(0, 1_000_001).ToArray();
        const int target = 987_654;
        var steps = 0;

        var result = BinarySearchImplementation.BinarySearch(largeArray, target, (a, b) =>
        {
            steps++;
            return a.CompareTo(b);
        });

        // Verify that the target is found
        Assert.Equal(target, largeArray[result]);
        // Verify the number of steps is within the expected range for binary search
        Assert.True(steps <= Math.Ceiling(Math.Log2(largeArray.Length)), "Too many steps taken in binary search.");
    }

    [Fact]
    public void HandleDatasetLijstAflopend2()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var binarySearch = BinarySearchImplementation.BinarySearch(dataset.LijstAflopend2, 1, (a, b) => a.CompareTo(b));
        
        // Assert
        Assert.Equal(0, binarySearch);
    }
    
    [Fact]
    public void HandleDatasetLijstOplopend2()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var binarySearch = BinarySearchImplementation.BinarySearch(dataset.LijstOplopend2, 1, (a, b) => a.CompareTo(b));
        
        // Assert
        Assert.Equal(-1, binarySearch);
    }

    [Fact]
    public void HandleDatasetLijstFloat8001()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var binarySearch = BinarySearchImplementation.BinarySearch(dataset.LijstFloat8001, 1, (a, b) => a.CompareTo(b));
        
        // Assert
        Assert.Equal(7750, binarySearch);
    }
    
    [Fact]
    public void HandleDatasetLijstGesorteerdAflopend3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var binarySearch = BinarySearchImplementation.BinarySearch(dataset.LijstGesorteerdAflopend3, 1, (a, b) => a.CompareTo(b));
        
        // Assert
        Assert.Equal(-1, binarySearch);
    }
    
    [Fact]
    public void HandleDatasetLijstGesorteerdOplopend3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var binarySearch = BinarySearchImplementation.BinarySearch(dataset.LijstGesorteerdOplopend3, 1, (a, b) => a.CompareTo(b));

        
        // Assert
        Assert.Equal(0, binarySearch);
    }

    [Fact]
    public void HandleDatasetLijstHerhaald1000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var binarySearch = BinarySearchImplementation.BinarySearch(dataset.LijstHerhaald1000, 1, (a, b) => a.CompareTo(b));

        
        // Assert
        Assert.Equal(4999, binarySearch);
    }
    
    
    [Fact]
    public void HandleDatasetLijstLeeg0()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var binarySearch = BinarySearchImplementation.BinarySearch(dataset.LijstLeeg0, 1, (a, b) => a.CompareTo(b));

        
        // Assert
        Assert.Equal(-1, binarySearch);
    }
    
    [Fact]
    public void HandleDatasetLijstNull1()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var binarySearch = BinarySearchImplementation.BinarySearch(dataset.LijstNull1, 1, (a, b) =>
        {
            if (a == null && b == null)
            {
                return 0;
            }

            if (a == null)
            {
                return -1;
            }

            if (b == null)
            {
                return 1;
            }

            return a.Value.CompareTo(b.Value);
        });

        
        // Assert
        Assert.Equal(-1, binarySearch);
    }
    
    [Fact]
    public void HandleDatasetLijstNull3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var binarySearch = BinarySearchImplementation.BinarySearch(dataset.LijstNull3, 1, (a, b) =>
        {
            if (a == null && b == null)
            {
                return 0;
            }

            if (a == null)
            {
                return -1;
            }

            if (b == null)
            {
                return 1;
            }

            return a.Value.CompareTo(b.Value);
        });
        
        // Assert
        Assert.Equal(-1, binarySearch);
    }
    
    [Fact]
    public void HandleDatasetLijstOnsorteerbaar3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var binarySearch = BinarySearchImplementation.BinarySearch(dataset.LijstOnsorteerbaar3, 1, (_, _) => 0);

        
        // Assert
        Assert.Equal(1, binarySearch);
    }
    
    [Fact]
    public void HandleDatasetLijstOplopend10000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var binarySearch = BinarySearchImplementation.BinarySearch(dataset.LijstGesorteerdOplopend3, 1, (a, b) => a.CompareTo(b));
        
        // Assert
        Assert.Equal(0, binarySearch);
    }
    
    [Fact]
    public void HandleDatasetLijstWillekeurig10000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var binarySearch = BinarySearchImplementation.BinarySearch(dataset.LijstWillekeurig10000, 1, (a, b) => a.CompareTo(b));

        
        // Assert
        Assert.Equal(-1, binarySearch);
    }
    
    [Fact]
    public void HandleDatasetLijstWillekeurig3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var binarySearch = BinarySearchImplementation.BinarySearch(dataset.LijstWillekeurig3, 1, (_, _) => 0);

        
        // Assert
        Assert.Equal(1, binarySearch);
    }
}