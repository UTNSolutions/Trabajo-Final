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
    public class Fachada
    {
        private static Fachada iInstanciaSingleton;

        private Fachada()
        {
            Inicializar();
        }

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
                    Cuentas.Instancia.AgregarCuentaOActualizar(new Cuenta(pNombre, pDireccion, pServicio, pContraseña));
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
        /// <exception cref="Exception"></exception>
        public IList<Cuenta> ObtenerCuentas()
        {
            try
            {
                return Cuentas.Instancia.ListaCuentas.Values.ToList<Cuenta>();
            }
            catch (Exception ex)
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
                //actualiza la cuenta en la base de datos
                FachadaABMCuentas.Instancia.ModificarCuenta(new CuentaDTO(pIdCuenta, pNombre, pDireccion, pServicio, pContraseña));
                if (!(Cuentas.Instancia.GetCuenta(pNombre) == null))
                {   
                    //actualiza la cuenta en la lista de cuentas del dominio
                    Cuentas.Instancia.AgregarCuentaOActualizar(new Cuenta(pNombre, pDireccion, pServicio, pContraseña));
                }
            }
            catch (DAOExcepcion ex)
            {
                throw ex;
            }
            catch (NombreCuentaExcepcion)
            {
                throw new NombreCuentaExcepcion("El nombre de la cuenta no se puede cambiar");
            }
        }

        /// <summary>
        /// Inicializa las cuentas de correo y su emails
        /// </summary>
        private void Inicializar()
        {
            CargarCuentasCorreo();
            CargarEmailsACadaCuenta();
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
                Cuentas.Instancia.EliminarCuenta(pNombre);
            }
            catch (DAOExcepcion ex)
            {
                throw ex;
            } 
        }


        /// <summary>
        /// Obtiene las cuentas de correo de la base de datos y crea objetos de tipo Cuenta 
        /// pertenicientes al dominio de la aplicacion
        /// </summary>
        /// <returns></returns>
        private void CargarCuentasCorreo()
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
                    Cuentas.Instancia.AgregarCuentaOActualizar(new Cuenta(cuenta.Nombre, cuenta.Direccion, cuenta.NombreServicio, cuenta.Contraseña));                    
                }
            }
            catch (DAOExcepcion ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Obtiene los mails de la base de datos y se los asigna a cada Cuenta a la que cada email
        /// pertence
        /// </summary>
        private void CargarEmailsACadaCuenta()
        {
            if (Cuentas.Instancia.ListaCuentas.Count == 0)
            {
                throw new CuentasExcepcion("No existen cuentas de correo");
            }
            try
            {
                //itera por cada Cuenta de correo perteneciente al dominio 
                foreach(Cuenta cuenta in Cuentas.Instancia.ListaCuentas.Values)
                {
                    CuentaDTO cuentaDto = BuscarCuenta(cuenta.Nombre);
                    //itera cada Email perteneciente a la cuenta buscada anteriormente para poder 
                    //agregar dicho email a la cuenta de dominio Email
                    foreach (EmailDTO emailDto in FachadaABMEmail.Instancia.ListarEmails(cuentaDto.IdCuenta)) 
                    {
                        Email email = new Email(emailDto.Remitente,emailDto.Destinatario,emailDto.Cuerpo,emailDto.Asunto);
                        cuenta.AgregarEmail(email);
                    }
                }
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
        public void EnviarEmail(String pRemitente,List<String> pDestinatario,List<String> pConCopia,List<String> pConCopiaOculta, String pAsunto, String pCuerpo,string pNombreCuenta)
        {
            if (pDestinatario == null)
            {
                throw new EmailExcepcion("Se debe ingresar un destinatario");
            }
            try
            {
                Cuenta cuenta = Cuentas.Instancia.GetCuenta(pNombreCuenta);
                IServicio servicio = FabricaServicios.Instancia.GetServicio(cuenta.NombreServicio);
                servicio.Cuenta = cuenta;
                Email email = new Email(pRemitente, pDestinatario, pConCopia, pConCopiaOculta, pCuerpo, pAsunto);
                servicio.EnviarMail(email);
            }
            catch (FormatException)
            {
                throw new FormatException("Se produjo un error interno, intente mas tarde");
            }
            catch (EmailExcepcion ex)
            {
                throw ex;
            }
            catch (InternetExcepcion ex)
            {
                throw ex;
            }
        }

        private CuentaDTO BuscarCuenta(string pNombreCuenta)
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

        /// <summary>
        /// Devuelve los emails de una cuenta
        /// </summary>
        /// <param name="pNombreCuenta"></param>
        public IList<Email> GetEmails(String pNombreCuenta)
        {
            IList<Email> lista = Cuentas.Instancia.GetCuenta(pNombreCuenta).ListaEMails;
            return lista ;
        }

        /// <summary>
        /// Obtiene los emails de correspondiente a una cuenta en particular, descargandolos
        /// del servidor correspondiente     
        /// </summary>
        /// <param name="pNombreCuenta"></param>
        public void ObtenerEmail(string pNombreCuenta)
        {
            try
            {
                Cuenta cuenta = Cuentas.Instancia.GetCuenta(pNombreCuenta);
                IServicio servicio = FabricaServicios.Instancia.GetServicio(cuenta.NombreServicio);
                servicio.Cuenta = cuenta;
                IList<Email> listaEmails = servicio.RecibirMail();
                //obtengo la cuenta de correo que posee el nombre de cuenta pasado como parametro
                //para poder asociarle los emails recibidos
                CuentaDTO cuentaDto = BuscarCuenta(pNombreCuenta);
                IList<EmailDTO> listaEmailDTO = new List<EmailDTO>();
                //A cada email de la lista lo transformo a EmailDTO asociandole la cuenta de correo del 
                //que el email corresponde
                foreach (Email email in listaEmails)
                {
                    listaEmailDTO.Add(new EmailDTO(cuentaDto.IdCuenta, email.Remitente, email.Destinatario, email.Cuerpo, email.Asunto));
                }
                //Guardo la lista de emails en la base de datos
                FachadaABMEmail.Instancia.InsertarEmails(listaEmailDTO);
                //Actualizo la lista de emails de dicha cuenta de dominio
                ActualizarListaEmails(cuenta, listaEmails);
            }
            catch (NombreCuentaExcepcion ex)
            {
                throw ex;
            }
            catch (InternetExcepcion ex)
            {
                 throw ex;
            }
            catch (EmailExcepcion ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene los emails de todas las cuentas configuradas, descargandolos del servidor 
        /// correspondiente 
        /// </summary>
        /// <param name="listaNombresCuentas"></param>
        public void ObtenerTodosEmails(IList<String> listaNombresCuentas)
        {
            foreach (String nombreCuenta in listaNombresCuentas)
            {
                try
                {
                    ObtenerEmail(nombreCuenta);
                }
                catch (NombreCuentaExcepcion ex)
                {
                    throw ex;
                }
                catch (InternetExcepcion ex)
                {
                    throw ex;
                }
                catch (EmailExcepcion)
                {                   
                    listaNombresCuentas.Remove(nombreCuenta);
                    ObtenerTodosEmails(listaNombresCuentas);
                    throw new EmailExcepcion("La recepcion de todas las cuentas de correo finalizó con errores");
                }
            }            
        }

        /// <summary>
        /// Actualiza la lista de emails de un cuenta del dominio
        /// </summary>
        /// <param name="pCuenta"></param>
        /// <param name="?"></param>
        private void ActualizarListaEmails(Cuenta pCuenta, IList<Email> pListaEmails)
        {
            foreach (Email email in pListaEmails)
            {
                pCuenta.AgregarEmail(email);
            }
        }
    }
}
