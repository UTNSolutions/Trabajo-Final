using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trabajo_Final.Dominio;
using Microsoft.Exchange.WebServices.Data;
using System.Collections.Generic;

namespace ExportarEmlTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExportarTextoPlanoTest()
        {
            IList<string> destinos = new List<string>();
            destinos.Add("mati.gmail.com");
            destinos.Add("hola.yahoo.es");
            Email email = new Email("mati.d@live.com.ar",destinos,"hola como andas?","consulta");
            ExportadorTextoPlano.Exportar(@"C:\export\email.txt",email);

        }
    }
}
