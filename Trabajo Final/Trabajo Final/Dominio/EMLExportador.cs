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
            get
            {
                return this.iNombre;
            }
        }

        public void Exportar(string pRuta, Email pEMail)
        {
            if (pRuta == null)
            {
                throw new ArgumentNullException("La ruta pasada es nula");
            }
            SmtpClient client = new SmtpClient();
            //establezco que el email saliente se tiene que guardar en un directorio especificado
            client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            MailMessage email = new MailMessage(pEMail.Remitente, pEMail.Destinatario[0], pEMail.Asunto, pEMail.Cuerpo);
            //establezco el directorio donde se quiere alojar el Email
            client.PickupDirectoryLocation = pRuta;
            client.DeliveryFormat = SmtpDeliveryFormat.International;
            client.Send(email);
        }
    }
}

