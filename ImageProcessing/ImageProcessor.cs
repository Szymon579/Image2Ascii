using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using static System.Windows.Forms.AxHost;

namespace ImageProcessing
{
    public class ImageProcessor
    {
        Bitmap bmp;
        string in_file_path;
        int scale;
        
        static readonly float[] values = new float[]  { 0.0f, 0.0751f, 0.0829f, 0.0848f, 0.1403f,
                                   0.1850f, 0.2183f, 0.2417f, 0.2571f, 0.2852f, 0.2902f, 0.2919f,
                                   0.3099f, 0.3192f, 0.3232f, 0.3294f, 0.3384f, 0.3609f, 0.3619f,
                                   0.3667f, 0.3737f, 0.3747f, 0.3838f, 0.3921f, 0.3960f, 0.3984f,
                                   0.3993f, 0.4075f, 0.4091f, 0.4101f, 0.4200f, 0.4230f, 0.4247f,
                                   0.4274f, 0.4293f, 0.4328f, 0.4382f, 0.4385f, 0.4420f, 0.4473f,
                                   0.4477f, 0.4503f, 0.4562f, 0.4580f, 0.4610f, 0.4638f, 0.4667f,
                                   0.4686f, 0.4693f, 0.4703f, 0.4833f, 0.4881f, 0.4944f, 0.4953f,
                                   0.4992f, 0.5509f, 0.5567f, 0.5569f, 0.5591f, 0.5602f, 0.5602f,
                                   0.5650f, 0.5776f, 0.5777f, 0.5818f, 0.5879f, 0.5972f, 0.5999f,
                                   0.6043f, 0.6049f, 0.6093f, 0.6099f, 0.6465f, 0.6561f, 0.6595f,
                                   0.6631f, 0.6714f, 0.6759f, 0.6809f, 0.6816f, 0.6925f, 0.7039f,
                                   0.7086f, 0.7235f, 0.7302f, 0.7332f, 0.7602f, 0.7834f, 0.8037f,
                                   1.0000f};

        static readonly char[] chars = new char[]      { ' ',     '`',     '.',     '-',     ':',
                                       '_',     '^',     '=',     ';',     '>',     '<',     '+',
                                       '!',     'r',     'c',     '*',     '/',     'z',     '?',
                                       's',     'L',     'T',     'v',     ')',     'J',     '7', 
                                       '(',     '|',     'F',     'i',     '{',     'C',     '}', 
                                       'f',     'I',     '3',     '1',     't',     'l',     'u',
                                       '[',     'n',     'e',     'o',     'Z',     '5',     'Y', 
                                       'x',     'j',     'y',     'a',     ']',     '2',     'E',
                                       'S',     'w',     'q',     'k',     'P',     '6',     'h',
                                       '9',     'd',     '4',     'V',     'p',     'O',     'G', 
                                       'b',     'U',     'A',     'K',     'X',     'H',     'm', 
                                       '8',     'R',     'D',     '#',     '$',     'B',     'g', 
                                       '0',     'M',     'N',     'W',     'Q',     '%',     '&', 
                                       '@'};
 
            public ImageProcessor()
        {         
        }

        public ImageProcessor(string in_file_path)
        {
            this.in_file_path = in_file_path;
            bmp = new Bitmap(this.in_file_path);        
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ///                                                                                                 ///
        ///                                          GetPixel()                                             ///
        ///                                                                                                 ///
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ProcessImage(StreamWriter stream)
        {          
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color color = bmp.GetPixel(j, i);
                    float brightness = color.GetBrightness();

                    char c = CalcChar(brightness);
                    stream.Write(c + " ");
                }
                stream.Write("\n");
            }

            stream.Flush();
            stream.Close();
        }

