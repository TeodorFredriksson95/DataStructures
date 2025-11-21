using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Repetition
{
    public class QuickSort
    {
        public static void QuickSortMain()
        {
            Console.WriteLine("----------- QUICK SORT ------------");
            int[] m_iArray = { 1, 502, 35, 22, 11, 63, 3 };
            QuickSortFunc(m_iArray, 0, m_iArray.Length - 1);
            foreach (var item in m_iArray)
            {
                Console.Write(item + ", ");
            }
        }
       public static int[] QuickSortFunc(int[] iArray, int leftIndex, int rightIndex)
        {

            //Find value in the middle of the array
            int pivot = iArray[(leftIndex + rightIndex) / 2];

            //Assign two iterative pointers
            int i = leftIndex;
            int j = rightIndex;

            while (i <= j)
            {
                while (iArray[i] < pivot)
                {
                    i++;
                }
                while (iArray[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = iArray[i];
                    iArray[i] = iArray[j];
                    iArray[j] = temp;

                    i++;
                    j--;

                    QuickSortFunc(iArray, leftIndex, j); //Partition array between leftindex and j (given an array of 10 elements, this is potentially between 0 and n).
                    QuickSortFunc(iArray, i, rightIndex); //Partition array between right index and i(given an array of 10 elements, this is potentially between 5 and arraylength -1).
                }
              
            }

            return iArray;
        }

    }
}
