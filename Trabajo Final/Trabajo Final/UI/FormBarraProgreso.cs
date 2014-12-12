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
    public partial class FormBarraProgreso : Form
    {
        delegate void CallBack(int p);

        private int iValorProgreso;
        public FormBarraProgreso()
        {
            InitializeComponent();
        }

        //Establece el valor de la barra de progreso
        public void SetValorProgreso(int pValor)
        {
           if (progressBar.InvokeRequired)
           {
                CallBack d = new CallBack(SetValorProgreso);
                this.Invoke(d,pValor);
           }
           else
           {
             this.iValorProgreso = pValor;
           } 
           progressBar.Value = this.iValorProgreso;        
        }
    }
}
