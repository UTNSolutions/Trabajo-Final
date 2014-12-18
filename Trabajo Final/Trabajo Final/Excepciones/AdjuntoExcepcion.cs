using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Excepciones
{
    /// <summary>
    /// Excepcion que se produce cuando hay un error con un archivo adjunto
    /// </summary>
    class AdjuntoExcepcion : Exception 
    {
        public AdjuntoExcepcion(String pMensaje) : base (pMensaje)
        {

        }
    }
}
