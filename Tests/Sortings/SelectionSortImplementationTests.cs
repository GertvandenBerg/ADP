using adp;
using adp.Sortings;

namespace Tests;

public class SelectionSortImplementationTests
{
    [Fact]
    public void SelectionSort_SortsIntegersInAscendingOrder()
    {
        var sorter = new SelectionSortImplementation();
        int[] array = { 9, 7, 5, 3, 1 };

        SelectionSortImplementation.SelectionSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal(new int[] { 1, 3, 5, 7, 9 }, array);
    }

    [Fact]
    public void SelectionSort_SortsIntegersInDescendingOrder()
    {
        var sorter = new SelectionSortImplementation();
        int[] array = { 1, 3, 5, 7, 9 };

        SelectionSortImplementation.SelectionSort(array, (a, b) => b.CompareTo(a));

        Assert.Equal(new int[] { 9, 7, 5, 3, 1 }, array);
    }

    [Fact]
    public void SelectionSort_SortsStringArrayAlphabetically()
    {
        var sorter = new SelectionSortImplementation();
        string[] array = { "banana", "apple", "cherry", "date" };

        SelectionSortImplementation.SelectionSort(array, (a, b) => string.Compare(a, b));

        Assert.Equal(new string[] { "apple", "banana", "cherry", "date" }, array);
    }

    [Fact]
    public void SelectionSort_HandlesEmptyArray()
    {
        var sorter = new SelectionSortImplementation();
        int[] array = { };

        SelectionSortImplementation.SelectionSort(array, (a, b) => a.CompareTo(b));

        Assert.Empty(array);
    }

    [Fact]
    public void SelectionSort_HandlesSingleElementArray()
    {
        var sorter = new SelectionSortImplementation();
        int[] array = { 42 };

        SelectionSortImplementation.SelectionSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal(new int[] { 42 }, array);
    }

    [Fact]
    public void SelectionSort_HandlesAlreadySortedArray()
    {
        var sorter = new SelectionSortImplementation();
        int[] array = { 1, 2, 3, 4, 5 };

        SelectionSortImplementation.SelectionSort(array, (a, b) => a.CompareTo(b));

        Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, array);
    }

    [Fact]
    public void SelectionSort_HandlesReverseSortedArray()
    {
        var sorter = new SelectionSortImplementation();
        int[] array = { 5, 4, 3, 2, 1 };

        SelectionSortImplementation.SelectionSort(array, (a, b) => a.CompareTo(b));

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

        SelectionSortImplementation.SelectionSort(people, (a, b) => a.Age.CompareTo(b.Age));

        Assert.Equal("Bob", people[0].Name);
        Assert.Equal("John", people[1].Name);
        Assert.Equal("Alice", people[2].Name);
    }
    
    [Fact]
    public void HandleDatasetLijstAflopend2()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var sortedArray = SelectionSortImplementation.SelectionSort(dataset.LijstAflopend2, (a, b) => a.CompareTo(b));
        
        // Assert
        Assert.Equal(-10033224, sortedArray[0]);
    }
    
    [Fact]
    public void HandleDatasetLijstOplopend2()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var sortedArray = SelectionSortImplementation.SelectionSort(dataset.LijstOplopend2, (a, b) => a.CompareTo(b));
        
        // Assert
        Assert.Equal(-100324, sortedArray[0]);
    }

    [Fact]
    public void HandleDatasetLijstFloat8001()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var sortedArray = SelectionSortImplementation.SelectionSort(dataset.LijstFloat8001, (a, b) => a.CompareTo(b));
        
        // Assert
        Assert.Equal(-0, sortedArray[0]);
    }
    
    [Fact]
    public void HandleDatasetLijstGesorteerdAflopend3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var sortedArray = SelectionSortImplementation.SelectionSort(dataset.LijstGesorteerdAflopend3, (a, b) => a.CompareTo(b));
        
        // Assert
        Assert.Equal(1, sortedArray[0]);
    }
    
    [Fact]
    public void HandleDatasetLijstGesorteerdOplopend3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var sortedArray = SelectionSortImplementation.SelectionSort(dataset.LijstGesorteerdOplopend3, (a, b) => a.CompareTo(b));
        
        // Assert
        Assert.Equal(1, sortedArray[0]);
    }

    [Fact]
    public void HandleDatasetLijstHerhaald1000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var sortedArray = SelectionSortImplementation.SelectionSort(dataset.LijstHerhaald1000, (a, b) => a.CompareTo(b));
        
        // Assert
        Assert.Equal(-1, sortedArray[0]);
    }
    
    
    [Fact]
    public void HandleDatasetLijstLeeg0()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var sortedArray = SelectionSortImplementation.SelectionSort(dataset.LijstLeeg0, (a, b) => a.CompareTo(b));
        
        // Assert
        Assert.Equal(default, sortedArray.FirstOrDefault());
    }
    
    [Fact]
    public void HandleDatasetLijstNull1()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var sortedArray = SelectionSortImplementation.SelectionSort(dataset.LijstNull1, (a, b) =>
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
        Assert.Null(sortedArray[0]);
    }
    
    [Fact]
    public void HandleDatasetLijstNull3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var sortedArray = SelectionSortImplementation.SelectionSort(dataset.LijstNull3, (a, b) =>
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
        Assert.Null(sortedArray[0]);
    }
    
    [Fact]
    public void HandleDatasetLijstOnsorteerbaar3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var sortedArray = SelectionSortImplementation.SelectionSort(dataset.LijstOnsorteerbaar3, (_, _) => 0);
        
        // Assert
        Assert.Equal("1", sortedArray[0].ToString());
    }
    
    [Fact]
    public void HandleDatasetLijstOplopend10000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var sortedArray = SelectionSortImplementation.SelectionSort(dataset.LijstGesorteerdOplopend3, (a, b) => a.CompareTo(b));
        
        // Assert
        Assert.Equal(1, sortedArray[0]);
    }
    
    [Fact]
    public void HandleDatasetLijstWillekeurig10000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var sortedArray = SelectionSortImplementation.SelectionSort(dataset.LijstWillekeurig10000, (a, b) => a.CompareTo(b));
        
        // Assert
        Assert.Equal(1, sortedArray[0]);
    }
    
    [Fact]
    public void HandleDatasetLijstWillekeurig3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        // Act
        var sortedArray = SelectionSortImplementation.SelectionSort(dataset.LijstWillekeurig3, (_, _) => 0);
        
        // Assert
        Assert.Equal(1, sortedArray[0]);
    }

    private class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}