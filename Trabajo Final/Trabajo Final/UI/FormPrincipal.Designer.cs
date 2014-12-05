namespace Trabajo_Final.UI
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Cuentas de Correo");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvCuentas = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.obtenerMailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obtenerTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoMeilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gpNuevoMail = new System.Windows.Forms.GroupBox();
            this.botonCCO = new System.Windows.Forms.Button();
            this.botonCC = new System.Windows.Forms.Button();
            this.bAdjuntar = new System.Windows.Forms.Button();
            this.bGuardar = new System.Windows.Forms.Button();
            this.tbAsunto = new System.Windows.Forms.TextBox();
            this.bEnviar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCuerpo = new System.Windows.Forms.RichTextBox();
            this.tbCC = new System.Windows.Forms.TextBox();
            this.tbCCO = new System.Windows.Forms.TextBox();
            this.tbAdjuntos = new System.Windows.Forms.TextBox();
            this.tbPara = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelCuentas = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.gpNuevoMail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.panelCuentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentasToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(819, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cuentasToolStripMenuItem
            // 
            this.cuentasToolStripMenuItem.Name = "cuentasToolStripMenuItem";
            this.cuentasToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.cuentasToolStripMenuItem.Text = "Cuentas";
            this.cuentasToolStripMenuItem.Click += new System.EventHandler(this.cuentasToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de ...";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // tvCuentas
            // 
            this.tvCuentas.Location = new System.Drawing.Point(12, 78);
            this.tvCuentas.Name = "tvCuentas";
            treeNode5.Name = "Nodo0";
            treeNode5.Text = "Cuentas de Correo";
            this.tvCuentas.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.tvCuentas.Size = new System.Drawing.Size(185, 371);
            this.tvCuentas.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.menuStrip2);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 45);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obtenerMailsToolStripMenuItem,
            this.obtenerTodosToolStripMenuItem,
            this.nuevoMeilToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(3, 16);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(524, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // obtenerMailsToolStripMenuItem
            // 
            this.obtenerMailsToolStripMenuItem.Name = "obtenerMailsToolStripMenuItem";
            this.obtenerMailsToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.obtenerMailsToolStripMenuItem.Text = "Obtener";
            this.obtenerMailsToolStripMenuItem.Click += new System.EventHandler(this.obtenerMailsToolStripMenuItem_Click);
            // 
            // obtenerTodosToolStripMenuItem
            // 
            this.obtenerTodosToolStripMenuItem.Name = "obtenerTodosToolStripMenuItem";
            this.obtenerTodosToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.obtenerTodosToolStripMenuItem.Text = "Obtener Todos";
            this.obtenerTodosToolStripMenuItem.Click += new System.EventHandler(this.obtenerTodosToolStripMenuItem_Click);
            // 
            // nuevoMeilToolStripMenuItem
            // 
            this.nuevoMeilToolStripMenuItem.Image = global::Trabajo_Final.Properties.Resources.icono_del_l_piz_y_del_cuaderno_7956808___1_;
            this.nuevoMeilToolStripMenuItem.Name = "nuevoMeilToolStripMenuItem";
            this.nuevoMeilToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.nuevoMeilToolStripMenuItem.Text = "Nuevo Email";
            this.nuevoMeilToolStripMenuItem.Click += new System.EventHandler(this.nuevoMeilToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Buscar";
            // 
            // gpNuevoMail
            // 
            this.gpNuevoMail.Controls.Add(this.botonCCO);
            this.gpNuevoMail.Controls.Add(this.botonCC);
            this.gpNuevoMail.Controls.Add(this.bAdjuntar);
            this.gpNuevoMail.Controls.Add(this.bGuardar);
            this.gpNuevoMail.Controls.Add(this.tbAsunto);
            this.gpNuevoMail.Controls.Add(this.bEnviar);
            this.gpNuevoMail.Controls.Add(this.label5);
            this.gpNuevoMail.Controls.Add(this.tbCuerpo);
            this.gpNuevoMail.Controls.Add(this.tbCC);
            this.gpNuevoMail.Controls.Add(this.tbCCO);
            this.gpNuevoMail.Controls.Add(this.tbAdjuntos);
            this.gpNuevoMail.Controls.Add(this.tbPara);
            this.gpNuevoMail.Controls.Add(this.label4);
            this.gpNuevoMail.Controls.Add(this.label1);
            this.gpNuevoMail.Location = new System.Drawing.Point(203, 78);
            this.gpNuevoMail.Name = "gpNuevoMail";
            this.gpNuevoMail.Size = new System.Drawing.Size(604, 371);
            this.gpNuevoMail.TabIndex = 5;
            this.gpNuevoMail.TabStop = false;
            this.gpNuevoMail.Text = "Nuevo Email";
            this.gpNuevoMail.Visible = false;
            // 
            // botonCCO
            // 
            this.botonCCO.Location = new System.Drawing.Point(72, 116);
            this.botonCCO.Name = "botonCCO";
            this.botonCCO.Size = new System.Drawing.Size(37, 23);
            this.botonCCO.TabIndex = 13;
            this.botonCCO.Text = "CCO";
            this.botonCCO.UseVisualStyleBackColor = true;
            this.botonCCO.Click += new System.EventHandler(this.botonCCO_Click);
            // 
            // botonCC
            // 
            this.botonCC.Location = new System.Drawing.Point(72, 84);
            this.botonCC.Name = "botonCC";
            this.botonCC.Size = new System.Drawing.Size(37, 23);
            this.botonCC.TabIndex = 12;
            this.botonCC.Text = "CC";
            this.botonCC.UseVisualStyleBackColor = true;
            this.botonCC.Click += new System.EventHandler(this.botonCC_Click);
            // 
            // bAdjuntar
            // 
            this.bAdjuntar.Image = global::Trabajo_Final.Properties.Resources.attach;
            this.bAdjuntar.Location = new System.Drawing.Point(425, 147);
            this.bAdjuntar.Name = "bAdjuntar";
            this.bAdjuntar.Size = new System.Drawing.Size(36, 24);
            this.bAdjuntar.TabIndex = 11;
            this.bAdjuntar.UseVisualStyleBackColor = true;
            this.bAdjuntar.Click += new System.EventHandler(this.bAdjuntar_Click);
            // 
            // bGuardar
            // 
            this.bGuardar.Image = global::Trabajo_Final.Properties.Resources.filesave;
            this.bGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bGuardar.Location = new System.Drawing.Point(174, 13);
            this.bGuardar.Name = "bGuardar";
            this.bGuardar.Size = new System.Drawing.Size(75, 31);
            this.bGuardar.TabIndex = 7;
            this.bGuardar.Text = "Guardar";
            this.bGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bGuardar.UseVisualStyleBackColor = true;
            // 
            // tbAsunto
            // 
            this.tbAsunto.Location = new System.Drawing.Point(124, 182);
            this.tbAsunto.Name = "tbAsunto";
            this.tbAsunto.Size = new System.Drawing.Size(337, 20);
            this.tbAsunto.TabIndex = 10;
            // 
            // bEnviar
            // 
            this.bEnviar.Image = global::Trabajo_Final.Properties.Resources.mail_send;
            this.bEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEnviar.Location = new System.Drawing.Point(75, 13);
            this.bEnviar.Name = "bEnviar";
            this.bEnviar.Size = new System.Drawing.Size(73, 31);
            this.bEnviar.TabIndex = 6;
            this.bEnviar.Text = "Enviar";
            this.bEnviar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Asunto";
            // 
            // tbCuerpo
            // 
            this.tbCuerpo.Location = new System.Drawing.Point(124, 217);
            this.tbCuerpo.Name = "tbCuerpo";
            this.tbCuerpo.Size = new System.Drawing.Size(337, 134);
            this.tbCuerpo.TabIndex = 8;
            this.tbCuerpo.Text = "";
            // 
            // tbCC
            // 
            this.tbCC.Location = new System.Drawing.Point(124, 86);
            this.tbCC.Name = "tbCC";
            this.tbCC.ReadOnly = true;
            this.tbCC.Size = new System.Drawing.Size(337, 20);
            this.tbCC.TabIndex = 7;
            // 
            // tbCCO
            // 
            this.tbCCO.Location = new System.Drawing.Point(124, 118);
            this.tbCCO.Name = "tbCCO";
            this.tbCCO.ReadOnly = true;
            this.tbCCO.Size = new System.Drawing.Size(337, 20);
            this.tbCCO.TabIndex = 6;
            // 
            // tbAdjuntos
            // 
            this.tbAdjuntos.Location = new System.Drawing.Point(124, 150);
            this.tbAdjuntos.Name = "tbAdjuntos";
            this.tbAdjuntos.Size = new System.Drawing.Size(295, 20);
            this.tbAdjuntos.TabIndex = 5;
            // 
            // tbPara
            // 
            this.tbPara.Location = new System.Drawing.Point(124, 54);
            this.tbPara.Name = "tbPara";
            this.tbPara.Size = new System.Drawing.Size(337, 20);
            this.tbPara.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Archivos Adjuntos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Para";
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.AllowUserToAddRows = false;
            this.dgvCuentas.AllowUserToDeleteRows = false;
            this.dgvCuentas.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.correo,
            this.asunto,
            this.fecha});
            this.dgvCuentas.Location = new System.Drawing.Point(3, 30);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.ReadOnly = true;
            this.dgvCuentas.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvCuentas.Size = new System.Drawing.Size(605, 341);
            this.dgvCuentas.TabIndex = 6;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // correo
            // 
            this.correo.HeaderText = "Correo";
            this.correo.Name = "correo";
            this.correo.ReadOnly = true;
            this.correo.Width = 180;
            // 
            // asunto
            // 
            this.asunto.HeaderText = "Asunto";
            this.asunto.Name = "asunto";
            this.asunto.ReadOnly = true;
            this.asunto.Width = 200;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 90;
            // 
            // panelCuentas
            // 
            this.panelCuentas.Controls.Add(this.dgvCuentas);
            this.panelCuentas.Controls.Add(this.textBox1);
            this.panelCuentas.Location = new System.Drawing.Point(741, 43);
            this.panelCuentas.Name = "panelCuentas";
            this.panelCuentas.Size = new System.Drawing.Size(824, 374);
            this.panelCuentas.TabIndex = 7;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 458);
            this.Controls.Add(this.tvCuentas);
            this.Controls.Add(this.panelCuentas);
            this.Controls.Add(this.gpNuevoMail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador de Correo";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.gpNuevoMail.ResumeLayout(false);
            this.gpNuevoMail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.panelCuentas.ResumeLayout(false);
            this.panelCuentas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cuentasToolStripMenuItem;
        private System.Windows.Forms.TreeView tvCuentas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem obtenerMailsToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem obtenerTodosToolStripMenuItem;
        private System.Windows.Forms.GroupBox gpNuevoMail;
        private System.Windows.Forms.TextBox tbAsunto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox tbCuerpo;
        private System.Windows.Forms.TextBox tbCC;
        private System.Windows.Forms.TextBox tbCCO;
        private System.Windows.Forms.TextBox tbAdjuntos;
        private System.Windows.Forms.TextBox tbPara;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bEnviar;
        private System.Windows.Forms.Button bGuardar;
        private System.Windows.Forms.Button bAdjuntar;
        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn asunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.ToolStripMenuItem nuevoMeilToolStripMenuItem;
        private System.Windows.Forms.Panel panelCuentas;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button botonCCO;
        private System.Windows.Forms.Button botonCC;
    }
}