        public void ProcessImage(StreamWriter stream, int scale = 1)
        {             
            for (int i = 0; i <= bmp.Height - scale; i += scale)
            {
                for (int j = 0; j <= bmp.Width - scale; j += scale)
                {
                    
                    float sum_brightness = 0.0f;

                    for (int y = 0; y < scale; y++)
                    {
                        for(int x = 0; x < scale; x++)
                        {
                            Color color = bmp.GetPixel(j+x, i+y);
                            sum_brightness += color.GetBrightness();
                        }
                    }

                    float avr_brightness = sum_brightness / (scale*scale);

                    char c = CalcChar(avr_brightness);
                    stream.Write(c + " ");

                }
                stream.Write("\n");
            }

            stream.Flush();
            stream.Close();
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ///                                                                                                 ///
        ///                                         BitmapData()                                            ///
        ///                                                                                                 ///
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        public void BitmapDataProcess(StreamWriter stream)
        {
            Bitmap oldBmp = new Bitmap(this.bmp);
            Bitmap newBmp = new Bitmap(oldBmp);
            Bitmap targetBmp = newBmp.Clone(new Rectangle(0, 0, newBmp.Width, newBmp.Height), PixelFormat.Format32bppArgb);
  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData =
                targetBmp.LockBits(rect, ImageLockMode.ReadWrite,
                targetBmp.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int counter = 0; counter < rgbValues.Length; counter += 4)
            {
                int r_index = counter + 0; 
                int g_index = counter + 1;
                int b_index = counter + 2;

                float brightness = CalcBrightness((int)rgbValues[r_index],
                                                  (int)rgbValues[g_index],
                                                  (int)rgbValues[b_index]);

                if ((counter) % (bmpData.Stride) == 0)
                    stream.Write("\n");

                char c = CalcChar(brightness);
                stream.Write(c + " ");
            }

            targetBmp.UnlockBits(bmpData);

            stream.Flush();
            stream.Close();
        }

        public void BitmapDataProcess(StreamWriter stream, int scale)
        {
            
            Bitmap oldBmp = new Bitmap(this.bmp);
            Bitmap newBmp = new Bitmap(oldBmp);
            Bitmap targetBmp = newBmp.Clone(new Rectangle(0, 0, newBmp.Width, newBmp.Height), PixelFormat.Format32bppArgb);

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData =
                targetBmp.LockBits(rect, ImageLockMode.ReadWrite,
                targetBmp.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int i = 0; i <= bmp.Height - scale; i += scale)
            {
                for (int j = 0; j <= bmp.Width - scale; j += scale)
                {
                    float sumBrightness = 0.0f;

                    for (int y = 0; y < scale; y++)
                    {
                        for (int x = 0; x < scale; x++)
                        {
                            int pixelIndex = ((i + y) * bmp.Width + (j + x)) * 4; 
                            int r = (int)rgbValues[pixelIndex + 0];
                            int g = (int)rgbValues[pixelIndex + 1];
                            int b = (int)rgbValues[pixelIndex + 2];

                            float brightness = CalcBrightness(r, g, b);
                            sumBrightness += brightness;
                        }
                    }

                    float averageBrightness = sumBrightness / (scale * scale);
                    char c = CalcChar(averageBrightness);
                    stream.Write(c + " ");
                }
                stream.Write("\n");
            }
            targetBmp.UnlockBits(bmpData);

            stream.Flush();
            stream.Close();
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ///                                                                                                 ///
        ///                                             Util                                                ///
        ///                                                                                                 ///
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetBmpInfo()
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData =
                bmp.LockBits(rect, ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            Console.WriteLine("Pixel format: " + bmp.PixelFormat);
            Console.WriteLine("Arr size: " + rgbValues.Length);
        }

        private float CalcBrightness(int R, int G, int B)
        {
            float num =  (float)(int)R / 255f;
            float num2 = (float)(int)G / 255f;
            float num3 = (float)(int)B / 255f;
            float num4 = num;
            float num5 = num;

            if (num2 > num4)
            {
                num4 = num2;
            }

            if (num3 > num4)
            {
                num4 = num3;
            }

            if (num2 < num5)
            {
                num5 = num2;
            }

            if (num3 < num5)
            {
                num5 = num3;
            }

            return (num4 + num5) / 2f;
        }

        private char CalcChar(float brightness)
        {
            int i = 0;

            while(i < values.Length - 1)
            {
                if (brightness >= values[i] && brightness < values[i + 1])
                {
                    return chars[i];
                }
                i++;
            }
            return 'E';
        }

        public void SetFilePath(string in_file_path)
        {
            this.in_file_path = in_file_path;
            bmp = new Bitmap(this.in_file_path);
        }

        public void SetScale(int scale)
        {
            this.scale = scale;
        }

        public string MakeOutFilePath(string appendix)
        {
            string out_file_path = in_file_path.Remove(in_file_path.Length - 4);
            
            return out_file_path + "_ASCII" + appendix + ".txt";
        }

        public static void CompareArrays()
        {
            Console.WriteLine("Size of values: " + values.Length);
            Console.WriteLine("Size of chars:  " + chars.Length);
        }
    }
}
