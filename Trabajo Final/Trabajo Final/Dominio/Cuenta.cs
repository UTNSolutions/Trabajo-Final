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

        private IServicio iServicio;

        public Cuenta(String pNombre,String pDireccion, String pServicio, String pContraseña)
        {
            this.iNombre = pNombre;
            this.iDireccion = pDireccion;
            this.iNombreServicio = pServicio;
            this.iContraseña = pContraseña;
            this.iServicio = FabricaServicios.Instancia.GetServicio(pServicio);
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

        public IServicio Servicio
        {
            get { return this.iServicio; }
        }
    }
}
