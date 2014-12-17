using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_Final.UI
{
    partial class FormAcercaDe : Form
    {
        public FormAcercaDe()
        {
            InitializeComponent();
            this.Text = String.Format("Acerca de MaDBaF Email Manager");
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Versión {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
        }

        #region Descriptores de acceso de atributos de ensamblado

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {return "Esta aplicación administra cuentas de correos electronicos, donde permite enviar, recibir y exportar e-mail." ; }
        }

        public string AssemblyProduct
        {
            get
            {
                return "MaDBaF Email Manager";
            }
        }

        public string AssemblyCopyright
        {
            get
            { return "Copyright 2014 MaDBaF Email Manager"; }
        }

        public string AssemblyCompany
        {
            get { return "Del Real Matias, Fellin Brian"; }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
