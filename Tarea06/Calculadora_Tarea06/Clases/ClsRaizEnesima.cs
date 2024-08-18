using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_Tarea06.Clases
{
    internal class ClsRaizEnesima
    {
        public double Calcular(double radicando, double indice)
        {
            return Math.Pow(radicando, 1.0 / indice);
        }
    }
}
