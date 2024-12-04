namespace adp;

public class InsertionSortImplementation
{
    public void InsertionSort<T>(T[] array, Func<T, T, int> customComparer)
    {
        for (int i = 1; i < array.Length; i++)
        {
            T key = array[i];
            int j = i - 1;

            while (j >= 0 && customComparer(array[j], key) > 0)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = key;
        }
    }
}