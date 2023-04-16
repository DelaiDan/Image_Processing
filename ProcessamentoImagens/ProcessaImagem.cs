using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProcessamentoImagens
{
    internal class ProcessaImagem
    {
        public Bitmap img;
        public byte[,] vImgGray;
        public byte[,] vImgR;
        public byte[,] vImgG;
        public byte[,] vImgB;
        public byte[,] vImgA;
        public int height;
        public int width;

        //Constructor
        public ProcessaImagem(Bitmap bitmap) {
            if(bitmap != null)
            {
                ExtractRGB(bitmap);
            }
        }

        //N Sei
        public ProcessaImagem newImage(Bitmap bitmap)
        {
            return new ProcessaImagem(bitmap);
        }

        //Menin
        public void ExtractRGB(Bitmap bitmap)
        {
            img = bitmap;
            height = img.Height;
            width = img.Width;
            vImgR = new byte[bitmap.Width, bitmap.Height];
            vImgG = new byte[bitmap.Width, bitmap.Height];
            vImgB = new byte[bitmap.Width, bitmap.Height];
            vImgA = new byte[bitmap.Width, bitmap.Height];

            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color pixel = bitmap.GetPixel(i, j);

                    byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);

                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;
                    byte A = pixel.A;

                    vImgR[i, j] = R;
                    vImgG[i, j] = G;
                    vImgB[i, j] = B;
                    vImgA[i, j] = A;
                }
            }
        }

        //Adição
        public Bitmap AddImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.img.Width, img1.img.Height);
            byte[,] vImgResultR = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultG = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultB = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultA = new byte[img1.img.Width, img1.img.Height];

            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    Color Img1Pixel = img1.img.GetPixel(i, j);
                    Color Img2Pixel = img2.img.GetPixel(i, j);

                    //byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);

                    vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.R + Img2Pixel.R));
                    vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.G + Img2Pixel.G));
                    vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.B + Img2Pixel.B));
                    vImgResultA[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.A + Img2Pixel.A));

                    Color c = Color.FromArgb(
                        vImgResultA[i, j],
                        vImgResultR[i, j],
                        vImgResultG[i, j],
                        vImgResultB[i, j]
                        );

                    imgResultado.SetPixel(i, j, c);
                }
            }

            return imgResultado;
        }

        public Bitmap SubtImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.img.Width, img1.img.Height);
            byte[,] vImgResultR = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultG = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultB = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultA = new byte[img1.img.Width, img1.img.Height];

            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    Color Img1Pixel = img1.img.GetPixel(i, j);
                    Color Img2Pixel = img2.img.GetPixel(i, j);

                    //byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);

                    vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.R - Img2Pixel.R));
                    vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.G - Img2Pixel.G));
                    vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.B - Img2Pixel.B));
                    vImgResultA[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.A));

                    Color c = Color.FromArgb(
                        vImgResultA[i, j],
                        vImgResultR[i, j],
                        vImgResultG[i, j],
                        vImgResultB[i, j]
                        );

                    imgResultado.SetPixel(i, j, c);
                }
            }

            return imgResultado;
        }

        public Bitmap MultImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.img.Width, img1.img.Height);
            byte[,] vImgResultR = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultG = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultB = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultA = new byte[img1.img.Width, img1.img.Height];

            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    Color Img1Pixel = img1.img.GetPixel(i, j);
                    Color Img2Pixel = img2.img.GetPixel(i, j);

                    //byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);

                    vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.R * Img2Pixel.R));
                    vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.G * Img2Pixel.G));
                    vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.B * Img2Pixel.B));
                    vImgResultA[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.A));

                    Color c = Color.FromArgb(
                        vImgResultA[i, j],
                        vImgResultR[i, j],
                        vImgResultG[i, j],
                        vImgResultB[i, j]
                        );

                    imgResultado.SetPixel(i, j, c);
                }
            }

            return imgResultado;
        }

        public Bitmap DivImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.img.Width, img1.img.Height);
            byte[,] vImgResultR = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultG = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultB = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultA = new byte[img1.img.Width, img1.img.Height];

            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    Color Img1Pixel = img1.img.GetPixel(i, j);
                    Color Img2Pixel = img2.img.GetPixel(i, j);

                    //byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);

                    vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.R / Img2Pixel.R));
                    vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.G / Img2Pixel.G));
                    vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.B / Img2Pixel.B));
                    vImgResultA[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.A));

                    Color c = Color.FromArgb(
                        vImgResultA[i, j],
                        vImgResultR[i, j],
                        vImgResultG[i, j],
                        vImgResultB[i, j]
                        );

                    imgResultado.SetPixel(i, j, c);
                }
            }

            return imgResultado;
        }

        public Bitmap MedImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.img.Width, img1.img.Height);
            byte[,] vImgResultR = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultG = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultB = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultA = new byte[img1.img.Width, img1.img.Height];

            double resultR = 0;
            double resultG = 0;
            double resultB = 0;


            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    Color Img1Pixel = img1.img.GetPixel(i, j);
                    Color Img2Pixel = img2.img.GetPixel(i, j);

                    //byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);

                    resultR = (Img1Pixel.R * 0.5) + (Img2Pixel.R * 0.5);
                    resultG = (Img1Pixel.G * 0.5) + (Img2Pixel.G * 0.5);
                    resultB = (Img1Pixel.B * 0.5) + (Img2Pixel.B * 0.5);

                    vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(resultR));
                    vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(resultG));
                    vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(resultB));
                    vImgResultA[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.A));

                    Color c = Color.FromArgb(
                        vImgResultA[i, j],
                        vImgResultR[i, j],
                        vImgResultG[i, j],
                        vImgResultB[i, j]
                        );

                    imgResultado.SetPixel(i, j, c);
                }
            }

            return imgResultado;
        }

        public Bitmap BlendImages(ProcessaImagem img1, ProcessaImagem img2, int scalar)
        {
            Bitmap imgResultado = new Bitmap(img1.img.Width, img1.img.Height);
            byte[,] vImgResultR = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultG = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultB = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultA = new byte[img1.img.Width, img1.img.Height];

            double resultR = 0;
            double resultG = 0;
            double resultB = 0;

            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    Color Img1Pixel = img1.img.GetPixel(i, j);
                    Color Img2Pixel = img2.img.GetPixel(i, j);

                    //byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);

                    resultR = scalar * Img1Pixel.R + (1 - scalar) * Img2Pixel.R;
                    resultG = scalar * Img1Pixel.G + (1 - scalar) * Img2Pixel.G;
                    resultB = scalar * Img1Pixel.B + (1 - scalar) * Img2Pixel.B;

                    vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(resultR));
                    vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(resultG));
                    vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(resultB));
                    vImgResultA[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.A));

                    Color c = Color.FromArgb(
                        vImgResultA[i, j],
                        vImgResultR[i, j],
                        vImgResultG[i, j],
                        vImgResultB[i, j]
                        );

                    imgResultado.SetPixel(i, j, c);
                }
            }

            return imgResultado;
        }

        public Bitmap LogicNOT(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.img.Width, img1.img.Height);
            byte[,] vImgResultR = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultG = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultB = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultA = new byte[img1.img.Width, img1.img.Height];

            int maxR = 0;
            int maxG = 0;
            int maxB = 0;

            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    Color Img1Pixel = img1.img.GetPixel(i, j);

                    vImgResultR[i, j] = Img1Pixel.R;
                    vImgResultG[i, j] = Img1Pixel.G;
                    vImgResultB[i, j] = Img1Pixel.B;
                    vImgResultA[i, j] = Img1Pixel.A;

                    if(maxR < Img1Pixel.R)
                    {
                        maxR = Img1Pixel.R;
                    }
                    if(maxG < Img1Pixel.G)
                    {
                        maxG = Img1Pixel.G;
                    }
                    if(maxB < Img1Pixel.B)
                    {
                        maxB = Img1Pixel.B;
                    }

                    Color c = Color.FromArgb(
                        vImgResultA[i, j],
                        maxR - vImgResultR[i, j],
                        maxG - vImgResultG[i, j],
                        maxB - vImgResultB[i, j]
                        );

                    //byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);

                    imgResultado.SetPixel(i, j, c);
                }
            }

            return imgResultado;
        }

        public Bitmap LogicAND(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.img.Width, img1.img.Height);
            byte[,] vImgResultR = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultG = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultB = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultA = new byte[img1.img.Width, img1.img.Height];

            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    Color Img1Pixel = img1.img.GetPixel(i, j);
                    Color Img2Pixel = img2.img.GetPixel(i, j);

                    //byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);

                    vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.R & Img2Pixel.R));
                    vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.G & Img2Pixel.G));
                    vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.B & Img2Pixel.B));
                    vImgResultA[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.A));

                    Color c = Color.FromArgb(
                        vImgResultA[i, j],
                        vImgResultR[i, j],
                        vImgResultG[i, j],
                        vImgResultB[i, j]
                        );

                    imgResultado.SetPixel(i, j, c);
                }
            }

            return imgResultado;
        }

        public Bitmap LogicOR(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.img.Width, img1.img.Height);
            byte[,] vImgResultR = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultG = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultB = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultA = new byte[img1.img.Width, img1.img.Height];

            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    Color Img1Pixel = img1.img.GetPixel(i, j);
                    Color Img2Pixel = img2.img.GetPixel(i, j);

                    //byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);

                    vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.R | Img2Pixel.R));
                    vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.G | Img2Pixel.G));
                    vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.B | Img2Pixel.B));
                    vImgResultA[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.A));

                    Color c = Color.FromArgb(
                        vImgResultA[i, j],
                        vImgResultR[i, j],
                        vImgResultG[i, j],
                        vImgResultB[i, j]
                        );

                    imgResultado.SetPixel(i, j, c);
                }
            }

            return imgResultado;
        }

        public Bitmap LogicXOR(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.img.Width, img1.img.Height);
            byte[,] vImgResultR = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultG = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultB = new byte[img1.img.Width, img1.img.Height];
            byte[,] vImgResultA = new byte[img1.img.Width, img1.img.Height];

            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    Color Img1Pixel = img1.img.GetPixel(i, j);
                    Color Img2Pixel = img2.img.GetPixel(i, j);

                    //byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);

                    vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.R ^ Img2Pixel.R));
                    vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.G ^ Img2Pixel.G));
                    vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.B ^ Img2Pixel.B));
                    vImgResultA[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.A));

                    Color c = Color.FromArgb(
                        vImgResultA[i, j],
                        vImgResultR[i, j],
                        vImgResultG[i, j],
                        vImgResultB[i, j]
                        );

                    imgResultado.SetPixel(i, j, c);
                }
            }

            return imgResultado;
        }

        //Random Matrix
        public Bitmap RandomCreateAdd(int size)
        {
            Random rnd = new Random();
            Bitmap img1 = new Bitmap(size, size);
            Bitmap img2 = new Bitmap(size, size);

            byte[,] vImg1ResultR = new byte[size, size];
            byte[,] vImg1ResultG = new byte[size, size];
            byte[,] vImg1ResultB = new byte[size, size];

            byte[,] vImg2ResultR = new byte[size, size];
            byte[,] vImg2ResultG = new byte[size, size];
            byte[,] vImg2ResultB = new byte[size, size];

            byte[,] vImgResultA = new byte[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    vImg1ResultR[i, j] = Convert.ToByte(NormalizeRGB(rnd.Next(256)));
                    vImg1ResultG[i, j] = Convert.ToByte(NormalizeRGB(rnd.Next(256)));
                    vImg1ResultB[i, j] = Convert.ToByte(NormalizeRGB(rnd.Next(256)));

                    vImg2ResultR[i, j] = Convert.ToByte(NormalizeRGB(rnd.Next(256)));
                    vImg2ResultG[i, j] = Convert.ToByte(NormalizeRGB(rnd.Next(256)));
                    vImg2ResultB[i, j] = Convert.ToByte(NormalizeRGB(rnd.Next(256)));


                    vImgResultA[i, j] = Convert.ToByte(NormalizeRGB(255));

                    Color c1 = Color.FromArgb(
                        vImgResultA[i, j],
                        vImg1ResultR[i, j],
                        vImg1ResultG[i, j],
                        vImg1ResultB[i, j]
                        );

                    Color c2 = Color.FromArgb(
                        vImgResultA[i, j],
                        vImg2ResultR[i, j],
                        vImg2ResultG[i, j],
                        vImg2ResultB[i, j]
                        );

                    img1.SetPixel(i, j, c1);
                    img2.SetPixel(i, j, c2);
                }
            }

            Bitmap imgResultado = new Bitmap(img1.Width, img1.Height);
            byte[,] vImgResultR = new byte[img1.Width, img1.Height];
            byte[,] vImgResultG = new byte[img1.Width, img1.Height];
            byte[,] vImgResultB = new byte[img1.Width, img1.Height];

            for (int i = 0; i < img1.Height; i++)
            {
                for (int j = 0; j < img1.Width; j++)
                {
                    Color Img1Pixel = img1.GetPixel(i, j);
                    Color Img2Pixel = img2.GetPixel(i, j);

                    //byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);

                    vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.R + Img2Pixel.R));
                    vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.G + Img2Pixel.G));
                    vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.B + Img2Pixel.B));
                    vImgResultA[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.A + Img2Pixel.A));

                    Color c = Color.FromArgb(
                        vImgResultA[i, j],
                        vImgResultR[i, j],
                        vImgResultG[i, j],
                        vImgResultB[i, j]
                        );

                    imgResultado.SetPixel(i, j, c);
                }
            }

            return imgResultado;
        }

        public double NormalizeRGB(double rgb)
        {
            if(rgb >= 255)
            {
                rgb = 255;
            } 
            else if(rgb <= 0)
            {
                rgb = 0;
            }

            return rgb;
        }

        //Net
        public Color[][] GetBitMapColorMatrix(string bitmapFilePath)
        {
            Bitmap bitmap = new Bitmap(bitmapFilePath);

            int height = bitmap.Height;
            int width = bitmap.Width;

            Color[][] colorMatrix = new Color[width][];

            for (int i = 0; i < width; i++)
            {
                colorMatrix[i] = new Color[height];
                for (int j = 0; j < height; j++)
                {
                    colorMatrix[i][j] = bitmap.GetPixel(i, j);
                }
            }
            return colorMatrix;
        }

        public void saveImage(Bitmap drawImage)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(drawImage.Width);
                int height = Convert.ToInt32(drawImage.Height);
                using (Bitmap bmp = new Bitmap(width, height))
                {
                    bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                }
            }
        }

        //Debug
        public void ShowMatrix(byte[,] matrix)
        {
            int row = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }
    }
}
