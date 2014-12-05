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
        void EnviarMail(EmailDTO pMail);

        /// <summary>
        /// Permite recibir emails
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="EmailExcepcion"></exception>
        IList<MailMessage> RecibirMail();

        Cuenta Cuenta { get; set; }

        bool AccesoInternet();

    }
}
