using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.D3DCompiler;

namespace Test_Neural_Compute
{
    public class ParraCompute
    {
        private int groupSize;
        private int totalSize;
        private int elementByteSize;

        private int[] parseData;
        public int[] parsedData;

        private Device device;
        private ComputeShader cs;
        private DeviceContext context;

        private ShaderResourceView srvs;
        private UnorderedAccessView uavs;
        private SharpDX.Direct3D11.Buffer buffer;

        public ParraCompute(int inGSize, int inTSize, int[] data) 
        {
            groupSize = inGSize;
            totalSize = inTSize;
            elementByteSize = 4;
            parseData = data;
            device = new Device(DriverType.Hardware, DeviceCreationFlags.SingleThreaded);
        }

        public void CompileFile(string FileName)
        {
            CompilationResult compiledHLSL = ShaderBytecode.CompileFromFile(FileName, "CSMain", "cs_5_0");
            cs = new ComputeShader(device, compiledHLSL);
        }

        public void CompileString(string HLSL) 
        {
            CompilationResult compiledHLSL = ShaderBytecode.Compile(HLSL, "CSMain", "cs_5_0");
            cs = new ComputeShader(device, compiledHLSL);
        }

        public void SetupBuffer()
        {
            BufferDescription bufferDescription = new BufferDescription()
            {
                SizeInBytes = elementByteSize * totalSize,
                Usage = ResourceUsage.Default,
                BindFlags = BindFlags.ShaderResource | BindFlags.UnorderedAccess,
                OptionFlags = ResourceOptionFlags.BufferStructured,
                StructureByteStride = elementByteSize,
                CpuAccessFlags = CpuAccessFlags.Read,
            };
            buffer = SharpDX.Direct3D11.Buffer.Create(device, parseData, bufferDescription);

            ShaderResourceViewDescription srvDesc = new ShaderResourceViewDescription()
            {
                Format = SharpDX.DXGI.Format.Unknown,
                Dimension = ShaderResourceViewDimension.Buffer,
                Buffer = new ShaderResourceViewDescription.BufferResource()
                {
                    ElementWidth = elementByteSize,
                }
            };
            srvs = new ShaderResourceView(device, buffer, srvDesc);

            UnorderedAccessViewDescription uavDesc = new UnorderedAccessViewDescription()
            {
                Format = SharpDX.DXGI.Format.Unknown,
                Dimension = UnorderedAccessViewDimension.Buffer,
                Buffer = new UnorderedAccessViewDescription.BufferResource()
                {
                    ElementCount = totalSize
                }
            };
            uavs = new UnorderedAccessView(device, buffer, uavDesc);

            context = device.ImmediateContext;
            context.ComputeShader.Set(cs);

            context.ComputeShader.SetConstantBuffer(0, buffer);
            context.ComputeShader.SetShaderResource(0, srvs);
            context.ComputeShader.SetUnorderedAccessView(0, uavs);
        }

        public int[] ReturnShaderResult()
        {
            int threadGroupCount = (totalSize + groupSize - 1) / groupSize;
            context.Dispatch(threadGroupCount, 1, 1);
            DataStream ds;
            context.MapSubresource(buffer, MapMode.Read, MapFlags.None, out ds);
            parsedData = ds.ReadRange<int>(parseData.Length);
            return parsedData;
        }

        public void CloseCompute()
        {
            context.ClearState();
            Utilities.Dispose(ref srvs);
            Utilities.Dispose(ref uavs);
            Utilities.Dispose(ref buffer);
            Utilities.Dispose(ref cs);
            Utilities.Dispose(ref device);
        }
    }
}
