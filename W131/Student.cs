using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W131
{
    public class Student : Human
    {
        private string faveSubject;

        public Student(string inName, string inSubject) : base(inName)
        {
            faveSubject = inSubject;
        }

        public override void Talk()
        {
            base.Talk();
            Console.WriteLine($"And my favourite subject is {faveSubject}");
        }
    }
}
