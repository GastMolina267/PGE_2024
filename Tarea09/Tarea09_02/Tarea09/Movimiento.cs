using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea09
{
    public class Movimiento
    {
        public string Nombre { get; }
        public int Poder { get; }
        public string Tipo { get; }
        public double ProbabilidadFallo { get; set; } // Probabilidad de fallo entre 0 y 1

        public Movimiento(string nombre, int poder, string tipo, double probabilidadFallo)
        {
            Nombre = nombre;
            Poder = poder;
            Tipo = tipo;
            ProbabilidadFallo = probabilidadFallo;
        }
    }
}
