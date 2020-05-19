namespace FormContable.Configuracion.Conceptos
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_BANCO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_GASTO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_PASIVO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BT_BUSCAR = new System.Windows.Forms.Button();
            this.TB_BUSQUEDA = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BT_REFRESH = new System.Windows.Forms.Button();
            this.BT_EDITAR = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.BT_SALIR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 486);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(946, 45);
            this.panel2.TabIndex = 3;
            // 
            // BT_SALIR
            // 
            this.BT_SALIR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_SALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SALIR.Location = new System.Drawing.Point(851, 3);
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
            this.menuStrip1.Size = new System.Drawing.Size(946, 24);
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
            this.DGV.Location = new System.Drawing.Point(12, 109);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(570, 371);
            this.DGV.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(588, 74);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(346, 406);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(338, 380);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos Generales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TB_BANCO);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TB_GASTO);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TB_PASIVO);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 362);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // TB_BANCO
            // 
            this.TB_BANCO.Location = new System.Drawing.Point(36, 254);
            this.TB_BANCO.Multiline = true;
            this.TB_BANCO.Name = "TB_BANCO";
            this.TB_BANCO.ReadOnly = true;
            this.TB_BANCO.Size = new System.Drawing.Size(270, 80);
            this.TB_BANCO.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(13, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cuenta Banco:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_GASTO
            // 
            this.TB_GASTO.Location = new System.Drawing.Point(36, 152);
            this.TB_GASTO.Multiline = true;
            this.TB_GASTO.Name = "TB_GASTO";
            this.TB_GASTO.ReadOnly = true;
            this.TB_GASTO.Size = new System.Drawing.Size(270, 80);
            this.TB_GASTO.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(13, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cuenta Gasto:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_PASIVO
            // 
            this.TB_PASIVO.Location = new System.Drawing.Point(36, 50);
            this.TB_PASIVO.Multiline = true;
            this.TB_PASIVO.Name = "TB_PASIVO";
            this.TB_PASIVO.ReadOnly = true;
            this.TB_PASIVO.Size = new System.Drawing.Size(270, 80);
            this.TB_PASIVO.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuenta Pasivo:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Conceptos";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(16, 70);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(566, 33);
            this.panel3.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BT_BUSCAR);
            this.panel1.Controls.Add(this.TB_BUSQUEDA);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(294, 29);
            this.panel1.TabIndex = 5;
            // 
            // BT_BUSCAR
            // 
            this.BT_BUSCAR.BackgroundImage = global::FormContable.Properties.Resources.buscar;
            this.BT_BUSCAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_BUSCAR.Location = new System.Drawing.Point(258, 4);
            this.BT_BUSCAR.Name = "BT_BUSCAR";
            this.BT_BUSCAR.Size = new System.Drawing.Size(32, 23);
            this.BT_BUSCAR.TabIndex = 1;
            this.toolTip1.SetToolTip(this.BT_BUSCAR, "Buscar");
            this.BT_BUSCAR.UseVisualStyleBackColor = true;
            this.BT_BUSCAR.Click += new System.EventHandler(this.BT_BUSCAR_Click);
            // 
            // TB_BUSQUEDA
            // 
            this.TB_BUSQUEDA.Dock = System.Windows.Forms.DockStyle.Left;
            this.TB_BUSQUEDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_BUSQUEDA.Location = new System.Drawing.Point(1, 1);
            this.TB_BUSQUEDA.Name = "TB_BUSQUEDA";
            this.TB_BUSQUEDA.Size = new System.Drawing.Size(251, 26);
            this.TB_BUSQUEDA.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BT_REFRESH);
            this.panel4.Controls.Add(this.BT_EDITAR);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(464, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 29);
            this.panel4.TabIndex = 4;
            // 
            // BT_REFRESH
            // 
            this.BT_REFRESH.BackgroundImage = global::FormContable.Properties.Resources.menu_refrescar;
            this.BT_REFRESH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_REFRESH.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_REFRESH.Location = new System.Drawing.Point(40, 0);
            this.BT_REFRESH.Name = "BT_REFRESH";
            this.BT_REFRESH.Size = new System.Drawing.Size(30, 29);
            this.BT_REFRESH.TabIndex = 4;
            this.BT_REFRESH.UseVisualStyleBackColor = true;
            this.BT_REFRESH.Click += new System.EventHandler(this.BT_REFRESH_Click);
            // 
            // BT_EDITAR
            // 
            this.BT_EDITAR.BackgroundImage = global::FormContable.Properties.Resources.menu_editar;
            this.BT_EDITAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_EDITAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_EDITAR.Location = new System.Drawing.Point(70, 0);
            this.BT_EDITAR.Name = "BT_EDITAR";
            this.BT_EDITAR.Size = new System.Drawing.Size(30, 29);
            this.BT_EDITAR.TabIndex = 2;
            this.toolTip1.SetToolTip(this.BT_EDITAR, "Editar / Actualizar Item");
            this.BT_EDITAR.UseVisualStyleBackColor = true;
            this.BT_EDITAR.Click += new System.EventHandler(this.BT_EDITAR_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 531);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(815, 570);
            this.Name = "Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager";
            this.Load += new System.EventHandler(this.Manager_Load);
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TB_PASIVO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BT_REFRESH;
        private System.Windows.Forms.Button BT_EDITAR;
        private System.Windows.Forms.TextBox TB_GASTO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_BANCO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TB_BUSQUEDA;
        private System.Windows.Forms.Button BT_BUSCAR;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}