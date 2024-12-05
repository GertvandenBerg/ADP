using System.Text.Json;

namespace adp;

public static class DynamicComparable
{
    public static bool AreEqual<T>(this T obj1, T obj2)
    {
        if (obj1 == null && obj2 == null) return true;
        if (obj1 == null || obj2 == null) return false;
        
        if (JsonSerializer.Serialize(obj1) == JsonSerializer.Serialize(obj2))
        {
            return true;
        }

        return false;
    }
}