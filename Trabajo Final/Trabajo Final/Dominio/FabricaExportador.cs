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
        private IDictionary<String,IExportador> iDiccionarioExportadores;
        private FabricaExportador()
        {
            this.iDiccionarioExportadores = new Dictionary<String, IExportador>();
            IExportador expTextoPlano = new ExportadorTextoPlano("TextoPlano");
            this.iDiccionarioExportadores.Add(expTextoPlano.Nombre, expTextoPlano);
        }

        public static FabricaExportador Instancia
        {
            get
            { 
                if (iInstancia == null) 
                {
                    iInstancia = new FabricaExportador();
                }
                return Instancia;                
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
           if (this.iDiccionarioExportadores.ContainsKey(pNombre))
           {
                return this.iDiccionarioExportadores[pNombre];
           }
           else
           {
               throw new FormatException("El parametro no esta asociado a ningun exportador");
           }
        }
    }
}
