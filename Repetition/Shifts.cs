using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Repetition
{
    public class Shifts
    {
        public static void ShiftsFunc()
        {

            Console.WriteLine();
            // --------------- Left Shift Array --------------

            // Define array of ints
            int[] iArray = { 1, 5, 2, };

            // Print array before left shift
            foreach (var item in iArray)
            {
                Console.Write(item + ", ");
            }
            // Since left shift, store the first index value in a temp
            int temp = iArray[0];

            // Loop the array
            for (int i = 1; i < iArray.Length; i++)
            {
                // Shift element i into [index-1]
                iArray[i - 1] = iArray[i];
            }
            // We've reached the end of the array. Assign the initial first value (stored in temp) to the last position of the array.
            iArray[iArray.Length - 1] = temp;

            Console.WriteLine();
            // Print array after left shift
            foreach (var item in iArray)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            // --------------- Right Shift Array With Constant Space Complexity --------------

            // Define array of ints
            int[] iArray2 = { 1, 5, 2, 7, 9 };

            // Print array before right shift
            foreach (var item in iArray2)
            {
                Console.Write(item + ", ");
            }

            // Define how many times to shift
            int shiftTimes = 3;

            // Loop for the amount of times we shift
            for (int i = 0; i < shiftTimes; i++)
            {
                // We shift right, so for each shift, lets store the last position value in a temp value
                int temp2 = iArray2[iArray2.Length - 1];
                // Since we shift right, lets start at the next to last element, looping down, shifting values "upwards".
                for (int j = iArray2.Length - 1; j > 0; j--)
                {
                    iArray2[j] = iArray2[j - 1];
                }
                //Once we've reached the start of the array, place the temp value as the first value (the one we shifted out)
                iArray2[0] = temp2;

                //The outer for loop will repeat the above process for n amount of times, effectively shifting the array n times.
            }
            Console.WriteLine();
            // Print array before right shift
            foreach (var item in iArray2)
            {
                Console.Write(item + ", ");
            }

            // Modulus Left Shift
            int[] iArray3 = { 1, 0, 6, 25, 9, 2, 5, 3 };
            Console.WriteLine();
            // Print array before left modulus shift
            foreach (var item in iArray3)
            {
                Console.Write(item + ", ");
            }

            int shiftTimes2 = 3; 
            for (int i = 0; i < iArray3.Length; i++)
            {
                // Use modulus and length of array to assign new index value an arbitrary amount of times
                int newIndex = (i - shiftTimes2 + iArray3.Length) % iArray3.Length; // use (..+ iArray3.Length to make sure modulus always stays a positive number
                                                                                    // In order to ALWAYS handle potentially negative or large numbers, use the following check for n amount of times to shift:
                                                                                    //     n = ((n % arrayLength) + arrayLength) % arrayLength;

                //Shift elements n times to the left
                iArray3[i] = iArray3[newIndex];
            }
            Console.WriteLine();
            // Print array after left modulus shift
            foreach (var item in iArray3)
            {
                Console.Write(item + ", ");
            }


            // Modulus Right Shift
            int[] iArray4 = { 1, 0, 6, 25, 9, 2, 5, 3 };
            Console.WriteLine();
            // Print array before left modulus shift
            foreach (var item in iArray3)
            {
                Console.Write(item + ", ");
            }

            int shiftTimes3 = 3; 
            for (int i = 0; i < iArray3.Length; i++)
            {
                // Use modulus and length of array to assign new index value an arbitrary amount of times
                int newIndex = (i + shiftTimes3) % iArray3.Length;
                //Shift elements n times to the left
                iArray3[i] = iArray3[newIndex];
            }
            Console.WriteLine();
            // Print array after left modulus shift
            foreach (var item in iArray3)
            {
                Console.Write(item + ", ");
            }
        }


    }
}
