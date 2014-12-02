using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Excepciones
{
    /// <summary>
    /// Excepcion que se produce cuando ocurre un error en la capa DAO
    /// </summary>
    class DAOExcepcion : Exception 
    {
        public DAOExcepcion (String pMensaje) : base(pMensaje)
        { }
    }
}
