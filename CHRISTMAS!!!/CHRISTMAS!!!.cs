using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace CHRISTMAS___
{
    internal class Program
    {
        struct snowPoint
        {
            public string value;
            public int top;
            public int left;
        }
        static void Main(string[] args)
        {
            PlaceTree();
            Console.ForegroundColor = ConsoleColor.White;
            Snow();
            Console.ReadKey();
        }

        static void Disp(string Text)
        {
            Console.CursorLeft = (Console.WindowWidth - Text.Length) / 2;
            Console.WriteLine(Text);
        }

        static void PlaceTree()
        {
            int Height = Console.WindowHeight - 4;
            int[] layers = TriangularNums(Height);
            for (int i = 0; i < layers.Length; i++)
            {
                int width = Console.WindowWidth;
                layers[i] = layers[i] / (width/32);
            }
            foreach(int triangle in layers)
            {
                Console.Write($"{triangle} ");
            }
            for (int i = 0; i < Height; i++)
            {
                string Text = "";
                for (int j = 0; j < layers[i]; j++)
                {
                    Text += "*";
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Disp(Text);
            }
            for (int i = 0; i < 3; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Disp("***");
            }
        }

        static int[] TriangularNums(int height)
        {
            int[] triangles = new int[height];
            int k = 1; int j = 1;
            for (int i = 1; i <= height; i++)
            {
                triangles[i - 1] = k;
                j++;
                k += j;
            }
            return triangles;
        }

        static void Snow()
        {
            List<snowPoint> snow = new List<snowPoint>();
            Random rnd = new Random();
            while (true)
            {
                snowPoint NewSnow = new snowPoint();
                int RandSnow = rnd.Next(Console.WindowWidth);
                NewSnow.value = ".";
                NewSnow.top = 0;
                NewSnow.left = RandSnow;
                snow.Add(NewSnow);
                ShowSnow();
            }
        }

        static void ShowSnow(List<snowPoint> allSnow)
        {
            foreach (snowPoint currentSnow in allSnow)
            {

            }
        }
    }
}
