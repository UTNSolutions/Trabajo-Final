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
using Trabajo_Final.Excepciones;

namespace Trabajo_Final.UI
{
    public partial class FormAdministrarCuentas : Form
    {
        public FormAdministrarCuentas()
        {
            InitializeComponent();
        }

        private void FormAdministrarCuentas_Load(object sender, EventArgs e)
        {
            cbServicio.SelectedIndex = 0;
            //Cargo el data grid de cuentas con las cuentas obtenidas de la base de datos
            dgCuentas.DataSource = Fachada.Instancia.ObtenerCuentas();
        }

        /// <summary>
        /// Permite dar de alta una cuanta de correo electronico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AltaCuenta(object sender, EventArgs e)
        {
            if (tbCuenta.Text == "" | tbMail.Text == "")
            {
                MessageBox.Show("Falta completar datos obligatorios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {   
                    Fachada.Instancia.AltaCuenta(tbCuenta.Text, tbMail.Text, cbServicio.SelectedItem.ToString(), tbContraseña.Text);
                }
                catch (DAOExcepcion ex)
                {
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NombreCuentaExcepcion ex)
                {
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
