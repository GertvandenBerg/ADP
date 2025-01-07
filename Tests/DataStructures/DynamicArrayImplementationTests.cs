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

    [Fact]
    public void Contains_ShouldWorkForComplexObjects()
    {
        // Arrange
        var dynamicArray = new DynamicArrayImplementation<Pizza>();
        dynamicArray.Add(new Pizza { pizzaName = "Margherita", numberOfSlices = 8, Nogiets = new Nogiets()
        {
            Age = 10,
            Name = "Nogiets"
        }});
        dynamicArray.Add(new Pizza { pizzaName = "Pepperoni", numberOfSlices = 10, Nogiets = new Nogiets()
        {
            Age = 20,
            Name = "Nogiets"
        }});

        var pizzaToFind = new Pizza { pizzaName = "Margherita", numberOfSlices = 8, Nogiets = new Nogiets()
        {
            Age = 10,
            Name = "Nogiets"
        }};

        // Act
        var contains = dynamicArray.Contains(pizzaToFind);

        // Assert
        Assert.True(contains);
    }

    [Fact]
    public void IndexOf_ShouldWorkForComplexObjects()
    {
        // Arrange
        var dynamicArray = new DynamicArrayImplementation<Pizza>();
        dynamicArray.Add(new Pizza { pizzaName = "Margherita", numberOfSlices = 8 });
        dynamicArray.Add(new Pizza { pizzaName = "Pepperoni", numberOfSlices = 10 });

        var pizzaToFind = new Pizza { pizzaName = "Pepperoni", numberOfSlices = 10 };

        // Act
        var index = dynamicArray.IndexOf(pizzaToFind);

        // Assert
        Assert.Equal(1, index);
    }

    [Fact]
    public void HandleDatasetLijstAflopend2()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var dynamicArray = new DynamicArrayImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstAflopend2)
        {
            dynamicArray.Add(item);
        }
        
        // Assert
        Assert.Equal(1, dynamicArray.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstOplopend2()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var dynamicArray = new DynamicArrayImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstOplopend2)
        {
            dynamicArray.Add(item);
        }
        
        // Assert
        Assert.Equal(-100324, dynamicArray.Get(0));
    }

    [Fact]
    public void HandleDatasetLijstFloat8001()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var dynamicArray = new DynamicArrayImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstFloat8001)
        {
            dynamicArray.Add(item);
        }
        
        // Assert
        Assert.Equal(-0.0, dynamicArray.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstGesorteerdAflopend3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var dynamicArray = new DynamicArrayImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstGesorteerdAflopend3)
        {
            dynamicArray.Add(item);
        }
        
        // Assert
        Assert.Equal(3, dynamicArray.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstGesorteerdOplopend3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var dynamicArray = new DynamicArrayImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstGesorteerdOplopend3)
        {
            dynamicArray.Add(item);
        }
        
        // Assert
        Assert.Equal(1, dynamicArray.Get(0));
    }

    [Fact]
    public void HandleDatasetLijstHerhaald1000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var dynamicArray = new DynamicArrayImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstHerhaald1000)
        {
            dynamicArray.Add(item);
        }
        
        // Assert
        Assert.Equal(1, dynamicArray.Get(0));
    }
    
    
    [Fact]
    public void HandleDatasetLijstLeeg0()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var dynamicArray = new DynamicArrayImplementation<float>();
        
        // Act
        foreach (var item in dataset.LijstLeeg0)
        {
            dynamicArray.Add(item);
        }
        
        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => dynamicArray.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstNull1()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var dynamicArray = new DynamicArrayImplementation<int?>();
        
        // Act
        foreach (var item in dataset.LijstNull1)
        {
            dynamicArray.Add(item);
        }
        
        // Assert
        Assert.Null(dynamicArray.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstNull3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var dynamicArray = new DynamicArrayImplementation<int?>();
        
        // Act
        foreach (var item in dataset.LijstNull3)
        {
            dynamicArray.Add(item);
        }
        
        // Assert
        Assert.Equal(1, dynamicArray.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstOnsorteerbaar3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var dynamicArray = new DynamicArrayImplementation<object>();
        
        // Act
        foreach (var item in dataset.LijstOnsorteerbaar3)
        {
            dynamicArray.Add(item);
        }
        
        // Assert
        Assert.Equal(1, int.Parse(dynamicArray.Get(0).ToString()));
    }
    
    [Fact]
    public void HandleDatasetLijstOplopend10000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var dynamicArray = new DynamicArrayImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstOplopend10000)
        {
            dynamicArray.Add(item);
        }
        
        // Assert
        Assert.Equal(1, dynamicArray.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstWillekeurig10000()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var dynamicArray = new DynamicArrayImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstWillekeurig10000)
        {
            dynamicArray.Add(item);
        }
        
        // Assert
        Assert.Equal(5824, dynamicArray.Get(0));
    }
    
    [Fact]
    public void HandleDatasetLijstWillekeurig3()
    {
        // Arrange
        var dataset = JsonProvider.LoadSortData();
        
        var dynamicArray = new DynamicArrayImplementation<int>();
        
        // Act
        foreach (var item in dataset.LijstWillekeurig3)
        {
            dynamicArray.Add(item);
        }
        
        // Assert
        Assert.Equal(1, dynamicArray.Get(0));
    }
}

// Updated Pizza Class for Tests
public class Pizza
{
    public string pizzaName { get; set; }
    public int numberOfSlices { get; set; }
    public Nogiets? Nogiets { get; set; }
}

public class Nogiets
{
    public string Name { get; set; }
    public int Age { get; set; }
}
