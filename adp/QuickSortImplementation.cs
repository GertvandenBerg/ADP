using System;

namespace adp;

public class QuickSortImplementation
{
    public void QuickSort<T>(T[] array, Func<T, T, int> customComparer)
    {
        QuickSort(array, 0, array.Length - 1, customComparer);
    }

    private void QuickSort<T>(T[] array, int low, int high, Func<T, T, int> customComparer)
    {
        if (low < high)
        {
            int partitionIndex = Partition(array, low, high, customComparer);
            QuickSort(array, low, partitionIndex - 1, customComparer);
            QuickSort(array, partitionIndex + 1, high, customComparer);
        }
    }

    private int Partition<T>(T[] array, int low, int high, Func<T, T, int> customComparer)
    {
        int pivotIndex = MedianOfThree(array, low, high, customComparer);
        Swap(array, pivotIndex, high);
        T pivot = array[high];

        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (customComparer(array[j], pivot) <= 0)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);
        return i + 1;
    }

    private int MedianOfThree<T>(T[] array, int low, int high, Func<T, T, int> customComparer)
    {
        int mid = low + (high - low) / 2;

        if (customComparer(array[low], array[mid]) > 0) Swap(array, low, mid);
        if (customComparer(array[low], array[high]) > 0) Swap(array, low, high);
        if (customComparer(array[mid], array[high]) > 0) Swap(array, mid, high);

        return mid;
    }

    private void Swap<T>(T[] array, int i, int j)
    {
        // ReSharper disable once SwapViaDeconstruction
        T temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}