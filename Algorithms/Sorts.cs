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

            // Basic sort, no performance in mind
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
        }
    }
}
