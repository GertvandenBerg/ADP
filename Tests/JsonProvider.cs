using Newtonsoft.Json;

namespace Tests;

public static class JsonProvider
{
    public static Dataset LoadTestData()
    {
        var jsonData = File.ReadAllText("TestData.json");
        
        return System.Text.Json.JsonSerializer.Deserialize<Dataset>(jsonData);
    }
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