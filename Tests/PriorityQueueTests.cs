using adp;

namespace Tests;

public class PriorityQueueTests
{
    [Fact]
    public void Add_ShouldInsertElementsInPriorityOrder()
    {
        // Arrange
        var pq = new PriorityQueueImplementation<int>(5);

        // Act
        pq.Add(10);
        pq.Add(5);
        pq.Add(20);
        pq.Add(1);

        // Assert
        Assert.Equal(1, pq.Peek());
    }

    [Fact]
    public void Peek_ShouldReturnHighestPriorityElementWithoutRemoving()
    {
        // Arrange
        var pq = new PriorityQueueImplementation<int>(5);
        pq.Add(15);
        pq.Add(10);
        pq.Add(5);

        // Act
        var peeked = pq.Peek();

        // Assert
        Assert.Equal(5, peeked);
        Assert.Equal(3, pq.Size()); // Ensure size remains unchanged
    }

    [Fact]
    public void Poll_ShouldReturnAndRemoveHighestPriorityElement()
    {
        // Arrange
        var pq = new PriorityQueueImplementation<int>(5);
        pq.Add(30);
        pq.Add(20);
        pq.Add(10);

        // Act
        var polled = pq.Poll();

        // Assert
        Assert.Equal(10, polled);
        Assert.Equal(20, pq.Peek()); // Ensure next highest-priority element is now at the top
        Assert.Equal(2, pq.Size()); // Ensure size is decremented
    }

    [Fact]
    public void Add_ShouldThrowException_WhenCapacityIsExceeded()
    {
        // Arrange
        var pq = new PriorityQueueImplementation<int>(2);
        pq.Add(10);
        pq.Add(20);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => pq.Add(30));
    }

    [Fact]
    public void Peek_ShouldThrowException_WhenPriorityQueueIsEmpty()
    {
        // Arrange
        var pq = new PriorityQueueImplementation<int>(5);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => pq.Peek());
    }

    [Fact]
    public void Poll_ShouldThrowException_WhenPriorityQueueIsEmpty()
    {
        // Arrange
        var pq = new PriorityQueueImplementation<int>(5);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => pq.Poll());
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrue_WhenQueueIsEmpty()
    {
        // Arrange
        var pq = new PriorityQueueImplementation<int>(5);

        // Act
        var isEmpty = pq.IsEmpty();

        // Assert
        Assert.True(isEmpty);
    }

    [Fact]
    public void IsEmpty_ShouldReturnFalse_WhenQueueIsNotEmpty()
    {
        // Arrange
        var pq = new PriorityQueueImplementation<int>(5);
        pq.Add(10);

        // Act
        var isEmpty = pq.IsEmpty();

        // Assert
        Assert.False(isEmpty);
    }

    [Fact]
    public void Size_ShouldReturnCorrectNumberOfElements()
    {
        // Arrange
        var pq = new PriorityQueueImplementation<int>(5);
        pq.Add(1);
        pq.Add(2);
        pq.Add(3);

        // Act
        var size = pq.Size();

        // Assert
        Assert.Equal(3, size);
    }

    [Fact]
    public void MixedOperations_ShouldMaintainPriorityQueueProperty()
    {
        // Arrange
        var pq = new PriorityQueueImplementation<int>(10);

        // Act
        pq.Add(15);  // [15]
        pq.Add(10);  // [10, 15]
        pq.Add(20);  // [10, 15, 20]
        pq.Add(5);   // [5, 10, 20, 15]

        // Assert
        Assert.Equal(5, pq.Poll()); // [10, 15, 20]
        Assert.Equal(10, pq.Poll()); // [15, 20]
        Assert.Equal(15, pq.Peek()); // [15, 20]
        Assert.Equal(2, pq.Size());
    }
}