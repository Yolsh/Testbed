//Skeleton Program for the CAP1 examination
//this code should be used in conjunction with the Preliminary Material
//developed in a Visual Studio Community programming environment

//Version Number 1.0

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    public struct ShipType
    {
        public string Name;
        public int Size;
    }

    const string TrainingGame = "Training.txt";
    const int ShipNumber = 7;
    const int BoardSizeX = 10;
    const int BoardSizeY = 10;

    private static void GetRowColumn(ref int Row, ref int Column)
    {
        do
        {
            Console.Write("Please enter column: ");
            string ColumnStr = Console.ReadLine();
            if (Regex.Match(ColumnStr, $"[0-{BoardSizeY - 1}]").Success) Column = Convert.ToInt32(ColumnStr);
            else if (Regex.Match(ColumnStr, "[^\\d]").Success) Console.WriteLine("You're input must be a number");
            else Console.WriteLine($"not a valid input [0-{BoardSizeY}]");
        } while (Column <= 0 && Column >= 9);

        do
        {
            Console.Write("Please enter row: ");
            string RowStr = Console.ReadLine();
            if (Regex.Match(RowStr, $"[0-{BoardSizeX - 1}]").Success) Column = Convert.ToInt32(RowStr);
            else if (Regex.Match(RowStr, "[^\\d]").Success) Console.WriteLine("You're input must be a number");
            else Console.WriteLine($"not a valid input [0-{BoardSizeX}]");
        } while (Row >= 0 && Row <= 9);
        Console.WriteLine();
    }

    private static int MakePlayerMove(ref char[,] Board, ref ShipType[] Ships)
    {
        int Row = 0;
        int Column = 0;
        int Move = 0;
        GetRowColumn(ref Row, ref Column);
        if (Board[Row, Column] == 'm' || Board[Row, Column] == 'h')
        {
            Console.WriteLine("Sorry, you have already shot at the square (" + Column + "," + Row + "). Please try again.");
        }
        else if (Board[Row, Column] == '-')
        {
            Console.WriteLine("Sorry, (" + Column + "," + Row + ") is a miss.");
            Board[Row, Column] = 'm';
            Move = 1;
        }
        else
        {
            Console.WriteLine("Hit at (" + Column + "," + Row + ").");
            Board[Row, Column] = 'h';
            Move = 1;
        }
        return Move;
    }

    private static void SetUpBoard(ref char[,] Board)
    {
        for (int Row = 0; Row < BoardSizeY; Row++)
        {
            for (int Column = 0; Column < BoardSizeX; Column++)
            {
                Board[Row, Column] = '-';
            }
        }
    }

    private static void LoadGame(string TrainingGame, ref char[,] Board)
    {
        string Line = "";
        using (StreamReader BoardFile = new StreamReader(TrainingGame))
        {
            for (int Row = 0; Row < 10; Row++)
            {
                Line = BoardFile.ReadLine();
                for (int Column = 0; Column < 10; Column++)
                {
                    Board[Row, Column] = Line[Column];
                }
            }
        }
    }

    private static void PlaceRandomShips(ref char[,] Board, ShipType[] Ships)
    {
        Random RandomNumber = new Random();
        bool Valid;
        char Orientation = ' ';
        int Row = 0;
        int Column = 0;
        int HorV = 0;
        int ShipArrPointer = 0;
        for (int i = 0; i < ShipNumber; i++)
        {
            Valid = false;
            if (ShipArrPointer > 4) ShipArrPointer = 0;
            while (Valid == false)
            {
                Row = RandomNumber.Next(0, 10);
                Column = RandomNumber.Next(0, 10);
                HorV = RandomNumber.Next(0, 2);
                if (HorV == 0)
                {
                    Orientation = 'v';
                }
                else
                {
                    Orientation = 'h';
                }
                Valid = ValidateBoatPosition(Board, Ships[ShipArrPointer], Row, Column, Orientation);
            }
            Console.WriteLine($"Computer placing the {Ships[ShipArrPointer].Name} which is {Ships[ShipArrPointer].Size} long");
            PlaceShip(ref Board, Ships[ShipArrPointer], Row, Column, Orientation);
            ShipArrPointer++;
        }
    }

    private static void PlaceShip(ref char[,] Board, ShipType Ship, int Row, int Column, char Orientation)
    {
        if (Orientation == 'v')
        {
            for (int Scan = 0; Scan < Ship.Size; Scan++)
            {
                Board[Row + Scan, Column] = Ship.Name[0];
            }
        }
        else if (Orientation == 'h')
        {
            for (int Scan = 0; Scan < Ship.Size; Scan++)
            {
                Board[Row, Column + Scan] = Ship.Name[0];
            }
        }
    }

    private static bool ValidateBoatPosition(char[,] Board, ShipType Ship, int Row, int Column, char Orientation)
    {
        if (Orientation == 'v' && Row + Ship.Size > 10)
        {
            return false;
        }
        else if (Orientation == 'h' && Column + Ship.Size > 10)
        {
            return false;
        }
        else
        {
            if (Orientation == 'v')
            {
                for (int Scan = 0; Scan < Ship.Size; Scan++)
                {
                    if (Board[Row + Scan, Column] != '-')
                    {
                        return false;
                    }
                }
            }
            else if (Orientation == 'h')
            {
                for (int Scan = 0; Scan < Ship.Size; Scan++)
                {
                    if (Board[Row, Column + Scan] != '-')
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    private static bool CheckWin(char[,] Board)
    {
        for (int Row = 0; Row < 10; Row++)
        {
            for (int Column = 0; Column < 10; Column++)
            {
                if (Board[Row, Column] == 'A' || Board[Row, Column] == 'B' || Board[Row, Column] == 'S' || Board[Row, Column] == 'D' || Board[Row, Column] == 'P')
                {
                    return false;
                }
            }
        }
        return true;
    }

    private static void PrintBoard(char[,] Board)
    {
        Console.WriteLine();
        Console.WriteLine("The board looks like this: ");
        Console.WriteLine();
        Console.Write(" ");
        for (int Column = 0; Column < 10; Column++)
        {
            Console.Write(" " + Column + "  ");
        }
        Console.WriteLine();
        for (int Row = 0; Row < 10; Row++)
        {
            Console.Write(Row + " ");
            for (int Column = 0; Column < 10; Column++)
            {
                if (Board[Row, Column] == '-')
                {
                    Console.Write(" ");
                }
                else if (Board[Row, Column] == 'A' || Board[Row, Column] == 'B' || Board[Row, Column] == 'S' || Board[Row, Column] == 'D' || Board[Row, Column] == 'P')
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(Board[Row, Column]);
                }
                if (Column != 9)
                {
                    Console.Write(" | ");
                }
            }
            Console.WriteLine();
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("MAIN MENU");
        Console.WriteLine("Welcome to Warships");
        Console.WriteLine("1. Start new game");
        Console.WriteLine("2. Load training game");
        Console.WriteLine("9. Quit");
        Console.WriteLine();
    }

    private static int GetMainMenuChoice()
    {
        int Choice = 0;
        do
        {
            Console.Write("Please enter your choice: ");
            string ChoiceStr = Console.ReadLine();
            if (Regex.Match(ChoiceStr, "[129]").Success) Choice = Convert.ToInt32(ChoiceStr);
            else if (Regex.Match(ChoiceStr, "[^\\d]").Success) Console.WriteLine("You're input must be a number");
            else Console.WriteLine("Not a valid input. Try again");
        } while (Choice != 1 && Choice != 2 && Choice != 9);
        return Choice;
    }

    private static void PlayGame(ref char[,] Board, ref ShipType[] Ships, string Username)
    {
        bool GameWon = false;
        int MovesDone = 0;
        while (GameWon == false)
        {
            PrintBoard(Board);
            Console.WriteLine($"You have had {MovesDone} Moves");
            MovesDone += MakePlayerMove(ref Board, ref Ships);
            GameWon = CheckWin(Board);
            if (GameWon == true)
            {
                Console.WriteLine("All ships sunk!");
                Console.WriteLine($"Well Done {Username} you got a Score of {MovesDone}");
            }
        }
    }

    private static void SetUpShips(ref ShipType[] Ships)
    {
        Ships[0].Name = "Aircraft Carrier";
        Ships[0].Size = 5;
        Ships[1].Name = "Battleship";
        Ships[1].Size = 4;
        Ships[2].Name = "Submarine";
        Ships[2].Size = 3;
        Ships[3].Name = "Destroyer";
        Ships[3].Size = 3;
        Ships[4].Name = "Patrol Boat";
        Ships[4].Size = 2;
    }

    private static string Username()
    {
        Console.WriteLine("what is you name?");
        return Console.ReadLine();
    }

    static void Main(string[] args)
    {
        ShipType[] Ships = new ShipType[5];
        char[,] Board = new char[10, 10];
        int MenuOption = 0;
        while (MenuOption != 9)
        {
            SetUpBoard(ref Board);
            SetUpShips(ref Ships);
            DisplayMenu();
            MenuOption = GetMainMenuChoice();
            if (MenuOption == 1)
            {
                PlaceRandomShips(ref Board, Ships);
                PlayGame(ref Board, ref Ships, Username());
            }
            if (MenuOption == 2)
            {
                LoadGame(TrainingGame, ref Board);
                PlayGame(ref Board, ref Ships, Username());
            }
        }
    }

    private static void sonar(int Row, int Column, char[,] Board)
    {
        char[] Notships = { 'h', 'm', '-' };
        int curRow = Row;
        int curColumn = Column;
        while (Notships.Contains(Board[curRow, curColumn]))
        {
            for (int i = 0; i < 9; i++)
            {
                if ()
            }
        }
    }
}
