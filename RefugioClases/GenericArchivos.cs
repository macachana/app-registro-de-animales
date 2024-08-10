using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Text.Json;

namespace RefugioClases
{
    public class GenericArchivos<T>
    {
        public static void serializarArchivoXML(string archivo, List<T> objetos)
        {
            using (XmlTextWriter write = new XmlTextWriter(archivo, Encoding.UTF8))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));

                ser.Serialize(write, objetos);
            }
        }

        public static void serializarArchivoJSON(string archivo, List<T> objetos)
        {
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;

            using (StreamWriter streamWriter = new StreamWriter(archivo))
            {
                string objJson = JsonSerializer.Serialize(objetos, opciones);

                streamWriter.WriteLine(objJson);
            }
        }

        public static List<T> deserializarArchivoXML(string archivo)
        {
            List<T> listaAux = new List<T>();
            using (XmlTextReader r = new XmlTextReader(archivo))
            {
                XmlSerializer lista = new XmlSerializer(typeof(List<T>));

                listaAux = (List<T>)lista.Deserialize(r);
            }
            return listaAux;
        }

        public static List<T> deserializarArchivoJSON(string archivo)
        {
            List<T> listaAux = new List<T>();
            using (StreamReader streamReader = new StreamReader(archivo))
            {
                string listaJson = streamReader.ReadToEnd();

                listaAux = JsonSerializer.Deserialize<List<T>>(listaJson);

            }
            return listaAux;
        }

        public static void serializarArchivoTexto(string archivo)
        {
            List<string> listaAux = new List<string>();
            using (StreamWriter streamWriteUsuarios = new StreamWriter(archivo))
            {
                foreach (string linea in listaAux)
                {
                    streamWriteUsuarios.WriteLine(linea);
                }
            }
        }

        public static List<string>  deserializarArchivoTexto(string archivo)
        {
            List<string> listaAux = new List<string>();

            StreamReader streamReader = new StreamReader(archivo);

            string linea = "";

            while ((linea = streamReader.ReadLine()) != null)
            {
                listaAux.Add(linea);
            }

            streamReader.Close();
            return listaAux;
        }
    }
}
