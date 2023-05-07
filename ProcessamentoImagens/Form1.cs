using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProcessamentoImagens
{
    public partial class Form1 : Form
    {
        private Bitmap img1;
        private Bitmap img2;

        private ProcessaImagem Processa1;
        private ProcessaImagem Processa2;
        private ProcessaImagem ProcessaHelper;

        Bitmap bmpHelper = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void bt_load1_Click(object sender, EventArgs e)
        {
            //Abre caixa de diálogo 
            OpenFileDialog open = new OpenFileDialog();
            //Extensões Utilizáveis
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.tif)|*.jpg; *.jpeg; *.gif; *.bmp; *.tif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                //Salva Imagem
                img1 = new Bitmap(open.FileName);

                Processa1 = new ProcessaImagem(img1);
                Console.Write(Processa1.vImgR[1,1]);

                //Mostra Imagem
                picBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void bt_load2_Click(object sender, EventArgs e)
        {
            //Abre caixa de diálogo 
            OpenFileDialog open = new OpenFileDialog();
            //Extensões Utilizáveis
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.tif)|*.jpg; *.jpeg; *.gif; *.bmp; *.tif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                //Salva Imagem
                img2 = new Bitmap(open.FileName);

                Processa2 = new ProcessaImagem(img2);

                //Mostra Imagem
                picBox2.Image = new Bitmap(open.FileName);
            }
        }

        private void bt_adicao_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.AddImages(Processa1, Processa2);
            if(imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_Subt_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.SubtImages(Processa1, Processa2);
            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_NOT_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.LogicNOT(Processa1, Processa2);
            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_Mult_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.MultImages(Processa1, Processa2);
            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_Med_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.MedImages(Processa1, Processa2);
            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_Div_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.DivImages(Processa1, Processa2);
            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_Blend_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            int scalar = Convert.ToInt32(nm_Blend.Value);
            Bitmap imgResultado = ProcessaHelper.BlendImages(Processa1, Processa2, scalar);
            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_AND_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.LogicAND(Processa1, Processa2);
            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_OR_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.LogicOR(Processa1, Processa2);
            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_XOR_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.LogicXOR(Processa1, Processa2);
            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_saveResult_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                picBox3.Image.Save(dialog.FileName, ImageFormat.Jpeg);
            }
        }

        private void bt_randMat_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            int size = Convert.ToInt32(nm_tam.Value);
            if (size <= 0)
            {
                MessageBox.Show("Insira um tamanho Válido!", "Tamanho Inválido",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Bitmap imgResultado = ProcessaHelper.RandomCreateAdd(size);
                if (imgResultado != null)
                {
                    picBox3.Image = new Bitmap(imgResultado);
                }
            }
        }

        private void bt_espelhar_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.MirrorImgUD(Processa1);
            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_espelharLR_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.MirrorImgLR(Processa1);
            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_grayscale_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.ToGrayscale(Processa1);
            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_binario_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.ToBinary(Processa1);
            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_neg_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.ToNegative(Processa1);
            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_hist_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Object[] obj = ProcessaHelper.Histogram(Processa1);
            Bitmap imgResultado = (Bitmap)obj[0];

            if (imgResultado != null)
            {
                int[] histogram = (int[])obj[1];
                int[] histogramFinalImg = (int[])obj[2];

                hist1.Series.Clear();
                hist1.Series.Add("Histograma");
                hist1.Series["Histograma"].ChartType = SeriesChartType.Column;
                hist1.Series["Histograma"].Points.DataBindY(histogram);
                hist1.ChartAreas[0].AxisY.Maximum = histogram.Max() + 10;

                hist2.Series.Clear();
                hist2.Series.Add("ImgResult");
                hist2.Series["ImgResult"].ChartType = SeriesChartType.Column;
                hist2.Series["ImgResult"].Points.DataBindY(histogramFinalImg);
                hist2.ChartAreas[0].AxisY.Maximum = histogramFinalImg.Max() + 10;
                
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_filter_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);

            int maskSize = 3;
            int tipoFiltro = 1;

            //Filter Size (3x3, 5x5, 7x7)
            if (rd_3_3.Checked)
            {
                maskSize = 3;
            }
            else if (rd_5_5.Checked)
            {
                maskSize = 5;
            }
            else if (rd_7_7.Checked)
            {
                maskSize = 7;
            }

            //Filter Type (MAX, MIN, MED)
            if (rd_max.Checked)
            {
                tipoFiltro = 1;
            }
            else if (rd_min.Checked)
            {
                tipoFiltro = 2;
            }
            else if (rd_med.Checked)
            {
                tipoFiltro = 3;
            }

            Bitmap imgResultado = ProcessaHelper.ApplyFilter(Processa1, maskSize, tipoFiltro);

            if (imgResultado != null)
            {
                picBox3.Image = new Bitmap(imgResultado);
            }
        }
    }
}
