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
        private int victoriasConsecutivas = 0; // Número de victorias necesarias para subir de nivel
        private int combatesGanados = 0; // Combates ganados por el jugador

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
            // Inicializar contador de victorias para subir de nivel
            victoriasConsecutivas = 1;

            // Generar un oponente aleatorio
            oponente = GenerarOponenteAleatorio(jugador.Nivel);
            IniciarCombate(jugador, oponente);

            // Configurar los botones de movimientos
            ConfigurarBotonesMovimientos();
            // Deshabilitar el botón "Volver" inicialmente
            btnVolver.Enabled = false;
            // Habilitar el botón de curar
            btnCurar.Enabled = true;
        }

        // Método para generar un oponente aleatorio
        private Pokemon GenerarOponenteAleatorio(int nivelJugador)
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
            oponente.Nivel = nivelJugador; // Escalar nivel del oponente

            return oponente;
        }

        private void IniciarCombate(Pokemon jugador, Pokemon oponente)
        {
            lblPokemonJugador.Text = jugador.Nombre;
            lblPokemonOponente.Text = oponente.Nombre;

            // Mostrar las imágenes de los Pokémon
            CargarImagenPokemon(pbPokemonJugador, jugador.Nombre);
            CargarImagenPokemon(pbPokemonOponente, oponente.Nombre);

            progressBarJugador.Maximum = jugador.SaludMaxima;
            progressBarJugador.Value = jugador.Salud;
            lblVidaJugador.Text = $"HP: {jugador.Salud}/{jugador.SaludMaxima}";

            progressBarOponente.Maximum = oponente.SaludMaxima;
            progressBarOponente.Value = oponente.Salud;
            lblVidaOponente.Text = $"HP: {oponente.Salud}/{oponente.SaludMaxima}";

            lblEstadoCombate.Text = "¡Es tu turno!";
        }

        // Método para cargar las imágenes de los Pokémon en los PictureBox
        private void CargarImagenPokemon(PictureBox pb, string nombrePokemon)
        {
            switch (nombrePokemon)
            {
                case "Charmander":
                    pb.Image = Properties.Resources.Charmander;
                    break;
                case "Squirtle":
                    pb.Image = Properties.Resources.Squirtle;
                    break;
                case "Bulbasaur":
                    pb.Image = Properties.Resources.Bulbasaur;
                    break;
            }
            pb.SizeMode = PictureBoxSizeMode.StretchImage; // Ajustar el tamaño de la imagen en el PictureBox
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

            if (danio > 0)
            {
                lblMovimiento.Text += $" y causa {danio} de daño.";
            }
            else
            {
                lblMovimiento.Text += " pero el ataque falló.";
            }

            // Actualizar la barra de progreso del oponente
            progressBarOponente.Value = Math.Max(0, Math.Min(oponente.Salud, progressBarOponente.Maximum));
            lblVidaOponente.Text = $"HP: {oponente.Salud}/{oponente.SaludMaxima}";

            await Task.Delay(1000); // Pausa de 1 segundo para mayor realismo

            // Verificar si el oponente se ha debilitado
            if (oponente.Salud <= 0)
            {
                lblEstadoCombate.Text = $"{oponente.Nombre} se ha debilitado. ¡Ganaste!";
                combatesGanados++; // Aumentar el contador de combates ganados

                // Lógica de subida de nivel
                SubirDeNivel();

                // Habilitar el botón "Volver"
                btnVolver.Enabled = true;

                // Esperar un segundo antes de continuar
                await Task.Delay(1000);

                // Generar un nuevo oponente
                oponente = GenerarOponenteAleatorio(jugador.Nivel);

                // Reiniciar el combate con el nuevo oponente
                IniciarCombate(jugador, oponente);
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
                this.Close(); // Cerrar la pantalla si el jugador pierde
            }
            else
            {
                lblEstadoCombate.Text = "¡Es tu turno!";
            }
        }

        private void CurarPokemon(int cantidad)
        {
            jugador.Salud = Math.Min(jugador.Salud + cantidad, jugador.SaludMaxima);
            progressBarJugador.Value = jugador.Salud;
            lblVidaJugador.Text = $"HP: {jugador.Salud}/{jugador.SaludMaxima}";
            lblMovimiento.Text = $"{jugador.Nombre} se ha curado con caramelos.";
        }

        // El método para que el oponente ataque
        private async void AtacarOponente()
        {
            Movimiento movimientoOponente = oponente.SeleccionarMovimientoAleatorio();
            if (movimientoOponente == null)
            {
                lblEstadoCombate.Text = $"{oponente.Nombre} no tiene movimientos disponibles.";
                return;
            }

            lblMovimiento.Text = $"{oponente.Nombre} usa {movimientoOponente.Nombre}";
            int danioOponente = oponente.Atacar(jugador, movimientoOponente);

            if (danioOponente > 0)
            {
                lblMovimiento.Text += $" y causa {danioOponente} de daño.";
            }
            else
            {
                lblMovimiento.Text += " pero el ataque falló.";
            }

            // Actualizar la barra de progreso del jugador
            progressBarJugador.Value = Math.Max(0, Math.Min(jugador.Salud, progressBarJugador.Maximum));
            lblVidaJugador.Text = $"HP: {jugador.Salud}/{jugador.SaludMaxima}";

            await Task.Delay(1000); // Pausa de 1 segundo entre turnos

            // Verificar si el jugador se ha debilitado
            if (jugador.Salud <= 0)
            {
                lblEstadoCombate.Text = $"{jugador.Nombre} se ha debilitado. ¡Perdiste!";
                this.Close(); // Cerrar la pantalla si el jugador pierde
            }
            else
            {
                lblEstadoCombate.Text = "¡Es tu turno!";
                btnCurar.Enabled = true; // Habilitar el botón de curar nuevamente
            }
        }

        private async void btnCurar_Click(object sender, EventArgs e)
        {
            // Aplicar caramelos al Pokémon jugador
            CurarPokemon(7);

            // Deshabilitar el botón de curar para que el jugador no pueda curar continuamente en el mismo turno
            btnCurar.Enabled = false;
            await Task.Delay(1000); // Pausa de 1 segundo entre turnos
            // El jugador pierde su turno de atacar, por lo que se debe hacer que el oponente ataque a continuación
            AtacarOponente();
        }

        // Verificar si el jugador puede subir de nivel
        private void SubirDeNivel()
        {
            // Lógica de subida de nivel escalada
            int combatesRequeridos = (jugador.Nivel * (jugador.Nivel + 1)) / 2; // Ejemplo de lógica escalada

            if (combatesGanados >= combatesRequeridos)
            {
                jugador.Nivel++; // Subir de nivel
                jugador.RecuperarSaludCompleta(); // Recuperar salud tras subir de nivel
                lblEstadoCombate.Text = $"{jugador.Nombre} ha subido al nivel {jugador.Nivel}.";
                combatesGanados = 0; // Reiniciar el contador de combates ganados
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (jugador.Salud > 0 && combatesGanados >= victoriasConsecutivas)
            {
                // Solo se permite volver si el jugador ha ganado
                this.Close();
            }
        }
    }
}