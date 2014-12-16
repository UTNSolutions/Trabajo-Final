using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Final.DTO;

namespace Trabajo_Final.Persistencia
{
    interface IMailDAO
    {
        /// <summary>
        /// Permite insertar un nuevo Email en la base de datos
        /// </summary>
        /// <param name="pCuenta"></param>
        void Insertar(EmailDTO pEmail);

      
        /// <summary>
        /// Permite eliminar un Email de la base de datos
        /// </summary>
        /// <param name="pCuenta"></param>
        void Eliminar(int pIdEmail);

        /// <summary>
        /// Permite marcar como leido un Email
        /// </summary>
        /// <param name="pIdEmail"></param>
        void MarcarLeido(int pIdEmail);

        /// <summary>
        /// Obtiene todos los Emails correspondiente a una Cuenta de correo
        /// </summary>
        /// <returns></returns>
        IList<EmailDTO> Obtener(int pIdCuenta);

        

    }
}
