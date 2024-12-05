namespace adp.Sortings;

public class InsertionSortImplementation
{
    public static void InsertionSort<T>(T[] array, Func<T, T, int> customComparer)
    {
        for (var i = 1; i < array.Length; i++)
        {
            var key = array[i];
            var j = i - 1;

            while (j >= 0 && customComparer(array[j], key) > 0)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = key;
        }
    }
}