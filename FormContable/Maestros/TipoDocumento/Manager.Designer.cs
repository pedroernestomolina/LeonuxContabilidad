namespace FormContable.Maestros.TipoDocumento
{
    partial class Manager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BT_SALIR = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BT_REFRESCAR = new System.Windows.Forms.Button();
            this.BT_AGREGAR = new System.Windows.Forms.Button();
            this.BT_EDITAR = new System.Windows.Forms.Button();
            this.BT_ELIMINAR = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.BT_SALIR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 494);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(497, 45);
            this.panel2.TabIndex = 3;
            // 
            // BT_SALIR
            // 
            this.BT_SALIR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_SALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SALIR.Location = new System.Drawing.Point(402, 3);
            this.BT_SALIR.Name = "BT_SALIR";
            this.BT_SALIR.Size = new System.Drawing.Size(92, 39);
            this.BT_SALIR.TabIndex = 0;
            this.BT_SALIR.Text = "Salir";
            this.BT_SALIR.UseVisualStyleBackColor = true;
            this.BT_SALIR.Click += new System.EventHandler(this.BT_SALIR_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(497, 24);
            this.menuStrip1.TabIndex = 4;
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
            // DGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(12, 77);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(473, 411);
            this.DGV.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "DOCUMENTOS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(322, 38);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(163, 33);
            this.panel3.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BT_REFRESCAR);
            this.panel4.Controls.Add(this.BT_AGREGAR);
            this.panel4.Controls.Add(this.BT_EDITAR);
            this.panel4.Controls.Add(this.BT_ELIMINAR);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(33, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(128, 29);
            this.panel4.TabIndex = 4;
            // 
            // BT_REFRESCAR
            // 
            this.BT_REFRESCAR.BackgroundImage = global::FormContable.Properties.Resources.menu_refrescar;
            this.BT_REFRESCAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_REFRESCAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_REFRESCAR.Location = new System.Drawing.Point(8, 0);
            this.BT_REFRESCAR.Name = "BT_REFRESCAR";
            this.BT_REFRESCAR.Size = new System.Drawing.Size(30, 29);
            this.BT_REFRESCAR.TabIndex = 6;
            this.toolTip1.SetToolTip(this.BT_REFRESCAR, "Refrescar Lista");
            this.BT_REFRESCAR.UseVisualStyleBackColor = true;
            this.BT_REFRESCAR.Click += new System.EventHandler(this.BT_REFRESCAR_Click);
            // 
            // BT_AGREGAR
            // 
            this.BT_AGREGAR.BackgroundImage = global::FormContable.Properties.Resources.menu_agregar;
            this.BT_AGREGAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_AGREGAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_AGREGAR.Location = new System.Drawing.Point(38, 0);
            this.BT_AGREGAR.Name = "BT_AGREGAR";
            this.BT_AGREGAR.Size = new System.Drawing.Size(30, 29);
            this.BT_AGREGAR.TabIndex = 5;
            this.toolTip1.SetToolTip(this.BT_AGREGAR, "Agregar Item");
            this.BT_AGREGAR.UseVisualStyleBackColor = true;
            this.BT_AGREGAR.Click += new System.EventHandler(this.BT_AGREGAR_Click);
            // 
            // BT_EDITAR
            // 
            this.BT_EDITAR.BackgroundImage = global::FormContable.Properties.Resources.menu_editar;
            this.BT_EDITAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_EDITAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_EDITAR.Location = new System.Drawing.Point(68, 0);
            this.BT_EDITAR.Name = "BT_EDITAR";
            this.BT_EDITAR.Size = new System.Drawing.Size(30, 29);
            this.BT_EDITAR.TabIndex = 4;
            this.toolTip1.SetToolTip(this.BT_EDITAR, "Editar Item");
            this.BT_EDITAR.UseVisualStyleBackColor = true;
            this.BT_EDITAR.Click += new System.EventHandler(this.BT_EDITAR_Click);
            // 
            // BT_ELIMINAR
            // 
            this.BT_ELIMINAR.BackgroundImage = global::FormContable.Properties.Resources.eliminar;
            this.BT_ELIMINAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_ELIMINAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_ELIMINAR.Location = new System.Drawing.Point(98, 0);
            this.BT_ELIMINAR.Name = "BT_ELIMINAR";
            this.BT_ELIMINAR.Size = new System.Drawing.Size(30, 29);
            this.BT_ELIMINAR.TabIndex = 2;
            this.toolTip1.SetToolTip(this.BT_ELIMINAR, "Eliminar Item");
            this.BT_ELIMINAR.UseVisualStyleBackColor = true;
            this.BT_ELIMINAR.Click += new System.EventHandler(this.BT_ELIMINAR_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 539);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager";
            this.Load += new System.EventHandler(this.Manager_Load);
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BT_SALIR;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuSalir;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BT_EDITAR;
        private System.Windows.Forms.Button BT_ELIMINAR;
        private System.Windows.Forms.Button BT_REFRESCAR;
        private System.Windows.Forms.Button BT_AGREGAR;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}