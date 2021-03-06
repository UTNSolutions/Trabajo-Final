﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Dominio
{
    /// <summary>
    /// Representa un Email
    /// </summary>
    public class Email
    {
        private int iIdEmail;

        private String iRemitente;

        private IList<String> iDestinatario;

        private String iCuerpo;

        private IList<String> iConCopia;

        private IList<String> iConCopiaOculta;

        private String iAsunto;

        private DateTime iFecha;

        private bool iLeido;

        private IList<String> iAdjuntos;

        public Email(String pRemitente, IList<String> pDestinatario, IList<String> pCC, IList<String> pCCO, String pCuerpo, String pAsunto, IList<String> pAdjuntos, DateTime pFecha, bool pLeido)
        {
            this.iRemitente = pRemitente;
            this.iDestinatario = pDestinatario;
            this.iCuerpo = pCuerpo;
            this.iAsunto = pAsunto;
            this.iConCopia = pCC;
            this.iConCopiaOculta = pCCO;
            this.iFecha = pFecha;
            this.iLeido = pLeido;
            this.iAdjuntos = pAdjuntos;
        }

        public Email(int pIdEmail, String pRemitente, IList<String> pDestinatario, IList<String> pCC, IList<String> pCCO, String pCuerpo, String pAsunto, IList<String> pAdjuntos, DateTime pFecha, bool pLeido)
        {
            this.iIdEmail = pIdEmail;
            this.iRemitente = pRemitente;
            this.iDestinatario = pDestinatario;
            this.iCuerpo = pCuerpo;
            this.iAsunto = pAsunto;
            this.iConCopia = pCC;
            this.iConCopiaOculta = pCCO;
            this.iFecha = pFecha;
            this.iLeido = pLeido;
            this.iAdjuntos = pAdjuntos;
        }

        /// <summary>
        /// Devuelve o establece la componente IdEmail
        /// </summary>
        public int IdEmail
        {
            get { return this.iIdEmail; }
            set { this.iIdEmail = value; }
        }

        /// <summary>
        /// Devuelve el componente remitente.
        /// </summary>
        public String Remitente
        {
            get { return this.iRemitente; }
        }

        /// <summary>
        /// Devuelve el componente Destinatario.
        /// </summary>
        public IList<String> Destinatario
        {
            get { return this.iDestinatario; }
        }

        /// <summary>
        /// Devuelve el componente CC.
        /// </summary>
        public IList<String> CC
        {
            get { return this.iConCopia; }
        }

        /// <summary>
        /// Devuelve el componente CCO.
        /// </summary>
        public IList<String> CCO
        {
            get { return this.iConCopiaOculta; }
        }

        /// <summary>
        /// Devuelve el cuerpo del Email.
        /// </summary>
        public String Cuerpo
        {
            get { return this.iCuerpo; }
        }

        /// <summary>
        /// Devuelve el asunto del Email.
        /// </summary>
        public String Asunto
        {
            get { return this.iAsunto; }
        }

        /// <summary>
        /// Devuelve los adjuntos (Rutas) del Email.
        /// </summary>
        public IList<String> Adjunto
        {
            get { return this.iAdjuntos; }
        }
        /// <summary>
        /// Devuelve la fecha del Email
        /// </summary>
        public DateTime Fecha
        {
            get { return this.iFecha; }
        }

        /// <summary>
        /// Devuelve o establece si el email fue leido o no
        /// </summary>
        public bool Leido
        {
            get { return this.iLeido; }
            set { this.iLeido = value; }
        }
    }
}
