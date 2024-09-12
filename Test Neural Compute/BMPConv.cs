using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Test_Neural_Compute
{
    public class BMPConv
    {
        private string filename;
        private int Width;
        private int Height;
        private byte[] data;
        private Bitmap bmp;
        public BMPConv(string inFilename) 
        {
            filename = inFilename;
            bmp = new Bitmap(filename);
        }

        public void BArrToImg(byte[] bytes)
        {
            bmp = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            BitmapData bmpData = bmp.LockBits(
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.WriteOnly, bmp.PixelFormat);
            Marshal.Copy(bytes, 0, bmpData.Scan0, bytes.Length);
            bmp.UnlockBits(bmpData);
            bmp.Save(filename, ImageFormat.Bmp);
        }

        public void ImgToBArr()
        {
            ImageConverter imgConv = new ImageConverter();
            data = (byte[])imgConv.ConvertTo(bmp, typeof(byte[]));
        }

        static public byte[] ConvertByteArray(string strings)
        {
            byte[] bytes = Enumerable.Range(0, strings.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(strings.Substring(x, 2), 16))
                .ToArray();

            for (int i = 0; i < bytes.Length; i += 3)
            {
                byte temp = bytes[i];
                bytes[i] = bytes[i + 2];
                bytes[i + 2] = temp;
            }
            return bytes;
        }
    }
}
