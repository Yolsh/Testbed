using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W137___Dictionaries
{
    internal class Program
    {
        static Dictionary<string, int> scentence;

        static void Main(string[] args)
        {
            scentence = new Dictionary<string, int>();

            int wide = scentence.Keys.Max(x => x.Length);
            foreach (string word in scentence.Keys)
            {
                Console.WriteLine($"{word.PadRight(wide)} : {scentence[word]}");
            }
            Console.ReadLine();
        }

        static void LoadScript()
        {
            using (StreamReader sr = new StreamReader("BeeMovie.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split();

                    foreach (string word in line)
                    {
                        if (!scentence.ContainsKey(word))
                        {
                            scentence.Add(word, 1);
                            continue;
                        }
                        scentence[word]++;
                    }
                }
            }
        }
    }
}
