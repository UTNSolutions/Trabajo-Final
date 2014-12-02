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
    class ServicioYahoo : IServicio
    {
        private string iNombre;
        private Cuenta cuenta;
        private NetworkCredential credenciales;

        public void ServicioYahoo(string pNombre, Cuenta pCuenta)
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

        public IList<System.Net.Mail.MailMessage> RecibirMail()
        {
            IList<System.Net.Mail.MailMessage> listaMail = new List<System.Net.Mail.MailMessage>
            // Create a folder named "inbox" under current directory
            // to save the email retrieved.
            string curpath = Directory.GetCurrentDirectory();
            string mailbox = String.Format("{0}\\inbox", curpath);

            // If the folder is not existed, create it.
            if (!Directory.Exists(mailbox))
            {
                Directory.CreateDirectory(mailbox);
            }

            // Yahoo POP3 server is "pop.mail.yahoo.com"
            MailServer oServer = new MailServer("pop.mail.yahoo.com",
                        "myid@yahoo.com", "yourpassword", ServerProtocol.Pop3);
            MailClient oClient = new MailClient("TryIt");

            // Set SSL connection
            oServer.SSLConnection = true;

            // Set 995 SSL port
            oServer.Port = 995;

            try
            {
                oClient.Connect(oServer);
                MailInfo[] infos = oClient.GetMailInfos();
                for (int i = 0; i < infos.Length; i++)
                {
                    MailInfo info = infos[i];
                    Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}",
                        info.Index, info.Size, info.UIDL);

                    // Receive email from Yahoo POP3 server
                    Mail oMail = oClient.GetMail(info);

                    Console.WriteLine("From: {0}", oMail.From.ToString());
                    Console.WriteLine("Subject: {0}\r\n", oMail.Subject);

                    // Generate an email file name based on date time.
                    System.DateTime d = System.DateTime.Now;
                    System.Globalization.CultureInfo cur = new
                        System.Globalization.CultureInfo("en-US");
                    string sdate = d.ToString("yyyyMMddHHmmss", cur);
                    string fileName = String.Format("{0}\\{1}{2}{3}.eml",
                        mailbox, sdate, d.Millisecond.ToString("d3"), i);

                    // Save email to local disk
                    oMail.SaveAs(fileName, true);

                    // Mark email as deleted in Yahoo account.
                    oClient.Delete(info);
                }

                // Quit and pure emails marked as deleted from Yahoo POP3 server.
                oClient.Quit();
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
            }
        }
    }
}
