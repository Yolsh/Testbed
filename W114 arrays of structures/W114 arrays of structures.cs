using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W114_arrays_of_structures
{
    internal class Program
    {
        struct coordinates
        {
            public int x;
            public int y;
        }
        struct Player
        {
            public coordinates Coordinates;
            public char Symbol;
            public ConsoleColor Colour;
        }
        static void Main(string[] args)
        {
            DrawPlayers(GetPlayers());
            Console.ReadKey();
        }

        static Random rand = new Random();

        static void DrawPlayers(Player[] players)
        {
            foreach (Player player in players)
            {
                Console.SetCursorPosition(player.Coordinates.x, player.Coordinates.y);
                Console.BackgroundColor = player.Colour;
                Console.Write(player.Symbol);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        static Player[] GetPlayers()
        {
            Console.WriteLine("How many Players do you want?");
            int PlayerNum = int.Parse(Console.ReadLine());
            Player[] players = new Player[PlayerNum];
            for (int i = 0; i < PlayerNum; i++)
            {
                players[i] = new Player();
                Console.WriteLine("Player Symbol?");
                players[i].Symbol = (char)Console.ReadKey().Key;
                Console.WriteLine("What colour should they be?[red/blue/green/pink]");
                players[i].Colour =(ConsoleColor) Enum.Parse(typeof(ConsoleColor), Console.ReadLine(), true);
                players[i].Coordinates.x = rand.Next(1, 44);
                players[i].Coordinates.y = rand.Next(1, 44);
                Console.Clear();
            }
            return players;
        }
    }
}
