using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        ///     Valida que el operador ingresado sea correcto.
        /// </summary>
        /// <param name="operador">
        ///     Operador Ingresado.
        /// </param>
        /// <returns>
        ///     Retorna el operador ingresado. Contrario retorna un "+".
        /// </returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                return operador;
            }
            return "+";
        }
        /// <summary>
        ///     Realiza la operacion entre dos objetos Numero con el operador indicado.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>
        ///     Retorna el resultado de la operacion indicada.
        /// </returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;

            switch (ValidarOperador(operador))
            {
                case "+":   //Caso de que sea una suma.
                   retorno = num1 + num2;
                    break;
                case "-":   //Caso de que sea una resta.
                    retorno = num1 - num2;
                    break;
                case "*":   //Caso de que sea una multiplicacion.
                    retorno = num1 * num2;
                    break;
                case "/":   //Caso de que sea una Division.
                    retorno = num1 / num2;
                    break;
            }

            return retorno;
        }

    }
}
