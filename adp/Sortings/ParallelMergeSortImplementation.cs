namespace adp.Sortings;

public static class ParallelMergeSortImplementation
{
    public static void ParallelMergeSort<T>(T[] array, Func<T, T, int> comparer)
    {
        if (array.Length <= 1)
        {
            return;
        }
            
        var temp = new T[array.Length];
        ParallelMergeSort(array, temp, 0, array.Length - 1, comparer);
    }

    private static void ParallelMergeSort<T>(T[] array, T[] temp, int left, int right, Func<T, T, int> comparer)
    {
        if (left >= right)
        {
            return;
        }
            
        var middle = left + (right - left) / 2;

        var leftTask = Task.Run(() => ParallelMergeSort(array, temp, left, middle, comparer));
        var rightTask = Task.Run(() => ParallelMergeSort(array, temp, middle + 1, right, comparer));

        Task.WaitAll(leftTask, rightTask);

        Merge(array, temp, left, middle, right, comparer);
    }

    private static void Merge<T>(T[] array, T[] temp, int left, int middle, int right, Func<T, T, int> comparer)
    {
        var i = left;
        var j = middle + 1;
        var k = left;

        while (i <= middle && j <= right)
        {
            if (comparer(array[i], array[j]) <= 0)
            {
                temp[k++] = array[i++];
            }
            else
            {
                temp[k++] = array[j++];
            }
        }

        while (i <= middle)
        {
            temp[k++] = array[i++];
        }

        while (j <= right)
        {
            temp[k++] = array[j++];
        }

        for (i = left; i <= right; i++)
        {
            array[i] = temp[i];
        }
    }
}