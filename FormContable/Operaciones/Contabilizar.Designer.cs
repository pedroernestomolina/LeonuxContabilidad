namespace FormContable.Operaciones
{
    partial class Contabilizar
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.BT_PROCESAR = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_DOCUMENTO = new System.Windows.Forms.ComboBox();
            this.CB_TIPO = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_DESCRIPCION = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.L_NUMERO = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.BT_PROCESAR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 182);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(634, 39);
            this.panel2.TabIndex = 4;
            // 
            // BT_PROCESAR
            // 
            this.BT_PROCESAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_PROCESAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_PROCESAR.Location = new System.Drawing.Point(539, 3);
            this.BT_PROCESAR.Name = "BT_PROCESAR";
            this.BT_PROCESAR.Size = new System.Drawing.Size(92, 33);
            this.BT_PROCESAR.TabIndex = 0;
            this.BT_PROCESAR.Text = "Procesar";
            this.BT_PROCESAR.UseVisualStyleBackColor = true;
            this.BT_PROCESAR.Click += new System.EventHandler(this.BT_PROCESAR_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CB_DOCUMENTO);
            this.groupBox1.Controls.Add(this.CB_TIPO);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TB_DESCRIPCION);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 150);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encabezado";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Tipo Documento:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_DOCUMENTO
            // 
            this.CB_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DOCUMENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_DOCUMENTO.FormattingEnabled = true;
            this.CB_DOCUMENTO.Location = new System.Drawing.Point(130, 44);
            this.CB_DOCUMENTO.Name = "CB_DOCUMENTO";
            this.CB_DOCUMENTO.Size = new System.Drawing.Size(287, 24);
            this.CB_DOCUMENTO.TabIndex = 16;
            // 
            // CB_TIPO
            // 
            this.CB_TIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TIPO.Enabled = false;
            this.CB_TIPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_TIPO.FormattingEnabled = true;
            this.CB_TIPO.Items.AddRange(new object[] {
            "OPERATIVO",
            "AJUSTE",
            "CIERRE"});
            this.CB_TIPO.Location = new System.Drawing.Point(130, 14);
            this.CB_TIPO.Name = "CB_TIPO";
            this.CB_TIPO.Size = new System.Drawing.Size(219, 24);
            this.CB_TIPO.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Tipo Asiento:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_DESCRIPCION
            // 
            this.TB_DESCRIPCION.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_DESCRIPCION.Location = new System.Drawing.Point(130, 74);
            this.TB_DESCRIPCION.MaxLength = 120;
            this.TB_DESCRIPCION.Multiline = true;
            this.TB_DESCRIPCION.Name = "TB_DESCRIPCION";
            this.TB_DESCRIPCION.Size = new System.Drawing.Size(287, 55);
            this.TB_DESCRIPCION.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Descripción:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.L_NUMERO);
            this.panel4.Location = new System.Drawing.Point(448, 20);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(174, 60);
            this.panel4.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Comprobante No:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_NUMERO
            // 
            this.L_NUMERO.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.L_NUMERO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_NUMERO.Location = new System.Drawing.Point(3, 33);
            this.L_NUMERO.Name = "L_NUMERO";
            this.L_NUMERO.Size = new System.Drawing.Size(168, 24);
            this.L_NUMERO.TabIndex = 11;
            this.L_NUMERO.Text = "0000000001";
            this.L_NUMERO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Contabilizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 221);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.MaximumSize = new System.Drawing.Size(650, 260);
            this.MinimumSize = new System.Drawing.Size(650, 260);
            this.Name = "Contabilizar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contabilizar";
            this.Load += new System.EventHandler(this.Contabilizar_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BT_PROCESAR;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CB_DOCUMENTO;
        private System.Windows.Forms.ComboBox CB_TIPO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_DESCRIPCION;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label L_NUMERO;
    }
}