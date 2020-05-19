namespace FormContable.Operaciones
{
    partial class FiltroBanco
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
            this.CB_TIPO_MOVIMIENTO = new System.Windows.Forms.ComboBox();
            this.L_TIPO_MOVIMIENTO = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.BT_PROCESAR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 242);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(274, 39);
            this.panel2.TabIndex = 4;
            // 
            // BT_PROCESAR
            // 
            this.BT_PROCESAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_PROCESAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_PROCESAR.Location = new System.Drawing.Point(179, 3);
            this.BT_PROCESAR.Name = "BT_PROCESAR";
            this.BT_PROCESAR.Size = new System.Drawing.Size(92, 33);
            this.BT_PROCESAR.TabIndex = 0;
            this.BT_PROCESAR.Text = "Aceptar";
            this.BT_PROCESAR.UseVisualStyleBackColor = true;
            this.BT_PROCESAR.Click += new System.EventHandler(this.BT_PROCESAR_Click);
            // 
            // CB_TIPO_MOVIMIENTO
            // 
            this.CB_TIPO_MOVIMIENTO.AutoCompleteCustomSource.AddRange(new string[] {
            "FACTURA",
            "NOTA CREDITO",
            "NOTA DEBITO"});
            this.CB_TIPO_MOVIMIENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TIPO_MOVIMIENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_TIPO_MOVIMIENTO.FormattingEnabled = true;
            this.CB_TIPO_MOVIMIENTO.Items.AddRange(new object[] {
            "DEPOSITOS",
            "CHEQUE",
            "NOTAS DE CREDITO",
            "NOTAS DE DEBITO",
            "IGTF"});
            this.CB_TIPO_MOVIMIENTO.Location = new System.Drawing.Point(53, 69);
            this.CB_TIPO_MOVIMIENTO.Name = "CB_TIPO_MOVIMIENTO";
            this.CB_TIPO_MOVIMIENTO.Size = new System.Drawing.Size(174, 24);
            this.CB_TIPO_MOVIMIENTO.TabIndex = 5;
            // 
            // L_TIPO_MOVIMIENTO
            // 
            this.L_TIPO_MOVIMIENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TIPO_MOVIMIENTO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.L_TIPO_MOVIMIENTO.Location = new System.Drawing.Point(22, 53);
            this.L_TIPO_MOVIMIENTO.Name = "L_TIPO_MOVIMIENTO";
            this.L_TIPO_MOVIMIENTO.Size = new System.Drawing.Size(168, 13);
            this.L_TIPO_MOVIMIENTO.TabIndex = 9;
            this.L_TIPO_MOVIMIENTO.Text = "TIPO MOVIMIENTO:";
            this.L_TIPO_MOVIMIENTO.Click += new System.EventHandler(this.L_TIPO_MOVIMIENTO_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(274, 30);
            this.label5.TabIndex = 13;
            this.label5.Text = "A FILTRAR POR";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FiltroBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 281);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.L_TIPO_MOVIMIENTO);
            this.Controls.Add(this.CB_TIPO_MOVIMIENTO);
            this.Controls.Add(this.panel2);
            this.MaximumSize = new System.Drawing.Size(290, 320);
            this.MinimumSize = new System.Drawing.Size(290, 320);
            this.Name = "FiltroBanco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FiltroBanco_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BT_PROCESAR;
        private System.Windows.Forms.ComboBox CB_TIPO_MOVIMIENTO;
        private System.Windows.Forms.Label L_TIPO_MOVIMIENTO;
        private System.Windows.Forms.Label label5;
    }
}