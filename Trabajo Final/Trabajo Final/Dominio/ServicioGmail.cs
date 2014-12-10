using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Trabajo_Final.Excepciones;
using OpenPop.Pop3;
using OpenPop.Mime;
using Trabajo_Final.Persistencia;
using Trabajo_Final.DTO;
using System.Text.RegularExpressions;
using System.Xml;



namespace Trabajo_Final.Dominio
{
    public class ServicioGmail : Servicio
    {
        private String iNombre;
        private Cuenta iCuenta;
        private NetworkCredential iCredenciales;

        public ServicioGmail(String pNombre)
        {
            this.iNombre = pNombre;
            this.iCuenta = null;            
        }

        public override Cuenta Cuenta
        {
            set
            {
                this.iCuenta = value;
                this.iCredenciales = new NetworkCredential(this.iCuenta.Direccion, this.iCuenta.Contraseña);
            }
        }

        public override string Nombre
        {
            get { return this.iNombre; }
        }

        public override void EnviarMail(Email pMail)
        {           
            if (this.iCuenta == null)
            {
                throw new NullReferenceException("No hay una cuenta asociada para realizar la operacion");
            }
            foreach (string destinatario in pMail.Destinatario)
            {
                String cadena = destinatario;
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

                client.Port = 587;

                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;  //Esto es para que vaya a través de SSL que es obligatorio con GMail
                MailMessage email = new MailMessage(this.iCuenta.Direccion, destinatario, pMail.Asunto, pMail.Cuerpo);
                try
                {
                    client.Send(email);
                }
                catch (SmtpFailedRecipientsException)
                {
                    throw new EmailExcepcion("No se pudo enviar el E-mail a todos los destinatarios, verifique los datos");        
                }
                catch (SmtpFailedRecipientException)
                {
                    throw new EmailExcepcion("No se pudo enviar el E-mail, verifique los datos");
                }
                catch (SmtpException)
                {
                    throw new EmailExcepcion("Fallo la autenticación de la direccion de correo, verifique los datos de la cuenta");
                }
            }
        }

        public override IList<Email> RecibirMail()
        {
            if (this.iCuenta == null)
            {
                throw new NullReferenceException("no hay una cuenta asociada para realizar la operacion");
            }
            if (!AccesoInternet())
            {
                throw new InternetExcepcion("Existe un problema con la conexión a Internet");
            }
            try
            {
                Pop3Client client = new Pop3Client();
                client.Connect("pop.gmail.com", 995, true);
                client.Authenticate(this.iCuenta.Direccion, this.iCuenta.Contraseña);
                int indice = 1;
                IList<Email> listaADevolver = new List<Email>();
                while (indice <= client.GetMessageCount())
                {
                   Message mail = client.GetMessage(indice);
                  
                   MailMessage email = mail.ToMailMessage();
                   IList<String> listaDestinatarios = new List<String>();                 
                   listaDestinatarios.Add(Convert.ToString(email.To));
                   Email msj = new Email(Convert.ToString(email.From), listaDestinatarios, email.Body, email.Subject);
                    listaADevolver.Add(msj);
                    indice++;
                }
                client.Disconnect();
                return listaADevolver;
            }
            catch(OpenPop.Pop3.Exceptions.PopServerException)
            {
                throw new EmailExcepcion("Error en el servidor, no responde");
            }
            catch (OpenPop.Pop3.Exceptions.InvalidLoginException)
            {
                throw new EmailExcepcion("Error en el acceso a la cuenta, verifique la configuracion de la misma");
            }
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
