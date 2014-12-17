using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Utils
{
    /// <summary>
    /// Representa un archivo adjunto.
    /// </summary>
    class ArchivoAdjunto
    {
        private String iNombreArchivo;
        private String iRutaArchivo;

        public ArchivoAdjunto(String pNombreArchivo, String pRutaArchivo)
        {
            this.iNombreArchivo = pNombreArchivo;
            this.iRutaArchivo = pRutaArchivo;
        }

        /// <summary>
        /// Devuelve la componente nombre del archivo y la extensión del mismo.
        /// </summary>
        public String NombreArchivo
        {
            get { return this.iNombreArchivo; }
        }

        /// <summary>
        /// Devuelve la componente ruta de un adjunto.
        /// </summary>
        public String RutaArchivo
        {            
            get { return this.iRutaArchivo; }
        }
    }
}
