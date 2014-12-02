﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Trabajo_Final.Excepciones;
using OpenPop.Pop3;
using OpenPop.Mime;

namespace Trabajo_Final
{
    class ServicioGmail : IServicio
    {
        private String iNombre;
        private Cuenta iCuenta;
        private NetworkCredential iCredenciales;

        public ServicioGmail(String pNombre, Cuenta pCuenta)
        {
            this.iNombre = pNombre;
            this.iCuenta = pCuenta;
            this.iCredenciales = new NetworkCredential(this.iCuenta.Direccion, this.iCuenta.Contraseña);
        }

        public void EnviarMail(MailMessage pMail)
        {           
            SmtpClient client = new SmtpClient();

            client.Credentials = this.iCredenciales;

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
            client.Connect("smtp.gmail.com", 587, true);
            client.Authenticate(this.iCuenta.Direccion, this.iCuenta.Contraseña);
            int numeroMails = client.GetMessageCount();
            int indice = 0;
            IList<MailMessage> listaADevolver = new List<MailMessage>();
            while (indice <= numeroMails)
            {
                Message mail = client.GetMessage(indice);
               
            }

        }
    }
}
