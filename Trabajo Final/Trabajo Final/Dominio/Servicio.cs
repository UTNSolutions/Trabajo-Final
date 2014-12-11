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

        public abstract void EnviarMail(Email pMail, Cuenta pCuenta);

        public abstract IList<Email> RecibirMail(Cuenta pCuenta);

        public abstract string Nombre { get; }

        public abstract bool AccesoInternet();     
    }
}
