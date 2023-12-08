using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_comparison
{
    internal class Code_comparison
    {
        static void banana3(string word)
        {
            int length, aCount;
            aCount = 0;

            length = word.Length;

            for (int i = 0; i < length; i++)
            {
                if (word[i] == 'a')
                {
                    aCount++;
                }
            }

            Console.Write("Method 3: ");
            Console.WriteLine("Number of 'a's in " + word + " is " + aCount);
        }


        static void banana2(string word)
        {
            int length, aCount, nextAPos;
            string tempWord = word;

            aCount = 0;
            // Calculate the length of the word
            length = tempWord.Length;

            // Find the position of the next a character in the word
            nextAPos = tempWord.IndexOf("a");

            // If this is 0, there were no a's, so skip the loop

            while (nextAPos != -1)
            {
                // We found another a. Increment the counter
                aCount += 1;

                // Chop off everything up to and including the a we just found
                tempWord = tempWord.Substring(nextAPos + 1, length - nextAPos - 1);

                // Calculate the next length
                length = tempWord.Length;

                // Look for another a in the rest of the word
                nextAPos = tempWord.IndexOf("a");
            }

            // Print the number of a's found to the console
            Console.Write("Method 2: ");
            Console.WriteLine("Number of 'a's in " + word + " is " + aCount);
        }

        static void banana4(string word)
        {
            int l, anum;
            string t;
            string a = "a";
            anum = 0;
            l = word.Length;
            for (int i = 0; i <= l - 1; i++)
            {
                t = word.Substring(0, i + 1);
                t = t.Substring(t.Length - 1, 1);
                if (t == a) anum++;
            }
            Console.Write("Method 4: ");
            Console.WriteLine("Number of 'a's in " + word + " is " + anum);
        }

        static void banana1(string word)
        {
            int length, aCount, counter;
            aCount = 0;
            counter = 0;
            length = word.Length;

            for (int i = 0; i < length; i++)
            {
                if (word.Substring(counter, 1) == "a")
                {
                    aCount += 1;
                }
                counter += 1;
            }

            Console.Write("Method 1: ");
            Console.WriteLine("Number of 'a's in " + word + " is " + aCount);
        }

        static void Main(string[] args)
        {
            banana4("banana");
            Console.ReadKey();
        }
    }
}
