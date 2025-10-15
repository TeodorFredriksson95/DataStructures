using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class CollectionTypes
    {

        public static void Main()
        {
            // Arrays
            // Arrays have the power of random access within the array
            int[] intArray = { 1, 2, 3, 4, 5, 6 };
            var randomRange = new Random().Next(0, intArray.Length);
            int intfromArray = intArray[randomRange]; // Example of random, or "free" access within the array
            Console.WriteLine("Randomly accessed value from within array: " + intfromArray);

            // Array manual remove at any index
            intArray = RemoveAt(intArray, 2);


            // Lists
            // Lists abstracts the necessity of creating manual methods of array length manipulation
            List<int> intList = new List<int>(); // No need to specify length;

            intList = new List<int> { 1,2,3,4,5}; // Fill list
            intList.RemoveAt(2); // Manual method exists within the List class.

            // Queues
            // Queus are follow the principle of FIFO - Random index manipulation is allowed. Elements are either enqueued to the end of the array, or dequeued from the beginning of the array.

            // Create class to fill Queue with
            Person person1 = new Person { name = "Teo", age = 30 };
            Person person2 = new Person { name = "Ferri", age = 20 };
            Person person3 = new Person { name = "Niklas", age = 15 };

            // Create a Queue of people
            Queue<Person> people = new Queue<Person>();

            // Enqueue adds an element to the underlying array. Elements are Enqueued to the end of the queue.
            people.Enqueue(person1); // First element
            people.Enqueue(person2); // Second element
            people.Enqueue(person3); // Third 

            // Given the above Queue, there is no way to access person2 at index 1 of the Queue. We must either Dequeue the element at position 0 or Enqueue at ö(Queue.Count +1)
            // people[1]; ---> will not work. Cannot apply indexing on Queues.

            Person deQueuedPerson = people.Dequeue(); // Dequeue the queue, assigning the element positioned at index[0] within the queue to a new person.
            Console.WriteLine("Person first in queue: " + deQueuedPerson.name); // Prints: "Teo"

            Person lastInQueuePerson = people.Last(); // Get the person last in Queue.
            Console.WriteLine("Person last in queue: " + lastInQueuePerson.name); // Prints: "Niklas"

            // Stacks
            // Stacks are similar to Queues in the way that indexing is not applicable. While Queues follow the principle of FIFO, Stacks adhere to LIFO - Last In First Out.
            // Elements added onto the Stack are done so at the end of the Stack. Elements removed from the stack are done so at the end of stack as well.
            // You can think of the Stack as a pile of dishes. When you add a plate to the stack of dishes, you place it on top of the already existing pile.
            // When you remove a clean plate from the stack, you likewise remove it from the top. Removing a plate from the middle of the pile, or adding one, could cause a potential disaster!
            Stack<Person> stackOfPeople = new Stack<Person>();
            stackOfPeople.Push(person1); // "Push" is the method of adding an element to the stack
            stackOfPeople.Push(person2);
            stackOfPeople.Push(person3);

        }
        public class Person
        {
            public string name;
            public int age;
        }
        static int[] RemoveAt(int[] array, int index)
        {
            int newArrayIndex = 0;
            int[] newArray = new int[array.Length - 1];

            for (int i = 0; i < array.Length; i++)
            {
                if (newArrayIndex == index)
                {
                    continue;
                }
                newArray[i] = array[i];
                newArrayIndex++;
            }
            return newArray;
        }
    }
}
