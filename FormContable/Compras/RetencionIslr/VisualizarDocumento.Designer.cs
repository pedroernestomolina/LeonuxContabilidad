namespace FormContable.Compras.RetencionIslr
{
    partial class VisualizarDocumento
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
            this.label1 = new System.Windows.Forms.Label();
            this.TB_PROVEEDOR = new System.Windows.Forms.TextBox();
            this.TB_FECHA_EMISION = new System.Windows.Forms.TextBox();
            this.TB_PERIODO = new System.Windows.Forms.TextBox();
            this.TB_COMPROBANTE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BT_SALIR = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.L_RETENCION = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.L_TASA_RETENCION = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Para:";
            // 
            // TB_PROVEEDOR
            // 
            this.TB_PROVEEDOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_PROVEEDOR.Enabled = false;
            this.TB_PROVEEDOR.Location = new System.Drawing.Point(54, 12);
            this.TB_PROVEEDOR.Multiline = true;
            this.TB_PROVEEDOR.Name = "TB_PROVEEDOR";
            this.TB_PROVEEDOR.Size = new System.Drawing.Size(346, 78);
            this.TB_PROVEEDOR.TabIndex = 1;
            // 
            // TB_FECHA_EMISION
            // 
            this.TB_FECHA_EMISION.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_FECHA_EMISION.Enabled = false;
            this.TB_FECHA_EMISION.Location = new System.Drawing.Point(513, 13);
            this.TB_FECHA_EMISION.Name = "TB_FECHA_EMISION";
            this.TB_FECHA_EMISION.Size = new System.Drawing.Size(145, 20);
            this.TB_FECHA_EMISION.TabIndex = 2;
            // 
            // TB_PERIODO
            // 
            this.TB_PERIODO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_PERIODO.Enabled = false;
            this.TB_PERIODO.Location = new System.Drawing.Point(513, 39);
            this.TB_PERIODO.Name = "TB_PERIODO";
            this.TB_PERIODO.Size = new System.Drawing.Size(145, 20);
            this.TB_PERIODO.TabIndex = 3;
            // 
            // TB_COMPROBANTE
            // 
            this.TB_COMPROBANTE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_COMPROBANTE.Enabled = false;
            this.TB_COMPROBANTE.Location = new System.Drawing.Point(513, 65);
            this.TB_COMPROBANTE.Name = "TB_COMPROBANTE";
            this.TB_COMPROBANTE.Size = new System.Drawing.Size(145, 20);
            this.TB_COMPROBANTE.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(414, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(414, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Periodo:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(414, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Comprobante:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DGV
            // 
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(54, 123);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(786, 303);
            this.DGV.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.BT_SALIR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 492);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(894, 39);
            this.panel2.TabIndex = 9;
            // 
            // BT_SALIR
            // 
            this.BT_SALIR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_SALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SALIR.Location = new System.Drawing.Point(799, 3);
            this.BT_SALIR.Name = "BT_SALIR";
            this.BT_SALIR.Size = new System.Drawing.Size(92, 33);
            this.BT_SALIR.TabIndex = 0;
            this.BT_SALIR.Text = "Salir";
            this.BT_SALIR.UseVisualStyleBackColor = true;
            this.BT_SALIR.Click += new System.EventHandler(this.BT_SALIR_Click_1);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.L_RETENCION);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(417, 432);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 52);
            this.panel1.TabIndex = 10;
            // 
            // L_RETENCION
            // 
            this.L_RETENCION.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.L_RETENCION.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_RETENCION.Location = new System.Drawing.Point(136, 21);
            this.L_RETENCION.Name = "L_RETENCION";
            this.L_RETENCION.Size = new System.Drawing.Size(284, 27);
            this.L_RETENCION.TabIndex = 1;
            this.L_RETENCION.Text = "label6";
            this.L_RETENCION.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total Retención:";
            // 
            // L_TASA_RETENCION
            // 
            this.L_TASA_RETENCION.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TASA_RETENCION.Location = new System.Drawing.Point(677, 44);
            this.L_TASA_RETENCION.Name = "L_TASA_RETENCION";
            this.L_TASA_RETENCION.Size = new System.Drawing.Size(178, 42);
            this.L_TASA_RETENCION.TabIndex = 11;
            this.L_TASA_RETENCION.Text = "100 %";
            this.L_TASA_RETENCION.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(684, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 27);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tasa Retención:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VisualizarDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 531);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.L_TASA_RETENCION);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_COMPROBANTE);
            this.Controls.Add(this.TB_PERIODO);
            this.Controls.Add(this.TB_FECHA_EMISION);
            this.Controls.Add(this.TB_PROVEEDOR);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(910, 570);
            this.MinimumSize = new System.Drawing.Size(910, 570);
            this.Name = "VisualizarDocumento";
            this.Text = "Visualizar";
            this.Load += new System.EventHandler(this.VisualizarDocumento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_PROVEEDOR;
        private System.Windows.Forms.TextBox TB_FECHA_EMISION;
        private System.Windows.Forms.TextBox TB_PERIODO;
        private System.Windows.Forms.TextBox TB_COMPROBANTE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BT_SALIR;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label L_RETENCION;
        private System.Windows.Forms.Label L_TASA_RETENCION;
        private System.Windows.Forms.Label label7;
    }
}