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
    public partial class FormExportar : Form
    {
        private String iRemitente;
        private String iAsunto;
        private String iCuerpo;
        private String iDestinatario;

        public FormExportar(String pRemitente, String pAsunto, String pDestinatario, String pCuerpo)
        {
            InitializeComponent();
            this.iRemitente = pRemitente;
            this.iAsunto = pAsunto;
            this.iDestinatario = pDestinatario;
            this.iCuerpo = pCuerpo;
        }

        /// <summary>
        /// Permite buscar un directorio en el sistema de archivos de la pc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bBuscarDirectorio_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog carpeta = new FolderBrowserDialog();
            carpeta.Description = "Seleccione un Directorio";
            carpeta.ShowNewFolderButton = true;
            carpeta.ShowDialog();
            tbRutaDirectorio.Text = carpeta.SelectedPath;
        }

        private void FormExportar_Load(object sender, EventArgs e)
        {
            cbTipoExportador.SelectedIndex = 0;
        }


        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (tbRutaDirectorio.Text == "")
            {
                MessageBox.Show("Seleccione un directorio donde almacenar el archivo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    IList<String> destinatarios = new List<String>();
                    destinatarios.Add(this.iDestinatario);
                    String ruta = tbRutaDirectorio.Text + @"\" + tbNombreArchivo.Text;
                    Fachada.Instancia.Exportar(this.iRemitente, destinatarios, this.iAsunto, this.iCuerpo, ruta, cbTipoExportador.SelectedItem.ToString());
                    MessageBox.Show("Se ha exportado el Email con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (ExportadorExcepcion ex)
                {
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
