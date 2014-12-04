using System;
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

        private void nuevoMeilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelCuentas.Visible = false;
            gpNuevoMail.Visible = true;

        }

        private void obtenerMailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gpNuevoMail.Visible = false;
            panelCuentas.Visible = true;            
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
