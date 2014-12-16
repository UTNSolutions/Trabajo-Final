using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Trabajo_Final.DTO;

namespace Trabajo_Final.Dominio
{
    /// <summary>
    /// Clase abstracta que representa un servicio de correo electronico
    /// </summary>
    public abstract class Servicio : IServicio
    {
        /// <summary>
        /// Permite enviar un Email
        /// </summary>
        /// <param name="pMail"></param>
        /// <param name="pCuenta"></param>
        public abstract void EnviarMail(Email pMail, Cuenta pCuenta);
        
        /// <summary>
        /// Permite recibir Emails de una cuenta de correo
        /// </summary>
        /// <param name="pCuenta"></param>
        /// <returns></returns>
        public abstract IList<Email> RecibirMail(Cuenta pCuenta);

        /// <summary>
        /// Devuelve el Nombre del servicio
        /// </summary>
        public abstract string Nombre { get; }

        /// <summary>
        /// Verifica si funciona correctamente el acceso a internet
        /// </summary>
        /// <returns></returns>
        public abstract bool AccesoInternet();     
    }
}
