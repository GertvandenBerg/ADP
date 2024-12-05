using adp;
using Xunit;

namespace Tests;

public class PriorityQueueImplementationTests
{
    [Fact]
    public void AddAndPeek_ShouldReturnHighestPriorityElement()
    {
        var queue = new PriorityQueueImplementation<string>();
        queue.Add("Low Priority Task", 5);
        queue.Add("High Priority Task", 1);
        queue.Add("Medium Priority Task", 3);

        Assert.Equal("High Priority Task", queue.Peek());
    }

    [Fact]
    public void Poll_ShouldReturnAndRemoveHighestPriorityElement()
    {
        var queue = new PriorityQueueImplementation<string>();
        queue.Add("Low Priority Task", 5);
        queue.Add("High Priority Task", 1);
        queue.Add("Medium Priority Task", 3);

        Assert.Equal("High Priority Task", queue.Poll());
        Assert.Equal("Medium Priority Task", queue.Poll());
        Assert.Equal("Low Priority Task", queue.Poll());
        Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void Size_ShouldReturnCorrectNumberOfElements()
    {
        var queue = new PriorityQueueImplementation<string>();

        Assert.Equal(0, queue.Size());

        queue.Add("Task 1", 1);
        Assert.Equal(1, queue.Size());

        queue.Add("Task 2", 2);
        Assert.Equal(2, queue.Size());

        queue.Poll();
        Assert.Equal(1, queue.Size());
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrueForEmptyQueue()
    {
        var queue = new PriorityQueueImplementation<string>();

        Assert.True(queue.IsEmpty());

        queue.Add("Task", 1);
        Assert.False(queue.IsEmpty());

        queue.Poll();
        Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void Poll_OnEmptyQueue_ShouldThrowInvalidOperationException()
    {
        var queue = new PriorityQueueImplementation<string>();

        Assert.Throws<InvalidOperationException>(() => queue.Poll());
    }

    [Fact]
    public void Peek_OnEmptyQueue_ShouldThrowInvalidOperationException()
    {
        var queue = new PriorityQueueImplementation<string>();

        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    [Fact]
    public void Add_MultipleElements_ShouldMaintainCorrectOrder()
    {
        var queue = new PriorityQueueImplementation<int>();

        queue.Add(20, 2);
        queue.Add(10, 1);
        queue.Add(30, 3);
        queue.Add(15, 1);

        Assert.Equal(10, queue.Poll());
        Assert.Equal(15, queue.Poll());
        Assert.Equal(20, queue.Poll());
        Assert.Equal(30, queue.Poll());
    }
}
