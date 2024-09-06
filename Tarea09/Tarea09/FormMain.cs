namespace Tarea09
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnOpenCalculator_Click(object sender, EventArgs e)
        {
            FormCalculator calculatorForm = new FormCalculator();
            calculatorForm.Show(); // Muestra la ventana de la calculadora
            this.Hide(); // Oculta la ventana principal
        }

        private void btnOpenFileManager_Click(object sender, EventArgs e)
        {
            FormFileManager fileManagerForm = new FormFileManager();
            fileManagerForm.Show(); // Muestra la ventana del gestor de archivos
            this.Hide(); // Oculta la ventana principal
        }
    }

}
