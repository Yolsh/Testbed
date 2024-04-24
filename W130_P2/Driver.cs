using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W130_P2
{
    public class Driver : Employee
    {
        private List<string> LicensePlates = new List<string>();

        public Driver(string fullName) : base(fullName, 21500)
        {

        }

        public bool AddNewCar(string inLicensePlate)
        {
            if (!LicensePlates.Contains(inLicensePlate))
            {
                LicensePlates.Add(inLicensePlate);
                return true;
            }
            return false;
        }
    }
}
