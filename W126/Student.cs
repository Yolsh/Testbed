using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W126
{
    public class Student
    {
        public string name;
        public int age;

        public void GetInfoFromUser()
        {
            Console.WriteLine("What is Your Name?");
            name = Console.ReadLine();
            Console.WriteLine("What is your Age?");
            age = int.Parse(Console.ReadLine());
        }
    }
}
