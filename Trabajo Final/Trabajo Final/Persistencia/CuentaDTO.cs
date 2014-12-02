using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Persistencia
{
    /// <summary>
    /// Representa una cuenta de correo electronico
    /// </summary>
    class CuentaDTO
    {
        private String iNombre ;

        private String iDireccion ;

        private String iServicio ;

        private String iContraseña;

        public CuentaDTO(String pNombre,String pDireccion, String pServicio, String pContraseña)
        {
            this.iNombre = pNombre;
            this.iDireccion = pDireccion;
            this.iServicio = pServicio;
            this.iContraseña = pContraseña;
        }

        public String Nombre
        {
            get { return this.iNombre;}
        }

        public String Direccion
        {
            get { return this.iDireccion; }
        }

        public String Servicio
        {
            get { return this.iServicio; }
        }

        public String Contraseña
        {
            get { return this.iContraseña; }
        }

    }
    }
}
