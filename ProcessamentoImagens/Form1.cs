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
            picBox3.Image = new Bitmap(imgResultado);
        }

        private void bt_Subt_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.SubtImages(Processa1, Processa2);
            picBox3.Image = new Bitmap(imgResultado);
        }

        private void bt_NOT_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.LogicNOT(Processa1, Processa2);
            picBox3.Image = new Bitmap(imgResultado);
        }

        private void bt_Mult_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            //int multiplicador = Convert.ToInt32(nm_Mult.Value);
            Bitmap imgResultado = ProcessaHelper.MultImages(Processa1, Processa2);
            picBox3.Image = new Bitmap(imgResultado);
        }

        private void bt_Med_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.MedImages(Processa1, Processa2);
            picBox3.Image = new Bitmap(imgResultado);
        }

        private void bt_Div_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.DivImages(Processa1, Processa2);
            picBox3.Image = new Bitmap(imgResultado);
        }

        private void bt_Blend_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            int scalar = Convert.ToInt32(nm_Blend.Value);
            Bitmap imgResultado = ProcessaHelper.BlendImages(Processa1, Processa2, scalar);
            picBox3.Image = new Bitmap(imgResultado);
        }

        private void bt_AND_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.LogicAND(Processa1, Processa2);
            picBox3.Image = new Bitmap(imgResultado);
        }

        private void bt_OR_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.LogicOR(Processa1, Processa2);
            picBox3.Image = new Bitmap(imgResultado);
        }

        private void bt_XOR_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.LogicXOR(Processa1, Processa2);
            picBox3.Image = new Bitmap(imgResultado);
        }

        private void bt_saveResult_Click(object sender, EventArgs e)
        {

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
                picBox3.Image = new Bitmap(imgResultado);
            }
        }

        private void bt_espelhar_Click(object sender, EventArgs e)
        {
            ProcessaHelper = new ProcessaImagem(bmpHelper);
            Bitmap imgResultado = ProcessaHelper.MirrorImg(Processa1);
            picBox3.Image = new Bitmap(imgResultado);
        }
    }
}
