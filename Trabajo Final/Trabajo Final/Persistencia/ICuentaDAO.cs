﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Persistencia
{
    /// <summary>
    /// Representa funcionalidades para el manejo de una Cuenta de correo electronico
    /// </summary>
    interface ICuentaDAO
    {
        /// <summary>
        /// Permite insertar una nueva Cuenta de correo en la base de datos
        /// </summary>
        /// <param name="pCuenta"></param>
        void Insertar(CuentaDTO pCuenta);

        /// <summary>
        /// Permite modificar los datos de una cuenta de correo en la base de datos
        /// </summary>
        /// <param name="pCuenta"></param>
        void Modificar(CuentaDTO pCuenta);

        /// <summary>
        /// Permite eliminar una cuenta de correo en la base de datos
        /// </summary>
        /// <param name="pCuenta"></param>
        void Eliminar(CuentaDTO pCuenta);

        /// <summary>
        /// Obtiene todas las cuenta de correo electronico de la base de datos
        /// </summary>
        /// <returns></returns>
        IList<CuentaDTO> Obtener();
      

    }
}
