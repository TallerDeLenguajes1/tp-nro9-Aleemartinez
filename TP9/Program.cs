using System;
using Helpers;
using System.IO;

namespace TP9
{
    class Program
    {
        static void Main()
        {
            string ruta = @"C:\Users\alee2\Google Drive\FACET_\Nivel 2\Taller de Lenguajes 1\tp-nro9-Aleemartinez\";
            string arch = @"config2.dat";
            string debug = @"C:\Users\alee2\Google Drive\FACET_\Nivel 2\Taller de Lenguajes 1\tp-nro9-Aleemartinez\TP9\bin\Debug\netcoreapp2.1\";
            SoporteParaConfiguracion.CrearArchivoDeConfiguracion(ruta,arch);
            Console.WriteLine("Carpeta de configuracion:");
            Console.WriteLine(SoporteParaConfiguracion.LeerArchivoDeConfiguracion(arch));
            Console.WriteLine("\nArchivos en la carpeta debug:");
            string[] archivos = Directory.GetFiles(debug);
            foreach (string item in archivos)
            {
                Console.WriteLine(Path.GetFileName(item));
                if (Path.GetExtension(item)==".mp3" || Path.GetExtension(item) == ".txt")
                {
                    File.Move(item, SoporteParaConfiguracion.LeerArchivoDeConfiguracion(arch)+Path.GetFileName(item));
                }

            }
            Console.WriteLine();
            string archmorse = "morse[" +DateTime.Now.ToString("dd-MM-hh-mm")+"].txt";
            ConversorDeMorse.Creartxt(arch,archmorse);
            ConversorDeMorse.Leertxt(arch, archmorse);
            ConversorDeMorse.Crearmp3Morse(arch, archmorse);
            Console.ReadKey();
        }
    }
}
