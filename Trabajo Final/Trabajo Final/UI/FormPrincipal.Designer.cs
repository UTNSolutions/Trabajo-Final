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
            this.combobDe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.progressBarEnviando = new System.Windows.Forms.ProgressBar();
            this.panelCuentas = new System.Windows.Forms.Panel();
            this.tbTipoCorreo = new System.Windows.Forms.TextBox();
            this.tbNombreCuenta = new System.Windows.Forms.TextBox();
            this.dgEmails = new System.Windows.Forms.DataGridView();
            this.remitente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuerpo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinatario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbEnviarMail = new System.Windows.Forms.GroupBox();
            this.lEnviado = new System.Windows.Forms.Label();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bEnviar = new System.Windows.Forms.ToolStripMenuItem();
            this.bGuardarBorrador = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.gbOpciones1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.gpNuevoMail.SuspendLayout();
            this.panelCuentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmails)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(854, 24);
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
            this.tvCuentas.Size = new System.Drawing.Size(185, 378);
            this.tvCuentas.TabIndex = 1;
            this.tvCuentas.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.MostrarDatosDelNodo);
            // 
            // gbOpciones1
            // 
            this.gbOpciones1.Controls.Add(this.menuStrip2);
            this.gbOpciones1.Location = new System.Drawing.Point(0, 27);
            this.gbOpciones1.Name = "gbOpciones1";
            this.gbOpciones1.Size = new System.Drawing.Size(853, 45);
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
            this.menuStrip2.Size = new System.Drawing.Size(847, 24);
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
            this.gpNuevoMail.Controls.Add(this.combobDe);
            this.gpNuevoMail.Controls.Add(this.label2);
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
            this.gpNuevoMail.Controls.Add(this.progressBarEnviando);
            this.gpNuevoMail.Location = new System.Drawing.Point(0, 78);
            this.gpNuevoMail.Name = "gpNuevoMail";
            this.gpNuevoMail.Size = new System.Drawing.Size(853, 400);
            this.gpNuevoMail.TabIndex = 5;
            this.gpNuevoMail.TabStop = false;
            this.gpNuevoMail.Text = "Nuevo Email";
            this.gpNuevoMail.Visible = false;
            // 
            // combobDe
            // 
            this.combobDe.FormattingEnabled = true;
            this.combobDe.Location = new System.Drawing.Point(103, 41);
            this.combobDe.Name = "combobDe";
            this.combobDe.Size = new System.Drawing.Size(329, 21);
            this.combobDe.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "De";
            // 
            // botonCCO
            // 
            this.botonCCO.Location = new System.Drawing.Point(60, 197);
            this.botonCCO.Name = "botonCCO";
            this.botonCCO.Size = new System.Drawing.Size(37, 23);
            this.botonCCO.TabIndex = 13;
            this.botonCCO.Text = "CCO";
            this.botonCCO.UseVisualStyleBackColor = true;
            this.botonCCO.Click += new System.EventHandler(this.botonCCO_Click);
            // 
            // botonCC
            // 
            this.botonCC.Location = new System.Drawing.Point(60, 138);
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
            this.bAdjuntar.Location = new System.Drawing.Point(396, 300);
            this.bAdjuntar.Name = "bAdjuntar";
            this.bAdjuntar.Size = new System.Drawing.Size(36, 24);
            this.bAdjuntar.TabIndex = 11;
            this.bAdjuntar.UseVisualStyleBackColor = true;
            this.bAdjuntar.Click += new System.EventHandler(this.botonAdjuntar_Click);
            // 
            // tbAsunto
            // 
            this.tbAsunto.Location = new System.Drawing.Point(103, 253);
            this.tbAsunto.Name = "tbAsunto";
            this.tbAsunto.Size = new System.Drawing.Size(329, 20);
            this.tbAsunto.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Asunto";
            // 
            // tbCuerpo
            // 
            this.tbCuerpo.Location = new System.Drawing.Point(441, 35);
            this.tbCuerpo.Name = "tbCuerpo";
            this.tbCuerpo.Size = new System.Drawing.Size(397, 341);
            this.tbCuerpo.TabIndex = 8;
            this.tbCuerpo.Text = "";
            // 
            // tbCC
            // 
            this.tbCC.Location = new System.Drawing.Point(103, 140);
            this.tbCC.Name = "tbCC";
            this.tbCC.ReadOnly = true;
            this.tbCC.Size = new System.Drawing.Size(329, 20);
            this.tbCC.TabIndex = 7;
            this.tbCC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCC_KeyPress);
            // 
            // tbCCO
            // 
            this.tbCCO.Location = new System.Drawing.Point(103, 199);
            this.tbCCO.Name = "tbCCO";
            this.tbCCO.ReadOnly = true;
            this.tbCCO.Size = new System.Drawing.Size(329, 20);
            this.tbCCO.TabIndex = 6;
            this.tbCCO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCCO_KeyPress);
            // 
            // tbAdjuntos
            // 
            this.tbAdjuntos.Location = new System.Drawing.Point(103, 303);
            this.tbAdjuntos.Name = "tbAdjuntos";
            this.tbAdjuntos.ReadOnly = true;
            this.tbAdjuntos.Size = new System.Drawing.Size(287, 20);
            this.tbAdjuntos.TabIndex = 5;
            // 
            // tbPara
            // 
            this.tbPara.Location = new System.Drawing.Point(103, 90);
            this.tbPara.Name = "tbPara";
            this.tbPara.Size = new System.Drawing.Size(329, 20);
            this.tbPara.TabIndex = 4;
            this.tbPara.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPara_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Archivos Adjuntos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Para";
            // 
            // progressBarEnviando
            // 
            this.progressBarEnviando.Location = new System.Drawing.Point(6, 17);
            this.progressBarEnviando.Name = "progressBarEnviando";
            this.progressBarEnviando.Size = new System.Drawing.Size(841, 12);
            this.progressBarEnviando.TabIndex = 9;
            this.progressBarEnviando.Visible = false;
            // 
            // panelCuentas
            // 
            this.panelCuentas.Controls.Add(this.tbTipoCorreo);
            this.panelCuentas.Controls.Add(this.tbNombreCuenta);
            this.panelCuentas.Controls.Add(this.tvCuentas);
            this.panelCuentas.Controls.Add(this.textBox1);
            this.panelCuentas.Controls.Add(this.dgEmails);
            this.panelCuentas.Location = new System.Drawing.Point(0, 78);
            this.panelCuentas.Name = "panelCuentas";
            this.panelCuentas.Size = new System.Drawing.Size(853, 400);
            this.panelCuentas.TabIndex = 7;
            // 
            // tbTipoCorreo
            // 
            this.tbTipoCorreo.Location = new System.Drawing.Point(487, 7);
            this.tbTipoCorreo.Name = "tbTipoCorreo";
            this.tbTipoCorreo.ReadOnly = true;
            this.tbTipoCorreo.Size = new System.Drawing.Size(77, 20);
            this.tbTipoCorreo.TabIndex = 8;
            // 
            // tbNombreCuenta
            // 
            this.tbNombreCuenta.Location = new System.Drawing.Point(397, 6);
            this.tbNombreCuenta.Name = "tbNombreCuenta";
            this.tbNombreCuenta.ReadOnly = true;
            this.tbNombreCuenta.Size = new System.Drawing.Size(59, 20);
            this.tbNombreCuenta.TabIndex = 7;
            // 
            // dgEmails
            // 
            this.dgEmails.AllowUserToAddRows = false;
            this.dgEmails.AllowUserToDeleteRows = false;
            this.dgEmails.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.remitente,
            this.cuerpo,
            this.destinatario,
            this.asunto});
            this.dgEmails.Location = new System.Drawing.Point(194, 33);
            this.dgEmails.Name = "dgEmails";
            this.dgEmails.ReadOnly = true;
            this.dgEmails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgEmails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEmails.Size = new System.Drawing.Size(648, 348);
            this.dgEmails.TabIndex = 6;
            // 
            // remitente
            // 
            this.remitente.DataPropertyName = "Remitente";
            this.remitente.HeaderText = "Remitente";
            this.remitente.Name = "remitente";
            this.remitente.ReadOnly = true;
            // 
            // cuerpo
            // 
            this.cuerpo.DataPropertyName = "Cuerpo";
            this.cuerpo.HeaderText = "Cuerpo";
            this.cuerpo.Name = "cuerpo";
            this.cuerpo.ReadOnly = true;
            this.cuerpo.Visible = false;
            // 
            // destinatario
            // 
            this.destinatario.DataPropertyName = "Destinatario";
            this.destinatario.HeaderText = "Destinatario";
            this.destinatario.Name = "destinatario";
            this.destinatario.ReadOnly = true;
            // 
            // asunto
            // 
            this.asunto.DataPropertyName = "Asunto";
            this.asunto.HeaderText = "Asunto";
            this.asunto.Name = "asunto";
            this.asunto.ReadOnly = true;
            // 
            // gbEnviarMail
            // 
            this.gbEnviarMail.Controls.Add(this.lEnviado);
            this.gbEnviarMail.Controls.Add(this.menuStrip3);
            this.gbEnviarMail.Location = new System.Drawing.Point(0, 27);
            this.gbEnviarMail.Name = "gbEnviarMail";
            this.gbEnviarMail.Size = new System.Drawing.Size(853, 45);
            this.gbEnviarMail.TabIndex = 8;
            this.gbEnviarMail.TabStop = false;
            this.gbEnviarMail.Visible = false;
            // 
            // lEnviado
            // 
            this.lEnviado.AutoSize = true;
            this.lEnviado.BackColor = System.Drawing.Color.LightGreen;
            this.lEnviado.ForeColor = System.Drawing.Color.Blue;
            this.lEnviado.Location = new System.Drawing.Point(786, 26);
            this.lEnviado.Name = "lEnviado";
            this.lEnviado.Size = new System.Drawing.Size(61, 13);
            this.lEnviado.TabIndex = 8;
            this.lEnviado.Text = "Enviado.    ";
            this.lEnviado.Visible = false;
            // 
            // menuStrip3
            // 
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.bEnviar,
            this.bGuardarBorrador});
            this.menuStrip3.Location = new System.Drawing.Point(3, 16);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(847, 24);
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
            // bEnviar
            // 
            this.bEnviar.Image = global::Trabajo_Final.Properties.Resources.mail_send;
            this.bEnviar.Name = "bEnviar";
            this.bEnviar.Size = new System.Drawing.Size(67, 20);
            this.bEnviar.Text = "Enviar";
            this.bEnviar.Click += new System.EventHandler(this.toolStripMenubEnviar_Click);
            // 
            // bGuardarBorrador
            // 
            this.bGuardarBorrador.Image = global::Trabajo_Final.Properties.Resources.filesave;
            this.bGuardarBorrador.Name = "bGuardarBorrador";
            this.bGuardarBorrador.Size = new System.Drawing.Size(160, 20);
            this.bGuardarBorrador.Text = "Guardar como borrador";
            this.bGuardarBorrador.Click += new System.EventHandler(this.guardarComoBorradorToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 478);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gbOpciones1);
            this.Controls.Add(this.gbEnviarMail);
            this.Controls.Add(this.panelCuentas);
            this.Controls.Add(this.gpNuevoMail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador de Correo";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BorrarLabelEnviado);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbOpciones1.ResumeLayout(false);
            this.gbOpciones1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.gpNuevoMail.ResumeLayout(false);
            this.gpNuevoMail.PerformLayout();
            this.panelCuentas.ResumeLayout(false);
            this.panelCuentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmails)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoMeilToolStripMenuItem;
        private System.Windows.Forms.Panel panelCuentas;
        private System.Windows.Forms.Button botonCCO;
        private System.Windows.Forms.Button botonCC;
        private System.Windows.Forms.GroupBox gbEnviarMail;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bEnviar;
        private System.Windows.Forms.ToolStripMenuItem bGuardarBorrador;
        private System.Windows.Forms.ComboBox combobDe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNombreCuenta;
        private System.Windows.Forms.ProgressBar progressBarEnviando;
        private System.Windows.Forms.Label lEnviado;
        private System.Windows.Forms.DataGridView dgEmails;
        private System.Windows.Forms.TextBox tbTipoCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn remitente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuerpo;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinatario;
        private System.Windows.Forms.DataGridViewTextBoxColumn asunto;
    }
}

