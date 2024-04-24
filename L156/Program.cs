using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace L156
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {2, 19, 4, 88, 16, 14, 37, 90, 9, 9, 17, 15, 23 };
            TimingFunc(arr);
            PrintArray(arr);
            Console.ReadLine();
        }

        static void TimingFunc(int[] arr)
        {
            Timer timer = new Timer(10);
            BubbleSort(arr);
            PrintArray(arr);
        }

        static void BubbleSort(int[] arr)
        {
            bool swapped;
            int n = arr.Length;
            do
            {
                swapped = false;
                for (int i = 0; i < n - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int Temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = Temp;
                        swapped = true;
                    }
                }
                n--;
            } while (swapped && n > 1);
        }

        static void PrintArray(int[] arr)
        {
            foreach (int element in arr)
            {
                Console.Write($"{element}, ");
            }
            Console.WriteLine();
        }

        static bool LinearSearch(int[] arr, int searchable)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == searchable) return true;
            }
            return false;
        }
    }
}
