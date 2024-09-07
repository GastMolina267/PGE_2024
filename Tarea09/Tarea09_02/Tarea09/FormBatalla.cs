using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea09
{
    public partial class FormBatalla : Form
    {
        private Pokemon jugador;
        private Pokemon oponente;
        private Random rand = new Random();

        public FormBatalla(string pokemonSeleccionado)
        {
            InitializeComponent();

            // Inicializar Pokémon jugador basado en la selección
            switch (pokemonSeleccionado)
            {
                case "Squirtle":
                    jugador = new PokemonAgua("Squirtle");
                    break;
                case "Charmander":
                    jugador = new PokemonFuego("Charmander");
                    break;
                case "Bulbasaur":
                    jugador = new PokemonPlanta("Bulbasaur");
                    break;
                default:
                    throw new ArgumentException("Pokémon seleccionado no válido.");
            }

            // Generar un oponente aleatorio
            oponente = GenerarOponenteAleatorio();
            IniciarCombate(jugador, oponente);

            // Configurar los botones de movimientos
            ConfigurarBotonesMovimientos();
        }

        // Método para generar un oponente aleatorio
        private Pokemon GenerarOponenteAleatorio()
        {
            int oponenteAleatorio = rand.Next(1, 4); // Elige entre 1 y 3
            Pokemon oponente;

            switch (oponenteAleatorio)
            {
                case 1:
                    oponente = new PokemonAgua("Squirtle");
                    break;
                case 2:
                    oponente = new PokemonFuego("Charmander");
                    break;
                case 3:
                    oponente = new PokemonPlanta("Bulbasaur");
                    break;
                default:
                    oponente = new PokemonAgua("Squirtle");
                    break;
            }

            return oponente;
        }

        private void IniciarCombate(Pokemon jugador, Pokemon oponente)
        {
            lblPokemonJugador.Text = jugador.Nombre;
            lblPokemonOponente.Text = oponente.Nombre;

            progressBarJugador.Maximum = jugador.SaludMaxima;
            progressBarJugador.Value = jugador.Salud;
            lblVidaJugador.Text = $"HP: {jugador.Salud}/{jugador.SaludMaxima}";

            progressBarOponente.Maximum = oponente.SaludMaxima;
            progressBarOponente.Value = oponente.Salud;
            lblVidaOponente.Text = $"HP: {oponente.Salud}/{oponente.SaludMaxima}";

            lblEstadoCombate.Text = "¡Es tu turno!";
        }

        private void ConfigurarBotonesMovimientos()
        {
            if (jugador.Movimientos.Count > 0)
            {
                btnMovimiento1.Text = jugador.Movimientos[0].Nombre;
                btnMovimiento1.Click += (sender, e) => AtacarConMovimiento(jugador.Movimientos[0]);

                if (jugador.Movimientos.Count > 1)
                {
                    btnMovimiento2.Text = jugador.Movimientos[1].Nombre;
                    btnMovimiento2.Click += (sender, e) => AtacarConMovimiento(jugador.Movimientos[1]);
                }

                if (jugador.Movimientos.Count > 2)
                {
                    btnMovimiento3.Text = jugador.Movimientos[2].Nombre;
                    btnMovimiento3.Click += (sender, e) => AtacarConMovimiento(jugador.Movimientos[2]);
                }

                if (jugador.Movimientos.Count > 3)
                {
                    btnMovimiento4.Text = jugador.Movimientos[3].Nombre;
                    btnMovimiento4.Click += (sender, e) => AtacarConMovimiento(jugador.Movimientos[3]);
                }
            }
        }

        private async void AtacarConMovimiento(Movimiento movimiento)
        {
            // Realiza el ataque del jugador
            lblMovimiento.Text = $"{jugador.Nombre} usa {movimiento.Nombre}";
            int danio = jugador.Atacar(oponente, movimiento);

            // Actualizar la barra de progreso del oponente
            progressBarOponente.Value = Math.Max(0, Math.Min(oponente.Salud, progressBarOponente.Maximum));
            lblVidaOponente.Text = $"HP: {oponente.Salud}/{oponente.SaludMaxima}";

            await Task.Delay(1000); // Pausa de 1 segundo para mayor realismo

            // Verificar si el oponente se ha debilitado
            if (oponente.Salud <= 0)
            {
                lblEstadoCombate.Text = $"{oponente.Nombre} se ha debilitado. ¡Ganaste!";
                return;
            }

            // El oponente ataca de vuelta
            Movimiento movimientoOponente = oponente.SeleccionarMovimientoAleatorio();
            if (movimientoOponente == null)
            {
                lblEstadoCombate.Text = $"{oponente.Nombre} no tiene movimientos disponibles.";
                return;
            }

            lblMovimiento.Text = $"{oponente.Nombre} usa {movimientoOponente.Nombre}";
            int danioOponente = oponente.Atacar(jugador, movimientoOponente);

            // Actualizar la barra de progreso del jugador
            progressBarJugador.Value = Math.Max(0, Math.Min(jugador.Salud, progressBarJugador.Maximum));
            lblVidaJugador.Text = $"HP: {jugador.Salud}/{jugador.SaludMaxima}";

            await Task.Delay(1000); // Pausa de 1 segundo entre turnos

            // Verificar si el jugador se ha debilitado
            if (jugador.Salud <= 0)
            {
                lblEstadoCombate.Text = $"{jugador.Nombre} se ha debilitado. ¡Perdiste!";
            }
            else
            {
                lblEstadoCombate.Text = "¡Es tu turno!";
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}