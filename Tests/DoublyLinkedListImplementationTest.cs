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
    public void Get_ShouldThrowException_ForInvalidIndex()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(1);

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(5));
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
    }

    [Fact]
    public void Remove_ByIndex_ShouldRemoveElementAtIndex()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Act
        list.Remove(1);

        // Assert
        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(2));
    }

    [Fact]
    public void Remove_ByIndex_ShouldThrowException_ForInvalidIndex()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        
        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => list.Remove(0));
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
    public void Remove_ByValue_ShouldReturnTrue_WhenElementExistsAndIsRemoved()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(10);
        list.Add(20);

        // Act & Assert
        Assert.True(list.Contains(10));
        Assert.Equal(20, list.Get(1));
        Assert.Throws<IndexOutOfRangeException>(() => list.Remove(10));
    }

    [Fact]
    public void Remove_ByValue_ShouldReturnFalse_WhenElementDoesNotExist()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(10);

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => list.Remove(30));
    }

    [Fact]
    public void Add_ShouldHandleEmptyListCorrectly()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();

        // Act
        list.Add(100);

        // Assert
        Assert.Equal(100, list.Get(0));
    }

    [Fact]
    public void Remove_ByIndex_ShouldUpdateHeadAndTailCorrectly()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        // Act
        list.Remove(0); // Remove head
        list.Remove(1); // Remove tail

        // Assert
        Assert.Equal(2, list.Get(0)); // Remaining element is now head and tail
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(1));
    }

    [Fact]
    public void Remove_ByValue_ShouldUpdateHeadAndTailCorrectly()
    {
        // Arrange
        var list = new DoublyLinkedListImplementation<string>();
        list.Add("1");
        list.Add("2");
        list.Add("3");

        // Act
        list.Remove("1"); // Remove head
        list.Remove("3"); // Remove tail

        // Assert
        Assert.True(list.Contains("2"));
        Assert.False(list.Contains("1"));
        Assert.False(list.Contains("3"));
    }
}