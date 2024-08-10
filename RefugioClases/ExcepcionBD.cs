using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioClases
{
    public class ExcepcionBD : Exception
    {
        public ExcepcionBD() : base("no se pudo realizar la conexion")
        {
        }

        public ExcepcionBD(string mensaje) : base()
        {

        }

        public ExcepcionBD(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }

        public ExcepcionBD(string mensaje, Exception innerException, string origenError) : base(mensaje, innerException)
        {
            base.Source = origenError;
        }

        public override string ToString()
        {
            return "ERROR: " + base.InnerException.Message + "\nOrigen: " + base.Source;
        }
    }
}
