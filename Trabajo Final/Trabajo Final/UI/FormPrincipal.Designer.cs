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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Recibidos");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Enviados");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Mati", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Recibidos");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Brian", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Cuentas de Correo", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.obtenerMailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obtenerTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bAdjuntar = new System.Windows.Forms.Button();
            this.bGuardar = new System.Windows.Forms.Button();
            this.tbAsunto = new System.Windows.Forms.TextBox();
            this.bEnviar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCuerpo = new System.Windows.Forms.RichTextBox();
            this.tbCC = new System.Windows.Forms.TextBox();
            this.tbCCO = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tbPara = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentasToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(824, 24);
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
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 75);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Nodo0";
            treeNode1.Text = "Recibidos";
            treeNode2.Name = "Nodo1";
            treeNode2.Text = "Enviados";
            treeNode3.Name = "Nodo1";
            treeNode3.Text = "Mati";
            treeNode4.Name = "Nodo7";
            treeNode4.Text = "Recibidos";
            treeNode5.Name = "Nodo3";
            treeNode5.Text = "Brian";
            treeNode6.Name = "Nodo0";
            treeNode6.Text = "Cuentas de Correo";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.treeView1.Size = new System.Drawing.Size(160, 353);
            this.treeView1.TabIndex = 1;
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
            this.obtenerTodosToolStripMenuItem});
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
            // 
            // obtenerTodosToolStripMenuItem
            // 
            this.obtenerTodosToolStripMenuItem.Name = "obtenerTodosToolStripMenuItem";
            this.obtenerTodosToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.obtenerTodosToolStripMenuItem.Text = "Obtener Todos";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(203, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Buscar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bAdjuntar);
            this.groupBox2.Controls.Add(this.bGuardar);
            this.groupBox2.Controls.Add(this.tbAsunto);
            this.groupBox2.Controls.Add(this.bEnviar);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbCuerpo);
            this.groupBox2.Controls.Add(this.tbCC);
            this.groupBox2.Controls.Add(this.tbCCO);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.tbPara);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(391, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 365);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nuevo Email";
            // 
            // bAdjuntar
            // 
            this.bAdjuntar.Image = global::Trabajo_Final.Properties.Resources.attach;
            this.bAdjuntar.Location = new System.Drawing.Point(377, 154);
            this.bAdjuntar.Name = "bAdjuntar";
            this.bAdjuntar.Size = new System.Drawing.Size(36, 24);
            this.bAdjuntar.TabIndex = 11;
            this.bAdjuntar.UseVisualStyleBackColor = true;
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
            this.tbAsunto.Location = new System.Drawing.Point(77, 185);
            this.tbAsunto.Name = "tbAsunto";
            this.tbAsunto.Size = new System.Drawing.Size(294, 20);
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
            this.label5.Location = new System.Drawing.Point(31, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Asunto";
            // 
            // tbCuerpo
            // 
            this.tbCuerpo.Location = new System.Drawing.Point(34, 219);
            this.tbCuerpo.Name = "tbCuerpo";
            this.tbCuerpo.Size = new System.Drawing.Size(337, 134);
            this.tbCuerpo.TabIndex = 8;
            this.tbCuerpo.Text = "";
            // 
            // tbCC
            // 
            this.tbCC.Location = new System.Drawing.Point(75, 88);
            this.tbCC.Name = "tbCC";
            this.tbCC.Size = new System.Drawing.Size(296, 20);
            this.tbCC.TabIndex = 7;
            // 
            // tbCCO
            // 
            this.tbCCO.Location = new System.Drawing.Point(75, 118);
            this.tbCCO.Name = "tbCCO";
            this.tbCCO.Size = new System.Drawing.Size(296, 20);
            this.tbCCO.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(124, 154);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(247, 20);
            this.textBox3.TabIndex = 5;
            // 
            // tbPara
            // 
            this.tbPara.Location = new System.Drawing.Point(75, 50);
            this.tbPara.Name = "tbPara";
            this.tbPara.Size = new System.Drawing.Size(296, 20);
            this.tbPara.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Archivos Adjuntos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "CCO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "CC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Para";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(203, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(182, 326);
            this.dataGridView1.TabIndex = 6;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 455);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador de Correo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cuentasToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem obtenerMailsToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem obtenerTodosToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbAsunto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox tbCuerpo;
        private System.Windows.Forms.TextBox tbCC;
        private System.Windows.Forms.TextBox tbCCO;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox tbPara;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bEnviar;
        private System.Windows.Forms.Button bGuardar;
        private System.Windows.Forms.Button bAdjuntar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
    }
}

