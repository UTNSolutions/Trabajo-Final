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
using Trabajo_Final.Excepciones;

namespace Trabajo_Final.UI
{
    public partial class FormPrincipal : Form
    {
        private static FormAdministrarCuentas iFormAdminCuentas;
        private static FormAcercaDe iFormAcercaDe;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Abre un formulario con la especificaciones del programa. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iFormAcercaDe == null)
            {
                iFormAcercaDe = new FormAcercaDe();
                iFormAcercaDe.Disposed += new EventHandler(form_Disposed);
            }
            iFormAcercaDe.Show();
        }

        /// <summary>
        /// Abre un formulario que permite administrar cuentas de correo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iFormAdminCuentas == null)
            {
                iFormAdminCuentas = new FormAdministrarCuentas();
                iFormAdminCuentas.Disposed += new EventHandler(form_Disposed);
                iFormAdminCuentas.FormClosed += new FormClosedEventHandler(formAdminCuentas_FormClosed);
            }
            iFormAdminCuentas.Show();
        }

        private void formAdminCuentas_FormClosed(object sender, FormClosedEventArgs e)       
        {              
            //when child form is closed, this code is executed   
            // Bind the Grid view       
            CargarCuentasCorreo();     
        }

        /// <summary>
        /// Le asigna null a los formularios para que no se puedan abrir de nuevo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_Disposed(object sender, EventArgs e)
        {
            iFormAdminCuentas = null;
            iFormAcercaDe = null;
        }

        /// <summary>
        /// Cambia la pantalla principal y habilita el panel para enviar un nuevo mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuevoMeilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gpNuevoMail.Visible)
            {
                combobDe.DataSource = Fachada.Instancia.ObtenerCuentas();
                combobDe.ValueMember = "Nombre";
                combobDe.DisplayMember = "Direccion";
                gbOpciones1.Visible = false;
                gbEnviarMail.Visible = true;
                tbCCO.ReadOnly = true;
                tbCC.ReadOnly = true;
                panelCuentas.Visible = false;
                gpNuevoMail.Visible = true;
                
            }
        }

        /// <summary>
        /// Habilita el TextBox que permita cargar el/las direcciones a los que se le envían una copia del mail. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonCC_Click(object sender, EventArgs e)
        {
            tbCC.ReadOnly = false;
        }

        /// <summary>
        /// Habilita el TextBox que permita cargar el/las direcciones a los que se le envían una copia oculata del mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonCCO_Click(object sender, EventArgs e)
        {
            tbCCO.ReadOnly = false;
        }

        /// <summary>
        /// Abre una ventana que deja adjuntar archivos al mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonAdjuntar_Click(object sender, EventArgs e)
        {            
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Seleccione Archivo";
            file.InitialDirectory = @"c:\";
            file.Filter = "All Files(*.*)|*.*";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.ShowDialog();
            tbAdjuntos.Text = file.SafeFileName;
        }

        /// <summary>
        /// Evento que se ejecuta cuando inicia el formulario principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CargarCuentasCorreo();
        }

        /// <summary>
        /// Carga las cuentas en el formulario principal.
        /// </summary>
        public void CargarCuentasCorreo()
        {
            IList<Cuenta> listaCuentas = Fachada.Instancia.CargarCuentasCorreo();
            tvCuentas.Nodes.Clear();
            TreeNode raiz = tvCuentas.Nodes.Add("Cuentas");
            foreach (Cuenta cuenta in listaCuentas)
            {
                TreeNode nodo = tvCuentas.Nodes.Add(cuenta.Nombre);
                nodo.Nodes.Add("Recibidos");
                nodo.Nodes.Add("Enviados");
                nodo.Nodes.Add("Borradores");
            }
        }

        /// <summary>
        /// Cambia la pantalla principal y abilita el panel para mostrar los mail de las cuentas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuAdministrarCorreo_Click(object sender, EventArgs e)
        {
            if (VaciarDatosEnviarMail_TextChanged(sender, e))
            {
                gbEnviarMail.Visible = false;
                gbOpciones1.Visible = true;
                gpNuevoMail.Visible = false;
                panelCuentas.Visible = true;
            }
        }

        /// <summary>
        /// Vacia los datos cargados en el panel de nuevo mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool VaciarDatosEnviarMail_TextChanged(object sender, EventArgs e)
        {
            if (tbPara.Text != "" || tbCC.Text != "" || tbCCO.Text != "" || tbAsunto.Text != "" || tbAdjuntos.Text != "" || tbCuerpo.Text != "")
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que quiere eliminar este mail no enviado ?", "Advertencia", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    tbPara.Text = "";
                    tbCC.Text = "";
                    tbCCO.Text = "";
                    tbAsunto.Text = "";
                    tbAdjuntos.Text = "";
                    tbCuerpo.Text = "";
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Envia un mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenubEnviar_Click(object sender, EventArgs e)
        {
            FormEnviandoMail enviandoMail = new FormEnviandoMail();
            enviandoMail.Show();
            try
            {
                Fachada.Instancia.EnviarEmail(combobDe.SelectedValue.ToString(),Convert.ToString(tbPara.Text), Convert.ToString(tbAsunto.Text),Convert.ToString(tbCuerpo.Text), tbNombreCuenta.Text);
                enviandoMail.Close();
            }
            catch (DAOExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (EmailExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InternetExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
            
        private void guardarComoBorradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void obtenerMailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           dgEmails.DataSource = Fachada.Instancia.ObtenerEmail(tbNombreCuenta.Text);
        }
    }
}
