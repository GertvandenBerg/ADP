namespace adp.Sortings;

public class SelectionSortImplementation
{
    public static void SelectionSort<T>(T[] array, Func<T, T, int> customComparer)
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            var minIndex = i;

            for (var j = i + 1; j < array.Length; j++)
            {
                if (customComparer(array[j], array[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }

            if (minIndex == i)
            {
                continue;
            }
            
            // ReSharper disable once SwapViaDeconstruction
            var temp = array[i];
            array[i] = array[minIndex];
            array[minIndex] = temp;
        }
    }
}