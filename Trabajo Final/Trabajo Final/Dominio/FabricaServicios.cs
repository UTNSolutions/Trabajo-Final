using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Dominio
{
    /// <summary>
    /// Representa una fabrica de Servicios de correo electronico
    /// </summary>
    class FabricaServicios
    {
        private static FabricaServicios iInstanciaSingleton;
        private IDictionary<String,IServicio> iServicios;
        private FabricaServicios()
        {
            this.iServicios = new Dictionary<String, IServicio>();
            ServicioGmail servicioGmail = new ServicioGmail("Gmail");
            ServicioYahoo servicioYahoo = new ServicioYahoo("Yahoo");
            this.iServicios.Add(servicioGmail.Nombre, servicioGmail);
            this.iServicios.Add(servicioYahoo.Nombre, servicioYahoo);
        }

        public static FabricaServicios Instancia
        {
          get {
                if (iInstanciaSingleton == null)
                {
                    iInstanciaSingleton = new FabricaServicios();
                }
                return iInstanciaSingleton;
              }
        }

        /// <summary>
        /// Devuelve un servicio de correo para realizar operaciones de envio y recepcion de correos
        /// </summary>
        /// <param name="pNombre"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public IServicio GetServicio(String pNombre)
        {
         //Verifico si dicho nombre pasado como parametro es clave del diccionario
         if (this.iServicios.ContainsKey(pNombre))
         {
             return this.iServicios[pNombre];
         }
         else
         {
             throw new FormatException("El parametro no esta asociado a ningun servicio");
         }
        }
      }
}
