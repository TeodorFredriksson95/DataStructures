using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Algorithms
{
    public class Sorts
    {
        public static void Main()
        {
            int iComparisons = 0;
            int[] m_iArray = { 23, 45, 21, 23, 11, 2, 1, 59, 100 };
            int[] m_iPerformanceArray = new int[200];

            // Basic sort, no performance in mind O(n^2)
            for (int Left = 0; Left < m_iPerformanceArray.Length; Left++)
            {
                for (int Right = Left + 1; Right < m_iPerformanceArray.Length; Right++)
                {
                    int temp = m_iPerformanceArray[Left];
                    if (m_iPerformanceArray[Right] < m_iPerformanceArray[Left])
                    {
                        m_iPerformanceArray[Left] = m_iPerformanceArray[Right];
                        m_iPerformanceArray[Right] = temp;
                    }
                    iComparisons++;
                }
            }
            Console.WriteLine("Sorted nr array");

            foreach (var nr in m_iPerformanceArray)
            {
                Console.Write(nr + ", ");
            }
            Console.WriteLine("Number of comparions made in the above sort: " + iComparisons);


            Console.WriteLine("------------ Quick Sort -------------------");

            //Array to be sorted
            int[] m_iQSArray = { 52, 96, 67, 71, 42, 38, 39, 40, 14 };

            // Quick Sort is a "divide and conquer" discipline.
            // Choose a pivot point and use that to partition the array in smaller sections.
            // Split into 2 subarrays based on the pivot point, the left section will contain numbers smaller than the pivot point
            // The right sight will contain numbers larger than the pivot point.

            // There are different algorithm structures for a quick sort, and their usage and structure heavily depends on what you choose to consider your pivot point.
            // The most popular and efficient ones are where the pivot point is either the element at first, last, random or median position, where the 
            // median position is based on the first, last and middle element.

            Console.WriteLine("------------- Quick Sort - First element pivot-----------------");

            int iQSTemp;
            for (int i = 1; i < m_iQSArray.Length; i++)  // Traverse the array from first and last element
            {
                //Compare the elements against the pivot, which is the first element in the array
                // Given the above array, the m_iQSarray pivot, which is the first element, will be compared against the first element after the pivot, and
                // the last element of the array

                // On first iteration, 96 and 14 will be compared to 52.
                // 96 is more than the pivot, but the 14 is less than the pivot.
                // Swap the 96 and 14 elements.
                iQSTemp = m_iQSArray[i]; // Store one of the elements which is to be swapped.
                m_iQSArray[i] = m_iQSArray[m_iQSArray.Length - i]; // Swap last element into current element
                m_iQSArray[m_iQSArray.Length - i] = iQSTemp; // Assign the temp value into the last index, finalizing the swap.

                //Repeat the above process for numbers 67 & 40, 71 & 39. One of these values are greater than the pivot, while the other one is smaller.

                // 42 and 38 are both less than the pivot, which triggers the iteration to stop.
                // Now we need to decide the split point of the array. 38 is less than the pivot, so we swap its position with the pivot.
                // Meanwhile, 71 is greater than the pivot, which makes it become the new split point.

                // We should now have the following array elements: 38, 14, 40, 39, 42, 52, 71, 67, 96
                // Given recursion, the next iteration should operate on two different arrays based on the split points.

                // ------ SECOND PARTITION LEVEL ---------
                // The left subarray is 38, 14, 40, 39, 42 and the right subarray is 71, 67, 96

                // Given that 71 is the right subarrays pivot point, we compare 67 and 96 to the pivot. 67 is less than the pivot, which means we swap it with 71.
                // Meanwhile, 96 is greater than the pivot, and thus it retains its position.

                //Repeat the same process for the left subarray and select 38 as the pivot for that subarray.
                //14 is less than the pivot while the rest of the elements are greater than the pivot so the array becomes 14, 38, 40, 39, 42

                // ---- THIRD PARTITION LEVEL -------
                // In the last iteration of this example, the nr 40 is chosen as the pivot. 39 is less than the pivot, so they swap places.
                // 42 is greater than the pivot, which means it stays in place.
                // we are now left with a left subarray of 14, 38, 39, 40, 42 and a right subarray of 67, 71, 96, making the overall array:
                // 14, 38, 39, 40, 42, 67, 71, 96
            }

            // Quick sort implementation
            // Define a method for entry point. Necessary for recursion.
            int[] QuickSort(int[] iArray, int leftIndex, int rightIndex)
            {
                int i = leftIndex;
                int j = rightIndex;
                int pivot = iArray[leftIndex];

                // Given the array example above
                while (i <= j) // while 0 <= 8 - j
                {
                    while (iArray[i] < pivot) // while 52 < 52
                    {
                        i++; // Increase leftindex position
                    }
                    while (iArray[j] > pivot) // while 14 > 52
                    {
                        j--; // Decrese rightindex position
                    }

                    if (i <= j) // For each iteration, perform a valid swap
                    {
                        int temp = iArray[i]; // Store left subarray value
                        iArray[i] = iArray[j]; // Replace left value with right
                        iArray[j] = temp; // Replace right value with previously stored left value, finalizing the swap.

                        //Increment and Decrement respective positions
                        i++;
                        j--;
                    }
                }
                if (leftIndex < j) //If 0 < current right index position. After the while loop finishes the first time, this equates to: if 0 < 4
                    QuickSort(iArray, leftIndex, j); //Sort again 

                return new int[2];
            }

            QuickSort(m_iQSArray, 0, m_iQSArray.Length - 1);
        }
    }
}
