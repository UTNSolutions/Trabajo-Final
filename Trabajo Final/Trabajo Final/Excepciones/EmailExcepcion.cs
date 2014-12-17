﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Excepciones
{
    /// <summary>
    /// Excepcion que se produce cuando hay un error en un Email de una cuenta
    /// </summary>
    class EmailExcepcion : Exception 
    {
        public EmailExcepcion(String pMensaje) : base(pMensaje)
        { }
    }
}
