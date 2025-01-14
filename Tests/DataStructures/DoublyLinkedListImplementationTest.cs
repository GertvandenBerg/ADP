using adp;

namespace Tests.DataStructures;

public class DoublyLinkedListImplementationTests
{
    [Fact]
    public void Add_ShouldAddElementToEndOfList()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();

        // Act
        list.Add(10);
        list.Add(20);

        // Assert
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
    }

    [Fact]
    public void Get_ShouldReturnElementAtIndex()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        // Act
        var element = list.Get(1);

        // Assert
        Assert.Equal(2, element);
    }

    [Fact]
    public void Set_ShouldUpdateElementAtIndex()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(10);
        list.Add(20);

        // Act
        list.Set(1, 30);

        // Assert
        Assert.Equal(30, list.Get(1));
    }

    [Fact]
    public void Set_ShouldThrowException_ForInvalidIndex()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => list.Set(0, 10));
        Assert.Throws<IndexOutOfRangeException>(() => list.Set(-1, 10));
    }

    [Fact]
    public void RemoveAtIndex_ShouldRemoveElementAtIndex()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Act
        var result = list.RemoveAtIndex(1);

        // Assert
        Assert.True(result);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(2));
    }

    [Fact]
    public void RemoveAtIndex_ShouldReturnFalse_ForInvalidIndex()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();

        // Act
        var result = list.RemoveAtIndex(5);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void RemoveAtIndex_ShouldUpdateHeadAndTailCorrectly()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        // Act
        list.RemoveAtIndex(0); // Remove head
        list.RemoveAtIndex(1); // Remove tail

        // Assert
        Assert.Equal(2, list.Get(0)); // Remaining element is now head and tail
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(1));
    }

    [Fact]
    public void Contains_ShouldReturnTrue_WhenElementExists()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(1);
        list.Add(2);

        // Act
        var contains = list.Contains(2);

        // Assert
        Assert.True(contains);
    }

    [Fact]
    public void Contains_ShouldReturnFalse_WhenElementDoesNotExist()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(1);

        // Act
        var contains = list.Contains(3);

        // Assert
        Assert.False(contains);
    }

    [Fact]
    public void IndexOf_ShouldReturnIndex_WhenElementExists()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        // Act
        var index = list.IndexOf(2);

        // Assert
        Assert.Equal(1, index);
    }

    [Fact]
    public void IndexOf_ShouldReturnMinusOne_WhenElementDoesNotExist()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(1);

        // Act
        var index = list.IndexOf(5);

        // Assert
        Assert.Equal(-1, index);
    }

    [Fact]
    public void Remove_ShouldRemoveElementByValue()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(10);
        list.Add(20);

        // Act
        var result = list.Remove(10);

        // Assert
        Assert.True(result);
        Assert.False(list.Contains(10));
        Assert.Equal(20, list.Get(0));
    }

    [Fact]
    public void Remove_ShouldReturnFalse_WhenElementDoesNotExist()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(10);

        // Act
        var result = list.Remove(30);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Add_Remove_MultipleOperations_ShouldMaintainCorrectState()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();

        // Act
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.RemoveAtIndex(1);
        list.Add(4);

        // Assert
        Assert.Equal(1, list.Get(0));
        Assert.Equal(3, list.Get(1));
        Assert.Equal(4, list.Get(2));
    }
    
    [Fact]
    public void HandleDatasetLijstAflopend2()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var linkedList = new DoublyLinkedListImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstAflopend2)
        {
            linkedList.Add(item);
        }
        
        // Assert
        Assert.Equal(1, linkedList.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstOplopend2()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var linkedList = new DoublyLinkedListImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstOplopend2)
        {
            linkedList.Add(item);
        }
        
        // Assert
        Assert.Equal(-100324, linkedList.Get(0));
    }

    [Fact]
    public void HandleDatasetLijstFloat8001()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var linkedList = new DoublyLinkedListImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstFloat8001)
        {
            linkedList.Add(item);
        }
        
        // Assert
        Assert.Equal(-0.0, linkedList.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstGesorteerdAflopend3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var linkedList = new DoublyLinkedListImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstGesorteerdAflopend3)
        {
            linkedList.Add(item);
        }
        
        // Assert
        Assert.Equal(3, linkedList.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstGesorteerdOplopend3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var linkedList = new DoublyLinkedListImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstGesorteerdOplopend3)
        {
            linkedList.Add(item);
        }
        
        // Assert
        Assert.Equal(1, linkedList.Get(0));
    }

    [Fact]
    public void HandleDatasetLijstHerhaald1000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var linkedList = new DoublyLinkedListImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstHerhaald1000)
        {
            linkedList.Add(item);
        }
        
        // Assert
        Assert.Equal(1, linkedList.Get(0));
    }
    
    
    [Fact]
    public void HandleDatasetLijstLeeg0()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var linkedList = new DoublyLinkedListImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstLeeg0)
        {
            linkedList.Add(item);
        }
        
        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstNull1()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var linkedList = new DoublyLinkedListImplementation<int?>();
        
        // Act
        foreach (var item in dataset.LijstNull1)
        {
            linkedList.Add(item);
        }
        
        // Assert
        Assert.Null(linkedList.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstNull3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var linkedList = new DoublyLinkedListImplementation<int?>();
        
        // Act
        foreach (var item in dataset.LijstNull3)
        {
            linkedList.Add(item);
        }
        
        // Assert
        Assert.Equal(1, linkedList.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstOnsorteerbaar3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var linkedList = new DoublyLinkedListImplementation<object>();
        
        // Act
        foreach (var item in dataset.LijstOnsorteerbaar3)
        {
            linkedList.Add(item);
        }
        
        // Assert
        Assert.Equal(1, int.Parse(linkedList.Get(0).ToString()));
    }
    
    [Fact]
    public void HandleDatasetLijstOplopend10000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var linkedList = new DoublyLinkedListImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstOplopend10000)
        {
            linkedList.Add(item);
        }
        
        // Assert
        Assert.Equal(1, linkedList.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstWillekeurig10000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var linkedList = new DoublyLinkedListImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstWillekeurig10000)
        {
            linkedList.Add(item);
        }
        
        // Assert
        Assert.Equal(5824, linkedList.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstWillekeurig3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var linkedList = new DoublyLinkedListImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstWillekeurig3)
        {
            linkedList.Add(item);
        }
        
        // Assert
        Assert.Equal(1, linkedList.Get(0));
    }
}
