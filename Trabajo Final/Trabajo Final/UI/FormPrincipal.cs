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
using System.IO;



namespace Trabajo_Final.UI
{
    public partial class FormPrincipal : Form
    {
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
            FormAcercaDe iFormAcercaDe = new FormAcercaDe();            
            iFormAcercaDe.ShowDialog();
        }

        /// <summary>
        /// Abre un formulario que permite administrar cuentas de correo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdministrarCuentas iFormAdminCuentas = new FormAdministrarCuentas();
            iFormAdminCuentas.ShowDialog();
        }

        private void formAdminCuentas_FormClosed(object sender, FormClosedEventArgs e)       
        {              
            //when child form is closed, this code is executed   
            // Bind the Grid view       
            CargarTreeView();         
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
                tbCCOROnly.ReadOnly = true;
                tbCCROnly.ReadOnly = true;
                panelCuentas.Visible = false;
                gpNuevoMail.Visible = true;
                
            }
        }

        /// <summary>
        /// Habilita la carga de la/las direcciones a los que se le envían una copia carbono del mail. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonCC_Click(object sender, EventArgs e)
        {
                botonCC.Visible = false;
                botonCCAtras.Visible = true;
                tbCC.Visible = true;
                botonAgregarCC.Visible = true;
                botonBorrarUltimoCC.Visible = true;
        }

        /// <summary>
        /// Deshabilita la carga de la/las direcciones a los que se le envían una copia carbono del mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonCCAtras_Click(object sender, EventArgs e)
        {
            botonCCAtras.Visible = false;
            botonCC.Visible = true;
            tbCC.Visible = false;
            botonAgregarCC.Visible = false;
            botonBorrarUltimoCC.Visible = false;
            tbCCROnly.Text = "";
            labelDNValidaCC.Visible = false;
            tbCCROnly.Multiline = false;
            tbCCROnly.Location = new Point(103, 196);
            tbCCROnly.Size = new Size(298, 20);
            if (botonBorrarUltimoCC.Enabled)
            {
                botonBorrarUltimoCC.Enabled = false;
            }
        }

        /// <summary>
        /// Habilita la carga de la/las direcciones a los que se le envían una copia carbono oculta del mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonCCO_Click(object sender, EventArgs e)
        {
            botonCCO.Visible = false;
            botonCCOAtras.Visible = true;
            tbCCO.Visible = true;
            botonAgregarCCO.Visible = true;
            botonBorrarUltimoCCO.Visible = true;
        }

        /// <summary>
        /// Deshabilita la carga de la/las direcciones a los que se le envían una copia carbono del mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonCCOAtras_Click(object sender, EventArgs e)
        {
            botonCCOAtras.Visible = false;
            botonCCO.Visible = true;
            tbCCO.Visible = false;
            botonAgregarCCO.Visible = false;
            botonBorrarUltimoCCO.Visible = false;
            tbCCOROnly.Text = "";
            labelDNValidaCCO.Visible = false;
            tbCCOROnly.Multiline = false;
            tbCCOROnly.Location = new Point(103, 290);
            tbCCOROnly.Size = new Size(298, 20);
            if (botonBorrarUltimoCCO.Enabled)
            {
                botonBorrarUltimoCCO.Enabled = false;
            }
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

            tbAdjuntos.Text = file.InitialDirectory;
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
                panelLeerMail.Visible = false; 
                gbLeerMail.Visible = false; 
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
            botonCCOAtras_Click(sender, e);
            botonCCAtras_Click(sender, e);
            if (tbParaROnly.Text != "" || tbCCROnly.Text != "" || tbCCOROnly.Text != "" || tbAsunto.Text != "" || tbAdjuntos.Text != "" || tbCuerpo.Text != "")
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que quiere eliminar este mail no enviado ?", "Advertencia", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {                    
                    tbParaROnly.Text = "";
                    tbCCROnly.Text = "";
                    tbCCOROnly.Text = "";
                    tbAsunto.Text = "";
                    tbAdjuntos.Text = "";
                    tbCuerpo.Text = "";
                    tbParaROnly.Multiline = false;
                    tbParaROnly.Location = new Point(103, 107);
                    tbParaROnly.Size = new Size(298, 20);
                    botonBorrarUltimoPara.Enabled = false;
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
        /// Agrega una dirección al textbox de destinatarios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonAgregarPara_Click(object sender, EventArgs e)
        {
            if (tbPara.Text != "")
            {
                //Para ver si seesta poniendo una cedena valida como dirección de correo.
                if (!(Regex.IsMatch(tbPara.Text, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+(a-z)*")))
                {
                    labelDNValidaPara.Visible = true;
                }
                else
                {
                    labelDNValidaPara.Visible = false;
                    if (tbParaROnly.Text == "")
                    {
                        tbParaROnly.Text = tbPara.Text + "; ";
                        tbPara.Text = "";
                        botonBorrarUltimoPara.Enabled = true;
                    }
                    else
                    {
                        tbParaROnly.Text = tbParaROnly.Text + tbPara.Text + "; ";
                        tbPara.Text = "";
                    }
                }
                //pasando esa cantidad de elementos en el textbox habilito el multiline.
                if (tbParaROnly.Text.Length > 50)
                {
                    tbParaROnly.Multiline = true;
                    tbParaROnly.Location = new Point(103, 80);
                    tbParaROnly.Size = new Size(298, 47);
                }
            }
            //En caso de que no escriba nada para que no me muestre el label.
            else
            {
                labelDNValidaPara.Visible = false;
            }
        }

        /// <summary>
        /// Borra la última direccion de correo que se escribio como destinatario del mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonBorrarUltimoPara_Click(object sender, EventArgs e)
        {
            //Le saco dos porque se que la última cadena tiene un "; " (punto y coma seguido de un espacio),
            //y no me interezan para ciclar.
            int indice = tbParaROnly.Text.Length - 2;
            bool control = true;
            //Recorro la cadena hacia atras hasta encontrar un "; " (punto y coma seguido de un espacio)
            //para eliminar la última cadena. 
            while (indice > 0 && control)
            {
                //Elimino la última cadena.
                if (tbParaROnly.Text[indice] == ' ' && tbParaROnly.Text[indice - 1] == ';')
                {
                    tbParaROnly.Text = tbParaROnly.Text.Substring(0, indice + 1);
                    control = false;
                }
                else
                {
                    indice--;
                }                
            }
            //En caso de que salga del while por la condición de la sig. linea es porque es la última cadena.
            if (indice == 0)
            {
                tbParaROnly.Text = "";
                botonBorrarUltimoPara.Enabled = false;
            }
            //Para desabilitar el multiline en caso que la cadena posea menos de 50 elemenetos.
            if (tbParaROnly.Text.Length < 50)
            {
                tbParaROnly.Multiline = false;
                tbParaROnly.Location = new Point(103, 107);
                tbParaROnly.Size = new Size(298, 20);
            }
        }

        /// <summary>
        /// Agrega una dirección al textbox de direcciones con copia carbono.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonAgregarCC_Click(object sender, EventArgs e)
        {
            if (tbCC.Text != "")
            {
                //Para ver si seesta poniendo una cedena valida como dirección de correo.
                if (!(Regex.IsMatch(tbCC.Text, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+(a-z)*")))
                {
                    labelDNValidaCC.Visible = true;
                }
                else
                {
                    labelDNValidaCC.Visible = false;
                    if (tbCCROnly.Text == "")
                    {
                        tbCCROnly.Text = tbCC.Text + "; ";
                        tbCC.Text = "";
                        botonBorrarUltimoCC.Enabled = true;
                    }
                    else
                    {
                        tbCCROnly.Text = tbCCROnly.Text + tbCC.Text + "; ";
                        tbCC.Text = "";
                    }
                }
                //pasando esa cantidad de elementos en el textbox habilito el multiline.
                if (tbCCROnly.Text.Length > 50)
                {
                    tbCCROnly.Multiline = true;
                    tbCCROnly.Location = new Point(103, 172);
                    tbCCROnly.Size = new Size(298, 47);
                }
            }
            //En caso de que no escriba nada para que no me muestre el label.
            else
            {
                labelDNValidaCC.Visible = false;
            }
        }

        /// <summary>
        /// Borra la última direccion de correo que se escribio como copia carbono del mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonBorrarUltimoCC_Click(object sender, EventArgs e)
        {
            //Le saco dos porque se que la última cadena tiene un "; " (punto y coma seguido de un espacio),
            //y no me interezan para ciclar.
            int indice = tbCCROnly.Text.Length - 2;
            bool control = true;
            //Recorro la cadena hacia atras hasta encontrar un "; " (punto y coma seguido de un espacio)
            //para eliminar la última cadena. 
            while (indice > 0 && control)
            {
                //Elimino la última cadena.
                if (tbCCROnly.Text[indice] == ' ' && tbCCROnly.Text[indice - 1] == ';')
                {
                    tbCCROnly.Text = tbCCROnly.Text.Substring(0, indice + 1);
                    control = false;
                }
                else
                {
                    indice--;
                }
            }
            //En caso de que salga del while por la condición de la sig. linea es porque es la última cadena.
            if (indice == 0)
            {
                tbCCROnly.Text = "";
                botonBorrarUltimoCC.Enabled = false;
            }
            //Para desabilitar el multiline en caso que la cadena posea menos de 50 elemenetos.
            if (tbCCROnly.Text.Length < 50)
            {
                tbCCROnly.Multiline = false;
                tbCCROnly.Location = new Point(103, 196);
                tbCCROnly.Size = new Size(298, 20);
            }
        }

        /// <summary>
        /// Agrega una dirección al textbox de direcciones con copia carbono oculta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonAgregarCCO_Click(object sender, EventArgs e)
        {
             if (tbCCO.Text != "")
            {
                //Para ver si seesta poniendo una cedena valida como dirección de correo.
                if (!(Regex.IsMatch(tbCCO.Text, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+(a-z)*")))
                {
                    labelDNValidaCCO.Visible = true;
                }
                else
                {
                    labelDNValidaCCO.Visible = false;
                    if (tbCCOROnly.Text == "")
                    {
                        tbCCOROnly.Text = tbCCO.Text + "; ";
                        tbCCO.Text = "";
                        botonBorrarUltimoCCO.Enabled = true;
                    }
                    else
                    {
                        tbCCOROnly.Text = tbCCOROnly.Text + tbCCO.Text + "; ";
                        tbCCO.Text = "";
                    }
                }
                //pasando esa cantidad de elementos en el textbox habilito el multiline.
                if (tbCCOROnly.Text.Length > 50)
                {
                    tbCCOROnly.Multiline = true;
                    tbCCOROnly.Location = new Point(103, 264);
                    tbCCOROnly.Size = new Size(298, 47);
                }
            }
            //En caso de que no escriba nada para que no me muestre el label.
            else
            {
                labelDNValidaCCO.Visible = false;
            }
        }

        /// <summary>
        /// Borra la última direccion de correo que se escribio como copia carbono oculta del mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonBorrarUltimoCCO_Click(object sender, EventArgs e)
        {
            //Le saco dos porque se que la última cadena tiene un "; " (punto y coma seguido de un espacio),
            //y no me interezan para ciclar.
            int indice = tbCCOROnly.Text.Length - 2;
            bool control = true;
            //Recorro la cadena hacia atras hasta encontrar un "; " (punto y coma seguido de un espacio)
            //para eliminar la última cadena. 
            while (indice > 0 && control)
            {
                //Elimino la última cadena.
                if (tbCCOROnly.Text[indice] == ' ' && tbCCOROnly.Text[indice - 1] == ';')
                {
                    tbCCOROnly.Text = tbCCOROnly.Text.Substring(0, indice + 1);
                    control = false;
                }
                else
                {
                    indice--;
                }
            }
            //En caso de que salga del while por la condición de la sig. linea es porque es la última cadena.
            if (indice == 0)
            {
                tbCCOROnly.Text = "";
                botonBorrarUltimoCCO.Enabled = false;
            }
            //Para desabilitar el multiline en caso que la cadena posea menos de 50 elemenetos.
            if (tbCCOROnly.Text.Length < 50)
            {
                tbCCOROnly.Multiline = false;
                tbCCOROnly.Location = new Point(103, 290);
                tbCCOROnly.Size = new Size(298, 20);
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
                Fachada.Instancia.EnviarEmail(combobDe.Text, generarListaDestinatario(tbParaROnly.Text), tbAsunto.Text, tbCuerpo.Text, combobDe.SelectedValue.ToString());
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
        private IList<String>  generarListaDestinatario(String pCadena)
        {
            IList<String> listaDestinatarios = new List<String>();
            String cadena = "";
            int ind = 0;
            while (ind < pCadena.Length)
            {
                if (pCadena[ind] != ';' && ind != pCadena.Length)
                {
                    cadena = cadena + pCadena[ind].ToString();
                    ind ++;
                }
                else 
                {
                    if (pCadena[ind] == ';')
                    {
                        listaDestinatarios.Add(cadena);
                        cadena = "";
                        ind = ind + 2;
                    }
                    else
                    {
                        cadena = cadena + pCadena[ind].ToString();
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
            dgEmails.DataSource = adaptador;
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
                    adaptador.Add(new AdaptadorDataGrid(email.Remitente, email.Destinatario[0], email.Asunto, email.Cuerpo,email.Fecha));
                }
                }
                dgEmails.DataSource = adaptador;
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
            tbParaROnly.Text = "";
            tbCuerpo.Text = "";
            tbCCROnly.Text = "";
            tbCCOROnly.Text = "";
            tbAsunto.Text = "";
            tbAdjuntos.Text = "";
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
                CargarDataGrid(tbNombreCuenta.Text,Convert.ToChar(tbTipoCorreo.Text));
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

        /// <summary>
        /// Obtiene los correos de todas las cuentas configuradas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        

        /// <summary>
        /// Extrae un mail del DataGrilView y lo muestra.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            FormExportar iFormExportar = new FormExportar(tbDeLeerMail.Text,tbAsuntoLeerMail.Text,tbParaLeerMail.Text,tbCuerpoLeerMail.Text,Convert.ToDateTime(tbFechaLeerMail.Text));                
            iFormExportar.ShowDialog();
        }
    }
}
