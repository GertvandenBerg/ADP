using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Tests;

public static class JsonProvider
{
    public static Dataset LoadTestData()
    {
        var jsonData = File.ReadAllText("TestData.json");
        
        return System.Text.Json.JsonSerializer.Deserialize<Dataset>(jsonData);
    }
    
    public static SortDataset LoadSortData()
    {
        var jsonData = File.ReadAllText("Datasets/SortDataset.json");
        
        return System.Text.Json.JsonSerializer.Deserialize<SortDataset>(jsonData);
    }

    public static HashingDataset LoadHashingDataset()
    {
        var jsonData = File.ReadAllText("Datasets/HashingDataset.json");
        
        return System.Text.Json.JsonSerializer.Deserialize<HashingDataset>(jsonData);
    }
}

public class SortDataset
{
    [JsonPropertyName("lijst_aflopend_2")]
    public int[] LijstAflopend2 { get; set; }
    
    [JsonPropertyName("lijst_oplopend_2")]
    public int[] LijstOplopend2 { get; set; } 
    
    [JsonPropertyName("lijst_float_8001")]
    public float[] LijstFloat8001 { get; set; }
    
    [JsonPropertyName("lijst_gesorteerd_aflopend_3")]
    public int[] LijstGesorteerdAflopend3 { get; set; }
    
    [JsonPropertyName("lijst_gesorteerd_oplopend_3")]
    public int[] LijstGesorteerdOplopend3 { get; set; }
    
    [JsonPropertyName("lijst_herhaald_1000")]
    public int[] LijstHerhaald1000 { get; set; }
    
    [JsonPropertyName("lijst_leeg_0")]
    public int[] LijstLeeg0 { get; set; }
    
    [JsonPropertyName("lijst_null_1")]
    public int?[] LijstNull1 { get; set; }
    
    [JsonPropertyName("lijst_null_3")]
    public int?[] LijstNull3 { get; set; }
    
    [JsonPropertyName("lijst_onsorteerbaar_3")]
    public object[] LijstOnsorteerbaar3 { get; set; }
    
    [JsonPropertyName("lijst_oplopend_10000")]
    public int[] LijstOplopend10000 { get; set; }
    
    [JsonPropertyName("lijst_willekeurig_10000")]
    public int[] LijstWillekeurig10000 { get; set; }
    
    [JsonPropertyName("lijst_willekeurig_3")]
    public int[] LijstWillekeurig3 { get; set; }
    
}

public class HashingDataset
{
    [JsonPropertyName("hashtabelsleutelswaardes")]
    public Dictionary<string, int[]> Hashtabelsleutelswaardes { get; set; }
}


public class Dataset
{
    public int[][] lijnlijst { get; set; }
    public int[][] verbindingslijst { get; set; }
    public int[][] verbingdingsmatrix { get; set; }
    public int[][] lijnlijst_gewogen { get; set; }
    public int[][][] verbindingslijst_gewogen { get; set; }
    public int[][] verbindingsmatrix_gewogen { get; set; }
}