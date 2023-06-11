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
        public Bitmap MultImages(ProcessaImagem img1, ProcessaImagem img2, int multiplicador)
        {
            if (img1 != null)
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

                        vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.R * multiplicador));
                        vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.G * multiplicador));
                        vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(Img1Pixel.B * multiplicador));
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
        public Bitmap DivImages(ProcessaImagem img1, int multiplicador)
        {
            if (img1 != null)
            {
                Bitmap imgResultado = new Bitmap(img1.width, img1.height);
                byte[,] vImgResultR = new byte[img1.height, img1.width];
                byte[,] vImgResultG = new byte[img1.height, img1.width];
                byte[,] vImgResultB = new byte[img1.height, img1.width];
                byte[,] vImgResultA = new byte[img1.height, img1.width];

                double pixelR1;
                double pixelG1;
                double pixelB1;

                for (int i = 0; i < img1.height; i++)
                {
                    for (int j = 0; j < img1.width; j++)
                    {
                        Color Img1Pixel = img1.img.GetPixel(j, i);

                        pixelR1 = DivHelper(Img1Pixel.R);
                        pixelG1 = DivHelper(Img1Pixel.G);
                        pixelB1 = DivHelper(Img1Pixel.B);

                        vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(pixelR1 / multiplicador));
                        vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(pixelG1 / multiplicador));
                        vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(pixelB1 / multiplicador));
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
                ProcessaImagem ProcessaHelper = new ProcessaImagem(null);
                Bitmap Img1Bin = ProcessaHelper.ToBinary(img1);
                Bitmap Img2Bin = ProcessaHelper.ToBinary(img2);

                Bitmap imgResultado = new Bitmap(img1.width, img1.height);
                byte[,] vImgResultR = new byte[img1.height, img1.width];
                byte[,] vImgResultG = new byte[img1.height, img1.width];
                byte[,] vImgResultB = new byte[img1.height, img1.width];
                byte[,] vImgResultA = new byte[img1.height, img1.width];

                byte R, G, B;

                for (int i = 0; i < img1.height; i++)
                {
                    for (int j = 0; j < img1.width; j++)
                    {
                        Color Img1Pixel = Img1Bin.GetPixel(j, i);
                        Color Img2Pixel = Img2Bin.GetPixel(j, i);

                        //Verify values
                        if (Img1Pixel.R.Equals(Img2Pixel.R) || Img1Pixel.R > Img2Pixel.R)
                        {
                            R = Convert.ToByte(Img1Pixel.R);
                        }
                        else
                        {
                            R = Convert.ToByte(Img2Pixel.R);
                        }

                        if (Img1Pixel.G.Equals(Img2Pixel.G) || Img1Pixel.G > Img2Pixel.G)
                        {
                            G = Convert.ToByte(Img1Pixel.G);
                        }
                        else
                        {
                            G = Convert.ToByte(Img2Pixel.G);
                        }

                        if (Img1Pixel.B.Equals(Img2Pixel.B) || Img1Pixel.B > Img2Pixel.B)
                        {
                            B = Convert.ToByte(Img1Pixel.B);
                        }
                        else
                        {
                            B = Convert.ToByte(Img2Pixel.B);
                        }

                        vImgResultR[i, j] = Convert.ToByte(R);
                        vImgResultG[i, j] = Convert.ToByte(G);
                        vImgResultB[i, j] = Convert.ToByte(B);
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
            if (img1 != null)
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
            return null;
        }

        public Bitmap MirrorImgLR(ProcessaImagem img1)
        {
            if (img1 != null)
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
            return null;
        }

        public Bitmap ToGrayscale(ProcessaImagem img1)
        {
            if (img1 != null)
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

                        vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(img1.vImgGray[i, j]));
                        vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(img1.vImgGray[i, j]));
                        vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(img1.vImgGray[i, j]));
                        vImgResultA[i, j] = Convert.ToByte(NormalizeRGB(img1.vImgA[i, j]));

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

        public Bitmap ToBinary(ProcessaImagem img1)
        {
            if (img1 != null)
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
            return null;
        }

        public Bitmap ToNegative(ProcessaImagem img1)
        {
            if (img1 != null)
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
                            Convert.ToByte(NormalizeRGB(maxR - vImgResultR[i, j])),
                            Convert.ToByte(NormalizeRGB(maxG - vImgResultG[i, j])),
                            Convert.ToByte(NormalizeRGB(maxB - vImgResultB[i, j]))
                            );

                        imgResultado.SetPixel(j, i, c);
                    }
                }

                return imgResultado;
            }
            return null;
        }

        public Object[] Histogram(ProcessaImagem img1)
        {
            if (img1 != null)
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
                int[,] equalizedImg = new int[img1.width, img1.height];

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

                for (int i = 0; i < img1.width; i++)
                {
                    for (int j = 0; j < img1.height; j++)
                    {
                        Color c = Color.FromArgb(equalizedImg[i, j], equalizedImg[i, j], equalizedImg[i, j]);
                        imgResultado.SetPixel(j, i, c);
                    }
                }

                Object[] array = { imgResultado, histogram, histogramFinalImg };

                return array;
            }
            return null;
        }

        //Image Filters
        public Bitmap ApplyFilter(ProcessaImagem img1, int maskSize = 3, int type = 1, int order = 0)
        {
            if(img1 != null)
            {
                Bitmap imgResultado = new Bitmap(img1.width, img1.height);
                byte[,] imgResultadoHelper = new byte[img1.height, img1.width];

                int maskI = 0;
                int maskJ = 0;

                if(maskSize == 3)
                {
                    maskI = 1;
                    maskJ = 1;

                } else if(maskSize == 5)
                {
                    maskI = 2;
                    maskJ = 2;

                } else if(maskSize == 7)
                {
                    maskI = 3;
                    maskJ = 3;
                }

                for (int i = maskI; i < (img1.height - maskI); i++)
                {
                    for (int j = maskJ; j < (img1.width - maskJ); j++)
                    {
                        byte[] mask = new byte[maskSize * maskSize];
                        int mean = 0;

                        for (int w = 0; w < mask.Length; w++) mask[w] = 1;

                        if (maskSize == 3)
                        {
                            mask[0] = (byte)(mask[0] * img1.vImgGray[i - 1, j - 1]);
                            mask[1] = (byte)(mask[1] * img1.vImgGray[i - 1, j]);
                            mask[2] = (byte)(mask[2] * img1.vImgGray[i - 1, j + 1]);

                            mask[3] = (byte)(mask[3] * img1.vImgGray[i, j - 1]);
                            mask[4] = (byte)(mask[4] * img1.vImgGray[i, j]);
                            mask[5] = (byte)(mask[5] * img1.vImgGray[i, j + 1]);

                            mask[6] = (byte)(mask[6] * img1.vImgGray[i + 1, j - 1]);
                            mask[7] = (byte)(mask[7] * img1.vImgGray[i + 1, j]);
                            mask[8] = (byte)(mask[8] * img1.vImgGray[i + 1, j + 1]);

                        }
                        else if (maskSize == 5)
                        {
                            mask[0] = (byte)(mask[0] * img1.vImgGray[i - 2, j - 2]);
                            mask[1] = (byte)(mask[1] * img1.vImgGray[i - 2, j - 1]);
                            mask[2] = (byte)(mask[2] * img1.vImgGray[i - 2, j]);
                            mask[3] = (byte)(mask[3] * img1.vImgGray[i - 2, j + 1]);
                            mask[4] = (byte)(mask[4] * img1.vImgGray[i - 2, j + 2]);

                            mask[5] = (byte)(mask[5] * img1.vImgGray[i - 1, j - 2]);
                            mask[6] = (byte)(mask[6] * img1.vImgGray[i - 1, j - 1]);
                            mask[7] = (byte)(mask[7] * img1.vImgGray[i - 1, j]);
                            mask[8] = (byte)(mask[8] * img1.vImgGray[i - 1, j + 1]);
                            mask[9] = (byte)(mask[9] * img1.vImgGray[i - 1, j + 2]);

                            mask[10] = (byte)(mask[10] * img1.vImgGray[i, j - 2]);
                            mask[11] = (byte)(mask[11] * img1.vImgGray[i, j - 1]);
                            mask[12] = (byte)(mask[12] * img1.vImgGray[i, j]);
                            mask[13] = (byte)(mask[13] * img1.vImgGray[i, j + 1]);
                            mask[14] = (byte)(mask[14] * img1.vImgGray[i, j + 2]);

                            mask[15] = (byte)(mask[15] * img1.vImgGray[i + 1, j - 2]);
                            mask[16] = (byte)(mask[16] * img1.vImgGray[i + 1, j - 1]);
                            mask[17] = (byte)(mask[17] * img1.vImgGray[i + 1, j]);
                            mask[18] = (byte)(mask[18] * img1.vImgGray[i + 1, j + 1]);
                            mask[19] = (byte)(mask[19] * img1.vImgGray[i + 1, j + 2]);

                            mask[20] = (byte)(mask[20] * img1.vImgGray[i + 2, j - 2]);
                            mask[21] = (byte)(mask[21] * img1.vImgGray[i + 2, j - 1]);
                            mask[22] = (byte)(mask[22] * img1.vImgGray[i + 2, j]);
                            mask[23] = (byte)(mask[23] * img1.vImgGray[i + 2, j + 1]);
                            mask[24] = (byte)(mask[24] * img1.vImgGray[i + 2, j + 2]);

                        }
                        else if(maskSize == 7)
                        {
                            mask[0] = (byte)(mask[0] * img1.vImgGray[i - 3, j - 3]);
                            mask[1] = (byte)(mask[1] * img1.vImgGray[i - 3, j - 2]);
                            mask[2] = (byte)(mask[2] * img1.vImgGray[i - 3, j - 1]);
                            mask[3] = (byte)(mask[3] * img1.vImgGray[i - 3, j]);
                            mask[4] = (byte)(mask[4] * img1.vImgGray[i - 3, j + 1]);
                            mask[5] = (byte)(mask[5] * img1.vImgGray[i - 3, j + 2]);
                            mask[6] = (byte)(mask[6] * img1.vImgGray[i - 3, j + 3]);

                            mask[7] = (byte)(mask[7] * img1.vImgGray[i - 2, j - 3]);
                            mask[8] = (byte)(mask[8] * img1.vImgGray[i - 2, j - 2]);
                            mask[9] = (byte)(mask[9] * img1.vImgGray[i - 2, j - 1]);
                            mask[10] = (byte)(mask[10] * img1.vImgGray[i - 2, j]);
                            mask[11] = (byte)(mask[11] * img1.vImgGray[i - 2, j + 1]);
                            mask[12] = (byte)(mask[12] * img1.vImgGray[i - 2, j + 2]);
                            mask[13] = (byte)(mask[13] * img1.vImgGray[i - 2, j + 3]);
                        
                            mask[14] = (byte)(mask[14] * img1.vImgGray[i - 1, j - 3]);
                            mask[15] = (byte)(mask[15] * img1.vImgGray[i - 1, j - 2]);
                            mask[16] = (byte)(mask[16] * img1.vImgGray[i - 1, j - 1]);
                            mask[17] = (byte)(mask[17] * img1.vImgGray[i - 1, j]);
                            mask[18] = (byte)(mask[18] * img1.vImgGray[i - 1, j + 1]);
                            mask[19] = (byte)(mask[19] * img1.vImgGray[i - 1, j + 2]);
                            mask[20] = (byte)(mask[20] * img1.vImgGray[i - 1, j + 3]);

                            mask[21] = (byte)(mask[21] * img1.vImgGray[i, j - 3]);
                            mask[22] = (byte)(mask[22] * img1.vImgGray[i, j - 2]);
                            mask[23] = (byte)(mask[23] * img1.vImgGray[i, j - 1]);
                            mask[24] = (byte)(mask[24] * img1.vImgGray[i, j]);
                            mask[25] = (byte)(mask[25] * img1.vImgGray[i, j + 1]);
                            mask[26] = (byte)(mask[26] * img1.vImgGray[i, j + 2]);
                            mask[27] = (byte)(mask[27] * img1.vImgGray[i, j + 3]);
                        
                            mask[28] = (byte)(mask[28] * img1.vImgGray[i + 1, j - 3]);
                            mask[29] = (byte)(mask[29] * img1.vImgGray[i + 1, j - 2]);
                            mask[30] = (byte)(mask[30] * img1.vImgGray[i + 1, j - 1]);
                            mask[31] = (byte)(mask[31] * img1.vImgGray[i + 1, j]);
                            mask[32] = (byte)(mask[32] * img1.vImgGray[i + 1, j + 1]);
                            mask[33] = (byte)(mask[33] * img1.vImgGray[i + 1, j + 2]);
                            mask[34] = (byte)(mask[34] * img1.vImgGray[i + 1, j + 3]);
                        
                            mask[35] = (byte)(mask[35] * img1.vImgGray[i + 2, j - 3]);
                            mask[36] = (byte)(mask[36] * img1.vImgGray[i + 2, j - 2]);
                            mask[37] = (byte)(mask[37] * img1.vImgGray[i + 2, j - 1]);
                            mask[38] = (byte)(mask[38] * img1.vImgGray[i + 2, j]);
                            mask[39] = (byte)(mask[39] * img1.vImgGray[i + 2, j + 1]);
                            mask[40] = (byte)(mask[40] * img1.vImgGray[i + 2, j + 2]);
                            mask[41] = (byte)(mask[41] * img1.vImgGray[i + 2, j + 3]);
                        
                            mask[42] = (byte)(mask[42] * img1.vImgGray[i + 3, j - 3]);
                            mask[43] = (byte)(mask[43] * img1.vImgGray[i + 3, j - 2]);
                            mask[44] = (byte)(mask[44] * img1.vImgGray[i + 3, j - 1]);
                            mask[45] = (byte)(mask[45] * img1.vImgGray[i + 3, j]);
                            mask[46] = (byte)(mask[46] * img1.vImgGray[i + 3, j + 1]);
                            mask[47] = (byte)(mask[47] * img1.vImgGray[i + 3, j + 2]);
                            mask[48] = (byte)(mask[48] * img1.vImgGray[i + 3, j + 3]);
                        }

                        if(type == 1)
                        {
                            byte filter = mask.Max();
                            imgResultadoHelper[j, i] = Convert.ToByte(filter);
                        }
                        else if (type == 2)
                        {
                            byte filter = mask.Min();
                            imgResultadoHelper[j, i] = Convert.ToByte(filter);
                        }
                        else if (type == 3)
                        {
                            for (int w = 0; w < mask.Length; w++)
                            {
                                mean = mean + mask[w];
                            }

                            mean = mean / mask.Length;

                            imgResultadoHelper[j, i] = Convert.ToByte(mean);
                        }
                        else if (type == 4)
                        {
                            Array.Sort(mask);
                            int selector = mask.Length / 2;
                            byte filter = mask[selector];
                            imgResultadoHelper[j, i] = Convert.ToByte(filter);
                        }
                        else if (type == 5)
                        {
                            int tam = mask.Length - 1;

                            if(order > tam)
                            {
                                order = tam;
                            }

                            if(order < 0)
                            {
                                order = 0;
                            }

                            Array.Sort(mask);
                            byte filter = mask[order];
                            imgResultadoHelper[j, i] = Convert.ToByte(filter);
                        }
                        else if (type == 6)
                        {
                            Array.Sort(mask);
                            byte max = mask.Max();
                            byte min = mask.Min();

                            int selector = mask.Length / 2;

                            byte filter = mask[selector];

                            if (mask[selector] > max)
                            {
                                filter = max;
                            }

                            if(mask[selector] < min)
                            {
                                filter = min;
                            }

                            imgResultadoHelper[j, i] = Convert.ToByte(filter);
                        }
                    }
                }

                for (int i = 0; i < img1.height; i++)
                {
                    for (int j = 0; j < img1.width; j++)
                    {
                        Color c = Color.FromArgb(imgResultadoHelper[j, i], imgResultadoHelper[j, i], imgResultadoHelper[j, i]);
                        imgResultado.SetPixel(j, i, c);
                    }
                }

                return imgResultado;
            }
            return null;
        }

        //Gaussiano
        public Object[] GaussianFilter(ProcessaImagem img1, double sigma)
        {
            if (img1 != null)
            {
                int width = img1.width;
                int height = img1.height;

                Bitmap imgResultado = new Bitmap(img1.width, img1.height);

                byte[,] vImgResultR = new byte[img1.height, img1.width];
                byte[,] vImgResultG = new byte[img1.height, img1.width];
                byte[,] vImgResultB = new byte[img1.height, img1.width];
                byte[,] vImgResultA = new byte[img1.height, img1.width];

                Object[] obj = GenerateGaussianKernel(sigma);

                double[,] kernel = (double[,])obj[0];

                int kernelSize = kernel.GetLength(0);
                int kernelOffset = kernelSize / 2;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        double redSum = 0;
                        double greenSum = 0;
                        double blueSum = 0;
                        double weightSum = 0;
                        double alpha = 1;

                        for (int ki = 0; ki < kernelSize; ki++)
                        {
                            int offsetI = i + ki - kernelOffset;

                            if (offsetI < 0 || offsetI >= height)
                            {
                                continue;
                            }

                            for (int kj = 0; kj < kernelSize; kj++)
                            {
                                int offsetJ = j + kj - kernelOffset;

                                if (offsetJ < 0 || offsetJ >= width)
                                {
                                    continue;
                                }

                                Color pixel = img1.img.GetPixel(offsetJ, offsetI);

                                double weight = kernel[ki, kj];

                                redSum += pixel.R * weight;
                                greenSum += pixel.G * weight;
                                blueSum += pixel.B * weight;
                                alpha = pixel.A;

                                weightSum += weight;
                            }
                        }

                        vImgResultR[i, j] = Convert.ToByte(NormalizeRGB(redSum / weightSum));
                        vImgResultG[i, j] = Convert.ToByte(NormalizeRGB(greenSum / weightSum));
                        vImgResultB[i, j] = Convert.ToByte(NormalizeRGB(blueSum / weightSum));
                        vImgResultA[i, j] = Convert.ToByte(NormalizeRGB(alpha));

                        Color c = Color.FromArgb(
                            vImgResultA[i, j],
                            vImgResultR[i, j],
                            vImgResultG[i, j],
                            vImgResultB[i, j]
                        );

                        imgResultado.SetPixel(j, i, c);
                    }
                }

                Object[] array = { imgResultado, (Bitmap)obj[1] };
                return array;
            }
            return null;
        }

        //Criar Kernel para Gaussiano
        private Object[] GenerateGaussianKernel(double sigma)
        {

            int size = (int)Math.Ceiling(sigma) * 2 + 1;

            double[,] kernel = new double[size, size];
            Bitmap kernelImage = new Bitmap(size, size);

            double sum = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    double exponent = -((j - size / 2) * (j - size / 2) + (i - size / 2) * (i - size / 2)) / (2 * sigma * sigma);
                    double weight = Math.Exp(exponent);
                    kernel[i, j] = weight;
                    sum += weight;
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    kernel[i, j] /= sum;
                }
            }

            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    Color ck = Color.FromArgb(
                        (int)NormalizeRGB(kernel[i, j]),
                        (int)NormalizeRGB(kernel[i, j]),
                        (int)NormalizeRGB(kernel[i, j])
                    );

                    kernelImage.SetPixel(j, i, ck);
                }
            }

            Object[] array = { kernel, kernelImage };
            return array;
        }

        //Trabalho Final
        //Erosão
        public Bitmap Erosao(ProcessaImagem img1, int matrixSize, int operation, bool applyR, bool applyG, bool applyB)
        {
            if (img1 != null)
            {
                Bitmap sourceBitmap = img1.img;

                Bitmap imgResultado = new Bitmap(img1.width, img1.height);

                BitmapData sourceData =
                           sourceBitmap.LockBits(new Rectangle(0, 0,
                           sourceBitmap.Width, sourceBitmap.Height),
                           ImageLockMode.ReadOnly,
                           PixelFormat.Format32bppArgb
                );

                byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
                byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

                Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

                sourceBitmap.UnlockBits(sourceData);

                int filterOffset = (matrixSize - 1) / 2;
                int calcOffset = 0;

                int byteOffset = 0;

                byte blue = 0;
                byte green = 0;
                byte red = 0;

                byte morphResetValue = 0;

                //Erosao
                if (operation == 1)
                {
                    morphResetValue = 255;
                }

                for (int offsetY = filterOffset; offsetY < sourceBitmap.Height - filterOffset; offsetY++)
                {
                    for (int offsetX = filterOffset; offsetX < sourceBitmap.Width - filterOffset; offsetX++)
                    {
                        byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                        blue = morphResetValue;
                        green = morphResetValue;
                        red = morphResetValue;

                        //Dilatacao
                        if(operation == 0)
                        {
                            for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                            {
                                for (int filterX = -filterOffset;
                                    filterX <= filterOffset; filterX++)
                                {
                                    calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);

                                    if (pixelBuffer[calcOffset] > blue)
                                    {
                                        blue = pixelBuffer[calcOffset];
                                    }

                                    if (pixelBuffer[calcOffset + 1] > green)
                                    {
                                        green = pixelBuffer[calcOffset + 1];
                                    }

                                    if (pixelBuffer[calcOffset + 2] > red)
                                    {
                                        red = pixelBuffer[calcOffset + 2];
                                    }
                                }
                            }
                        }
                        else if(operation == 1)
                        {
                            for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                            {
                                for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                                {
                                    calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);

                                    if (pixelBuffer[calcOffset] < blue)
                                    {
                                        blue = pixelBuffer[calcOffset];
                                    }

                                    if (pixelBuffer[calcOffset + 1] < green)
                                    {
                                        green = pixelBuffer[calcOffset + 1];
                                    }

                                    if (pixelBuffer[calcOffset + 2] < red)
                                    {
                                        red = pixelBuffer[calcOffset + 2];
                                    }
                                }
                            }
                        }

                        //Cores que serão aplicadas
                        if (applyR)
                        {
                            red = (byte)NormalizeRGB(pixelBuffer[byteOffset + 2]);
                        }
                        if (applyG)
                        {
                            green = (byte)NormalizeRGB(pixelBuffer[byteOffset + 1]);
                        }
                        if (applyB)
                        {
                            blue = (byte)NormalizeRGB(pixelBuffer[byteOffset]);
                        }

                        resultBuffer[byteOffset] = blue;
                        resultBuffer[byteOffset + 1] = green;
                        resultBuffer[byteOffset + 2] = red;
                        resultBuffer[byteOffset + 3] = 255;
                    }
                }

                BitmapData resultData =
                   imgResultado.LockBits(new Rectangle(0, 0,
                   imgResultado.Width, imgResultado.Height),
                   ImageLockMode.WriteOnly,
                   PixelFormat.Format32bppArgb
                );

                Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);

                imgResultado.UnlockBits(resultData);

                return imgResultado;
            }

            return null;
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

        public bool CheckImages(ProcessaImagem img1 = null, ProcessaImagem img2 = null)
        {
            if(img1 == null || img2 == null)
            {
                MessageBox.Show("Imagens VAZIAS!");
                return false;
            }

            if (img1.img.Width != img2.img.Width || img1.img.Height != img2.img.Height || img1.img.PixelFormat != img1.img.PixelFormat)
            {
                MessageBox.Show("As imagens precisam ter o mesmo tamanho e formato");
                return false;
            }

            return true;
        }
    }
}
