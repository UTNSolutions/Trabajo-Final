using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Trabajo_Final.Excepciones;

namespace Trabajo_Final
{
    public class ServicioYahoo : IServicio
    {
        private string iNombre;
        private Cuenta cuenta;
        private NetworkCredential credenciales;

        public ServicioYahoo(string pNombre, Cuenta pCuenta)
        {
            this.iNombre = pNombre;
            this.cuenta = pCuenta;
            this.credenciales = new NetworkCredential(pCuenta.Direccion, pCuenta.Contraseña);
        }

        public void EnviarMail(MailMessage pMail)
        {
            SmtpClient client = new SmtpClient();

            client.Credentials = this.credenciales;

            client.Port = 25;

            client.Host = "smtp.mail.yahoo.com";
            client.EnableSsl = true;  //Esto es para que vaya a través de SSL que es obligatorio con Yahoo
            try
            {
                client.Send(pMail);
            }
            catch (SmtpException)
            {
                throw new EmailExcepcion("No se pudo enviar el mail, verifique los datos");
            }
        }

        public IList<MailMessage> RecibirMail()
        {
            throw new NotImplementedException();
        }
    }
}
