using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroDeGastos
{
    public partial class Form1 : Form
    {
        // Lista para almacenar los gastos
        private List<Gasto> listaGastos = new List<Gasto>();

        // Constructor
        public Form1()
        {
            InitializeComponent();
            // Inicializar el ComboBox con las opciones de moneda
            cbMoneda.Items.Add("USD");
            cbMoneda.Items.Add("EUR");
            cbMoneda.Items.Add("MXN");  // Moneda local
            cbMoneda.SelectedIndex = 0; // Seleccionar por defecto USD

            // Definir las columnas del DataGridView si no se definen en el diseñador
            dgvGastos.ColumnCount = 2;
            dgvGastos.Columns[0].Name = "Descripción";
            dgvGastos.Columns[1].Name = "Valor";
        }

        // Evento del botón "Agregar Gasto"
        private void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            // Validar la entrada del valor del gasto
            if (double.TryParse(txtValor.Text, out double valor) && !string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                // Crear un nuevo objeto Gasto
                Gasto nuevoGasto = new Gasto
                {
                    Descripcion = txtDescripcion.Text,
                    Valor = valor,
                    Moneda = "MXN" // Moneda local
                };

                // Agregar el gasto a la lista
                listaGastos.Add(nuevoGasto);

                // Actualizar el DataGridView o ListBox
                dgvGastos.Rows.Add(nuevoGasto.Descripcion, nuevoGasto.Valor.ToString("F2"));

                // Limpiar los TextBox
                txtDescripcion.Clear();
                txtValor.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una descripción y un valor válido para el gasto.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para obtener la tasa de cambio (en este ejemplo, tasas fijas)
        private double ObtenerTasaCambio(string moneda)
        {
            switch (moneda)
            {
                case "USD":
                    return 0.05; // Ejemplo: 1 MXN = 0.05 USD
                case "EUR":
                    return 0.04; // Ejemplo: 1 MXN = 0.04 EUR
                case "MXN":
                default:
                    return 1.0; // Moneda local, no requiere conversión
            }
        }

        // Evento del botón "Convertir"
        private void btnConvertir_Click(object sender, EventArgs e)
        {
            string monedaSeleccionada = cbMoneda.SelectedItem.ToString();
            double tasaCambio = ObtenerTasaCambio(monedaSeleccionada);

            // Calcular el total de los gastos convertidos
            double totalConvertido = 0;
            foreach (var gasto in listaGastos)
            {
                totalConvertido += gasto.Valor * tasaCambio;
            }

            // Mostrar el total convertido
            lblTotalConvertido.Text = $"Total en {monedaSeleccionada}: {totalConvertido:F2}";
        }
    }

    // Clase Gasto para almacenar la información de cada gasto
    public class Gasto
    {
        public string Descripcion { get; set; }
        public double Valor { get; set; }
        public string Moneda { get; set; }
    }
}
