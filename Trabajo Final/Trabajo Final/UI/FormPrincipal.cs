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
using Trabajo_Final.Dominio;
using System.Threading;
using System.Text.RegularExpressions;
using Trabajo_Final.Utils;


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
            CargarTreeView();         
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
            CargarTreeView();
        }

        /// <summary>
        /// Carga las cuentas en el treeView del formulario principal.
        /// </summary>
        public void CargarTreeView()
        {
            tvCuentas.Nodes.Clear();
            //cargo los nombres de las cuentas, y genero sus nodos de recibidos,enviados y borradores
            foreach (Cuenta cuenta in Fachada.Instancia.ObtenerCuentas())
            {
                TreeNode nodo = tvCuentas.Nodes.Add(cuenta.Nombre,cuenta.Nombre+ "("+cuenta.Direccion+")") ;
                nodo.Nodes.Add("Rec","Recibidos");
                nodo.Nodes.Add("Env","Enviados");
                nodo.Nodes.Add("Bor","Borradores");
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
            try
            {
                progressBarEnviando.Maximum = 10;
                progressBarEnviando.Visible = true;
                progressBarEnviando.Value = 3;
                progressBarEnviando.Value = 4;
                progressBarEnviando.Value = 5;
                gpNuevoMail.Enabled = false;
                gbEnviarMail.Enabled = false;
                menuStrip1.Enabled = false;               
                progressBarEnviando.Value = 6;
                progressBarEnviando.Value = 7;
                progressBarEnviando.Value = 8;
                progressBarEnviando.Value = 10;
                lEnviado.Visible = true;
                borrarMailEnviado();             
            }
            catch (EmailExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InternetExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {                
                gpNuevoMail.Enabled = true;
                gbEnviarMail.Enabled = true;
                menuStrip1.Enabled = true;
                progressBarEnviando.Visible = false;
            }
            
        }

        /// <summary>
        /// Genera una lista de string con los destinatarioas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private List<String>  generarListaDestinatario()
        {
            List<String> listaDestinatarios = new List<String>();
            String cadena = "";
            int ind = 0;
            while (ind < tbPara.Text.Length)
            {
                if (tbPara.Text[ind].ToString() != ";" && ind != tbPara.Text.Length)
                {
                    cadena = cadena + tbPara.Text[ind].ToString();
                    ind ++;
                }
                else 
                {
                    if (tbPara.Text[ind].ToString() == ";")
                    {
                        listaDestinatarios.Add(cadena);
                        cadena = "";
                        ind = ind + 2;
                    }
                    else
                    {
                        cadena = cadena + tbPara.Text[ind].ToString();
                        listaDestinatarios.Add(cadena);
                        cadena = "";
                        ind++;
                    }
                }
            }
            return listaDestinatarios;
        }
           
        /// <summary>
        /// Cargar el data grid con los datos de los emails de una cuenta teniendo en cuenta
        /// el nodo seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MostrarDatosDelNodo(object sender, TreeNodeMouseClickEventArgs e)
        {
            //verifico si el nodo esta en el nivel cero, si no esta en el nivel cero, significa
            //que es hijo de algun nodo, por lo que muestro el nombre del nodo padre
            if (!(e.Node.Level == 0))
            {
                tbNombreCuenta.Text = e.Node.Parent.Name;
                tbTipoCorreo.Text = e.Node.Name;
                CargarDataGrid(e.Node.Parent.Name);
            }
            else
            {
                tbNombreCuenta.Text = e.Node.Name;
            }
        }

        /// <summary>
        /// Carga el data grid
        /// </summary>
        /// <param name="pNombreNodo"></param>
        private void CargarDataGrid(String pNombreNodo)
        {
            IList<AdaptadorDataGrid> adaptador = new List<AdaptadorDataGrid>();
                foreach(Email email in Fachada.Instancia.GetEmails(pNombreNodo))
                {
                    adaptador.Add(new AdaptadorDataGrid(email.Remitente, email.Destinatario[0], email.Asunto,email.Cuerpo));
                }
                dgEmails.DataSource = adaptador;
        }

        private void guardarComoBorradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Luego que se envia un mail borra el panel y sus elementos.
        /// </summary>
        private void borrarMailEnviado()
        {
            tbPara.Text = "";
            tbCuerpo.Text = "";
            tbCC.Text = "";
            tbCCO.Text = "";
            tbAsunto.Text = "";
            tbAdjuntos.Text = "";                
            tbCC.ReadOnly = true;
            tbCCO.ReadOnly = true;              
        }

        /// <summary>
        /// Borra el label que notifica que se envio un mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorrarLabelEnviado(object sender, MouseEventArgs e)
        {
            lEnviado.Visible = false;
        }

        /// <summary>
        /// Obtiene los Emails de una cuenta de correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void obtenerMailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Fachada.Instancia.ObtenerEmail(tbNombreCuenta.Text);
                CargarDataGrid(tbNombreCuenta.Text);
            }           
            catch(NombreCuentaExcepcion ex)
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
            catch(DAOExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void obtenerTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {          
           IList<String> listaNombreCuentas = new List<String>();
           foreach (TreeNode tn in tvCuentas.Nodes)
           {
              listaNombreCuentas.Add(tn.Name);
           }
           try
           {
               Fachada.Instancia.ObtenerTodosEmails(listaNombreCuentas);
           }
           catch (NombreCuentaExcepcion ex)
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


        private void tbPara_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbPara.Text = tbPara.Text + "; ";
                tbPara.Select(tbPara.Location.X + tbPara.Text.Length, tbPara.Location.Y);
            }
        }

        private void tbCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbPara.Text = tbPara.Text + "; ";
                tbPara.Select(tbPara.Location.X + tbPara.Text.Length, tbPara.Location.Y);
            }
        }

        private void tbCCO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbPara.Text = tbPara.Text + "; ";
                tbPara.Select(tbPara.Location.X + tbPara.Text.Length, tbPara.Location.Y);
            }
        }
    }
}
