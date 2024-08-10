using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioClases
{
    public class Tigre : Animal, IFiltro
    {
        private EsubEspecie subEspecie;
        private string habitat;

        #region Constructores
        public Tigre() : base()
        {
            this.subEspecie = EsubEspecie.BENGALA;
            this.habitat = "BOSQUE TROPICAL";
        }

        public Tigre(string nombre, string colorOjos, int edad, double peso, ESexo sexo) : base(nombre, colorOjos, edad, peso, sexo)
        {
        }

        public Tigre(string nombre, string colorOjos, int edad, double peso, ESexo sexo, EsubEspecie subspecie) : base(nombre, colorOjos, edad, peso, sexo)
        {
            this.subEspecie = subspecie;
        }

        public Tigre(string nombre, string colorOjos, int edad, double peso, ESexo sexo, EsubEspecie subEspecie, string habitat) : base(nombre, colorOjos, edad, peso, sexo)
        {
            this.subEspecie = subEspecie;
            this.habitat = habitat;
        }
        #endregion

        public EsubEspecie SubEspecie
        {
            get
            {
                return this.subEspecie;
            }

            set
            {
                this.subEspecie = value;
            }
        }

        public string Habitat
        {
            get
            {
                return this.habitat;
            }

            set
            {
                this.habitat = value;
            }
        }

        public static bool operator ==(List<Tigre> t, Tigre tigreIng)
        {
            bool resp = false;
            foreach (Tigre ti in t)
            {
                if (ti == tigreIng)
                {
                    resp = true;
                }
            }

            return resp;
        }

        public static bool operator !=(List<Tigre> t, Tigre tigreIng)
        {
            return !(t == tigreIng);
        }


        public static bool operator ==(Tigre tigre, Tigre tigre2)
        {
            return tigre.Nombre.ToUpper() == tigre2.Nombre.ToUpper() && tigre.Sexo == tigre2.Sexo && tigre.SubEspecie.ToString().ToUpper() == tigre2.SubEspecie.ToString().ToUpper();
        }

        public static bool operator !=(Tigre tigre, Tigre tigre2)
        {
            return !(tigre == tigre2);
        }


        public static List<Tigre> operator +(List<Tigre> tigreList, Tigre tigre)
        {
            if (tigreList != tigre)
            {
                tigreList.Add(tigre);
            }
            return tigreList;
        }

        public static List<Tigre> operator -(List<Tigre> tigreList, Tigre tigre)
        {
            if (tigreList == tigre)
            {
                tigreList.Remove(tigre);
            }
            return tigreList;
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
        /// <returns> retorna como se visualizaran los datos del tigre ingresado </returns>
        public override string Mostrar()
        {
            return $"NOMBRE : {this.Nombre.ToUpper()} - COLOR DE OJOS : {this.ColorOjos.ToUpper()} - EDAD (EN MESES) : {this.Edad} - PESO : {this.Peso} - SEXO : {this.Sexo} - SUB ESPECIE : {this.SubEspecie} - HABITAT : {this.habitat.ToUpper()}";

        }


        /// <summary>
        /// metodo heredado de la clase object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is Tigre)
            {
                return ((Tigre)obj) == this;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// metodo heredado de la clase object
        /// </summary>
        /// <returns> retorna la forma de visualizacion de los datos de la clase Tigre</returns>
        public override string ToString()
        {
            return Mostrar();
        }
    }
}
