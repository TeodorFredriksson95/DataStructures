using DataStructures.Repetition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SelfStudy
{
    public class Lesson6
    {
        public static void LinearSearchFunc()
        {

            // ------- LINEAR SEARCH --------------

            // Define array to search through
            int[] iArray = { 1, 50, 2, 33, 12 };

            // Define number to search for
            int iNr = 33;

            Console.WriteLine("------- BINARY SEARCH --------");
            FindNumber(iArray, iNr);

        }

        public static void BinarySearch()
        {
            // Define array to search through
            int[] iArray = { 1, 55, 3, 22, 10, 93, 25, 365, 21 };

            // Define number to search for
            int iNr = 55;

            //A pre-requisite for Binary Search is that the array is sorted.
            // Sort the array
            int[] iSortedArray = QuickSort.QuickSortFunc(iArray, 0, iArray.Length - 1);

            // Print array to verify that it's been sorted.
            Console.WriteLine("Sorted binary search array");
            foreach (var item in iSortedArray)
            {
                Console.Write(item + ", ");
            }
           int foundNr = FindNumberBinary(iSortedArray, iNr, 0, iArray.Length - 1);
        }

        static int FindNumberBinary(int[] iArray, int iNr, int start, int end)
        {

            // Find middle index of array
            int middle = (start + end) / 2;

            // Check if we have found the searched for number. If so, return early.
            if (iArray[middle] == iNr)
            {
                return iNr;
            }

            //Check if searched for number is less than middle element
            if (iNr < iArray[middle])
            {
                // Perform recursive operation on left-partitioned array
                FindNumberBinary(iArray, iNr, 0, middle - 1);
            }

            // Check if searched for number is greater than middle element
            else if (iNr > iArray[middle])
            {
                // Perform recursive operation on right-partitioned array
                FindNumberBinary(iArray, iNr, middle + 1, iArray.Length - 1);
            }
            else
            {
                Console.WriteLine("Couldnt find nr: " + iNr);
            }
                return iNr;
        }

        static int FindNumber(int[] iArray, int iNr)
        {
            // Loop through array
            for (int i = 0; i < iArray.Length; i++)
            {
                // Check every value for the searched number
                if (iArray[i] == iNr)
                {
                    // Return the number
                    Console.WriteLine("Found number: " + iNr);
                    return iNr;
                }
            }

            // If number wasnt found, return a 'bad' number
            Console.WriteLine("Couldn't find number: " + iNr);
            return -1;
        }


    }
}
