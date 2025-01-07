using adp;

namespace Tests;

public class DequeImplementationTests
{
    [Fact]
    public void InsertLeft_AddsElementToFront()
    {
        var deque = new DequeImplementation<int>();
        deque.InsertLeft(10);

        Assert.Equal(1, deque.Size());
        Assert.Equal(10, deque.DeleteLeft());
    }

    [Fact]
    public void InsertRight_AddsElementToEnd()
    {
        var deque = new DequeImplementation<int>();
        deque.InsertRight(20);

        Assert.Equal(1, deque.Size());
        Assert.Equal(20, deque.DeleteRight());
    }

    [Fact]
    public void DeleteLeft_RemovesElementFromFront()
    {
        var deque = new DequeImplementation<int>();
        deque.InsertLeft(10);
        deque.InsertLeft(20);

        var result = deque.DeleteLeft();

        Assert.Equal(20, result);
        Assert.Equal(1, deque.Size());
    }

    [Fact]
    public void DeleteRight_RemovesElementFromEnd()
    {
        var deque = new DequeImplementation<int>();
        deque.InsertRight(10);
        deque.InsertRight(20);

        var result = deque.DeleteRight();

        Assert.Equal(20, result);
        Assert.Equal(1, deque.Size());
    }

    [Fact]
    public void Size_ReturnsCorrectCount()
    {
        var deque = new DequeImplementation<int>();
        deque.InsertLeft(10);
        deque.InsertRight(20);
        deque.InsertLeft(30);

        Assert.Equal(3, deque.Size());

        deque.DeleteLeft();
        Assert.Equal(2, deque.Size());
    }

    [Fact]
    public void DeleteLeft_ThrowsException_WhenDequeIsEmpty()
    {
        var deque = new DequeImplementation<int>();

        Assert.Throws<InvalidOperationException>(() => deque.DeleteLeft());
    }

    [Fact]
    public void DeleteRight_ThrowsException_WhenDequeIsEmpty()
    {
        var deque = new DequeImplementation<int>();

        Assert.Throws<InvalidOperationException>(() => deque.DeleteRight());
    }

    [Fact]
    public void InsertLeftAndDeleteRight_WorkTogetherCorrectly()
    {
        var deque = new DequeImplementation<int>();
        deque.InsertLeft(10);
        deque.InsertLeft(20);

        Assert.Equal(10, deque.DeleteRight());
        Assert.Equal(20, deque.DeleteRight());
    }

    [Fact]
    public void InsertRightAndDeleteLeft_WorkTogetherCorrectly()
    {
        var deque = new DequeImplementation<int>();
        deque.InsertRight(10);
        deque.InsertRight(20);

        Assert.Equal(10, deque.DeleteLeft());
        Assert.Equal(20, deque.DeleteLeft());
    }
    
    [Fact]
    public void HandleDatasetLijstAflopend2()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var deque = new DequeImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstAflopend2)
        {
            deque.InsertRight(item);
        }
        
        // Assert
        Assert.Equal(1, deque.DeleteLeft());
    }
    
    [Fact]
    public void HandleDatasetLijstOplopend2()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var deque = new DequeImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstOplopend2)
        {
            deque.InsertRight(item);
        }
        
        // Assert
        Assert.Equal(-100324, deque.DeleteLeft());
    }

    [Fact]
    public void HandleDatasetLijstFloat8001()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var deque = new DequeImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstFloat8001)
        {
            deque.InsertRight(item);
        }
        
        // Assert
        Assert.Equal(-0.0, deque.DeleteLeft());
    }
    
    [Fact]
    public void HandleDatasetLijstGesorteerdAflopend3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var deque = new DequeImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstGesorteerdAflopend3)
        {
            deque.InsertRight(item);
        }
        
        // Assert
        Assert.Equal(3, deque.DeleteLeft());
    }
    
    [Fact]
    public void HandleDatasetLijstGesorteerdOplopend3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var deque = new DequeImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstGesorteerdOplopend3)
        {
            deque.InsertRight(item);
        }
        
        // Assert
        Assert.Equal(1, deque.DeleteLeft());
    }

    [Fact]
    public void HandleDatasetLijstHerhaald1000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var deque = new DequeImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstHerhaald1000)
        {
            deque.InsertRight(item);
        }
        
        // Assert
        Assert.Equal(1, deque.DeleteLeft());
    }
    
    
    [Fact]
    public void HandleDatasetLijstLeeg0()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var deque = new DequeImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstLeeg0)
        {
            deque.InsertRight(item);
        }
        
        // Assert
        Assert.Throws<InvalidOperationException>(() => deque.DeleteLeft());
    }
    
    [Fact]
    public void HandleDatasetLijstNull1()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var deque = new DequeImplementation<int?>();
        
        // Act
        foreach (var item in dataset.LijstNull1)
        {
            deque.InsertRight(item);
        }
        
        // Assert
        Assert.Null(deque.DeleteLeft());
    }
    
    [Fact]
    public void HandleDatasetLijstNull3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var deque = new DequeImplementation<int?>();
        
        // Act
        foreach (var item in dataset.LijstNull3)
        {
            deque.InsertRight(item);
        }
        
        // Assert
        Assert.Equal(1, deque.DeleteLeft());
    }
    
    [Fact]
    public void HandleDatasetLijstOnsorteerbaar3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var deque = new DequeImplementation<object>();
        
        // Act
        foreach (var item in dataset.LijstOnsorteerbaar3)
        {
            deque.InsertRight(item);
        }
        
        // Assert
        Assert.Equal(1, int.Parse(deque.DeleteLeft().ToString()));
    }
    
    [Fact]
    public void HandleDatasetLijstOplopend10000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var deque = new DequeImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstOplopend10000)
        {
            deque.InsertRight(item);
        }
        
        // Assert
        Assert.Equal(1, deque.DeleteLeft());
    }
    
    [Fact]
    public void HandleDatasetLijstWillekeurig10000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var deque = new DequeImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstWillekeurig10000)
        {
            deque.InsertRight(item);
        }
        
        // Assert
        Assert.Equal(5824, deque.DeleteLeft());
    }
    
    [Fact]
    public void HandleDatasetLijstWillekeurig3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var deque = new DequeImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstWillekeurig3)
        {
            deque.InsertRight(item);
        }
        
        // Assert
        Assert.Equal(1, deque.DeleteLeft());
    }
}