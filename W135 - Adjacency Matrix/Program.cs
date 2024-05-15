using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace W135___Adjacency_Matrix
{
    internal class Program
    {
        static List<string> Users;
        static int[,] Connections;

        static void Main(string[] args)
        {
            Users = new List<string>();
            Connections = new int[Users.Count(),Users.Count()];

            while (true)
            {
                ShowMenu();
            }
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Add a User");
            Console.WriteLine("2. Add a Friendship");
            Console.WriteLine("3. Are We Friends");
            Console.WriteLine("4. List mutual Friends");
            Console.WriteLine("5. Remove a Friendship");

            ConsoleKey choice = Console.ReadKey(true).Key;

            switch (choice)
            {
                case ConsoleKey.D1:
                    AddUser();
                    break;
                case ConsoleKey.D2:
                    MakeFriend();
                    break;
                case ConsoleKey.D3:
                    AreWeFriends();
                    break;
                case ConsoleKey.D4:
                    ListMutualFriends();
                    break;
                case ConsoleKey.D5:
                    RemoveFriends();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("That was not an option");
                    Console.ReadKey();
                    ShowMenu();
                    break;
            }
        }

        static void AddUser()
        {
            Console.Clear();
            Console.WriteLine("What is the new Users name?");
            string name = Console.ReadLine();

            if (Regex.IsMatch(name.Trim(), "^[!,.\\-*\"£$%^&()?\\/]*$"))
            {
                Console.Clear();
                Console.WriteLine("That is not a valid name");
                Console.ReadKey();
                return;
            }

            else if (!Users.Contains(name))
            {
                Users.Add(name);
                int[,] NewGrid = new int[Connections.GetLength(0) + 1, Connections.GetLength(1) + 1];

                for (int i = 0; i < Connections.GetLength(0); i++)
                {
                    for (int j = 0; j < Connections.GetLength(1); j++)
                    {
                        NewGrid[i, j] = Connections[i, j];
                    }
                }

                Connections = NewGrid;

                return;
            }
            Console.Clear();
            Console.WriteLine("That person already exists in MyBarton!");
            Console.ReadKey();
        }

        static void MakeFriend()
        {
            string User1 = "", User2 = "";
            try
            {
                if (!GetNames(ref User1, ref User2)) return;
            }
            catch (MyBartonException e)
            {
                Console.Clear();
                Console.WriteLine(e);
                Console.ReadKey();
                return;
            }

            if (Connections[Users.IndexOf(User1), Users.IndexOf(User2)] == 1)
            {
                Console.Clear();
                Console.WriteLine("That Person is already friends with you in the MyBarton network");
                Console.ReadKey();
                return;
            }

            Connections[Users.IndexOf(User1), Users.IndexOf(User2)] = 1;
            Connections[Users.IndexOf(User2), Users.IndexOf(User1)] = 1;

            Console.Clear();
            Console.WriteLine("Succesfully added new friend!");
            Console.ReadKey();
        }

        static void AreWeFriends()
        {
            string User1 = "", User2 = "";
            try
            {
                if (!GetNames(ref User1, ref User2)) return;
            }
            catch (MyBartonException e)
            {
                Console.Clear();
                Console.WriteLine(e);
                Console.ReadKey();
                return;
            }

            if (!(Users.Contains(User1) && Users.Contains(User2)))
            {
                Console.Clear();
                Console.WriteLine("That Person doesnt exist in the MyBarton network");
                Console.ReadKey();
                return;
            }

            else if (Connections[Users.IndexOf(User1), Users.IndexOf(User2)] == 1)
            {
                Console.Clear();
                Console.WriteLine("You are Friends!!");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("you are not currently friends with that person on MyBarton");
            Console.ReadKey();
        }

        static void ListMutualFriends()
        {
            string User1 = "", User2 = "";
            try
            {
                if (!GetNames(ref User1, ref User2)) return;
            }
            catch (MyBartonException e)
            {
                Console.Clear();
                Console.WriteLine(e);
                Console.ReadKey();
                return;
            }

            if (Connections[Users.IndexOf(User1), Users.IndexOf(User2)] == 0)
            {
                Console.Clear();
                Console.WriteLine("You are Not Friends");
                Console.ReadKey();
                return;
            }

            List<string> MutualFriends = new List<string>();

            for (int i = 0; i < Connections.GetLength(0); i++)
            {
                if (Connections[i, Users.IndexOf(User1)] == 1 && Connections[i, Users.IndexOf(User2)] == 1)
                {
                    MutualFriends.Add(Users[i]);
                }
            }

            if (MutualFriends.Count() == 0)
            {
                Console.Clear();
                Console.WriteLine("You have no Mutual Friends");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Your mutual Friends are:");
            foreach (string name in MutualFriends)
            {
                Console.WriteLine(name);
            }
            Console.ReadKey();
        }

        static void RemoveFriends()
        {
            string User1 = "", User2 = "";
            try
            {
                if (!GetNames(ref User1, ref User2)) return;
            }
            catch (MyBartonException e)
            {
                Console.Clear();
                Console.WriteLine(e);
                Console.ReadKey();
                return;
            }
            Console.Clear();
            if (Connections[Users.IndexOf(User1), Users.IndexOf(User2)] == 1)
            {
                Connections[Users.IndexOf(User1), Users.IndexOf(User2)] = 0;
                Connections[Users.IndexOf(User2), Users.IndexOf(User1)] = 0;
                Console.WriteLine("Sucessfully removed friendship");
            }

            else Console.WriteLine("you are not currently friends with that person.");
            Console.ReadKey();
        }

        static bool GetNames(ref string User1, ref string User2)
        {
            Console.Clear();
            Console.WriteLine("What is your Username?");
            User1 = Console.ReadLine();
            Console.WriteLine("What is your friends Username?");
            User2 = Console.ReadLine();

            if (User1 == User2) throw new MyBartonException("you cant be friends with yourself");

            else if (!(Users.Contains(User1) && Users.Contains(User2)))
            {
                Console.Clear();
                Console.WriteLine("That Person doesnt exist in the MyBarton network");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        static bool CheckDegrees(int n, string User1, string User2, int i = 0)
        {
            if (n == i) return false;
            for (int j = 0; j < Connections.GetLength(1); j++)
            {
                if (Users[Connections[Users.IndexOf(User1), j]] == User2)
                {
                    return true;
                }
            }
            if (CheckDegrees(n, User1, User2, i++)) return true;
            return false;
        }
    }
}
