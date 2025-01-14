namespace adp.DataStructures;

public class GraphImplementation
{
    private readonly Dictionary<int, List<(int neighbor, int weight)>> _adjacencyList = new();

    private readonly Comparer<(int vertex, int distance)> _distanceComparer =
        Comparer<(int vertex, int distance)>.Create(
            (a, b) =>
            {
                if (a.distance == b.distance)
                {
                    return a.vertex.CompareTo(b.vertex);
                }

                return a.distance.CompareTo(b.distance);
            }
        );

    public void AddVertex(int vertex)
    {
        if (!_adjacencyList.ContainsKey(vertex))
        {
            _adjacencyList[vertex] = [];
        }
    }

    public void AddEdge(int src, int dest)
    {
        AddWeightedEdge(src, dest, 1);
    }

    public void AddWeightedEdge(int src, int dest, int weight)
    {
        if (!_adjacencyList.ContainsKey(src))
        {
            AddVertex(src);
        }

        if (!_adjacencyList.ContainsKey(dest))
        {
            AddVertex(dest);
        }

        if (!_adjacencyList[src].Contains((dest, weight)))
        {
            _adjacencyList[src].Add((dest, weight));
        }
    }

    public int[] FindShortestPath(int startVertex, int targetVertex)
    {
        var isWeighted = _adjacencyList.Any(kvp => kvp.Value.Any(edge => edge.weight > 1));

        if (isWeighted)
        {
            return Dijkstra(startVertex, targetVertex);
        }
        
        return Bfs(startVertex, targetVertex);
    }

    private int[] Bfs(int startVertex, int targetVertex)
    {
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        var parent = new Dictionary<int, int>();

        visited.Add(startVertex);
        queue.Enqueue(startVertex);
        parent[startVertex] = -1;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current == targetVertex)
            {
                return ReconstructPath(parent, targetVertex);
            }

            foreach (var (neighbor, _) in _adjacencyList[current])
            {
                if (visited.Contains(neighbor))
                {
                    continue;
                }

                visited.Add(neighbor);
                queue.Enqueue(neighbor);
                parent[neighbor] = current;
            }
        }

        return [];
    }

    private int[] Dijkstra(int startVertex, int targetVertex)
    {
        var distances = new Dictionary<int, int>();
        var parent = new Dictionary<int, int>();

        var priorityQueue = new SortedSet<(int vertex, int distance)>(_distanceComparer);

        foreach (var vertex in _adjacencyList.Keys)
        {
            distances[vertex] = int.MaxValue;
        }

        distances[startVertex] = 0;
        parent[startVertex] = -1;
        priorityQueue.Add((startVertex, 0));

        while (priorityQueue.Count > 0)
        {
            var (currentVertex, currentDistance) = priorityQueue.Min;
            priorityQueue.Remove(priorityQueue.Min);

            if (currentVertex == targetVertex)
            {
                return ReconstructPath(parent, targetVertex);
            }

            var neighbors = _adjacencyList[currentVertex];

            foreach (var (neighbor, weight) in neighbors)
            {
                var newDistance = currentDistance + weight;

                if (newDistance >= distances[neighbor])
                {
                    continue;
                }

                priorityQueue.Remove((neighbor, distances[neighbor]));
                distances[neighbor] = newDistance;
                parent[neighbor] = currentVertex;
                priorityQueue.Add((neighbor, newDistance));
            }
        }

        return [];
    }

    private static int[] ReconstructPath(Dictionary<int, int> parent, int targetVertex)
    {
        var path = new List<int>();
        for (var v = targetVertex; v != -1; v = parent[v])
        {
            path.Add(v);
        }

        path.Reverse();
        return path.ToArray();
    }
}