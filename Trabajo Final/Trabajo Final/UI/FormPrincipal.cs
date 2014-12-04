using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
