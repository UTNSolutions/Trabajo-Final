using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Excepciones
{
    /// <summary>
    /// Excepcion que se produce cuando hay un error en el proceso de Exportar un correo
    /// </summary>
    class ExportadorExcepcion : Exception
    {
        public ExportadorExcepcion(String pMensaje): base (pMensaje)
        { }
    }
}
