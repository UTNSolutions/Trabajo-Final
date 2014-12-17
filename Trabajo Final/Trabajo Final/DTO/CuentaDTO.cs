using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Trabajo_Final.DTO
{
    /// <summary>
    /// Representa una cuenta de correo electronico
    /// </summary>
    public class CuentaDTO
    {
        private int iIdCuenta;

        private String iNombre ;

        private String iDireccion ;

        private String iNombreServicio ;

        private String iContraseña;

        private String iDirectorioDeAdjuntos;

        public CuentaDTO(String pNombre,String pDireccion, String pNombreServicio, String pContraseña)
        {
            this.iNombre = pNombre;
            this.iDireccion = pDireccion;
            this.iNombreServicio = pNombreServicio;
            this.iContraseña = pContraseña;
            this.iDirectorioDeAdjuntos = @"C:\EmailManager\" + pNombre;
        }

        public CuentaDTO(int pIdCuenta,String pNombre,String pDireccion, String pNombreServicio, String pContraseña)
        {
            this.iIdCuenta = pIdCuenta;
            this.iNombre = pNombre;
            this.iDireccion = pDireccion;
            this.iNombreServicio = pNombreServicio;
            this.iContraseña = pContraseña;
        }

        /// <summary>
        /// Devuelve la componente IdCuenta
        /// </summary>
        public int IdCuenta
        {
            get {return this.iIdCuenta;}
        }

        /// <summary>
        /// Devuelve o establece la componente Nombre
        /// </summary>
        public String Nombre
        {
            get { return this.iNombre;}
            set { this.iNombre = value; }
        }

        /// <summary>
        /// Devuelve o establece la componente Direccion
        /// </summary>
        public String Direccion
        {
            get { return this.iDireccion; }
            set { this.iDireccion = value; }
        }

        /// <summary>
        /// Devuelve o establece la componente NombreServicio
        /// </summary>
        public String NombreServicio
        {
            get { return this.iNombreServicio; }
            set { this.iNombreServicio = value; }
        }

        /// <summary>
        /// Devuelve o establece la componente Contraseña
        /// </summary>
        public String Contraseña
        {
            get { return this.iContraseña; }
            set { this.iContraseña = value; }
        }

        /// <summary>
        /// Devuelve la componente DirectorioDeAdjuntos
        /// </summary>
        public String DirectorioDeAdjuntos
        {
            get { return this.iDirectorioDeAdjuntos; }
        }

    }
}

