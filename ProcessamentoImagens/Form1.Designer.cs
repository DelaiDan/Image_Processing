namespace ProcessamentoImagens
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBox1 = new System.Windows.Forms.PictureBox();
            this.picBox2 = new System.Windows.Forms.PictureBox();
            this.picBox3 = new System.Windows.Forms.PictureBox();
            this.bt_load1 = new System.Windows.Forms.Button();
            this.bt_load2 = new System.Windows.Forms.Button();
            this.bt_saveResult = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nm_mult = new System.Windows.Forms.NumericUpDown();
            this.nm_div = new System.Windows.Forms.NumericUpDown();
            this.nm_Blend = new System.Windows.Forms.NumericUpDown();
            this.bt_Blend = new System.Windows.Forms.Button();
            this.bt_Med = new System.Windows.Forms.Button();
            this.bt_Div = new System.Windows.Forms.Button();
            this.bt_Mult = new System.Windows.Forms.Button();
            this.bt_Subt = new System.Windows.Forms.Button();
            this.bt_adicao = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bt_XOR = new System.Windows.Forms.Button();
            this.bt_NOT = new System.Windows.Forms.Button();
            this.bt_OR = new System.Windows.Forms.Button();
            this.bt_AND = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.bt_espelharLR = new System.Windows.Forms.Button();
            this.bt_espelharUD = new System.Windows.Forms.Button();
            this.lb_tam = new System.Windows.Forms.Label();
            this.nm_tam = new System.Windows.Forms.NumericUpDown();
            this.bt_randMat = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.bt_neg = new System.Windows.Forms.Button();
            this.bt_binario = new System.Windows.Forms.Button();
            this.bt_grayscale = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.bt_hist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox3)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_mult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_div)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_Blend)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_tam)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox1
            // 
            this.picBox1.Location = new System.Drawing.Point(6, 21);
            this.picBox1.Name = "picBox1";
            this.picBox1.Size = new System.Drawing.Size(286, 309);
            this.picBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox1.TabIndex = 0;
            this.picBox1.TabStop = false;
            // 
            // picBox2
            // 
            this.picBox2.Location = new System.Drawing.Point(5, 21);
            this.picBox2.Name = "picBox2";
            this.picBox2.Size = new System.Drawing.Size(287, 309);
            this.picBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox2.TabIndex = 1;
            this.picBox2.TabStop = false;
            // 
            // picBox3
            // 
            this.picBox3.Location = new System.Drawing.Point(6, 21);
            this.picBox3.Name = "picBox3";
            this.picBox3.Size = new System.Drawing.Size(286, 309);
            this.picBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox3.TabIndex = 2;
            this.picBox3.TabStop = false;
            // 
            // bt_load1
            // 
            this.bt_load1.Location = new System.Drawing.Point(6, 336);
            this.bt_load1.Name = "bt_load1";
            this.bt_load1.Size = new System.Drawing.Size(286, 33);
            this.bt_load1.TabIndex = 3;
            this.bt_load1.Text = "Carregar Imagem 1";
            this.bt_load1.UseVisualStyleBackColor = true;
            this.bt_load1.Click += new System.EventHandler(this.bt_load1_Click);
            // 
            // bt_load2
            // 
            this.bt_load2.Location = new System.Drawing.Point(5, 336);
            this.bt_load2.Name = "bt_load2";
            this.bt_load2.Size = new System.Drawing.Size(287, 33);
            this.bt_load2.TabIndex = 4;
            this.bt_load2.Text = "Carregar Imagem 2";
            this.bt_load2.UseVisualStyleBackColor = true;
            this.bt_load2.Click += new System.EventHandler(this.bt_load2_Click);
            // 
            // bt_saveResult
            // 
            this.bt_saveResult.Location = new System.Drawing.Point(6, 336);
            this.bt_saveResult.Name = "bt_saveResult";
            this.bt_saveResult.Size = new System.Drawing.Size(286, 33);
            this.bt_saveResult.TabIndex = 5;
            this.bt_saveResult.Text = "Salvar Imagem";
            this.bt_saveResult.UseVisualStyleBackColor = true;
            this.bt_saveResult.Click += new System.EventHandler(this.bt_saveResult_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nm_mult);
            this.groupBox1.Controls.Add(this.nm_div);
            this.groupBox1.Controls.Add(this.nm_Blend);
            this.groupBox1.Controls.Add(this.bt_Blend);
            this.groupBox1.Controls.Add(this.bt_Med);
            this.groupBox1.Controls.Add(this.bt_Div);
            this.groupBox1.Controls.Add(this.bt_Mult);
            this.groupBox1.Controls.Add(this.bt_Subt);
            this.groupBox1.Controls.Add(this.bt_adicao);
            this.groupBox1.Location = new System.Drawing.Point(620, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 269);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operações Aritméticas";
            // 
            // nm_mult
            // 
            this.nm_mult.Location = new System.Drawing.Point(183, 105);
            this.nm_mult.Name = "nm_mult";
            this.nm_mult.Size = new System.Drawing.Size(84, 22);
            this.nm_mult.TabIndex = 18;
            // 
            // nm_div
            // 
            this.nm_div.Location = new System.Drawing.Point(183, 144);
            this.nm_div.Name = "nm_div";
            this.nm_div.Size = new System.Drawing.Size(84, 22);
            this.nm_div.TabIndex = 17;
            // 
            // nm_Blend
            // 
            this.nm_Blend.Location = new System.Drawing.Point(183, 222);
            this.nm_Blend.Name = "nm_Blend";
            this.nm_Blend.Size = new System.Drawing.Size(84, 22);
            this.nm_Blend.TabIndex = 16;
            // 
            // bt_Blend
            // 
            this.bt_Blend.Location = new System.Drawing.Point(6, 216);
            this.bt_Blend.Name = "bt_Blend";
            this.bt_Blend.Size = new System.Drawing.Size(159, 33);
            this.bt_Blend.TabIndex = 10;
            this.bt_Blend.Text = "Blending";
            this.bt_Blend.UseVisualStyleBackColor = true;
            this.bt_Blend.Click += new System.EventHandler(this.bt_Blend_Click);
            // 
            // bt_Med
            // 
            this.bt_Med.Location = new System.Drawing.Point(6, 177);
            this.bt_Med.Name = "bt_Med";
            this.bt_Med.Size = new System.Drawing.Size(159, 33);
            this.bt_Med.TabIndex = 9;
            this.bt_Med.Text = "Média";
            this.bt_Med.UseVisualStyleBackColor = true;
            this.bt_Med.Click += new System.EventHandler(this.bt_Med_Click);
            // 
            // bt_Div
            // 
            this.bt_Div.Location = new System.Drawing.Point(6, 138);
            this.bt_Div.Name = "bt_Div";
            this.bt_Div.Size = new System.Drawing.Size(159, 33);
            this.bt_Div.TabIndex = 8;
            this.bt_Div.Text = "Divisão";
            this.bt_Div.UseVisualStyleBackColor = true;
            this.bt_Div.Click += new System.EventHandler(this.bt_Div_Click);
            // 
            // bt_Mult
            // 
            this.bt_Mult.Location = new System.Drawing.Point(6, 99);
            this.bt_Mult.Name = "bt_Mult";
            this.bt_Mult.Size = new System.Drawing.Size(159, 33);
            this.bt_Mult.TabIndex = 7;
            this.bt_Mult.Text = "Multiplicação";
            this.bt_Mult.UseVisualStyleBackColor = true;
            this.bt_Mult.Click += new System.EventHandler(this.bt_Mult_Click);
            // 
            // bt_Subt
            // 
            this.bt_Subt.Location = new System.Drawing.Point(6, 60);
            this.bt_Subt.Name = "bt_Subt";
            this.bt_Subt.Size = new System.Drawing.Size(159, 33);
            this.bt_Subt.TabIndex = 6;
            this.bt_Subt.Text = "Substração";
            this.bt_Subt.UseVisualStyleBackColor = true;
            this.bt_Subt.Click += new System.EventHandler(this.bt_Subt_Click);
            // 
            // bt_adicao
            // 
            this.bt_adicao.Location = new System.Drawing.Point(6, 21);
            this.bt_adicao.Name = "bt_adicao";
            this.bt_adicao.Size = new System.Drawing.Size(159, 33);
            this.bt_adicao.TabIndex = 5;
            this.bt_adicao.Text = "Adição";
            this.bt_adicao.UseVisualStyleBackColor = true;
            this.bt_adicao.Click += new System.EventHandler(this.bt_adicao_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picBox1);
            this.groupBox2.Controls.Add(this.bt_load1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 376);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Imagem 1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picBox2);
            this.groupBox3.Controls.Add(this.bt_load2);
            this.groupBox3.Location = new System.Drawing.Point(316, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 376);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Imagem 2";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.picBox3);
            this.groupBox4.Controls.Add(this.bt_saveResult);
            this.groupBox4.Location = new System.Drawing.Point(974, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(298, 376);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Resultado";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bt_XOR);
            this.groupBox5.Controls.Add(this.bt_NOT);
            this.groupBox5.Controls.Add(this.bt_OR);
            this.groupBox5.Controls.Add(this.bt_AND);
            this.groupBox5.Location = new System.Drawing.Point(620, 287);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(348, 101);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Operações Lógicas";
            // 
            // bt_XOR
            // 
            this.bt_XOR.Location = new System.Drawing.Point(183, 60);
            this.bt_XOR.Name = "bt_XOR";
            this.bt_XOR.Size = new System.Drawing.Size(159, 33);
            this.bt_XOR.TabIndex = 8;
            this.bt_XOR.Text = "XOR";
            this.bt_XOR.UseVisualStyleBackColor = true;
            this.bt_XOR.Click += new System.EventHandler(this.bt_XOR_Click);
            // 
            // bt_NOT
            // 
            this.bt_NOT.Location = new System.Drawing.Point(183, 21);
            this.bt_NOT.Name = "bt_NOT";
            this.bt_NOT.Size = new System.Drawing.Size(159, 33);
            this.bt_NOT.TabIndex = 7;
            this.bt_NOT.Text = "NOT";
            this.bt_NOT.UseVisualStyleBackColor = true;
            this.bt_NOT.Click += new System.EventHandler(this.bt_NOT_Click);
            // 
            // bt_OR
            // 
            this.bt_OR.Location = new System.Drawing.Point(6, 61);
            this.bt_OR.Name = "bt_OR";
            this.bt_OR.Size = new System.Drawing.Size(159, 33);
            this.bt_OR.TabIndex = 6;
            this.bt_OR.Text = "OR";
            this.bt_OR.UseVisualStyleBackColor = true;
            this.bt_OR.Click += new System.EventHandler(this.bt_OR_Click);
            // 
            // bt_AND
            // 
            this.bt_AND.Location = new System.Drawing.Point(6, 21);
            this.bt_AND.Name = "bt_AND";
            this.bt_AND.Size = new System.Drawing.Size(159, 33);
            this.bt_AND.TabIndex = 5;
            this.bt_AND.Text = "AND";
            this.bt_AND.UseVisualStyleBackColor = true;
            this.bt_AND.Click += new System.EventHandler(this.bt_AND_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.bt_espelharLR);
            this.groupBox6.Controls.Add(this.bt_espelharUD);
            this.groupBox6.Controls.Add(this.lb_tam);
            this.groupBox6.Controls.Add(this.nm_tam);
            this.groupBox6.Controls.Add(this.bt_randMat);
            this.groupBox6.Location = new System.Drawing.Point(620, 394);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(348, 100);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Operações Adicionais";
            // 
            // bt_espelharLR
            // 
            this.bt_espelharLR.Location = new System.Drawing.Point(183, 61);
            this.bt_espelharLR.Name = "bt_espelharLR";
            this.bt_espelharLR.Size = new System.Drawing.Size(159, 33);
            this.bt_espelharLR.TabIndex = 20;
            this.bt_espelharLR.Text = "Espelhar E/D";
            this.bt_espelharLR.UseVisualStyleBackColor = true;
            this.bt_espelharLR.Click += new System.EventHandler(this.bt_espelharLR_Click);
            // 
            // bt_espelharUD
            // 
            this.bt_espelharUD.Location = new System.Drawing.Point(6, 61);
            this.bt_espelharUD.Name = "bt_espelharUD";
            this.bt_espelharUD.Size = new System.Drawing.Size(159, 33);
            this.bt_espelharUD.TabIndex = 19;
            this.bt_espelharUD.Text = "Espelhar C/B";
            this.bt_espelharUD.UseVisualStyleBackColor = true;
            this.bt_espelharUD.Click += new System.EventHandler(this.bt_espelhar_Click);
            // 
            // lb_tam
            // 
            this.lb_tam.AutoSize = true;
            this.lb_tam.Location = new System.Drawing.Point(178, 29);
            this.lb_tam.Name = "lb_tam";
            this.lb_tam.Size = new System.Drawing.Size(68, 16);
            this.lb_tam.TabIndex = 18;
            this.lb_tam.Text = "Tamanho:";
            // 
            // nm_tam
            // 
            this.nm_tam.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nm_tam.Location = new System.Drawing.Point(252, 27);
            this.nm_tam.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nm_tam.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nm_tam.Name = "nm_tam";
            this.nm_tam.Size = new System.Drawing.Size(84, 22);
            this.nm_tam.TabIndex = 17;
            this.nm_tam.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bt_randMat
            // 
            this.bt_randMat.Location = new System.Drawing.Point(6, 21);
            this.bt_randMat.Name = "bt_randMat";
            this.bt_randMat.Size = new System.Drawing.Size(159, 33);
            this.bt_randMat.TabIndex = 9;
            this.bt_randMat.Text = "Matrizes Aleatórias";
            this.bt_randMat.UseVisualStyleBackColor = true;
            this.bt_randMat.Click += new System.EventHandler(this.bt_randMat_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.bt_neg);
            this.groupBox7.Controls.Add(this.bt_binario);
            this.groupBox7.Controls.Add(this.bt_grayscale);
            this.groupBox7.Location = new System.Drawing.Point(18, 394);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(112, 141);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Converter";
            // 
            // bt_neg
            // 
            this.bt_neg.Location = new System.Drawing.Point(6, 99);
            this.bt_neg.Name = "bt_neg";
            this.bt_neg.Size = new System.Drawing.Size(102, 33);
            this.bt_neg.TabIndex = 11;
            this.bt_neg.Text = "Negativo";
            this.bt_neg.UseVisualStyleBackColor = true;
            this.bt_neg.Click += new System.EventHandler(this.bt_neg_Click);
            // 
            // bt_binario
            // 
            this.bt_binario.Location = new System.Drawing.Point(6, 60);
            this.bt_binario.Name = "bt_binario";
            this.bt_binario.Size = new System.Drawing.Size(102, 33);
            this.bt_binario.TabIndex = 10;
            this.bt_binario.Text = "Binário";
            this.bt_binario.UseVisualStyleBackColor = true;
            this.bt_binario.Click += new System.EventHandler(this.bt_binario_Click);
            // 
            // bt_grayscale
            // 
            this.bt_grayscale.Location = new System.Drawing.Point(6, 21);
            this.bt_grayscale.Name = "bt_grayscale";
            this.bt_grayscale.Size = new System.Drawing.Size(102, 33);
            this.bt_grayscale.TabIndex = 9;
            this.bt_grayscale.Text = "Grayscale";
            this.bt_grayscale.UseVisualStyleBackColor = true;
            this.bt_grayscale.Click += new System.EventHandler(this.bt_grayscale_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.bt_hist);
            this.groupBox8.Location = new System.Drawing.Point(198, 394);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(112, 141);
            this.groupBox8.TabIndex = 14;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Outras";
            // 
            // bt_hist
            // 
            this.bt_hist.Location = new System.Drawing.Point(6, 21);
            this.bt_hist.Name = "bt_hist";
            this.bt_hist.Size = new System.Drawing.Size(102, 33);
            this.bt_hist.TabIndex = 9;
            this.bt_hist.Text = "Histograma";
            this.bt_hist.UseVisualStyleBackColor = true;
            this.bt_hist.Click += new System.EventHandler(this.bt_hist_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 583);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Processamento de Imagens";
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nm_mult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_div)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_Blend)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_tam)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox1;
        private System.Windows.Forms.PictureBox picBox2;
        private System.Windows.Forms.PictureBox picBox3;
        private System.Windows.Forms.Button bt_load1;
        private System.Windows.Forms.Button bt_load2;
        private System.Windows.Forms.Button bt_saveResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bt_adicao;
        private System.Windows.Forms.Button bt_Blend;
        private System.Windows.Forms.Button bt_Med;
        private System.Windows.Forms.Button bt_Div;
        private System.Windows.Forms.Button bt_Mult;
        private System.Windows.Forms.Button bt_Subt;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button bt_XOR;
        private System.Windows.Forms.Button bt_NOT;
        private System.Windows.Forms.Button bt_OR;
        private System.Windows.Forms.Button bt_AND;
        private System.Windows.Forms.NumericUpDown nm_Blend;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button bt_randMat;
        private System.Windows.Forms.Label lb_tam;
        private System.Windows.Forms.NumericUpDown nm_tam;
        private System.Windows.Forms.Button bt_espelharUD;
        private System.Windows.Forms.Button bt_espelharLR;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button bt_grayscale;
        private System.Windows.Forms.NumericUpDown nm_mult;
        private System.Windows.Forms.NumericUpDown nm_div;
        private System.Windows.Forms.Button bt_binario;
        private System.Windows.Forms.Button bt_neg;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button bt_hist;
    }
}

