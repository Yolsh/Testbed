using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W128
{
    internal class Cuboid
    {
        private int height, width, length;

        public Cuboid(int inHeight, int inWidth, int inLength)
        {
            height = inHeight;
            width = inWidth;
            length = inLength;
        }

        public int getHeight()
        {
            return height;
        }

        public int getWidth()
        {
            return width;
        }

        public int getLength()
        {
            return length;
        }

        public int calculateVolume()
        {
            return height * width * length;
        }

        public int calculateSurfaceArea() 
        {
            return (height * width * 2) + (width * length * 2) + (length * height * 2);
        }
    }
}
