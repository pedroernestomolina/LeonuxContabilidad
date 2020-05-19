namespace FormContable.Periodo
{
    partial class SeleccionarPeriodo
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
            this.BT_SELECCION = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_DESDE = new System.Windows.Forms.ComboBox();
            this.CB_HASTA = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.BT_SELECCION);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 195);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(351, 39);
            this.panel2.TabIndex = 4;
            // 
            // BT_SELECCION
            // 
            this.BT_SELECCION.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_SELECCION.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SELECCION.Location = new System.Drawing.Point(237, 6);
            this.BT_SELECCION.Name = "BT_SELECCION";
            this.BT_SELECCION.Size = new System.Drawing.Size(102, 30);
            this.BT_SELECCION.TabIndex = 7;
            this.BT_SELECCION.Text = "Seleccionar";
            this.BT_SELECCION.UseVisualStyleBackColor = true;
            this.BT_SELECCION.Click += new System.EventHandler(this.BT_SELECCION_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 38);
            this.label1.TabIndex = 5;
            this.label1.Text = "Periodo A Seleccionar:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_DESDE
            // 
            this.CB_DESDE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DESDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_DESDE.FormattingEnabled = true;
            this.CB_DESDE.Location = new System.Drawing.Point(67, 85);
            this.CB_DESDE.Name = "CB_DESDE";
            this.CB_DESDE.Size = new System.Drawing.Size(243, 28);
            this.CB_DESDE.TabIndex = 8;
            // 
            // CB_HASTA
            // 
            this.CB_HASTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_HASTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_HASTA.FormattingEnabled = true;
            this.CB_HASTA.Location = new System.Drawing.Point(67, 139);
            this.CB_HASTA.Name = "CB_HASTA";
            this.CB_HASTA.Size = new System.Drawing.Size(243, 28);
            this.CB_HASTA.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Hasta:";
            // 
            // SeleccionarPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 234);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CB_HASTA);
            this.Controls.Add(this.CB_DESDE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeleccionarPeriodo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Periodos";
            this.Load += new System.EventHandler(this.SeleccionarPeriodo_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BT_SELECCION;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_DESDE;
        private System.Windows.Forms.ComboBox CB_HASTA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}