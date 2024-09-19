using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace VentasMensuales
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private SeriesCollection _coleccionSeries;
        public SeriesCollection ColeccionSeries
        {
            get { return _coleccionSeries; }
            set
            {
                _coleccionSeries = value;
                OnPropertyChanged(nameof(ColeccionSeries));
            }
        }

        public string[] Etiquetas { get; set; }
        public Func<double, string> Formateador { get; set; }

        public ObservableCollection<VentaMensual> VentasMensuales { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            VentasMensuales = new ObservableCollection<VentaMensual>
            {
                new VentaMensual("Ene", 0),
                new VentaMensual("Feb", 0),
                new VentaMensual("Mar", 0),
                new VentaMensual("Abr", 0),
                new VentaMensual("May", 0),
                new VentaMensual("Jun", 0),
                new VentaMensual("Jul", 0),
                new VentaMensual("Ago", 0),
                new VentaMensual("Sep", 0),
                new VentaMensual("Oct", 0),
                new VentaMensual("Nov", 0),
                new VentaMensual("Dic", 0)
            };

            ActualizarGrafico();

            Etiquetas = VentasMensuales.Select(v => v.Mes).ToArray();
            Formateador = valor => valor.ToString("C");

            DataContext = this;
        }

        private void ActualizarGrafico()
        {
            ColeccionSeries = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Ventas 2023",
                    Values = new ChartValues<double>(VentasMensuales.Select(v => v.Ventas))
                }
            };
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ActualizarGrafico();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class VentaMensual : INotifyPropertyChanged
    {
        public string Mes { get; set; }
        private double _ventas;
        public double Ventas
        {
            get { return _ventas; }
            set
            {
                _ventas = value;
                OnPropertyChanged(nameof(Ventas));
            }
        }

        public VentaMensual(string mes, double ventas)
        {
            Mes = mes;
            Ventas = ventas;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}