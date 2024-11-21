using adp;

namespace Tests;

public class DequeImplementationTests
{
    [Fact]
    public void InsertLeft_ShouldAddElementToFront()
    {
        // Arrange
        var deque = new DequeImplementation<int>();

        // Act
        deque.InsertLeft(10);
        deque.InsertLeft(20);

        // Assert
        Assert.Equal(20, deque.DeleteLeft());
        Assert.Equal(10, deque.DeleteLeft());
    }

    [Fact]
    public void InsertRight_ShouldAddElementToBack()
    {
        // Arrange
        var deque = new DequeImplementation<int>();

        // Act
        deque.InsertRight(10);
        deque.InsertRight(20);

        // Assert
        Assert.Equal(10, deque.DeleteLeft());
        Assert.Equal(20, deque.DeleteLeft());
    }

    [Fact]
    public void DeleteLeft_ShouldRemoveAndReturnFrontElement()
    {
        // Arrange
        var deque = new DequeImplementation<int>();
        deque.InsertRight(10);
        deque.InsertRight(20);

        // Act
        var front = deque.DeleteLeft();

        // Assert
        Assert.Equal(10, front);
        Assert.Equal(1, deque.Size());
    }

    [Fact]
    public void DeleteRight_ShouldRemoveAndReturnBackElement()
    {
        // Arrange
        var deque = new DequeImplementation<int>();
        deque.InsertRight(10);
        deque.InsertRight(20);

        // Act
        var back = deque.DeleteRight();

        // Assert
        Assert.Equal(20, back);
        Assert.Equal(1, deque.Size());
    }

    [Fact]
    public void DeleteLeft_ShouldThrowException_WhenDequeIsEmpty()
    {
        // Arrange
        var deque = new DequeImplementation<int>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => deque.DeleteLeft());
    }

    [Fact]
    public void DeleteRight_ShouldThrowException_WhenDequeIsEmpty()
    {
        // Arrange
        var deque = new DequeImplementation<int>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => deque.DeleteRight());
    }

    [Fact]
    public void Size_ShouldReturnNumberOfElements()
    {
        // Arrange
        var deque = new DequeImplementation<int>();
        deque.InsertLeft(10);
        deque.InsertRight(20);

        // Act
        var size = deque.Size();

        // Assert
        Assert.Equal(2, size);
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrue_WhenDequeIsEmpty()
    {
        // Arrange
        var deque = new DequeImplementation<int>();

        // Act
        var isEmpty = deque.Size() == 0;

        // Assert
        Assert.True(isEmpty);
    }

    [Fact]
    public void IsEmpty_ShouldReturnFalse_WhenDequeIsNotEmpty()
    {
        // Arrange
        var deque = new DequeImplementation<int>();
        deque.InsertLeft(10);

        // Act
        var isEmpty = deque.Size() == 0;

        // Assert
        Assert.False(isEmpty);
    }

    [Fact]
    public void InsertAndDeleteOperations_ShouldMaintainDequeState()
    {
        // Arrange
        var deque = new DequeImplementation<int>();

        // Act
        deque.InsertLeft(10);
        deque.InsertRight(20);
        deque.InsertLeft(5);
        deque.InsertRight(25);

        // Assert
        Assert.Equal(5, deque.DeleteLeft());
        Assert.Equal(10, deque.DeleteLeft());
        Assert.Equal(20, deque.DeleteLeft());
        Assert.Equal(25, deque.DeleteLeft());
        Assert.True(deque.Size() == 0);
    }

    [Fact]
    public void MixedOperations_ShouldWorkCorrectly()
    {
        // Arrange
        var deque = new DequeImplementation<int>();

        // Act
        deque.InsertRight(10);  // [10]
        deque.InsertLeft(5);    // [5, 10]
        deque.InsertRight(15);  // [5, 10, 15]

        // Assert
        Assert.Equal(5, deque.DeleteLeft()); // [10, 15]
        Assert.Equal(15, deque.DeleteRight()); // [10]
        Assert.Equal(10, deque.DeleteLeft()); // []
        Assert.True(deque.Size() == 0);
    }
}