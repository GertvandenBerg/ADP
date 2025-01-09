namespace adp.Hashing;

public class HashTableImplementation<T>
{
    private readonly int _size;
    private readonly LinkedList<KeyValuePair<string, T>>[] _buckets;

    public HashTableImplementation(int size = 100)
    {
        _size = size;
        _buckets = new LinkedList<KeyValuePair<string, T>>[_size];
        for (var i = 0; i < _size; i++)
        {
            _buckets[i] = new LinkedList<KeyValuePair<string, T>>();
        }
    }

    private int GetBucketIndex(string key)
    {
        return Math.Abs(key.GetHashCode()) % _size;
    }

    public void Insert(string key, T value)
    {
        var bucketIndex = GetBucketIndex(key);
        var bucket = _buckets[bucketIndex];

        foreach (var pair in bucket)
        {
            if (pair.Key == key)
            {
                throw new ArgumentException("Key already exists");
            }
        }

        bucket.AddLast(new KeyValuePair<string, T>(key, value));
    }

    public T Get(string key)
    {
        var bucketIndex = GetBucketIndex(key);
        var bucket = _buckets[bucketIndex];

        foreach (var pair in bucket)
        {
            if (pair.Key == key)
            {
                return pair.Value;
            }
        }

        throw new KeyNotFoundException("Key not found");
    }

    public void Delete(string key)
    {
        var bucketIndex = GetBucketIndex(key);
        var bucket = _buckets[bucketIndex];

        foreach (var pair in bucket)
        {
            if (pair.Key != key) continue;
            
            bucket.Remove(pair);
            return;
        }

        throw new KeyNotFoundException("Key not found");
    }

    public void Update(string key, T newValue)
    {
        var bucketIndex = GetBucketIndex(key);
        var bucket = _buckets[bucketIndex];

        for (var node = bucket.First; node != null; node = node.Next)
        {
            if (node.Value.Key != key) continue;
            
            bucket.Remove(node);
            bucket.AddLast(new KeyValuePair<string, T>(key, newValue));
            return;
        }

        throw new KeyNotFoundException("Key not found");
    }
}