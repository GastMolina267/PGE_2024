using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea09
{
    public partial class FormFileManager : Form
    {
        public FormFileManager()
        {
            InitializeComponent();
        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            FormMain mainForm = new FormMain();
            mainForm.Show(); // Vuelve al menú principal
            this.Close(); // Cierra la ventana actual
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "archivoEjemplo.txt";
                File.WriteAllText(filePath, "Este es un ejemplo de texto en el archivo.");
                MessageBox.Show("Archivo creado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "archivoEjemplo.txt";
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    MessageBox.Show(content);
                }
                else
                {
                    MessageBox.Show("El archivo no existe");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }

}
