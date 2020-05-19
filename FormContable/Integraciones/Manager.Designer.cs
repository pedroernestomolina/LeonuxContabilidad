namespace FormContable.Integraciones
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BT_VISUALIZAR = new System.Windows.Forms.Button();
            this.BT_ELIMINAR = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.accionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_MODULO = new System.Windows.Forms.TextBox();
            this.TB_HASTA = new System.Windows.Forms.TextBox();
            this.TB_DESDE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.BT_SALIR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 435);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(698, 45);
            this.panel2.TabIndex = 3;
            // 
            // BT_SALIR
            // 
            this.BT_SALIR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_SALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SALIR.Location = new System.Drawing.Point(603, 3);
            this.BT_SALIR.Name = "BT_SALIR";
            this.BT_SALIR.Size = new System.Drawing.Size(92, 39);
            this.BT_SALIR.TabIndex = 0;
            this.BT_SALIR.Text = "Salir";
            this.BT_SALIR.UseVisualStyleBackColor = true;
            this.BT_SALIR.Click += new System.EventHandler(this.BT_SALIR_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(171, 27);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(183, 33);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BT_VISUALIZAR);
            this.panel4.Controls.Add(this.BT_ELIMINAR);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(34, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(147, 29);
            this.panel4.TabIndex = 4;
            // 
            // BT_VISUALIZAR
            // 
            this.BT_VISUALIZAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_VISUALIZAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_VISUALIZAR.Image = global::FormContable.Properties.Resources.ver;
            this.BT_VISUALIZAR.Location = new System.Drawing.Point(87, 0);
            this.BT_VISUALIZAR.Name = "BT_VISUALIZAR";
            this.BT_VISUALIZAR.Size = new System.Drawing.Size(30, 29);
            this.BT_VISUALIZAR.TabIndex = 4;
            this.toolTip1.SetToolTip(this.BT_VISUALIZAR, "Visualizar Item\r\n");
            this.BT_VISUALIZAR.UseVisualStyleBackColor = true;
            this.BT_VISUALIZAR.Click += new System.EventHandler(this.BT_VISUALIZAR_Click);
            // 
            // BT_ELIMINAR
            // 
            this.BT_ELIMINAR.BackgroundImage = global::FormContable.Properties.Resources.eliminar;
            this.BT_ELIMINAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_ELIMINAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_ELIMINAR.Location = new System.Drawing.Point(117, 0);
            this.BT_ELIMINAR.Name = "BT_ELIMINAR";
            this.BT_ELIMINAR.Size = new System.Drawing.Size(30, 29);
            this.BT_ELIMINAR.TabIndex = 3;
            this.toolTip1.SetToolTip(this.BT_ELIMINAR, "Eliminar Item\r\n");
            this.BT_ELIMINAR.UseVisualStyleBackColor = true;
            this.BT_ELIMINAR.Click += new System.EventHandler(this.BT_ELIMINAR_Click);
            // 
            // DGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(10, 60);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(344, 369);
            this.DGV.TabIndex = 5;
            this.DGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DGV_DataBindingComplete);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.accionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(698, 24);
            this.menuStrip1.TabIndex = 7;
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
            // accionesToolStripMenuItem
            // 
            this.accionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEliminar});
            this.accionesToolStripMenuItem.Name = "accionesToolStripMenuItem";
            this.accionesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.accionesToolStripMenuItem.Text = "Acciones";
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(117, 22);
            this.MenuEliminar.Text = "Eliminar";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(360, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(326, 369);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(318, 343);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detalle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TB_MODULO);
            this.groupBox1.Controls.Add(this.TB_HASTA);
            this.groupBox1.Controls.Add(this.TB_DESDE);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 241);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // TB_MODULO
            // 
            this.TB_MODULO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_MODULO.Enabled = false;
            this.TB_MODULO.Location = new System.Drawing.Point(16, 139);
            this.TB_MODULO.Multiline = true;
            this.TB_MODULO.Name = "TB_MODULO";
            this.TB_MODULO.Size = new System.Drawing.Size(284, 81);
            this.TB_MODULO.TabIndex = 5;
            // 
            // TB_HASTA
            // 
            this.TB_HASTA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_HASTA.Enabled = false;
            this.TB_HASTA.Location = new System.Drawing.Point(16, 94);
            this.TB_HASTA.Name = "TB_HASTA";
            this.TB_HASTA.Size = new System.Drawing.Size(138, 22);
            this.TB_HASTA.TabIndex = 4;
            // 
            // TB_DESDE
            // 
            this.TB_DESDE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_DESDE.Enabled = false;
            this.TB_DESDE.Location = new System.Drawing.Point(16, 50);
            this.TB_DESDE.Name = "TB_DESDE";
            this.TB_DESDE.Size = new System.Drawing.Size(138, 22);
            this.TB_DESDE.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(13, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta La Fecha:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde La Fecha:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Integraciones";
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 480);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Integraciones (Administrador)";
            this.Load += new System.EventHandler(this.Manager_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BT_SALIR;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BT_ELIMINAR;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem MenuSalir;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_MODULO;
        private System.Windows.Forms.TextBox TB_HASTA;
        private System.Windows.Forms.TextBox TB_DESDE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BT_VISUALIZAR;
    }
}