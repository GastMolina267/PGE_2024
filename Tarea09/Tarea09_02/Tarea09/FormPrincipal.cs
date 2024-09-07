namespace Tarea09
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnIniciarBatalla_Click(object sender, EventArgs e)
        {
            string pokemonSeleccionado = comboBoxSeleccionPokemon.SelectedItem.ToString();
            FormBatalla formBatalla = new FormBatalla(pokemonSeleccionado);
            formBatalla.Show();
            this.Hide();
        }
    }
}
