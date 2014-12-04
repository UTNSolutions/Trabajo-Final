using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.DTO
{
    /// <summary>
    /// Representa un email
    /// </summary>
    class EmailDTO
    {
        private String iDestinatario;

        private CuentaDTO iCuenta;

        private String iCuerpo;

        private String iAsunto;

        public EmailDTO(CuentaDTO pCuenta,String pDestinatario,String pCuerpo, String pAsunto)
        {
            this.iDestinatario = pDestinatario;
            this.iCuenta = pCuenta;
            this.iCuerpo = pCuerpo;
            this.iAsunto = pAsunto;
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
        /// Devuelve la componente Cuenta a la que pertenece dicho Email
        /// </summary>
        public CuentaDTO Cuenta
        {
            get { return this.iCuenta; }
            set { this.iCuenta = value; }
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
