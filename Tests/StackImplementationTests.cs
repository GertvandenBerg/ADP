using adp;

namespace Tests;

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

    // Example custom class for object tests
    public class Pizza
    {
        public string pizzaName { get; set; }
        public int numberOfSlices { get; set; }
    }
}