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
}
