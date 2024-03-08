using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W130_P2
{
    public class Employee
    {
        protected string forename, surname;
        protected double salary;
        protected Employee(string fullName, double startSalary)
        {
            string[] names = fullName.Split(' ');
            forename = names[0];
            surname = names[names.Length - 1];
            salary = startSalary;
        }
        public void GiveRaise(double rate)
        {
            salary *= 1 + rate / 100;
        }
        public string GetFullName()
        {
            return forename + " " + surname;
        }
        public double GetMonthlyPay()
        {
            return Math.Round(salary / 12, 2);
        }
    }
}
