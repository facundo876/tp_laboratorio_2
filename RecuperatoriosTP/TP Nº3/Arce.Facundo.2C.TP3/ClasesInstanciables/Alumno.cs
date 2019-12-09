using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        #region Constructores

        public Alumno() { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.estadoCuenta = estadoCuenta;
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.AlDia)//Es valido poner que esta al dia? .
        { }
        #endregion

        #region Metodos

        /// <summary>
        ///     Retorna los datos del alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n",base.Nombre, base.Apellido);
            sb.AppendLine("NACIONALIDAD: " + base.Nacionalidad);
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }
        /// <summary>
        ///     Retorna la una cadena con la clase que se esta tomando.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA LA CLASE DE {0}", this.claseQueToma);
        }
        /// <summary>
        ///     Retorna los datos del Alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        ///     Comprueva si el alumno esta tomado la clase pasasda.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna true si toma la clase, de lo contrario false.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if((a.estadoCuenta != EEstadoCuenta.Deudor) && (a.claseQueToma == clase))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        ///     Comprueva si las clases son distintas y su estado de cuenta.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna true si toma la clase, de lo contrario false.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if(a.claseQueToma != clase)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
