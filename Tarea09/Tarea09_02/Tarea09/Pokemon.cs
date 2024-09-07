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
            this.salud = 20;
            this.ataque = 5;
            this.defensa = 5;
            this.movimientos = new List<Movimiento>();
        }

        public string Nombre => nombre;
        public string Tipo => tipo;
        public int Salud => salud;
        public int SaludMaxima => saludMaxima;

        public void RecibirDanio(int danio)
        {
            salud = Math.Max(0, salud - danio);
            if (salud == 0)
            {
                Console.WriteLine($"{nombre} se ha debilitado...");
            }
        }

        public void AgregarMovimiento(Movimiento movimiento)
        {
            if (movimientos.Count < 4)
            {
                movimientos.Add(movimiento);
            }
        }

        public virtual int Atacar(Pokemon objetivo, Movimiento movimiento)
        {
            int danio = movimiento.Poder + ataque;
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

        public List<Movimiento> Movimientos => movimientos;

        private bool EsEfectivo(string tipoAtaque, string tipoDefensa)
        {
            return (tipoAtaque == "Agua" && tipoDefensa == "Fuego") ||
                   (tipoAtaque == "Fuego" && tipoDefensa == "Planta") ||
                   (tipoAtaque == "Planta" && tipoDefensa == "Agua");
        }

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

    }
}
