using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public enum ENacionalidad { Argentino, Extranjero }

        #region Constructores

        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nacionalidad = nacionalidad;
            this.Nombre = nombre;
            this.Apellido = apellido;

        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        #endregion

        #region Propiedades

        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                if (value == this.ValidarNombreApellido(value))
                {
                    this.apellido = value;
                }
            }
        }

        public int DNI
        {
            get { return this.dni; }
            set
            {
              this.dni =  this.ValidarDni(this.nacionalidad, value);

            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }

            set
            {
                if (value == this.ValidarNombreApellido(value))
                {
                    this.nombre = value;
                }
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        #endregion

        #region Metodos
        /// <summary>
        ///     Valida que el DNI pasado cumpla con las normas.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Retorna el dni</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            try
            {
                if ((nacionalidad == ENacionalidad.Argentino && dato < 89999999 && dato > 1) || (nacionalidad == ENacionalidad.Extranjero && dato > 90000000 && dato < 99999999))
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no condice con el numero de DNI");
                }
            }
            catch (NacionalidadInvalidaException e)
            {
                throw e;
            }

        }
        /// <summary>
        ///     Valida que el DNI pasado cumpla con las normas.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Retorna el strin pasado a entero.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                 if(int.TryParse(dato, out int aux))
                {
                    return this.ValidarDni(nacionalidad, aux);
                }
                else
                {
                    throw new DniInvalidoException();
                }
                 
            }
            catch (DniInvalidoException e)
            {
                throw e;
            }
   
        }
        /// <summary>
        ///     Valida que el nombre y apellido sean validos.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Retorna dato si es valido, contrario "" si no lo es.</returns>
        private string ValidarNombreApellido(string dato)
        {

            foreach (char c in dato)
            {
                if (!Char.IsLetter(c))
                {

                    dato = "";
                    break;
                }
            }
            return dato;
        }
        /// <summary>
        ///     Retorna todos los datos de Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nombre: " + this.Nombre);
            sb.AppendLine("Apellido: " + this.Apellido);
            sb.AppendLine("Nacionalidad: " + this.Nacionalidad);
            sb.AppendLine("DNI: " + this.DNI);

            return sb.ToString();
        }
        #endregion
    }
}
