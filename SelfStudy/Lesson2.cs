using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStructures.SelfStudy
{
    public class Lesson2
    {
        public static void Main()
        {
            // Implement a bool Contains(T item) function for the List structure
            List<Person> people = PersonFactory(10);
            foreach (var person in people)
            {
                Console.WriteLine("Person in people list: " + person.name);
            }
            Console.WriteLine("Amount of people inside people list: " + people.Count);

            Person testPerson = new Person { name = "Teo", age = 30, favoritefood = "Äggmackor" };
            people.Add(testPerson); // Comment this out if you wanna see the else statement being run.
            if (people.Contains(testPerson))
            {
                Console.WriteLine("People list contains Person - Name:  " + testPerson.name + ". Age: " + testPerson.age + ". Favorite Food: " + testPerson.favoritefood);
            }
            else
            {
                Console.WriteLine("Did not contain PersonPerson - Name:  " + testPerson.name + ". Age: " + testPerson.age + ". Favorite Food: " + testPerson.favoritefood);
            }


            //Implement a void Insert(int index, T item) function for the List structure
            Person testPerson2 = new Person { name = "Federich", age = 99, favoritefood = "Chicken Fingers" };
            if (people.Count >= 4)
            {
                people.Insert(3, testPerson2);
                Console.WriteLine("Testperson2 was added to people list at index 3. Person name: " + testPerson2.name);
            }


            //Implement a void Reverse() Function in the List<T> that internally uses a Stack<T> to do a Stack reversal of the elements.

            Console.WriteLine("Current order of people in list by name: ");
            foreach (var person in people)
            {
                Console.WriteLine(person.name);
            }

            Console.WriteLine();
            people.Reverse();

            Console.WriteLine("Current order of people in list by name after reverse: ");
            foreach (var person in people)
            {
                Console.WriteLine(person.name);
            }

        }

        public class Person
        {
            public string name;
            public int age;
            public string favoritefood;

        }

        public static List<Person> PersonFactory(int factoryAmount)
        {
            List<Person> people = new List<Person>();

            string[] namesArray = { "Teo", "Felix", "Erika", "Anna", "Sofia", "Mattias", "Rikard", "Jakob", "Ferri", "Jonatan", "Fredrik", "Matila" };
            Random rnd = new Random();

            int[] ageArray = { 30, 50, 24, 19, 22, 59, 30, 20, 27, 10, 25, 20 };

            string[] favFoodArray = { "Pizza", "Kebab", "Äggmackor", "Chicken Parma", "Candy", "Winegum" };

            for (int i = 0; i < factoryAmount; i++)
            {
                int rndAge = rnd.Next(0, ageArray.Length);
                int rndFavFood = rnd.Next(0, favFoodArray.Length);
                int randomNameIndex = rnd.Next(0, namesArray.Length);

                people.Add(new Person()
                {
                    name = namesArray[randomNameIndex],
                    age = ageArray[rndAge],
                    favoritefood = favFoodArray[rndFavFood]
                }); 
            }

            return people;
        }
    }
}
