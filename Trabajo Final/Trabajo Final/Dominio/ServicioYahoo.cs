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
using Trabajo_Final.DTO;
using System.Text.RegularExpressions;

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
                
        public override void EnviarMail(Email pMail)
        {
            if (this.iCuenta == null)
            {
                throw new NullReferenceException("No hay una cuenta asociada para realizar la operación");
            }
            String cadena = pMail.Destinatario;
            if (!(Regex.IsMatch(cadena, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*")))
            {
                throw new EmailExcepcion("El destinatario no posee la estructura correcta");
            }
            if (!AccesoInternet())
            {
                throw new InternetExcepcion("Existe un problema con la conexión a Internet");
            }
            SmtpClient client = new SmtpClient();

            client.Credentials = this.iCredenciales;

            client.Port = 25;

            client.Host = "smtp.mail.yahoo.com";
            client.EnableSsl = true;  //Esto es para que vaya a través de SSL que es obligatorio con Yahoo
            MailMessage email = new MailMessage(this.iCuenta.Direccion, pMail.Destinatario, pMail.Asunto, pMail.Cuerpo);
            try
            {
                client.Send(email);
            }
            catch (SmtpFailedRecipientsException)
            {
                throw new EmailExcepcion("No se pudo enviar el mail a todos los destinatarios, verifique los datos");
            }
            catch (SmtpFailedRecipientException)
            {
                throw new EmailExcepcion("No se pudo enviar el mail, verifique los datos");
            }
            catch (SmtpException)
            {
                throw new EmailExcepcion("Fallo la autenticación de la direccion de correo, verifique los datos de la cuenta");
            }
        }

        public override IList<Email> RecibirMail()
        {
            if (this.iCuenta == null)
            {
                throw new NullReferenceException("No hay una cuenta asociada para realizar la operación");
            }
            if (!AccesoInternet())
            {
                throw new InternetExcepcion("Existe un problema con la conexión a Internet");
            }
            try
            {
                Pop3Client client = new Pop3Client();
                client.Connect("pop.mail.yahoo.com", 995, true);
                client.Authenticate(this.iCuenta.Direccion, this.iCuenta.Contraseña);
                int indice = 1;
                IList<Email> listaADevolver = new List<Email>();
                while (indice <= client.GetMessageCount())
                {
                    Message mail = client.GetMessage(indice);
                    MailMessage email = mail.ToMailMessage();
                    Email msj = new Email(Convert.ToString(email.From),Convert.ToString(email.To), email.Body, email.Subject);
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

        public override bool AccesoInternet()
        {
            try
            {
                IPHostEntry host = Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
