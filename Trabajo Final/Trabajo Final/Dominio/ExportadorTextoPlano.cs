using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Trabajo_Final.Excepciones;


namespace Trabajo_Final.Dominio
{
    /// <summary>
    /// Permite exportar un email en Texto Plano
    /// </summary>
    public class ExportadorTextoPlano : IExportador 
    {
        private String iNombre;

        public ExportadorTextoPlano(String pNombre)
        {
            this.iNombre = pNombre;
        }

        public string Nombre
        {
            get
            {
                { return this.iNombre; }
            }
        }
       
        public void Exportar(String pRuta,Email pEmail)
        {
            if (pRuta == null)
            {
                throw new ArgumentNullException("La ruta pasada es nula");
            }
            try
            {
                StreamWriter archivo = new StreamWriter(pRuta);
                String destinatarios = "";
                String CC = "";
                if (pEmail.CC != null)
                {
                    CC = "CC: ";
                    foreach (String ConCopia in pEmail.CC)
                    {
                        CC += ConCopia + ";";
                    }
                    CC += Environment.NewLine; 
                }
                foreach (String destinatario in pEmail.Destinatario)
                {
                    destinatarios += destinatario + ";";
                }
                archivo.WriteLine("De: " + pEmail.Remitente + Environment.NewLine +
                                  "Para: " + destinatarios + Environment.NewLine +
                                  CC +
                                  "Fecha: " + pEmail.Fecha + Environment.NewLine +
                                  "Asunto: " + pEmail.Asunto + Environment.NewLine +
                                   Environment.NewLine +
                                  "Cuerpo: " + pEmail.Cuerpo);
                archivo.Close();
            }
            catch (UnauthorizedAccessException)
            {
                throw new ExportadorExcepcion("Seleccione un directorio donde almacenar el archivo");
            }
            catch (DirectoryNotFoundException)
            {
                throw new ExportadorExcepcion("Ingrese un nombre de archivo");
            }
            
        }
    }
}
