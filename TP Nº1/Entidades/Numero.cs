using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        //Constructor Por Defecto
        public Numero()
        {
            this.numero = 0;
        }
        //Consotructor con paramentro Double
        public Numero(double numero)
        {
            this.numero = numero;
        }   
        //Consotructor con paramentro string
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }
        /// <summary>
        ///     Setea el string ingresado en el atributo numero.
        /// </summary>
        public string SetNumero
        {
            set
            { 
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        ///     Validar que la cadena Ingresada sea Numerica.
        /// </summary>
        /// <param name="strNumero">
        ///     Cadena con el numero ingresado.
        /// </param>
        /// <returns>
        ///     Retorna la cadena parsea a Double. Contrario Retorna 0.
        /// </returns>
        private double ValidarNumero(string strNumero)
        {
            double aux = 0;
            //Analiza que sea numerico
            for (int i=0; i<strNumero.Length; i++)
            {
               
                if ( !(strNumero[i] <= '9' && strNumero[i] >= '0'))
                {
                    return 0;
                }

            }
            //Parsea el numero ingresado
            double.TryParse(strNumero, out aux);

            return aux;
        }
        /// <summary>
        ///     Pasa de Binario a Decimal.
        /// </summary>
        /// <param name="binario">
        ///     La cadena con el Binario;
        /// </param>
        /// <returns>
        ///     Retorna le Decimal pasado a cadena.
        /// </returns>
        public string BinaroDecimal(string binario)
        {

            int exponente = binario.Length - 1;
            double numeroDecimal = 0;

            for (int i = 0; i < binario.Length; i++)
            {
                if (int.Parse(binario.Substring(i, 1)) == 1)
                {
                    numeroDecimal = numeroDecimal + double.Parse(System.Math.Pow(2, double.Parse(exponente.ToString())).ToString());
                }
                exponente--;
            }
            
            return string.Format("{0}", numeroDecimal);
        }
        /// <summary>
        ///     Pasa de Decimal a Binario.
        /// </summary>
        /// <param name="numero">
        ///     Recibe un double Decimal.
        /// </param>
        /// <returns>
        ///     Retorna  la cadena del numero convertido a Binario.
        /// </returns>
        public string DecimalBinario(double numero)
        {
            string cadena = "";
            if (numero > 0)
            {
                
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }

                    numero = (int)(numero / 2);
                }
            }
            else
            {
                cadena = "0";
            }

            return cadena;
        }
        /// <summary>
        ///     Pasa de decimal a binario.
        /// </summary>
        /// <param name="numero">
        ///     Cadena del numero decimal.
        /// </param>
        /// <returns>
        ///     Retorna la cadena del numero binario.
        /// </returns>
        public string DecimalBinario(string numero)
        {
            double aux = 0;
            double.TryParse(numero, out aux);
            return DecimalBinario(aux);
        }
        /// <summary>
        ///     Sobrecarga del operador "+", suma dos objetos Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>
        ///     Retorna la suma de sus atributos. 
        /// </returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        ///     Sobrecarga del operador "-", resta dos objetos Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>
        ///     Retorna la resta de sus atributos. 
        /// </returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        ///     Sobrecarga del operador "*", multiplicacion dos objetos Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>
        ///     Retorna la multiplicacion de sus atributos. 
        /// </returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        ///     Sobrecarga del operador "/", divide dos objetos Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>
        ///     Retorna la division de sus atributos. 
        /// </returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MaxValue;
            }

            return n1.numero / n2.numero;
        }
    }
}
