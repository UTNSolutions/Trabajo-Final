using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Excepciones
{
    /// <summary>
    /// Excepcion que se produce cuando hay un problema con la conexion a internet
    /// </summary>
    class InternetExcepcion : Exception
    {
        public InternetExcepcion(String pMensaje) : base(pMensaje)
        { }
    }
}
