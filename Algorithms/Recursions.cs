using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Algorithms
{
    public class Recursions
    {
        public static void Main()
        {
            // Factorials
            // n! = n * (n - 1 ) *  (n - 2) * (n - 3) ... * 1

            // 1!


            CalculateFactorial_Recursive(5);

            int CalculateFactorial_Recursive(int i) // Adding calls to the call stack results in a minor performance penalty. Remember this when opting for either ease of coding, readability and performance.
            {
                Console.Write(i + " ,");
                return i > 0 ? i * CalculateFactorial_Recursive(i - 1) : 1; // Explore the calculations here more thoroughly.
            }
        }

        public int CalculateFactorial_Iterative(int i)
        {
            if (i > 0)
            {
                int iValue = i;
                i--;

                while (i > 0)
                {
                    iValue *= i;
                    i--;
                }
                return iValue;
            }
            return 0;
        }


    }
}
