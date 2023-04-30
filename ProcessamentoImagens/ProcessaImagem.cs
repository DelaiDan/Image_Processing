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

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Color pixel = bitmap.GetPixel(j, i);

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
            if(CheckImages(img1, img2))
            {
                Bitmap imgResultado = new Bitmap(img1.width, img1.height);
                byte[,] vImgResultR = new byte[img1.height, img1.width];
                byte[,] vImgResultG = new byte[img1.height, img1.width];
                byte[,] vImgResultB = new byte[img1.height, img1.width];
                byte[,] vImgResultA = new byte[img1.height, img1.width];

                for (int i = 0; i < img1.height; i++)
                {
                    for (int j = 0; j < img1.width; j++)
                    {
                        Color Img1Pixel = img1.img.GetPixel(j, i);
                        Color Img2Pixel = img2.img.GetPixel(j, i);

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

                        imgResultado.SetPixel(j, i, c);
                    }
                }

                return imgResultado;
            }
            return null;
        }

        //Subtraction
        public Bitmap SubtImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            if (CheckImages(img1, img2))
            {
                Bitmap imgResultado = new Bitmap(img1.width, img1.height);
                byte[,] vImgResultR = new byte[img1.height, img1.width];
                byte[,] vImgResultG = new byte[img1.height, img1.width];
                byte[,] vImgResultB = new byte[img1.height, img1.width];
                byte[,] vImgResultA = new byte[img1.height, img1.width];

                for (int i = 0; i < img1.height; i++)
                {
                    for (int j = 0; j < img1.width; j++)
                    {
                        Color Img1Pixel = img1.img.GetPixel(j, i);
                        Color Img2Pixel = img2.img.GetPixel(j, i);

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

                        imgResultado.SetPixel(j, i, c);
                    }
                }

                return imgResultado;
            }
            return null;
        }

        //Multiplication
        public Bitmap MultImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            if (CheckImages(img1, img2))
            {
                Bitmap imgResultado = new Bitmap(img1.width, img1.height);
                byte[,] vImgResultR = new byte[img1.height, img1.width];
                byte[,] vImgResultG = new byte[img1.height, img1.width];
                byte[,] vImgResultB = new byte[img1.height, img1.width];
                byte[,] vImgResultA = new byte[img1.height, img1.width];

                for (int i = 0; i < img1.height; i++)
                {
                    for (int j = 0; j < img1.width; j++)
                    {
                        Color Img1Pixel = img1.img.GetPixel(j, i);
                        Color Img2Pixel = img2.img.GetPixel(j, i);

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

                        imgResultado.SetPixel(j, i, c);
                    }
                }

                return imgResultado;
            }
            return null;
        }

        //Division
        public Bitmap DivImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            if (CheckImages(img1, img2))
            {
                Bitmap imgResultado = new Bitmap(img1.width, img1.height);
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
                        Color Img1Pixel = img1.img.GetPixel(j, i);
                        Color Img2Pixel = img2.img.GetPixel(j, i);

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

                        imgResultado.SetPixel(j, i, c);
                    }
                }

                return imgResultado;
            }
            return null;
        }

        //Media
        public Bitmap MedImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            if (CheckImages(img1, img2))
            {
                Bitmap imgResultado = new Bitmap(img1.width, img1.height);
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
                        Color Img1Pixel = img1.img.GetPixel(j, i);
                        Color Img2Pixel = img2.img.GetPixel(j, i);

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

                        imgResultado.SetPixel(j, i, c);
                    }
                }

                return imgResultado;
            }
            return null;
        }

        //Blend
        public Bitmap BlendImages(ProcessaImagem img1, ProcessaImagem img2, int scalar)
        {
            if (CheckImages(img1, img2))
            {
                Bitmap imgResultado = new Bitmap(img1.width, img1.height);
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
                        Color Img1Pixel = img1.img.GetPixel(j, i);
                        Color Img2Pixel = img2.img.GetPixel(j, i);

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

                        imgResultado.SetPixel(j, i, c);
                    }
                }

                return imgResultado;
            }
            return null;
        }

        //Logic
        //NOT
        public Bitmap LogicNOT(ProcessaImagem img1, ProcessaImagem img2)
        {
            if (CheckImages(img1, img2))
            {
                Bitmap imgResultado = new Bitmap(img1.width, img1.height);
                byte[,] vImgResultR = new byte[img1.height, img1.width];
                byte[,] vImgResultG = new byte[img1.height, img1.width];
                byte[,] vImgResultB = new byte[img1.height, img1.width];
                byte[,] vImgResultA = new byte[img1.height, img1.width];

                for (int i = 0; i < img1.height; i++)
                {
                    for (int j = 0; j < img1.width; j++)
                    {
                        Color Img1Pixel = img1.img.GetPixel(j, i);
                        Color Img2Pixel = img2.img.GetPixel(j, i);

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

                        imgResultado.SetPixel(j, i, c);
                    }
                }

                return imgResultado;
            }
            return null;
        }

        //AND
        public Bitmap LogicAND(ProcessaImagem img1, ProcessaImagem img2)
        {
            if (CheckImages(img1, img2))
            {
                Bitmap imgResultado = new Bitmap(img1.width, img1.height);
                byte[,] vImgResultR = new byte[img1.height, img1.width];
                byte[,] vImgResultG = new byte[img1.height, img1.width];
                byte[,] vImgResultB = new byte[img1.height, img1.width];
                byte[,] vImgResultA = new byte[img1.height, img1.width];

                for (int i = 0; i < img1.height; i++)
                {
                    for (int j = 0; j < img1.width; j++)
                    {
                        Color Img1Pixel = img1.img.GetPixel(j, i);
                        Color Img2Pixel = img2.img.GetPixel(j, i);

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

                        imgResultado.SetPixel(j, i, c);
                    }
                }

                return imgResultado;
            }
            return null;
        }

        //OR
        public Bitmap LogicOR(ProcessaImagem img1, ProcessaImagem img2)
        {
            if (CheckImages(img1, img2))
            {
                Bitmap imgResultado = new Bitmap(img1.width, img1.height);
                byte[,] vImgResultR = new byte[img1.height, img1.width];
                byte[,] vImgResultG = new byte[img1.height, img1.width];
                byte[,] vImgResultB = new byte[img1.height, img1.width];
                byte[,] vImgResultA = new byte[img1.height, img1.width];

                for (int i = 0; i < img1.height; i++)
                {
                    for (int j = 0; j < img1.width; j++)
                    {
                        Color Img1Pixel = img1.img.GetPixel(j, i);
                        Color Img2Pixel = img2.img.GetPixel(j, i);

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

                        imgResultado.SetPixel(j, i, c);
                    }
                }

                return imgResultado;
            }
            return null;
        }

        //XOR
        public Bitmap LogicXOR(ProcessaImagem img1, ProcessaImagem img2)
        {
            if (CheckImages(img1, img2))
            {
                Bitmap imgResultado = new Bitmap(img1.width, img1.height);
                byte[,] vImgResultR = new byte[img1.height, img1.width];
                byte[,] vImgResultG = new byte[img1.height, img1.width];
                byte[,] vImgResultB = new byte[img1.height, img1.width];
                byte[,] vImgResultA = new byte[img1.height, img1.width];

                for (int i = 0; i < img1.height; i++)
                {
                    for (int j = 0; j < img1.width; j++)
                    {
                        Color Img1Pixel = img1.img.GetPixel(j, i);
                        Color Img2Pixel = img2.img.GetPixel(j, i);

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

                        imgResultado.SetPixel(j, i, c);
                    }
                }

                return imgResultado;
            }
            return null;
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

                    img1.SetPixel(j, i, c1);
                    img2.SetPixel(j, i, c2);
                }
            }

            Bitmap imgResultado = new Bitmap(img1.Width, img1.Height);
            byte[,] vImgResultR = new byte[img1.Height, img1.Width];
            byte[,] vImgResultG = new byte[img1.Height, img1.Width];
            byte[,] vImgResultB = new byte[img1.Height, img1.Width];

            for (int i = 0; i < img1.Height; i++)
            {
                for (int j = 0; j < img1.Width; j++)
                {
                    Color Img1Pixel = img1.GetPixel(j, i);
                    Color Img2Pixel = img2.GetPixel(j, i);

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

                    imgResultado.SetPixel(j, i, c);
                }
            }

            return imgResultado;
        }

        public Bitmap MirrorImgUD(ProcessaImagem img1)
        {
            int height = img1.height * 2;

            Bitmap imgResultado = new Bitmap(img1.width, height);

            byte[,] vImgResultR = new byte[height, img1.width];
            byte[,] vImgResultG = new byte[height, img1.width];
            byte[,] vImgResultB = new byte[height, img1.width];
            byte[,] vImgResultA = new byte[height, img1.width];

            //Get image
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    if (i >= img1.height)
                    {
                        vImgResultA[i, j] = img1.vImgA[Math.Abs(height - i - 1), j];
                        vImgResultR[i, j] = img1.vImgR[Math.Abs(height - i - 1), j];
                        vImgResultG[i, j] = img1.vImgG[Math.Abs(height - i - 1), j];
                        vImgResultB[i, j] = img1.vImgB[Math.Abs(height - i - 1), j];
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
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    Color c = Color.FromArgb(
                        vImgResultA[i, j],
                        vImgResultR[i, j],
                        vImgResultG[i, j],
                        vImgResultB[i, j]
                    );

                    imgResultado.SetPixel(j, i, c);
                }
            }

            return imgResultado;
        }

        public Bitmap MirrorImgLR(ProcessaImagem img1)
        {
            int width = img1.width * 2;

            Bitmap imgResultado = new Bitmap(width, img1.height);

            byte[,] vImgResultR = new byte[img1.height, width];
            byte[,] vImgResultG = new byte[img1.height, width];
            byte[,] vImgResultB = new byte[img1.height, width];
            byte[,] vImgResultA = new byte[img1.height, width];

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

                    imgResultado.SetPixel(j, i, c);
                }
            }

            return imgResultado;
        }

        public Bitmap ToGrayscale(ProcessaImagem img1)
        {
            Bitmap imgResultado = new Bitmap(img1.width, img1.height);
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

                    imgResultado.SetPixel(j, i, c);
                }
            }

            return imgResultado;
        }

        public Bitmap ToBinary(ProcessaImagem img1)
        {
            Bitmap imgResultado = new Bitmap(img1.width, img1.height);
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

                    imgResultado.SetPixel(j, i, c);
                }
            }

            return imgResultado;
        }

        public Bitmap ToNegative(ProcessaImagem img1)
        {
            Bitmap imgResultado = new Bitmap(img1.width, img1.height);
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
                    Color Img1Pixel = img1.img.GetPixel(j, i);

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

                    imgResultado.SetPixel(j, i, c);
                }
            }

            return imgResultado;
        }

        public Bitmap Histogram(ProcessaImagem img1)
        {
            Bitmap imgResultado = new Bitmap(img1.width, img1.height);
            byte[,] img = img1.vImgGray;

            int[] histogramFinalImg = new int[256];

            // Calcula o histograma da imagem
            int[] histogram = new int[256];
            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    histogram[img[i, j]]++;
                }
            }

            // Calcula a função de distribuição acumulada (CDF) do histograma, normalizada para ter valores entre 0 e 1
            double[] cdf = new double[256];
            int pixelsCount = img1.width * img1.height;
            cdf[0] = histogram[0] / (double)pixelsCount;

            for (int i = 1; i < 256; i++)
            {
                cdf[i] = cdf[i - 1] + histogram[i] / (double)pixelsCount;
            }

            // Mapeia cada valor de pixel para um novo valor com base na CDF, escalonando para o intervalo [0, 255]
            int[,] equalizedImg = new int[width, height];

            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    int oldPixelValue = img[i, j];
                    int newPixelValue = (int)Math.Round(cdf[oldPixelValue] * 255.0);
                    equalizedImg[i, j] = newPixelValue;
                }
            }

            for (int i = 0; i < img1.height; i++)
            {
                for (int j = 0; j < img1.width; j++)
                {
                    histogramFinalImg[equalizedImg[i, j]]++;
                }
            }

            /*
            chart1.Series.Clear();
            chart1.Series.Add("Histograma");
            chart1.Series["Histograma"].ChartType = SeriesChartType.Column;
            chart1.Series["Histograma"].Points.DataBindY(histogram);
            chart1.ChartAreas[0].AxisY.Maximum = histogram.Max() + 10;

            chart2.Series.Clear();
            chart2.Series.Add("ImgResult");
            chart2.Series["ImgResult"].ChartType = SeriesChartType.Column;
            chart2.Series["ImgResult"].Points.DataBindY(histogramFinalImg);
            chart2.ChartAreas[0].AxisY.Maximum = histogramFinalImg.Max() + 10;
            */


            for (int i = 0; i < img1.width; i++)
            {
                for (int j = 0; j < img1.height; j++)
                {
                    Color c = Color.FromArgb(equalizedImg[i, j], equalizedImg[i, j], equalizedImg[i, j]);
                    imgResultado.SetPixel(j, i, c);
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

        public bool CheckImages(ProcessaImagem img1, ProcessaImagem img2)
        {
            if (img1.img.Width != img2.img.Width || img1.img.Height != img2.img.Height || img1.img.PixelFormat != img1.img.PixelFormat)
            {
                MessageBox.Show("As imagens precisam ter o mesmo tamanho e formato");
                return false;
            }
            return true;
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
