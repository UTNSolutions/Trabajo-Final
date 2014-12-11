using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Utils
{
    class AdaptadorDataGrid
    {
        private String iRemitente;
        private String iDestinatario;
        private String iAsunto;
        private String iCuerpo;
        private DateTime iFecha;
        public AdaptadorDataGrid(String pRemitente,String pDestinatario,String pAsunto,String pCuerpo,DateTime pFecha)
        {
            this.iRemitente = pRemitente;
            this.iDestinatario = pDestinatario;
            this.iAsunto = pAsunto;
            this.iCuerpo = pCuerpo;
            this.iFecha = pFecha;
        }

        public String Remitente
        {
            get { return this.iRemitente; }
        }

        public String Destinatario
        {
            get { return this.iDestinatario; }
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
    }
}
