using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string vacio = "Escogido";
            ML.UsuarioPunto1 usuario = new ML.UsuarioPunto1(vacio);

            usuario.Mostrar();
        }
    }
}
