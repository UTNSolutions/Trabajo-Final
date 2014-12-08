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

        public abstract void EnviarMail(Email pMail);

        public abstract IList<Email> RecibirMail();

        public abstract Cuenta Cuenta { set; }

        public abstract string Nombre { get; }

        public abstract bool AccesoInternet();

        }
}
