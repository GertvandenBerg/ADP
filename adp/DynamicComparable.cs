namespace adp;

public static class DynamicComparable
{
    public static bool AreEqual<T>(T obj1, T obj2)
    {
        if (obj1 == null && obj2 == null) return true;
        if (obj1 == null || obj2 == null) return false;

        if (typeof(T).IsPrimitive || typeof(T).IsValueType || typeof(T) == typeof(string))
        {
            return obj1.Equals(obj2);
        }

        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            var value1 = property.GetValue(obj1);
            var value2 = property.GetValue(obj2);

            if (!AreEqual(value1, value2))
            {
                return false;
            }
        }

        return true;
    }
}