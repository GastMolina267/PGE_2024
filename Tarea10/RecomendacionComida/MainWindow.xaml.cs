using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RecomendacionComida
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, List<Producto>> productosPorCategoria;
        private int calificacionTemporal = 0; // Calificación temporal antes de confirmar
        private string starFilled = "/Img/star_empty.png";
        private string starEmpty = "/Img/star_empty.png";
        private string starBlack = "/Img/star_black.png";

        public MainWindow()
        {
            InitializeComponent();
            CargarCategorias();
            CargarProductos();
        }

        private void CargarCategorias()
        {

        }

        private void CargarProductos()
        {
            productosPorCategoria = new Dictionary<string, List<Producto>>();

            // Productos para la categoría "Burger"
            productosPorCategoria["Burger"] = new List<Producto>
            {
                new Producto { Nombre = "Cheeseburger", Descripcion = "Delicious cheeseburger with fries.", Imagen = "/Img/cheeseburger.png" },
                new Producto { Nombre = "Chicken Burger", Descripcion = "Grilled chicken burger.", Imagen = "/Img/chickenburger.png" }
            };

            // Productos para la categoría "Pizza"
            productosPorCategoria["Pizza"] = new List<Producto>
            {
                new Producto { Nombre = "Margherita Pizza", Descripcion = "Classic margherita pizza.", Imagen = "/Img/margherita.png" },
                new Producto { Nombre = "Pepperoni Pizza", Descripcion = "Pepperoni pizza with extra cheese.", Imagen = "/Img/pepperoni.png" }
            };

            // Productos para la categoría "FrenchFries"
            productosPorCategoria["FrenchFries"] = new List<Producto>
            {
                new Producto { Nombre = "Curly Fries", Descripcion = "Crispy curly fries with a special sauce.", Imagen = "/Img/curlyfries.png" },
                new Producto { Nombre = "Waffle Fries", Descripcion = "Delicious waffle fries with melted cheese.", Imagen = "/Img/wafflefries.png" }
            };

            // Productos para la categoría "Chinese"
            productosPorCategoria["Chinese"] = new List<Producto>
            {
                new Producto { Nombre = "Sweet and Sour Chicken", Descripcion = "Tender chicken with sweet and sour sauce.", Imagen = "/Img/sweetandsour.png" },
                new Producto { Nombre = "Kung Pao Chicken", Descripcion = "Spicy kung pao chicken with peanuts.", Imagen = "/Img/kungpao.png" }
            };

            // Productos para la categoría "Drinks"
            productosPorCategoria["Drinks"] = new List<Producto>
            {
                new Producto { Nombre = "Lemonade", Descripcion = "Refreshing homemade lemonade.", Imagen = "/Img/lemonade.png" },
                new Producto { Nombre = "Iced Tea", Descripcion = "Iced tea with a hint of lemon.", Imagen = "/Img/icedtea.png" }
            };
        }

        private void lbCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbCategorias.SelectedItem != null)
            {
                string categoriaSeleccionada = (lbCategorias.SelectedItem as ListBoxItem).Content.ToString();

                if (productosPorCategoria.ContainsKey(categoriaSeleccionada))
                {
                    lbProductos.ItemsSource = productosPorCategoria[categoriaSeleccionada];
                }
                else
                {
                    lbProductos.ItemsSource = null;
                }
            }
        }

        private void lbProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbProductos.SelectedItem is Producto productoSeleccionado)
            {
                imgProducto.Source = new BitmapImage(new Uri(productoSeleccionado.Imagen, UriKind.Relative));
                txtNombreProducto.Text = productoSeleccionado.Nombre;
                txtDescripcionProducto.Text = productoSeleccionado.Descripcion;
                ActualizarEstrellas(0); // Inicializar sin calificación temporal
                txtCalificacionPromedio.Text = $"Calificación Promedio: {productoSeleccionado.PromedioCalificaciones():F1}";
                txtCantidadCriticas.Text = $"Número de Críticas: {productoSeleccionado.CantidadCriticas}";
            }
        }

        private void Star_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button botonEstrella)
            {
                calificacionTemporal = Convert.ToInt32(botonEstrella.Tag);
                ActualizarEstrellas(calificacionTemporal);
            }
        }

        private void ActualizarEstrellas(int calificacion)
        {
            // Establecer las estrellas llenas hasta la calificación asignada
            for (int i = 1; i <= calificacion; i++)
            {
                Button botonEstrella = (Button)FindName($"btnStar{i}");
                if (botonEstrella != null)
                {
                    botonEstrella.Content = new Image { Source = new BitmapImage(new Uri(starFilled, UriKind.Relative)) };
                }
            }

            // Establecer las estrellas negras para las restantes
            for (int i = calificacion + 1; i <= 5; i++)
            {
                Button botonEstrella = (Button)FindName($"btnStar{i}");
                if (botonEstrella != null)
                {
                    botonEstrella.Content = new Image { Source = new BitmapImage(new Uri(starBlack, UriKind.Relative)) };
                }
            }
        }

        private void btnCalificar_Click(object sender, RoutedEventArgs e)
        {
            if (lbProductos.SelectedItem is Producto productoSeleccionado)
            {
                // Agregar la calificación temporal al producto seleccionado
                productoSeleccionado.AgregarCalificacion(calificacionTemporal);

                // Mostrar la calificación actualizada y el número de críticas
                txtCalificacionPromedio.Text = $"Calificación Promedio: {productoSeleccionado.PromedioCalificaciones():F1}";
                txtCantidadCriticas.Text = $"Número de Críticas: {productoSeleccionado.CantidadCriticas}";

                // Mostrar mensaje de confirmación
                MessageBox.Show($"Gracias por calificar este producto con {calificacionTemporal} estrellas.", "Calificación");
            }
        }
    }

    public class Producto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public double CalificacionTotal { get; private set; } = 0;
        public int CantidadCriticas { get; private set; } = 0;

        // Método para agregar una nueva calificación
        public void AgregarCalificacion(int calificacion)
        {
            CalificacionTotal += calificacion;
            CantidadCriticas++;
        }

        // Método para calcular el promedio de calificaciones
        public double PromedioCalificaciones()
        {
            if (CantidadCriticas == 0) return 0;
            return CalificacionTotal / CantidadCriticas;
        }
    }
}
