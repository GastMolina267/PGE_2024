using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea09
{
    public class Pokemon
    {
        protected string nombre;
        protected string tipo;
        protected int nivel;
        protected int saludMaxima;
        protected int salud;
        protected int ataque;
        protected int defensa;
        protected List<Movimiento> movimientos;

        public Pokemon(string nombre)
        {
            this.nombre = nombre;
            this.tipo = "Normal";
            this.nivel = 1;
            this.saludMaxima = 20;
            this.salud = saludMaxima;
            this.ataque = 5;
            this.defensa = 5;
            this.movimientos = new List<Movimiento>();
        }

        // Propiedad para obtener el nombre del Pokémon
        public string Nombre => nombre;

        // Propiedad para obtener el tipo del Pokémon
        public string Tipo => tipo;

        // Propiedad para obtener y establecer el nivel del Pokémon
        public int Nivel
        {
            get => nivel;
            set
            {
                nivel = value;
                // Ajustar estadísticas del Pokémon según el nivel
                ActualizarEstadisticasPorNivel();
            }
        }

        // Propiedades para la salud y salud máxima
        public int Salud
        {
            get => salud;
            set { salud = value; }
        }
        public int SaludMaxima => saludMaxima;

        // Método para recibir daño
        public void RecibirDanio(int danio)
        {
            salud = Math.Max(0, salud - danio);
            if (salud == 0)
            {
                Console.WriteLine($"{nombre} se ha debilitado...");
            }
        }

        // Método para agregar movimientos al Pokémon (máximo 4 movimientos)
        public void AgregarMovimiento(Movimiento movimiento)
        {
            if (movimientos.Count < 4)
            {
                movimientos.Add(movimiento);
            }
        }

        // Método para atacar a un objetivo usando un movimiento
        public virtual int Atacar(Pokemon objetivo, Movimiento movimiento)
        {
            Random rand = new Random();
            int danio = movimiento.Poder + ataque;

            // Verificar si el ataque falla
            if (rand.NextDouble() < movimiento.ProbabilidadFallo)
            {
                // El ataque falla
                return 0;
            }
            if (movimiento.Tipo == objetivo.Tipo)
            {
                danio /= 2; // No es efectivo
            }
            else if (EsEfectivo(movimiento.Tipo, objetivo.Tipo))
            {
                danio *= 2; // Es super efectivo
            }
            objetivo.RecibirDanio(danio);
            return danio;
        }

        // Propiedad para obtener los movimientos del Pokémon
        public List<Movimiento> Movimientos => movimientos;

        // Método para determinar si un ataque es efectivo o no
        private bool EsEfectivo(string tipoAtaque, string tipoDefensa)
        {
            return (tipoAtaque == "Agua" && tipoDefensa == "Fuego") ||
                   (tipoAtaque == "Fuego" && tipoDefensa == "Planta") ||
                   (tipoAtaque == "Planta" && tipoDefensa == "Agua");
        }

        // Método para seleccionar un movimiento aleatorio
        public Movimiento SeleccionarMovimientoAleatorio()
        {
            if (movimientos.Count > 0)
            {
                Random random = new Random();
                int indiceAleatorio = random.Next(movimientos.Count);
                return movimientos[indiceAleatorio];
            }
            else
            {
                return null; // Si no hay movimientos disponibles
            }
        }

        // Método para recuperar la salud máxima
        public void RecuperarSaludCompleta()
        {
            salud = saludMaxima;
            Console.WriteLine($"{nombre} ha recuperado toda su salud.");
        }

        // Método para actualizar las estadísticas al subir de nivel
        private void ActualizarEstadisticasPorNivel()
        {
            saludMaxima = 20 + (nivel * 5); // Ejemplo de incremento de salud máxima por nivel
            ataque = 5 + (nivel * 2); // Incremento de ataque por nivel
            defensa = 5 + (nivel * 2); // Incremento de defensa por nivel
            RecuperarSaludCompleta(); // Recuperar salud completa al subir de nivel
        }
    }
}
