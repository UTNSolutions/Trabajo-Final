﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Dominio
{
    /// <summary>
    /// Representa funcionalidades para exportar Emails al sistema de archivos de la pc
    /// </summary>
    interface IExportador
    {
 
        /// <summary>
        /// Obtiene el Nombre del Exportador
        /// </summary>
        String Nombre { get; }

        /// <summary>
        /// Exporta un email 
        /// </summary>
        /// <param name="pRuta">Ruta donde se alojara el archivo en el disco duro</param>
        /// <param name="pEmail">Email que se quiere exportar</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ExportadorExcepcion"></exception>
        void Exportar(String pRuta, Email pEMail);
    }
}
