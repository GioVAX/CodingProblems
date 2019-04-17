namespace Coding_Problems
{

    // Find index of array that divides array into 2 non-empty subarrays with equal sum

    public class SplitArrayEqualSum
    {
        public static int Split(int[] array, int size)
        {
            int[] partialSums = new int[size];
            int grandTotal = 0;

            for (int i = 0; i < size; i++)
            {
                partialSums[i] = grandTotal;
                grandTotal += array[i];
            }

            for (int i = 0; i < size; i++)
                if (grandTotal - partialSums[i] - array[i] == partialSums[i])
                    return i;

            return -1;
        }
    }
}