using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures_1
{
    internal class Program
    {
        struct Person
        {
            public string Title;
            public string Forename;
            public string Surname;
            public int Age;
            public string FavouriteColour;
        }

        static void DisplayPerson(Person pers)
        {
            Console.WriteLine("" + );
            Console.WriteLine("" + );
            Console.WriteLine("" + );
            Console.WriteLine("" + );
            Console.WriteLine("" + );

        }

        static void Main(string[] args)
        {
            Person Myself;
            Myself.Title = "Mr"; Myself.Forename = "Josh"; Myself.Surname = "Appleby-Smith"; Myself.Age = 16; Myself.FavouriteColour = "green";
            DisplayPerson(Myself);
            Console.ReadKey();

        }
    }
}
