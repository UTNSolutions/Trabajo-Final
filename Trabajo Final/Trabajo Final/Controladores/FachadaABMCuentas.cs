using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Final.Persistencia;
using Trabajo_Final.Excepciones;
using Trabajo_Final.DTO;

namespace Trabajo_Final.Controladores
{
    /// <summary>
    /// Representa funcionalidades para la persistencia de Cuentas de correo en base de datos
    /// </summary>
    public class FachadaABMCuentas
    {
        private static FachadaABMCuentas iInstanciaSingleton;
        private FachadaABMCuentas()
        {
        }

        public static FachadaABMCuentas Instancia
        {
            get { 
                    if (iInstanciaSingleton == null)
                    {    
                        iInstanciaSingleton = new FachadaABMCuentas ();
                    }
                    return iInstanciaSingleton;
                }
        }
        

        /// <summary>
        /// Devuelve una lista de todos las cuentas de correo
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DAOExcepcion"></exception>        
        public IList<CuentaDTO> ListarCuentas()
        {
            DAOFactory factory = null;

            try
            {
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();
                return factory.CuentaDAO.Obtener();
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
        /// Crea una nueva cuenta de correo  
        /// </summary>
        /// <param name="pCuenta"></param>
        /// <exception cref="DAOExcepcion"></exception>
        public void CrearCuenta(CuentaDTO pCuenta)
        {
            DAOFactory factory = null;

            try
            {
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();
                factory.ComenzarTransaccion();
                factory.CuentaDAO.Insertar(pCuenta);
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
        /// Modifica los datos de una cuenta de correo en particular
        /// </summary>
        /// <param name="pCuenta"></param>
        /// <exception cref="DAOExcepcion"></exception>
        public void ModificarCuenta(CuentaDTO pCuenta)
        {
            DAOFactory factory = null;

            try
            {
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();
                factory.ComenzarTransaccion();
                factory.CuentaDAO.Modificar(pCuenta);
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
        /// Elimina una cuenta de correo  
        /// </summary>
        /// <param name="pCuenta"></param>
        /// <exception cref="DAOExcepcion"></exception>
        public void EliminarCuenta(CuentaDTO pCuenta)
        {
            DAOFactory factory = null;

            try
            {
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();
                factory.ComenzarTransaccion();
                factory.CuentaDAO.Eliminar(pCuenta);
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
        /// Permite buscar una Cuenta identificada por su nombre
        /// </summary>
        /// <param name="pnombreCuenta"></param>
        /// <returns></returns>
        public CuentaDTO BuscarCuenta(String pNombreCuenta)
        {
            DAOFactory factory = null;

            try
            {
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();
                return factory.CuentaDAO.BuscarCuenta(pNombreCuenta);
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
        /// Establece la fecha y hora del ultimo correo recibido del servidor de correo de la cuenta         
        /// </summary>
        /// <param name="pUltimaConexion"></param>
        /// <param name="pIdCuenta"></param>
        public void EstablecerUltimaConexion(DateTime pUltimaConexion, string pNombreCuenta)
        {
            DAOFactory factory = null;

            try
            {
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();
                factory.ComenzarTransaccion();
                factory.CuentaDAO.EstablecerUltimaConexion(pUltimaConexion, pNombreCuenta);
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
        /// Devuelve la fecha y hora del ultimo correo descargado desde el servidor de la cuenta pasada como parametro
        /// </summary>
        /// <param name="pNombreCuenta"></param>
        /// <returns></returns>
        public DateTime GetUltimaConexion(String pNombreCuenta)
        {
            DAOFactory factory = null;

            try
            {
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();
                return factory.CuentaDAO.ObtenerUltimaConexion(pNombreCuenta);
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
    }
    }
