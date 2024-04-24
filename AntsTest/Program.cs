using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Logic_Tester
{
    internal class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            List<Ant> ants = new List<Ant>();
            string[,] board = new string[Console.WindowWidth, Console.WindowHeight - 1];
            Initialise(ants, board);
            while (1 == 1)
            {
                Update(ants, board);
                Draw(board);
                Thread.Sleep(10);
            }
        }

        static void Draw(string[,] board)
        {
            Console.Clear();
            for (int y = 0; y < board.GetLength(0); y++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    Console.SetCursorPosition(y, x);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine(board[y, x]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    board[y, x] = "";
                }
            }
        }

        static void Initialise(List<Ant> ants, string[,] board)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < 20; i++)
            {
                int[] home = new int[2];
                home[0] = rand.Next(Console.WindowWidth);
                home[1] = rand.Next(Console.WindowHeight - 1);
                Ant ant = new Ant(home, rand, board);
                ants.Add(ant);
            }
        }

        static void Update(List<Ant>ants, string[,] board)
        {
            for (int i = 0; i < ants.Count(); i++)
            {
                try
                {
                    board[ants[i].position[0], ants[i].position[1]] = " ";
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"{i}: y:{board.GetLength(1)} - {ants[i].position[1]}, x:{board.GetLength(0)} - {ants[i].position[0]}");
                }
            }

            for (int i = 0; i < ants.Count(); i++)
            {
                ants[i].Move();
            }
        }
    }
}
