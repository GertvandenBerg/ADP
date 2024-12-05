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
}