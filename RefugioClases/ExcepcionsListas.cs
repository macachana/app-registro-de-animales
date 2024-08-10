using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioClases
{
    public class ExcepcionsListas : Exception
    {
        public ExcepcionsListas() : base("no se encuentra ningun elemento en la lista")
        {
        }

        public ExcepcionsListas(string mensaje) : base()
        {

        }

        public ExcepcionsListas(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }

        public ExcepcionsListas(string mensaje, Exception innerException, string origenError) : base(mensaje, innerException)
        {
            base.Source = origenError;
        }

        public override string ToString()
        {
            return "ERROR: " + base.InnerException.Message + "\nOrigen: " + base.Source;
        }
    }
}
