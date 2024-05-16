using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Neural_Compute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] vals = new int[100];
            for (int i = 0; i < vals.Length; i++)
            {
                vals[i] = i;
                Console.WriteLine(vals[i]);
            }
            Console.WriteLine();

            ParraCompute compObj = new ParraCompute(2, vals);

            compObj.CompileString(
                @"RWStructuredBuffer<int> Result;

[numthreads(2, 1, 1)]
void CSMain(uint id : SV_DispatchThreadID)
{
    Result[id.x] = Result[id.x] * Result[id.x];
}"
);
            compObj.SetupBuffer();
            vals = compObj.ReturnShaderResult();
            compObj.CloseCompute();

            for (int i = 0; i < vals.Length; i++)
            {
                Console.WriteLine(vals[i]);
            }
            Console.ReadKey();
        }
    }
}
