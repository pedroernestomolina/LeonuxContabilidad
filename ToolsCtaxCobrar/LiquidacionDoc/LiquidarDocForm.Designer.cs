namespace ToolsCtaxCobrar.LiquidacionDoc
{
    partial class LiquidarDocForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BT_PROCESAR = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.L_DOC_FVENC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.L_DOC_DIAS_VENC = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.L_DOC_NRO = new System.Windows.Forms.Label();
            this.L_DOC_FEMI = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.L_DOC_TIPO = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.TB_MONTO_RECIBIDO = new System.Windows.Forms.TextBox();
            this.TB_MONTO_RET_IVA = new System.Windows.Forms.TextBox();
            this.TB_MONTO_ANTICIPO = new System.Windows.Forms.TextBox();
            this.TB_MONTO_DSCTO = new System.Windows.Forms.TextBox();
            this.TB_MONTO_ABONADO = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DTP_FECHA_RECEPCION = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.L_SALDO_PEND = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.LL_MONTO_POR_RET_IVA = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.BT_PROCESAR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 383);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(517, 47);
            this.panel1.TabIndex = 0;
            // 
            // BT_PROCESAR
            // 
            this.BT_PROCESAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_PROCESAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_PROCESAR.Location = new System.Drawing.Point(401, 2);
            this.BT_PROCESAR.Name = "BT_PROCESAR";
            this.BT_PROCESAR.Size = new System.Drawing.Size(114, 43);
            this.BT_PROCESAR.TabIndex = 0;
            this.BT_PROCESAR.Text = "OK";
            this.BT_PROCESAR.UseVisualStyleBackColor = true;
            this.BT_PROCESAR.Click += new System.EventHandler(this.BT_PROCESAR_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 86);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.02564F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.97436F));
            this.tableLayoutPanel2.Controls.Add(this.L_DOC_FVENC, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.L_DOC_DIAS_VENC, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(251, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(254, 72);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // L_DOC_FVENC
            // 
            this.L_DOC_FVENC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_DOC_FVENC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DOC_FVENC.ForeColor = System.Drawing.Color.White;
            this.L_DOC_FVENC.Location = new System.Drawing.Point(107, 0);
            this.L_DOC_FVENC.Name = "L_DOC_FVENC";
            this.L_DOC_FVENC.Size = new System.Drawing.Size(144, 24);
            this.L_DOC_FVENC.TabIndex = 9;
            this.L_DOC_FVENC.Text = "label15";
            this.L_DOC_FVENC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(3, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dias Vencida:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_DOC_DIAS_VENC
            // 
            this.L_DOC_DIAS_VENC.AutoSize = true;
            this.L_DOC_DIAS_VENC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_DOC_DIAS_VENC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DOC_DIAS_VENC.ForeColor = System.Drawing.Color.White;
            this.L_DOC_DIAS_VENC.Location = new System.Drawing.Point(107, 24);
            this.L_DOC_DIAS_VENC.Name = "L_DOC_DIAS_VENC";
            this.L_DOC_DIAS_VENC.Size = new System.Drawing.Size(144, 24);
            this.L_DOC_DIAS_VENC.TabIndex = 10;
            this.L_DOC_DIAS_VENC.Text = "label14";
            this.L_DOC_DIAS_VENC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "F/Vence:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.02564F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.97436F));
            this.tableLayoutPanel1.Controls.Add(this.L_DOC_NRO, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.L_DOC_FEMI, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.L_DOC_TIPO, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(234, 72);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // L_DOC_NRO
            // 
            this.L_DOC_NRO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_DOC_NRO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DOC_NRO.ForeColor = System.Drawing.Color.White;
            this.L_DOC_NRO.Location = new System.Drawing.Point(98, 0);
            this.L_DOC_NRO.Name = "L_DOC_NRO";
            this.L_DOC_NRO.Size = new System.Drawing.Size(133, 24);
            this.L_DOC_NRO.TabIndex = 9;
            this.L_DOC_NRO.Text = "label15";
            this.L_DOC_NRO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_DOC_FEMI
            // 
            this.L_DOC_FEMI.AutoSize = true;
            this.L_DOC_FEMI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_DOC_FEMI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DOC_FEMI.ForeColor = System.Drawing.Color.White;
            this.L_DOC_FEMI.Location = new System.Drawing.Point(98, 48);
            this.L_DOC_FEMI.Name = "L_DOC_FEMI";
            this.L_DOC_FEMI.Size = new System.Drawing.Size(133, 24);
            this.L_DOC_FEMI.TabIndex = 11;
            this.L_DOC_FEMI.Text = "label13";
            this.L_DOC_FEMI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Yellow;
            this.label17.Location = new System.Drawing.Point(3, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 24);
            this.label17.TabIndex = 7;
            this.label17.Text = "Tipo:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_DOC_TIPO
            // 
            this.L_DOC_TIPO.AutoSize = true;
            this.L_DOC_TIPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_DOC_TIPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DOC_TIPO.ForeColor = System.Drawing.Color.White;
            this.L_DOC_TIPO.Location = new System.Drawing.Point(98, 24);
            this.L_DOC_TIPO.Name = "L_DOC_TIPO";
            this.L_DOC_TIPO.Size = new System.Drawing.Size(133, 24);
            this.L_DOC_TIPO.TabIndex = 10;
            this.L_DOC_TIPO.Text = "label14";
            this.L_DOC_TIPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Yellow;
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 24);
            this.label18.TabIndex = 6;
            this.label18.Text = "Documento:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Yellow;
            this.label16.Location = new System.Drawing.Point(3, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 24);
            this.label16.TabIndex = 8;
            this.label16.Text = "De Feha:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_MONTO_RECIBIDO
            // 
            this.TB_MONTO_RECIBIDO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_MONTO_RECIBIDO.Location = new System.Drawing.Point(156, 302);
            this.TB_MONTO_RECIBIDO.Name = "TB_MONTO_RECIBIDO";
            this.TB_MONTO_RECIBIDO.ReadOnly = true;
            this.TB_MONTO_RECIBIDO.Size = new System.Drawing.Size(131, 22);
            this.TB_MONTO_RECIBIDO.TabIndex = 28;
            this.TB_MONTO_RECIBIDO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TB_MONTO_RET_IVA
            // 
            this.TB_MONTO_RET_IVA.BackColor = System.Drawing.Color.Yellow;
            this.TB_MONTO_RET_IVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_MONTO_RET_IVA.Location = new System.Drawing.Point(156, 274);
            this.TB_MONTO_RET_IVA.Name = "TB_MONTO_RET_IVA";
            this.TB_MONTO_RET_IVA.ReadOnly = true;
            this.TB_MONTO_RET_IVA.Size = new System.Drawing.Size(131, 22);
            this.TB_MONTO_RET_IVA.TabIndex = 27;
            this.TB_MONTO_RET_IVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_MONTO_RET_IVA.Validating += new System.ComponentModel.CancelEventHandler(this.TB_MONTO_RET_IVA_Validating);
            // 
            // TB_MONTO_ANTICIPO
            // 
            this.TB_MONTO_ANTICIPO.BackColor = System.Drawing.Color.Yellow;
            this.TB_MONTO_ANTICIPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_MONTO_ANTICIPO.Location = new System.Drawing.Point(156, 246);
            this.TB_MONTO_ANTICIPO.Name = "TB_MONTO_ANTICIPO";
            this.TB_MONTO_ANTICIPO.Size = new System.Drawing.Size(131, 22);
            this.TB_MONTO_ANTICIPO.TabIndex = 26;
            this.TB_MONTO_ANTICIPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_MONTO_ANTICIPO.Validating += new System.ComponentModel.CancelEventHandler(this.TB_MONTO_ANTICIPO_Validating);
            // 
            // TB_MONTO_DSCTO
            // 
            this.TB_MONTO_DSCTO.BackColor = System.Drawing.Color.Yellow;
            this.TB_MONTO_DSCTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_MONTO_DSCTO.Location = new System.Drawing.Point(156, 218);
            this.TB_MONTO_DSCTO.Name = "TB_MONTO_DSCTO";
            this.TB_MONTO_DSCTO.Size = new System.Drawing.Size(131, 22);
            this.TB_MONTO_DSCTO.TabIndex = 25;
            this.TB_MONTO_DSCTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_MONTO_DSCTO.Validating += new System.ComponentModel.CancelEventHandler(this.TB_MONTO_DSCTO_Validating);
            // 
            // TB_MONTO_ABONADO
            // 
            this.TB_MONTO_ABONADO.BackColor = System.Drawing.Color.Yellow;
            this.TB_MONTO_ABONADO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_MONTO_ABONADO.Location = new System.Drawing.Point(156, 175);
            this.TB_MONTO_ABONADO.Name = "TB_MONTO_ABONADO";
            this.TB_MONTO_ABONADO.Size = new System.Drawing.Size(131, 22);
            this.TB_MONTO_ABONADO.TabIndex = 24;
            this.TB_MONTO_ABONADO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_MONTO_ABONADO.Validating += new System.ComponentModel.CancelEventHandler(this.TB_MONTO_ABONADO_Validating);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 305);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Monto Recibido:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 221);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Monto Por Descuento:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Monto Por Anticipos:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Monto Abonado:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Fecha Rec/Merc:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DTP_FECHA_RECEPCION
            // 
            this.DTP_FECHA_RECEPCION.CalendarMonthBackground = System.Drawing.Color.Yellow;
            this.DTP_FECHA_RECEPCION.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_FECHA_RECEPCION.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_FECHA_RECEPCION.Location = new System.Drawing.Point(156, 149);
            this.DTP_FECHA_RECEPCION.Name = "DTP_FECHA_RECEPCION";
            this.DTP_FECHA_RECEPCION.Size = new System.Drawing.Size(131, 22);
            this.DTP_FECHA_RECEPCION.TabIndex = 29;
            this.DTP_FECHA_RECEPCION.Validating += new System.ComponentModel.CancelEventHandler(this.DTP_FECHA_RECEPCION_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(222, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Saldo Pendiente:";
            // 
            // L_SALDO_PEND
            // 
            this.L_SALDO_PEND.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_SALDO_PEND.Location = new System.Drawing.Point(357, 89);
            this.L_SALDO_PEND.Name = "L_SALDO_PEND";
            this.L_SALDO_PEND.Size = new System.Drawing.Size(145, 28);
            this.L_SALDO_PEND.TabIndex = 31;
            this.L_SALDO_PEND.Text = "0.00";
            this.L_SALDO_PEND.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // LL_MONTO_POR_RET_IVA
            // 
            this.LL_MONTO_POR_RET_IVA.AutoSize = true;
            this.LL_MONTO_POR_RET_IVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LL_MONTO_POR_RET_IVA.Location = new System.Drawing.Point(27, 277);
            this.LL_MONTO_POR_RET_IVA.Name = "LL_MONTO_POR_RET_IVA";
            this.LL_MONTO_POR_RET_IVA.Size = new System.Drawing.Size(121, 16);
            this.LL_MONTO_POR_RET_IVA.TabIndex = 32;
            this.LL_MONTO_POR_RET_IVA.TabStop = true;
            this.LL_MONTO_POR_RET_IVA.Text = "Monto Por Ret/IVA:";
            this.LL_MONTO_POR_RET_IVA.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_MONTO_POR_RET_IVA_LinkClicked);
            // 
            // LiquidarDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 430);
            this.Controls.Add(this.LL_MONTO_POR_RET_IVA);
            this.Controls.Add(this.L_SALDO_PEND);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DTP_FECHA_RECEPCION);
            this.Controls.Add(this.TB_MONTO_RECIBIDO);
            this.Controls.Add(this.TB_MONTO_RET_IVA);
            this.Controls.Add(this.TB_MONTO_ANTICIPO);
            this.Controls.Add(this.TB_MONTO_DSCTO);
            this.Controls.Add(this.TB_MONTO_ABONADO);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "LiquidarDocForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidar Documento";
            this.Load += new System.EventHandler(this.LiquidarDocForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TB_MONTO_RECIBIDO;
        private System.Windows.Forms.TextBox TB_MONTO_RET_IVA;
        private System.Windows.Forms.TextBox TB_MONTO_ANTICIPO;
        private System.Windows.Forms.TextBox TB_MONTO_DSCTO;
        private System.Windows.Forms.TextBox TB_MONTO_ABONADO;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BT_PROCESAR;
        private System.Windows.Forms.DateTimePicker DTP_FECHA_RECEPCION;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label L_DOC_NRO;
        private System.Windows.Forms.Label L_DOC_FEMI;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label L_DOC_TIPO;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label L_DOC_FVENC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label L_DOC_DIAS_VENC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label L_SALDO_PEND;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.LinkLabel LL_MONTO_POR_RET_IVA;
    }
}