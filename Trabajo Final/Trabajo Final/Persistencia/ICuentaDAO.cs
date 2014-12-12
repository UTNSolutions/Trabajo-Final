using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Final.DTO;

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

        /// <summary>
        /// Obtiene una cuenta de correo electronico identificada por su nombre.
        /// </summary>
        /// <param name="pNombreCuenta"></param>
        /// <returns></returns>
        CuentaDTO BuscarCuenta(string pNombreCuenta);

        /// <summary>
        /// Permite establecer la hora del ultimo correo recibido del servidor de correo de dicha cuenta
        /// </summary>
        /// <param name="pUltimaConexion"></param>
        void EstablecerUltimaConexion(DateTime pUltimaConexion, string pNombreCuenta);

        /// <summary>
        /// Obtiene la hora del ultimo correo recibido (fecha y hora) del servidor de correo de la cuenta 
        /// </summary>
        /// <param name="pIdCuenta"></param>
        /// <returns></returns>
        DateTime ObtenerUltimaConexion(string pNombreCuenta);

    }
}
