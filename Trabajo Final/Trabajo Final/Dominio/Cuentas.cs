using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Dominio
{
    /// <summary>
    /// Representa un conjunto de cuentas de correo electronico
    /// </summary>
    class Cuentas
    {
        private IList<Cuenta> iListaCuentas ;

        private static Cuentas iInstanciaSingleton;

        private Cuentas()
        {
            this.iListaCuentas = new List<Cuenta>();
        }

        public static Cuentas Instancia
        {
            get { 
                    if (iInstanciaSingleton == null)
                    {    
                        iInstanciaSingleton = new Cuentas ();
                    }
                    return iInstanciaSingleton;
               }
        }

        /// <summary>
        /// Agrega una cuenta de correo a la lista de cuentas
        /// </summary>
        /// <param name="pCuenta"></param>
        public void AgregarCuenta(Cuenta pCuenta)
        {
            this.iListaCuentas.Add(pCuenta);
        }
    }
}
