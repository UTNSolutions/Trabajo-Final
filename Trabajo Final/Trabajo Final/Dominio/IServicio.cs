using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Trabajo_Final.Persistencia;
using Trabajo_Final.DTO;

namespace Trabajo_Final.Dominio
{
    /// <summary>
    /// Representa operaciones para el manejo de una cuenta de correo
    /// </summary>
    public interface IServicio
    {
        /// <summary>
        /// Permite enviar un mail       
        /// </summary>
        /// <param name="pMail">Email a enviar</param>
        /// <param name="pCuenta">Cuenta con la que se quiere enviar el Email</param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="EmailExcepcion"></exception>
        /// <exception cref="InternetExcepcion"></exception>
        void EnviarMail(Email pMail,Cuenta pCuenta);

        /// <summary>
        /// Permite recibir emails
        /// </summary>
        /// <param name="pCuenta">Cuenta de la que se quiere recibir los Emails</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="EmailExcepcion"></exception>
        /// <exception cref="InternetExcepcion"></exception>
        IList<Email> RecibirMail(Cuenta pCuenta);


        /// <summary>
        /// Verifica la conexion a Internet
        /// </summary>
        /// <returns></returns>
        bool AccesoInternet();

    }
}
