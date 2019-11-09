using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        ///     Guarda datos string en un archivo de texto.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>retorna true si tiene exito, contrario false.</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw = new StreamWriter(archivo);
            sw.WriteLine(datos);
            sw.Close();

            return true;
        }
        /// <summary>
        ///     Lee archivos de texto y devuelve lo leido por parametros.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna true si lo logro, contraio false.</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
                sr.Close();

                return true;
            }
            catch (FileNotFoundException e)
            {
                throw e;
            }
        }
    }
}
