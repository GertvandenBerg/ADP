using adp.DataStructures;
using Tests;

namespace adp.Datastructures.Tests;

public class GraphImplementationTests
{
    [Fact]
    public void BFS_ShouldReturnShortestPath_WhenPathExists()
    {
        // Arrange
        var graph = new GraphImplementation();
        graph.AddEdge(0, 1);
        graph.AddEdge(1, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(3, 4);

        // Act
        var path = graph.FindShortestPath(0, 4);

        // Assert
        Assert.Equal([0, 1, 3, 4], path);
    }

    [Fact]
    public void BFS_ShouldReturnEmptyArray_WhenNoPathExists()
    {
        // Arrange
        var graph = new GraphImplementation();
        graph.AddEdge(0, 1);
        graph.AddEdge(1, 2);
        graph.AddEdge(3, 4);

        // Act
        var path = graph.FindShortestPath(0, 4);

        // Assert
        Assert.Empty(path);
    }

    [Fact]
    public void BFS_ShouldHandleSingleNodeGraph()
    {
        // Arrange
        var graph = new GraphImplementation();
        graph.AddVertex(0);

        // Act
        var path = graph.FindShortestPath(0, 0);

        // Assert
        Assert.Equal(new[] { 0 }, path);
    }

    [Fact]
    public void BFS_ShouldReturnDirectConnection_WhenVerticesAreAdjacent()
    {
        // Arrange
        var graph = new GraphImplementation();
        graph.AddEdge(0, 1);

        // Act
        var path = graph.FindShortestPath(0, 1);

        // Assert
        Assert.Equal(new[] { 0, 1 }, path);
    }

    [Fact]
    public void Dijkstra_ShouldReturnShortestPathInWeightedGraph()
    {
        // Arrange
        var graph = new GraphImplementation();
        graph.AddWeightedEdge(0, 1, 1);
        graph.AddWeightedEdge(1, 2, 2);
        graph.AddWeightedEdge(0, 2, 4);

        // Act
        var path = graph.FindShortestPath(0, 2);

        // Assert
        Assert.Equal(new[] { 0, 1, 2 }, path);
    }

    [Fact]
    public void FindShortestPath_ShouldHandleMixedWeightedAndUnweightedGraph()
    {
        // Arrange
        var graph = new GraphImplementation();
        graph.AddEdge(0, 1);
        graph.AddWeightedEdge(1, 2, 5);
        graph.AddEdge(2, 3);

        // Act
        var path = graph.FindShortestPath(0, 3);

        // Assert
        Assert.Equal(new[] { 0, 1, 2, 3 }, path);
    }

    [Fact]
    public void Dijkstra_ShouldReturnEmptyArray_WhenNoPathExistsInWeightedGraph()
    {
        // Arrange
        var graph = new GraphImplementation();
        graph.AddWeightedEdge(0, 1, 1);
        graph.AddWeightedEdge(2, 3, 1);

        // Act
        var path = graph.FindShortestPath(0, 3);

        // Assert
        Assert.Empty(path);
    }

    [Fact]
    public void FindShortestPath_ShouldHandleNonExistentNodesGracefully()
    {
        // Arrange
        var graph = new GraphImplementation();
        graph.AddEdge(0, 1);

        // Act
        var path = graph.FindShortestPath(0, 99);

        // Assert
        Assert.Empty(path);
    }

    [Fact]
    public void FindShortestPath_ShouldHandleGraphWithLoops()
    {
        // Arrange
        var graph = new GraphImplementation();
        graph.AddEdge(0, 1);
        graph.AddEdge(1, 1);
        graph.AddEdge(1, 2);

        // Act
        var path = graph.FindShortestPath(0, 2);

        // Assert
        Assert.Equal(new[] { 0, 1, 2 }, path);
    }
}