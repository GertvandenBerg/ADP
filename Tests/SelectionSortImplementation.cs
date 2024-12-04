namespace adp;

public class SelectionSortImplementation
{
    public void SelectionSort<T>(T[] array, Func<T, T, int> customComparer)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < array.Length; j++)
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