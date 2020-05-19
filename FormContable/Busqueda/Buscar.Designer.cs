namespace FormContable.Busqueda
{
    partial class Buscar
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
            this.TB_BUSCAR = new System.Windows.Forms.TextBox();
            this.BT_BUSCAR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "A Buscar:";
            // 
            // TB_BUSCAR
            // 
            this.TB_BUSCAR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_BUSCAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_BUSCAR.Location = new System.Drawing.Point(28, 37);
            this.TB_BUSCAR.Name = "TB_BUSCAR";
            this.TB_BUSCAR.Size = new System.Drawing.Size(302, 26);
            this.TB_BUSCAR.TabIndex = 1;
            // 
            // BT_BUSCAR
            // 
            this.BT_BUSCAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_BUSCAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_BUSCAR.Location = new System.Drawing.Point(258, 69);
            this.BT_BUSCAR.Name = "BT_BUSCAR";
            this.BT_BUSCAR.Size = new System.Drawing.Size(72, 30);
            this.BT_BUSCAR.TabIndex = 2;
            this.BT_BUSCAR.Text = "Buscar";
            this.BT_BUSCAR.UseVisualStyleBackColor = true;
            this.BT_BUSCAR.Click += new System.EventHandler(this.BT_BUSCAR_Click);
            // 
            // Buscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 111);
            this.Controls.Add(this.BT_BUSCAR);
            this.Controls.Add(this.TB_BUSCAR);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(520, 160);
            this.MinimumSize = new System.Drawing.Size(370, 150);
            this.Name = "Buscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar";
            this.Load += new System.EventHandler(this.Buscar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_BUSCAR;
        private System.Windows.Forms.Button BT_BUSCAR;
    }
}