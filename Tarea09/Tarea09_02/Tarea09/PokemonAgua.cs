using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea09
{
    public class PokemonAgua : Pokemon
    {
        public PokemonAgua(string nombre) : base(nombre)
        {
            tipo = "Agua";
            AgregarMovimiento(new Movimiento("Pistola de Agua", 6, "Agua"));
            AgregarMovimiento(new Movimiento("Burbuja", 5, "Agua"));
            AgregarMovimiento(new Movimiento("Placaje", 5, "Normal"));
            AgregarMovimiento(new Movimiento("Mordisco", 6, "Normal"));
        }
    }

}
