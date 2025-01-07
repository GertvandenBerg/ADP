namespace adp.Sortings;

public class QuickSortImplementation
{
    public static T[] QuickSort<T>(T[] array, Func<T, T, int> customComparer)
    {
        QuickSort(array, 0, array.Length - 1, customComparer);
        return array;
    }

    private static void QuickSort<T>(T[] array, int low, int high, Func<T, T, int> customComparer)
    {
        if (low >= high)
        {
            return;
        }
        
        var partitionIndex = Partition(array, low, high, customComparer);
        QuickSort(array, low, partitionIndex - 1, customComparer);
        QuickSort(array, partitionIndex + 1, high, customComparer);
    }

    private static int Partition<T>(T[] array, int low, int high, Func<T, T, int> customComparer)
    {
        var pivotIndex = MedianOfThree(array, low, high, customComparer);
        Swap(array, pivotIndex, high);
        T pivot = array[high];

        var i = low - 1;

        for (var j = low; j < high; j++)
        {
            if (customComparer(array[j], pivot) > 0)
            {
                continue;
            }
            
            i++;
            Swap(array, i, j);
        }

        Swap(array, i + 1, high);
        return i + 1;
    }

    private static int MedianOfThree<T>(T[] array, int low, int high, Func<T, T, int> customComparer)
    {
        var mid = low + (high - low) / 2;

        if (customComparer(array[low], array[mid]) > 0) Swap(array, low, mid);
        if (customComparer(array[low], array[high]) > 0) Swap(array, low, high);
        if (customComparer(array[mid], array[high]) > 0) Swap(array, mid, high);

        return mid;
    }

    private static void Swap<T>(T[] array, int i, int j)
    {
        // ReSharper disable once SwapViaDeconstruction
        var temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}