using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Utils
{
    /// <summary>
    /// Representa un adaptador al DataGrid de Emails
    /// </summary>
    class AdaptadorDataGrid
    {
        private int iIdEmail;
        private String iRemitente;
        private String iDestinatario;
        private String iCC;
        private String iAdjuntos; 
        private String iAsunto;
        private String iCuerpo;
        private DateTime iFecha;        
        private bool iLeido;
        public AdaptadorDataGrid(int pIdEmail, String pRemitente, IList<String> pDestinatario, IList<String> pCC, String pAsunto, String pCuerpo, IList<String> pAdjuntos, DateTime pFecha, bool pLeido)
        {
            this.iIdEmail = pIdEmail;
            this.iRemitente = pRemitente;
            foreach (String destinatario in pDestinatario)
            {
                this.iDestinatario += destinatario + "; ";
            }
            if (pCC != null)
            {
                foreach (String CC in pCC)
                {
                    this.iCC += CC + "; ";
                }
            }
            if (pAdjuntos != null)
            {
                foreach (String adjunto in pAdjuntos)
                {
                    this.iAdjuntos += adjunto + "; ";
                }
            }
            this.iAsunto = pAsunto;
            this.iCuerpo = pCuerpo;
            this.iFecha = pFecha;
            this.iLeido = pLeido;            
        }

        public int IdEmail
        {
            get { return this.iIdEmail; }
        }

        public String Remitente
        {
            get { return this.iRemitente; }
        }

        public String Destinatario
        {
            get { return this.iDestinatario; }
        }

        public String Adjuntos
        {
            get { return this.iAdjuntos; }
        }

        public String CC
        {
            get { return this.iCC; }
        }

        public String Asunto
        {
            get { return this.iAsunto; }
        }

        public String Cuerpo
        {
            get { return this.iCuerpo; }
        }

        public DateTime Fecha
        {
            get { return this.iFecha; }
        }

        public bool Leido
        {
            get { return this.iLeido; }
        }
    }
}
