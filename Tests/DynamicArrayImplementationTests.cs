using adp;

namespace Tests;

public class DynamicArrayImplementationTests
{
    [Fact]
    public void Add_ShouldAddElementToArray()
    {
        // Arrange
        var dynamicArray = new DynamicArrayImplementation<int>();

        // Act
        dynamicArray.Add(10);
        dynamicArray.Add(20);

        // Assert
        Assert.Equal(10, dynamicArray.Get(0));
        Assert.Equal(20, dynamicArray.Get(1));
    }

    [Fact]
    public void Get_ShouldReturnElementAtIndex()
    {
        // Arrange
        var dynamicArray = new DynamicArrayImplementation<int>();
        dynamicArray.Add(5);
        dynamicArray.Add(15);
        dynamicArray.Add(25);

        // Act
        var element = dynamicArray.Get(1);

        // Assert
        Assert.Equal(15, element);
    }

    [Fact]
    public void Set_ShouldUpdateElementAtIndex()
    {
        // Arrange
        var dynamicArray = new DynamicArrayImplementation<int>();
        dynamicArray.Add(1);
        dynamicArray.Add(2);

        // Act
        dynamicArray.Set(1, 42);

        // Assert
        Assert.Equal(42, dynamicArray.Get(1));
    }

    [Fact]
    public void Remove_ShouldRemoveElementAtIndexAndShiftElements()
    {
        // Arrange
        var dynamicArray = new DynamicArrayImplementation<int>();
        dynamicArray.Add(10);
        dynamicArray.Add(20);
        dynamicArray.Add(30);

        // Act
        dynamicArray.Remove(1);

        // Assert
        Assert.Equal(10, dynamicArray.Get(0));
        Assert.Equal(30, dynamicArray.Get(1));
        Assert.Throws<IndexOutOfRangeException>(() => dynamicArray.Get(2));
    }

    [Fact]
    public void Contains_ShouldReturnTrue_WhenElementExists()
    {
        // Arrange
        var dynamicArray = new DynamicArrayImplementation<int>();
        dynamicArray.Add(10);
        dynamicArray.Add(20);

        // Act
        var contains = dynamicArray.Contains(20);

        // Assert
        Assert.True(contains);
    }

    [Fact]
    public void Contains_ShouldReturnFalse_WhenElementDoesNotExist()
    {
        // Arrange
        var dynamicArray = new DynamicArrayImplementation<int>();
        dynamicArray.Add(10);

        // Act
        var contains = dynamicArray.Contains(99);

        // Assert
        Assert.False(contains);
    }

    [Fact]
    public void IndexOf_ShouldReturnIndex_WhenElementExists()
    {
        // Arrange
        var dynamicArray = new DynamicArrayImplementation<int>();
        dynamicArray.Add(5);
        dynamicArray.Add(15);
        dynamicArray.Add(25);

        // Act
        var index = dynamicArray.IndexOf(15);

        // Assert
        Assert.Equal(1, index);
    }

    [Fact]
    public void IndexOf_ShouldReturnMinusOne_WhenElementDoesNotExist()
    {
        // Arrange
        var dynamicArray = new DynamicArrayImplementation<int>();
        dynamicArray.Add(5);

        // Act
        var index = dynamicArray.IndexOf(100);

        // Assert
        Assert.Equal(-1, index);
    }

    [Fact]
    public void Remove_ShouldHandleRemovingLastElement()
    {
        // Arrange
        var dynamicArray = new DynamicArrayImplementation<int>();
        dynamicArray.Add(10);
        dynamicArray.Add(20);

        // Act
        dynamicArray.Remove(1);

        // Assert
        Assert.Equal(10, dynamicArray.Get(0));
        Assert.Throws<IndexOutOfRangeException>(() => dynamicArray.Get(1));
    }

    [Fact]
    public void Add_ShouldHandleDynamicResizing()
    {
        // Arrange
        var dynamicArray = new DynamicArrayImplementation<int>();

        // Act
        for (int i = 0; i < 100; i++)
        {
            dynamicArray.Add(i);
        }

        // Assert
        Assert.Equal(99, dynamicArray.Get(99)); // Last element added
        Assert.Equal(50, dynamicArray.Get(50)); // Check middle element
    }
}