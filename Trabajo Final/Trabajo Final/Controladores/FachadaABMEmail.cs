using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Final.DTO;
using Trabajo_Final.Persistencia;
using Trabajo_Final.Excepciones;

namespace Trabajo_Final.Controladores
{
    /// <summary>
    /// Representa funcionalidades para la persistencia de Emails en base de datos
    /// </summary>
    class FachadaABMEmail
    {
        private static FachadaABMEmail iInstanciaSingleton;
        private FachadaABMEmail()
        {
        }

        public static FachadaABMEmail Instancia
        {
            get
            {
                if (iInstanciaSingleton == null)
                {
                    iInstanciaSingleton = new FachadaABMEmail();
                }
                return iInstanciaSingleton;
            }
        }


        /// <summary>
        /// Devuelve una lista de todos los emails asociados a una cuenta
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DAOExcepcion"></exception>        
        public IList<EmailDTO> ListarEmails(int pIdCuenta)
        {
            DAOFactory factory = null;

            try
            {
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();
                return factory.MailDao.Obtener(pIdCuenta);
            }
            catch (DAOExcepcion ex)
            {
                throw ex;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        /// <summary>
        /// Inserta un nuevo email en la base de datos
        /// </summary>
        /// <param name="pCuenta"></param>
        /// <exception cref="DAOExcepcion"></exception>
        public void NuevoEmail(EmailDTO pEmail)
        {
            DAOFactory factory = null;

            try
            {
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();
                factory.ComenzarTransaccion();
                factory.MailDao.Insertar(pEmail);
                factory.Commit();
            }
            catch (DAOExcepcion ex)
            {
                factory.RollBack();
                throw ex;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        /// <summary>
        /// Elimina un email de una cuenta de la base de datos  
        /// </summary>
        /// <param name="pCuenta"></param>
        /// <exception cref="DAOExcepcion"></exception>
        public void EliminarCuenta(int pIdEmail)
        {
            DAOFactory factory = null;

            try
            {
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();
                factory.ComenzarTransaccion();
                factory.MailDao.Eliminar(pIdEmail);
                factory.Commit();
            }
            catch (DAOExcepcion ex)
            {
                factory.RollBack();
                throw ex;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }
    }
}

