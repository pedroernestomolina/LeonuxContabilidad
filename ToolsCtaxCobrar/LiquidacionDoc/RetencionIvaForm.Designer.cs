namespace ToolsCtaxCobrar.LiquidacionDoc
{
    partial class RetencionIvaForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BT_PROCESAR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TB_TASA_IVA = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TB_TOTAL = new System.Windows.Forms.TextBox();
            this.TB_MONTO_IMPUESTO = new System.Windows.Forms.TextBox();
            this.TB_MONTO_BASE = new System.Windows.Forms.TextBox();
            this.TB_MONTO_EXCENTO = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TB_DOCUMENTO = new System.Windows.Forms.TextBox();
            this.TB_CONTROL = new System.Windows.Forms.TextBox();
            this.TB_COMPROBANTE = new System.Windows.Forms.TextBox();
            this.TB_TASA_RETENCION = new System.Windows.Forms.TextBox();
            this.DTP_FECHA_RETENCION = new System.Windows.Forms.DateTimePicker();
            this.L_MONTO_RETENCION = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.BT_PROCESAR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 228);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(622, 55);
            this.panel1.TabIndex = 0;
            // 
            // BT_PROCESAR
            // 
            this.BT_PROCESAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_PROCESAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_PROCESAR.Location = new System.Drawing.Point(493, 2);
            this.BT_PROCESAR.Name = "BT_PROCESAR";
            this.BT_PROCESAR.Size = new System.Drawing.Size(127, 51);
            this.BT_PROCESAR.TabIndex = 0;
            this.BT_PROCESAR.Text = "OK";
            this.BT_PROCESAR.UseVisualStyleBackColor = true;
            this.BT_PROCESAR.Click += new System.EventHandler(this.BT_PROCESAR_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Documento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Control:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(250, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha Retención:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(250, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Comprobante Nro:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.TB_TASA_IVA);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.TB_TOTAL);
            this.panel2.Controls.Add(this.TB_MONTO_IMPUESTO);
            this.panel2.Controls.Add(this.TB_MONTO_BASE);
            this.panel2.Controls.Add(this.TB_MONTO_EXCENTO);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(15, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 132);
            this.panel2.TabIndex = 5;
            // 
            // TB_TASA_IVA
            // 
            this.TB_TASA_IVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_TASA_IVA.Location = new System.Drawing.Point(314, 69);
            this.TB_TASA_IVA.Name = "TB_TASA_IVA";
            this.TB_TASA_IVA.ReadOnly = true;
            this.TB_TASA_IVA.Size = new System.Drawing.Size(59, 22);
            this.TB_TASA_IVA.TabIndex = 10;
            this.TB_TASA_IVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(265, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 16);
            this.label11.TabIndex = 9;
            this.label11.Text = "Tasa:";
            // 
            // TB_TOTAL
            // 
            this.TB_TOTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_TOTAL.Location = new System.Drawing.Point(123, 97);
            this.TB_TOTAL.Name = "TB_TOTAL";
            this.TB_TOTAL.ReadOnly = true;
            this.TB_TOTAL.Size = new System.Drawing.Size(127, 22);
            this.TB_TOTAL.TabIndex = 8;
            this.TB_TOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TB_MONTO_IMPUESTO
            // 
            this.TB_MONTO_IMPUESTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_MONTO_IMPUESTO.Location = new System.Drawing.Point(123, 69);
            this.TB_MONTO_IMPUESTO.Name = "TB_MONTO_IMPUESTO";
            this.TB_MONTO_IMPUESTO.ReadOnly = true;
            this.TB_MONTO_IMPUESTO.Size = new System.Drawing.Size(127, 22);
            this.TB_MONTO_IMPUESTO.TabIndex = 7;
            this.TB_MONTO_IMPUESTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TB_MONTO_BASE
            // 
            this.TB_MONTO_BASE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_MONTO_BASE.Location = new System.Drawing.Point(123, 41);
            this.TB_MONTO_BASE.Name = "TB_MONTO_BASE";
            this.TB_MONTO_BASE.ReadOnly = true;
            this.TB_MONTO_BASE.Size = new System.Drawing.Size(127, 22);
            this.TB_MONTO_BASE.TabIndex = 6;
            this.TB_MONTO_BASE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TB_MONTO_EXCENTO
            // 
            this.TB_MONTO_EXCENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_MONTO_EXCENTO.Location = new System.Drawing.Point(123, 13);
            this.TB_MONTO_EXCENTO.Name = "TB_MONTO_EXCENTO";
            this.TB_MONTO_EXCENTO.ReadOnly = true;
            this.TB_MONTO_EXCENTO.Size = new System.Drawing.Size(127, 22);
            this.TB_MONTO_EXCENTO.TabIndex = 5;
            this.TB_MONTO_EXCENTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(74, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Total:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Monto Impuesto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Monto Base:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Monto Excento:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(464, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "Tasa Retención (%):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(482, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 16);
            this.label10.TabIndex = 7;
            this.label10.Text = "Monto Retención:";
            // 
            // TB_DOCUMENTO
            // 
            this.TB_DOCUMENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_DOCUMENTO.Location = new System.Drawing.Point(98, 6);
            this.TB_DOCUMENTO.MaxLength = 10;
            this.TB_DOCUMENTO.Name = "TB_DOCUMENTO";
            this.TB_DOCUMENTO.ReadOnly = true;
            this.TB_DOCUMENTO.Size = new System.Drawing.Size(127, 22);
            this.TB_DOCUMENTO.TabIndex = 0;
            // 
            // TB_CONTROL
            // 
            this.TB_CONTROL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_CONTROL.Location = new System.Drawing.Point(98, 34);
            this.TB_CONTROL.MaxLength = 10;
            this.TB_CONTROL.Name = "TB_CONTROL";
            this.TB_CONTROL.ReadOnly = true;
            this.TB_CONTROL.Size = new System.Drawing.Size(127, 22);
            this.TB_CONTROL.TabIndex = 1;
            // 
            // TB_COMPROBANTE
            // 
            this.TB_COMPROBANTE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_COMPROBANTE.Location = new System.Drawing.Point(374, 34);
            this.TB_COMPROBANTE.MaxLength = 14;
            this.TB_COMPROBANTE.Name = "TB_COMPROBANTE";
            this.TB_COMPROBANTE.Size = new System.Drawing.Size(203, 22);
            this.TB_COMPROBANTE.TabIndex = 4;
            // 
            // TB_TASA_RETENCION
            // 
            this.TB_TASA_RETENCION.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_TASA_RETENCION.Location = new System.Drawing.Point(530, 109);
            this.TB_TASA_RETENCION.Name = "TB_TASA_RETENCION";
            this.TB_TASA_RETENCION.Size = new System.Drawing.Size(64, 22);
            this.TB_TASA_RETENCION.TabIndex = 9;
            this.TB_TASA_RETENCION.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_TASA_RETENCION.Validating += new System.ComponentModel.CancelEventHandler(this.TB_TASA_RETENCION_Validating);
            // 
            // DTP_FECHA_RETENCION
            // 
            this.DTP_FECHA_RETENCION.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_FECHA_RETENCION.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_FECHA_RETENCION.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_FECHA_RETENCION.Location = new System.Drawing.Point(374, 6);
            this.DTP_FECHA_RETENCION.Name = "DTP_FECHA_RETENCION";
            this.DTP_FECHA_RETENCION.Size = new System.Drawing.Size(138, 22);
            this.DTP_FECHA_RETENCION.TabIndex = 3;
            this.DTP_FECHA_RETENCION.Validating += new System.ComponentModel.CancelEventHandler(this.DTP_FECHA_RETENCION_Validating);
            // 
            // L_MONTO_RETENCION
            // 
            this.L_MONTO_RETENCION.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_MONTO_RETENCION.Location = new System.Drawing.Point(450, 184);
            this.L_MONTO_RETENCION.Name = "L_MONTO_RETENCION";
            this.L_MONTO_RETENCION.Size = new System.Drawing.Size(144, 24);
            this.L_MONTO_RETENCION.TabIndex = 10;
            this.L_MONTO_RETENCION.Text = "label12";
            this.L_MONTO_RETENCION.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // RetencionIvaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 283);
            this.Controls.Add(this.L_MONTO_RETENCION);
            this.Controls.Add(this.DTP_FECHA_RETENCION);
            this.Controls.Add(this.TB_TASA_RETENCION);
            this.Controls.Add(this.TB_COMPROBANTE);
            this.Controls.Add(this.TB_CONTROL);
            this.Controls.Add(this.TB_DOCUMENTO);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "RetencionIvaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retención Iva";
            this.Load += new System.EventHandler(this.RetencionIvaForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BT_PROCESAR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TB_TOTAL;
        private System.Windows.Forms.TextBox TB_MONTO_IMPUESTO;
        private System.Windows.Forms.TextBox TB_MONTO_BASE;
        private System.Windows.Forms.TextBox TB_MONTO_EXCENTO;
        private System.Windows.Forms.TextBox TB_DOCUMENTO;
        private System.Windows.Forms.TextBox TB_CONTROL;
        private System.Windows.Forms.TextBox TB_COMPROBANTE;
        private System.Windows.Forms.TextBox TB_TASA_RETENCION;
        private System.Windows.Forms.DateTimePicker DTP_FECHA_RETENCION;
        private System.Windows.Forms.TextBox TB_TASA_IVA;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label L_MONTO_RETENCION;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}