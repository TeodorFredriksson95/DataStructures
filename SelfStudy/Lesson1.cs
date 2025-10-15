using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SelfStudy
{
    public class Lesson1
    {
        public static void Main()
        {
            // Right shift array

            int[] intArray = { 1, 2, 3, 4, 5 };
            int rightMostElement = intArray[intArray.Length - 1];
            for (int i = intArray.Length -1; i > 0; i--)
            {
                intArray[i] = intArray[i - 1];
            }
            intArray[0] = rightMostElement;
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.Write(intArray[i]);
            }
            Console.WriteLine();

            // Manually reverse order in array
            int[] intArray2 = { 1, 2, 3, 4};
            for (int i = 0; i < intArray2.Length / 2; i++)
            {
                int tmp1 = intArray2[intArray2.Length - 1 - i];
                intArray2[intArray2.Length - 1 - i] = intArray2[i];
                intArray2[i] = tmp1;

            }
            for (int i = 0; i < intArray2.Length; i++)
            {
                Console.Write(intArray2[i]);
            }

            // Find Min and Max value in array
            int maxValue = int.MinValue;
            int minValue = int.MaxValue;
            int[] intArray3 = { 1, 5, 7, 2, 4, 6, 10, 23, 6 };
            for (int i = 0; i < intArray3.Length; i++)
            {
                if (intArray3[i] > maxValue) maxValue = intArray3[i];

                if (intArray3[i] < minValue) minValue = intArray3[i];
            }

            Console.WriteLine("Max value: " + maxValue);
            Console.WriteLine("Min value: " + minValue);

        }
    }
}
