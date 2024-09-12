using SharpDX.Direct3D11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Neural_Compute
{
    public class Net
    {
        Layer[] Hidden;
        Random rand;
        ParraCompute compObj;
        public Net(int NumLayers, int NumNeurons, int InputsSize)
        {
            Hidden = new Layer[NumLayers];
            rand = new Random();
            for (int i = 0; i < Hidden.Length; i++)
            {
                Hidden[i] = new Layer(NumNeurons, rand);
            }

            compObj = new ParraCompute(2, InputsSize);

            compObj.CompileFile("Shader.hlsl");
        }

        public Layer Compute(Layer Inputs)
        {

            compObj.ReturnShaderResult();
        }
    }
}
