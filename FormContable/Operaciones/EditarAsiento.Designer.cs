namespace FormContable.Operaciones
{
    partial class EditarAsiento
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
            this.BT_PROCESAR = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculadoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TB_FECHA = new System.Windows.Forms.TextBox();
            this.TB_DOCUMENTO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_DESCRIPCION = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.L_DIF_HABER = new System.Windows.Forms.Label();
            this.L_DIF_DEBE = new System.Windows.Forms.Label();
            this.L_HABER = new System.Windows.Forms.Label();
            this.L_DEBE = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BT_PROCESAR
            // 
            this.BT_PROCESAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_PROCESAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_PROCESAR.Location = new System.Drawing.Point(613, 3);
            this.BT_PROCESAR.Name = "BT_PROCESAR";
            this.BT_PROCESAR.Size = new System.Drawing.Size(138, 42);
            this.BT_PROCESAR.TabIndex = 0;
            this.BT_PROCESAR.Text = "Procesar";
            this.BT_PROCESAR.UseVisualStyleBackColor = true;
            this.BT_PROCESAR.Click += new System.EventHandler(this.BT_PROCESAR_Click);
            // 
            // DGV
            // 
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(5, 178);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(737, 263);
            this.DGV.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.BT_PROCESAR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 500);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(754, 48);
            this.panel1.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(5, 143);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(1);
            this.panel5.Size = new System.Drawing.Size(737, 29);
            this.panel5.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "DETALLES";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.L_DIF_HABER);
            this.panel2.Controls.Add(this.L_DIF_DEBE);
            this.panel2.Controls.Add(this.L_HABER);
            this.panel2.Controls.Add(this.L_DEBE);
            this.panel2.Location = new System.Drawing.Point(5, 441);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(736, 54);
            this.panel2.TabIndex = 19;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.utilitysToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(754, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSalir});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // MenuSalir
            // 
            this.MenuSalir.Name = "MenuSalir";
            this.MenuSalir.Size = new System.Drawing.Size(96, 22);
            this.MenuSalir.Text = "Salir";
            this.MenuSalir.Click += new System.EventHandler(this.MenuSalir_Click);
            // 
            // utilitysToolStripMenuItem
            // 
            this.utilitysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculadoraToolStripMenuItem});
            this.utilitysToolStripMenuItem.Name = "utilitysToolStripMenuItem";
            this.utilitysToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.utilitysToolStripMenuItem.Text = "Utilitis";
            // 
            // calculadoraToolStripMenuItem
            // 
            this.calculadoraToolStripMenuItem.Name = "calculadoraToolStripMenuItem";
            this.calculadoraToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.calculadoraToolStripMenuItem.Text = "Calculadora";
            this.calculadoraToolStripMenuItem.Click += new System.EventHandler(this.calculadoraToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TB_FECHA);
            this.groupBox2.Controls.Add(this.TB_DOCUMENTO);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TB_DESCRIPCION);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(573, 110);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // TB_FECHA
            // 
            this.TB_FECHA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_FECHA.Enabled = false;
            this.TB_FECHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_FECHA.Location = new System.Drawing.Point(9, 77);
            this.TB_FECHA.MaxLength = 20;
            this.TB_FECHA.Name = "TB_FECHA";
            this.TB_FECHA.Size = new System.Drawing.Size(142, 22);
            this.TB_FECHA.TabIndex = 13;
            // 
            // TB_DOCUMENTO
            // 
            this.TB_DOCUMENTO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_DOCUMENTO.Enabled = false;
            this.TB_DOCUMENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_DOCUMENTO.Location = new System.Drawing.Point(9, 35);
            this.TB_DOCUMENTO.MaxLength = 20;
            this.TB_DOCUMENTO.Name = "TB_DOCUMENTO";
            this.TB_DOCUMENTO.Size = new System.Drawing.Size(142, 22);
            this.TB_DOCUMENTO.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Documento/Ref No:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_DESCRIPCION
            // 
            this.TB_DESCRIPCION.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_DESCRIPCION.Enabled = false;
            this.TB_DESCRIPCION.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_DESCRIPCION.Location = new System.Drawing.Point(216, 35);
            this.TB_DESCRIPCION.MaxLength = 120;
            this.TB_DESCRIPCION.Multiline = true;
            this.TB_DESCRIPCION.Name = "TB_DESCRIPCION";
            this.TB_DESCRIPCION.Size = new System.Drawing.Size(327, 41);
            this.TB_DESCRIPCION.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "De Fecha:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(213, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "Descripción:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Diferencia:";
            // 
            // L_DIF_HABER
            // 
            this.L_DIF_HABER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_DIF_HABER.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DIF_HABER.Location = new System.Drawing.Point(578, 28);
            this.L_DIF_HABER.Name = "L_DIF_HABER";
            this.L_DIF_HABER.Size = new System.Drawing.Size(150, 20);
            this.L_DIF_HABER.TabIndex = 8;
            this.L_DIF_HABER.Text = "0.0";
            this.L_DIF_HABER.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_DIF_DEBE
            // 
            this.L_DIF_DEBE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_DIF_DEBE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DIF_DEBE.Location = new System.Drawing.Point(422, 28);
            this.L_DIF_DEBE.Name = "L_DIF_DEBE";
            this.L_DIF_DEBE.Size = new System.Drawing.Size(150, 20);
            this.L_DIF_DEBE.TabIndex = 7;
            this.L_DIF_DEBE.Text = "0.0";
            this.L_DIF_DEBE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_HABER
            // 
            this.L_HABER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_HABER.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_HABER.Location = new System.Drawing.Point(578, 3);
            this.L_HABER.Name = "L_HABER";
            this.L_HABER.Size = new System.Drawing.Size(150, 20);
            this.L_HABER.TabIndex = 6;
            this.L_HABER.Text = "0.0";
            this.L_HABER.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_DEBE
            // 
            this.L_DEBE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_DEBE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DEBE.Location = new System.Drawing.Point(422, 3);
            this.L_DEBE.Name = "L_DEBE";
            this.L_DEBE.Size = new System.Drawing.Size(150, 20);
            this.L_DEBE.TabIndex = 5;
            this.L_DEBE.Text = "0.0";
            this.L_DEBE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditarAsiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 548);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(750, 540);
            this.Name = "EditarAsiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Asiento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditarAsiento_FormClosing);
            this.Load += new System.EventHandler(this.Agregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_PROCESAR;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuSalir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TB_DESCRIPCION;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TB_DOCUMENTO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem utilitysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculadoraToolStripMenuItem;
        private System.Windows.Forms.TextBox TB_FECHA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label L_DIF_HABER;
        private System.Windows.Forms.Label L_DIF_DEBE;
        private System.Windows.Forms.Label L_HABER;
        private System.Windows.Forms.Label L_DEBE;
    }
}