using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioClases
{
    public class Refugio
    {
        private List<Animal> animales;

        public Refugio()
        {
            this.animales = new List<Animal>();
        }

        public List<Animal> Animales
        {
            get
            {
                return this.animales;
            }

            set
            {
                this.animales = value;
            }
        }

        public static Refugio operator +(Refugio r, Animal a)
        {
            if (r != a)
            {
                r.Animales.Add(a);
            }
            return r;
        }


        public static Refugio operator -(Refugio r, Animal a)
        {
            if (r == a)
            {
                r.Animales.Remove(a);
            }
            return r;
        }
        public static bool operator ==(Refugio r, Animal aIng)
        {
            return r == aIng;
        }

        public static bool operator !=(Refugio r, Animal a)
        {
            return !(r == a);
        }

        public List<Animal> modificarItem(Animal itemOriginal, Animal itemModificado)
        {
            for (int i = 0; i < this.Animales.Count; i++)
            {
                if (this.Animales[i] == itemOriginal)
                {
                    this.Animales[i] = itemModificado;
                }
            }

            return this.Animales;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

    }
}
