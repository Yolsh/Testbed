using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W126
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student Stu1 = new Student();
            Student Stu2 = new Student();
            Course CompSci = new Course();
            Stu1.GetInfoFromUser();
            Stu2.GetInfoFromUser();
            CompSci.subject = "Computer Science";


        }
    }
}
