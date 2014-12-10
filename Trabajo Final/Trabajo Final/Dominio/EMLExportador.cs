using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using System.IO;
using System.Net.Mail;

namespace Trabajo_Final.Dominio
{
    public class EMLExportador
    {

        public static void ExportMIMEEmail(ExchangeService service)
        {
 /*            Folder inbox = Folder.Bind(service, WellKnownFolderName.Inbox);
            ItemView view = new ItemView(1);
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly);

            // This results in a FindItem call to EWS.
            FindItemsResults<Item> results = inbox.FindItems(view); 

            foreach (var item in results)
            {
                PropertySet props = new PropertySet(EmailMessageSchema.MimeContent); */

                // This results in a GetItem call to EWS.
            EmailMessage email = new EmailMessage(service);
            email.Body = "hola como andas";
            email.From = "mati.d@live.com.ar";

                string emlFileName = @"C:\export\email.eml";

                // Save as .eml.
                using (FileStream fs = new FileStream(emlFileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(email.MimeContent.Content, 0, email.MimeContent.Content.Length);
                }

            }
        }
    }

    
