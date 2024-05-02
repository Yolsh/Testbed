using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace W135___Adjacency_Lists
{
    internal class Program
    {
        static List<string> Users;
        static List<List<int>> Connections;

        static void Main(string[] args)
        {
            Users = new List<string>();
            Connections = new List<List<int>>();

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
                    //RemoveFriends();
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
                Connections.Add(new List<int>());
                return;
            }
            Console.Clear();
            Console.WriteLine("That person already exists in MyBarton!");
            Console.ReadKey();
        }

        static void MakeFriend()
        {
            string User1 = "",User2 = "";
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

            if (Connections[Users.IndexOf(User1)].Contains(Users.IndexOf(User2)))
            {
                Console.Clear();
                Console.WriteLine("That Person is already friends with you in the MyBarton network");
                Console.ReadKey();
                return;
            }

            Connections[Users.IndexOf(User1)].Add(Users.IndexOf(User2));
            Connections[Users.IndexOf(User2)].Add(Users.IndexOf(User1));

            Console.Clear();
            Console.WriteLine("Succesfully added new friend!");
            Console.ReadKey();
        }

        static void AreWeFriends()
        {
            string User1 = "",User2 = "";
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

            else if (Connections[Users.IndexOf(User1)].Contains(Users.IndexOf(User2)))
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

            if (Connections[Users.IndexOf(User1)].Contains(Users.IndexOf(User2)))
            {
                Console.Clear();
                Console.WriteLine("You are Not Friends");
                Console.ReadKey();
                return;
            }

            List<string> MutualFriends = new List<string>();

            foreach (int con in Connections[Users.IndexOf(User1)])
            {
                if (Connections[Users.IndexOf(User2)].Contains(con))
                {
                    MutualFriends.Add(Users[con]);
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
    }
}
