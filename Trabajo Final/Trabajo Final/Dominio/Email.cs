using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Dominio
{
    /// <summary>
    /// Representa un Email
    /// </summary>
    public class Email
    {
        private String iRemitente;

        private IList<String> iDestinatario;

        private String iCuerpo;

        private IList<String> iConCopia;

        private IList<String> iConCopiaOculta;

        private String iAsunto;

        public Email(String pRemitente,List<String> pDestinatario, List<String> pCC, List<String> pCCO, String pCuerpo, String pAsunto)
        {
            this.iRemitente = pRemitente;
            this.iDestinatario = pDestinatario;
            this.iCuerpo = pCuerpo;
            this.iAsunto = pAsunto;
            this.iConCopia = pCC;
            this.iConCopiaOculta = pCCO;
        }

        /// <summary>
        /// Devuelve el componente remitente.
        /// </summary>
        public String Remitente
        {
            get { return this.iRemitente; }
        }

        /// <summary>
        /// Devuelve el componente Destinatario.
        /// </summary>
        public IList<String> Destinatario
        {
            get { return this.iDestinatario; }
        }

        /// <summary>
        /// Devuelve el componente Con Copia a.
        /// </summary>
        public IList<String> ConCopia
        {
            get { return this.iConCopia; }
        }

        /// <summary>
        /// Devuelve el componente Con Copia Oculta a.
        /// </summary>
        public IList<String> ConCopiaOculta
        {
            get { return this.iConCopiaOculta; }
        }

        /// <summary>
        /// Devuelve el cuerpo del Email.
        /// </summary>
        public String Cuerpo
        {
            get { return this.iCuerpo; }
        }

        /// <summary>
        /// Devuelve el asunto del Email.
        /// </summary>
        public String Asunto
        {
            get { return this.iAsunto; }
        }
    }
}
