using System.Text;

namespace RefugioClases
{
    public class Usuario
    {
        private string apellidoIngr;
        private string nombreIngr;
        private int legajoIngr;
        private string correoIngr;
        private string claveIngr;
        private string perfilIngr;

        #region Constructores
        public Usuario(string apellidoIngr, string nombreIngr, int legajoIngr, string correoIngr, string claveIngr, string perfilIngr)
        {
            this.apellidoIngr = apellidoIngr;
            this.nombreIngr = nombreIngr;
            this.legajoIngr = legajoIngr;
            this.correoIngr = correoIngr;
            this.claveIngr = claveIngr;
            this.perfilIngr = perfilIngr;
        }
        public Usuario()
        {

        }
        #endregion

        #region Propiedades
        public string apellido
        {
            get
            {
                return this.apellidoIngr;
            }
            set
            {
                this.apellidoIngr = value;
            }
        }

        public string nombre
        {
            get
            {
                return this.nombreIngr;
            }
            set
            {
                this.nombreIngr = value;
            }
        }

        public int legajo
        {
            get
            {
                return this.legajoIngr;
            }
            set
            {
                this.legajoIngr = value;
            }
        }

        public string correo
        {
            get
            {
                return this.correoIngr;
            }
            set
            {
                this.correoIngr = value;
            }
        }

        public string clave
        {
            get
            {
                return this.claveIngr;
            }
            set
            {
                this.claveIngr = value;
            }
        }

        public string perfil
        {
            get
            {
                return this.perfilIngr;
            }
            set
            {
                this.perfilIngr = value;
            }
        }
        #endregion

        #region Sobrecarga

        /// <summary>
        /// sobrecarga para poder sumar o agregar un usuario a una lista de usuarios
        /// </summary>
        /// <param name="listUsuario"> lista de usuarios en donde agregar al usuario ingresado </param>
        /// <param name="usuario"> usuario que se agregara a la lista </param>
        /// <returns></returns>
        public static List<Usuario> operator +(List<Usuario> listUsuario,Usuario usuario)
        {
            listUsuario.Add(usuario);
            return listUsuario;
        }

        /// <summary>
        /// sobrecarga para poder restar o eliminar un usuario de una lista de usuarios
        /// </summary>
        /// <param name="listUsuario"> lista de usuarios en donde eliminar al usuario ingresado</param>
        /// <param name="usuario"> usuario que se eliminara de la lista </param>
        /// <returns></returns>
        public static List<Usuario> operator -(List<Usuario> listUsuario,Usuario usuario)
        {
            listUsuario.Remove(usuario);
            return listUsuario;
        }
        #endregion



        /// <summary>
        /// metodo que retorna la fecha actual sin hora
        /// </summary>
        /// <returns>fecha sin hora</returns>
        public string obtenerFechaActualSH()
        {
            DateTime fechaActual = new DateTime();
            fechaActual = DateTime.Now.Date;
            return fechaActual.ToShortDateString();
        }

        /// <summary>
        /// este metodo retorna la fecha actual con
        /// un formato de tiempo
        /// </summary>
        /// <returns>fecha con hora</returns>
        public string obtenerFechaActualCH()
        {
            DateTime fechaActual = new DateTime();
            fechaActual = DateTime.Now;
            return fechaActual.ToString("yyyy-MM-dd hh:mm:ss");

        }

        /// <summary>
        /// este metodo es un formato con el que escribi los datos de forma que se visualizara bien 
        /// en el form principal
        /// </summary>
        /// <returns>visualizacion de los datos del usuario logueado sin hora</returns>
        public string MostrarPrincipal()
        {
            StringBuilder texto = new StringBuilder();
            texto.Append($"Legajo: {this.legajo} - ");
            texto.Append($"Nombre: {this.nombre} - ");
            texto.Append($"Apellido: {this.apellido} - ");
            texto.Append($"Perfil: {this.perfil} - ");
            texto.Append($"Fecha : {obtenerFechaActualSH()}");
            return texto.ToString();
        }

        /// <summary>
        /// este metodo muestra al usuario logueado de otra forma 
        /// incluyendo la fecha con hora,minutos y segundos
        /// </summary>
        /// <returns>visualizacion del usuario logueado con hora</returns>
        public string MostrarParaArchivo()
        {
            return $"USUARIO LOGUEADO : Nombre: {this.nombre} | Apellido : {this.apellido} | Legajo : {this.legajo} | Corrreo : {this.correo} | Perfil : {this.perfil} | Fecha : {obtenerFechaActualCH()}";
        }

        /// <summary>
        /// metodo heredado de la clase object
        /// visualizacion del usuario logueado con hora
        /// </summary>
        /// <returns> retorna el usuario con hora</returns>
        public override string ToString()
        {
            return this.MostrarParaArchivo();
        }
    }
}
