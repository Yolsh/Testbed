using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace W112_Reading_Text_Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("MyText.txt"))
            {
                string line;
                while(!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (line != "")
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
