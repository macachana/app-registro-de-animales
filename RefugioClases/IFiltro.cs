using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioClases
{
    internal interface IFiltro
    {
        string mostrarAnimalPesado(string nombreIng, double pesoIng);

        string mostrarAnimalViejo(string nombreIng, int edadIng);
    }
}
