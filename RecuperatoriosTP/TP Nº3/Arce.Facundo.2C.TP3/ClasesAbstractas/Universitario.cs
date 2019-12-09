using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalida)
            :base(nombre, apellido, dni, nacionalida)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos

        protected abstract string ParticiparEnClase();

        /// <summary>
        ///     Retorna todos los datos del universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nLEGAJO NUMERO: " + this.legajo);

            return sb.ToString();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        ///     Ve si dos universitarios son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Retorna true si lo son de lo contrario false.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if ((pg1.GetType() == pg2.GetType()) && ((pg1.legajo == pg2.legajo) || (pg1.DNI == pg2.DNI)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        ///     Ve si dos universitarios son diferentes.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Retorna true si lo son de lo contrario false.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        ///     Comprueba si un obj es de tipo universitario.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>retorna true si lo es, de lo contrario false.</returns>
        public override bool Equals(object obj)
        {
            return (obj is Universitario);
        }
        #endregion
    }
}
