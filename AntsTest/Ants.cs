using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic_Tester
{
    public class Ant
    {
        private Random rand;
        //position[0] is y axis
        //position[1] is x axis
        public int[] position { get; private set; }
        public int direction { get; private set; }
        private int limitX;
        private int limitY;

        public Ant(int[] HomeLocation, Random inRand, string[,] board)
        {
            rand = inRand;
            limitX = board.GetLength(1);
            limitY = board.GetLength(0);
            position = new int[2];
            position[0] = HomeLocation[0];
            position[1] = HomeLocation[1];
            direction = rand.Next(4);
        }

        public void Move()
        {
            // direction 0 means facing up
            // direction 1 means facing right
            // direction 2 means facing down
            // direction 3 means facing left

            switch(direction)
            {
                case 0: 
                    if (position[1]-- >= 0)
                    {
                        position[1]--;
                    }
                    break;
                case 1: 
                    if (position[0]++ <= limitY)
                    {
                        position[0]++;
                    }
                    break;
                case 2: 
                    if (position[1]++ <= limitX)
                    {
                        position[1]++;
                    }
                    break;
                case 3:
                    if (position[0]-- >= 0)
                    {
                        position[0]--;
                    }
                    break;
            }
        }
    }
}
