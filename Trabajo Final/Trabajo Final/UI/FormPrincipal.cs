﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final.Controladores;
using Trabajo_Final.DTO;
using Trabajo_Final.Dominio;

namespace Trabajo_Final.UI
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAcercaDe formAcercaDe = new FormAcercaDe();
            formAcercaDe.Show();
        }

        private void cuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdministrarCuentas formAdminCuentas = new FormAdministrarCuentas();
            formAdminCuentas.Show();
        }

        /// <summary>
        /// Cambia la pantalla principal y abilita el panel para enviar un nuevo mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuevoMeilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gpNuevoMail.Visible)
            {
                tbCCO.ReadOnly = true;
                tbCC.ReadOnly = true;
            panelCuentas.Visible = false;
            gpNuevoMail.Visible = true;
        }
        }

        /// <summary>
        /// Cambia la pantalla principal y abilita el panel para mostrar los mail de una cuenta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void obtenerMailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gpNuevoMail.Visible = false;
            panelCuentas.Visible = true;            
        }

        /// <summary>
        /// Cambia la pantalla principal y abilita el panel para mostrar los mail de las cuentas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void obtenerTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gpNuevoMail.Visible = false;
            panelCuentas.Visible = true;
        }

        /// <summary>
        /// Abilita el TextBox que permita cargar el/las direcciones a los que se le envían una copia del mail. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonCC_Click(object sender, EventArgs e)
        {
            tbCC.ReadOnly = false;
        }

        /// <summary>
        /// Abilita el TextBox que permita cargar el/las direcciones a los que se le envían una copia oculata del mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buton_Click(object sender, EventArgs e)
        {
            tbCCO.ReadOnly = false;
        }

        private void bAdjuntar_Click(object sender, EventArgs e)
        {
            IList<FileDialog> listaDeAdjuntos = new List<FileDialog>(); 
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Seleccione Archivo";
            file.InitialDirectory = @"c:\";
            file.Filter = "All Files(*.*)|*.*";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.ShowDialog();
            tbAdjuntos.Text = file.SafeFileName;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CargarCuentasCorreo();
        }

        private void CargarCuentasCorreo()
        {
           IList<Cuenta> listaCuentas = Fachada.Instancia.CargarCuentasCorreo();
           foreach (Cuenta cuenta in listaCuentas)
           {
               TreeNode nodo = tvCuentas.Nodes.Add(cuenta.Nombre);
               nodo.Nodes.Add("Recibidos");
               nodo.Nodes.Add("Enviados");
               nodo.Nodes.Add("Borradores");               
           }
        }

    }
}