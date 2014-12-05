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
        private IDictionary<string,Cuenta> iListaCuentas ;

        private static Cuentas iInstanciaSingleton;

        private Cuentas()
        {
            this.iListaCuentas = new Dictionary<string,Cuenta>();
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

        public IDictionary<string,Cuenta> ListaCuentas
        {
            get { return this.iListaCuentas; }
        }

        /// <summary>
        /// Devuelve una cuenta de correo electronico
        /// </summary>
        /// <param name="pNombreCuenta">Nombre de la cuenta por la cual se va a buscar</param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public Cuenta GetCuenta(string pNombreCuenta)
        {
            //Verifico si dicho nombre pasado como parametro es clave del diccionario
            if (this.iListaCuentas.ContainsKey(pNombreCuenta))
            {
              return this.iListaCuentas[pNombreCuenta];
            }
            else
            {
             throw new FormatException("El parametro no esta asociado a ningun servicio");
            }
        }

        /// <summary>
        /// Agrega o actualiza una cuenta de correo a la lista de cuentas
        /// </summary>
        /// <param name="pCuenta"></param>
        public void AgregarCuentaOActualizar(Cuenta pCuenta)
        {
            if (this.iListaCuentas.ContainsKey(pCuenta.Nombre))
            {             
                //Sobreescribe la cuenta en la posicion del diccionario que coincide con la clave
                this.iListaCuentas[pCuenta.Nombre] = pCuenta;
            }
            else
            {
                this.iListaCuentas.Add(pCuenta.Nombre,pCuenta);
            }
        }
    }
}
