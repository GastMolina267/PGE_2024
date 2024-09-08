namespace Tarea09
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;
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
