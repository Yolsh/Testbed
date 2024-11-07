using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W141___Error_Detection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> tests = new Dictionary<string, string>();

            tests.Add("111000000111", "1001");
            tests.Add("010110111000110101111001", "01101110");

            foreach (string key in tests.Keys)
            {
                if (CorrectMajority(key) == tests[key]) Console.WriteLine("Pass");
                else Console.WriteLine("Fail");
            }

            Console.ReadKey();

            Console.WriteLine("Majority or parity? [m/p]");
            string ans = Console.ReadLine();
            if (ans == "m")
            {
                Console.WriteLine("would you like to create a majority string or correct one? [cr/co]");
                ans = Console.ReadLine();
                if (ans == "cr") Console.WriteLine(CreateMajority(Console.ReadLine()));
                else Console.WriteLine(CorrectMajority(Console.ReadLine()));
            }
            else
            {
                Console.WriteLine("would you like to create a majority string or correct one? [cr/co]");
                ans = Console.ReadLine();
            }
        }

        static string CreateMajority(string start) => start.Aggregate("", (m, c) => m + new string(c, 3));
        static string CorrectMajority(string message) => Enumerable.Range(0, message.Length/3)
                                                            .Aggregate("", (t, i) => t + (message
                                                                                        .Substring(i*3, 3)
                                                                                        .Count(x => x == '1') >= 2 ? "1":"0"));
    }
}
