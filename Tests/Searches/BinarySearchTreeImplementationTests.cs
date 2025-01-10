using Xunit;
using adp.Searches;

namespace Tests.Searches;

public class BinarySearchTreeImplementationTests
{
    private static int IntComparer(int x, int y) => x.CompareTo(y);

    // Updated method signature: returns int (not int?)
    private static int NullableIntCompare(int? a, int? b)
    {
        if (a == null && b == null) return 0;
        if (a == null) return -1;
        if (b == null) return 1;
        return a.Value.CompareTo(b.Value);
    }

    [Fact]
    public void Insert_And_Find_ShouldWork()
    {
        var bst = new BinarySearchTreeImplementation<int>(IntComparer);
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);

        Assert.NotNull(bst.Find(10));
        Assert.NotNull(bst.Find(5));
        Assert.NotNull(bst.Find(15));
        Assert.Null(bst.Find(999));
    }

    [Fact]
    public void FindMin_FindMax_ShouldReturnCorrectNodes()
    {
        var bst = new BinarySearchTreeImplementation<int>(IntComparer);
        bst.Insert(50);
        bst.Insert(30);
        bst.Insert(70);
        bst.Insert(10);
        bst.Insert(90);

        Assert.Equal(10, bst.FindMin()?.Value);
        Assert.Equal(90, bst.FindMax()?.Value);
    }

    [Fact]
    public void Remove_ShouldHandleLeafAndInternalNodes()
    {
        var bst = new BinarySearchTreeImplementation<int>(IntComparer);
        bst.Insert(20);
        bst.Insert(10);
        bst.Insert(30);
        bst.Insert(25);
        bst.Insert(35);

        bst.Remove(35);
        Assert.Null(bst.Find(35));

        bst.Remove(30);
        Assert.Null(bst.Find(30));

        bst.Insert(30);
        bst.Insert(40);
        bst.Remove(20);
        Assert.Null(bst.Find(20));
    }

    [Fact]
    public void HandleDatasetLijstAflopend2()
    {
        var dataset = JsonProvider.LoadSortData();
        var bst = new BinarySearchTreeImplementation<int>(IntComparer);

        foreach (var item in dataset.LijstAflopend2)
            bst.Insert(item);

        var foundNode = bst.Find(1);
        Assert.NotNull(foundNode);
        Assert.Equal(1, foundNode.Value);
    }

    [Fact]
    public void HandleDatasetLijstOplopend2()
    {
        var dataset = JsonProvider.LoadSortData();
        var bst = new BinarySearchTreeImplementation<int>(IntComparer);

        foreach (var item in dataset.LijstOplopend2)
            bst.Insert(item);

        var foundNode = bst.Find(1);
        Assert.Null(foundNode);
    }

    [Fact]
    public void HandleDatasetLijstFloat8001()
    {
        var dataset = JsonProvider.LoadSortData();
        var bst = new BinarySearchTreeImplementation<float>((x, y) => x.CompareTo(y));

        foreach (var item in dataset.LijstFloat8001)
            bst.Insert(item);

        var foundNode = bst.Find(1f);
        Assert.NotNull(foundNode);
        Assert.Equal(1f, foundNode.Value);
    }

    [Fact]
    public void HandleDatasetLijstGesorteerdAflopend3()
    {
        var dataset = JsonProvider.LoadSortData();
        var bst = new BinarySearchTreeImplementation<int>(IntComparer);

        foreach (var item in dataset.LijstGesorteerdAflopend3)
            bst.Insert(item);

        var foundNode = bst.Find(1);
        Assert.Equal(1, foundNode.Value);
    }

    [Fact]
    public void HandleDatasetLijstGesorteerdOplopend3()
    {
        var dataset = JsonProvider.LoadSortData();
        var bst = new BinarySearchTreeImplementation<int>(IntComparer);

        foreach (var item in dataset.LijstGesorteerdOplopend3)
            bst.Insert(item);

        var foundNode = bst.Find(1);
        Assert.NotNull(foundNode);
        Assert.Equal(1, foundNode.Value);
    }

    [Fact]
    public void HandleDatasetLijstHerhaald1000()
    {
        var dataset = JsonProvider.LoadSortData();
        var bst = new BinarySearchTreeImplementation<int>(IntComparer);

        foreach (var item in dataset.LijstHerhaald1000)
            bst.Insert(item);

        var foundNode = bst.Find(1);
        Assert.NotNull(foundNode);
        Assert.Equal(1, foundNode.Value);
    }

    [Fact]
    public void HandleDatasetLijstLeeg0()
    {
        var dataset = JsonProvider.LoadSortData();
        var bst = new BinarySearchTreeImplementation<int>(IntComparer);

        foreach (var item in dataset.LijstLeeg0)
            bst.Insert(item);

        var foundNode = bst.Find(1);
        Assert.Null(foundNode);
    }

    [Fact]
    public void HandleDatasetLijstNull1()
    {
        var dataset = JsonProvider.LoadSortData();
        var bst = new BinarySearchTreeImplementation<int?>(NullableIntCompare);

        foreach (var item in dataset.LijstNull1)
            bst.Insert(item);

        var foundNode = bst.Find(1);
        Assert.Null(foundNode);
    }

    [Fact]
    public void HandleDatasetLijstNull3()
    {
        var dataset = JsonProvider.LoadSortData();
        var bst = new BinarySearchTreeImplementation<int?>(NullableIntCompare);

        foreach (var item in dataset.LijstNull3)
            bst.Insert(item);

        var foundNode = bst.Find(1);
        Assert.Equal(1, foundNode.Value);
    }

    [Fact]
    public void HandleDatasetLijstOnsorteerbaar3()
    {
        var dataset = JsonProvider.LoadSortData();
        var bst = new BinarySearchTreeImplementation<object>((_, _) => 0);

        foreach (var item in dataset.LijstOnsorteerbaar3)
            bst.Insert(item);

        var foundNode = bst.Find(1);
        Assert.NotNull(foundNode);
    }

    [Fact]
    public void HandleDatasetLijstOplopend10000()
    {
        var dataset = JsonProvider.LoadSortData();
        var bst = new BinarySearchTreeImplementation<int>(IntComparer);

        foreach (var item in dataset.LijstOplopend10000)
            bst.Insert(item);

        var foundNode = bst.Find(1);
        Assert.NotNull(foundNode);
        Assert.Equal(1, foundNode.Value);
    }

    [Fact]
    public void HandleDatasetLijstWillekeurig10000()
    {
        var dataset = JsonProvider.LoadSortData();
        var bst = new BinarySearchTreeImplementation<int>(IntComparer);

        foreach (var item in dataset.LijstWillekeurig10000)
            bst.Insert(item);

        var foundNode = bst.Find(1);
        Assert.Equal(1, foundNode.Value);
    }

    [Fact]
    public void HandleDatasetLijstWillekeurig3()
    {
        var dataset = JsonProvider.LoadSortData();
        var bst = new BinarySearchTreeImplementation<int>((_, _) => 0);

        foreach (var item in dataset.LijstWillekeurig3)
            bst.Insert(item);

        var foundNode = bst.Find(1);
        Assert.NotNull(foundNode);
    }
}