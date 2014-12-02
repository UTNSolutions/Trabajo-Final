using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Trabajo_Final.Excepciones;
using OpenPop.Pop3;

namespace Trabajo_Final
{
    class ServicioGmail : IServicio
    {
        private String iNombre;
        private Cuenta cuenta;
        private NetworkCredential credenciales;

        public ServicioGmail(String pNombre, Cuenta pCuenta)
        {
            this.iNombre = pNombre;
            this.cuenta = pCuenta;
            this.credenciales = new NetworkCredential(this.pCuenta.Direccion, this.pCuenta.Contraseña);
        }

        public void EnviarMail(MailMessage pMail)
        {           
            SmtpClient client = new SmtpClient();

            client.Credentials = this.credenciales;

            client.Port = 587;

            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;  //Esto es para que vaya a través de SSL que es obligatorio con GMail
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
            Pop3Client client = new Pop3Client();
            client.Authenticate(this.cuenta.Direccion, this.cuenta.Contraseña);
        }
    }
}
