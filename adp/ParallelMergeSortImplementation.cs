namespace adp
{
    public class ParallelMergeSortImplementation
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

            // Parallelize the sorting of the two halves
            var leftTask = Task.Run(() => ParallelMergeSort(array, temp, left, middle, comparer));
            var rightTask = Task.Run(() => ParallelMergeSort(array, temp, middle + 1, right, comparer));

            Task.WaitAll(leftTask, rightTask);

            // Merge the sorted halves
            Merge(array, temp, left, middle, right, comparer);
        }

        private static void Merge<T>(T[] array, T[] temp, int left, int middle, int right, Func<T, T, int> comparer)
        {
            var i = left;
            var j = middle + 1;
            var k = left;

            // Merge the two subarrays into the temp array
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

            // Copy any remaining elements from the left subarray
            while (i <= middle)
            {
                temp[k++] = array[i++];
            }

            // Copy any remaining elements from the right subarray
            while (j <= right)
            {
                temp[k++] = array[j++];
            }

            // Copy the sorted elements back to the original array
            for (i = left; i <= right; i++)
            {
                array[i] = temp[i];
            }
        }
    }
}
