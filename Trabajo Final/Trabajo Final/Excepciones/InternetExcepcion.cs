using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Excepciones
{
    class InternetExcepcion : Exception
    {
        public InternetExcepcion(String pMensaje) : base(pMensaje)
        { }
    }
}
