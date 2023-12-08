using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
namespace L130_Sabotage
{
    class L130_Sabotage
    {

        static void Main(string[] args)
        {
            string chosenFilename;
            string toSearchFor;

            Console.Write("Enter filename (excl. file extension): ");
            chosenFilename = Console.ReadLine();

            Console.Write("Enter character to search for: ");
            toSearchFor = Console.ReadLine();

            if (toSearchFor.Length == 1)
            {
                int numOfOccurrences;
                numOfOccurrences = FileCharacterCount(chosenFilename, toSearchFor);
                Console.WriteLine($"The character '{toSearchFor}' appears {numOfOccurrences} times in '{chosenFilename}'");
            }
            else if (toSearchFor.Length > 1)
            {
                Console.WriteLine("Error. A single character must be searched for.");
            }

            Console.ReadKey();
        }

        static int LineCharacterCount(string line, string charToSearchFor)
        {
            string letter = "";
            int count = 0;

            for (int i = 0; i < line.Length; i++)
            {
                letter = line.Substring(i, 1);

                if (letter == charToSearchFor)
                {
                    count = 1;
                }

            }

            return count;
        }

        static int FileCharacterCount(string filename, string charToSearchFor)
        {
            int count = 0;
            string line = "";
            using (StreamReader reader = new StreamReader(filename))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    count += LineCharacterCount(line, charToSearchFor);
                }
                return count;
            }
        }

    }
}