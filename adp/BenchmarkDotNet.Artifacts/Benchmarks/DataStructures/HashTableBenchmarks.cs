using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using adp.Hashing;

namespace Benchmarks.Hashing;

[MemoryDiagnoser]
public class HashTableBenchmarks
{
    private HashTableImplementation<int> _hashTable;
    private Dictionary<string, int> _dataset;
    private List<string> _keys;
    private string _nonExistentKey;

    [Params(100, 1_000)] public int DatasetSize;

    [GlobalSetup]
    public void Setup()
    {
        _hashTable = new HashTableImplementation<int>(DatasetSize);
        _dataset = new Dictionary<string, int>(DatasetSize);
        _keys = new List<string>(DatasetSize);

        var random = new Random();
        for (int i = 0; i < DatasetSize; i++)
        {
            var key = $"key{i}";
            var value = random.Next(1, 1000);
            _dataset[key] = value;
            _keys.Add(key);
            _hashTable.Insert(key, value);
        }

        _nonExistentKey = $"nonexistent_key_{DatasetSize}";
    }

    [Benchmark]
    public void Insert()
    {
        var tempHashTable = new HashTableImplementation<int>(DatasetSize);
        foreach (var kvp in _dataset)
        {
            tempHashTable.Insert(kvp.Key, kvp.Value);
        }
    }

    [Benchmark]
    public void Get_ExistingKey()
    {
        foreach (var key in _keys)
        {
            _hashTable.Get(key);
        }
    }

    [Benchmark]
    public void Get_NonExistentKey()
    {
        try
        {
            _hashTable.Get(_nonExistentKey);
        }
        catch (KeyNotFoundException)
        {
        }
    }

    [Benchmark]
    public void Update()
    {
        foreach (var key in _keys)
        {
            _hashTable.Update(key, _dataset[key] + 1);
        }
    }

    [Benchmark]
    public void Delete_ExistingKey()
    {
        var tempHashTable = new HashTableImplementation<int>(DatasetSize);
        foreach (var kvp in _dataset)
        {
            tempHashTable.Insert(kvp.Key, kvp.Value);
        }

        foreach (var key in _keys)
        {
            tempHashTable.Delete(key);
        }
    }

    [Benchmark]
    public void Delete_NonExistentKey()
    {
        try
        {
            _hashTable.Delete(_nonExistentKey);
        }
        catch (KeyNotFoundException)
        {
        }
    }
}