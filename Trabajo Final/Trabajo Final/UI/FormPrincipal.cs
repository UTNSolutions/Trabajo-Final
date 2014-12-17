using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final.Controladores;
using Trabajo_Final.Excepciones;
using Trabajo_Final.DTO;
using System.Threading;
using System.Text.RegularExpressions;
using Trabajo_Final.Utils;
using System.IO;
using System.Activities.Statements;
using System.Collections;


namespace Trabajo_Final.UI
{
    public partial class FormPrincipal : Form
    {
        delegate void CallBack(string p);

        private FormBarraProgreso iFormBarraProgreso;
        public FormPrincipal()
        {
            InitializeComponent();
        }
        #region MetodosParaAbrirFormularios
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
            iFormAdminCuentas.FormClosed += new FormClosedEventHandler(formAdminCuentas_FormClosed);
            iFormAdminCuentas.ShowDialog();           
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormExportar iFormExportar = new FormExportar(tbDeLeerMail.Text, tbAsuntoLeerMail.Text, generarListaCadenas(tbParaLeerMail.Text), generarListaCadenas(tbCCLeerMail.Text), tbCuerpoLeerMail.Text, Convert.ToDateTime(tbFechaLeerMail.Text));
            iFormExportar.ShowDialog();
        }
        #endregion
        
        #region RedactarEmail

