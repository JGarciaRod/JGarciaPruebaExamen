using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ML
{
    public class UsuarioPunto1
    {
        public string Couch { get; } = "Leonardo";
        public string ApellidoCouch { get; set; }
        public string TecnologiaCouch { get; set; }
        protected string[] Vacantes { get; set; }

        protected static string PrimerMetod0()
        {
            string Mensaje = "Metodo estatico protegido ";

            return Mensaje;
        }

        public string SegundoMetodo()
        {
            string Mensaje = "Metodo publico no estatico";

            return Mensaje;
        }


        public UsuarioPunto1(string apellido)
        {
            ApellidoCouch = apellido;
        }

        public UsuarioPunto1(string apellido,string tecno)
        {
            ApellidoCouch = apellido;
            TecnologiaCouch = tecno;
        }

        public UsuarioPunto1(string[] nombres)
        {
            Vacantes = nombres;
        }

        public void Mostrar()
        {
            //primer contructor
            string apellido = "Escogido";

            UsuarioPunto1 usuario1 = new UsuarioPunto1(apellido);

            string mensaje1 = "Hola" + " " + usuario1.Couch + " " + usuario1.ApellidoCouch;

            Console.WriteLine(mensaje1);

            //segundo constructor
            string Tecnologia = "C#";
            
            UsuarioPunto1 usuario2 = new UsuarioPunto1(apellido,Tecnologia);

            string mesnaje2 = "Hola" + " " + usuario2.Couch + " " + usuario2.ApellidoCouch + " " + usuario2.TecnologiaCouch;

            Console.WriteLine(mesnaje2);
            
            //constrcutor ciclo
            string[] strings = {"OCC","COMPUTRABAJO","lINKEDIN","INDEED" };

            UsuarioPunto1 usuario = new UsuarioPunto1(strings);

            for(int i = 0; i <= usuario.Vacantes.Length; i++)
            {
                Console.WriteLine(i+"-"+ usuario.Vacantes[i]);
            }
        }

    }
}
