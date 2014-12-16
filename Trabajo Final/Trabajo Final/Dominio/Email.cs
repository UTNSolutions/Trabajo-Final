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
        private int iIdEmail;

        private String iRemitente;

        private IList<String> iDestinatario;

        private String iCuerpo;

       // private IList<String> iConCopia;

        //private IList<String> iConCopiaOculta;

        private String iAsunto;

        private DateTime iFecha;

        private bool iLeido;

        public Email(String pRemitente,IList<String> pDestinatario, String pCuerpo, String pAsunto,DateTime pFecha,bool pLeido)
        {
            this.iRemitente = pRemitente;
            this.iDestinatario = pDestinatario;
            this.iCuerpo = pCuerpo;
            this.iAsunto = pAsunto;
           // this.iConCopia = pCC;
          //  this.iConCopiaOculta = pCCO;
            this.iFecha = pFecha;
            this.iLeido = pLeido;
        }

        public Email(int pIdEmail,String pRemitente, IList<String> pDestinatario, String pCuerpo, String pAsunto, DateTime pFecha, bool pLeido)
        {
            this.iIdEmail = pIdEmail;
            this.iRemitente = pRemitente;
            this.iDestinatario = pDestinatario;
            this.iCuerpo = pCuerpo;
            this.iAsunto = pAsunto;
            // this.iConCopia = pCC;
            //  this.iConCopiaOculta = pCCO;
            this.iFecha = pFecha;
            this.iLeido = pLeido;
        }

        /// <summary>
        /// Devuelve o establece la componente IdEmail
        /// </summary>
        public int IdEmail
        {
            get { return this.iIdEmail; }
            set { this.iIdEmail = value; }
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

        /// <summary>
        /// Devuelve la fecha del Email
        /// </summary>
        public DateTime Fecha
        {
            get { return this.iFecha; }
        }

        /// <summary>
        /// Devuelve o establece si el email fue leido o no
        /// </summary>
        public bool Leido
        {
            get { return this.iLeido; }
            set { this.iLeido = value; }
        }
    }
}
