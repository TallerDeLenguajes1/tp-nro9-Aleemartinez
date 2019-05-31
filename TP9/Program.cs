using System;
using Helpers;

namespace TP9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string ruta = @"C:\Users\alee2\Google Drive\FACET_\Nivel 2\Taller de Lenguajes 1\tp-nro9-Aleemartinez";
            string arch = @"config2.dat";
            SoporteParaConfiguracion.CrearArchivoDeConfiguracion(ruta,arch);
            Console.WriteLine(SoporteParaConfiguracion.LeerArchivoDeConfiguracion(arch));

        }
    }
}
