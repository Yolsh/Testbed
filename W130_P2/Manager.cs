using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W130_P2
{
    public class Manager : Employee
    {
        private List<Employee> employees = new List<Employee>();

        public Manager(string fullname) : base(fullname, 30000)
        {

        }

        public bool AddEmployee(Employee inEmployee)
        {
            if (!employees.Contains(inEmployee))
            {
                employees.Add(inEmployee);
                return true;
            }
            return false;
        }

        public double GiveRaises(double rate)
        {
            this.GiveRaise(rate);
            double total = this.GetMonthlyPay();
            foreach (Employee employee in employees)
            {
                if (employee is Manager)
                {
                    Manager subManager = (Manager) employee;
                    total += subManager.GiveRaises(rate);
                }
                employee.GiveRaise(rate);
                total += employee.GetMonthlyPay();
            }
            return total;
        }
    }
}
