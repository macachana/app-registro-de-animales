using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioClases
{
    public class ManejadorEventos
    {
        //DELEGATES
        public delegate void PerroEventHandler(object sender, EventArgs e);

        public delegate void GatoEventHandler(object sender, EventArgs e);

        public delegate void TigreEventHadler(object sender, EventArgs e);


        //EVENTOS
        public event PerroEventHandler SerializarPerroJ;
        public event PerroEventHandler DeserializarPerroJ;

        public event PerroEventHandler SerializarPerroX;
        public event PerroEventHandler DeserializarPerroX;

        public event GatoEventHandler SerializarGatoJ;
        public event GatoEventHandler DeserializarGatoJ;

        public event GatoEventHandler SerializarGatoX;
        public event GatoEventHandler DeserializarGatoX;

        public event TigreEventHadler SerializarTigreJ;
        public event TigreEventHadler DeserializarTigreJ;

        public event TigreEventHadler SerializarTigreX;
        public event TigreEventHadler DeserializarTigreX;

        // Métodos para disparar los eventos de Perro
        public void OnSerializarPerroJson() => SerializarPerroJ?.Invoke(this, EventArgs.Empty);
        public void OnDeserializarPerroJson() => DeserializarPerroJ?.Invoke(this, EventArgs.Empty);
        public void OnSerializarPerroXML() => SerializarPerroX?.Invoke(this, EventArgs.Empty);
        public void OnDeserializarPerroXML() => DeserializarPerroX?.Invoke(this, EventArgs.Empty);

        // Métodos para disparar los eventos de Gato
        public void OnSerializarGatoJson() => SerializarGatoJ?.Invoke(this, EventArgs.Empty);
        public void OnDeserializarGatoJson() => DeserializarGatoJ?.Invoke(this, EventArgs.Empty);
        public void OnSerializarGatoXML() => SerializarGatoX?.Invoke(this, EventArgs.Empty);
        public void OnDeserializarGatoXML() => DeserializarGatoX?.Invoke(this, EventArgs.Empty);

        // Metodos para disparar los eventos de tigre
        public void OnSerializarTigreJson() => SerializarTigreJ?.Invoke(this, EventArgs.Empty);
        public void OnDeserializarTigreJson() => DeserializarTigreJ?.Invoke(this, EventArgs.Empty);
        public void OnSerializarTigreXML() => SerializarTigreX?.Invoke(this, EventArgs.Empty);
        public void OnDeserializarTigreXML() => DeserializarTigreX?.Invoke(this, EventArgs.Empty);
    }
}
