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

namespace DibujoLibre
{
    public partial class MainWindow : Window
    {
        private bool isDrawing = false;  // Para rastrear si el usuario está dibujando
        private Point previousPoint;     // Para almacenar la posición anterior del mouse

        public MainWindow()
        {
            InitializeComponent();
        }

        // Evento cuando se presiona el botón del mouse (comienzo del dibujo)
        private void DibujoCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDrawing = true;
            previousPoint = e.GetPosition(DibujoCanvas);  // Guardar la posición inicial
        }

        // Evento cuando se mueve el mouse (se dibuja mientras se arrastra el mouse)
        private void DibujoCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                // Obtener la posición actual del mouse
                Point currentPoint = e.GetPosition(DibujoCanvas);

                // Crear una línea que conecte el punto anterior con el actual
                Line line = new Line
                {
                    Stroke = Brushes.Black,  // Color de la línea
                    StrokeThickness = 2,     // Grosor de la línea
                    X1 = previousPoint.X,
                    Y1 = previousPoint.Y,
                    X2 = currentPoint.X,
                    Y2 = currentPoint.Y
                };

                // Agregar la línea al Canvas
                DibujoCanvas.Children.Add(line);

                // Actualizar el punto anterior
                previousPoint = currentPoint;
            }
        }

        // Evento cuando se suelta el botón del mouse (fin del dibujo)
        private void DibujoCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDrawing = false;  // Finaliza el dibujo
        }
    }
}
