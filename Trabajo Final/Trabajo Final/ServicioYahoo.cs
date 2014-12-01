using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Trabajo_Final
{
    class ServicioYahoo : IServicio
    {
        private string iNombre;

        public void ServicioYahoo(string pNombre)
        {
            this.iNombre = pNombre;
        }

        public void EnviarMail(MailMessage pMail)
        {
            throw new NotImplementedException();
        }

        public IList<System.Net.Mail.MailMessage> RecibirMail()
        {
            throw new NotImplementedException();
        }
    }
}
