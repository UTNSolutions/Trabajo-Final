using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Trabajo_Final.Persistencia;

namespace Trabajo_Final
{
    /// <summary>
    /// Representa operaciones para el manejo de una cuenta de correo
    /// </summary>
    public interface IServicio
    {
        /// <summary>
        /// Permite enviar un mail
        /// </summary>
        void EnviarMail(MailMessage pMail);

        /// <summary>
        /// Permite recibir emails
        /// </summary>
        IList<MailMessage> RecibirMail();
    }
}
