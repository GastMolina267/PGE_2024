using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertirTemperatura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Evento del botón para convertir Celsius a Fahrenheit
        private void btnConvertir_Click(object sender, EventArgs e)
        {
            // Validar que el TextBox no esté vacío y sea un número válido
            if (double.TryParse(txtCelsius.Text, out double celsius))
            {
                // Realizar la conversión de Celsius a Fahrenheit
                double fahrenheit = (celsius * 9 / 5) + 32;

                // Mostrar el resultado en el Label
                lblResultado.Text = $"Temperatura en Fahrenheit: {fahrenheit:F2}°F";
            }
            else
            {
                // Mostrar mensaje de error si la entrada no es válida
                MessageBox.Show("Por favor, ingrese un valor numérico válido para la temperatura en Celsius.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
