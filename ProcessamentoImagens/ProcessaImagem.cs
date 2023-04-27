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
            vImgR = new byte[bitmap.Height, bitmap.Width];
            vImgG = new byte[bitmap.Height, bitmap.Width];
            vImgB = new byte[bitmap.Height, bitmap.Width];
            vImgA = new byte[bitmap.Height, bitmap.Width];
            vImgGray = new byte[bitmap.Height, bitmap.Width];

            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color pixel = bitmap.GetPixel(i, j);

                    double pixelIntensity = (pixel.R + pixel.G + pixel.B) / 3;

                    vImgGray[i, j] = Convert.ToByte(NormalizeRGB(pixelIntensity));
                    vImgR[i, j] = Convert.ToByte(NormalizeRGB(pixel.R));
                    vImgG[i, j] = Convert.ToByte(NormalizeRGB(pixel.G));
                    vImgB[i, j] = Convert.ToByte(NormalizeRGB(pixel.B));
                    vImgA[i, j] = Convert.ToByte(NormalizeRGB(pixel.A));
                }
            }
        }

        //Add
        public Bitmap AddImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.height, img1.width);
            byte[,] vImgResultR = new byte[img1.height, img1.width];
            byte[,] vImgResultG = new byte[img1.height, img1.width];
            byte[,] vImgResultB = new byte[img1.height, img1.width];
            byte[,] vImgResultA = new byte[img1.height, img1.width];

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

        //Subtraction
        public Bitmap SubtImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.height, img1.width);
            byte[,] vImgResultR = new byte[img1.height, img1.width];
            byte[,] vImgResultG = new byte[img1.height, img1.width];
            byte[,] vImgResultB = new byte[img1.height, img1.width];
            byte[,] vImgResultA = new byte[img1.height, img1.width];

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

        //Multiplication
        public Bitmap MultImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.height, img1.width);
            byte[,] vImgResultR = new byte[img1.height, img1.width];
            byte[,] vImgResultG = new byte[img1.height, img1.width];
            byte[,] vImgResultB = new byte[img1.height, img1.width];
            byte[,] vImgResultA = new byte[img1.height, img1.width];

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

        //Division
        public Bitmap DivImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.height, img1.width);
            byte[,] vImgResultR = new byte[img1.height, img1.width];
            byte[,] vImgResultG = new byte[img1.height, img1.width];
            byte[,] vImgResultB = new byte[img1.height, img1.width];
            byte[,] vImgResultA = new byte[img1.height, img1.width];

            double pixelR1;
            double pixelG1;
            double pixelB1;

            double pixelR2;
            double pixelG2;
            double pixelB2;


            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    Color Img1Pixel = img1.img.GetPixel(i, j);
                    Color Img2Pixel = img2.img.GetPixel(i, j);

                    pixelR1 = DivHelper(Img1Pixel.R);
                    pixelG1 = DivHelper(Img1Pixel.G);
                    pixelB1 = DivHelper(Img1Pixel.B);

                    pixelR2 = DivHelper(Img2Pixel.R);
                    pixelG2 = DivHelper(Img2Pixel.G);
                    pixelB2 = DivHelper(Img2Pixel.B);


                    //byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);

                    vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(pixelR1 / pixelR2));
                    vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(pixelG1 / pixelG2));
                    vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(pixelB1 / pixelB2));
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

        //Media
        public Bitmap MedImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.height, img1.width);
            byte[,] vImgResultR = new byte[img1.height, img1.width];
            byte[,] vImgResultG = new byte[img1.height, img1.width];
            byte[,] vImgResultB = new byte[img1.height, img1.width];
            byte[,] vImgResultA = new byte[img1.height, img1.width];

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

        //Blend
        public Bitmap BlendImages(ProcessaImagem img1, ProcessaImagem img2, int scalar)
        {
            Bitmap imgResultado = new Bitmap(img1.height, img1.width);
            byte[,] vImgResultR = new byte[img1.height, img1.width];
            byte[,] vImgResultG = new byte[img1.height, img1.width];
            byte[,] vImgResultB = new byte[img1.height, img1.width];
            byte[,] vImgResultA = new byte[img1.height, img1.width];

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

        //Logic
        //NOT
        public Bitmap LogicNOT(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.height, img1.width);
            byte[,] vImgResultR = new byte[img1.height, img1.width];
            byte[,] vImgResultG = new byte[img1.height, img1.width];
            byte[,] vImgResultB = new byte[img1.height, img1.width];
            byte[,] vImgResultA = new byte[img1.height, img1.width];

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

        //AND
        public Bitmap LogicAND(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.height, img1.width);
            byte[,] vImgResultR = new byte[img1.height, img1.width];
            byte[,] vImgResultG = new byte[img1.height, img1.width];
            byte[,] vImgResultB = new byte[img1.height, img1.width];
            byte[,] vImgResultA = new byte[img1.height, img1.width];

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

        //OR
        public Bitmap LogicOR(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.height, img1.width);
            byte[,] vImgResultR = new byte[img1.height, img1.width];
            byte[,] vImgResultG = new byte[img1.height, img1.width];
            byte[,] vImgResultB = new byte[img1.height, img1.width];
            byte[,] vImgResultA = new byte[img1.height, img1.width];

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

        //XOR
        public Bitmap LogicXOR(ProcessaImagem img1, ProcessaImagem img2)
        {
            Bitmap imgResultado = new Bitmap(img1.height, img1.width);
            byte[,] vImgResultR = new byte[img1.height, img1.width];
            byte[,] vImgResultG = new byte[img1.height, img1.width];
            byte[,] vImgResultB = new byte[img1.height, img1.width];
            byte[,] vImgResultA = new byte[img1.height, img1.width];

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

        //Random Matrixes
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

            Bitmap imgResultado = new Bitmap(img1.Height, img1.Width);
            byte[,] vImgResultR = new byte[img1.Height, img1.Width];
            byte[,] vImgResultG = new byte[img1.Height, img1.Width];
            byte[,] vImgResultB = new byte[img1.Height, img1.Width];

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

        public Bitmap MirrorImgUD(ProcessaImagem img1)
        {
            int width = img1.width * 2;

            Bitmap imgResultado = new Bitmap(img1.img.Height, width);

            byte[,] vImgResultR = new byte[img1.img.Height, width];
            byte[,] vImgResultG = new byte[img1.img.Height, width];
            byte[,] vImgResultB = new byte[img1.img.Height, width];
            byte[,] vImgResultA = new byte[img1.img.Height, width];

            //Get image
            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j >= img1.width)
                    {
                        vImgResultA[i, j] = img1.vImgA[i, Math.Abs(width - j - 1)];
                        vImgResultR[i, j] = img1.vImgR[i, Math.Abs(width - j - 1)];
                        vImgResultG[i, j] = img1.vImgG[i, Math.Abs(width - j - 1)];
                        vImgResultB[i, j] = img1.vImgB[i, Math.Abs(width - j - 1)];
                    }
                    else
                    {
                        vImgResultA[i,j] = img1.vImgA[i, j];
                        vImgResultR[i,j] = img1.vImgR[i, j];
                        vImgResultG[i,j] = img1.vImgG[i, j];
                        vImgResultB[i,j] = img1.vImgB[i, j];
                    }
                }
            }

            //Print Results
            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < width; j++)
                {
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

        public Bitmap MirrorImgLR(ProcessaImagem img1)
        {
            int width = img1.width * 2;

            Bitmap imgResultado = new Bitmap(img1.img.Height, width);

            byte[,] vImgResultR = new byte[img1.img.Height, width];
            byte[,] vImgResultG = new byte[img1.img.Height, width];
            byte[,] vImgResultB = new byte[img1.img.Height, width];
            byte[,] vImgResultA = new byte[img1.img.Height, width];

            //Get image
            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j >= img1.width)
                    {
                        vImgResultA[i, j] = img1.vImgA[i, Math.Abs(width - j - 1)];
                        vImgResultR[i, j] = img1.vImgR[i, Math.Abs(width - j - 1)];
                        vImgResultG[i, j] = img1.vImgG[i, Math.Abs(width - j - 1)];
                        vImgResultB[i, j] = img1.vImgB[i, Math.Abs(width - j - 1)];
                    }
                    else
                    {
                        vImgResultA[i, j] = img1.vImgA[i, j];
                        vImgResultR[i, j] = img1.vImgR[i, j];
                        vImgResultG[i, j] = img1.vImgG[i, j];
                        vImgResultB[i, j] = img1.vImgB[i, j];
                    }
                }
            }

            //Print Results
            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < width; j++)
                {
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

        public Bitmap ToGrayscale(ProcessaImagem img1)
        {
            Bitmap imgResultado = new Bitmap(img1.height, img1.width);
            byte[,] vImgResultG = new byte[img1.height, img1.width];
            byte[,] vImgResultB = new byte[img1.height, img1.width];
            byte[,] vImgResultR = new byte[img1.height, img1.width];
            byte[,] vImgResultA = new byte[img1.height, img1.width];

            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {

                    vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(img1.vImgGray[i,j]));
                    vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(img1.vImgGray[i,j]));
                    vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(img1.vImgGray[i,j]));
                    vImgResultA[i, j] = Convert.ToByte(NormalizeRGB(img1.vImgA[i,j]));

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

        public Bitmap ToBinary(ProcessaImagem img1)
        {
            Bitmap imgResultado = new Bitmap(img1.height, img1.width);
            byte[,] vImgResultG = new byte[img1.height, img1.width];
            byte[,] vImgResultB = new byte[img1.height, img1.width];
            byte[,] vImgResultR = new byte[img1.height, img1.width];
            byte[,] vImgResultA = new byte[img1.height, img1.width];

            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {

                    vImgResultR[i, j] = Convert.ToByte(ConvertToBinary(img1.vImgGray[i, j]));
                    vImgResultG[i, j] = Convert.ToByte(ConvertToBinary(img1.vImgGray[i, j]));
                    vImgResultB[i, j] = Convert.ToByte(ConvertToBinary(img1.vImgGray[i, j]));
                    vImgResultA[i, j] = Convert.ToByte(ConvertToBinary(img1.vImgA[i, j]));

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

        public Bitmap ToNegative(ProcessaImagem img1)
        {
            Bitmap imgResultado = new Bitmap(img1.height, img1.width);
            byte[,] vImgResultR = new byte[img1.height, img1.width];
            byte[,] vImgResultG = new byte[img1.height, img1.width];
            byte[,] vImgResultB = new byte[img1.height, img1.width];
            byte[,] vImgResultA = new byte[img1.height, img1.width];

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

                    if (maxR < Img1Pixel.R)
                    {
                        maxR = Img1Pixel.R;
                    }
                    if (maxG < Img1Pixel.G)
                    {
                        maxG = Img1Pixel.G;
                    }
                    if (maxB < Img1Pixel.B)
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

        public Bitmap ToNegative(ProcessaImagem img1)
        {
            Bitmap imgResultado = new Bitmap(img1.height, img1.width);
            byte[,] vImgResultR = new byte[img1.height, img1.width];
            byte[,] vImgResultG = new byte[img1.height, img1.width];
            byte[,] vImgResultB = new byte[img1.height, img1.width];
            byte[,] vImgResultA = new byte[img1.height, img1.width];

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

                    if (maxR < Img1Pixel.R)
                    {
                        maxR = Img1Pixel.R;
                    }
                    if (maxG < Img1Pixel.G)
                    {
                        maxG = Img1Pixel.G;
                    }
                    if (maxB < Img1Pixel.B)
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

        //Helper Normalize RGB
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

        //Helper Convert Binary
        public double ConvertToBinary(double rgb)
        {
            if (rgb >= 128)
            {
                rgb = 255;
            }
            else if (rgb < 128)
            {
                rgb = 0;
            }

            return rgb;
        }

        // Divide by 0?
        public double DivHelper(double rgb)
        {
            if(rgb <= 0)
            {
                rgb = 1;
            }

            return rgb;
        }

        //Save --In Progress
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
