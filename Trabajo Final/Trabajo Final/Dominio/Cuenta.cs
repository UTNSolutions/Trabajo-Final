using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Cuenta(String pNombre,String pDireccion, String pServicio, String pContraseña)
        {
            this.iNombre = pNombre;
            this.iDireccion = pDireccion;
            this.iNombreServicio = pServicio;
            this.iContraseña = pContraseña;
            this.iListaEmail = new List<Email>();
        }

        public String Nombre
        {
            get { return this.iNombre;}
        }

        public String Direccion
        {
            get { return this.iDireccion; }
        }

        public String NombreServicio
        {
            get { return this.iNombreServicio; }
        }

        public String Contraseña
        {
            get { return this.iContraseña; }
        }

        public IList<Email> ListaEMails
        {
            get { return this.iListaEmail; }
        }

        public Email BuscarEmail(int pIdEmail)
        {
            if (pIdEmail == 0)
            {
                throw new ArgumentNullException();
            }
            return (from c in this.iListaEmail where c.IdEmail == pIdEmail select c).FirstOrDefault();            
        }

        public void AgregarEmail(Email pEmail)
        {
            if (pEmail == null)
            {
                throw new ArgumentNullException();
            }
            this.iListaEmail.Add(pEmail);
        }

        public void EliminarEmail(Email pEmail)
        {
            if (pEmail == null)
            {
                throw new ArgumentNullException();
            }
            this.iListaEmail.Remove(pEmail);
        }
    }
}
