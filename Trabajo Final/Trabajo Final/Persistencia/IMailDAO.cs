using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void Eliminar(EmailDTO pEmail);

        /// <summary>
        /// Obtiene todos los Emails correspondiente a una Cuenata de correo
        /// </summary>
        /// <returns></returns>
        IList<EmailDTO> Obtener(CuentaDTO pCuenta);
    }
}
