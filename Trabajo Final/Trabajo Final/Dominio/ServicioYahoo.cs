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
using System.IO;

namespace Trabajo_Final.Dominio
{
    public class ServicioYahoo : Servicio
    {
        private string iNombre;
        //Representa las credenciales de una cuenta de correo que se necesitan para 
        //realizar el envio de una Email
        private NetworkCredential iCredenciales;

        public ServicioYahoo(string pNombre)
        {
            this.iNombre = pNombre;
        }

        public override string Nombre
        {
            get { return this.iNombre; }
        }
                
        public override void EnviarMail(Email pMail,Cuenta pCuenta)
        {
            
            if (pCuenta == null)
            {
                throw new NullReferenceException("No hay una cuenta asociada para realizar la operación");
            }
            //Configuro las credenciales de la cuenta para poder establecer la conexion
            this.iCredenciales = new NetworkCredential(pCuenta.Direccion, pCuenta.Contraseña);
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

                client.Port = 25;

                client.Host = "smtp.mail.yahoo.com";
                client.EnableSsl = true;  //Esto es para que vaya a través de SSL que es obligatorio con Yahoo
                MailMessage email = new MailMessage(pCuenta.Direccion, destinatario, pMail.Asunto, pMail.Cuerpo);
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
                catch (IOException)
                {
                    throw new EmailExcepcion("Error en el servidor de " + pCuenta.NombreServicio + ", no responde");
                }
            }
        }

        public override IList<Email> RecibirMail(Cuenta pCuenta)
        {
            if (pCuenta == null)
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
                client.Authenticate(pCuenta.Direccion, pCuenta.Contraseña);
                int indice = 1;
                IList<Email> listaADevolver = new List<Email>();
                while (indice <= client.GetMessageCount())
                {
                    Message mail = client.GetMessage(indice);
                    MailMessage email = mail.ToMailMessage();
                    IList<String> listaDestinatarios = new List<String>();
                    listaDestinatarios.Add(Convert.ToString(email.To));
                    //Si el cuerpo esta en HTML lo trasforma.
                    if (email.IsBodyHtml)
                    {
                        //desace de las etiquetas HTML.
                        email.Body = Regex.Replace(email.Body, "<[^>]*>", string.Empty);
                        //get rid of multiple blank lines
                        //email.Body = Regex.Replace(email.Body, @"^\s*$\n", string.Empty, RegexOptions.Multiline);
                    }
                    DateTime fecha = mail.Headers.DateSent;
                    Email msj = new Email(Convert.ToString(email.From),listaDestinatarios, email.Body, email.Subject,fecha);
                    listaADevolver.Add(msj);
                    indice++;
                }
                client.Disconnect();
                return listaADevolver;
            }
            catch (OpenPop.Pop3.Exceptions.PopServerException)
            {
                throw new EmailExcepcion("Error en el servidor de " + pCuenta.NombreServicio + ", no responde");
            }
            catch (OpenPop.Pop3.Exceptions.InvalidLoginException)
            {
                throw new EmailExcepcion("Error en el acceso a la cuenta " + pCuenta.Nombre + ", verifique la configuracion de la misma");
            }
            catch(IOException)
            {
                throw new EmailExcepcion("Error en el servidor de " + pCuenta.NombreServicio + ", no responde");
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
