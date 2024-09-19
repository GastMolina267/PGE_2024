using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace EditorDeImagenes
{
    public partial class Form1 : Form
    {
        private Image imagenOriginal;
        private Image imagenModificada;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnCargarImagen = new System.Windows.Forms.Button();
            this.btnCambiarTamano = new System.Windows.Forms.Button();
            this.btnAjustarBrillo = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.trackBarBrillo = new System.Windows.Forms.TrackBar();
            this.numericUpDownAncho = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAlto = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrillo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAncho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.Location = new System.Drawing.Point(12, 12);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(120, 23);
            this.btnCargarImagen.Text = "Cargar Imagen";
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // btnCambiarTamano
            // 
            this.btnCambiarTamano.Location = new System.Drawing.Point(12, 41);
            this.btnCambiarTamano.Name = "btnCambiarTamano";
            this.btnCambiarTamano.Size = new System.Drawing.Size(120, 23);
            this.btnCambiarTamano.Text = "Cambiar Tamaño";
            this.btnCambiarTamano.Click += new System.EventHandler(this.btnCambiarTamano_Click);
            // 
            // btnAjustarBrillo
            // 
            this.btnAjustarBrillo.Location = new System.Drawing.Point(12, 70);
            this.btnAjustarBrillo.Name = "btnAjustarBrillo";
            this.btnAjustarBrillo.Size = new System.Drawing.Size(120, 23);
            this.btnAjustarBrillo.Text = "Ajustar Brillo";
            this.btnAjustarBrillo.Click += new System.EventHandler(this.btnAjustarBrillo_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(138, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 300);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // trackBarBrillo
            // 
            this.trackBarBrillo.Location = new System.Drawing.Point(12, 99);
            this.trackBarBrillo.Maximum = 100;
            this.trackBarBrillo.Minimum = -100;
            this.trackBarBrillo.Name = "trackBarBrillo";
            this.trackBarBrillo.Size = new System.Drawing.Size(120, 45);
            // 
            // numericUpDownAncho
            // 
            this.numericUpDownAncho.Location = new System.Drawing.Point(12, 150);
            this.numericUpDownAncho.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numericUpDownAncho.Name = "numericUpDownAncho";
            this.numericUpDownAncho.Size = new System.Drawing.Size(60, 20);
            // 
            // numericUpDownAlto
            // 
            this.numericUpDownAlto.Location = new System.Drawing.Point(72, 150);
            this.numericUpDownAlto.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numericUpDownAlto.Name = "numericUpDownAlto";
            this.numericUpDownAlto.Size = new System.Drawing.Size(60, 20);
            // 
            // FormEditorImagenes
            // 
            this.ClientSize = new System.Drawing.Size(550, 324);
            this.Controls.Add(this.btnCargarImagen);
            this.Controls.Add(this.btnCambiarTamano);
            this.Controls.Add(this.btnAjustarBrillo);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.trackBarBrillo);
            this.Controls.Add(this.numericUpDownAncho);
            this.Controls.Add(this.numericUpDownAlto);
            this.Name = "FormEditorImagenes";
            this.Text = "Editor de Imágenes";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrillo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAncho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnCargarImagen;
        private System.Windows.Forms.Button btnCambiarTamano;
        private System.Windows.Forms.Button btnAjustarBrillo;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TrackBar trackBarBrillo;
        private System.Windows.Forms.NumericUpDown numericUpDownAncho;
        private System.Windows.Forms.NumericUpDown numericUpDownAlto;

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagenOriginal = Image.FromFile(openFileDialog.FileName);
                    imagenModificada = (Image)imagenOriginal.Clone();
                    pictureBox.Image = imagenModificada;
                    numericUpDownAncho.Value = imagenOriginal.Width;
                    numericUpDownAlto.Value = imagenOriginal.Height;
                }
            }
        }

        private void btnCambiarTamano_Click(object sender, EventArgs e)
        {
            if (imagenOriginal != null)
            {
                int nuevoAncho = (int)numericUpDownAncho.Value;
                int nuevoAlto = (int)numericUpDownAlto.Value;
                imagenModificada = new Bitmap(imagenOriginal, nuevoAncho, nuevoAlto);
                pictureBox.Image = imagenModificada;
            }
        }

        private void btnAjustarBrillo_Click(object sender, EventArgs e)
        {
            if (imagenOriginal != null)
            {
                float brillo = (float)trackBarBrillo.Value / 100f;
                imagenModificada = AjustarBrillo((Bitmap)imagenOriginal, brillo);
                pictureBox.Image = imagenModificada;
            }
        }

        private Bitmap AjustarBrillo(Bitmap original, float brillo)
        {
            Bitmap ajustada = new Bitmap(original.Width, original.Height);
            float factor = 1f + brillo;

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color colorOriginal = original.GetPixel(x, y);
                    int r = Math.Min(255, Math.Max(0, (int)(colorOriginal.R * factor)));
                    int g = Math.Min(255, Math.Max(0, (int)(colorOriginal.G * factor)));
                    int b = Math.Min(255, Math.Max(0, (int)(colorOriginal.B * factor)));
                    ajustada.SetPixel(x, y, Color.FromArgb(colorOriginal.A, r, g, b));
                }
            }

            return ajustada;
        }
    }
}