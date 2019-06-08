using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Helpers
{
    public static class SoporteParaConfiguracion
    {


        public static void CrearArchivoDeConfiguracion(string dire,string nombredearch)
        {
          FileStream fs = new FileStream(nombredearch, FileMode.OpenOrCreate,FileAccess.Write);       
            
          BinaryWriter bw = new BinaryWriter(fs);
           
          bw.Write(dire);
            bw.Close();
        }
        public static string LeerArchivoDeConfiguracion(string nombredearch)
        {
            FileStream fs = new FileStream(nombredearch, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            nombredearch = bw.ReadString();
            bw.Close();
            return nombredearch;

        }




    }
    public static class ConversorDeMorse
    {
        public static string MorseATexto(string morse)
        {
            string textores="",tmp;
            foreach (string c in morse.Split(" "))
            {
            switch (c)
            {
                case ".-": tmp = "a";
                    break;
                case "-...":tmp = "b";
                    break;
                case "-.-.":tmp = "c";
                    break;
                case "-..":tmp = "d";
                    break;
                case ".":tmp = "e";
                    break;
                case "..-.":tmp = "f";
                    break;
                case "--.":tmp = "g";
                    break;
                case "....":tmp = "h";
                    break;
                case "..":tmp = "i";
                    break;
                case ".---":tmp = "j";
                    break;
                case "-.-":tmp = "k";
                    break;
                case ".-..":tmp = "l";
                    break;
                case "--":tmp = "m";
                    break;
                case "-.": tmp = "n";
                    break;
                case "---":tmp = "o";
                    break;
                case ".--.":tmp = "p";
                    break;
                case "--.-":tmp = "q";
                    break;
                case ".-.":tmp = "r";
                    break;
                case "...":tmp = "s";
                    break;
                case "-":tmp = "t";
                    break;
                case "..-":tmp = "u";
                    break;
                case "...-":tmp = "v";
                    break;
                case ".--":tmp = "w";
                    break;
                case "-..-":tmp = "x";
                    break;
                case "-.--":tmp = "y";
                    break;
                case "--..":tmp = "z";
                    break;
                default:tmp=" ";
                    break;
            }
                textores+=tmp;
            }



            return textores;
        }
        public static string TextoAMorse(string texto)
        {
           
            string textores = "";
            string tmp;
            foreach (char l in texto)
            {

                switch (l)
                {
                    case 'a':
                        tmp = ".- ";
                        break;
                    case 'b':
                        tmp = "-... ";
                        break;
                    case 'c':
                        tmp = "-.-. ";
                        break;
                    case 'd':
                        tmp = "-.. ";
                        break;
                    case 'e':
                        tmp = ". ";
                        break;
                    case 'f':
                        tmp = "..-. ";
                        break;
                    case 'g':
                        tmp = "--. ";
                        break;
                    case 'h':
                        tmp = ".... ";
                        break;
                    case 'i':
                        tmp = ".. ";
                        break;
                    case 'j':
                        tmp = ".--- ";
                        break;
                    case 'k':
                        tmp = "-.- ";
                        break;
                    case 'l':
                        tmp = ".-.. ";
                        break;
                    case 'm':
                        tmp = "-- ";
                        break;
                    case 'n':
                        tmp = "-. ";
                        break;
                    case 'o':
                        tmp = "--- ";
                        break;
                    case 'p':
                        tmp = ".--. ";
                        break;
                    case 'q':
                        tmp = "--.- ";
                        break;
                    case 'r':
                        tmp = ".-. ";
                        break;
                    case 's':
                        tmp = "... ";
                        break;
                    case 't':
                        tmp = "- ";
                        break;
                    case 'u':
                        tmp = "..- ";
                        break;
                    case 'v':
                        tmp = "...- ";
                        break;
                    case 'w':
                        tmp = ".-- ";
                        break;
                    case 'x':
                        tmp = "-..- ";
                        break;
                    case 'y':
                        tmp = "-.-- ";
                        break;
                    case 'z':
                        tmp = "--.. ";
                        break;
                    default:
                        tmp = " ";
                        break;
                }
                textores += tmp;
            }

            return textores;

        }
        public static void Creartxt(string archivoconfig, string archivonuevo)
        {
            FileStream fs = new FileStream(SoporteParaConfiguracion.LeerArchivoDeConfiguracion(archivoconfig) + archivonuevo, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("ingrese texto para convertir en codigo Morse");
            sw.WriteLine(TextoAMorse(Console.ReadLine()));
            sw.Close();
            fs.Close();
        }
        public static void Leertxt(string archivoconfig,string archivonuevo)
        {
            FileStream fs = new FileStream(SoporteParaConfiguracion.LeerArchivoDeConfiguracion(archivoconfig) + archivonuevo, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            Console.WriteLine("En Morse:");
            string linea=sr.ReadLine();
            Console.WriteLine(linea);
            Console.WriteLine("En Castellano");
            Console.WriteLine(MorseATexto(linea));
            sr.Close();
            fs.Close();
        }
        public static void Crearmp3Morse(string archivoconfig,string archivotxt)
        {
            string ruta = SoporteParaConfiguracion.LeerArchivoDeConfiguracion(archivoconfig) + @"Morse\";
            string resultante = ruta + Path.ChangeExtension(Path.GetFileNameWithoutExtension(archivotxt), ".mp3");
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);

            }
            FileStream punto = new FileStream(SoporteParaConfiguracion.LeerArchivoDeConfiguracion(archivoconfig)+"punto.mp3",FileMode.Open,FileAccess.Read);
            FileStream raya = new FileStream(SoporteParaConfiguracion.LeerArchivoDeConfiguracion(archivoconfig)+"raya.mp3", FileMode.Open, FileAccess.Read);
            byte[] punt = LectorCompletoDeBinario(punto),ray=LectorCompletoDeBinario(raya);
            FileStream morsefinal = new FileStream(resultante, FileMode.Append, FileAccess.Write);
            FileStream fs = new FileStream(SoporteParaConfiguracion.LeerArchivoDeConfiguracion(archivoconfig) + archivotxt, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            foreach (char item in sr.ReadToEnd())
            {
                if (item=='.')
                {
                    morsefinal.Write(punt, 0, punt.Length);
                }
                else if(item=='-')
                {
                    morsefinal.Write(ray, 0, ray.Length);
                }
            }
            if (File.Exists(resultante))
            {
                Console.WriteLine("Archivo mp3 creado correctamente en: " + ruta);
            }
            else
            {
                Console.WriteLine("No se pudo crear el archivo mp3");
            }
            morsefinal.Close();



        }
        public static byte[] LectorCompletoDeBinario(Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length); 
                    if (read <= 0)
                        return ms.ToArray();  
                    ms.Write(buffer, 0, read);  
                }
            }
        }
    }
}
