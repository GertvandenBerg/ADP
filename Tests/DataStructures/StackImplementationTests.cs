using adp;

namespace Tests.DataStructures;

public class StackImplementationTests
{   
    [Fact]
    public void Push_ShouldAddElementToStack()
    {
        // Arrange
        var stack = new StackImplementation<int>();

        // Act
        stack.Push(42);

        // Assert
        Assert.False(stack.IsEmpty());
        Assert.Equal(1, stack.Size());
        Assert.Equal(42, stack.Peek());
    }

    [Fact]
    public void Push_ShouldAddMultipleElementsToStack()
    {
        // Arrange
        var stack = new StackImplementation<int>();

        // Act
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        // Assert
        Assert.Equal(3, stack.Size());
        Assert.Equal(30, stack.Peek());
    }

    [Fact]
    public void Pop_ShouldRemoveAndReturnLastElement()
    {
        // Arrange
        var stack = new StackImplementation<int>();
        stack.Push(10);
        stack.Push(20);

        // Act
        var poppedElement = stack.Pop();

        // Assert
        Assert.Equal(20, poppedElement);
        Assert.False(stack.IsEmpty());
        Assert.Equal(1, stack.Size());
        Assert.Equal(10, stack.Peek());
    }

    [Fact]
    public void Pop_ShouldThrowException_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new StackImplementation<int>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Peek_ShouldReturnLastElementWithoutRemovingIt()
    {
        // Arrange
        var stack = new StackImplementation<int>();
        stack.Push(100);
        stack.Push(200);

        // Act
        var topElement = stack.Peek();

        // Assert
        Assert.Equal(200, topElement);
        Assert.Equal(2, stack.Size());
    }

    [Fact]
    public void Peek_ShouldThrowException_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new StackImplementation<int>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrueForNewStack()
    {
        // Arrange
        var stack = new StackImplementation<int>();

        // Act
        var isEmpty = stack.IsEmpty();

        // Assert
        Assert.True(isEmpty);
    }

    [Fact]
    public void IsEmpty_ShouldReturnFalseAfterPush()
    {
        // Arrange
        var stack = new StackImplementation<int>();
        stack.Push(5);

        // Act
        var isEmpty = stack.IsEmpty();

        // Assert
        Assert.False(isEmpty);
    }

    [Fact]
    public void Size_ShouldReturnCorrectNumberOfElements()
    {
        // Arrange
        var stack = new StackImplementation<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Act
        var size = stack.Size();

        // Assert
        Assert.Equal(3, size);
    }

    [Fact]
    public void Push_ShouldHandleResizingCorrectly()
    {
        // Arrange
        var stack = new StackImplementation<int>();

        // Act
        for (int i = 0; i < 100; i++)
        {
            stack.Push(i);
        }

        // Assert
        Assert.Equal(100, stack.Size());
        Assert.Equal(99, stack.Peek());
    }

    [Fact]
    public void Pop_ShouldResizeArrayCorrectly_WhenShrinking()
    {
        // Arrange
        var stack = new StackImplementation<int>();
        for (int i = 1; i <= 16; i++)
        {
            stack.Push(i); // Ensure array grows
        }

        // Act
        for (int i = 16; i > 4; i--)
        {
            stack.Pop(); // Remove elements to trigger shrinking
        }

        // Assert
        Assert.Equal(4, stack.Size());
        Assert.Equal(4, stack.Peek());
    }

    [Fact]
    public void Push_And_Pop_ShouldMaintainCorrectOrder()
    {
        // Arrange
        var stack = new StackImplementation<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Act & Assert
        Assert.Equal(3, stack.Pop());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void Push_ShouldWorkWithCustomObjects()
    {
        // Arrange
        var stack = new StackImplementation<Pizza>();
        var pizza1 = new Pizza { pizzaName = "Margherita", numberOfSlices = 8 };
        var pizza2 = new Pizza { pizzaName = "Pepperoni", numberOfSlices = 6 };

        // Act
        stack.Push(pizza1);
        stack.Push(pizza2);

        // Assert
        Assert.Equal(2, stack.Size());
        Assert.Equal(pizza2, stack.Peek());
    }

    [Fact]
    public void Pop_ShouldWorkWithCustomObjects()
    {
        // Arrange
        var stack = new StackImplementation<Pizza>();
        var pizza1 = new Pizza { pizzaName = "Margherita", numberOfSlices = 8 };
        var pizza2 = new Pizza { pizzaName = "Pepperoni", numberOfSlices = 6 };

        stack.Push(pizza1);
        stack.Push(pizza2);

        // Act
        var poppedPizza = stack.Pop();

        // Assert
        Assert.Equal(pizza2, poppedPizza);
        Assert.Equal(1, stack.Size());
        Assert.Equal(pizza1, stack.Peek());
    }
   
[Fact]
    public void HandleDatasetLijstAflopend2()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var dynamicArray = new StackImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstAflopend2)
        {
            dynamicArray.Push(item);
        }
        
        // Assert
        Assert.Equal(-10033224, dynamicArray.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstOplopend2()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var stack = new StackImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstOplopend2)
        {
            stack.Push(item);
        }
        
        // Assert
        Assert.Equal(1023, stack.Peek());
    }

    [Fact]
    public void HandleDatasetLijstFloat8001()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var stack = new StackImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstFloat8001)
        {
            stack.Push(item);
        }
        
        // Assert
        Assert.Equal(-0.0, stack.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstGesorteerdAflopend3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var stack = new StackImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstGesorteerdAflopend3)
        {
            stack.Push(item);
        }
        
        // Assert
        Assert.Equal(1, stack.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstGesorteerdOplopend3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var stack = new StackImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstGesorteerdOplopend3)
        {
            stack.Push(item);
        }
        
        // Assert
        Assert.Equal(3, stack.Peek());
    }

    [Fact]
    public void HandleDatasetLijstHerhaald1000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var stack = new StackImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstHerhaald1000)
        {
            stack.Push(item);
        }
        
        // Assert
        Assert.Equal(1, stack.Peek());
    }
    
    
    [Fact]
    public void HandleDatasetLijstLeeg0()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var stack = new StackImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstLeeg0)
        {
            stack.Push(item);
        }
        
        // Assert
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstNull1()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var stack = new StackImplementation<int?>();
        
        // Act
        foreach (var item in dataset.LijstNull1)
        {
            stack.Push(item);
        }
        
        // Assert
        Assert.Null(stack.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstNull3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var stack = new StackImplementation<int?>();
        
        // Act
        foreach (var item in dataset.LijstNull3)
        {
            stack.Push(item);
        }
        
        // Assert
        Assert.Equal(3, stack.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstOnsorteerbaar3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var stack = new StackImplementation<object>();
        
        // Act
        foreach (var item in dataset.LijstOnsorteerbaar3)
        {
            stack.Push(item);
        }
        
        // Assert
        Assert.Equal("string", stack.Peek().ToString());
    }
    
    [Fact]
    public void HandleDatasetLijstOplopend10000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var stack = new StackImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstOplopend10000)
        {
            stack.Push(item);
        }
        
        // Assert
        Assert.Equal(9999, stack.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstWillekeurig10000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var stack = new StackImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstWillekeurig10000)
        {
            stack.Push(item);
        }
        
        // Assert
        Assert.Equal(8009, stack.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstWillekeurig3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var stack = new StackImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstWillekeurig3)
        {
            stack.Push(item);
        }
        
        // Assert
        Assert.Equal(2, stack.Peek());
    }
    
    // Example custom class for object tests
    public class Pizza
    {
        public string pizzaName { get; set; }
        public int numberOfSlices { get; set; }
    }
}