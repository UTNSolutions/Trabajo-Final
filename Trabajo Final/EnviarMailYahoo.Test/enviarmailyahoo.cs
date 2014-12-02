using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trabajo_Final;
using System.Net.Mail;

namespace EnviarMailYahoo.Test
{
    [TestClass]
    public class enviarmailyahoo
    {
        [TestMethod]
        public void envio1()
        {
            Cuenta nuevaCuenta = new Cuenta("Brian", "brian_fellin@yahoo.com", "yahoo", "brianyahoo");
            IServicio servicioYahoo = new ServicioYahoo("yahoo",nuevaCuenta);
            MailMessage nuevoMail = new MailMessage();
            nuevoMail.From = new MailAddress(nuevaCuenta.Direccion);
            nuevoMail.To.Add("brian-fellin@yahoohotmail.com");
            nuevoMail.Subject = "Hola como andas";
            servicioYahoo.EnviarMail(nuevoMail);
        }
    }
}
