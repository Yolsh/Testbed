using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.Remoting.Messaging;

namespace W133___Recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sortable = {7, 5, 8, 9, 6, 7, 0, 1, 6 };
            Func<int[], int[]> MergeSort = null;
            MergeSort = arr =>
            {
                if (arr.Length == 1) return arr;
                int[] newArr = new int[arr.Length];
                int[] b1 = MergeSort(arr.Take(arr.Length / 2).ToArray());
                int[] b2 = MergeSort(arr.Skip(arr.Length / 2).Take(arr.Length / 2).ToArray());
                for (int i = 0; i < b1.Length; i+=2)
                {
                    if (b1[i] > b2[i])
                    {
                        newArr[i] = b2[i];
                        newArr[i + 1] = b1[i];
                    }
                    else
                    {
                        newArr[i] = b1[i];
                        newArr[i+1] = b2[i];
                    }
                }

                foreach (int val in newArr)
                {
                    Console.Write($"{val}, ");
                }

                Console.WriteLine();
                return newArr;
            };
            
            MergeSort(sortable);

            foreach (int val in sortable)
            {
                Console.WriteLine(val);
            }

            Console.ReadKey();
        }

        static int Fib(int n) => n == 0 ? 0 : n == 1 ? 1 : (Fib(n - 1) + Fib(n - 2));
        static int SumAll(int n) => n == 0 ? 0 : n + SumAll(n - 1);
        static int SumAllOdd(int n) => n == 0 ? 0 : n % 2 == 0 ? SumAllOdd(n - 1) : n + SumAllOdd(n - 1);
        static int AllVowels(string x) => x.Length == 0 ? 0 : Regex.Match(x, "^[AEIOUaeiou]").Success ? 1 + AllVowels(x.Substring(1)) : 0 + AllVowels(x.Substring(1));
        static int BunnyEars(int n) => n == 0 ? 0 : n == 1 ? 2 : n % 2 == 0 ? 3 + BunnyEars(n - 1) : 2 + BunnyEars(n - 1);
        static int TriangleBlocks(int row) => row == 0 ? 1 : 2 + TriangleBlocks(row - 1);
        static int Eights(int n) => n < 10 ? n == 8 ? 1 : 0 : n % 10 == 8 ? (n / 10) % 100 == 8 ? 2 + Eights(n / 10) : 1 + Eights(n / 10) : 0 + Eights(n / 10);
    }
}
