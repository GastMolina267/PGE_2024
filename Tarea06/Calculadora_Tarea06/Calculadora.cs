namespace Calculadora_Tarea06
{
    public partial class Calculadora : Form
    {
        double primero;
        double segundo;
        string operador;

        // Lista para almacenar el historial de operaciones
        List<string> historial = new List<string>();


        // Definir un evento personalizado de error
        public event EventHandler<ErrorEventArgs> ErrorOcurrido;


        public Calculadora()
        {
            InitializeComponent();
            // Suscribirse al evento de error
            this.ErrorOcurrido += MostrarError;
        }

        Clases.ClsSuma obj = new Clases.ClsSuma();
        Clases.ClsResta obj2 = new Clases.ClsResta();
        Clases.ClsMultiplicacion obj3 = new Clases.ClsMultiplicacion();
        Clases.ClsDivision obj4 = new Clases.ClsDivision();

        // Instancias para las nuevas operaciones
        Clases.ClsPotencia objPotencia = new Clases.ClsPotencia();
        Clases.ClsRaizCuadrada objRaizCuadrada = new Clases.ClsRaizCuadrada();
        Clases.ClsExponencial objExponencial = new Clases.ClsExponencial();
        Clases.ClsRaizEnesima objRaizEnesima = new Clases.ClsRaizEnesima();

        private void button1_Click(object sender, EventArgs e)
        {
            operador = "+";
            primero = double.Parse(txtScreen.Text);
            txtScreen.Text += txtScreen.Text + " + ";  // Mostrar el operador en un Label adicional
            txtScreen.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            operador = "*";
            primero = double.Parse(txtScreen.Text);
            txtScreen.Clear();
        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "0";
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "1";
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "2";
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "3";
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "4";
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "5";
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "6";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "7";
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "8";
        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "9";
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            // Evitar múltiples puntos decimales
            if (!txtScreen.Text.Contains("."))
            {
                txtScreen.Text += ".";
            }
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            operador = "-";
            primero = double.Parse(txtScreen.Text);
            txtScreen.Clear();
            // Es un ejemplo
        }
        private void btnDiv_Click(object sender, EventArgs e)
        {
            operador = "/";
            primero = double.Parse(txtScreen.Text);
            txtScreen.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtScreen.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Verificar si hay texto para borrar
            if (txtScreen.Text.Length > 0)
            {
                if (txtScreen.Text.Length == 1)
                {
                    txtScreen.Text = ""; // Si hay solo un carácter, borrar todo el texto
                }
                else
                {
                    // Eliminar el último carácter
                    txtScreen.Text = txtScreen.Text.Substring(0, txtScreen.Text.Length - 1);
                }
            }
        }

        private void btnRaizCua_Click(object sender, EventArgs e)
        {
            try
            {
                operador = "raiz";
                primero = double.Parse(txtScreen.Text);
                txtScreen.Clear();

                double resultado = objRaizCuadrada.Calcular(primero);
                txtScreen.Text = resultado.ToString();

                historial.Add($"√{primero} = {resultado}");
                lstHistorial.Items.Add($"√{primero} = {resultado}");
            }
            catch (FormatException)
            {
                DispararError("Entrada inválida para la raíz cuadrada.");
            }
            catch (Exception ex)
            {
                DispararError(ex.Message);
            }
        }

        private void btnPoten_Click(object sender, EventArgs e)
        {
            try
            {
                operador = "potencia";
                primero = double.Parse(txtScreen.Text);
                txtScreen.Clear();
            }
            catch (FormatException)
            {
                DispararError("Entrada inválida para la potencia.");
            }
        }

        private void btnExpo_Click(object sender, EventArgs e)
        {
            try
            {
                operador = "exponencial";
                primero = double.Parse(txtScreen.Text);
                txtScreen.Clear();

                double resultado = objExponencial.Calcular(primero);
                txtScreen.Text = resultado.ToString();

                historial.Add($"e^{primero} = {resultado}");
                lstHistorial.Items.Add($"e^{primero} = {resultado}");
            }
            catch (FormatException)
            {
                DispararError("Entrada inválida para la operación exponencial.");
            }
            catch (Exception ex)
            {
                DispararError(ex.Message);
            }
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            try
            {
                operador = "raizenesima";
                primero = double.Parse(txtScreen.Text);
                txtScreen.Clear();
            }
            catch (FormatException)
            {
                DispararError("Entrada inválida para la raíz enésima.");
            }
        }

        // Método para disparar el evento de error
        private void DispararError(string mensajeError)
        {
            ErrorOcurrido?.Invoke(this, new ErrorEventArgs(mensajeError));
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            segundo = double.Parse(txtScreen.Text);
            double resultado = 0;

            // Mejor manejo de excepciones y validaciones
            try
            {
                switch (operador)
                {
                    case "+":
                        resultado = obj.Sumar(primero, segundo);
                        historial.Add($"{primero} + {segundo} = {resultado}");
                        break;
                    case "-":
                        resultado = obj2.Resta(primero, segundo);
                        historial.Add($"{primero} - {segundo} = {resultado}");
                        break;
                    case "*":
                        resultado = obj3.Multiplicar(primero, segundo);
                        historial.Add($"{primero} * {segundo} = {resultado}");
                        break;
                    case "/":
                        // Validación de división por cero
                        if (segundo == 0)
                            throw new DivideByZeroException("No se puede dividir entre cero.");
                        resultado = obj4.Division(primero, segundo);
                        historial.Add($"{primero} / {segundo} = {resultado}");
                        break;
                    case "potencia":
                        resultado = objPotencia.Calcular(primero, segundo);
                        historial.Add($"{primero}^{segundo} = {resultado}");
                        break;
                    case "raizenesima":
                        resultado = objRaizEnesima.Calcular(primero, segundo);
                        historial.Add($"{segundo}√{primero} = {resultado}");
                        break;
                    default:
                        throw new InvalidOperationException("Operador no válido."); 
                }
                txtScreen.Text = resultado.ToString();
                lstHistorial.Items.Add(historial.Last());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtScreen.Clear();
            }
        }

        // Manejador del evento de error
        private void MostrarError(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Clase personalizada para el evento de error
        public class ErrorEventArgs : EventArgs
        {
            public string Message { get; }

            public ErrorEventArgs(string message)
            {
                Message = message;
            }
        }
    }
}
