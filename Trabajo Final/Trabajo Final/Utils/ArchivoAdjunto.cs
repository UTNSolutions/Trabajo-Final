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

        public ArchivoAdjunto(String pNombreArchivo, String pRutaArcivo)
        {
            this.iNombreArchivo = pNombreArchivo;
            this.iRutaArchivo = pRutaArcivo;
        }

        /// <summary>
        /// Devuelve el nombre del archivo y la extensión de un adjunto.
        /// </summary>
        public String NombreArchivo
        {
            get { return this.iNombreArchivo; }
        }

        /// <summary>
        /// Devuelve la ruta de un adjunto.
        /// </summary>
        public String RutaArchivo
        {            
            get { return this.iRutaArchivo; }
        }
    }
}
