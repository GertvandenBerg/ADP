using adp.Hashing;

namespace Tests.Hashing;

public class HashTableImplementationTests
{
    [Fact]
    public void Insert_AddsElementToHashTable()
    {
        var hashTable = new HashTableImplementation<int>(10);
        hashTable.Insert("key1", 100);

        Assert.Equal(100, hashTable.Get("key1"));
    }

    [Fact]
    public void Get_ReturnsCorrectValue()
    {
        var hashTable = new HashTableImplementation<int>(10);
        hashTable.Insert("key1", 100);
        hashTable.Insert("key2", 200);

        Assert.Equal(200, hashTable.Get("key2"));
    }

    [Fact]
    public void Get_ThrowsException_ForNonExistentKey()
    {
        var hashTable = new HashTableImplementation<int>(10);

        Assert.Throws<KeyNotFoundException>(() => hashTable.Get("nonexistent"));
    }

    [Fact]
    public void Delete_RemovesElementFromHashTable()
    {
        var hashTable = new HashTableImplementation<int>(10);
        hashTable.Insert("key1", 100);

        hashTable.Delete("key1");

        Assert.Throws<KeyNotFoundException>(() => hashTable.Get("key1"));
    }

    [Fact]
    public void Delete_ThrowsException_ForNonExistentKey()
    {
        var hashTable = new HashTableImplementation<int>(10);

        Assert.Throws<KeyNotFoundException>(() => hashTable.Delete("nonexistent"));
    }

    [Fact]
    public void Update_ChangesValueForExistingKey()
    {
        var hashTable = new HashTableImplementation<int>(10);
        hashTable.Insert("key1", 100);

        hashTable.Update("key1", 200);

        Assert.Equal(200, hashTable.Get("key1"));
    }

    [Fact]
    public void Update_ThrowsException_ForNonExistentKey()
    {
        var hashTable = new HashTableImplementation<int>(10);

        Assert.Throws<KeyNotFoundException>(() => hashTable.Update("key1", 200));
    }

    [Fact]
    public void Insert_ThrowsException_ForDuplicateKey()
    {
        var hashTable = new HashTableImplementation<int>(10);
        hashTable.Insert("key1", 100);

        Assert.Throws<ArgumentException>(() => hashTable.Insert("key1", 200));
    }

    [Fact]
    public void InsertAndGet_WorkForMultipleKeys()
    {
        var hashTable = new HashTableImplementation<int>(10);
        hashTable.Insert("key1", 100);
        hashTable.Insert("key2", 200);
        hashTable.Insert("key3", 300);

        Assert.Equal(100, hashTable.Get("key1"));
        Assert.Equal(200, hashTable.Get("key2"));
        Assert.Equal(300, hashTable.Get("key3"));
    }
    
    [Fact]
    public void HandleDatasetHashing()
    {
        // Arrange
        var dataset = JsonProvider.LoadHashingDataset();

        // Act
        var hashTable = new HashTableImplementation<int[]>(dataset.Hashtabelsleutelswaardes.Count);

        foreach (var sleutelWaarde in dataset.Hashtabelsleutelswaardes)
        {
            hashTable.Insert(sleutelWaarde.Key, sleutelWaarde.Value);
        }

        // Assert
        foreach (var sleutelWaarde in dataset.Hashtabelsleutelswaardes)
        {
            // Check if the retrieved value matches the expected value
            var retrievedValue = hashTable.Get(sleutelWaarde.Key);
            Assert.Equal(sleutelWaarde.Value, retrievedValue);
        }
    }
}