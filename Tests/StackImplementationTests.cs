

using adp;
// use stack from adp

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
    public void Pop_ShouldThrowException_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new System.Collections.Generic.Stack<int>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Peek_ShouldThrowException_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new System.Collections.Generic.Stack<int>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
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
    public void Pop_ShouldResizeArrayCorrectly()
    {
        // Arrange
        var stack = new StackImplementation<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Act
        stack.Pop(); // Remove 3
        stack.Pop(); // Remove 2

        // Assert
        Assert.Equal(1, stack.Size());
        Assert.Equal(1, stack.Peek());
    }
}