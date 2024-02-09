using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W126
{
    public class Course
    {
        public string subject;
        public List<string> register;

        public void EnrolStudent(Student Stu)
        {
            register.Add(Stu.name);
        }

        public void DisplayRegister()
        {
            Console.WriteLine(subject);
            foreach (string student in register)
            {
                Console.WriteLine(student);
            }
        }
    }
}
