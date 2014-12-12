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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.tvCuentas = new System.Windows.Forms.TreeView();
            this.gbOpciones1 = new System.Windows.Forms.GroupBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.obtenerMailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obtenerTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.redactarMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelLeerMail = new System.Windows.Forms.Panel();
            this.tbFechaLeerMail = new System.Windows.Forms.TextBox();
            this.tbCuerpoLeerMail = new System.Windows.Forms.TextBox();
            this.tbParaLeerMail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDeLeerMail = new System.Windows.Forms.TextBox();
            this.tbAsuntoLeerMail = new System.Windows.Forms.TextBox();
            this.gbEnviarMail = new System.Windows.Forms.GroupBox();
            this.lEnviado = new System.Windows.Forms.Label();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.administradorDeCuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bEnviar = new System.Windows.Forms.ToolStripMenuItem();
            this.bGuardarBorrador = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.gbLeerMail = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sadqadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.responderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.gbOpciones1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.gpNuevoMail.SuspendLayout();
            this.panelCuentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmails)).BeginInit();
            this.panelLeerMail.SuspendLayout();
            this.gbEnviarMail.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.gbLeerMail.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvCuentas
            // 
            this.tvCuentas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tvCuentas.Location = new System.Drawing.Point(3, 6);
            this.tvCuentas.Name = "tvCuentas";
            this.tvCuentas.Size = new System.Drawing.Size(185, 437);
            this.tvCuentas.TabIndex = 1;
            this.tvCuentas.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.MostrarDatosDelNodo);
            // 
            // gbOpciones1
            // 
            this.gbOpciones1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gbOpciones1.Controls.Add(this.menuStrip2);
            this.gbOpciones1.Location = new System.Drawing.Point(0, 2);
            this.gbOpciones1.Name = "gbOpciones1";
            this.gbOpciones1.Size = new System.Drawing.Size(853, 45);
            this.gbOpciones1.TabIndex = 2;
            this.gbOpciones1.TabStop = false;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obtenerMailsToolStripMenuItem,
            this.obtenerTodosToolStripMenuItem,
            this.cuentasToolStripMenuItem1,
            this.redactarMailToolStripMenuItem,
            this.acercaDeToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(3, 16);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(847, 27);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // obtenerMailsToolStripMenuItem
            // 
            this.obtenerMailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.obtenerMailsToolStripMenuItem.Image = global::Trabajo_Final.Properties.Resources.icono_email111;
            this.obtenerMailsToolStripMenuItem.Name = "obtenerMailsToolStripMenuItem";
            this.obtenerMailsToolStripMenuItem.Size = new System.Drawing.Size(88, 23);
            this.obtenerMailsToolStripMenuItem.Text = "Obtener";
            this.obtenerMailsToolStripMenuItem.Click += new System.EventHandler(this.obtenerMailsToolStripMenuItem_Click);
            // 
            // obtenerTodosToolStripMenuItem
            // 
            this.obtenerTodosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.obtenerTodosToolStripMenuItem.Name = "obtenerTodosToolStripMenuItem";
            this.obtenerTodosToolStripMenuItem.Size = new System.Drawing.Size(113, 23);
            this.obtenerTodosToolStripMenuItem.Text = "Obtener Todos";
            this.obtenerTodosToolStripMenuItem.Click += new System.EventHandler(this.obtenerTodosToolStripMenuItem_Click);
            // 
            // cuentasToolStripMenuItem1
            // 
            this.cuentasToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cuentasToolStripMenuItem1.Image = global::Trabajo_Final.Properties.Resources.Administrar;
            this.cuentasToolStripMenuItem1.Name = "cuentasToolStripMenuItem1";
            this.cuentasToolStripMenuItem1.Size = new System.Drawing.Size(87, 23);
            this.cuentasToolStripMenuItem1.Text = "Cuentas";
            this.cuentasToolStripMenuItem1.Click += new System.EventHandler(this.cuentasToolStripMenuItem_Click);
            // 
            // redactarMailToolStripMenuItem
            // 
            this.redactarMailToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.redactarMailToolStripMenuItem.Image = global::Trabajo_Final.Properties.Resources.icono_del_l_piz_y_del_cuaderno_7956808___1_;
            this.redactarMailToolStripMenuItem.Name = "redactarMailToolStripMenuItem";
            this.redactarMailToolStripMenuItem.Size = new System.Drawing.Size(126, 23);
            this.redactarMailToolStripMenuItem.Text = "Redactar Email";
            this.redactarMailToolStripMenuItem.Click += new System.EventHandler(this.redactarEmailToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem1
            // 
            this.acercaDeToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.acercaDeToolStripMenuItem1.Image = global::Trabajo_Final.Properties.Resources.Help;
            this.acercaDeToolStripMenuItem1.Name = "acercaDeToolStripMenuItem1";
            this.acercaDeToolStripMenuItem1.Size = new System.Drawing.Size(105, 23);
            this.acercaDeToolStripMenuItem1.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem1.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
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
            this.gpNuevoMail.Location = new System.Drawing.Point(0, 49);
            this.gpNuevoMail.Name = "gpNuevoMail";
            this.gpNuevoMail.Size = new System.Drawing.Size(853, 429);
            this.gpNuevoMail.TabIndex = 5;
            this.gpNuevoMail.TabStop = false;
            this.gpNuevoMail.Text = "Nuevo Email";
            this.gpNuevoMail.Visible = false;
            // 
            // combobDe
            // 
            this.combobDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.tbCuerpo.Size = new System.Drawing.Size(397, 393);
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
            this.panelCuentas.Controls.Add(this.label7);
            this.panelCuentas.Controls.Add(this.progressBar);
            this.panelCuentas.Controls.Add(this.tvCuentas);
            this.panelCuentas.Controls.Add(this.tbTipoCorreo);
            this.panelCuentas.Controls.Add(this.tbNombreCuenta);
            this.panelCuentas.Controls.Add(this.textBox1);
            this.panelCuentas.Controls.Add(this.dgEmails);
            this.panelCuentas.Location = new System.Drawing.Point(0, 49);
            this.panelCuentas.Name = "panelCuentas";
            this.panelCuentas.Size = new System.Drawing.Size(853, 432);
            this.panelCuentas.TabIndex = 7;
            // 
            // tbTipoCorreo
            // 
            this.tbTipoCorreo.Location = new System.Drawing.Point(487, 7);
            this.tbTipoCorreo.Name = "tbTipoCorreo";
            this.tbTipoCorreo.ReadOnly = true;
            this.tbTipoCorreo.Size = new System.Drawing.Size(77, 20);
            this.tbTipoCorreo.TabIndex = 8;
            this.tbTipoCorreo.Text = " ";
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
            this.dgEmails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.remitente,
            this.cuerpo,
            this.destinatario,
            this.asunto,
            this.fecha});
            this.dgEmails.Location = new System.Drawing.Point(194, 33);
            this.dgEmails.Name = "dgEmails";
            this.dgEmails.ReadOnly = true;
            this.dgEmails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEmails.Size = new System.Drawing.Size(653, 407);
            this.dgEmails.TabIndex = 6;
            this.dgEmails.DoubleClick += new System.EventHandler(this.LeerMail);
            // 
            // remitente
            // 
            this.remitente.DataPropertyName = "Remitente";
            this.remitente.HeaderText = "Remitente";
            this.remitente.Name = "remitente";
            this.remitente.ReadOnly = true;
            this.remitente.Width = 250;
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
            this.destinatario.Width = 250;
            // 
            // asunto
            // 
            this.asunto.DataPropertyName = "Asunto";
            this.asunto.HeaderText = "Asunto";
            this.asunto.Name = "asunto";
            this.asunto.ReadOnly = true;
            this.asunto.Width = 250;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "Fecha";
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // panelLeerMail
            // 
            this.panelLeerMail.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelLeerMail.Controls.Add(this.tbFechaLeerMail);
            this.panelLeerMail.Controls.Add(this.tbCuerpoLeerMail);
            this.panelLeerMail.Controls.Add(this.tbParaLeerMail);
            this.panelLeerMail.Controls.Add(this.label6);
            this.panelLeerMail.Controls.Add(this.label3);
            this.panelLeerMail.Controls.Add(this.tbDeLeerMail);
            this.panelLeerMail.Controls.Add(this.tbAsuntoLeerMail);
            this.panelLeerMail.Location = new System.Drawing.Point(0, 49);
            this.panelLeerMail.Name = "panelLeerMail";
            this.panelLeerMail.Size = new System.Drawing.Size(853, 429);
            this.panelLeerMail.TabIndex = 17;
            this.panelLeerMail.Visible = false;
            // 
            // tbFechaLeerMail
            // 
            this.tbFechaLeerMail.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbFechaLeerMail.Location = new System.Drawing.Point(741, 4);
            this.tbFechaLeerMail.Multiline = true;
            this.tbFechaLeerMail.Name = "tbFechaLeerMail";
            this.tbFechaLeerMail.ReadOnly = true;
            this.tbFechaLeerMail.Size = new System.Drawing.Size(106, 31);
            this.tbFechaLeerMail.TabIndex = 7;
            // 
            // tbCuerpoLeerMail
            // 
            this.tbCuerpoLeerMail.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbCuerpoLeerMail.Location = new System.Drawing.Point(6, 109);
            this.tbCuerpoLeerMail.Multiline = true;
            this.tbCuerpoLeerMail.Name = "tbCuerpoLeerMail";
            this.tbCuerpoLeerMail.ReadOnly = true;
            this.tbCuerpoLeerMail.Size = new System.Drawing.Size(841, 314);
            this.tbCuerpoLeerMail.TabIndex = 6;
            // 
            // tbParaLeerMail
            // 
            this.tbParaLeerMail.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbParaLeerMail.Location = new System.Drawing.Point(98, 77);
            this.tbParaLeerMail.Name = "tbParaLeerMail";
            this.tbParaLeerMail.ReadOnly = true;
            this.tbParaLeerMail.Size = new System.Drawing.Size(749, 20);
            this.tbParaLeerMail.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "          Para:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "            De:";
            // 
            // tbDeLeerMail
            // 
            this.tbDeLeerMail.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbDeLeerMail.Location = new System.Drawing.Point(98, 46);
            this.tbDeLeerMail.Name = "tbDeLeerMail";
            this.tbDeLeerMail.ReadOnly = true;
            this.tbDeLeerMail.Size = new System.Drawing.Size(749, 20);
            this.tbDeLeerMail.TabIndex = 2;
            // 
            // tbAsuntoLeerMail
            // 
            this.tbAsuntoLeerMail.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbAsuntoLeerMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAsuntoLeerMail.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbAsuntoLeerMail.Location = new System.Drawing.Point(8, 4);
            this.tbAsuntoLeerMail.Name = "tbAsuntoLeerMail";
            this.tbAsuntoLeerMail.ReadOnly = true;
            this.tbAsuntoLeerMail.Size = new System.Drawing.Size(728, 31);
            this.tbAsuntoLeerMail.TabIndex = 0;
            this.tbAsuntoLeerMail.Text = "Sin Asunto...";
            // 
            // gbEnviarMail
            // 
            this.gbEnviarMail.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gbEnviarMail.Controls.Add(this.lEnviado);
            this.gbEnviarMail.Controls.Add(this.menuStrip3);
            this.gbEnviarMail.Location = new System.Drawing.Point(0, 2);
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
            this.menuStrip3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administradorDeCuentasToolStripMenuItem,
            this.bEnviar,
            this.bGuardarBorrador,
            this.acercaDeToolStripMenuItem2});
            this.menuStrip3.Location = new System.Drawing.Point(3, 16);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(847, 27);
            this.menuStrip3.TabIndex = 0;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // administradorDeCuentasToolStripMenuItem
            // 
            this.administradorDeCuentasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.administradorDeCuentasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("administradorDeCuentasToolStripMenuItem.Image")));
            this.administradorDeCuentasToolStripMenuItem.Name = "administradorDeCuentasToolStripMenuItem";
            this.administradorDeCuentasToolStripMenuItem.Size = new System.Drawing.Size(28, 23);
            this.administradorDeCuentasToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuAdministrarCorreo_Click);
            // 
            // bEnviar
            // 
            this.bEnviar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.bEnviar.Image = global::Trabajo_Final.Properties.Resources.mail_send;
            this.bEnviar.Name = "bEnviar";
            this.bEnviar.Size = new System.Drawing.Size(74, 23);
            this.bEnviar.Text = "Enviar";
            this.bEnviar.Click += new System.EventHandler(this.toolStripMenubEnviar_Click);
            // 
            // bGuardarBorrador
            // 
            this.bGuardarBorrador.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.bGuardarBorrador.Image = global::Trabajo_Final.Properties.Resources.filesave;
            this.bGuardarBorrador.Name = "bGuardarBorrador";
            this.bGuardarBorrador.Size = new System.Drawing.Size(183, 23);
            this.bGuardarBorrador.Text = "Guardar como borrador";
            this.bGuardarBorrador.Click += new System.EventHandler(this.guardarComoBorradorToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem2
            // 
            this.acercaDeToolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.acercaDeToolStripMenuItem2.Image = global::Trabajo_Final.Properties.Resources.Help;
            this.acercaDeToolStripMenuItem2.Name = "acercaDeToolStripMenuItem2";
            this.acercaDeToolStripMenuItem2.Size = new System.Drawing.Size(105, 23);
            this.acercaDeToolStripMenuItem2.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem2.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // gbLeerMail
            // 
            this.gbLeerMail.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gbLeerMail.Controls.Add(this.menuStrip1);
            this.gbLeerMail.Location = new System.Drawing.Point(0, 2);
            this.gbLeerMail.Name = "gbLeerMail";
            this.gbLeerMail.Size = new System.Drawing.Size(853, 45);
            this.gbLeerMail.TabIndex = 16;
            this.gbLeerMail.TabStop = false;
            this.gbLeerMail.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sadqadToolStripMenuItem,
            this.responderToolStripMenuItem,
            this.exportarToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 16);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(847, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sadqadToolStripMenuItem
            // 
            this.sadqadToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.sadqadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sadqadToolStripMenuItem.Image")));
            this.sadqadToolStripMenuItem.Name = "sadqadToolStripMenuItem";
            this.sadqadToolStripMenuItem.Size = new System.Drawing.Size(28, 23);
            this.sadqadToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuAdministrarCorreo_Click);
            // 
            // responderToolStripMenuItem
            // 
            this.responderToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.responderToolStripMenuItem.Image = global::Trabajo_Final.Properties.Resources.icono_del_l_piz_y_del_cuaderno_7956808_1;
            this.responderToolStripMenuItem.Name = "responderToolStripMenuItem";
            this.responderToolStripMenuItem.Size = new System.Drawing.Size(102, 23);
            this.responderToolStripMenuItem.Text = "Responder";
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.exportarToolStripMenuItem.Image = global::Trabajo_Final.Properties.Resources.folder_icons_windows_7;
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(88, 23);
            this.exportarToolStripMenuItem.Text = "Exportar";
            this.exportarToolStripMenuItem.Click += new System.EventHandler(this.exportarToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.acercaDeToolStripMenuItem.Image = global::Trabajo_Final.Properties.Resources.Help;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(105, 23);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(42, 225);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Obtencion Completa";
            this.label7.Visible = false;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(851, 481);
            this.Controls.Add(this.gbEnviarMail);
            this.Controls.Add(this.gbLeerMail);
            this.Controls.Add(this.gbOpciones1);
            this.Controls.Add(this.panelCuentas);
            this.Controls.Add(this.gpNuevoMail);
            this.Controls.Add(this.panelLeerMail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador de Correo";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BorrarLabelEnviado);
            this.gbOpciones1.ResumeLayout(false);
            this.gbOpciones1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.gpNuevoMail.ResumeLayout(false);
            this.gpNuevoMail.PerformLayout();
            this.panelCuentas.ResumeLayout(false);
            this.panelCuentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmails)).EndInit();
            this.panelLeerMail.ResumeLayout(false);
            this.panelLeerMail.PerformLayout();
            this.gbEnviarMail.ResumeLayout(false);
            this.gbEnviarMail.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.gbLeerMail.ResumeLayout(false);
            this.gbLeerMail.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.ToolStripMenuItem redactarMailToolStripMenuItem;
        private System.Windows.Forms.Panel panelCuentas;
        private System.Windows.Forms.Button botonCCO;
        private System.Windows.Forms.Button botonCC;
        private System.Windows.Forms.GroupBox gbEnviarMail;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem bEnviar;
        private System.Windows.Forms.ToolStripMenuItem bGuardarBorrador;
        private System.Windows.Forms.ComboBox combobDe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNombreCuenta;
        private System.Windows.Forms.ProgressBar progressBarEnviando;
        private System.Windows.Forms.Label lEnviado;
        private System.Windows.Forms.DataGridView dgEmails;
        private System.Windows.Forms.TextBox tbTipoCorreo;
        private System.Windows.Forms.ToolStripMenuItem cuentasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem2;
        private System.Windows.Forms.GroupBox gbLeerMail;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem responderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.Panel panelLeerMail;
        private System.Windows.Forms.ToolStripMenuItem administradorDeCuentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sadqadToolStripMenuItem;
        private System.Windows.Forms.TextBox tbAsuntoLeerMail;
        private System.Windows.Forms.TextBox tbCuerpoLeerMail;
        private System.Windows.Forms.TextBox tbParaLeerMail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDeLeerMail;
        private System.Windows.Forms.TextBox tbFechaLeerMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn remitente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuerpo;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinatario;
        private System.Windows.Forms.DataGridViewTextBoxColumn asunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label7;
    }
}

