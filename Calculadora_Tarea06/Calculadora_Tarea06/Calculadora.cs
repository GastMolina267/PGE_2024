namespace Calculadora_Tarea06
{
    public partial class Calculadora : Form
    {
        double primero;
        double segundo;
        string operador;

        public Calculadora()
        {
            InitializeComponent();
        }

        Clases.ClsSuma obj = new Clases.ClsSuma();
        Clases.ClsResta obj2 = new Clases.ClsResta();
        Clases.ClsMultiplicacion obj3 = new Clases.ClsMultiplicacion();
        Clases.ClsDivision obj4 = new Clases.ClsDivision();

        private void button1_Click(object sender, EventArgs e)
        {
            operador = "+";
            primero = double.Parse(txtScreen.Text);
            txtScreen.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "7";
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
            txtScreen.Text = txtScreen.Text + ".";
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
    }
}
