using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Constructores

        public Profesor() { }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        ///     Asigna dos clases aleatorias al Profesor.
        /// </summary>
        private void _randomClases()
        {
            for(int i =0; i<2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            }
            
        }
        /// <summary>
        ///     Retorna las clases que Da es profesor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder("Clases Del Dia: ");
            foreach(Universidad.EClases item in clasesDelDia)
            {
                sb.AppendFormat(" {0},", item);
            }
            return sb.ToString();
        }

        /// <summary>
        ///     Retorna los datos de el Profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
           
            sb.AppendFormat("NOMBRE COMPLETO {1}, {2}\n", this.clasesDelDia, base.Nombre,base.Apellido);
            sb.AppendLine("NACIONALIDAD: " + base.Nacionalidad);
            sb.AppendLine(base.MostrarDatos());

            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        ///     Mustra los datos del profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        ///     Compueva si Profesor esta dando dicha clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna True si da esa clase, de lo contrario false.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach(Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    return true;
                }
            }

            return false;
        }
         /// <summary>
        ///     Compueva si Profesor NO esta dando dicha clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna True si da esa clase, de lo contrario false.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
