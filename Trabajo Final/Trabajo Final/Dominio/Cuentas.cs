using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Final.Excepciones;

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
        /// <exception cref="NombreCuentaExcepcion"></exception>
        public Cuenta GetCuenta(string pNombreCuenta)
        {
            //Verifico si dicho nombre pasado como parametro es clave del diccionario
            if (this.iListaCuentas.ContainsKey(pNombreCuenta))
            {
              return this.iListaCuentas[pNombreCuenta];
            }
            else
            {
                throw new NombreCuentaExcepcion("");
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

        /// <summary>
        /// Elimina una cuenta de correo de la lista de cuentas
        /// </summary>
        /// <param name="pNombreCuenta"></param>
        public void EliminarCuenta(String pNombreCuenta)
        {
            if (this.iListaCuentas.ContainsKey(pNombreCuenta))
            {
                this.iListaCuentas.Remove(pNombreCuenta);
            }
            else
            {
                throw new ArgumentException("El nombre de cuenta no existe en la lista como clave de una cuenta");
            }
        }
    }
}
