namespace FormContable.Compras.Compra
{
    partial class Calificactivo
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
            this.CB_CALIFICATIVO = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BT_GUARDAR = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CB_CALIFICATIVO
            // 
            this.CB_CALIFICATIVO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_CALIFICATIVO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_CALIFICATIVO.FormattingEnabled = true;
            this.CB_CALIFICATIVO.Location = new System.Drawing.Point(23, 48);
            this.CB_CALIFICATIVO.Name = "CB_CALIFICATIVO";
            this.CB_CALIFICATIVO.Size = new System.Drawing.Size(466, 26);
            this.CB_CALIFICATIVO.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Indicar Calificativo ?:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.BT_GUARDAR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 106);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(529, 39);
            this.panel2.TabIndex = 4;
            // 
            // BT_GUARDAR
            // 
            this.BT_GUARDAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_GUARDAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_GUARDAR.Location = new System.Drawing.Point(434, 3);
            this.BT_GUARDAR.Name = "BT_GUARDAR";
            this.BT_GUARDAR.Size = new System.Drawing.Size(92, 33);
            this.BT_GUARDAR.TabIndex = 0;
            this.BT_GUARDAR.Text = "Guardar";
            this.BT_GUARDAR.UseVisualStyleBackColor = true;
            this.BT_GUARDAR.Click += new System.EventHandler(this.BT_GUARDAR_Click);
            // 
            // Calificactivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 145);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_CALIFICATIVO);
            this.Name = "Calificactivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Datos";
            this.Load += new System.EventHandler(this.Calificactivo_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_CALIFICATIVO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BT_GUARDAR;
    }
}