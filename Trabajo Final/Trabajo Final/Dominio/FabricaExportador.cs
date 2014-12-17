using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Dominio
{
    /// <summary>
    /// Representa una fabrica de exportadores de correo electronico
    /// </summary>
    class FabricaExportador
    {
        private static FabricaExportador iInstancia;
        private IDictionary<String,IExportador> iExportadores;
        private FabricaExportador()
        {
            this.iExportadores = new Dictionary<String, IExportador>();
            IExportador expTextoPlano = new ExportadorTextoPlano("Texto Plano");
            this.iExportadores.Add(expTextoPlano.Nombre, expTextoPlano);
            IExportador expEML = new EMLExportador("EML");
            this.iExportadores.Add(expEML.Nombre, expEML);
        }

        public static FabricaExportador Instancia
        {
            get
            { 
                if (iInstancia == null) 
                {
                    iInstancia = new FabricaExportador();
                }
                return iInstancia;                
            }
        }

        /// <summary>
        /// Devuelve un exportador de correo identificado por su nombre
        /// </summary>
        /// <param name="pNombre"></param>
        /// <returns></returns>
        public IExportador GetExportador(String pNombre)
        {
           //Verifico si dicho nombre pasado como parametro es clave del diccionario
           if (this.iExportadores.ContainsKey(pNombre))
           {
                return this.iExportadores[pNombre];
           }
           else
           {
               throw new FormatException("El parametro no esta asociado a ningun exportador");
           }
        }
    }
}
