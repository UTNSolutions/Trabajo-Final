using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Trabajo_Final.Excepciones;
using OpenPop.Pop3;
using OpenPop.Mime;

namespace Trabajo_Final
{
    public class ServicioYahoo : IServicio
    {
        private string iNombre;
        private Cuenta iCuenta;
        private NetworkCredential iCredenciales;

        public ServicioYahoo(string pNombre, Cuenta pCuenta)
        {
            this.iNombre = pNombre;
            this.iCuenta = pCuenta;
            this.iCredenciales = new NetworkCredential(pCuenta.Direccion, pCuenta.Contraseña);
        }

        public void EnviarMail(MailMessage pMail)
        {
            SmtpClient client = new SmtpClient();

            client.Credentials = this.iCredenciales;

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
            try
            {
                Pop3Client client = new Pop3Client();
                client.Connect("pop.mail.yahoo.com", 995, true);
                client.Authenticate(this.iCuenta.Direccion, this.iCuenta.Contraseña);
                int indice = 1;
                IList<MailMessage> listaADevolver = new List<MailMessage>();
                while (indice <= client.GetMessageCount())
                {
                    Message mail = client.GetMessage(indice);
                    MailMessage msj = mail.ToMailMessage();
                    listaADevolver.Add(msj);
                    indice++;
                }
                client.Disconnect();
                return listaADevolver;
            }
            catch (OpenPop.Pop3.Exceptions.InvalidLoginException)
            {
                throw new EmailExcepcion("Error en el acceso a la cuenta, verifique los datos ingresados");
            }
        }
    }
}
