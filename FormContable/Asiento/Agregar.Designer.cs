namespace FormContable.Asiento
{
    partial class Agregar
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
            this.L_NUMERO = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_TIPO = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_DOCUMENTO = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.L_DIF_HABER = new System.Windows.Forms.Label();
            this.L_DIF_DEBE = new System.Windows.Forms.Label();
            this.L_HABER = new System.Windows.Forms.Label();
            this.L_DEBE = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGuardarPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculadoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TB_DOCUMENTO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DTP_FECHA = new System.Windows.Forms.DateTimePicker();
            this.TB_DESCRIPCION = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.L_MODO_FICHA = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.BT_PROCESAR.Location = new System.Drawing.Point(681, 3);
            this.BT_PROCESAR.Name = "BT_PROCESAR";
            this.BT_PROCESAR.Size = new System.Drawing.Size(138, 42);
            this.BT_PROCESAR.TabIndex = 10;
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
            this.DGV.Location = new System.Drawing.Point(5, 239);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(805, 255);
            this.DGV.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.BT_PROCESAR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 556);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(822, 48);
            this.panel1.TabIndex = 6;
            // 
            // L_NUMERO
            // 
            this.L_NUMERO.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.L_NUMERO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_NUMERO.Location = new System.Drawing.Point(3, 38);
            this.L_NUMERO.Name = "L_NUMERO";
            this.L_NUMERO.Size = new System.Drawing.Size(183, 33);
            this.L_NUMERO.TabIndex = 11;
            this.L_NUMERO.Text = "0000000001";
            this.L_NUMERO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 31);
            this.label5.TabIndex = 12;
            this.label5.Text = "Asiento No:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.L_NUMERO);
            this.panel4.Location = new System.Drawing.Point(618, 71);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(189, 74);
            this.panel4.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(359, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Tipo Asiento:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_TIPO
            // 
            this.CB_TIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TIPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_TIPO.FormattingEnabled = true;
            this.CB_TIPO.Items.AddRange(new object[] {
            "OPERATIVO",
            "AJUSTE",
            "CIERRE"});
            this.CB_TIPO.Location = new System.Drawing.Point(362, 54);
            this.CB_TIPO.Name = "CB_TIPO";
            this.CB_TIPO.Size = new System.Drawing.Size(222, 24);
            this.CB_TIPO.TabIndex = 4;
            this.CB_TIPO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CB_TIPO_KeyDown);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(356, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Tipo Documento:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_DOCUMENTO
            // 
            this.CB_DOCUMENTO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DOCUMENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_DOCUMENTO.FormattingEnabled = true;
            this.CB_DOCUMENTO.Location = new System.Drawing.Point(362, 106);
            this.CB_DOCUMENTO.Name = "CB_DOCUMENTO";
            this.CB_DOCUMENTO.Size = new System.Drawing.Size(224, 24);
            this.CB_DOCUMENTO.TabIndex = 5;
            this.CB_DOCUMENTO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CB_DOCUMENTO_KeyDown);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(5, 208);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(1);
            this.panel5.Size = new System.Drawing.Size(805, 31);
            this.panel5.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 29);
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
            this.panel2.Location = new System.Drawing.Point(5, 498);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(804, 55);
            this.panel2.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(403, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Diferencia:";
            // 
            // L_DIF_HABER
            // 
            this.L_DIF_HABER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_DIF_HABER.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DIF_HABER.Location = new System.Drawing.Point(648, 28);
            this.L_DIF_HABER.Name = "L_DIF_HABER";
            this.L_DIF_HABER.Size = new System.Drawing.Size(150, 20);
            this.L_DIF_HABER.TabIndex = 3;
            this.L_DIF_HABER.Text = "0.0";
            this.L_DIF_HABER.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_DIF_DEBE
            // 
            this.L_DIF_DEBE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_DIF_DEBE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DIF_DEBE.Location = new System.Drawing.Point(492, 28);
            this.L_DIF_DEBE.Name = "L_DIF_DEBE";
            this.L_DIF_DEBE.Size = new System.Drawing.Size(150, 20);
            this.L_DIF_DEBE.TabIndex = 2;
            this.L_DIF_DEBE.Text = "0.0";
            this.L_DIF_DEBE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_HABER
            // 
            this.L_HABER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_HABER.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_HABER.Location = new System.Drawing.Point(648, 3);
            this.L_HABER.Name = "L_HABER";
            this.L_HABER.Size = new System.Drawing.Size(150, 20);
            this.L_HABER.TabIndex = 1;
            this.L_HABER.Text = "0.0";
            this.L_HABER.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_DEBE
            // 
            this.L_DEBE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_DEBE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DEBE.Location = new System.Drawing.Point(492, 3);
            this.L_DEBE.Name = "L_DEBE";
            this.L_DEBE.Size = new System.Drawing.Size(150, 20);
            this.L_DEBE.TabIndex = 0;
            this.L_DEBE.Text = "0.0";
            this.L_DEBE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.utilitysToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(822, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuGuardarPreview,
            this.toolStripSeparator1,
            this.MenuSalir});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // MenuGuardarPreview
            // 
            this.MenuGuardarPreview.CheckOnClick = true;
            this.MenuGuardarPreview.Name = "MenuGuardarPreview";
            this.MenuGuardarPreview.Size = new System.Drawing.Size(216, 22);
            this.MenuGuardarPreview.Text = "Guardar Como ( PREVIEW )";
            this.MenuGuardarPreview.CheckedChanged += new System.EventHandler(this.MenuGuardarPreview_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // MenuSalir
            // 
            this.MenuSalir.Name = "MenuSalir";
            this.MenuSalir.Size = new System.Drawing.Size(216, 22);
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
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TB_DOCUMENTO);
            this.groupBox2.Controls.Add(this.CB_DOCUMENTO);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.CB_TIPO);
            this.groupBox2.Controls.Add(this.DTP_FECHA);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.TB_DESCRIPCION);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(592, 175);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // TB_DOCUMENTO
            // 
            this.TB_DOCUMENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_DOCUMENTO.Location = new System.Drawing.Point(9, 35);
            this.TB_DOCUMENTO.MaxLength = 20;
            this.TB_DOCUMENTO.Name = "TB_DOCUMENTO";
            this.TB_DOCUMENTO.Size = new System.Drawing.Size(142, 22);
            this.TB_DOCUMENTO.TabIndex = 1;
            this.TB_DOCUMENTO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_DOCUMENTO_KeyDown);
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
            // DTP_FECHA
            // 
            this.DTP_FECHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_FECHA.Location = new System.Drawing.Point(9, 77);
            this.DTP_FECHA.Name = "DTP_FECHA";
            this.DTP_FECHA.Size = new System.Drawing.Size(267, 22);
            this.DTP_FECHA.TabIndex = 2;
            this.DTP_FECHA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTP_FECHA_KeyDown);
            // 
            // TB_DESCRIPCION
            // 
            this.TB_DESCRIPCION.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_DESCRIPCION.Location = new System.Drawing.Point(9, 121);
            this.TB_DESCRIPCION.MaxLength = 120;
            this.TB_DESCRIPCION.Multiline = true;
            this.TB_DESCRIPCION.Name = "TB_DESCRIPCION";
            this.TB_DESCRIPCION.Size = new System.Drawing.Size(327, 41);
            this.TB_DESCRIPCION.TabIndex = 3;
            this.TB_DESCRIPCION.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_DESCRIPCION_KeyDown);
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
            this.label10.Location = new System.Drawing.Point(6, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "Descripción:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_MODO_FICHA
            // 
            this.L_MODO_FICHA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_MODO_FICHA.BackColor = System.Drawing.Color.DarkOrange;
            this.L_MODO_FICHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_MODO_FICHA.Location = new System.Drawing.Point(618, 45);
            this.L_MODO_FICHA.Name = "L_MODO_FICHA";
            this.L_MODO_FICHA.Size = new System.Drawing.Size(189, 23);
            this.L_MODO_FICHA.TabIndex = 23;
            this.L_MODO_FICHA.Text = "MODO EDICION";
            this.L_MODO_FICHA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.L_MODO_FICHA.Visible = false;
            // 
            // Agregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 604);
            this.Controls.Add(this.L_MODO_FICHA);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(750, 540);
            this.Name = "Agregar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar/Editar Asiento Manual";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Agregar_FormClosing);
            this.Load += new System.EventHandler(this.Agregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
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
        private System.Windows.Forms.Label L_NUMERO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_TIPO;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label L_HABER;
        private System.Windows.Forms.Label L_DEBE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CB_DOCUMENTO;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuSalir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker DTP_FECHA;
        private System.Windows.Forms.TextBox TB_DESCRIPCION;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TB_DOCUMENTO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem MenuGuardarPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem utilitysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculadoraToolStripMenuItem;
        private System.Windows.Forms.Label L_MODO_FICHA;
        private System.Windows.Forms.Label L_DIF_HABER;
        private System.Windows.Forms.Label L_DIF_DEBE;
        private System.Windows.Forms.Label label3;
    }

}