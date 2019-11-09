using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        ///     Guarda datos de tipo generico en archivos xml.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna true si lo logra, contraio false.</returns>
        public bool Guardar(string archivo, T datos)
        {
            
            XmlTextWriter write = new XmlTextWriter(archivo, System.Text.Encoding.UTF8);
            try
            {

                XmlSerializer ser = new XmlSerializer(typeof(T));

                ser.Serialize(write, datos);

                return true;
                
            }
            catch (InvalidOperationException e)
            {

                throw new ArchivosException(e);

            }
            finally
            {

                write.Close();
                
            }

        }
        /// <summary>
        ///     Lee archivos xml, y retorna lo leido por parametros.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna true si lo logra, contraio false.</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = new XmlTextReader(archivo);
            try
            {

                XmlSerializer ser = new XmlSerializer(typeof(T));

                datos = (T)ser.Deserialize(reader);
                return true;
            }
            finally
            {
                 reader.Close();
            }
            
            
        }
    }
}
