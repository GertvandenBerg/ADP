namespace adp.Searches;

public class BinarySearchTreeImplementation<T>(Func<T, T, int> customComparer)
{
    public class Node
    {
        public T Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    private Node? _root;

    public Node? Find(T value)
    {
        var current = _root;
        while (current != null)
        {
            var cmp = customComparer(value, current.Value);
            if (cmp == 0) return current;
            current = cmp < 0 ? current.Left : current.Right;
        }
        return null;
    }

    public Node? FindMin()
    {
        if (_root == null) return null;
        var current = _root;
        while (current.Left != null) current = current.Left;
        return current;
    }

    public Node? FindMax()
    {
        if (_root == null) return null;
        var current = _root;
        while (current.Right != null) current = current.Right;
        return current;
    }

    public void Insert(T value)
    {
        if (_root == null)
        {
            _root = new Node(value);
            return;
        }
        var current = _root;
        var parent = current;
        while (current != null)
        {
            parent = current;
            var cmp = customComparer(value, current.Value);
            if (cmp < 0) current = current.Left;
            else if (cmp > 0) current = current.Right;
            else return;
        }
        if (customComparer(value, parent.Value) < 0) parent.Left = new Node(value);
        else parent.Right = new Node(value);
    }

    public void Remove(T value)
    {
        _root = RemoveNode(_root, value);
    }

    private Node? RemoveNode(Node? root, T value)
    {
        if (root == null) return null;
        var cmp = customComparer(value, root.Value);
        if (cmp < 0) root.Left = RemoveNode(root.Left, value);
        else if (cmp > 0) root.Right = RemoveNode(root.Right, value);
        else
        {
            if (root.Left == null) return root.Right;
            if (root.Right == null) return root.Left;
            var successor = FindMinFrom(root.Right);
            root.Value = successor.Value;
            root.Right = RemoveNode(root.Right, successor.Value);
        }
        return root;
    }

    private static Node FindMinFrom(Node node)
    {
        var current = node;
        while (current.Left != null) current = current.Left;
        return current;
    }
}