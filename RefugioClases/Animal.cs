using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioClases
{
    public abstract class Animal : IFiltro
    {
        protected string nombre;
        protected string colorOjos;
        protected int edad;
        protected double peso;
        protected ESexo sexo;

        #region Propiedades

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string ColorOjos
        {
            get
            {
                return this.colorOjos;
            }

            set
            {
                colorOjos = value;
            }
        }

        public int Edad
        {
            get
            {
                return this.edad;
            }

            set
            {
                this.edad = value;
            }
        }

        public double Peso
        {
            get
            {
                return this.peso;
            }

            set
            {
                this.peso = value;
            }
        }

        public ESexo Sexo
        {
            get
            {
                return this.sexo;
            }

            set
            {
                this.sexo = value;
            }
        }

        #endregion

        #region Constructores
        public Animal()
        {
            this.nombre = "SIN NOMBRE";
            this.colorOjos = "SIN COLOR DE OJOS";
            this.edad = 0;
            this.peso = 0;
            this.sexo = ESexo.SIN_SEXO;
        }

        public Animal(string nombre) : this()
        {
            this.nombre = nombre;
        }

        public Animal(string nombre, string colorOjos) : this(nombre)
        {
            this.colorOjos = colorOjos;
        }

        public Animal(string nombre, string colorOjos, int edad) : this(nombre, colorOjos)
        {
            this.edad = edad;
        }

        public Animal(string nombre, string colorOjos, int edad, double peso) : this(nombre, colorOjos, edad)
        {
            this.peso = peso;
        }

        public Animal(string nombre, string colorOjos, int edad, double peso, ESexo sexo) : this(nombre, colorOjos, edad, peso)
        {
            this.sexo = sexo;
        }
        #endregion

        public static bool operator ==(List<Animal> a, Animal animal)
        {
            bool resp = false;
            foreach (Animal an in a)
            {
                if (an == animal)
                {
                    resp = true;
                }
            }
            return resp;
        }

        public static bool operator !=(List<Animal> an, Animal animal)
        {
            return !(an == animal);
        }

        public static List<Animal> operator +(List<Animal> a, Animal p)
        {
            if (a != p)
            {
                a.Add(p);
            }
            return a;
        }

        public static List<Animal> operator -(List<Animal> a, Animal p)
        {
            if (a == p)
            {
                a.Remove(p);
            }
            return a;
        }

        /// <summary>
        /// esta sobrecarga de operador explicit sirve para facilitar el trabajo de pasar un object Animal a int
        /// devolviendo la edad
        /// </summary>
        /// <param name="a"></param>
        public static explicit operator int(Animal a)
        {
            return a.Edad;
        }

        /// <summary>
        /// esta sobrecarga de operador implicit sirve para facilitar el trabajo de pasa un object Animal a int
        /// devolviendo el peso
        /// </summary>
        /// <param name="a"></param>
        public static implicit operator double(Animal a)
        {
            return a.Peso;
        }

        /// <summary>
        /// metodo abstracto que heredan las clases hijos con el override
        /// </summary>
        /// <returns> las clases hijos modificaran el metodo para asi poder mostrar los datos de su clase </returns>

        public virtual string mostrarAnimalViejo(string nombreIng, int edadIng)
        {
            return $"{nombreIng} | EDAD: {edadIng}";
        }
        public virtual string mostrarAnimalPesado(string nombreIng, double pesoIng)
        {
            return $"{nombreIng} | PESO: {pesoIng}";
        }
        public abstract string Mostrar();

    }
}
