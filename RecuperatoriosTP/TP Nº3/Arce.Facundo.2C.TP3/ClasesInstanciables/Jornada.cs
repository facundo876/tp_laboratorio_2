using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Constructores

        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        #endregion

        #region Metodos
        /// <summary>
        ///     Guarda los datos de la jornada en Texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>Retorna true si pudo guardarlos, de lo contrario false.</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool rta = false;

            Texto texto = new Texto();
            try
            {
                texto.Guardar("JornadaTxt.txt", jornada.ToString());
                rta = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return rta;

        }
        /// <summary>
        ///     Lee los datos de la jornada en Texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>Retorna true si pudo guardarlos, de lo contrario false.</returns>
        public static string Leer()
        {
            try
            {
                Texto texto = new Texto();

                texto.Leer("JornadaTxt.txt", out string aux);

                return aux;

            }
            catch (FileNotFoundException e)
            {
                throw e;
            }
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        ///     Publica los datos de la jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR ", this.Clase);
            sb.AppendLine(this.instructor.ToString());

            sb.AppendLine("ALUMNOS:");
            for (int i=0; i<this.alumnos.Count; i++)
            {
                sb.AppendLine(this.alumnos[i].ToString());
            }
            

            return sb.ToString();
        }

        /// <summary>
        ///     Agrega un alumno a la jornada si esta no pertenece a dicha jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Retorna la jornada con el alumno incluido, contrario retorna la jornada sin cambios.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }

        /// <summary>
        ///     Comprueba si el Alumno participa en partipa en la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>retorna True si participa, de lo contrario false.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return (a == j.Clase);

        }
        /// <summary>
        ///     Comprueba si el Alumno NO participa en partipa en la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>retorna True si participa, de lo contrario false.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);

        }
        #endregion
    }
}
