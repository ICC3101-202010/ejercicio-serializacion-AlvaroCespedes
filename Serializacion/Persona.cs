using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



namespace Serializacion
{
    [Serializable()]
    public class Persona : ISerializable
    {
        private string _nombre;
        private string _apellido;
        private int _edad;
        public Persona(string nombre, string apellido, int edad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._edad = edad;
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public int Edad
        {
            get { return _edad; }
            set { _edad = value; }
        }

        // Es la funcion de la serializacion. Guardara la data in a file.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //Asignamos nuestros valores.
            info.AddValue("Nombre", _nombre);
            info.AddValue("Apellido", _apellido);
            info.AddValue("edad", _edad);
        }

        //Deserializar
        public Persona(SerializationInfo info, StreamingContext context)
        {
            _nombre = (string)info.GetValue("Nombre", typeof(string));
            _apellido = (string)info.GetValue("Apellido", typeof(string));
            _edad = (int)info.GetValue("Edad", typeof(int));
        }

        public Persona()
        {
        }
    }
}
