﻿using System;
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
    }
    }