        /// <summary>
        /// Cambia la pantalla principal y Habilita el panel para mostrar los E-Mails de las cuentas.
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
            CCAtrasEvento();
        }

        /// <summary>
        /// Restablece la opción con copia carbono.
        /// </summary>
        private void CCAtrasEvento()
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
            CCOAtrasEvento();
        }

        /// <summary>
        /// Restablece la opción con copia carbono oculta.
        /// </summary>
        private void CCOAtrasEvento()
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
            tbAdjuntos.Text = tbAdjuntos.Text + file.FileName + "; ";
            if(botonBorrarUltimoAdjuntos.Visible == false)
            {
                botonBorrarUltimoAdjuntos.Visible = true;

            }
        }

        private void botonBorrarUltimoAdjuntos_Click(object sender, EventArgs e)
        {
            //Le saco dos porque se que la última cadena tiene un "; " (punto y coma seguido de un espacio),
            //y no me interezan para ciclar.
            int indice = tbAdjuntos.Text.Length - 2;
            bool control = true;
            //Recorro la cadena hacia atras hasta encontrar un "; " (punto y coma seguido de un espacio)
            //para eliminar la última cadena. 
            while (indice > 0 && control)
            {
                //Elimino la última cadena.
                if (tbAdjuntos.Text[indice] == ' ' && tbAdjuntos.Text[indice - 1] == ';')
                {
                    tbAdjuntos.Text = tbAdjuntos.Text.Substring(0, indice + 1);
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
                tbAdjuntos.Text = "";
                botonBorrarUltimoAdjuntos.Visible = false;
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
                DialogResult resultado = MessageBox.Show("¿Está seguro que quiere eliminar este mail no enviado ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                //Para ver si se esta poniendo una cadena valida como dirección de correo.
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
                gpNuevoMail.Enabled = false;
                gbEnviarMail.Enabled = false;
                menuStrip1.Enabled = false;
                Fachada.Instancia.EnviarEmail(combobDe.Text, generarListaCadenas(tbParaROnly.Text), generarListaCadenas(tbCCROnly.Text), generarListaCadenas(tbCCOROnly.Text), tbAsunto.Text, tbCuerpo.Text, generarListaCadenas(tbAdjuntos.Text), combobDe.SelectedValue.ToString());
                lEnviado.Visible = true;
                borrarMailEnviado();
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
            finally
            {
                gpNuevoMail.Enabled = true;
                gbEnviarMail.Enabled = true;
                menuStrip1.Enabled = true;
            }
        }

        /// <summary>
        /// Genera una lista de string que se utilizan en el envio de un mail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private IList<String> generarListaCadenas(String pCadena)
        {
            IList<String> listaDestinatarios = new List<String>();
            String cadena = "";
            int ind = 0;
            if (pCadena != "")
            {
                while (ind < pCadena.Length)
                {
                    if (pCadena[ind] != ';' && ind != pCadena.Length)
                    {
                        cadena = cadena + pCadena[ind].ToString();
                        ind++;
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
            }
            else
            {
                listaDestinatarios = null;
            }
            return listaDestinatarios;
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
            botonBorrarUltimoPara.Enabled = false;
            CCAtrasEvento();
            CCOAtrasEvento();
        }

        /// <summary>
        /// Borra el label que notifica que se envio un mail y la barra de progreso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorrarLabelEnviadoYBarraProgreso(object sender, MouseEventArgs e)
        {
            lEnviado.Visible = false;
        }

        /// <summary>
        /// Lo que hace es si se redacta un nuevo mail, cuando se escribe el asunto, si el textbox pasado los 
        /// 50 caracteres, entonces se le modifica a este último la propiedad multiline, y se le aumenta de tamaño.
        /// El proceso a la inversa se hace, si se esta borrando en el textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbAsunto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13)
            {
                if (tbAsunto.Text.Length > 50)
                {
                    tbAsunto.Size = new Size(354, 38);
                    tbAsunto.Multiline = true;
                }
                if (tbAsunto.Text.Length < 50)
                {
                    tbAsunto.Size = new Size(354, 20);
                    tbAsunto.Multiline = false;
                }
            }
        }
        #endregion

        #region Formulario Principal
        /// <summary>
        /// Evento que se ejecuta cuando inicia el formulario principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                CargarTreeView();
            }
            catch (DAOExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga las cuentas en el treeView del formulario principal.
        /// </summary>
        public void CargarTreeView()
        {
            tvCuentas.Nodes.Clear();
            //cargo los nombres de las cuentas, y genero sus nodos de recibidos,enviados y borradores
            foreach (CuentaDTO cuenta in Fachada.Instancia.ObtenerCuentas())
            {
                TreeNode nodo = tvCuentas.Nodes.Add(cuenta.Nombre, cuenta.Nombre + "(" + cuenta.Direccion + ")");
                nodo.Nodes.Add("R", "Recibidos");
                nodo.Nodes.Add("E", "Enviados");
            }
            if (tvCuentas.Nodes.Count > 0)
            {
                tbNombreCuenta.Text = tvCuentas.GetNodeAt(1, 1).Name;
            }
        }

        private void formAdminCuentas_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Cuando cierro el formulario de administrar las cuentas, cargo nuevamente
            //el tree view para que se actualize
            CargarTreeView();
            //le asigno al data grid una lista vacia para que no muestre ningun dato
            dgEmails.DataSource = new List<AdaptadorDataGrid>();
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
                try
                {
                    combobDe.DataSource = Fachada.Instancia.ObtenerCuentas();
                }
                catch (DAOExcepcion ex)
                {
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        /// Carga el data grid con los datos de los emails de una cuenta teniendo en cuenta
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
                CargarDataGrid(e.Node.Parent.Name, Convert.ToChar(tbTipoCorreo.Text));
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
        private void CargarDataGrid(String pNombreCuenta, Char pTipoCorreo)
        {
            switch (pTipoCorreo)
            {
                case 'R': { FiltarRecibidos(pNombreCuenta); }
                    break;
                case 'E': { FiltarEnviados(pNombreCuenta); }
                    break;
            }          
        }

        /// <summary>
        /// Separa los E-Mails que fueron recibidos de los que fueron recibidos en una cuenta.
        /// </summary>
        /// <param name="pNombreCuenta"></param>
        private void FiltarRecibidos(String pNombreCuenta)
        {
            IList<AdaptadorDataGrid> adaptador = new List<AdaptadorDataGrid>();
            
            foreach (EmailDTO email in Fachada.Instancia.GetEmails(pNombreCuenta))
            {
                CuentaDTO cuenta = Fachada.Instancia.GetCuenta(pNombreCuenta);
                String remitente = StringsUtils.ObtenerEmail(email.Remitente);
                //si el remitente del email no coincide con la direccion de la cuenta es porque
                //se trata de un Email recibido
                if (remitente != cuenta.Direccion)
                {
                    adaptador.Add(new AdaptadorDataGrid(email.IdEmail, email.Remitente, email.Destinatario, email.ConCopia, email.Asunto, email.Cuerpo, email.Adjuntos, email.Fecha, email.Leido));
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
                CallBack d = new CallBack(FiltarRecibidos);
                this.Invoke(d, pNombreCuenta);
            }
            else
            {
                dgEmails.DataSource = adaptador;
                //itera cada fila del data grid para saber si el email fue leido o no
                //y asi poder colorear los emails que fueron leidos
                foreach (DataGridViewRow fila in dgEmails.Rows)
                {
                    DataGridViewTextBoxCell celda = (DataGridViewTextBoxCell)fila.Cells["leido"];
                    if (!(bool)celda.Value)
                    {
                        fila.DefaultCellStyle.BackColor = Color.Wheat;
                    }
                }
            }         
            dgEmails.Columns["destinatario"].Visible = false;
            dgEmails.Columns["remitente"].Visible = true;
        }

        /// <summary>
        /// Separa los E-Mails que fueron enviados de los que fueron recibidos en una cuenta.
        /// </summary>
        /// <param name="pNombreCuenta"></param>
        private void FiltarEnviados(String pNombreCuenta)
        {
            IList<AdaptadorDataGrid> adaptador = new List<AdaptadorDataGrid>();

            foreach (EmailDTO email in Fachada.Instancia.GetEmails(pNombreCuenta))
            {
                CuentaDTO cuenta = Fachada.Instancia.GetCuenta(pNombreCuenta);
                String remitente = StringsUtils.ObtenerEmail(email.Remitente);
                //si el remitente del email coincide con la direccion de la cuenta es porque
                //se trata de un Email enviado
                if (remitente == cuenta.Direccion)
                {
                    adaptador.Add(new AdaptadorDataGrid(email.IdEmail, email.Remitente, email.Destinatario, email.ConCopia, email.Asunto, email.Cuerpo, email.Adjuntos, email.Fecha, email.Leido));
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
                CallBack d = new CallBack(FiltarEnviados);
                this.Invoke(d, pNombreCuenta);
                }
            else
            {
                dgEmails.DataSource = adaptador;
                //itera cada fila del data grid para saber si el email fue leido o no
                //y asi poder colorear los emails que fueron leidos
                foreach (DataGridViewRow fila in dgEmails.Rows)
                {
                    DataGridViewTextBoxCell celda = (DataGridViewTextBoxCell)fila.Cells["leido"];
                    if (!(bool)celda.Value)
                    {
                        fila.DefaultCellStyle.BackColor = Color.Wheat;
                    }
                }
            }
            dgEmails.Columns["remitente"].Visible = false;
            dgEmails.Columns["destinatario"].Visible = true;
        }

        
        /// <summary>
        /// Obtiene los Emails de una cuenta de correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void obtenerMailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (tbNombreCuenta.Text == "")
            {
                MessageBox.Show("Seleccione una cuenta antes de obtener los Correos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.iFormBarraProgreso = new FormBarraProgreso();
                this.iFormBarraProgreso.Show();
                BackgroundWorker hilo = new BackgroundWorker();
                hilo.WorkerReportsProgress = true;
                hilo.DoWork += new DoWorkEventHandler(ObtenerMailDeUnaCuenta);
                hilo.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProgressCompleted);
                hilo.RunWorkerAsync();
            }
        }


        private void ProgressCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.iFormBarraProgreso.Close();    
        }

        /// <summary>
        /// Obtiene los Emails de una cuenta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
               this.iFormBarraProgreso = new FormBarraProgreso();
               this.iFormBarraProgreso.Show();
               BackgroundWorker hilo = new BackgroundWorker();
               hilo.DoWork += new DoWorkEventHandler(ObtenerTodos);
               hilo.WorkerReportsProgress = true;               
               hilo.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProgressCompleted);
               hilo.RunWorkerAsync();
        }

        /// <summary>
        /// Obtiene los correos de cada una de las cuentas configuradas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObtenerTodos(object sender, DoWorkEventArgs e)
        {
          try
          {
            //Obtiene los emails por cada una de las cuentas que estan en el tree view
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
            catch (DAOExcepcion ex)
          {
            MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Permite Eliminar un Email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgEmails.RowCount > 0)
                {
                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar el E-Mail seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        AdaptadorDataGrid fila = (AdaptadorDataGrid)dgEmails.CurrentRow.DataBoundItem;
                        int id = fila.IdEmail;
                        Fachada.Instancia.EliminarEmail(tbNombreCuenta.Text, id);
                        MessageBox.Show("El E-Mail ha sido eliminado con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDataGrid(tbNombreCuenta.Text, Convert.ToChar(tbTipoCorreo.Text));
                    }
                }
            }
            catch (DAOExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
#endregion

        #region LeerEmail

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
                if (fila.CC != null)
                {
                    labelCC.Visible = true;
                    tbCCLeerMail.Visible = true;
                    tbCCLeerMail.Text = fila.CC;
                    tbCuerpoLeerMail.Location = new Point(6, 142);
                    tbCuerpoLeerMail.Size = new Size(841, 276);
                }
                else
                {
                    labelCC.Visible = false;
                    tbCCLeerMail.Visible = false;
                    tbCuerpoLeerMail.Location = new Point(6, 109);
                    tbCuerpoLeerMail.Size = new Size(841, 314);
                }
                if (fila.Adjuntos != null)
                {
                    panelDatosAdLeerMail.Visible = true;
                    IList<String> listaAdjuntos = generarListaCadenas(fila.Adjuntos);
                    IList<ArchivoAdjunto> datosAdjuntos = new List<ArchivoAdjunto>();
                    foreach (String adjunto in listaAdjuntos)
                    {
                        int indice = adjunto.Length - 1;
                        String cadena = "";
                        while (adjunto[indice] != Convert.ToChar(@"\"))
                        {
                            cadena = adjunto[indice] + cadena;
                            indice--;
                        }
                        datosAdjuntos.Add(new ArchivoAdjunto(cadena, adjunto));
                    }
                    cbDatosAdLeerMail.DataSource = datosAdjuntos;
                    tbCuerpoLeerMail.Location = new Point(6, 178);
                    tbCuerpoLeerMail.Size = new Size(841, 231);
                }
                else
                {
                    panelDatosAdLeerMail.Visible = false;
                }
                tbDeLeerMail.Text = fila.Remitente;
                tbParaLeerMail.Text = fila.Destinatario;
                tbCuerpoLeerMail.Text = fila.Cuerpo;
                tbFechaLeerMail.Text = Convert.ToString(fila.Fecha);
                //pinto en blanco la fila ya que el email ha sido leido
                dgEmails.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                //Cambio el estado del email a leido en la base de datos y en en el Email del dominio
                try
                {
                    Fachada.Instancia.MarcarComoLeido(tbNombreCuenta.Text, fila.IdEmail);
                }
                catch (DAOExcepcion ex)
                {
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
      
        private void responderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                combobDe.DataSource = Fachada.Instancia.ObtenerCuentas();
                tbParaROnly.Text = tbDeLeerMail.Text + "; ";
                tbAsunto.Text = "Re: " + tbAsuntoLeerMail.Text;
                panelLeerMail.Visible = false;
                gbEnviarMail.Visible = true;
                tbCCOROnly.ReadOnly = true;
                tbCCROnly.ReadOnly = true;
                gpNuevoMail.Visible = true;
                botonBorrarUltimoPara.Enabled = true;
            }
            catch (DAOExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

       
        /// <summary>
        /// Abre el archivo adjunto seleccionado, por una llamada al sistema operativos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bVerLeerMail_Click(object sender, EventArgs e)
        {
            try
            {
                //Lo que hacemos es ejecutar un proceso que abre el archivo. 
                Process proceso = new Process();
                proceso.EnableRaisingEvents = false;
                proceso.StartInfo.FileName = cbDatosAdLeerMail.SelectedValue.ToString();
                proceso.Start();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("El archivo que intenta abrir no se encuentra disponible, se ha eliminado o cambiado de directorio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
            }
        }

        /// <summary>
        /// Guarda un archivo adjunto seleccionado como un nuevo archivo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bGuardarLeerMail_Click(object sender, EventArgs e)
        {   
            
            int indice = cbDatosAdLeerMail.SelectedValue.ToString().Length - 1;
            String cadenaPrueba = cbDatosAdLeerMail.SelectedValue.ToString();
            String cadena = "";
            //Lo que hacemos es tomar la extensión del archivo para guardarlo.
            while (cadenaPrueba[indice] != '.')
            {
                cadena = cadenaPrueba[indice] + cadena;
                indice--;
            }
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = cadena + "|*." + cadena;
            if (File.Exists(cbDatosAdLeerMail.SelectedValue.ToString()))
            {
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {                
                    FileStream archivoAGuardar = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                    try
                    {
                        FileStream archivoACopiar = File.Open(cbDatosAdLeerMail.SelectedValue.ToString(), FileMode.Open);
                        archivoACopiar.CopyTo(archivoAGuardar, 4096);
                        archivoACopiar.Close();
                        MessageBox.Show("El archivo se ha guardado con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Cierre el archivo antes de guardarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        File.Delete(saveFileDialog1.FileName);
                    }
                    finally
                    {
                        archivoAGuardar.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("El archivo que intenta guardar no se encuentra disponible, se ha eliminado o cambiado de directorio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
        #endregion                
    }
}
