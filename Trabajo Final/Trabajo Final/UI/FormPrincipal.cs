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
using Trabajo_Final.Excepciones;
using Trabajo_Final.Dominio;
using System.Threading;
using System.Text.RegularExpressions;
using Trabajo_Final.Utils;


namespace Trabajo_Final.UI
{
    public partial class FormPrincipal : Form
    {
        delegate void AddItemCallBack(string p);

        private static FormAdministrarCuentas iFormAdminCuentas;
        private static FormAcercaDe iFormAcercaDe;
        private static FormExportar iFormExportar;
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
                //iFormAcercaDe.MdiParent = this;
                iFormAcercaDe.Disposed += new EventHandler(form_Disposed);
            }
            iFormAcercaDe.ShowDialog();
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
            iFormExportar = null;
        }

        /// <summary>
        /// Cambia la pantalla principal y habilita el panel para enviar un nuevo mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redactarEmailToolStripMenuItem_Click(object sender, EventArgs e)
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
                nodo.Nodes.Add("R","Recibidos");
                nodo.Nodes.Add("E","Enviados");
                nodo.Nodes.Add("B","Borradores");
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
                panelLeerMail.Visible = false; //
                gbLeerMail.Visible = false; //
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
                Fachada.Instancia.EnviarEmail(combobDe.Text, generarListaDestinatario(), tbAsunto.Text, tbCuerpo.Text, combobDe.SelectedValue.ToString());
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
        private IList<String>  generarListaDestinatario()
        {
            IList<String> listaDestinatarios = new List<String>();
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
                CargarDataGrid(e.Node.Parent.Name,Convert.ToChar(tbTipoCorreo.Text));
            }
            else
            {
                tbNombreCuenta.Text = e.Node.Name;
            }
        }

        /// <summary>
        /// Carga el data grid.
        /// </summary>
        /// <param name="pNombreCuenta">Nombre de la cuenta</param>
        /// <param name="pTipoCorreo">Tipo de correo (recibidos,enviados,borradores)</param>
        private void CargarDataGrid(String pNombreCuenta,Char pTipoCorreo)
        {
            switch (pTipoCorreo)
            {
                case 'R': { FiltarRecibidos(pNombreCuenta); }
                    break;
                case 'E': { FiltarEnviados(pNombreCuenta); }
                    break;
            }
           
        }

        private void FiltarRecibidos(String pNombreCuenta)
        {
            IList<AdaptadorDataGrid> adaptador = new List<AdaptadorDataGrid>();
            
            foreach (Email email in Fachada.Instancia.GetEmails(pNombreCuenta))
            {
                Cuenta cuenta = Fachada.Instancia.GetCuenta(pNombreCuenta);
                String remitente = StringsUtils.ObtenerEmail(email.Remitente);             
                if (remitente != cuenta.Direccion)
                {
                    adaptador.Add(new AdaptadorDataGrid(email.Remitente, email.Destinatario[0], email.Asunto, email.Cuerpo,email.Fecha));
                }
            }
            //ordeno por fecha                         
            adaptador = (from e in adaptador
                         orderby e.Fecha descending
                         select e).ToList();

            //controlo si otro hilo de ejecucion requiere hacer uso del data grid
            //entonces creo un delegado para cederle la tarea de actualizar el data grid,
            //sino directamente le asigno los datos al data grid
            if (dgEmails.InvokeRequired) 
            {
                AddItemCallBack d = new AddItemCallBack( FiltarRecibidos);
                    this.Invoke(d,pNombreCuenta);
            }
            else
            {
                dgEmails.DataSource = adaptador;
            }
            
            dgEmails.Columns["destinatario"].Visible = false;
            dgEmails.Columns["remitente"].Visible = true;
        }

        private void FiltarEnviados(String pNombreCuenta)
        {
            IList<AdaptadorDataGrid> adaptador = new List<AdaptadorDataGrid>();

            foreach (Email email in Fachada.Instancia.GetEmails(pNombreCuenta))
            {
                Cuenta cuenta = Fachada.Instancia.GetCuenta(pNombreCuenta);
                String remitente = StringsUtils.ObtenerEmail(email.Remitente);
                if (remitente == cuenta.Direccion)
                {
                    adaptador.Add(new AdaptadorDataGrid(email.Remitente, email.Destinatario[0], email.Asunto, email.Cuerpo, email.Fecha));
                }
            }
            //ordeno por fecha
            adaptador = (from e in adaptador
                           orderby e.Fecha descending
                           select e).ToList();
            //controlo si otro hilo de ejecucion requiere hacer uso del data grid
            //entonces creo un delegado para cederle la tarea de actualizar el data grid,
            //sino directamente le asigno los datos al data grid
            if (dgEmails.InvokeRequired)
            {
                AddItemCallBack d = new AddItemCallBack(FiltarEnviados);
                this.Invoke(d, pNombreCuenta);
            }
            else
            {
                dgEmails.DataSource = adaptador;
            }
            dgEmails.Columns["remitente"].Visible = false;
            dgEmails.Columns["destinatario"].Visible = true;
        }

        private void FiltarBorradores(String pNombreCuenta)
        {
            dgEmails.DataSource = "";
            dgEmails.Columns["remitente"].Visible = false;
            dgEmails.Columns["destinatario"].Visible = true;
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
                BackgroundWorker hilo = new BackgroundWorker();
                hilo.WorkerReportsProgress = true;
                hilo.ReportProgress(40);
                hilo.DoWork += new DoWorkEventHandler(ObtenerMailDeUnaCuenta);
                hilo.RunWorkerAsync();
                hilo.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
                hilo.ReportProgress(60);
                hilo.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProgressCompleted);                                                                
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Cambia el valor del progressBar segun el progreso de BackgroundWorker
            progressBar.Value = e.ProgressPercentage;
        }

        private void ProgressCompleted(object sender,RunWorkerCompletedEventArgs e)
        {
            //Establezco el progressBar en 100 ya que la operacion se completo
            progressBar.Value = 100;
            label7.Visible = true;
        }

        private void ObtenerMailDeUnaCuenta(object sender, DoWorkEventArgs e)
        {         
          try
          {  
            Fachada.Instancia.ObtenerEmail(tbNombreCuenta.Text);
            CargarDataGrid(tbNombreCuenta.Text, Convert.ToChar(tbTipoCorreo.Text));
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
          catch (DAOExcepcion ex)
          {
              MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }


        /// <summary>
        /// Obtiene los correos de todas las cuentas configuradas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void obtenerTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {                     
           try
           {
               //Obtiene los emails por cada una de las cuentas que estan en el tree view
               BackgroundWorker hilo1 = new BackgroundWorker();
               hilo1.DoWork += new DoWorkEventHandler(ObtenerTodos);

               hilo1.RunWorkerAsync();
               
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

        private void ObtenerTodos(object sender, DoWorkEventArgs e)
        {
            IList<String> listaNombreCuentas = new List<String>();
            //itera los nodos principales del tree view para obtener las cuentas configuradas
            //para poder extraer sus emails
            foreach (TreeNode tn in tvCuentas.Nodes)
            {
                listaNombreCuentas.Add(tn.Name);
            }
            Fachada.Instancia.ObtenerTodosEmails(listaNombreCuentas);
            CargarDataGrid(tbNombreCuenta.Text, Convert.ToChar(tbTipoCorreo.Text));
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

        private void LeerMail(object sender, EventArgs e)
        {            
            if (dgEmails.RowCount > 0)
            {
                panelLeerMail.Visible = true;
                gbLeerMail.Visible = true;
                gbOpciones1.Visible = false;
                gbEnviarMail.Visible = false;
                panelCuentas.Visible = false;
                gpNuevoMail.Visible = false;
                //Tomo la fila seleccionada del DataGridView y la cargo como un adaptador, para mostrarla.  
                AdaptadorDataGrid fila = (AdaptadorDataGrid)dgEmails.CurrentRow.DataBoundItem;
                //Veo si el mail posee asunto, para mostrarlo, sino muestro "Sin Asunto".
                if (Convert.ToString(fila.Asunto) != "")
                {
                    tbAsuntoLeerMail.Text = Convert.ToString(fila.Asunto);
                }
                tbDeLeerMail.Text = fila.Remitente;
                tbParaLeerMail.Text = fila.Destinatario;
                tbCuerpoLeerMail.Text = fila.Cuerpo;
                tbFechaLeerMail.Text = Convert.ToString(fila.Fecha);
            }
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iFormExportar == null)
            {                
                iFormExportar = new FormExportar(tbDeLeerMail.Text,tbAsuntoLeerMail.Text,tbParaLeerMail.Text,tbCuerpoLeerMail.Text,Convert.ToDateTime(tbFechaLeerMail.Text));
                iFormExportar.Disposed += new EventHandler(form_Disposed);                
            }
            iFormExportar.Show();
        }
    }
}
