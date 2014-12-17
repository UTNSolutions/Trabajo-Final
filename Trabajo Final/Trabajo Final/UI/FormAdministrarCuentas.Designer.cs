namespace Trabajo_Final.UI
{
    partial class FormAdministrarCuentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgCuentas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCuenta = new System.Windows.Forms.TextBox();
            this.tbContraseña = new System.Windows.Forms.TextBox();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.cbServicio = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelMailError = new System.Windows.Forms.Label();
            this.bEliminar = new System.Windows.Forms.Button();
            this.bModificar = new System.Windows.Forms.Button();
            this.bAgregar = new System.Windows.Forms.Button();
            this.tbIdCuenta = new System.Windows.Forms.TextBox();
            this.idCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirectorioDeAdjuntos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contraseña = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgCuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCuentas
            // 
            this.dgCuentas.AllowUserToAddRows = false;
            this.dgCuentas.AllowUserToDeleteRows = false;
            this.dgCuentas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCuenta,
            this.DirectorioDeAdjuntos,
            this.nombre,
            this.direccion,
            this.servicio,
            this.contraseña});
            this.dgCuentas.Location = new System.Drawing.Point(12, 12);
            this.dgCuentas.Name = "dgCuentas";
            this.dgCuentas.ReadOnly = true;
            this.dgCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCuentas.Size = new System.Drawing.Size(308, 250);
            this.dgCuentas.TabIndex = 0;
            this.dgCuentas.TabStop = false;
            this.dgCuentas.Click += new System.EventHandler(this.MostrarDatos);
            this.dgCuentas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MostrarDatos);
            this.dgCuentas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MostrarDatos);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre Cuenta*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "E-Mail*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Servicio*";
            // 
            // tbCuenta
            // 
            this.tbCuenta.Location = new System.Drawing.Point(413, 12);
            this.tbCuenta.Name = "tbCuenta";
            this.tbCuenta.Size = new System.Drawing.Size(180, 20);
            this.tbCuenta.TabIndex = 1;
            // 
            // tbContraseña
            // 
            this.tbContraseña.Location = new System.Drawing.Point(413, 163);
            this.tbContraseña.Name = "tbContraseña";
            this.tbContraseña.Size = new System.Drawing.Size(180, 20);
            this.tbContraseña.TabIndex = 4;
            this.tbContraseña.UseSystemPasswordChar = true;
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(413, 113);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(180, 20);
            this.tbMail.TabIndex = 3;
            // 
            // cbServicio
            // 
            this.cbServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbServicio.FormattingEnabled = true;
            this.cbServicio.Items.AddRange(new object[] {
            "Gmail",
            "Yahoo"});
            this.cbServicio.Location = new System.Drawing.Point(413, 62);
            this.cbServicio.Name = "cbServicio";
            this.cbServicio.Size = new System.Drawing.Size(122, 21);
            this.cbServicio.TabIndex = 2;
            this.cbServicio.SelectedIndexChanged += new System.EventHandler(this.cbServicio_TabIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(548, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "(*) Datos Obligatorios";
            // 
            // labelMailError
            // 
            this.labelMailError.AutoSize = true;
            this.labelMailError.ForeColor = System.Drawing.Color.Red;
            this.labelMailError.Location = new System.Drawing.Point(417, 136);
            this.labelMailError.Name = "labelMailError";
            this.labelMailError.Size = new System.Drawing.Size(153, 13);
            this.labelMailError.TabIndex = 11;
            this.labelMailError.Text = "Email con estructura incorrecta";
            this.labelMailError.Visible = false;
            // 
            // bEliminar
            // 
            this.bEliminar.Enabled = false;
            this.bEliminar.Image = global::Trabajo_Final.Properties.Resources.editdelete;
            this.bEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEliminar.Location = new System.Drawing.Point(575, 239);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(75, 23);
            this.bEliminar.TabIndex = 7;
            this.bEliminar.Text = "Eliminar  ";
            this.bEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bEliminar.UseVisualStyleBackColor = true;
            this.bEliminar.Click += new System.EventHandler(this.EliminarCuenta);
            // 
            // bModificar
            // 
            this.bModificar.Enabled = false;
            this.bModificar.Image = global::Trabajo_Final.Properties.Resources.edit;
            this.bModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bModificar.Location = new System.Drawing.Point(470, 239);
            this.bModificar.Name = "bModificar";
            this.bModificar.Size = new System.Drawing.Size(75, 23);
            this.bModificar.TabIndex = 6;
            this.bModificar.Text = "Modificar";
            this.bModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bModificar.UseVisualStyleBackColor = true;
            this.bModificar.Click += new System.EventHandler(this.ModificarCuenta);
            // 
            // bAgregar
            // 
            this.bAgregar.Image = global::Trabajo_Final.Properties.Resources.apply;
            this.bAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAgregar.Location = new System.Drawing.Point(361, 239);
            this.bAgregar.Name = "bAgregar";
            this.bAgregar.Size = new System.Drawing.Size(75, 23);
            this.bAgregar.TabIndex = 5;
            this.bAgregar.Text = "Agregar  ";
            this.bAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bAgregar.UseVisualStyleBackColor = true;
            this.bAgregar.Click += new System.EventHandler(this.AltaCuenta);
            // 
            // tbIdCuenta
            // 
            this.tbIdCuenta.Location = new System.Drawing.Point(557, 12);
            this.tbIdCuenta.Name = "tbIdCuenta";
            this.tbIdCuenta.ReadOnly = true;
            this.tbIdCuenta.Size = new System.Drawing.Size(36, 20);
            this.tbIdCuenta.TabIndex = 12;
            this.tbIdCuenta.TabStop = false;
            this.tbIdCuenta.Visible = false;
            // 
            // idCuenta
            // 
            this.idCuenta.DataPropertyName = "IdCuenta";
            this.idCuenta.HeaderText = "idCuenta";
            this.idCuenta.Name = "idCuenta";
            this.idCuenta.ReadOnly = true;
            this.idCuenta.Visible = false;
            // 
            // DirectorioDeAdjuntos
            // 
            this.DirectorioDeAdjuntos.DataPropertyName = "DirectorioDeAdjuntos";
            this.DirectorioDeAdjuntos.HeaderText = "DirectorioDeAdjuntos";
            this.DirectorioDeAdjuntos.Name = "DirectorioDeAdjuntos";
            this.DirectorioDeAdjuntos.ReadOnly = true;
            this.DirectorioDeAdjuntos.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "Nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 105;
            // 
            // direccion
            // 
            this.direccion.DataPropertyName = "Direccion";
            this.direccion.HeaderText = "Direccion";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            this.direccion.Width = 160;
            // 
            // servicio
            // 
            this.servicio.DataPropertyName = "NombreServicio";
            this.servicio.HeaderText = "Servicio";
            this.servicio.Name = "servicio";
            this.servicio.ReadOnly = true;
            this.servicio.Visible = false;
            // 
            // contraseña
            // 
            this.contraseña.DataPropertyName = "Contraseña";
            this.contraseña.HeaderText = "Contraseña";
            this.contraseña.Name = "contraseña";
            this.contraseña.ReadOnly = true;
            this.contraseña.Visible = false;
            // 
            // FormAdministrarCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 280);
            this.Controls.Add(this.labelMailError);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bEliminar);
            this.Controls.Add(this.bModificar);
            this.Controls.Add(this.bAgregar);
            this.Controls.Add(this.cbServicio);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.tbContraseña);
            this.Controls.Add(this.tbCuenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgCuentas);
            this.Controls.Add(this.tbIdCuenta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAdministrarCuentas";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar cuentas";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAdministrarCuentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCuentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCuentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCuenta;
        private System.Windows.Forms.TextBox tbContraseña;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.ComboBox cbServicio;
        private System.Windows.Forms.Button bAgregar;
        private System.Windows.Forms.Button bModificar;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelMailError;
        private System.Windows.Forms.TextBox tbIdCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirectorioDeAdjuntos;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn contraseña;
    }
}