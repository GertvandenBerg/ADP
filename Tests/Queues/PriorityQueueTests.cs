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
    
    [Fact]
    public void HandleDatasetLijstAflopend2()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        int current = 0;
        var random = new Random();
        
        var priorityQueue = new PriorityQueueImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstAflopend2)
        {
            priorityQueue.Add(item, current++);
        }
        
        // Assert
        Assert.Equal(1, priorityQueue.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstOplopend2()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        int current = 0;
        var priorityQueue = new PriorityQueueImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstOplopend2)
        {
            priorityQueue.Add(item, current++);
        }
        
        // Assert
        Assert.Equal(-100324, priorityQueue.Peek());
    }

    [Fact]
    public void HandleDatasetLijstFloat8001()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        int current = 0;
        var priorityQueue = new PriorityQueueImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstFloat8001)
        {
            priorityQueue.Add(item, current++);
        }
        
        // Assert
        Assert.Equal(-0.0, priorityQueue.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstGesorteerdAflopend3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        int current = 0;
        
        var priorityQueue = new PriorityQueueImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstGesorteerdAflopend3)
        {
            priorityQueue.Add(item, current++);
        }
        
        // Assert
        Assert.Equal(3, priorityQueue.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstGesorteerdOplopend3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        int current = 0;
        
        var priorityQueue = new PriorityQueueImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstGesorteerdOplopend3)
        {
            priorityQueue.Add(item, current++);
        }
        
        // Assert
        Assert.Equal(1, priorityQueue.Peek());
    }

    [Fact]
    public void HandleDatasetLijstHerhaald1000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        int current = 0;
        
        var priorityQueue = new PriorityQueueImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstHerhaald1000)
        {
            priorityQueue.Add(item, current++);
        }
        
        // Assert
        Assert.Equal(1, priorityQueue.Peek());
    }
    
    
    [Fact]
    public void HandleDatasetLijstLeeg0()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        int current = 0;
        
        var priorityQueue = new PriorityQueueImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstLeeg0)
        {
            priorityQueue.Add(item, current++);
        }
        
        // Assert
        Assert.Throws<InvalidOperationException>(() => priorityQueue.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstNull1()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        int current = 0;
        
        var priorityQueue = new PriorityQueueImplementation<int?>();
        
        // Act
        foreach (var item in dataset.LijstNull1)
        {
            priorityQueue.Add(item, current++);
        }
        
        // Assert
        Assert.Null(priorityQueue.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstNull3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        int current = 0;
        
        var priorityQueue = new PriorityQueueImplementation<int?>();
        
        // Act
        foreach (var item in dataset.LijstNull3)
        {
            priorityQueue.Add(item, current++);
        }
        
        // Assert
        Assert.Equal(1, priorityQueue.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstOnsorteerbaar3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        int current = 0;
        
        var priorityQueue = new PriorityQueueImplementation<object>();
        
        // Act
        foreach (var item in dataset.LijstOnsorteerbaar3)
        {
            priorityQueue.Add(item, current++);
        }
        
        // Assert
        Assert.Equal(1, int.Parse(priorityQueue.Peek().ToString()));
    }
    
    [Fact]
    public void HandleDatasetLijstOplopend10000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        int current = 0;
        
        var priorityQueue = new PriorityQueueImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstOplopend10000)
        {
            priorityQueue.Add(item, current++);
        }
        
        // Assert
        Assert.Equal(1, priorityQueue.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstWillekeurig10000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        int current = 0;
        
        var priorityQueue = new PriorityQueueImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstWillekeurig10000)
        {
            priorityQueue.Add(item, current++);
        }
        
        // Assert
        Assert.Equal(5824, priorityQueue.Peek());
    }
    
    [Fact]
    public void HandleDatasetLijstWillekeurig3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        int current = 0;
        
        var priorityQueue = new PriorityQueueImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstWillekeurig3)
        {
            priorityQueue.Add(item, current++);
        }
        
        // Assert
        Assert.Equal(1, priorityQueue.Peek());
    }
}
