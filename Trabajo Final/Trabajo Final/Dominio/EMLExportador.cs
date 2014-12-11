using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace Trabajo_Final.Dominio
{
    public class EMLExportador : IExportador
    {
        private String iNombre;

        public EMLExportador(String pNombre)
        {
            this.iNombre = pNombre;
        }

        public string Nombre
        {
            get { return this.iNombre; }
        }

        public void Exportar(string pRuta, Email pEMail)
        {
            SmtpClient cliente = new SmtpClient();            
            String cadenaTo = "";
            foreach(String destinatario in pEMail.Destinatario)
            {
                cadenaTo = destinatario;
            }
            MailMessage mail = new MailMessage(pEMail.Remitente, cadenaTo,pEMail.Asunto,pEMail.Cuerpo);
            cliente.Host = "stmp.gmail.com";
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Credentials = new NetworkCredential("matiadr13@gmail.com", "utnsist14");
            cliente.PickupDirectoryLocation = @"C:\Users\Brian\Desktop\Mail";
            cliente.Send(mail);
        }
    }
}
    
