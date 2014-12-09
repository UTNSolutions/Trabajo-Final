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
            this.idCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contraseña = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCuenta = new System.Windows.Forms.TextBox();
            this.tbContraseña = new System.Windows.Forms.TextBox();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.cbServicio = new System.Windows.Forms.ComboBox();
            this.chbContraseña = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelMailError = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbIdCuenta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgCuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCuentas
            // 
            this.dgCuentas.AllowUserToAddRows = false;
            this.dgCuentas.AllowUserToDeleteRows = false;
            this.dgCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCuenta,
            this.nombre,
            this.direccion,
            this.servicio,
            this.contraseña});
            this.dgCuentas.Location = new System.Drawing.Point(12, 12);
            this.dgCuentas.Name = "dgCuentas";
            this.dgCuentas.ReadOnly = true;
            this.dgCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCuentas.Size = new System.Drawing.Size(308, 279);
            this.dgCuentas.TabIndex = 0;
            this.dgCuentas.TabStop = false;
            this.dgCuentas.Click += new System.EventHandler(this.MostrarDatos);
            this.dgCuentas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MostrarDatos);
            this.dgCuentas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MostrarDatos);
            // 
            // idCuenta
            // 
            this.idCuenta.DataPropertyName = "IdCuenta";
            this.idCuenta.HeaderText = "idCuenta";
            this.idCuenta.Name = "idCuenta";
            this.idCuenta.ReadOnly = true;
            this.idCuenta.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "Nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre Cuenta*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mail*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Servicio*";
            // 
            // tbCuenta
            // 
            this.tbCuenta.Location = new System.Drawing.Point(413, 27);
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
            this.tbMail.Location = new System.Drawing.Point(413, 118);
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
            this.cbServicio.Location = new System.Drawing.Point(413, 72);
            this.cbServicio.Name = "cbServicio";
            this.cbServicio.Size = new System.Drawing.Size(122, 21);
            this.cbServicio.TabIndex = 2;
            // 
            // chbContraseña
            // 
            this.chbContraseña.AutoSize = true;
            this.chbContraseña.Location = new System.Drawing.Point(413, 189);
            this.chbContraseña.Name = "chbContraseña";
            this.chbContraseña.Size = new System.Drawing.Size(117, 17);
            this.chbContraseña.TabIndex = 9;
            this.chbContraseña.TabStop = false;
            this.chbContraseña.Text = "Mostrar contraseña";
            this.chbContraseña.UseVisualStyleBackColor = true;
            this.chbContraseña.CheckedChanged += new System.EventHandler(this.MostrarContraseña);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(558, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "(*) Datos Obligatorios";
            // 
            // labelMailError
            // 
            this.labelMailError.AutoSize = true;
            this.labelMailError.ForeColor = System.Drawing.Color.Red;
            this.labelMailError.Location = new System.Drawing.Point(413, 144);
            this.labelMailError.Name = "labelMailError";
            this.labelMailError.Size = new System.Drawing.Size(157, 13);
            this.labelMailError.TabIndex = 11;
            this.labelMailError.Text = "E-Mail con estructura incorrecta";
            this.labelMailError.Visible = false;
            // 
            // button3
            // 
            this.button3.Image = global::Trabajo_Final.Properties.Resources.editdelete;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(579, 250);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Eliminar  ";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.EliminarCuenta);
            // 
            // button2
            // 
            this.button2.Image = global::Trabajo_Final.Properties.Resources.edit;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(474, 250);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Modificar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ModificarCuenta);
            // 
            // button1
            // 
            this.button1.Image = global::Trabajo_Final.Properties.Resources.apply;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(369, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Agregar  ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AltaCuenta);
            // 
            // tbIdCuenta
            // 
            this.tbIdCuenta.Location = new System.Drawing.Point(618, 30);
            this.tbIdCuenta.Name = "tbIdCuenta";
            this.tbIdCuenta.ReadOnly = true;
            this.tbIdCuenta.Size = new System.Drawing.Size(36, 20);
            this.tbIdCuenta.TabIndex = 12;
            this.tbIdCuenta.TabStop = false;
            // 
            // FormAdministrarCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 309);
            this.Controls.Add(this.tbIdCuenta);
            this.Controls.Add(this.labelMailError);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chbContraseña);
            this.Controls.Add(this.cbServicio);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.tbContraseña);
            this.Controls.Add(this.tbCuenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgCuentas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAdministrarCuentas";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar cuentas";
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
        private System.Windows.Forms.CheckBox chbContraseña;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelMailError;
        private System.Windows.Forms.TextBox tbIdCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn contraseña;
    }
}