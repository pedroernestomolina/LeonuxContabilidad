namespace FormContable.Operaciones
{
    partial class Filtros
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
            this.BT_PROCESAR = new System.Windows.Forms.Button();
            this.CB_TIPO_DOCUMENTO = new System.Windows.Forms.ComboBox();
            this.CB_CONDICION_PAGO = new System.Windows.Forms.ComboBox();
            this.CB_DENOMINACION_FISCAL = new System.Windows.Forms.ComboBox();
            this.CB_SERIAL_FISCAL = new System.Windows.Forms.ComboBox();
            this.L_TIPO_DOCUMENTO = new System.Windows.Forms.Label();
            this.L_CONDICION_PAGO = new System.Windows.Forms.Label();
            this.L_DENOMIACION_FISCAL = new System.Windows.Forms.Label();
            this.L_SERIAL_FISCAL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.L_SUCURSAL = new System.Windows.Forms.Label();
            this.CB_SUCURSAL = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.BT_PROCESAR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 292);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(384, 39);
            this.panel2.TabIndex = 4;
            // 
            // BT_PROCESAR
            // 
            this.BT_PROCESAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_PROCESAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_PROCESAR.Location = new System.Drawing.Point(289, 3);
            this.BT_PROCESAR.Name = "BT_PROCESAR";
            this.BT_PROCESAR.Size = new System.Drawing.Size(92, 33);
            this.BT_PROCESAR.TabIndex = 0;
            this.BT_PROCESAR.Text = "Aceptar";
            this.BT_PROCESAR.UseVisualStyleBackColor = true;
            this.BT_PROCESAR.Click += new System.EventHandler(this.BT_PROCESAR_Click);
            // 
            // CB_TIPO_DOCUMENTO
            // 
            this.CB_TIPO_DOCUMENTO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_TIPO_DOCUMENTO.AutoCompleteCustomSource.AddRange(new string[] {
            "FACTURA",
            "NOTA CREDITO",
            "NOTA DEBITO"});
            this.CB_TIPO_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TIPO_DOCUMENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_TIPO_DOCUMENTO.FormattingEnabled = true;
            this.CB_TIPO_DOCUMENTO.Items.AddRange(new object[] {
            "FACTURA",
            "NOTA CREDITO",
            "NOTA DEBITO"});
            this.CB_TIPO_DOCUMENTO.Location = new System.Drawing.Point(53, 111);
            this.CB_TIPO_DOCUMENTO.Name = "CB_TIPO_DOCUMENTO";
            this.CB_TIPO_DOCUMENTO.Size = new System.Drawing.Size(305, 24);
            this.CB_TIPO_DOCUMENTO.TabIndex = 5;
            // 
            // CB_CONDICION_PAGO
            // 
            this.CB_CONDICION_PAGO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_CONDICION_PAGO.AutoCompleteCustomSource.AddRange(new string[] {
            "CONTADO",
            "CREDITO"});
            this.CB_CONDICION_PAGO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_CONDICION_PAGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_CONDICION_PAGO.FormattingEnabled = true;
            this.CB_CONDICION_PAGO.Items.AddRange(new object[] {
            "CONTADO",
            "CREDITO"});
            this.CB_CONDICION_PAGO.Location = new System.Drawing.Point(53, 151);
            this.CB_CONDICION_PAGO.Name = "CB_CONDICION_PAGO";
            this.CB_CONDICION_PAGO.Size = new System.Drawing.Size(305, 24);
            this.CB_CONDICION_PAGO.TabIndex = 6;
            // 
            // CB_DENOMINACION_FISCAL
            // 
            this.CB_DENOMINACION_FISCAL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_DENOMINACION_FISCAL.AutoCompleteCustomSource.AddRange(new string[] {
            "CONTRIBUYENTE",
            "NO CONTRIBUYENTE"});
            this.CB_DENOMINACION_FISCAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DENOMINACION_FISCAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_DENOMINACION_FISCAL.FormattingEnabled = true;
            this.CB_DENOMINACION_FISCAL.Items.AddRange(new object[] {
            "CONTRIBUYENTE",
            "NO CONTRIBUYENTE"});
            this.CB_DENOMINACION_FISCAL.Location = new System.Drawing.Point(53, 191);
            this.CB_DENOMINACION_FISCAL.Name = "CB_DENOMINACION_FISCAL";
            this.CB_DENOMINACION_FISCAL.Size = new System.Drawing.Size(305, 24);
            this.CB_DENOMINACION_FISCAL.TabIndex = 7;
            // 
            // CB_SERIAL_FISCAL
            // 
            this.CB_SERIAL_FISCAL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_SERIAL_FISCAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_SERIAL_FISCAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_SERIAL_FISCAL.FormattingEnabled = true;
            this.CB_SERIAL_FISCAL.Location = new System.Drawing.Point(53, 234);
            this.CB_SERIAL_FISCAL.Name = "CB_SERIAL_FISCAL";
            this.CB_SERIAL_FISCAL.Size = new System.Drawing.Size(305, 24);
            this.CB_SERIAL_FISCAL.TabIndex = 8;
            // 
            // L_TIPO_DOCUMENTO
            // 
            this.L_TIPO_DOCUMENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TIPO_DOCUMENTO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.L_TIPO_DOCUMENTO.Location = new System.Drawing.Point(22, 95);
            this.L_TIPO_DOCUMENTO.Name = "L_TIPO_DOCUMENTO";
            this.L_TIPO_DOCUMENTO.Size = new System.Drawing.Size(168, 13);
            this.L_TIPO_DOCUMENTO.TabIndex = 9;
            this.L_TIPO_DOCUMENTO.Text = "TIPO DOCUMENTO:";
            this.L_TIPO_DOCUMENTO.Click += new System.EventHandler(this.L_TIPO_DOCUMENTO_Click);
            // 
            // L_CONDICION_PAGO
            // 
            this.L_CONDICION_PAGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_CONDICION_PAGO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.L_CONDICION_PAGO.Location = new System.Drawing.Point(21, 135);
            this.L_CONDICION_PAGO.Name = "L_CONDICION_PAGO";
            this.L_CONDICION_PAGO.Size = new System.Drawing.Size(169, 13);
            this.L_CONDICION_PAGO.TabIndex = 10;
            this.L_CONDICION_PAGO.Text = "CONDICION PAGO:";
            this.L_CONDICION_PAGO.Click += new System.EventHandler(this.L_CONDICION_PAGO_Click);
            // 
            // L_DENOMIACION_FISCAL
            // 
            this.L_DENOMIACION_FISCAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DENOMIACION_FISCAL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.L_DENOMIACION_FISCAL.Location = new System.Drawing.Point(21, 175);
            this.L_DENOMIACION_FISCAL.Name = "L_DENOMIACION_FISCAL";
            this.L_DENOMIACION_FISCAL.Size = new System.Drawing.Size(169, 13);
            this.L_DENOMIACION_FISCAL.TabIndex = 11;
            this.L_DENOMIACION_FISCAL.Text = "DENOMINACION FISCAL:";
            this.L_DENOMIACION_FISCAL.Click += new System.EventHandler(this.L_DENOMIACION_FISCAL_Click);
            // 
            // L_SERIAL_FISCAL
            // 
            this.L_SERIAL_FISCAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_SERIAL_FISCAL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.L_SERIAL_FISCAL.Location = new System.Drawing.Point(21, 218);
            this.L_SERIAL_FISCAL.Name = "L_SERIAL_FISCAL";
            this.L_SERIAL_FISCAL.Size = new System.Drawing.Size(169, 13);
            this.L_SERIAL_FISCAL.TabIndex = 12;
            this.L_SERIAL_FISCAL.Text = "SERIAL FISCAL:";
            this.L_SERIAL_FISCAL.Click += new System.EventHandler(this.L_SERIAL_FISCAL_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(384, 30);
            this.label5.TabIndex = 13;
            this.label5.Text = "A FILTRAR POR";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_SUCURSAL
            // 
            this.L_SUCURSAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_SUCURSAL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.L_SUCURSAL.Location = new System.Drawing.Point(22, 52);
            this.L_SUCURSAL.Name = "L_SUCURSAL";
            this.L_SUCURSAL.Size = new System.Drawing.Size(168, 13);
            this.L_SUCURSAL.TabIndex = 15;
            this.L_SUCURSAL.Text = "SUCURSAL:";
            this.L_SUCURSAL.Click += new System.EventHandler(this.L_SUCURSAL_Click);
            // 
            // CB_SUCURSAL
            // 
            this.CB_SUCURSAL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_SUCURSAL.AutoCompleteCustomSource.AddRange(new string[] {
            "FACTURA",
            "NOTA CREDITO",
            "NOTA DEBITO"});
            this.CB_SUCURSAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_SUCURSAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_SUCURSAL.FormattingEnabled = true;
            this.CB_SUCURSAL.Location = new System.Drawing.Point(53, 68);
            this.CB_SUCURSAL.Name = "CB_SUCURSAL";
            this.CB_SUCURSAL.Size = new System.Drawing.Size(305, 24);
            this.CB_SUCURSAL.TabIndex = 14;
            // 
            // Filtros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 331);
            this.Controls.Add(this.L_SUCURSAL);
            this.Controls.Add(this.CB_SUCURSAL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.L_SERIAL_FISCAL);
            this.Controls.Add(this.L_DENOMIACION_FISCAL);
            this.Controls.Add(this.L_CONDICION_PAGO);
            this.Controls.Add(this.L_TIPO_DOCUMENTO);
            this.Controls.Add(this.CB_SERIAL_FISCAL);
            this.Controls.Add(this.CB_DENOMINACION_FISCAL);
            this.Controls.Add(this.CB_CONDICION_PAGO);
            this.Controls.Add(this.CB_TIPO_DOCUMENTO);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(350, 370);
            this.Name = "Filtros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Filtros_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BT_PROCESAR;
        private System.Windows.Forms.ComboBox CB_TIPO_DOCUMENTO;
        private System.Windows.Forms.ComboBox CB_CONDICION_PAGO;
        private System.Windows.Forms.ComboBox CB_DENOMINACION_FISCAL;
        private System.Windows.Forms.ComboBox CB_SERIAL_FISCAL;
        private System.Windows.Forms.Label L_TIPO_DOCUMENTO;
        private System.Windows.Forms.Label L_CONDICION_PAGO;
        private System.Windows.Forms.Label L_DENOMIACION_FISCAL;
        private System.Windows.Forms.Label L_SERIAL_FISCAL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label L_SUCURSAL;
        private System.Windows.Forms.ComboBox CB_SUCURSAL;
    }
}