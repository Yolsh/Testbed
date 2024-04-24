using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 9, 8, 7, 6, 5, 4 };
            Sort(arr);
            foreach(int element in arr)
            {
                Console.WriteLine($"{element}, ");
            }
            Console.ReadKey();
        }

        static void Sort(int[] arr)
        {
            int temp, i = 0;
            while (!isSorted(arr))
            {
                if (i == arr.Length - 1) i = 0;
                if (arr[i] > arr[i + 1])
                {
                    temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                }
                i++;
            }
        }

        static bool isSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i ++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
