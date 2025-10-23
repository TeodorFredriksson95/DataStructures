
using DataStructures;
using DataStructures.Algorithms;
using DataStructures.Repetition;
using DataStructures.SelfStudy;

Console.WriteLine("Create encoded Tetris byte file");

TetrisEncoder.Main();

Console.WriteLine("----------------------------------------------------------------------------");


Console.WriteLine("\nModulus Remainder Calcs");
int o = 256000;
int modulus = 640;
int remainder = o % modulus;

int heightY = o / 640;

Console.WriteLine($"int i: {o} % {modulus} == {remainder}. row = {heightY}");

Console.WriteLine("\n------------------------------------------------------------------");


// Left-shift array
Console.WriteLine("\n Left Shift Array");
int[] myIntArray = { 1, 2, 3, 4 };
int temp1 = myIntArray[0]; // Store the first element of the array that will be shifted out of the array.

for (int i = 0; i < myIntArray.Length - 1; i++) // Will break iteration before the last index.
{
    myIntArray[i] = myIntArray[i + 1]; // Assign the current index (first in line) the element of the index next in line of the iteration, resulting in a left shift.
}
myIntArray[myIntArray.Length - 1] = temp1; // The last element is replaced with the first element that we shifted out of the array.

for (int i = 0; i < myIntArray.Length; i++)
{
    Console.Write(myIntArray[i] + ", "); // 2, 3, 4, 1
}

// Right-shift array
Console.WriteLine("\nRight Shift Array");
int[] rightIntArray = { 1, 2, 3, 4 };
int temp2 = rightIntArray[rightIntArray.Length - 1]; // Store the last element of the array that will be shifted out

for (int i = rightIntArray.Length - 1; i > 0; i--) // Start iteration at next to last element, because we will start the shifting process at the last index.
                                                   // Neglecting to use the - sign would result in an out of bounds exception, since we would be trying to access array[4], which does not exist in this context.
{
    rightIntArray[i] = rightIntArray[i - 1]; // Assign the current index (last in line) the element of the previous index, resulting in a right shift.
}
rightIntArray[0] = temp2; // Assign the first index the value of the right-most element that was shifted out of the array.

for (int i = 0; i < rightIntArray.Length; i++)
{
    Console.Write(rightIntArray[i] + ", "); // 4, 1, 2, 3

}


// Linear space complexity
//Shift using modulus and without bound checking
Console.WriteLine("\n Shiftin Array With Modulus Operator - Linear space complexity"); //Linear complexity means memory required to handle the operation grows at the same rate as the input size.

int[] testArray = { 5, 3, 2, 10, 55, 32, 2 };
var intArray = Shift(testArray, 5); // Right shift
for (int i = 0; i < intArray.Length; i++)
{
    Console.Write(intArray[i] + ", "); // 2, 10, 55, 32, 2, 5, 3
}

    int[] Shift(int[] array, int k) // k = the amount of positions we want to shift a value.
    {

        var result = new int[array.Length]; // Creating a new array is what causes the linear complexity. The memory required to handle the input is equivalent to the input size.
    for (int i = 0; i < array.Length; i++)
    {
        result[(i + k) % array.Length] = array[i];
        // The equation of the above looks like this on the first iteration
        // result[(0+5) % an arbitrary length] = array[0].

        // Lets say array.Length is 7. that gives the following equation: 5 % 7 = 5.
        // Given the above equation, we get: result[5] = array[0]. So, we're shifting the elements 5 positions to the right.

        // Given that statement, let's put it to the test with the value from testArray at index 5. It should be moved to position 3, given the above reasoning.
        // It will reach the end of the array, and then pop back into the first position at the start of the array

        // result[(i+k) % array.Length] = array[0]
        // result[(5+5) % 7] = array[5];
        // 10 % 7 = 3
        // result[3] = array[5]

        // The reasoning behind these patterns are from modular arithmetics. The if given an array of n length, the % n
        // garuantees that if we cross the length of the array, we circle back to the beginning.


        // If we want to make a left shift instead of a right shift, we can change this:
        // result[(i + k) % array.Length] = array[i];

        // to this:
        // result[i] = array[(i + k) % array.Length];

        // In this scenario: result[(i + k) % array.Length] = array[i]; --- we're basically saying
        // "Assign to the current index + k positions the value of the arrays current index.", resulting in a right shift.

        // In the other scenario: result[i] = array[(i + k) % array.Length]; -- we're instead saying
        // "At result index i, place the element that is k positions ahead in the original array.", resulting in a left shift.



    }
    return result;
    }

