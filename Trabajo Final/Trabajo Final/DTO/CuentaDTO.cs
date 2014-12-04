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

        public CuentaDTO(String pNombre,String pDireccion, String pNombreServicio, String pContraseña)
        {
            this.iNombre = pNombre;
            this.iDireccion = pDireccion;
            this.iNombreServicio = pNombreServicio;
            this.iContraseña = pContraseña;
        }

        public CuentaDTO(int pIdCuenta,String pNombre,String pDireccion, String pNombreServicio, String pContraseña)
        {
            this.iIdCuenta = pIdCuenta;
            this.iNombre = pNombre;
            this.iDireccion = pDireccion;
            this.iNombreServicio = pNombreServicio;
            this.iContraseña = pContraseña;
        }

        public int IdCuenta
        {
            get {return this.iIdCuenta;}
        }
        public String Nombre
        {
            get { return this.iNombre;}
            set { this.iNombre = value; }
        }

        public String Direccion
        {
            get { return this.iDireccion; }
            set { this.iDireccion = value; }
        }

        public String NombreServicio
        {
            get { return this.iNombreServicio; }
            set { this.iNombreServicio = value; }
        }

        public String Contraseña
        {
            get { return this.iContraseña; }
            set { this.iContraseña = value; }
        }

    }
}

