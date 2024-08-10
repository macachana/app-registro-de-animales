using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace RefugioClases
{
    public class Gato : Animal,IFiltro
    {
        private ERazaGatos razaGatos;
        private bool esDomestico;
        private string comportamiento;

        #region Constructores

        public Gato() : base()
        {
            this.razaGatos = ERazaGatos.MESTIZO;
            this.esDomestico = true;
            this.comportamiento = "NO SE SABE";
        }

        public Gato(string nombre, string colorOjos, int edad, double peso, ESexo sexo, ERazaGatos raza) : base(nombre, colorOjos, edad, peso, sexo)
        {
            this.razaGatos = raza;
        }

        public Gato(string nombre, string colorOjos, int edad, double peso, ESexo sexo, ERazaGatos raza, bool esDomestico) : base(nombre, colorOjos, edad, peso, sexo)
        {
            this.razaGatos = raza;
            this.esDomestico = esDomestico;
        }
        public Gato(string nombre, string colorOjos, int edad, double peso, ESexo sexo, ERazaGatos raza, bool esDomestico, string comportamiento) : base(nombre, colorOjos, edad, peso, sexo)
        {
            this.razaGatos = raza;
            this.esDomestico = esDomestico;
            this.comportamiento = comportamiento;
        }

        #endregion

        public ERazaGatos RazaGatos
        {
            get
            {
                return this.razaGatos;
            }

            set
            {
                this.razaGatos = value;
            }
        }

        public bool EsDomestico
        {
            get
            {
                return this.esDomestico;
            }

            set
            {
                this.esDomestico = value;
            }
        }

        public string Comportamiento
        {
            get
            {
                return this.comportamiento;
            }

            set
            {
                this.comportamiento = value;
            }
        }


        public static bool operator ==(Gato gato, Gato gato2)
        {
            return gato.Nombre.ToUpper() == gato2.Nombre.ToUpper() && gato.Sexo == gato2.Sexo && gato.RazaGatos.ToString().ToUpper() == gato2.RazaGatos.ToString().ToUpper();
        }

        public static bool operator !=(Gato gato, Gato gato2)
        {
            return !(gato == gato2);
        }

        public static bool operator ==(List<Gato> gatoList, Gato gatoIng)
        {
            bool resp = false;
            foreach (Gato g in gatoList)
            {
                if (g == gatoIng)
                {
                    resp = true;
                }
            }
            return resp;
        }

        public static bool operator !=(List<Gato> gatoList, Gato gatoIng)
        {
            return !(gatoList == gatoIng);
        }
        public static List<Gato> operator +(List<Gato> gatoList, Gato gato)
        {
            if (gatoList != gato)
            {
                gatoList.Add(gato);
            }
            return gatoList;
        }

        public static List<Gato> operator -(List<Gato> gatoList, Gato gato)
        {
            if (gatoList == gato)
            {
                gatoList.Remove(gato);
            }
            return gatoList;
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
        /// <returns> retorna como se visualizaran los datos del gato ingresado </returns>
        public override string Mostrar()
        {
            string texto;
            if (this.EsDomestico == true)
            {
                texto = $"NOMBRE : {this.Nombre.ToUpper()} - COLOR DE OJOS : {this.ColorOjos.ToUpper()} - EDAD (EN MESES) : {this.Edad} - PESO : {this.Peso} - SEXO : {this.Sexo} - RAZA : {this.RazaGatos} - ¿ES DOMESTICO? : SI - COMPORTAMIENTO : {this.Comportamiento.ToUpper()}";
            }
            else
            {
                texto = $"NOMBRE : {this.Nombre.ToUpper()} - COLOR DE OJOS : {this.ColorOjos.ToUpper()} - EDAD (EN MESES) : {this.Edad} - PESO : {this.Peso} - SEXO : {this.Sexo} - RAZA : {this.RazaGatos} - ¿ES DOMESTICO? : NO - COMPORTAMIENTO : {this.Comportamiento.ToUpper()}";
            }
            return texto;
        }

        /// <summary>
        /// metodo heredado de la clase object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is Gato)
            {
                return ((Gato)obj) == this;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// metodo heredado de la clase object
        /// </summary>
        /// <returns> retorna la forma de visualizacion de los datos de la clase Gato</returns>
        public override string ToString()
        {
            return Mostrar();
        }
    }
}
