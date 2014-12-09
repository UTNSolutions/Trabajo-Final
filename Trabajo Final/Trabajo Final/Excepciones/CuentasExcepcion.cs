using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Excepciones
{
    /// <summary>
    /// Excepcion que se produce cuando la lista de cuentas se encuentra vacia
    /// </summary>
    class CuentasExcepcion : Exception 
    {
        public CuentasExcepcion(String pMensaje) : base(pMensaje)
        { }

    }
}
