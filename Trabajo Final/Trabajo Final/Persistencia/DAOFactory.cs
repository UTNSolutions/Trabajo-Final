using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Persistencia
{
    /// <summary>
    /// Clase abstracta que representa una fabrica de clases que proveen funcionalidades 
    /// para el acceso a bases de datos
    /// </summary>
    abstract class DAOFactory
    {

        /// <summary>
        /// Devuelve una instancia de CuentaDAO que provee funciones para interactuar con la base de datos
        /// </summary>
        public abstract ICuentaDAO CuentaDAO { get; }

        /// <summary>
        /// Devuelve una instancia de MailDAO que provee funciones para interactuar con la base de datos
        /// </summary>
        public abstract IMailDAO MailDao {get;}

        /// <summary>
        /// Devuelve una instancia de DAOFactory para realizar operaciones en la base de datos
        /// </summary>
        public static DAOFactory Instancia 
        {
            get
            {
                return new SQLServerDAOFactory();
            }
        }

        /// <summary>
        /// Inicia la conexion entre la capa DAO y la base de datos
        /// </summary>
        public abstract void IniciarConexion();

        /// <summary>
        /// Inicia una transaccion dentro de la base de datos
        /// </summary>
        public abstract void ComenzarTransaccion();

        /// <summary>
        /// Realiza la confirmacion de las operaciones de una transaccion abierta
        /// </summary>
        public abstract void Commit();

        /// <summary>
        /// Deshace las operaciones de una transaccion realizada en la base de datos
        /// </summary>
        public abstract void RollBack();

        /// <summary>
        /// Finaliza la conexion entre la capa DAO y la base de datos
        /// </summary>
        public abstract void FinalizarConexion();        
    }
}
}
