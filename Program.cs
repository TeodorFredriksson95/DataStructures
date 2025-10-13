
using DataStructures;

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
int temp1 = myIntArray[0];

for (int i = 0; i < myIntArray.Length - 1; i++)
{
    myIntArray[i] = myIntArray[i + 1];
}
myIntArray[myIntArray.Length - 1] = temp1;

for (int i = 0; i < myIntArray.Length; i++)
{
    Console.WriteLine(myIntArray[i]);
}

// Right-shift array
Console.WriteLine("\nRight Shift Array");
int[] rightIntArray = { 1, 2, 3, 4 };
int temp2 = rightIntArray[rightIntArray.Length - 1];

for (int i = rightIntArray.Length - 1; i > 0; i--)
{
    rightIntArray[i] = rightIntArray[i - 1];
}
rightIntArray[0] = temp2;

for (int i = 0; i < rightIntArray.Length; i++)
{
    Console.WriteLine(rightIntArray[i]);

}


// Linear space complexity
//Shift using modulus and without bound checking
Console.WriteLine("\n Shiftin Array With Modulus Operator - Linear space complexity"); //Linear complexity means memory required to handle the operation grows at the same rate as the input size.

int[] testArray = { 5, 3, 2, 10, 55, 32, 2 };
var intArray = Shift(testArray, 5);
for (int i = 0; i < intArray.Length; i++)
{
    Console.WriteLine(intArray[i]);
}

    int[] Shift(int[] array, int k)
    {

        var result = new int[array.Length]; // Creating a new array is what causes the linear complexity. The memory required to handle the input is equivalent to the input size.
        for (int i = 0; i < array.Length; i++)
        {
            result[(i + k) % array.Length] = array[i];
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

// Make a tetris block by using decoded bytes