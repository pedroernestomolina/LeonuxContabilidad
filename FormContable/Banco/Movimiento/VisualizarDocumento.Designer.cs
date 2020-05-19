namespace FormContable.Banco.Movimiento
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.BT_SALIR = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.L_TOTAL = new System.Windows.Forms.Label();
            this.TB_FECHA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_DOCUMENTO = new System.Windows.Forms.TextBox();
            this.TB_BANCO = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TB_DETALLE = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_TIPO_MOVIMIENTO = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.L_CONCILIADO = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.BT_SALIR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 381);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(588, 39);
            this.panel2.TabIndex = 3;
            // 
            // BT_SALIR
            // 
            this.BT_SALIR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_SALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SALIR.Location = new System.Drawing.Point(493, 3);
            this.BT_SALIR.Name = "BT_SALIR";
            this.BT_SALIR.Size = new System.Drawing.Size(92, 33);
            this.BT_SALIR.TabIndex = 0;
            this.BT_SALIR.Text = "Salir";
            this.BT_SALIR.UseVisualStyleBackColor = true;
            this.BT_SALIR.Click += new System.EventHandler(this.BT_SALIR_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 234);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TB_DETALLE);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(570, 208);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Documento";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.L_TOTAL);
            this.panel4.Location = new System.Drawing.Point(19, 155);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(533, 51);
            this.panel4.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(243, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(151, 30);
            this.label18.TabIndex = 14;
            this.label18.Text = "Por Monto De:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_TOTAL
            // 
            this.L_TOTAL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.L_TOTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TOTAL.Location = new System.Drawing.Point(400, 15);
            this.L_TOTAL.Name = "L_TOTAL";
            this.L_TOTAL.Size = new System.Drawing.Size(130, 20);
            this.L_TOTAL.TabIndex = 11;
            this.L_TOTAL.Text = "0.0";
            this.L_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_FECHA
            // 
            this.TB_FECHA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_FECHA.Enabled = false;
            this.TB_FECHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_FECHA.Location = new System.Drawing.Point(98, 38);
            this.TB_FECHA.Name = "TB_FECHA";
            this.TB_FECHA.Size = new System.Drawing.Size(123, 22);
            this.TB_FECHA.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.L_CONCILIADO);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TB_TIPO_MOVIMIENTO);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TB_DOCUMENTO);
            this.panel1.Controls.Add(this.TB_BANCO);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.TB_FECHA);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 137);
            this.panel1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Documento:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_DOCUMENTO
            // 
            this.TB_DOCUMENTO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_DOCUMENTO.Enabled = false;
            this.TB_DOCUMENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_DOCUMENTO.Location = new System.Drawing.Point(98, 6);
            this.TB_DOCUMENTO.Name = "TB_DOCUMENTO";
            this.TB_DOCUMENTO.Size = new System.Drawing.Size(123, 26);
            this.TB_DOCUMENTO.TabIndex = 4;
            // 
            // TB_BANCO
            // 
            this.TB_BANCO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_BANCO.Enabled = false;
            this.TB_BANCO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_BANCO.Location = new System.Drawing.Point(318, 6);
            this.TB_BANCO.Multiline = true;
            this.TB_BANCO.Name = "TB_BANCO";
            this.TB_BANCO.Size = new System.Drawing.Size(243, 80);
            this.TB_BANCO.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(232, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 41);
            this.label10.TabIndex = 16;
            this.label10.Text = "Entidad Banco:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 137);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(588, 244);
            this.panel3.TabIndex = 6;
            // 
            // TB_DETALLE
            // 
            this.TB_DETALLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_DETALLE.Enabled = false;
            this.TB_DETALLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_DETALLE.Location = new System.Drawing.Point(19, 66);
            this.TB_DETALLE.Multiline = true;
            this.TB_DETALLE.Name = "TB_DETALLE";
            this.TB_DETALLE.Size = new System.Drawing.Size(533, 91);
            this.TB_DETALLE.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Detalle Del Movimiento:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(229, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 38);
            this.label4.TabIndex = 18;
            this.label4.Text = "Tipo Movimiento:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_TIPO_MOVIMIENTO
            // 
            this.TB_TIPO_MOVIMIENTO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_TIPO_MOVIMIENTO.Enabled = false;
            this.TB_TIPO_MOVIMIENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_TIPO_MOVIMIENTO.Location = new System.Drawing.Point(318, 97);
            this.TB_TIPO_MOVIMIENTO.Name = "TB_TIPO_MOVIMIENTO";
            this.TB_TIPO_MOVIMIENTO.Size = new System.Drawing.Size(243, 26);
            this.TB_TIPO_MOVIMIENTO.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 42);
            this.label5.TabIndex = 20;
            this.label5.Text = "Movimiento Conciliado:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_CONCILIADO
            // 
            this.L_CONCILIADO.AutoSize = true;
            this.L_CONCILIADO.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_CONCILIADO.Location = new System.Drawing.Point(98, 70);
            this.L_CONCILIADO.Name = "L_CONCILIADO";
            this.L_CONCILIADO.Size = new System.Drawing.Size(42, 31);
            this.L_CONCILIADO.TabIndex = 21;
            this.L_CONCILIADO.Text = "SI";
            // 
            // VisualizarDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 420);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "VisualizarDocumento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar";
            this.Load += new System.EventHandler(this.VisualizarDocumento_Load);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BT_SALIR;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_FECHA;
        private System.Windows.Forms.TextBox TB_DOCUMENTO;
        private System.Windows.Forms.TextBox TB_BANCO;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label L_TOTAL;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_DETALLE;
        private System.Windows.Forms.TextBox TB_TIPO_MOVIMIENTO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label L_CONCILIADO;

    }
}