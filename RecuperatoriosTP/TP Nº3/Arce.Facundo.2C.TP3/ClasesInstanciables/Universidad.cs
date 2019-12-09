using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        #region Constructor

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        #endregion

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }
            set { this.jornadas = value; }
        }

        public Jornada this[int i]
        {
            get { return this.jornadas[i]; }
            set { this.jornadas[i] = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        ///     Guarda la universidad en un archivo.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            try
            {
                return xml.Guardar("ArchivoXml.txt", uni);
            }
            catch (ArchivosException e)
            {
                throw e;
            }
            
        }
        /// <summary>
        ///     lee archivo xml.
        /// </summary>
        /// <returns>Retorna una universidad serializada.</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad uni = new Universidad();

             if (xml.Leer("ArchivoXml.txt",out uni))
            {

            }
            return uni;
        }

        /// <summary>
        ///     Muestra los Datos de la universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            return uni.ToString();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        ///     Expone los datos de la Universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            for (int i=0; i<this.jornadas.Count; i++)
            {
                sb.AppendLine(this.jornadas[i].ToString());
                
                sb.AppendLine("<-------------------------------------------->");
            }
            
            return sb.ToString();
        }

        /// <summary>
        ///     Agrega una jornada a la universidad con la clase pasada por parametros.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna la universidad con la jornada nueva, contrario la universidad sin cambios.</returns>
        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {
            try
            {
                foreach (Profesor item in g.profesores)
                {
                    if (item == clase)
                    {
                        Jornada nuevaJornada = new Jornada(clase, item);
                        foreach (Alumno item2 in g.Alumnos)
                        {
                            if ( nuevaJornada == item2)
                            {
                                nuevaJornada.Alumnos.Add(item2);
                            }
                        }
                        g.jornadas.Add(nuevaJornada);
                        return g;
                    }
                }

                throw new SinProfesorException();
            }
            catch (SinProfesorException e)
            {
                throw e;
            }

        }
        /// <summary>
        ///     Agrega alumnos a la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Retorna la universidad con los alumnos nuevos, contrario la universidad sin cambios.</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            try
            {
                if (g != a)
                {
                    g.alumnos.Add(a);
                    return g;
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            catch(AlumnoRepetidoException e)
            {
                throw e;
            }


            
        }
        /// <summary>
        ///     Agrega profesores a la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>Retorna la universidad con los nuevos profesores, contraio la universidad sin cambios.</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesores.Add(i);
            }

            return g;
        }
        /// <summary>
        ///     Comprueba si el Alumno esta en la lista de inscritos de la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Retorna True si esta, de lo contrario False.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        ///     Comprueba si el Alumno NO esta en la lista de inscritos de la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Retorna True si esta, de lo contrario False.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        ///     Comprueba si el Profesor esta dando clases en la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Retorna True si esta, de lo contrario False.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        ///     Comprueba si el Profesor NO esta dando clases en la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Retorna True si esta, de lo contrario False.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        ///     Retorna el primer profesor capas de dar dicha clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna un Profesor.</returns>
        public static Profesor operator ==(Universidad g, Universidad.EClases clase)
        {
            try
            {
                foreach (Profesor item in g.profesores)
                {
                    if (item == clase)
                    {
                        return item;
                    }
                }

                throw new SinProfesorException();
            }
            catch (SinProfesorException e)
            {
                throw e;
            }
        }
        /// <summary>
        ///     Retorna el primer profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna un Profesor.</returns>
        public static Profesor operator !=(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item != clase)
                {
                    return item;
                }
            }

            return null;
        }

        #endregion
    }
}
