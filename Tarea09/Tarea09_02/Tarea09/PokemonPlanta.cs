using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea09
{
    public class PokemonPlanta : Pokemon
    {
        public PokemonPlanta(string nombre) : base(nombre)
        {
            tipo = "Planta";
            AgregarMovimiento(new Movimiento("Látigo Cepa", 6, "Planta"));
            AgregarMovimiento(new Movimiento("Hoja Afilada", 5, "Planta"));
            AgregarMovimiento(new Movimiento("Placaje", 5, "Normal"));
            AgregarMovimiento(new Movimiento("Gruñido", 4, "Normal"));
        }
    }

}
