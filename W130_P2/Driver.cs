using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W130_P2
{
    public class Driver : Employee
    {
        private List<string> LicensePlates;

        public Driver(List<string> inLicenses, string fullName, double startSalary) : base(fullName, startSalary)
        {

        }
    }
}
