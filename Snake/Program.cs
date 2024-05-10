using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake
{
    internal class Program
    {
        struct Apple
        {
            public int x;
            public int y;
        }

        static Random rand = new Random();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Snake Bob = new Snake(Console.WindowWidth / 2, Console.WindowHeight / 2);

            Apple apple = NextApple();

            while (true)
            {
                while (!Console.KeyAvailable)
                {
                    if (Bob.IsDead()) break;
                    if (Bob.Body[0][0] == apple.x && Bob.Body[0][1] == apple.y)
                    {
                        Bob.AddSegment();
                        apple = NextApple();
                    }
                    Bob.MoveForward();
                    Draw(Bob, apple);
                    Thread.Sleep(20);
                    Console.Clear();
                }
                if (Bob.IsDead()) break;
                Bob.direction = Console.ReadKey(true).Key;
            }
            Console.Clear();
            Console.WriteLine("You Died");
            Console.ReadKey();
        }

        static void Draw(Snake Bob, Apple apple)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (int[] seg in Bob.Body)
            {
                Console.SetCursorPosition(seg[0], seg[1]);
                Console.Write(Bob.Body.Count());
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(apple.x, apple.y);
            Console.Write('\u2588');
        }

        static Apple NextApple()
        {
            Apple apple = new Apple();
            apple.x = rand.Next(Console.WindowWidth-1);
            apple.y = rand.Next(Console.WindowHeight);
            return apple;
        }
    }
}
