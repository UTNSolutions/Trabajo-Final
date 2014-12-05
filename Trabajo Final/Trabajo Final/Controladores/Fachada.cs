using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Final.Persistencia;
using Trabajo_Final.Excepciones;
using Trabajo_Final.Dominio;
using Trabajo_Final.DTO;

namespace Trabajo_Final.Controladores
{
    class Fachada
    {
        private static Fachada iInstanciaSingleton;

        private Fachada()
        { }

        public static Fachada Instancia
        {
            get { 
                    if (iInstanciaSingleton == null)
                    {    
                        iInstanciaSingleton = new Fachada ();
                    }
                    return iInstanciaSingleton;
               }
        }

        /// <summary>
        /// Permite dar de alta una nueva cuenta de correo electronico
        /// </summary>
        /// <param name="pNombre"></param>
        /// <param name="pDireccion"></param>
        /// <param name="pServicio"></param>
        /// <param name="pContraseña"></param>
        /// <exception cref="NombreCuentaExcepcion"></exception>
        /// <exception cref="DAOExcepcion"></exception>
        public void AltaCuenta(String pNombre, String pDireccion, String pServicio, String pContraseña)
        {
            try
            {
                // Obtengo todas las cuentas de la base de datos para verificar que el nombre de la cuenta 
                // sea unívoco
                IList<CuentaDTO> listaCuentas = FachadaABMCuentas.Instancia.ListarCuentas();
                CuentaDTO cuenta = (from c in listaCuentas
                                    where c.Nombre == pNombre
                                    select c).FirstOrDefault();
                // si cuenta es nulo, significa de que no existe ninguna cuenta en la base de datos
                // que posea el nombre (pNombre) pasado como parametro, por lo que puedo crear esa cuenta
                if (cuenta == null)
                {
                    FachadaABMCuentas.Instancia.CrearCuenta(new CuentaDTO(pNombre, pDireccion, pServicio, pContraseña));
                }
                else
                {
                    throw new NombreCuentaExcepcion("El nombre de la cuenta ya existe, utilize otro");
                }
            }
            catch (DAOExcepcion ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Devuelve una lista de las cuentas de correo 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DAOExcepcion"></exception>
        public IList<CuentaDTO> ObtenerCuentas()
        {
            try
            {
                return FachadaABMCuentas.Instancia.ListarCuentas();
            }
            catch (DAOExcepcion ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Permite dar modificar los datos de una cuenta de correo electronico
        /// </summary>
        /// <param name="pIdCuenta"></param>
        /// <param name="pNombre"></param>
        /// <param name="pDireccion"></param>
        /// <param name="pServicio"></param>
        /// <param name="pContraseña"></param>
        /// <exception cref="NombreCuentaExcepcion"></exception>
        /// <exception cref="DAOExcepcion"></exception>
        public void ModificarCuenta(int pIdCuenta,String pNombre, String pDireccion, String pServicio, String pContraseña)
        {
            try
            {
                // Obtengo todas las cuentas de la base de datos para verificar que el nombre de la cuenta 
                // sea unívoco
                IList<CuentaDTO> listaCuentas = FachadaABMCuentas.Instancia.ListarCuentas();
                CuentaDTO cuenta = (from c in listaCuentas
                                    where c.Nombre == pNombre
                                    select c).FirstOrDefault();
                // si cuenta no es nula significa de que no existe ninguna cuenta en la base de datos
                // que posea el nombre (pNombre) pasado como parametro, por lo que puedo modificar esa cuenta,
                // y tambien el id de la cuenta encontrada si es igual al idCuenta pasado como parametro
                // significa que hay otra cuenta con el nombre de cuenta que quiero modificar, 
                //por lo que no puedo realizar la operacion
                if (cuenta != null & cuenta.IdCuenta != pIdCuenta) 
                {
                    throw new NombreCuentaExcepcion("El nombre de la cuenta ya existe, utilize otro");
                }
                else
                {
                    FachadaABMCuentas.Instancia.ModificarCuenta(new CuentaDTO(pIdCuenta, pNombre, pDireccion, pServicio, pContraseña));
                }
            }
            catch (DAOExcepcion ex)
            {
                throw ex;
            }  
        }


        /// <summary>
        /// Permite eliminar una cuenta de correo electronico
        /// </summary>
        /// <param name="pIdCuenta"></param>
        /// <param name="pNombre"></param>
        /// <param name="pDireccion"></param>
        /// <param name="pServicio"></param>
        /// <param name="pContraseña"></param>
        /// <exception cref="DAOExcepcion"></exception>
        public void EliminarCuenta(int pIdCuenta,String pNombre, String pDireccion, String pServicio, String pContraseña)
        {
            try
            {
                FachadaABMCuentas.Instancia.EliminarCuenta(new CuentaDTO(pIdCuenta, pNombre, pDireccion, pServicio, pContraseña));
            }
            catch (DAOExcepcion ex)
            {
                throw ex;
            } 
        }

        public IList<Cuenta> CargarCuentasCorreo()
        {
            try
            {
                //creo una nueva lista ya que la lista de cuentas es un diccionario
                IList<Cuenta> listaADevolver = new List<Cuenta>();
                // Obtengo las cuentas de la base de datos
                IList<CuentaDTO> listaCuentas = FachadaABMCuentas.Instancia.ListarCuentas();
                // Para cada cuenta la agrego en la lista de cuentas pertenecientes al dominio de la aplicacion
                foreach (CuentaDTO cuenta in listaCuentas)
                {
                    Cuentas.Instancia.AgregarCuenta(new Cuenta(cuenta.Nombre, cuenta.Direccion, cuenta.NombreServicio, cuenta.Contraseña));
                    listaADevolver.Add(new Cuenta(cuenta.Nombre, cuenta.Direccion, cuenta.NombreServicio, cuenta.Contraseña));
                }
                return listaADevolver;
            }
            catch (DAOExcepcion ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Permite enviar un Email
        /// </summary>
        /// <param name="pEmail">Email a enviar</param>
        /// <param name="pCuenta">Cuenta con la que se quiere enviar el email</param>
        /// <exception cref="EmailExcepcion"></exception>
        public void EnviarEmail(EmailDTO pEmail,string pNombreCuenta)
        {
            if (pEmail.Destinatario == null)
            {
                throw new EmailExcepcion("Se debe ingresar un destinatario");
            }
            try
            {
                Cuenta cuenta = Cuentas.Instancia.GetCuenta(pNombreCuenta);
                cuenta.Servicio.Cuenta = cuenta;
                cuenta.Servicio.EnviarMail(pEmail);
            }
            catch(FormatException)
            {
                throw new FormatException("Se produjo un error interno, intente mas tarde");
            }
            catch(EmailExcepcion ex)
            {
                throw ex;
            }
        }

        public CuentaDTO BuscarCuenta(string pNombreCuenta)
        {
            try
            {
                return FachadaABMCuentas.Instancia.BuscarCuenta(pNombreCuenta);
            }
            catch (DAOExcepcion ex)
            {
                throw ex;
            }
        }
    }
}
