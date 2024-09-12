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

        public double[] parseData;
        public double[] parsedData;
        public double[] WeightBias;

        private Device device;
        private ComputeShader cs;
        private DeviceContext context;

        private ShaderResourceView Resultsrvs;
        private UnorderedAccessView Resultuavs;
        private SharpDX.Direct3D11.Buffer Resultbuffer;
        private ShaderResourceView WBsrvs;
        private UnorderedAccessView WBuavs;
        private SharpDX.Direct3D11.Buffer WBbuffer;

        public ParraCompute(int inGSize, double[] data) 
        {
            parseData = data;
            groupSize = inGSize;
            totalSize = parseData.Length;
            elementByteSize = sizeof(double);
            device = new Device(DriverType.Hardware, DeviceCreationFlags.SingleThreaded);
        }

        public ParraCompute(int inGSize, int dataSize)
        {
            groupSize = inGSize;
            totalSize = dataSize;
            elementByteSize = 4;
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

        private void SetupResultBuffer()
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
            Resultbuffer = SharpDX.Direct3D11.Buffer.Create(device, parseData, bufferDescription);

            ShaderResourceViewDescription srvDesc = new ShaderResourceViewDescription()
            {
                Format = SharpDX.DXGI.Format.Unknown,
                Dimension = ShaderResourceViewDimension.Buffer,
                Buffer = new ShaderResourceViewDescription.BufferResource()
                {
                    ElementWidth = elementByteSize,
                }
            };
            Resultsrvs = new ShaderResourceView(device, Resultbuffer, srvDesc);

            UnorderedAccessViewDescription uavDesc = new UnorderedAccessViewDescription()
            {
                Format = SharpDX.DXGI.Format.Unknown,
                Dimension = UnorderedAccessViewDimension.Buffer,
                Buffer = new UnorderedAccessViewDescription.BufferResource()
                {
                    ElementCount = totalSize
                }
            };
            Resultuavs = new UnorderedAccessView(device, Resultbuffer, uavDesc);
        }

        private void SetupWBBuffer()
        {
            BufferDescription bufferDescription = new BufferDescription()
            {
                SizeInBytes = elementByteSize * WeightBias.Length,
                Usage = ResourceUsage.Default,
                BindFlags = BindFlags.ShaderResource | BindFlags.UnorderedAccess,
                OptionFlags = ResourceOptionFlags.BufferStructured,
                StructureByteStride = elementByteSize,
                CpuAccessFlags = CpuAccessFlags.Read,
            };
            WBbuffer = SharpDX.Direct3D11.Buffer.Create(device, WeightBias, bufferDescription);

            ShaderResourceViewDescription srvDesc = new ShaderResourceViewDescription()
            {
                Format = SharpDX.DXGI.Format.Unknown,
                Dimension = ShaderResourceViewDimension.Buffer,
                Buffer = new ShaderResourceViewDescription.BufferResource()
                {
                    ElementWidth = elementByteSize,
                }
            };
            WBsrvs = new ShaderResourceView(device, WBbuffer, srvDesc);

            UnorderedAccessViewDescription uavDesc = new UnorderedAccessViewDescription()
            {
                Format = SharpDX.DXGI.Format.Unknown,
                Dimension = UnorderedAccessViewDimension.Buffer,
                Buffer = new UnorderedAccessViewDescription.BufferResource()
                {
                    ElementCount = WeightBias.Length
                }
            };
            WBuavs = new UnorderedAccessView(device, WBbuffer, uavDesc);
        }

        private void SetupBuffers()
        {
            SetupResultBuffer();
            SetupWBBuffer();

            context = device.ImmediateContext;
            context.ComputeShader.Set(cs);
            context.ComputeShader.SetConstantBuffers(0, new SharpDX.Direct3D11.Buffer[] { WBbuffer, Resultbuffer });
            context.ComputeShader.SetShaderResources(0, new ShaderResourceView[] { WBsrvs, Resultsrvs });
            context.ComputeShader.SetUnorderedAccessViews(0, new UnorderedAccessView[] { WBuavs, Resultuavs });
        }

        public double[] ReturnShaderResult()
        {
            SetupBuffers();
            int threadGroupCount = (totalSize + groupSize - 1) / groupSize;
            context.Dispatch(threadGroupCount, 1, 1);
            DataStream ds;
            context.MapSubresource(Resultbuffer, MapMode.Read, MapFlags.None, out ds);
            parsedData = ds.ReadRange<double>(parseData.Length);
            return parsedData;
        }

        public void CloseCompute()
        {
            context.ClearState();
            Utilities.Dispose(ref Resultsrvs);
            Utilities.Dispose(ref Resultuavs);
            Utilities.Dispose(ref Resultbuffer);
            Utilities.Dispose(ref WBsrvs);
            Utilities.Dispose(ref WBuavs);
            Utilities.Dispose(ref WBbuffer);
            Utilities.Dispose(ref cs);
            Utilities.Dispose(ref device);
        }
    }
}
