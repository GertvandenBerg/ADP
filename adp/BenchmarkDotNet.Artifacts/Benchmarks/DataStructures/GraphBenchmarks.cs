using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using adp.DataStructures;

namespace adp.Benchmarks;

[MemoryDiagnoser]
public class GraphBenchmarks
{
    private GraphImplementation _graph;
    private int _startNode;
    private int _endNode;

    [Params(100, 1_000)] // Number of nodes in the graph
    public int NodeCount;

    [Params(1, 2, 5)] // Average degree (edges per node)
    public int AvgDegree;

    [GlobalSetup]
    public void Setup()
    {
        _graph = new GraphImplementation();

        var random = new Random();

        // Add nodes and edges
        for (int i = 0; i < NodeCount; i++)
        {
            for (int j = 0; j < AvgDegree; j++)
            {
                int target = random.Next(NodeCount);
                if (i != target)
                {
                    _graph.AddEdge(i, target);
                }
            }
        }

        // Set start and end nodes for shortest path
        _startNode = 0;
        _endNode = NodeCount - 1;
    }

    [Benchmark]
    public void AddEdge()
    {
        _graph.AddEdge(0, NodeCount - 1);
    }

    [Benchmark]
    public void BFS_FindShortestPath()
    {
        _graph.FindShortestPath(_startNode, _endNode);
    }

    [Benchmark]
    public void Dijkstra_FindShortestPath()
    {
        _graph.FindShortestPath(_startNode, _endNode); // Assuming Dijkstra is implemented
    }

    [Benchmark]
    public void SearchInGraph()
    {
        var node = NodeCount / 2;
        _graph.FindShortestPath(_startNode, node);
    }
}