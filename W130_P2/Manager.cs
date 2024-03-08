using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W130_P2
{
    public class Manager : Employee
    {
        List<Driver> drivers;

        public Manager(List<Driver> inDrivers, string fullname, double startSalary) : base(fullname, startSalary)
        {

        }

        public void AddEmployee(Driver inDriver)
        {
            drivers.Add(inDriver);
        }
    }
}
