using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolfram_s_Automata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Pick a Number?");
                int key = int.Parse(Console.ReadLine());
                CreateField(key);
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }

        static void CreateField(int key)
        {
            List<int[]> stages = new List<int[]>();
            int[] stage = new int[Console.WindowWidth / 2 - 1];
            stage[stage.Length / 2] = 1;

            stages.Add(stage);

            for (int i = 0; i < Console.WindowHeight - 2; i++)
            {
                stages.Add(Wolframs(key, stages[i]));
            }

            DispResult(stages);
        }

        static void DispResult(List<int[]> stages)
        {
            foreach (int[] stage in stages)
            {
                foreach (int point in stage)
                {
                    Console.Write(point == 1 ? "\u2588\u2588" : "  ");
                }
                Console.WriteLine();
            }
        }

        static int[] Wolframs(int num, int[] stage)
        {
            string BinConv(int n, string w = "")
            {
                if (n != 0)
                {
                    return BinConv(n / 2, w) + n % 2;
                }
                return "";
            }
            string Key = BinConv(num);
            int[] nextStage = new int[stage.Length];

            if (Key.Length < 8)
            {
                string temp = "";
                for (int i = 0; i < 8 - Key.Length; i++) temp += "0";
                Key = temp + Key;
            }

            for (int i = 0; i < stage.Length; i++)
            {
                string temp = stage[i-1 > 0 ? i-1 : stage.Length-1].ToString() + stage[i].ToString() + stage[i+1 < stage.Length-1 ? i+1 : 0].ToString();

                switch (temp)
                {
                    case "000":
                        nextStage[i] = (int)(Key[7] - '0');
                        break;
                    case "001":
                        nextStage[i] = (int)(Key[6] - '0');
                        break;
                    case "010":
                        nextStage[i] = (int)(Key[5] - '0');
                        break;
                    case "011":
                        nextStage[i] = (int)(Key[4] - '0');
                        break;
                    case "100":
                        nextStage[i] = (int)(Key[3] - '0');
                        break;
                    case "101":
                        nextStage[i] = (int)(Key[2] - '0');
                        break;
                    case "110":
                        nextStage[i] = (int)(Key[1] - '0');
                        break;
                    case "111":
                        nextStage[i] = (int)(Key[0] - '0');
                        break;
                }
            }

            return nextStage;
        }
    }
}
