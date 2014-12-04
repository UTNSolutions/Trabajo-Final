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

namespace Trabajo_Final.Dominio
{
    public class ServicioYahoo : Servicio
    {
        private string iNombre;
        private Cuenta iCuenta;
        private NetworkCredential iCredenciales;

        public ServicioYahoo(string pNombre)
        {
            this.iNombre = pNombre;
            this.iCuenta = null;
        }

        public override void EnviarMail(MailMessage pMail)
        {
            if (this.iCuenta == null)
            {
                throw new NullReferenceException("No hay una cuenta asociada para realizar la operación");
            }

            SmtpClient client = new SmtpClient();

            client.Credentials = this.iCredenciales;

            client.Port = 25;

            client.Host = "smtp.mail.yahoo.com";
            client.EnableSsl = true;  //Esto es para que vaya a través de SSL que es obligatorio con Yahoo
            try
            {
                client.Send(pMail);
            }
            catch (SmtpFailedRecipientsException)
            {
                throw new EmailExcepcion("No se pudo enviar el mail a todos los destinatarios, verifique los datos");
            }
            catch (SmtpFailedRecipientException)
            {
                throw new EmailExcepcion("No se pudo enviar el mail, verifique los datos");
            }

        }

        public override IList<MailMessage> RecibirMail()
        {
            if (this.iCuenta == null)
            {
                throw new NullReferenceException("No hay una cuenta asociada para realizar la operación");
            }
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
            catch (OpenPop.Pop3.Exceptions.PopServerException)
            {
                throw new EmailExcepcion("Error en el servidor, no responde");
            }
            catch (OpenPop.Pop3.Exceptions.InvalidLoginException)
            {
                throw new EmailExcepcion("Error en el acceso a la cuenta, verifique los datos ingresados");
            }
        }

        public override Cuenta Cuenta
        {
            get
            {
                return this.iCuenta;
            }
            set
            {
                this.iCuenta = value;
                this.iCredenciales = new NetworkCredential(iCuenta.Direccion, iCuenta.Contraseña);
            }
        }

        public override string Nombre
        {
            get { return this.iNombre; }
        }
    }
}
