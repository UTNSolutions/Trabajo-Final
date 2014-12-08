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

        private String iDestinatario;

        private int iIdEmail;

        private int iIdCuenta;

        private String iCuerpo;

        private String iAsunto;

        public EmailDTO(int pIdCuenta,String pRemitente,String pDestinatario,String pCuerpo, String pAsunto)
        {
            this.iRemitente = pRemitente;
            this.iDestinatario = pDestinatario;
            this.iIdCuenta = pIdCuenta;
            this.iCuerpo = pCuerpo;
            this.iAsunto = pAsunto;
        }

        public EmailDTO(int pIdEmail,int pIdCuenta,String pRemitente, String pDestinatario, String pCuerpo, String pAsunto)
        {
            this.iRemitente = pRemitente;
            this.iIdEmail = pIdEmail;
            this.iDestinatario = pDestinatario;
            this.iIdCuenta = pIdCuenta;
            this.iCuerpo = pCuerpo;
            this.iAsunto = pAsunto;
        }

        /// <summary>
        /// Devuelve el componente remitente
        /// </summary>
        public String Remitente
        {
            get { return this.iRemitente; }
            set { this.iRemitente = value; }
        }

        /// <summary>
        /// Devuelve el componente Destinatario
        /// </summary>
        public String Destinatario
        {
            get { return this.iDestinatario; }
            set { this.iDestinatario = value; }
        }

        /// <summary>
        /// Devuelve la componente IdCuenta a la que pertenece dicho Email
        /// </summary>
        public int IdCuenta
        {
            get { return this.iIdCuenta; }
            set { this.iIdCuenta = value; }
        }

        /// <summary>
        /// Devuelve la componente IdEmail de dicho mail
        /// </summary>
        public int IdEmail
        {
            get { return this.iIdEmail; }
            set { this.iIdEmail = value; }
        }

        /// <summary>
        /// Devuelve el cuerpo del Email
        /// </summary>
        public String Cuerpo
        {
            get { return this.iCuerpo; }
            set { this.iCuerpo = value; }
        }

        /// <summary>
        /// Devuelve el asunto del Email
        /// </summary>
        public String Asunto
        {
            get { return this.iAsunto; }
            set { this.iAsunto = value; }
        }
    }
}
