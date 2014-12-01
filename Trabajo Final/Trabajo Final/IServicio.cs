using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Trabajo_Final
{
    /// <summary>
    /// Representa operaciones para el manejo de una cuenta de correo
    /// </summary>
    interface IServicio
    {
        //Representa el nombre del servicio de correo, ej: Yahoo,Gmail
        String iNombre;

        /// <summary>
        /// Permite enviar un mail
        /// </summary>
        void EnviarMail();

        /// <summary>
        /// Permite recibir emails
        /// </summary>
        IList<MailMessage> RecibirMail();
    }
}
