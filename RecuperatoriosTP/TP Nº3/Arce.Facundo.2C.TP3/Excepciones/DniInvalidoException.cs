using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {           //incompleto
        private string mensajeBase;

        public DniInvalidoException()
            :base("DNI INVALIDO")
        { }

        public DniInvalidoException(string message, Exception e)
            :base(message, e)
        { }

        public DniInvalidoException(Exception e)
            :this("DNI INVALIDO", e)
        { }

        public DniInvalidoException(string message)
            :this(message, new Exception())
        { }

        
    }
}
