namespace adp;

public class BinarySearchImplementation
{
    public static int BinarySearch<T>(T[] sortedArray, T target, Func<T, T, int> customComparer)
    {
        int left = 0;
        int right = sortedArray.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            int comparison = customComparer(sortedArray[mid], target);
            if (comparison == 0) return mid;
            if (comparison > 0) right = mid - 1;
            else left = mid + 1;
        }

        return -1;
    }
}