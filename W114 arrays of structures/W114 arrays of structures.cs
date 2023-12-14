using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        static Random rand = new Random();

        static void Main(string[] args)
        {
            Player[] players = GetPlayers();
            while (true)
            {
                PlayerMove(players);
            }
        }

        static void PlayerMove(Player[] players)
        {
            ConsoleKey input = Console.ReadKey().Key;
            int selector = 0;

            switch (input)
            {
                case ConsoleKey.UpArrow: players[selector].Coordinates.y--; break;
                case ConsoleKey.DownArrow: players[selector].Coordinates.y++; break;
                case ConsoleKey.LeftArrow: players[selector].Coordinates.x--; break;
                case ConsoleKey.RightArrow: players[selector].Coordinates.x++; break;
                case ConsoleKey.D1: if (players.Length > 1) selector = 0; break;
                case ConsoleKey.D2: if (players.Length > 2) selector = 1; break;
                case ConsoleKey.D3: if (players.Length > 3) selector = 2; break;
                case ConsoleKey.D4: if (players.Length > 4) selector = 3; break;
                case ConsoleKey.D5: if (players.Length > 5) selector = 4; break;
                case ConsoleKey.D6: if (players.Length > 6) selector = 5; break;
                case ConsoleKey.D7: if (players.Length > 7) selector = 6; break;
                case ConsoleKey.D8: if (players.Length > 8) selector = 7; break;
                case ConsoleKey.D9: if (players.Length > 9) selector = 8; break;
                default: break;
            }
            DrawPlayers(players);
        }

        static void DrawPlayers(Player[] players)
        {
            Console.Clear();
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
            }
            return players;
        }
    }
}
