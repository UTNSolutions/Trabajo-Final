namespace Trabajo_Final.UI
{
    partial class FormExportar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExportar));
            this.cbTipoExportador = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRutaDirectorio = new System.Windows.Forms.TextBox();
            this.bBuscarDirectorio = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNombreArchivo = new System.Windows.Forms.TextBox();
            this.bAceptar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbTipoExportador
            // 
            this.cbTipoExportador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoExportador.FormattingEnabled = true;
            this.cbTipoExportador.Items.AddRange(new object[] {
            "EML",
            "Texto Plano"});
            this.cbTipoExportador.Location = new System.Drawing.Point(122, 28);
            this.cbTipoExportador.Name = "cbTipoExportador";
            this.cbTipoExportador.Size = new System.Drawing.Size(99, 21);
            this.cbTipoExportador.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Exportar A ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Guardar en ";
            // 
            // tbRutaDirectorio
            // 
            this.tbRutaDirectorio.Location = new System.Drawing.Point(122, 66);
            this.tbRutaDirectorio.Name = "tbRutaDirectorio";
            this.tbRutaDirectorio.ReadOnly = true;
            this.tbRutaDirectorio.Size = new System.Drawing.Size(233, 20);
            this.tbRutaDirectorio.TabIndex = 3;
            // 
            // bBuscarDirectorio
            // 
            this.bBuscarDirectorio.Location = new System.Drawing.Point(361, 66);
            this.bBuscarDirectorio.Name = "bBuscarDirectorio";
            this.bBuscarDirectorio.Size = new System.Drawing.Size(28, 20);
            this.bBuscarDirectorio.TabIndex = 4;
            this.bBuscarDirectorio.Text = "...";
            this.bBuscarDirectorio.UseVisualStyleBackColor = true;
            this.bBuscarDirectorio.Click += new System.EventHandler(this.bBuscarDirectorio_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre Archivo";
            // 
            // tbNombreArchivo
            // 
            this.tbNombreArchivo.Location = new System.Drawing.Point(122, 102);
            this.tbNombreArchivo.Name = "tbNombreArchivo";
            this.tbNombreArchivo.Size = new System.Drawing.Size(233, 20);
            this.tbNombreArchivo.TabIndex = 6;
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(122, 148);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 23);
            this.bAceptar.TabIndex = 7;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Location = new System.Drawing.Point(234, 148);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 8;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // FormExportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(404, 198);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.tbNombreArchivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bBuscarDirectorio);
            this.Controls.Add(this.tbRutaDirectorio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTipoExportador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormExportar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportar";
            this.Load += new System.EventHandler(this.FormExportar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTipoExportador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRutaDirectorio;
        private System.Windows.Forms.Button bBuscarDirectorio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNombreArchivo;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Button bCancelar;
    }
}