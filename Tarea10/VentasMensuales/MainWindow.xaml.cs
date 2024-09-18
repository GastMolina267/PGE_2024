using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;

namespace VentasMensuales
{
    public partial class MainWindow : Window
    {
        private PlotModel plotModel;

        public MainWindow()
        {
            InitializeComponent();
            plotModel = new PlotModel { Title = "Ventas Mensuales" };
            plotView.Model = plotModel;

            // Generar gráfico inicial para "Producto A"
            GenerarGrafico("Producto A");
        }

        // Método para generar el gráfico basado en el producto seleccionado
        private void GenerarGrafico(string producto)
        {
            plotModel.Series.Clear();

            // Datos de ventas ficticios por mes
            var ventasMensuales = ObtenerDatosVentas(producto);

            // Crear una serie de columnas (gráfico de barras)
            var barSeries = new ColumnSeries
            {
                Title = producto,
                FillColor = OxyColors.Blue
            };

            // Agregar datos de ventas a la serie
            foreach (var venta in ventasMensuales)
            {
                barSeries.Items.Add(new ColumnItem(venta));
            }

            // Agregar la serie al modelo de gráfico
            plotModel.Series.Add(barSeries);

            // Actualizar el gráfico
            plotView.InvalidatePlot(true);
        }

        // Método que retorna ventas mensuales ficticias
        private List<double> ObtenerDatosVentas(string producto)
        {
            // Ventas ficticias por mes
            if (producto == "Producto A")
            {
                return new List<double> { 150, 180, 120, 140, 200, 220, 210, 190, 170, 160, 180, 200 };
            }
            else if (producto == "Producto B")
            {
                return new List<double> { 130, 160, 110, 130, 190, 210, 220, 180, 160, 140, 170, 190 };
            }

            return new List<double>();
        }

        // Evento para actualizar el gráfico cuando se selecciona un producto diferente
        private void cbProductos_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbProductos.SelectedItem is System.Windows.Controls.ComboBoxItem selectedItem)
            {
                GenerarGrafico(selectedItem.Content.ToString());
            }
        }

        // Evento para actualizar el gráfico al hacer clic en el botón
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (cbProductos.SelectedItem is System.Windows.Controls.ComboBoxItem selectedItem)
            {
                GenerarGrafico(selectedItem.Content.ToString());
            }
        }
    }
}
