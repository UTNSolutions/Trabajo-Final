﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final
{
    /// <summary>
    /// Representa una cuenta de correo electronico de un usuario
    /// </summary>
    class Cuenta
    {
        private String iNombre {get ; set;}
        private String iDireccion {get ; set;}
        private String iServicio {get ; set;}
        private String iContraseña {get ; set;}

        public Cuenta(String pNombre,String pDireccion, String pServicio, String pContraseña)
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