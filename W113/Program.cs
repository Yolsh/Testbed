using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace W113
{
    internal class Program
    {
        static string ConsoleLogger(string ToLog, bool ReadLine)
        {
            DateTime dt = new DateTime();
            string output = "";
            if (!ReadLine)
            {
                Console.WriteLine(ToLog);
            }
            else
            {
                output = Console.ReadLine();
                ToLog = output;
            }
            using (StreamWriter Sw = new StreamWriter("cLog.txt", true))
            {
                Sw.WriteLine($"{dt} - {ToLog}");
            }
            return output;
        }

        static void Main(string[] args)
        {
            ConsoleLogger("hello", false);
            string output = ConsoleLogger("", true);
            ConsoleLogger($"echo: {output}", false);
            Console.ReadKey();
        }
    }
}
