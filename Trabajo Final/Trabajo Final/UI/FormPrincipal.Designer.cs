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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Cuentas de Correo");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvCuentas = new System.Windows.Forms.TreeView();
            this.gbOpciones1 = new System.Windows.Forms.GroupBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.obtenerMailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obtenerTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoMeilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gpNuevoMail = new System.Windows.Forms.GroupBox();
            this.botonCCO = new System.Windows.Forms.Button();
            this.botonCC = new System.Windows.Forms.Button();
            this.bAdjuntar = new System.Windows.Forms.Button();
            this.tbAsunto = new System.Windows.Forms.TextBox();
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
            this.gbEnviarMail = new System.Windows.Forms.GroupBox();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoBorradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.gbOpciones1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.gpNuevoMail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.panelCuentas.SuspendLayout();
            this.gbEnviarMail.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentasToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(853, 24);
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
            this.tvCuentas.Location = new System.Drawing.Point(3, 3);
            this.tvCuentas.Name = "tvCuentas";
            treeNode1.Name = "Nodo0";
            treeNode1.Text = "Cuentas de Correo";
            this.tvCuentas.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvCuentas.Size = new System.Drawing.Size(185, 378);
            this.tvCuentas.TabIndex = 1;
            // 
            // gbOpciones1
            // 
            this.gbOpciones1.Controls.Add(this.menuStrip2);
            this.gbOpciones1.Location = new System.Drawing.Point(0, 27);
            this.gbOpciones1.Name = "gbOpciones1";
            this.gbOpciones1.Size = new System.Drawing.Size(845, 45);
            this.gbOpciones1.TabIndex = 2;
            this.gbOpciones1.TabStop = false;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obtenerMailsToolStripMenuItem,
            this.obtenerTodosToolStripMenuItem,
            this.nuevoMeilToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(3, 16);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(839, 24);
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
            this.textBox1.Location = new System.Drawing.Point(194, 7);
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
            this.gpNuevoMail.Controls.Add(this.tbAsunto);
            this.gpNuevoMail.Controls.Add(this.label5);
            this.gpNuevoMail.Controls.Add(this.tbCuerpo);
            this.gpNuevoMail.Controls.Add(this.tbCC);
            this.gpNuevoMail.Controls.Add(this.tbCCO);
            this.gpNuevoMail.Controls.Add(this.tbAdjuntos);
            this.gpNuevoMail.Controls.Add(this.tbPara);
            this.gpNuevoMail.Controls.Add(this.label4);
            this.gpNuevoMail.Controls.Add(this.label1);
            this.gpNuevoMail.Location = new System.Drawing.Point(0, 78);
            this.gpNuevoMail.Name = "gpNuevoMail";
            this.gpNuevoMail.Size = new System.Drawing.Size(845, 382);
            this.gpNuevoMail.TabIndex = 5;
            this.gpNuevoMail.TabStop = false;
            this.gpNuevoMail.Text = "Nuevo Email";
            this.gpNuevoMail.Visible = false;
            // 
            // botonCCO
            // 
            this.botonCCO.Location = new System.Drawing.Point(61, 135);
            this.botonCCO.Name = "botonCCO";
            this.botonCCO.Size = new System.Drawing.Size(37, 23);
            this.botonCCO.TabIndex = 13;
            this.botonCCO.Text = "CCO";
            this.botonCCO.UseVisualStyleBackColor = true;
            this.botonCCO.Click += new System.EventHandler(this.botonCCO_Click);
            // 
            // botonCC
            // 
            this.botonCC.Location = new System.Drawing.Point(61, 76);
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
            this.bAdjuntar.Location = new System.Drawing.Point(397, 238);
            this.bAdjuntar.Name = "bAdjuntar";
            this.bAdjuntar.Size = new System.Drawing.Size(36, 24);
            this.bAdjuntar.TabIndex = 11;
            this.bAdjuntar.UseVisualStyleBackColor = true;
            this.bAdjuntar.Click += new System.EventHandler(this.botonAdjuntar_Click);
            // 
            // tbAsunto
            // 
            this.tbAsunto.Location = new System.Drawing.Point(104, 191);
            this.tbAsunto.Name = "tbAsunto";
            this.tbAsunto.Size = new System.Drawing.Size(329, 20);
            this.tbAsunto.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Asunto";
            // 
            // tbCuerpo
            // 
            this.tbCuerpo.Location = new System.Drawing.Point(442, 24);
            this.tbCuerpo.Name = "tbCuerpo";
            this.tbCuerpo.Size = new System.Drawing.Size(397, 341);
            this.tbCuerpo.TabIndex = 8;
            this.tbCuerpo.Text = "";
            // 
            // tbCC
            // 
            this.tbCC.Location = new System.Drawing.Point(104, 78);
            this.tbCC.Name = "tbCC";
            this.tbCC.ReadOnly = true;
            this.tbCC.Size = new System.Drawing.Size(329, 20);
            this.tbCC.TabIndex = 7;
            // 
            // tbCCO
            // 
            this.tbCCO.Location = new System.Drawing.Point(104, 137);
            this.tbCCO.Name = "tbCCO";
            this.tbCCO.ReadOnly = true;
            this.tbCCO.Size = new System.Drawing.Size(329, 20);
            this.tbCCO.TabIndex = 6;
            // 
            // tbAdjuntos
            // 
            this.tbAdjuntos.Location = new System.Drawing.Point(104, 241);
            this.tbAdjuntos.Name = "tbAdjuntos";
            this.tbAdjuntos.ReadOnly = true;
            this.tbAdjuntos.Size = new System.Drawing.Size(287, 20);
            this.tbAdjuntos.TabIndex = 5;
            // 
            // tbPara
            // 
            this.tbPara.Location = new System.Drawing.Point(104, 24);
            this.tbPara.Name = "tbPara";
            this.tbPara.Size = new System.Drawing.Size(329, 20);
            this.tbPara.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Archivos Adjuntos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 27);
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
            this.dgvCuentas.Location = new System.Drawing.Point(194, 33);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.ReadOnly = true;
            this.dgvCuentas.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvCuentas.Size = new System.Drawing.Size(648, 348);
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
            this.asunto.Width = 250;
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
            this.panelCuentas.Controls.Add(this.tvCuentas);
            this.panelCuentas.Controls.Add(this.textBox1);
            this.panelCuentas.Location = new System.Drawing.Point(0, 78);
            this.panelCuentas.Name = "panelCuentas";
            this.panelCuentas.Size = new System.Drawing.Size(845, 384);
            this.panelCuentas.TabIndex = 7;
            // 
            // gbEnviarMail
            // 
            this.gbEnviarMail.Controls.Add(this.menuStrip3);
            this.gbEnviarMail.Location = new System.Drawing.Point(0, 27);
            this.gbEnviarMail.Name = "gbEnviarMail";
            this.gbEnviarMail.Size = new System.Drawing.Size(845, 45);
            this.gbEnviarMail.TabIndex = 8;
            this.gbEnviarMail.TabStop = false;
            this.gbEnviarMail.Visible = false;
            // 
            // menuStrip3
            // 
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.guardarComoBorradorToolStripMenuItem});
            this.menuStrip3.Location = new System.Drawing.Point(3, 16);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(839, 24);
            this.menuStrip3.TabIndex = 0;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 20);
            this.toolStripMenuItem1.Text = "Administrador de Correo";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuAdministrarCorreo_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::Trabajo_Final.Properties.Resources.mail_send;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(67, 20);
            this.toolStripMenuItem2.Text = "Enviar";
            // 
            // guardarComoBorradorToolStripMenuItem
            // 
            this.guardarComoBorradorToolStripMenuItem.Image = global::Trabajo_Final.Properties.Resources.filesave;
            this.guardarComoBorradorToolStripMenuItem.Name = "guardarComoBorradorToolStripMenuItem";
            this.guardarComoBorradorToolStripMenuItem.Size = new System.Drawing.Size(160, 20);
            this.guardarComoBorradorToolStripMenuItem.Text = "Guardar como borrador";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 462);
            this.Controls.Add(this.gbOpciones1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelCuentas);
            this.Controls.Add(this.gbEnviarMail);
            this.Controls.Add(this.gpNuevoMail);
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
            this.gbOpciones1.ResumeLayout(false);
            this.gbOpciones1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.gpNuevoMail.ResumeLayout(false);
            this.gpNuevoMail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.panelCuentas.ResumeLayout(false);
            this.panelCuentas.PerformLayout();
            this.gbEnviarMail.ResumeLayout(false);
            this.gbEnviarMail.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cuentasToolStripMenuItem;
        private System.Windows.Forms.TreeView tvCuentas;
        private System.Windows.Forms.GroupBox gbOpciones1;
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
        private System.Windows.Forms.Button bAdjuntar;
        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoMeilToolStripMenuItem;
        private System.Windows.Forms.Panel panelCuentas;
        private System.Windows.Forms.Button botonCCO;
        private System.Windows.Forms.Button botonCC;
        private System.Windows.Forms.GroupBox gbEnviarMail;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem guardarComoBorradorToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn asunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
    }
}

