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

        private String iDestinatario;

        private String iCuerpo;

        private String iAsunto;

        public Email(String pRemitente,String pDestinatario,String pCuerpo, String pAsunto)
        {
            this.iRemitente = pRemitente;
            this.iDestinatario = pDestinatario;
            this.iCuerpo = pCuerpo;
            this.iAsunto = pAsunto;
        }

        /// <summary>
        /// Devuelve el componente remitente
        /// </summary>
        public String Remitente
        {
            get { return this.iRemitente; }
        }

        /// <summary>
        /// Devuelve el componente Destinatario
        /// </summary>
        public String Destinatario
        {
            get { return this.iDestinatario; }
        }

        /// <summary>
        /// Devuelve el cuerpo del Email
        /// </summary>
        public String Cuerpo
        {
            get { return this.iCuerpo; }
        }

        /// <summary>
        /// Devuelve el asunto del Email
        /// </summary>
        public String Asunto
        {
            get { return this.iAsunto; }
        }
    }
}
