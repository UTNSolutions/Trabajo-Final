using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.DTO
{
    /// <summary>
    /// Representa un email DTO
    /// </summary>
    public class EmailDTO
    {
        private String iRemitente;

        private IList<String> iDestinatario;

        private int iIdEmail;

        private int iIdCuenta;

        private String iCuerpo;

        private String iAsunto;

        private DateTime iFecha;

        private bool iLeido;

        private IList<String> iConCopia;

        private IList<String> iConCopiaOculta;

        private IList<String> iAdjuntos;

        public EmailDTO(int pIdCuenta, String pRemitente, IList<String> pDestinatario, IList<String> pConCopia, IList<String> pConCopiaOculta, String pCuerpo, String pAsunto, IList<String> pAdjuntos, DateTime pFecha, bool pLeido)
        {
            this.iRemitente = pRemitente;
            this.iDestinatario = pDestinatario;
            this.iConCopia = pConCopia;
            this.iConCopiaOculta = pConCopiaOculta;
            this.iIdCuenta = pIdCuenta;
            this.iCuerpo = pCuerpo;
            this.iAsunto = pAsunto;
            this.iFecha = pFecha;
            this.iLeido = pLeido;
            this.iAdjuntos = pAdjuntos;
        }

        public EmailDTO(int pIdEmail, int pIdCuenta, String pRemitente, IList<String> pDestinatario, IList<String> pConCopia, IList<String> pConCopiaOculta, String pCuerpo, String pAsunto, IList<String> pAdjuntos, DateTime pFecha, bool pLeido)
        {
            this.iRemitente = pRemitente;
            this.iIdEmail = pIdEmail;
            this.iDestinatario = pDestinatario;
            this.iConCopia = pConCopia;
            this.iConCopiaOculta = pConCopiaOculta;
            this.iIdCuenta = pIdCuenta;
            this.iCuerpo = pCuerpo;
            this.iAsunto = pAsunto;
            this.iFecha = pFecha;
            this.iLeido = pLeido;
            this.iAdjuntos = pAdjuntos;
        }

        /// <summary>
        /// Devuelve o establece el componente remitente
        /// </summary>
        public String Remitente
        {
            get { return this.iRemitente; }
            set { this.iRemitente = value; }
        }

        /// <summary>
        /// Devuelve o establece el componente Destinatario
        /// </summary>
        public IList<String> Destinatario
        {
            get { return this.iDestinatario; }
            set { this.iDestinatario = value; }
        }

        /// <summary>
        /// Devuelve o establece el componente con copia
        /// </summary>
        public IList<String> ConCopia
        {
            get { return this.iConCopia; }
            set { this.iConCopia = value; }
        }

        /// <summary>
        /// Devuelve o establece el componente con copia oculta
        /// </summary>
        public IList<String> ConCopiaOculta
        {
            get { return this.iConCopiaOculta; }
            set { this.iConCopiaOculta = value; }
        }

        /// <summary>
        /// Devuelve o establece la componente IdCuenta a la que pertenece dicho Email
        /// </summary>
        public int IdCuenta
        {
            get { return this.iIdCuenta; }
            set { this.iIdCuenta = value; }
        }

        /// <summary>
        /// Devuelve o establece la componente IdEmail de dicho mail
        /// </summary>
        public int IdEmail
        {
            get { return this.iIdEmail; }
            set { this.iIdEmail = value; }
        }

        /// <summary>
        /// Devuelve o establece el cuerpo del Email
        /// </summary>
        public String Cuerpo
        {
            get { return this.iCuerpo; }
            set { this.iCuerpo = value; }
        }

        /// <summary>
        /// Devuelve o establece el asunto del Email
        /// </summary>
        public String Asunto
        {
            get { return this.iAsunto; }
            set { this.iAsunto = value; }
        }

        /// <summary>
        /// Devuelve o establece la fecha del Email
        /// </summary>
        public DateTime Fecha
        {
            get { return this.iFecha; }
            set { this.iFecha = value; }
        }

        /// <summary>
        /// Devuelve o establece si el Email fue leido
        /// </summary>
        public bool Leido
        {
            get { return this.iLeido; }
            set { this.iLeido = value; }
        }

        /// <summary>
        /// Devuelve o establece los adjuntos del Email
        /// </summary>
        public IList<String> Adjuntos
        {
            get { return this.iAdjuntos; }
            set { this.iAdjuntos = value; }
        }
    }
}
