using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioClases
{
    public class Perro : Animal, IFiltro
    {
        private string raza;
        private Etamanio tamanio;

        #region Constructores
        public Perro() : base()
        {
            this.raza = "MESTIZO";
            this.tamanio = Etamanio.PEQUEÑO;
        }

        public Perro(string nombre, string colorOjos, int edad, double peso, ESexo sexo) : base(nombre, colorOjos, edad, peso, sexo)
        {
        }

        public Perro(string nombre, string colorOjos, int edad, double peso, ESexo sexo, Etamanio tamanio) : base(nombre, colorOjos, edad, peso, sexo)
        {
            this.tamanio = tamanio;
        }

        public Perro(string nombre, string colorOjos, int edad, double peso, ESexo sexo, Etamanio tamanio, string raza) : base(nombre, colorOjos, edad, peso, sexo)
        {
            this.tamanio = tamanio;
            this.raza = raza;
        }


        #endregion

        public string Raza
        {
            get
            {
                return this.raza;
            }

            set
            {
                this.raza = value;
            }
        }

        public Etamanio Tamanio
        {
            get
            {
                return this.tamanio;
            }

            set
            {
                this.tamanio = value;
            }
        }


        public static bool operator ==(Perro perro, Perro perro2)
        {
            return perro.Nombre.ToUpper() == perro2.Nombre.ToUpper() && perro.Sexo == perro2.Sexo && perro.Raza.ToUpper() == perro2.Raza.ToUpper();
        }

        public static bool operator !=(Perro perro, Perro perro2)
        {
            return !(perro == perro2);
        }

        public static bool operator ==(List<Perro> p, Perro perroIng)
        {
            bool resp = false;
            foreach (Perro pe in p)
            {
                if (pe == perroIng)
                {
                    resp = true;
                }
            }

            return resp;
        }

        public static bool operator !=(List<Perro> p, Perro perroIng)
        {
            return !(p == perroIng);
        }

        public static List<Perro> operator +(List<Perro> perroList, Perro perro)
        {
            if (perroList != perro)
            {
                perroList.Add(perro);
            }
            return perroList;
        }

        public static List<Perro> operator -(List<Perro> perroList, Perro perro)
        {
            if (perroList == perro)
            {
                perroList.Remove(perro);
            }
            return perroList;
        }

        public override string mostrarAnimalPesado(string nombreIng, double pesoIng)
        {
            return base.mostrarAnimalPesado(nombreIng, pesoIng);
        }

        public override string mostrarAnimalViejo(string nombreIng, int edadIng)
        {
            return base.mostrarAnimalViejo(nombreIng, edadIng);
        }


        /// <summary>
        /// metodo heredado de la clase "Animal"
        /// </summary>
        /// <returns> retorna como se visualizaran los datos del perro ingresado </returns>
        public override string Mostrar()
        {
            string texto;
            texto = $"NOMBRE : {this.Nombre.ToUpper()} - COLOR DE OJOS : {this.ColorOjos.ToUpper()} - EDAD (EN MESES) : {this.Edad} - PESO : {this.Peso} - RAZA : {this.Raza.ToUpper()} - SEXO : {this.Sexo} - TAMAÑO : {this.Tamanio}";
            return texto;
        }

        /// <summary>
        /// metodo heredado de la clase object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is Perro)
            {
                return ((Perro)obj) == this;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// metodo heredado de la clase object
        /// </summary>
        /// <returns> retorna la forma de visualizacion de los datos de la clase Perro</returns>
        public override string ToString()
        {
            return Mostrar();
        }
    }
}
