using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

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
            bool rta = false;

            StreamWriter sw = new StreamWriter(archivo, File.Exists(archivo));
            try
            {
                sw.WriteLine(datos);
                rta = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                sw.Close();
            }
            return rta;
        }
        /// <summary>
        ///     Lee archivos de texto y devuelve lo leido por parametros.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna true si lo logro, contraio false.</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool rta = false;
            StreamReader sr = new StreamReader(archivo);
            try
            {
                
                datos = sr.ReadToEnd();
                
                rta = true;
               
            }catch(FileNotFoundException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                sr.Close();
            }
            return rta;
        }
    }
}
