using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check_check
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(banana5("banana"));
            Console.ReadLine();
        }

        static int banana5(string word)
        {
            if (word.Length == 0)
            {
                return 0;
            }
            else
            {
                if (word[0] == 'a')
                {
                    return 1 + banana5(word.Substring(1));
                }
                else
                {
                    return banana5(word.Substring(1));
                }
            }
        }

    }
}
