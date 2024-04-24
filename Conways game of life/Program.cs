using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conways_game_of_life
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] Board = new int[Console.WindowHeight - 1, Console.WindowWidth / 2 - 1];

            DispBoard(Board);
            Board = CalcBoard(Board);
            Console.ReadKey();
            Console.Clear();
            DispBoard(Board);
            Console.ReadKey();
        }

        static void DispBoard(int[,] Board)
        {
            for (int y = 0; y < Board.GetLength(0); y++)
            {
                for (int x = 0; x < Board.GetLength(1); x++)
                {
                    Console.Write(Board[y, x] == 1 ? "\u2588\u2588" : "  ");
                }
                Console.WriteLine();
            }
        }

        static int[,] CalcBoard(int[,] Board)
        {
            int[,] NextBoard = new int[Board.GetLength(0), Board.GetLength(1)];

            int[,] adjacents =
            {
                { 0, -1 },
                { 1, 0 },
                { 0, 1 },
                { -1, 0 }
            };

            for (int y = 0; y < Board.GetLength(0); y++)
            {
                for (int x = 0; x < Board.GetLength(1); x++)
                {
                    int neighbors = 0;
                    for(int i = 0; i < adjacents.GetLength(0); i++)
                    {
                        if (
                            Board[y + adjacents[i, 1] > Board.GetLength(0)-1 ? 
                            0 : y + adjacents[i, 1] < 0 ? 
                            Board.GetLength(0)-1 : y + adjacents[i, 1], 
                            x + adjacents[i, 0] > Board.GetLength(1)-1 ? 
                            0 : x + adjacents[i, 0] < 0 ? 
                            Board.GetLength(1)-1 : x + adjacents[i, 0]] == 1
                            ) neighbors++;
                    }

                    if (neighbors < 2 || neighbors > 3) NextBoard[y, x] = 0;
                    else if (neighbors == 3) NextBoard[y, x] = 1;
                }
            }

            return NextBoard;
        }
    }
}
