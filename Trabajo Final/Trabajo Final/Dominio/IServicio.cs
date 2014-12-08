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
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="EmailExcepcion"></exception>
        /// <exception cref="InternetExcepcion"></exception>
        void EnviarMail(Email pMail);

        /// <summary>
        /// Permite recibir emails
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="EmailExcepcion"></exception>
        /// <exception cref="InternetExcepcion"></exception>
        IList<Email> RecibirMail();

        /// <summary>
        /// Setea una cuenta que al servicio de correo
        /// </summary>
        Cuenta Cuenta { set; }

        /// <summary>
        /// Verifica la conexion a Internet
        /// </summary>
        /// <returns></returns>
        bool AccesoInternet();

    }
}
