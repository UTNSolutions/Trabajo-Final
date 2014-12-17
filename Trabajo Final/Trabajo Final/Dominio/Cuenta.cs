using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabajo_Final.Dominio
{
    /// <summary>
    /// Representa una cuenta de correo electronico de un usuario
    /// </summary>
    public class Cuenta
    {
        private String iNombre ;

        private String iDireccion ;

        private String iNombreServicio ;

        private String iContraseña;

        private IList<Email> iListaEmail;

        private String iDirectorioDeAdjuntos;

        public Cuenta(String pNombre,String pDireccion, String pServicio, String pContraseña)
        {
            this.iNombre = pNombre;
            this.iDireccion = pDireccion;
            this.iNombreServicio = pServicio;
            this.iContraseña = pContraseña;
            this.iListaEmail = new List<Email>();
            this.iDirectorioDeAdjuntos = @"C:\EmailManager\" + pNombre;
            if (! Directory.Exists(this.iDirectorioDeAdjuntos))
            {
                Directory.CreateDirectory(this.iDirectorioDeAdjuntos);
            }

        }

        /// <summary>
        /// Devuelve la componente Nombre 
        /// </summary>
        public String Nombre
        {
            get { return this.iNombre;}
        }

        /// <summary>
        /// Devuelve la componente direccion
        /// </summary>
        public String Direccion
        {
            get { return this.iDireccion; }
        }

        /// <summary>
        /// Devuelve la componente Nombre de servicio
        /// </summary>
        public String NombreServicio
        {
            get { return this.iNombreServicio; }
        }

        /// <summary>
        /// Devuelve la componente contraseña
        /// </summary>
        public String Contraseña
        {
            get { return this.iContraseña; }
        }

        /// <summary>
        /// Devuelve la lista de Emails de dicha cuenta
        /// </summary>
        public IList<Email> ListaEMails
        {
            get { return this.iListaEmail; }
        }

        /// <summary>
        /// Devuelve una email de dicha cuenta identificado por su Id
        /// </summary>
        /// <param name="pIdEmail"></param>
        /// <returns></returns>
        public Email BuscarEmail(int pIdEmail)
        {
            if (pIdEmail == 0)
            {
                throw new ArgumentNullException();
            }
            return (from c in this.iListaEmail where c.IdEmail == pIdEmail select c).FirstOrDefault();            
        }

        /// <summary>
        /// Agrega un Email a dicha cuenta
        /// </summary>
        /// <param name="pEmail"></param>
        public void AgregarEmail(Email pEmail)
        {
            if (pEmail == null)
            {
                throw new ArgumentNullException();
            }
            this.iListaEmail.Add(pEmail);
        }

        /// <summary>
        /// Elimina un Email de la cuenta
        /// </summary>
        /// <param name="pEmail"></param>
        public void EliminarEmail(int pIdEmail)
        {
            if (pIdEmail == null)
            {
                throw new ArgumentNullException();
            }
           this.iListaEmail.Remove((from email in this.iListaEmail where email.IdEmail == pIdEmail select email).FirstOrDefault());
        }

        /// <summary>
        /// Devuelve la componente directorio de los archivos adjuntos 
        /// </summary>
        public String DirectorioDeAdjuntos
        {
            get { return this.iDirectorioDeAdjuntos; }
        }
    }
}
