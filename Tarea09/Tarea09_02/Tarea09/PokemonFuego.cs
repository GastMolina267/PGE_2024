using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea09
{
    public class PokemonFuego : Pokemon
    {
        public PokemonFuego(string nombre) : base(nombre)
        {
            tipo = "Fuego";
            AgregarMovimiento(new Movimiento("Ascuas", 6, "Fuego", 0.3));
            AgregarMovimiento(new Movimiento("Giro Fuego", 5, "Fuego", 0.2));
            AgregarMovimiento(new Movimiento("Arañazo", 5, "Normal", 0.2));
            AgregarMovimiento(new Movimiento("Gruñido", 4, "Normal", 0.3));
        }
    }

}
