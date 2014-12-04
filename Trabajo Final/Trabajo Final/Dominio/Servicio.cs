using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Trabajo_Final.Dominio
{
    public abstract class Servicio : IServicio
    {
        private  Cuenta iCuenta;
        private  string iNombre;

        public abstract void EnviarMail(MailMessage pMail);

        public abstract IList<MailMessage> RecibirMail();

        public abstract Cuenta Cuenta { get; set; }

        public abstract string Nombre { get; }

    }
}
