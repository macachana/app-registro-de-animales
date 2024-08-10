using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioClases
{
    public interface Iordenamiento<T> where T : Animal
    {
        List<T> organizarPorNombreASC(List<T> lista);

        List<T> organizarPorNombreDES(List<T> lista);

        List<T> organizarPorEdadASC(List<T> lista);

        List<T> organizarPorEdadDES(List<T> lista);
    }
}
