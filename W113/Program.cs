using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO

namespace W113
{
    internal class Program
    {
        static void ConsoleLogs()
        {
            DateTime dt = new DateTime();
            using (StreamWriter Sw = new StreamWriter("ConsoleLogs.txt", true))
            {
                Sw.WriteLine();
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
