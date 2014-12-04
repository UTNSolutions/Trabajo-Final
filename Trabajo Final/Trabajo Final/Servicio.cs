using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Trabajo_Final
{
    abstract class Servicio : IServicio
    {
        private abstract Cuenta iCuenta;
        private abstract string iNombre;

        public abstract void EnviarMail(MailMessage pMail);

        public abstract IList<MailMessage> RecibirMail();

        public abstract Cuenta Cuenta { get; set; }

        public abstract string Nombre { get; }

    }
}
