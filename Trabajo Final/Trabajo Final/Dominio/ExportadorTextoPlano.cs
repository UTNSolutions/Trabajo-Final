﻿using System;
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
                foreach (String destinatario in pEmail.Destinatario)
                {
                    destinatarios += destinatario + ";";
                }
                archivo.WriteLine("De: " + pEmail.Remitente + Environment.NewLine +
                                  "Para: " + destinatarios + Environment.NewLine +
                                  "Asunto: " + pEmail.Asunto + Environment.NewLine +
                                   Environment.NewLine +
                                  "Cuerpo: " + pEmail.Cuerpo);
                archivo.Close();
            }
            catch (DirectoryNotFoundException)
            {
                throw new ExportadorExcepcion("No se ha encontrado el directorio donde se quiere alojar el archivo");
            }
            
        }

        /// <summary>
        /// Devuelve la componente Nombre del Exportador
        /// </summary>
        public string Nombre
        {
            get
            {
                { return this.iNombre; }
            }
            set
            {
                { this.iNombre = value; };
            }
        }
    }
}