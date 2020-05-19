﻿namespace FormContable.Operaciones
{
    partial class FiltroCxP
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
            this.CB_PROVEEDOR = new System.Windows.Forms.ComboBox();
            this.CB_CONCEPTO = new System.Windows.Forms.ComboBox();
            this.L_TIPO_DOCUMENTO = new System.Windows.Forms.Label();
            this.L_PROVEEDOR = new System.Windows.Forms.Label();
            this.L_CONCEPTO = new System.Windows.Forms.Label();
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
            this.panel2.Location = new System.Drawing.Point(0, 232);
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
            this.CB_TIPO_DOCUMENTO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_TIPO_DOCUMENTO.AutoCompleteCustomSource.AddRange(new string[] {
            "FACTURA",
            "NOTA CREDITO",
            "NOTA DEBITO"});
            this.CB_TIPO_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TIPO_DOCUMENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_TIPO_DOCUMENTO.FormattingEnabled = true;
            this.CB_TIPO_DOCUMENTO.Items.AddRange(new object[] {
            "PAGO",
            "RETENCION IVA",
            "RETENCION ISLR"});
            this.CB_TIPO_DOCUMENTO.Location = new System.Drawing.Point(44, 68);
            this.CB_TIPO_DOCUMENTO.Name = "CB_TIPO_DOCUMENTO";
            this.CB_TIPO_DOCUMENTO.Size = new System.Drawing.Size(319, 24);
            this.CB_TIPO_DOCUMENTO.TabIndex = 5;
            // 
            // CB_PROVEEDOR
            // 
            this.CB_PROVEEDOR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_PROVEEDOR.AutoCompleteCustomSource.AddRange(new string[] {
            "CONTADO",
            "CREDITO"});
            this.CB_PROVEEDOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_PROVEEDOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_PROVEEDOR.FormattingEnabled = true;
            this.CB_PROVEEDOR.Items.AddRange(new object[] {
            "CONTADO",
            "CREDITO"});
            this.CB_PROVEEDOR.Location = new System.Drawing.Point(44, 108);
            this.CB_PROVEEDOR.Name = "CB_PROVEEDOR";
            this.CB_PROVEEDOR.Size = new System.Drawing.Size(319, 24);
            this.CB_PROVEEDOR.TabIndex = 6;
            // 
            // CB_CONCEPTO
            // 
            this.CB_CONCEPTO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_CONCEPTO.AutoCompleteCustomSource.AddRange(new string[] {
            "CONTRIBUYENTE",
            "NO CONTRIBUYENTE"});
            this.CB_CONCEPTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_CONCEPTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_CONCEPTO.FormattingEnabled = true;
            this.CB_CONCEPTO.Items.AddRange(new object[] {
            "CONTRIBUYENTE",
            "NO CONTRIBUYENTE"});
            this.CB_CONCEPTO.Location = new System.Drawing.Point(44, 148);
            this.CB_CONCEPTO.Name = "CB_CONCEPTO";
            this.CB_CONCEPTO.Size = new System.Drawing.Size(319, 24);
            this.CB_CONCEPTO.TabIndex = 7;
            // 
            // L_TIPO_DOCUMENTO
            // 
            this.L_TIPO_DOCUMENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TIPO_DOCUMENTO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.L_TIPO_DOCUMENTO.Location = new System.Drawing.Point(13, 52);
            this.L_TIPO_DOCUMENTO.Name = "L_TIPO_DOCUMENTO";
            this.L_TIPO_DOCUMENTO.Size = new System.Drawing.Size(168, 13);
            this.L_TIPO_DOCUMENTO.TabIndex = 9;
            this.L_TIPO_DOCUMENTO.Text = "TIPO DOCUMENTO:";
            this.L_TIPO_DOCUMENTO.Click += new System.EventHandler(this.L_TIPO_DOCUMENTO_Click);
            // 
            // L_PROVEEDOR
            // 
            this.L_PROVEEDOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_PROVEEDOR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.L_PROVEEDOR.Location = new System.Drawing.Point(12, 92);
            this.L_PROVEEDOR.Name = "L_PROVEEDOR";
            this.L_PROVEEDOR.Size = new System.Drawing.Size(169, 13);
            this.L_PROVEEDOR.TabIndex = 10;
            this.L_PROVEEDOR.Text = "PROVEEDOR:";
            this.L_PROVEEDOR.Click += new System.EventHandler(this.L_PROVEEDOR_Click);
            // 
            // L_CONCEPTO
            // 
            this.L_CONCEPTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_CONCEPTO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.L_CONCEPTO.Location = new System.Drawing.Point(12, 132);
            this.L_CONCEPTO.Name = "L_CONCEPTO";
            this.L_CONCEPTO.Size = new System.Drawing.Size(169, 13);
            this.L_CONCEPTO.TabIndex = 11;
            this.L_CONCEPTO.Text = "CONCEPTO:";
            this.L_CONCEPTO.Click += new System.EventHandler(this.L_CONCEPTO_Click);
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
            this.L_SUCURSAL.Location = new System.Drawing.Point(12, 175);
            this.L_SUCURSAL.Name = "L_SUCURSAL";
            this.L_SUCURSAL.Size = new System.Drawing.Size(168, 13);
            this.L_SUCURSAL.TabIndex = 21;
            this.L_SUCURSAL.Text = "SUCURSAL:";
            this.L_SUCURSAL.Visible = false;
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
            this.CB_SUCURSAL.Items.AddRange(new object[] {
            "PARAPARAL",
            "AGUA DORADA"});
            this.CB_SUCURSAL.Location = new System.Drawing.Point(43, 191);
            this.CB_SUCURSAL.Name = "CB_SUCURSAL";
            this.CB_SUCURSAL.Size = new System.Drawing.Size(319, 24);
            this.CB_SUCURSAL.TabIndex = 20;
            this.CB_SUCURSAL.Visible = false;
            // 
            // FiltroCxP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 271);
            this.Controls.Add(this.L_SUCURSAL);
            this.Controls.Add(this.CB_SUCURSAL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.L_CONCEPTO);
            this.Controls.Add(this.L_PROVEEDOR);
            this.Controls.Add(this.L_TIPO_DOCUMENTO);
            this.Controls.Add(this.CB_CONCEPTO);
            this.Controls.Add(this.CB_PROVEEDOR);
            this.Controls.Add(this.CB_TIPO_DOCUMENTO);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(400, 310);
            this.Name = "FiltroCxP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FiltroCompra_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BT_PROCESAR;
        private System.Windows.Forms.ComboBox CB_TIPO_DOCUMENTO;
        private System.Windows.Forms.ComboBox CB_PROVEEDOR;
        private System.Windows.Forms.ComboBox CB_CONCEPTO;
        private System.Windows.Forms.Label L_TIPO_DOCUMENTO;
        private System.Windows.Forms.Label L_PROVEEDOR;
        private System.Windows.Forms.Label L_CONCEPTO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label L_SUCURSAL;
        private System.Windows.Forms.ComboBox CB_SUCURSAL;

    }
}