using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        public List<int[]> Body = new List<int[]>();
        public ConsoleKey direction;

        public Snake(int inX, int inY)
        {
            int[] NewSeg = new int[2];
            direction = ConsoleKey.UpArrow;
            NewSeg[0] = inX;
            NewSeg[1] = inY;
            Body.Add(NewSeg);
        }

        public void AddSegment()
        {
            int[] NewSeg = new int[2];
            NewSeg[0] = Body.Last()[0]+1;
            NewSeg[1] = Body.Last()[1];
            Body.Add(NewSeg);
        }

        public void MoveForward()
        {
            switch (direction)
            {
                case ConsoleKey.DownArrow:
                    Body[0][1]++;
                    break;
                case ConsoleKey.RightArrow:
                    Body[0][0]++;
                    break;
                case ConsoleKey.UpArrow:
                    Body[0][1]--;
                    break;
                case ConsoleKey.LeftArrow:
                    Body[0][0]--;
                    break;
            }
            for (int i = 1; i < Body.Count(); i++)
            {
                Body[i - 1] = Body[i];
            }
        }

        public bool IsDead()
        {
            foreach (int[] seg in Body)
            {
                if (Body[0][0] == seg[0] && Body[0][0] == seg[0] && seg != Body[0])
                {
                    return true;
                }
            }

            if (Body[0][0] == 0 || Body[0][0] == Console.WindowWidth-1 || Body[0][1] == 0 || Body[0][1] == Console.WindowHeight) return true;

            return false;
        }
    }
}
