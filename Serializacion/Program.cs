using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Collections.Immutable;



namespace Serializacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona persona = new Persona();
            Stream stream = File.Open("PersonaData.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            // I need to send the object data to my file.
            //bf.Serialize(stream, persona);
            //stream.Close();

            //Now the data its saved.

            //Read the object data from the file.
            stream = File.Open("PersonaData.dat", FileMode.Open);
            bf = new BinaryFormatter();
            //persona = (Persona)bf.Deserialize(stream);
            //stream.Close();

            Console.WriteLine("Aprete 10 para ingresar al menu");
            string opcion1 = Console.ReadLine();
            while(opcion1 == "10") 
            {
                Console.WriteLine("(1) Crear persona. ");
                Console.WriteLine("(2) Mostrar Personas. ");
                Console.WriteLine("(3) Cargar Personas. Deserializar. ");
                Console.WriteLine("(4) Guardar personas en un archivo. Serializar. ");
                Console.WriteLine("0 Sali.");
                string opcion2 = Console.ReadLine();
                if (opcion2 == "1")
                {
                    Console.WriteLine("Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.WriteLine("Apellido: ");
                    string apellido = Console.ReadLine();

                    Console.WriteLine("Edad: ");
                    string edad = Console.ReadLine();
                    int edad1 = Convert.ToInt32(edad);

                    persona.Nombre = nombre;
                    persona.Apellido = apellido;
                    persona.Edad = edad1;

                    Console.WriteLine("Se ha agregado correctamente");
                    Console.WriteLine("Elegir nueva opcion. ");
                    string opcion3 = Console.ReadLine();
                    opcion2 = opcion3;
                    break;

                }
                if (opcion2 == "2")
                {
                    //Mostrando todas las personas.
                    Console.WriteLine(persona.ToString());
                    string opcion3 = Console.ReadLine();
                    opcion2 = opcion3;
                }
                if (opcion2 == "3")
                {
                    persona = (Persona)bf.Deserialize(stream);
                    stream.Close();
                    string opcion3 = Console.ReadLine();
                    opcion2 = opcion3;
                }
                if (opcion2 == "4")
                {
                    bf.Serialize(stream, persona);
                    stream.Close();
                    string opcion3 = Console.ReadLine();
                    opcion2 = opcion3;
                }
                if (opcion2 == "0")
                {
                    break;
                }
            }
        }
    }
}