// Constant space complexity
//Shift using modulus and without bound checking
Console.WriteLine("\n Shifting Array Right With Modulus Operator - Constant space complexity"); // Constant complexity means we can know beforehand how much memory is required in order to run the algorithm.
int[] ShiftConstantComplexity(int[] array, int k)
{
    for (int times = 0; times < k; times++) //Repeat the array iterations for as many times as the value should be shifted, defined by k. Not as performant, but constant complexity.
    {
        int tmp = array[array.Length - 1]; //Get the last element in array.
        for (int i = array.Length -1; i > 0 ; i--) //Start from the last element and countdown to 0+1.
        {
            array[i] = array[i - 1]; // If array length is 4 then on first iteration then this line becomes array[3] = array[3-1]. Shifting right.
        }
        //Insert the temp value at the beginning of array
        array[0] = tmp;
    }
    return array;
}

PrintArrayElements(ShiftConstantComplexity(new int[] {1,2,3,4,5}, 2));

Console.WriteLine("\n Shifting Array Left With Modulus Operator - Constant space complexity");
int[] testArray3 = { 1, 2, 3, 4, 5 };
PrintArrayElements(ShiftLeftConstantComplexity(testArray3, 2));
int[] ShiftLeftConstantComplexity(int[] array, int k)
{
    for (int times = 0; times < k; times++)
    {
        int tmp = array[0]; // Get first element in array
        for (int i = 0; i < array.Length -1; i++) // Start from first element, but stop before last
        {
            array[i] = array[i + 1]; //Shift second to first element to the first.
        }
        //Insert the leftmost shifted value to the end of the array
        array[array.Length - 1] = tmp;
    }
    return array;
}


// Reverse order in array
Console.WriteLine("\nReverse Array");
int[] reverseArray = { 1, 2, 3, 4 };
Array.Reverse(reverseArray);
for (int i = 0; i < reverseArray.Length; i++)
{
    Console.WriteLine(reverseArray[i]);
}

// Find min value and max value in array
Console.WriteLine("\nFind min and max value in Array");
int minValue = int.MaxValue;
int maxValue = int.MinValue;

int[] randomIntsArray = { 1, 50, 20, 32, 11, 26 };

for (int i = 0; i < randomIntsArray.Length; i++)
{
    if (randomIntsArray[i] < minValue)
        minValue = randomIntsArray[i];

    else if (randomIntsArray[i] > maxValue)
        maxValue = randomIntsArray[i];
}
Console.WriteLine("Min value: " + minValue);
Console.WriteLine("Max value: " + maxValue);

//Function to print all elements of a given array

void PrintArrayElements(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine(array[i]);
    }
}


Console.WriteLine("--------- Collection Types Practice ---------------");
CollectionTypes.Main();

Console.WriteLine("--------- Self Study - Lesson 1 ---------------");
Lesson1.Main();


Console.WriteLine("--------- Self Study - Lesson 2 ---------------");
Lesson2.Main();

Console.WriteLine("--------- Algorithms Lecture ---------------");
Sorts.Main();

Console.WriteLine("-------------- Recursions ------------------------");
Recursions.Main();

Console.WriteLine("-------------- REPETITION ------------------------");
Shifts.ShiftsFunc();

Console.WriteLine();
QuickSort.QuickSortMain();