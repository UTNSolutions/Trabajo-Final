using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Excepciones
{
    /// <summary>
    /// Excepcion que se produce cuando se violo el nombre de cuenta, ya que este debe ser univoco
    /// </summary>
    class NombreCuentaExcepcion : Exception 
    {
        public NombreCuentaExcepcion (String pMensaje) : base (pMensaje)
        { }
    }
}
