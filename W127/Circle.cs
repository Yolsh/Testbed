using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W127
{
    internal class Circle
    {
        private double radius;
        public double getArea()
        {
            return Math.PI * radius * radius;
        }

        public double getCircumference()
        {
            return Math.PI * 2 * radius;
        }

        public void setRadius(double value)
        {
            radius = value;
        }

        public double getRadius()
        {
            return radius;
        }
    }
}
