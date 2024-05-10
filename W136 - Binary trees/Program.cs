using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace W136___Binary_trees
{
    internal class Program
    {

        static TreeNode[] penguins;

        static void Main(string[] args)
        {
            penguins = new TreeNode[8];
            string[] data = { "Humbolt", "Adelie", "Emperor", "African", "Macaroni", "Snares", "Fairy", "King" };
            Fill(data);

            Console.WriteLine("Pre, In or Post?");
            string ans = Console.ReadLine();
            switch(ans)
            {
                case "Pre":
                    PreTrav();
                    break;
                case "In":
                    InTrav();
                    break;
                case "Post":
                    PostTrav();
                    break;
            }
            Console.ReadKey();
        }

        static void PreTrav(int index = 0)
        {
            Console.WriteLine(Data[index].data);
            if (Data[index].left != -1) PreTrav(Data[index].left);
            if (Data[index].right != -1) PreTrav(Data[index].right);
        }

        static void InTrav(int index = 0)
        {
            if (Data[index].left != -1) InTrav(Data[index].left);
            Console.WriteLine(Data[index].data);
            if (Data[index].right != -1) InTrav(Data[index].right);
        }

        static void PostTrav(int index = 0)
        {
            if (Data[index].left != -1) PostTrav(Data[index].left);
            if (Data[index].right != -1) PostTrav(Data[index].right);
            Console.WriteLine(Data[index].data);
        }

        static void Fill(string[] data)
        {
            foreach (string d in data)
            {
                while ()
            }
        }
    }
}
