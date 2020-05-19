namespace FormContable.PlanCta
{
    partial class Agregar
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConfigurar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReusarPlantilla = new System.Windows.Forms.ToolStripMenuItem();
            this.BT_PROCESAR = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_ESTADO = new System.Windows.Forms.ComboBox();
            this.TB_CODIGO = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_NATURALEZA = new System.Windows.Forms.ComboBox();
            this.CB_TIPO = new System.Windows.Forms.ComboBox();
            this.TB_DESCRIPCION = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.MenuConfigurar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(509, 24);
            this.menuStrip1.TabIndex = 12;
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
            // MenuConfigurar
            // 
            this.MenuConfigurar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuReusarPlantilla});
            this.MenuConfigurar.Name = "MenuConfigurar";
            this.MenuConfigurar.Size = new System.Drawing.Size(76, 20);
            this.MenuConfigurar.Text = "Configurar";
            // 
            // MenuReusarPlantilla
            // 
            this.MenuReusarPlantilla.Checked = true;
            this.MenuReusarPlantilla.CheckOnClick = true;
            this.MenuReusarPlantilla.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuReusarPlantilla.Name = "MenuReusarPlantilla";
            this.MenuReusarPlantilla.Size = new System.Drawing.Size(199, 22);
            this.MenuReusarPlantilla.Text = "Permitir Reusar Plantilla";
            // 
            // BT_PROCESAR
            // 
            this.BT_PROCESAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_PROCESAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_PROCESAR.Location = new System.Drawing.Point(414, 3);
            this.BT_PROCESAR.Name = "BT_PROCESAR";
            this.BT_PROCESAR.Size = new System.Drawing.Size(92, 39);
            this.BT_PROCESAR.TabIndex = 10;
            this.BT_PROCESAR.Text = "Procesar";
            this.BT_PROCESAR.UseVisualStyleBackColor = true;
            this.BT_PROCESAR.Click += new System.EventHandler(this.BT_PROCESAR_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.BT_PROCESAR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 241);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(509, 45);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CB_ESTADO);
            this.panel1.Controls.Add(this.TB_CODIGO);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CB_NATURALEZA);
            this.panel1.Controls.Add(this.CB_TIPO);
            this.panel1.Controls.Add(this.TB_DESCRIPCION);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 217);
            this.panel1.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Estado:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_ESTADO
            // 
            this.CB_ESTADO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ESTADO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_ESTADO.FormattingEnabled = true;
            this.CB_ESTADO.Items.AddRange(new object[] {
            "Situación Financiero",
            "Resultados"});
            this.CB_ESTADO.Location = new System.Drawing.Point(149, 169);
            this.CB_ESTADO.Name = "CB_ESTADO";
            this.CB_ESTADO.Size = new System.Drawing.Size(181, 24);
            this.CB_ESTADO.TabIndex = 5;
            // 
            // TB_CODIGO
            // 
            this.TB_CODIGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_CODIGO.Location = new System.Drawing.Point(149, 30);
            this.TB_CODIGO.Mask = "0000000000";
            this.TB_CODIGO.Name = "TB_CODIGO";
            this.TB_CODIGO.ResetOnSpace = false;
            this.TB_CODIGO.Size = new System.Drawing.Size(181, 24);
            this.TB_CODIGO.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Naturaleza:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tipo Cuenta:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Descripción:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Código:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_NATURALEZA
            // 
            this.CB_NATURALEZA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_NATURALEZA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_NATURALEZA.FormattingEnabled = true;
            this.CB_NATURALEZA.Items.AddRange(new object[] {
            "Deudora",
            "Acreedora"});
            this.CB_NATURALEZA.Location = new System.Drawing.Point(149, 139);
            this.CB_NATURALEZA.Name = "CB_NATURALEZA";
            this.CB_NATURALEZA.Size = new System.Drawing.Size(181, 24);
            this.CB_NATURALEZA.TabIndex = 4;
            // 
            // CB_TIPO
            // 
            this.CB_TIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TIPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_TIPO.FormattingEnabled = true;
            this.CB_TIPO.Items.AddRange(new object[] {
            "Auxiliar",
            "Totalizadora"});
            this.CB_TIPO.Location = new System.Drawing.Point(149, 109);
            this.CB_TIPO.Name = "CB_TIPO";
            this.CB_TIPO.Size = new System.Drawing.Size(181, 24);
            this.CB_TIPO.TabIndex = 3;
            // 
            // TB_DESCRIPCION
            // 
            this.TB_DESCRIPCION.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_DESCRIPCION.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_DESCRIPCION.Location = new System.Drawing.Point(149, 60);
            this.TB_DESCRIPCION.MaxLength = 120;
            this.TB_DESCRIPCION.Multiline = true;
            this.TB_DESCRIPCION.Name = "TB_DESCRIPCION";
            this.TB_DESCRIPCION.Size = new System.Drawing.Size(343, 43);
            this.TB_DESCRIPCION.TabIndex = 2;
            // 
            // Agregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 286);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 280);
            this.Name = "Agregar";
            this.Text = "Agregar Cuenta";
            this.Load += new System.EventHandler(this.Agregar_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuSalir;
        private System.Windows.Forms.ToolStripMenuItem MenuConfigurar;
        private System.Windows.Forms.Button BT_PROCESAR;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_NATURALEZA;
        private System.Windows.Forms.ComboBox CB_TIPO;
        private System.Windows.Forms.TextBox TB_DESCRIPCION;
        private System.Windows.Forms.ToolStripMenuItem MenuReusarPlantilla;
        private System.Windows.Forms.MaskedTextBox TB_CODIGO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CB_ESTADO;
    }
}