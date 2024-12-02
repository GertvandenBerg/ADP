using adp;

namespace Tests;

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
}