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
            try
            {
                Inicializar();
            }
            catch (DAOExcepcion ex)
            {
                throw ex;
            }
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
        public IList<CuentaDTO> ObtenerCuentas()
        {
            try
            {
                IList<CuentaDTO> lista = new List<CuentaDTO>();
                foreach (Cuenta cuenta in Cuentas.Instancia.ListaCuentas.Values)
                {
                    lista.Add(new CuentaDTO(cuenta.Nombre, cuenta.Direccion, cuenta.NombreServicio, cuenta.Contraseña));
                }
                return lista;
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
                if (!(Cuentas.Instancia.GetCuenta(pNombre) == null))
                {   
                    //actualiza la cuenta en la lista de cuentas del dominio
                    Cuentas.Instancia.AgregarCuentaOActualizar(new Cuenta(pNombre, pDireccion, pServicio, pContraseña));
                }
                //actualiza la cuenta en la base de datos
                FachadaABMCuentas.Instancia.ModificarCuenta(new CuentaDTO(pIdCuenta, pNombre, pDireccion, pServicio, pContraseña));               
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
            try
            {
                CargarCuentasCorreo();
                CargarEmailsACadaCuenta();
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
                        Email email = new Email(emailDto.IdEmail,emailDto.Remitente,emailDto.Destinatario,emailDto.Cuerpo,emailDto.Asunto,emailDto.Fecha,emailDto.Leido);
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
        public void EnviarEmail(String pRemitente,IList<String> pDestinatario,IList<String> pCC, IList<String> pCCO, String pAsunto, String pCuerpo, IList<String> pAdjuntos,string pNombreCuenta)
        {
            if (pDestinatario == null)
            {
                throw new EmailExcepcion("Se debe ingresar un destinatario");
            }
            try
            {
                Cuenta cuenta = Cuentas.Instancia.GetCuenta(pNombreCuenta);
                Email email = new Email(pRemitente, pDestinatario, pCC, pCCO, pCuerpo, pAsunto,pAdjuntos,DateTime.Now,false);
                IServicio servicio = FabricaServicios.Instancia.GetServicio(cuenta.NombreServicio);
                servicio.EnviarMail(email,cuenta);
                
                //busco la cuenta en la base de datos con la que envie el email
                //para poder asociar el email enviado a la cuenta en la base de datos
                CuentaDTO cuentaDto = FachadaABMCuentas.Instancia.BuscarCuenta(cuenta.Nombre);
                IList<EmailDTO> lEmail = new List<EmailDTO>();
                lEmail.Add(new EmailDTO(cuentaDto.IdCuenta,email.Remitente,email.Destinatario, email.CC,email.CCO,email.Cuerpo,email.Asunto,email.Fecha,false));
                //inserto el email enviado en la base de datos
                IList<int> listaId = FachadaABMEmail.Instancia.InsertarEmails(lEmail);                
                IList<Email> emailEnviado = new List<Email>();
                //le seteo al email el id devuelto en la insercion en la base de datos
                email.IdEmail = listaId.First();
                emailEnviado.Add(email);
                //Actualizo la lista de emails de dicha cuenta de dominio
                ActualizarListaEmails(cuenta, emailEnviado);
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

        /// <summary>
        /// Devuelve una cuenta identificada con su nombre, y tambien devuelve
        /// el Id de esa cuenta 
        /// </summary>
        /// <param name="pNombreCuenta"></param>
        /// <returns></returns>
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
        public IList<EmailDTO> GetEmails(String pNombreCuenta)
        {
            IList<EmailDTO> lista = new List<EmailDTO>();
            foreach (Email email in Cuentas.Instancia.GetCuenta(pNombreCuenta).ListaEMails) 
            {
                lista.Add(new EmailDTO(email.IdEmail,0,email.Remitente, email.Destinatario, email.CC, email.CCO, email.Cuerpo, email.Asunto, email.Fecha, email.Leido));
            }
            return lista;
        }

        /// <summary>
        /// Devuelve una cuenta 
        /// </summary>
        /// <param name="pNombreCuenta"></param>
        /// <returns></returns>
        public CuentaDTO GetCuenta(String pNombreCuenta)
        {
            Cuenta cuenta = Cuentas.Instancia.GetCuenta(pNombreCuenta);
            return new CuentaDTO(cuenta.Nombre, cuenta.Direccion, cuenta.NombreServicio, cuenta.Contraseña);
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
                IList<Email> listaEmails = servicio.RecibirMail(cuenta);
                //filtro los Emails que descargue para no insertar los emails repetidos en la base de datos
                IList<Email> listaEmailsFiltrados = FiltrarEmailsRepetidos(listaEmails, cuenta.Nombre);
                //obtengo la cuenta de correo que posee el nombre de cuenta pasado como parametro
                //para poder asociarle los emails recibidos
                CuentaDTO cuentaDto = BuscarCuenta(pNombreCuenta);
                IList<EmailDTO> listaEmailDTO = new List<EmailDTO>();
                //A cada email de la lista lo transformo a EmailDTO asociandole la cuenta de correo del 
                //que el email corresponde
                foreach (Email email in listaEmailsFiltrados)
                {
                    listaEmailDTO.Add(new EmailDTO(cuentaDto.IdCuenta, email.Remitente, email.CC, email.CCO, email.Destinatario, email.Cuerpo, email.Asunto, email.Fecha, false));
                }
                //Guardo la lista de emails en la base de datos y obtengo los Ids de los Emails insertados
                //para luego agregar los emails a su cuenta de dominio correspondiente
                IList<int> listaIds = FachadaABMEmail.Instancia.InsertarEmails(listaEmailDTO);
                //itera la lista de los Emails filtrados para asignarle a cada Email su Id correspondiente
                //de la base de datos
                for (int indice = 0; indice < listaEmailsFiltrados.Count; indice ++)
                {
                    listaEmailsFiltrados[indice].IdEmail = listaIds[indice];
                }
                //Actualizo la lista de emails de dicha cuenta de dominio
                ActualizarListaEmails(cuenta, listaEmailsFiltrados);
                //actualizo la ultima conexion de dicha cuenta en el servidor con la fecha y hora
                //del ultimo email recibidoo del servidor. Hago esto siempre y cuando 
                //halla recibibo al menos un Email.

                if (listaEmails.Count > 0)
                {
                    listaEmails = (from e in listaEmails
                                                              orderby e.Fecha descending    
                                                                select e).ToList();
                    FachadaABMCuentas.Instancia.EstablecerUltimaConexion(listaEmails[0].Fecha, cuenta.Nombre);
                }
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
        /// Filtra los Emails descargados del servidor contra los emails que estan en la 
        /// base de datos para que no se repitan
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        private IList<Email> FiltrarEmailsRepetidos(IList<Email> pListaEmail, String pNombreCuenta)
        {
            //Obtengo la ultima conexion (fecha y hora) de la cuenta de correo
            DateTime ultimaConexion = FachadaABMCuentas.Instancia.GetUltimaConexion(pNombreCuenta);
            IList<Email> listaEmailsFiltrados = new List<Email>();
            //itera por cada email en la lista pasada como parametro para hacer el filtro
            foreach (Email email in pListaEmail)
            {
                //si la fecha del email es mayor que la ultima conexion de la cuenta al servidor
                //significa que ese email no esta persistido en la base de datos, por lo que debo
                //agregarlo a la lista para que se agregue
                if (email.Fecha > ultimaConexion)
                {
                    listaEmailsFiltrados.Add(email);
                }
            }
            return listaEmailsFiltrados;
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
                catch (EmailExcepcion ex)
                {                   
                    listaNombresCuentas.Remove(nombreCuenta);
                    ObtenerTodosEmails(listaNombresCuentas);
                    throw ex;
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


        /// <summary>
        /// Permite exportar un Email a un tipo de formato
        /// </summary>
        /// <param name="pRemitente"></param>
        /// <param name="pDestinatarios"></param>
        /// <param name="pAsunto"></param>
        /// <param name="pCuerpo"></param>
        /// <param name="pRuta">ruta donde se va a alojar el email exportado</param>
        /// <param name="pNombreExportador">tipo de exportacion</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ExportadorExcepcion"></exception>
        public void Exportar(String pRemitente,IList<String> pDestinatarios,String pAsunto,String pCuerpo,String pRuta,String pNombreExportador,DateTime pFecha)
        {
            /*try
            {
                IExportador exportador = FabricaExportador.Instancia.GetExportador(pNombreExportador);
                exportador.Exportar(pRuta, new Email(pRemitente, pDestinatarios, pCuerpo, pAsunto,pFecha,false));
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (ExportadorExcepcion ex)
            {
                throw ex;
            }*/
        }

        /// <summary>
        /// Permite marcar como leido un Email 
        /// </summary>
        /// <param name="pNombreCuenta"></param>
        /// <param name="pIdEmail"></param>
        public void MarcarComoLeido(string pNombreCuenta,int pIdEmail)
        {
            try
            {
                Cuentas.Instancia.GetCuenta(pNombreCuenta).BuscarEmail(pIdEmail).Leido = true;
                FachadaABMEmail.Instancia.MarcarComoLeido(pIdEmail);
            }
            catch (NombreCuentaExcepcion ex)
            {
                throw ex;
            }
            catch (DAOExcepcion ex)
            {
                throw ex;
            }
        }
    }
}
