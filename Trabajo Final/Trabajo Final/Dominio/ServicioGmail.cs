using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Net.Mail;
using Trabajo_Final.Excepciones;
using OpenPop.Pop3;
using OpenPop.Mime;
using Trabajo_Final.Persistencia;
using Trabajo_Final.DTO;
using System.Text.RegularExpressions;
using System.IO;


namespace Trabajo_Final.Dominio
{
    public class ServicioGmail : Servicio
    {
        private String iNombre;
        //Representa las credenciales de una cuenta de correo que se necesitan para 
        //realizar el envio de una Email
        private NetworkCredential iCredenciales;

        public ServicioGmail(String pNombre)
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
                throw new NullReferenceException("No hay una cuenta asociada para realizar la operacion");
            }
            //Configuro las credenciales de la cuenta para poder establecer la conexion
            this.iCredenciales = new NetworkCredential(pCuenta.Direccion, pCuenta.Contraseña);
            foreach (string destinatario in pMail.Destinatario)
            {
                if (!(Regex.IsMatch(destinatario, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*")))
                {
                    throw new EmailExcepcion("El destinatario no posee la estructura correcta");
                }
                if (!AccesoInternet())
                {
                    throw new InternetExcepcion("Existe un problema con la conexión a Internet");
                }
                SmtpClient client = new SmtpClient();

                client.PickupDirectoryLocation = @"C:\Users\Brian\Desktop\Mail";
                client.Credentials = this.iCredenciales;

                client.Port = 587;

                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;  //Esto es para que vaya a través de SSL que es obligatorio con GMail
                MailMessage email = new MailMessage(pCuenta.Direccion, destinatario, pMail.Asunto, pMail.Cuerpo);
                if (pMail.Adjunto.Count != 0)
                {
                    foreach (String adjunto in pMail.Adjunto)
                    {
                        email.Attachments.Add(new Attachment(adjunto));
                    }
                }
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
                client.Authenticate(pCuenta.Direccion, pCuenta.Contraseña);
                int indice = 1;
                IList<Email> listaADevolver = new List<Email>();
                while (indice <= client.GetMessageCount())
                {
                    Message mail = client.GetMessage(indice);                    
                    MailMessage email = mail.ToMailMessage();
                    IList<String> listaDestinatarios = new List<String>();
                    IList<String> listaCC = new List<String>();
                    IList<String> listaCCO = new List<String>();
                    IList<String> listaAdjunto = new List<String>();
                    listaDestinatarios.Add(Convert.ToString(email.To));
                    if (email.CC.Count > 0)
                    {
                        foreach (MailAddress cadenaCC in email.CC)
                        {
                            listaCC.Add(cadenaCC.ToString());
                        }
                    }
                    if (email.Bcc.Count > 0)
                    {
                        foreach (MailAddress cadenaCCO in email.Bcc)
                        {
                            listaCCO.Add(cadenaCCO.ToString());
                        }
                    }
                    if ( email.Attachments != null)
                    {
                        
                        foreach(Attachment adjunto in email.Attachments)
                        {
                            
                            String DirectorioDescarga =  @"C:\hola\";
                            String nuevoPath = DirectorioDescarga +@"\"+ adjunto.Name;
                            if (!Directory.Exists(nuevoPath))
                            {
                                FileStream file = new FileStream(nuevoPath, FileMode.Create);
                                adjunto.ContentStream.CopyTo(file, 409633333);
                                listaAdjunto.Add(adjunto.Name);
                                file.Close();
                            }
                        }
                    }
                    //Si el cuerpo esta en HTML lo trasforma.
                    if (email.IsBodyHtml)
                    {
                        //deshace de las etiquetas HTML.
                        email.Body = Regex.Replace(email.Body, "<[^>]*>", string.Empty);                      
                    }
                    //obtengo la fecha de dicho Email
                    DateTime fecha = mail.Headers.DateSent;
                    Email msj = new Email(Convert.ToString(email.From), listaDestinatarios, listaCC, listaCCO, email.Body, email.Subject,listaDestinatarios,fecha,false);
                    listaADevolver.Add(msj);
                    indice++;
                }
                client.Disconnect();
                return listaADevolver;
            }
            catch(OpenPop.Pop3.Exceptions.PopServerNotFoundException)
            {
                throw new EmailExcepcion("Error en el servidor de " + pCuenta.NombreServicio + ", no responde");
            }
            catch(OpenPop.Pop3.Exceptions.PopServerException)
            {
                throw new EmailExcepcion("Error en el servidor de " + pCuenta.NombreServicio + ", no responde");
            }
            catch (OpenPop.Pop3.Exceptions.InvalidLoginException)
            {
                throw new EmailExcepcion("Error en el acceso a la cuenta " + pCuenta.Nombre + ", verifique la configuracion de la misma");
            }
            catch (IOException)
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
