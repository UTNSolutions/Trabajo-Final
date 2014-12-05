using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Trabajo_Final.DTO;

namespace Trabajo_Final.Dominio
{
    public abstract class Servicio : IServicio
    {
        private  Cuenta iCuenta;
        private  string iNombre;

        public abstract void EnviarMail(EmailDTO pMail);

        public abstract IList<MailMessage> RecibirMail();

        public abstract Cuenta Cuenta { get; set; }

        public abstract string Nombre { get; }

        public abstract bool AccesoInternet();

        }
}
