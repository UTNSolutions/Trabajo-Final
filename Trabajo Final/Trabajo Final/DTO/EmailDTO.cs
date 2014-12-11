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
      //  private IList<String> iConCopia;

       // private IList<String> iConCopiaOculta;

        public EmailDTO(int pIdCuenta,String pRemitente,IList<String> pDestinatario,String pCuerpo, String pAsunto,DateTime pFecha)
        {
            this.iRemitente = pRemitente;
            this.iDestinatario = pDestinatario;
           // this.iConCopia = pConCopia;
            //this.iConCopiaOculta = pConCopiaOculta;
            this.iIdCuenta = pIdCuenta;
            this.iCuerpo = pCuerpo;
            this.iAsunto = pAsunto;
            this.iFecha = pFecha;
        }

        public EmailDTO(int pIdEmail, int pIdCuenta, String pRemitente, IList<String> pDestinatario, String pCuerpo, String pAsunto,DateTime pFecha)
        {
            this.iRemitente = pRemitente;
            this.iIdEmail = pIdEmail;
            this.iDestinatario = pDestinatario;
           // this.iConCopia = pConCopia;
          //  this.iConCopiaOculta = pConCopiaOculta;
            this.iIdCuenta = pIdCuenta;
            this.iCuerpo = pCuerpo;
            this.iAsunto = pAsunto;
            this.iFecha = pFecha;
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
    }
}
