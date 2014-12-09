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
using System.Text.RegularExpressions;
using Trabajo_Final.DTO;

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
            CargarDataGridCuentas();
            this.tbMail.LostFocus += new EventHandler(ValidarMail);
        }

        /// <summary>
        /// Rellena el data grid view de las cuentas de correo
        /// </summary>
        private void CargarDataGridCuentas()
        {
            dgCuentas.DataSource = FachadaABMCuentas.Instancia.ListarCuentas();
        }

        /// <summary>
        /// Verifica si el mail ingresado posee una estructura correcta
        /// </summary>
        /// <returns></returns>
        private bool MailCorrecto()
        {
            String servicio = cbServicio.SelectedItem.ToString();
            String cadena = tbMail.Text;
            return Regex.IsMatch(tbMail.Text, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
        }

        /// <summary>
        /// Valida el email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidarMail(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Permite mostrar u ocultar la contraseña en el textBox de contraseña
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MostrarContraseña(object sender, EventArgs e)
        {
            if (chbContraseña.Checked)
            {
                tbContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                tbContraseña.UseSystemPasswordChar = true;
            }
        }

        /// <summary>
        /// Muestra los datos de una fila seleccionada del dataGridView en los textBoxs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MostrarDatos(object sender,EventArgs e)
        {
            if (dgCuentas.RowCount > 0)
            {
                CuentaDTO fila = (CuentaDTO)dgCuentas.CurrentRow.DataBoundItem;
                tbIdCuenta.Text = Convert.ToString(fila.IdCuenta);
                tbCuenta.Text = fila.Nombre;
                tbMail.Text = fila.Direccion;
                tbContraseña.Text = fila.Contraseña;
                cbServicio.SelectedItem = fila.NombreServicio;
            }
        }

        private void MostrarDatos(object sender, KeyEventArgs k )
        {
            if (dgCuentas.RowCount > 0)
            {
                CuentaDTO fila = (CuentaDTO)dgCuentas.CurrentRow.DataBoundItem;
                tbIdCuenta.Text = Convert.ToString(fila.IdCuenta);
                tbCuenta.Text = fila.Nombre;
                tbMail.Text = fila.Direccion;
                tbContraseña.Text = fila.Contraseña;
                cbServicio.SelectedItem = fila.NombreServicio;
            }
        }

        /// <summary>
        /// Permite dar de alta una cuanta de correo electronico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AltaCuenta(object sender, EventArgs e)
        {
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
                        MessageBox.Show("Cuenta agregada con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDataGridCuentas();                                               
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

        /// <summary>
        /// Permite modificar los datos de una cuenta de correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModificarCuenta(object sender, EventArgs e)
        {
          if (tbCuenta.Text == "" | tbMail.Text == "")
          {
               MessageBox.Show("Falta completar datos obligatorios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          else
          {
              try
                {
                    Fachada.Instancia.ModificarCuenta(Convert.ToInt32(tbIdCuenta.Text),tbCuenta.Text, tbMail.Text, cbServicio.SelectedItem.ToString(), tbContraseña.Text);
                    MessageBox.Show("Datos de la cuenta modificados con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDataGridCuentas();
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

       /// <summary>
       /// Permite eliminar una cuenta de correo 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void EliminarCuenta(object sender, EventArgs e)
        {
            if (tbIdCuenta.Text == "")
            {
                MessageBox.Show("Seleccione una cuenta, antes de eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar dicha cuenta?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        Fachada.Instancia.EliminarCuenta(Convert.ToInt32(tbIdCuenta.Text), tbCuenta.Text, tbMail.Text, cbServicio.SelectedItem.ToString(), tbContraseña.Text);
                        MessageBox.Show("La cuenta ha sido eliminada con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDataGridCuentas();
                    }
                    catch (DAOExcepcion ex)
                    {
                        MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    
    }
}
