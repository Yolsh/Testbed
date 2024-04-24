using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Stack_RPN_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("input an RPN string");
            UnitTest();
        }

        static double EvalSafe(string RPN)
        {
            try
            {
                return Evaluate(RPN);
            }
            catch (InvalidProgramException e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        static double Evaluate(string RPN)
        {
            string[] RPNarr = RPN.Split(' ');
            Stack<double> RPNEvalStack = new Stack<double>();
            double temp;
            foreach (string op in RPNarr)
            {
                switch (op)
                {
                    case "/":
                        temp = RPNEvalStack.Pop();
                        RPNEvalStack.Push(RPNEvalStack.Pop() / temp);
                        break;
                    case "*":
                        temp = RPNEvalStack.Pop();
                        RPNEvalStack.Push(RPNEvalStack.Pop() * temp);
                        break;
                    case "+":
                        temp = RPNEvalStack.Pop();
                        RPNEvalStack.Push(RPNEvalStack.Pop() + temp);
                        break;
                    case "-":
                        temp = RPNEvalStack.Pop();
                        RPNEvalStack.Push(RPNEvalStack.Pop() - temp);
                        break;
                    default:
                        RPNEvalStack.Push(double.Parse(op));
                        break;

                }
            }

            if (RPNEvalStack.Count() == 1) return RPNEvalStack.Pop();
            throw new InvalidProgramException("The RPN is Invalid");
        }

        static void UnitTest()
        {
            Dictionary<string, double> unitTests;
            unitTests = new Dictionary<string, double> {
                {"2 3 + 4 - *", 15},
                {"6 2 4 / *", 3},
                {"1 6 1 3 * 4 2 - /", 0.25}
            };
            foreach (string test in unitTests.Keys)
            {
                double result = EvalSafe(test);
                string r = "FAIL";
                if (result == unitTests[test]) r = "PASS";
                Console.WriteLine($"Test: {test}, Result: {r}");
            }
        }
    }
}
