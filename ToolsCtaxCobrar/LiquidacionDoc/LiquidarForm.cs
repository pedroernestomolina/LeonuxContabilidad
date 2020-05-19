using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ToolsCtaxCobrar.LiquidacionDoc
{

    public partial class LiquidarForm : Form
    {

        private OOB.CtxCobrar.Documentos.Pendiente.Ficha DocumentoCxC;
        private OOB.Clientes.Cliente.Ficha FichaCliente;
        private OOB.Vendedores.Vendedor.Ficha FichaVendedor;
        private OOB.Usuarios.Usuario.Ficha FichaUsuario;
        private List<OOB.Empresa.Cobradores.Ficha> Cobradores;
        private List<OOB.Empresa.MediosPago.Ficha> MediosPago;
        private List<OOB.Bancos.Banco.Ficha> Bancos;
        private BindingSource bs;
        private BindingList<Liquida> Doc;
        private BindingSource bsMedios;
        private BindingList<MedioPago> ListaMedios;
        private decimal Saldo;
        private int DocPendiente;
        private DateTime FechaSistema;
        private Comisiones ComisionesVend;
        private decimal _montoLiquidar;
        private decimal _montoRecibo;
        private decimal _montoPagado;
        private decimal _montoDsctos;
        private decimal _montoAnticipos;
        private decimal _montoRetenciones;
        private decimal _montoRecibido;
        private decimal _montoFavorCliente; 


        public LiquidarForm()
        {
            InitializeComponent();
            Inicializar();

            _montoAnticipos = 0.0m;
            _montoDsctos = 0.0m;
            _montoRetenciones = 0.0m;
            _montoRecibido = 0.0m;
            bs = new BindingSource();
            bs.CurrentChanged += bs_CurrentChanged;
            bsMedios = new BindingSource();
            ListaMedios = new BindingList<MedioPago>();
            FichaCliente = null;
            FichaVendedor = null;
            ComisionesVend = new Comisiones();
            FichaUsuario = new OOB.Usuarios.Usuario.Ficha() { IdAuto = "0000000004", Codigo = "MACOSTA", Nombre = "MACOSTA" };
        }

        public void CargarDocumento(OOB.CtxCobrar.Documentos.Pendiente.Ficha doc)
        {
            var r01 = Globals.MyData.CtaxCobrar_Documentos_Pendiente_Get_ById(doc.IdAuto);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            DocumentoCxC = r01.Entidad;
            CargarData(r01.Entidad.IdAutCliente);
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            TB_FECHA_RECEPCION.Text = DateTime.Now.ToShortDateString();
            TB_MONTO_ABONADO.Text = 0.ToString("n2");
            TB_MONTO_DSCTO.Text = 0.ToString("n2");
            TB_MONTO_ANTICIPO.Text = 0.ToString("n2");
            TB_MONTO_RET_IVA.Text = 0.ToString("n2");
            TB_MONTO_RECIBIDO.Text = 0.ToString("n2");

            if (bs.Current != null)
            {
                var lq = (Liquida)bs.Current;
                ActualizarItemFicha(lq);
            }
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        Clientes.Buscar.BuscarForm fBuscarCliente;
        private void Buscar()
        {
            fBuscarCliente = new Clientes.Buscar.BuscarForm();
            fBuscarCliente.ItemSeleccionadoOk += fBuscarCliente_ItemSeleccionadoOk;
            fBuscarCliente.ShowDialog();
        }

        private void fBuscarCliente_ItemSeleccionadoOk(object sender, OOB.Clientes.Cliente.Ficha e)
        {
            fBuscarCliente.Close();
            CargarData(e.IdAuto);
        }

        private void CargarData(string idCliente)
        {
            var r00 = Globals.MyData.Servidor_GetFecha();
            if (r00.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            FechaSistema = r00.Entidad;

            var r01 = Globals.MyData.Cliente_Get_ById(idCliente);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            FichaCliente = r01.Entidad;
            L_CLIENTE.Text = FichaCliente.Cliente;

            var r02 = Globals.MyData.Vendedor_Get_ById(FichaCliente.IdAutoVendedor);
            if (r02.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }
            FichaVendedor = r02.Entidad;
            L_VENDEDOR.Text = FichaVendedor.Vendedor;

            var filtro = new OOB.CtxCobrar.Documentos.Pendiente.Filtro() { Cliente = FichaCliente };
            var r03 = Globals.MyData.CtaxCobrar_Documentos_Pendiente_Lista(filtro);
            if (r03.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return;
            }

            var r04 = Globals.MyData.Empresa_Cobradores_Lista();
            if (r04.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return;
            }
            Cobradores = r04.Lista;
            CB_COBRADORES.DataSource = Cobradores;

            var r05 = Globals.MyData.Empresa_MediosPago_Lista();
            if (r05.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return;
            }
            MediosPago = r05.Lista;
            CB_MEDIO_PAGO.DataSource = MediosPago;

            var r06 = Globals.MyData.Bancos_Banco_Lista_Resumen();
            if (r06.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return;
            }
            Bancos = r06.Lista;
            CB_BANCOS.DataSource = Bancos;

            var l = r03.Lista.Select(d =>
            {
                return new Liquida()
                {
                    Ficha = d,
                };
            }).ToList();
            Doc = new BindingList<Liquida>(l.OrderBy(d => d.Ficha.FechaEmision).ToList());
            bs.DataSource = Doc;
            DGV.DataSource = bs;

            bsMedios.DataSource = ListaMedios;
            DGV_MEDIO_PAGO.DataSource = bsMedios;

            ActualizarSaldo();
        }

        private void LiquidarForm_Load(object sender, EventArgs e)
        {
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                var doc = (Liquida)bs.Current;
                if (doc.IsSelected == false)
                {
                    PagarDoc(doc);
                }
                else
                {
                    doc.IsSelected = false;
                    doc.FechaRecepcionMercancia = DateTime.Now.Date;
                    doc.MontoAbonado = 0.0m;
                    doc.MontoPorAnticipo = 0.0m;
                    doc.MontoPorDescuento = 0.0m;
                    doc.MontoPorRetencionIva = 0.0m;
                    Actualizar(doc);
                }
            }
        }

        private void Actualizar(Liquida doc)
        {
            ActualizaTotales();
            ActualizaItems();
            ActualizarItemFicha(doc);
            ActualizarSaldo();
            ActualizarMedioPagoImporte();
            ActualizarComision();
        }

        private void ActualizaTotales()
        {
            _montoDsctos = 0.0m;
            _montoAnticipos = 0.0m;
            _montoRetenciones = 0.0m;
            _montoRecibido = 0.0m;
            _montoRecibo = 0.0m;

            _montoDsctos = Doc.Where(w => w.IsSelected).Sum(d => d.MontoPorDescuento);
            _montoAnticipos = Doc.Where(w => w.IsSelected).Sum(d => d.MontoPorAnticipo);
            _montoRetenciones = Doc.Where(w => w.IsSelected).Sum(d => d.MontoPorRetencionIva);
            _montoRecibido = Doc.Where(w => w.IsSelected).Sum(d => d.MontoRecibido);
            _montoRecibo = Doc.Where(w => w.IsSelected).Sum(d => d.MontoAbonado*d.Ficha.Signo);
        }

        private void PagarDoc(Liquida doc)
        {
            var docLq = new LiquidarDocForm(doc);
            docLq.LiquidacionOk += docLq_LiquidacionOk;
            docLq.CargarDoc();
        }

        private void docLq_LiquidacionOk(object sender, Liquida e)
        {
            e.IsSelected = true;
            Actualizar(e);
        }

        private void ActualizarItemFicha(Liquida lq)
        {
            TB_FECHA_RECEPCION.Text = lq.FechaRecepcionMercancia.ToShortDateString();
            TB_MONTO_ABONADO.Text = lq.MontoAbonado.ToString("n2");
            TB_MONTO_DSCTO.Text = lq.MontoPorDescuento.ToString("n2");
            TB_MONTO_ANTICIPO.Text = lq.MontoPorAnticipo.ToString("n2");
            TB_MONTO_RET_IVA.Text = lq.MontoPorRetencionIva.ToString("n2");
            TB_MONTO_RECIBIDO.Text = lq.MontoRecibido.ToString("n2");
        }

        private void ActualizaItems()
        {
            var mAbono = decimal.Round(Doc.Where(W => W.IsSelected && W.Ficha.DocumentoTipo != OOB.CtxCobrar.Enumerados.PorTipoDocumento.NtCredito).
                Sum(t => t.MontoAbonado * t.Ficha.Signo), 2, MidpointRounding.AwayFromZero);
            var mNCR = decimal.Round(Math.Abs(Doc.Where(W => W.IsSelected && W.Ficha.DocumentoTipo == OOB.CtxCobrar.Enumerados.PorTipoDocumento.NtCredito).
                Sum(t => t.MontoAbonado * t.Ficha.Signo)), 2, MidpointRounding.AwayFromZero);
            _montoLiquidar = decimal.Round(Doc.Sum(d => d.MontoRecibido * d.Ficha.Signo), 2, MidpointRounding.AwayFromZero);

            L_MONTO_ABONADO.Text = mAbono.ToString("N2");
            L_MONTO_NCR.Text = mNCR.ToString("N2");
            L_ITEMS_SELECCIONADOS.Text = Doc.Count(T => T.IsSelected).ToString();
            L_MONTO_LIQUIDAR.Text = _montoLiquidar.ToString("n2");
        }

        private void ActualizarSaldo()
        {
            Saldo = Doc.Sum(d => d.Ficha.Saldo * d.Ficha.Signo);
            DocPendiente = Doc.Count(); ;
            L_SALDO.Text = Saldo.ToString("N2");
            L_DOC_PENDIENTE.Text = DocPendiente.ToString();
        }

        private void Inicializar()
        {
            L_CLIENTE.Text = "";
            L_VENDEDOR.Text = "";
            L_SALDO.Text = "0.0";
            L_DOC_PENDIENTE.Text = "0";
            L_ITEMS_SELECCIONADOS.Text = "0";
            L_MONTO_ABONADO.Text = "0.0";
            L_MONTO_NCR.Text = "0.0";
            L_MONTO_LIQUIDAR.Text = "0.0";
            L_IMPORTE_MEDIO_PAGO.Text = "0.0";
            L_SALDO_PEND.Text = "0.0";


            TB_IMPORTE_MEDIO_PAGO.Text = "0.0";


            CB_MEDIO_PAGO.DisplayMember = "Nombre";
            CB_MEDIO_PAGO.ValueMember = "IdAuto";
            CB_BANCOS.DisplayMember = "Numero";
            CB_BANCOS.ValueMember = "Id";
            CB_COBRADORES.DisplayMember = "Nombre";
            CB_COBRADORES.ValueMember = "Id";


            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.CellContentClick += DGV_CellContentClick;

            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);
            var f2 = new Font("Serif", 8, FontStyle.Bold);

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "FechaEmi";
            c1.HeaderText = "Fecha/Emi";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "DocTipo";
            c2.HeaderText = "Tipo";
            c2.Visible = true;
            c2.Width = 40;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "DocNro";
            c3.HeaderText = "Documento";
            c3.Visible = true;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "FechaVto";
            c4.HeaderText = "Fecha/Vto";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Total";
            c5.HeaderText = "Total";
            c5.Visible = true;
            c5.Width = 110;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f2;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Saldo";
            c6.HeaderText = "Saldo";
            c6.Visible = true;
            c6.Width = 110;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f2;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";
            c6.DefaultCellStyle.BackColor = Color.Yellow;

            var c7 = new DataGridViewCheckBoxColumn();
            c7.DataPropertyName = "IsSelected";
            c7.Name = "";
            c7.HeaderText = "*";
            c7.Width = 30;
            c7.Visible = true;
            c7.ReadOnly = true;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);


            //


            DGV_MEDIO_PAGO.AllowUserToAddRows = false;
            DGV_MEDIO_PAGO.AutoGenerateColumns = false;
            DGV_MEDIO_PAGO.AllowUserToResizeRows = false;
            DGV_MEDIO_PAGO.AllowUserToResizeColumns = false;
            DGV_MEDIO_PAGO.AllowUserToOrderColumns = false;
            DGV_MEDIO_PAGO.CellContentClick += DGV_CellContentClick;

            var c11 = new DataGridViewTextBoxColumn();
            c11.DataPropertyName = "MedioDesc";
            c11.HeaderText = "Medio/Pago";
            c11.Visible = true;
            c11.Width = 110;
            c11.HeaderCell.Style.Font = f;
            c11.DefaultCellStyle.Font = f1;

            var c22 = new DataGridViewTextBoxColumn();
            c22.DataPropertyName = "Referencia";
            c22.HeaderText = "Referencia";
            c22.Visible = true;
            c22.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c22.HeaderCell.Style.Font = f;
            c22.DefaultCellStyle.Font = f1;

            var c55 = new DataGridViewTextBoxColumn();
            c55.DataPropertyName = "Fecha";
            c55.HeaderText = "De Fecha";
            c55.Visible = true;
            c55.Width = 80;
            c55.HeaderCell.Style.Font = f;
            c55.DefaultCellStyle.Font = f1;

            var c33 = new DataGridViewTextBoxColumn();
            c33.DataPropertyName = "BancoDesc";
            c33.HeaderText = "Banco";
            c33.Visible = true;
            c33.Width = 120;
            c33.HeaderCell.Style.Font = f;
            c33.DefaultCellStyle.Font = f1;

            var c44 = new DataGridViewTextBoxColumn();
            c44.DataPropertyName = "Importe";
            c44.HeaderText = "Importe";
            c44.Visible = true;
            c44.Width = 110;
            c44.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c44.DefaultCellStyle.Format = "n2";
            c44.HeaderCell.Style.Font = f;
            c44.DefaultCellStyle.Font = f1;


            DGV_MEDIO_PAGO.Columns.Add(c11);
            DGV_MEDIO_PAGO.Columns.Add(c22);
            DGV_MEDIO_PAGO.Columns.Add(c55);
            DGV_MEDIO_PAGO.Columns.Add(c33);
            DGV_MEDIO_PAGO.Columns.Add(c44);


            //


            DGV_COMISIONES.AllowUserToAddRows = false;
            DGV_COMISIONES.AutoGenerateColumns = false;
            DGV_COMISIONES.AllowUserToResizeRows = false;
            DGV_COMISIONES.AllowUserToResizeColumns = false;
            DGV_COMISIONES.AllowUserToOrderColumns = false;

            var c111 = new DataGridViewTextBoxColumn();
            c111.DataPropertyName = "DocumentoLiq";
            c111.HeaderText = "Documento";
            c111.Visible = true;
            c111.Width = 100;
            c111.HeaderCell.Style.Font = f;
            c111.DefaultCellStyle.Font = f1;

            var c222 = new DataGridViewTextBoxColumn();
            c222.DataPropertyName = "Banco";
            c222.HeaderText = "Banco";
            c222.Visible = true;
            c222.Width = 100;
            c222.HeaderCell.Style.Font = f;
            c222.DefaultCellStyle.Font = f1;

            var c333 = new DataGridViewTextBoxColumn();
            c333.DataPropertyName = "RefBanco";
            c333.HeaderText = "Ref Nro";
            c333.Visible = true;
            c333.Width = 80;
            c333.HeaderCell.Style.Font = f;
            c333.DefaultCellStyle.Font = f1;

            var cc = new DataGridViewTextBoxColumn();
            cc.DataPropertyName = "MontoBanco";
            cc.HeaderText = "M/Recibido";
            cc.Visible = true;
            cc.Width = 100;
            cc.HeaderCell.Style.Font = f;
            cc.DefaultCellStyle.Font = f1;
            cc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cc.DefaultCellStyle.Format = "n2";

            var c444 = new DataGridViewTextBoxColumn();
            c444.DataPropertyName = "MontoBanco";
            c444.HeaderText = "M/Recibido";
            c444.Visible = true;
            c444.Width = 100;
            c444.HeaderCell.Style.Font = f;
            c444.DefaultCellStyle.Font = f1;
            c444.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c444.DefaultCellStyle.Format = "n2";

            var c555 = new DataGridViewTextBoxColumn();
            c555.DataPropertyName = "BaseCalculo";
            c555.HeaderText = "M/Importe";
            c555.Visible = true;
            c555.Width = 100;
            c555.HeaderCell.Style.Font = f;
            c555.DefaultCellStyle.Font = f1;
            c555.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c555.DefaultCellStyle.Format = "n2";

            var c666 = new DataGridViewTextBoxColumn();
            c666.DataPropertyName = "ComisionMonto";
            c666.HeaderText = "Com";
            c666.Visible = true;
            c666.Width = 100;
            c666.HeaderCell.Style.Font = f;
            c666.DefaultCellStyle.Font = f1;
            c666.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c666.DefaultCellStyle.Format = "n2";

            var c777 = new DataGridViewTextBoxColumn();
            c777.DataPropertyName = "DiasTranscurridos";
            c777.HeaderText = "Dias";
            c777.Visible = true;
            c777.Width = 50;
            c777.HeaderCell.Style.Font = f;
            c777.DefaultCellStyle.Font = f1;
            c777.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c888 = new DataGridViewTextBoxColumn();
            c888.DataPropertyName = "AplicaCastigoDesc";
            c888.HeaderText = "Castigo";
            c888.Visible = true;
            c888.Width = 50;
            c888.HeaderCell.Style.Font = f;
            c888.DefaultCellStyle.Font = f1;

            var c999 = new DataGridViewTextBoxColumn();
            c999.DataPropertyName = "ComisionPorc";
            c999.HeaderText = "Com %";
            c999.Visible = true;
            c999.Width = 60;
            c999.HeaderCell.Style.Font = f;
            c999.DefaultCellStyle.Font = f1;
            c999.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c999.DefaultCellStyle.Format = "n2";

            var ca = new DataGridViewTextBoxColumn();
            ca.DataPropertyName = "FechaMovBanco";
            ca.HeaderText = "Fecha/Mov";
            ca.Visible = true;
            ca.Width = 100;
            ca.HeaderCell.Style.Font = f;
            ca.DefaultCellStyle.Font = f1;
            ca.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var cb = new DataGridViewTextBoxColumn();
            cb.DataPropertyName = "FechaRecepcionMercancia";
            cb.HeaderText = "Fecha/Recep";
            cb.Visible = true;
            cb.Width = 100;
            cb.HeaderCell.Style.Font = f;
            cb.DefaultCellStyle.Font = f1;
            cb.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DGV_COMISIONES.Columns.Add(c111);
            DGV_COMISIONES.Columns.Add(c222);
            DGV_COMISIONES.Columns.Add(c333);
            DGV_COMISIONES.Columns.Add(c444);
            DGV_COMISIONES.Columns.Add(c555);
            DGV_COMISIONES.Columns.Add(c999);
            DGV_COMISIONES.Columns.Add(c666);
            DGV_COMISIONES.Columns.Add(c777);
            DGV_COMISIONES.Columns.Add(c888);
            DGV_COMISIONES.Columns.Add(cb);
            DGV_COMISIONES.Columns.Add(ca);
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                row.DefaultCellStyle.ForeColor = (string)row.Cells[1].Value == "NCR" ? Color.Red : Color.Black;
            }
        }


        private void BT_EDITAR_DOC_LIQUIDAR_Click(object sender, EventArgs e)
        {
            EditarItemLiquidar();
        }

        private void EditarItemLiquidar()
        {
            if (bs.Current != null)
            {
                var doc = (Liquida)bs.Current;
                if (doc.IsSelected)
                {
                    if (doc.Ficha.DocumentoTipo != OOB.CtxCobrar.Enumerados.PorTipoDocumento.NtCredito)
                    {
                        var docLq = new LiquidarDocForm(doc);
                        docLq.LiquidacionOk += docLq_LiquidacionOk;
                        docLq.EditarDoc();
                    }
                }
            }
        }

        private void TB_IMPORTE_MEDIO_PAGO_Validating(object sender, CancelEventArgs e)
        {
            decimal mt = 0.0m;
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            var culture = CultureInfo.CreateSpecificCulture("es-ES");
            if (!Decimal.TryParse(TB_IMPORTE_MEDIO_PAGO.Text, style, culture, out mt))
            {
                errorProvider1.SetError(TB_IMPORTE_MEDIO_PAGO, "NO ES UN VALOR NUMERICO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_IMPORTE_MEDIO_PAGO, "");
            }
        }

        private void BT_GUARDAR_MEDIO_PAGO_Click(object sender, EventArgs e)
        {
            decimal mt = 0.0m;
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            var culture = CultureInfo.CreateSpecificCulture("es-ES");
            Decimal.TryParse(TB_IMPORTE_MEDIO_PAGO.Text, style, culture, out mt);

            if (mt <= 0)
            {
                return;
            }

            //var xmp = ListaMedios.Sum(t => t.Importe);
            //var xmr = Doc.Sum(t => t.MontoRecibido);
            //if ((xmp + mt) > xmr )
            //{
            //    return;
            //}

            var mp = (OOB.Empresa.MediosPago.Ficha)CB_MEDIO_PAGO.SelectedItem;
            if (mp == null)
            {
                return;
            }

            var rf = TB_REFERENCIA_MEDIO_PAGO.Text.Trim();
            var ent = (OOB.Bancos.Banco.Ficha)CB_BANCOS.SelectedItem;
            if (mp.Codigo == "02" || mp.Codigo == "03" || mp.Codigo == "04" || mp.Codigo == "05")
            {
                if (string.IsNullOrEmpty(rf))
                {
                    return;
                }
                if (ent == null)
                {
                    return;
                }
            }

            var medio = new MedioPago()
            {
                Importe = mt,
                Saldo=(_montoLiquidar-_montoPagado),
                Referencia = rf,
                Fecha = DTP_FECHA_MEDIO_PAGO.Value.Date,
                Medio = mp,
                Banco = (OOB.Bancos.Banco.Ficha)CB_BANCOS.SelectedItem
            };
            ListaMedios.Add(medio);
            LimpiarImporte();
            ActualizarMedioPagoImporte();
            ActualizarComision();
        }

        private void ActualizarMedioPagoImporte()
        {
            _montoPagado = decimal.Round(ListaMedios.Sum(t => t.Importe), 2, MidpointRounding.AwayFromZero);

            var mPago = _montoPagado;
            var mAPagar = _montoLiquidar;
            L_IMPORTE_MEDIO_PAGO.Text = mPago.ToString("n2");

            if (mAPagar > mPago)
            {
                var t = (mAPagar - mPago);
                L_DESC_PEND.Text = "Saldo Pendiente:";
                L_SALDO_PEND.Text = t.ToString("n2");
            }
            else
            {
                var t = (mPago - mAPagar);
                L_DESC_PEND.Text = "A Favor Cliente:";
                L_SALDO_PEND.Text = t.ToString("n2");
                _montoFavorCliente = t;
            }
        }

        private void LimpiarImporte()
        {
            TB_IMPORTE_MEDIO_PAGO.Text = "0.0";
            TB_REFERENCIA_MEDIO_PAGO.Text = "";
            CB_BANCOS.SelectedIndex = -1;
            CB_MEDIO_PAGO.SelectedIndex = -1;
            DTP_FECHA_MEDIO_PAGO.Value = DateTime.Now.Date;
        }

        private void CB_MEDIO_PAGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_REFERENCIA_MEDIO_PAGO.Enabled = false;
            CB_BANCOS.Enabled = false;

            var mp = (OOB.Empresa.MediosPago.Ficha)CB_MEDIO_PAGO.SelectedItem;
            if (mp == null)
            {
                return;
            }

            if (mp.Codigo == "02" || mp.Codigo == "03" || mp.Codigo == "04" || mp.Codigo == "05")
            {
                TB_REFERENCIA_MEDIO_PAGO.Enabled = true;
                CB_BANCOS.Enabled = true;
            }
        }

        private void BT_ELIMINAR_MEDIO_PAGO_Click(object sender, EventArgs e)
        {
            if (bsMedios.Current != null)
            {
                var mp = (MedioPago)bsMedios.Current;
                bsMedios.Remove(mp);
                ActualizarMedioPagoImporte();
                ActualizarComision();
            }
        }

        private void DTP_FECHA_MEDIO_PAGO_Validating(object sender, CancelEventArgs e)
        {
            if (DTP_FECHA_MEDIO_PAGO.Value.Date > FechaSistema)
            {
                errorProvider1.SetError(DTP_FECHA_MEDIO_PAGO, "FECHA INCORRECTA");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(DTP_FECHA_MEDIO_PAGO, "");
            }
        }

        private void DTP_FECHA_RELACION_Validating(object sender, CancelEventArgs e)
        {
            if (DTP_FECHA_RELACION.Value.Date > FechaSistema)
            {
                errorProvider1.SetError(DTP_FECHA_RELACION, "FECHA INCORRECTA");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(DTP_FECHA_RELACION, "");
            }
        }

        private void ActualizarComision()
        {
            var docLiq = Doc.Where(d => d.IsSelected && d.Ficha.DocumentoTipo != OOB.CtxCobrar.Enumerados.PorTipoDocumento.NtCredito).ToList();
            var Pagos = ListaMedios.ToList();
            ComisionesVend.Calculo(docLiq, Pagos);
            DGV_COMISIONES.DataSource = ComisionesVend.Comision.ToList();
        }

        private void BT_PROCESAR_PAGO_Click(object sender, EventArgs e)
        {
            if (VerificaProceso()) 
            {
                var msg = MessageBox.Show("Estas Seguro De Procesar El Pago ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == System.Windows.Forms.DialogResult.Yes) 
                {
                    ProcesarPago();
                }
            }
        }

        private bool VerificaProceso() 
        {
            var r = true;

            if (Doc == null || Doc.Count == 0) 
            {
                r = false;
            }

            if (_montoLiquidar < 0) 
            {
                r = false;
            }

            if (_montoPagado < _montoLiquidar)
            {
                r = false;
            }

            return r;
        }

        private void ProcesarPago()
        {
            var ficha = new OOB.CtxCobrar.Pago.Ficha();
            ficha.Vendedor = FichaVendedor;
            ficha.Cobrador = (OOB.Empresa.Cobradores.Ficha) CB_COBRADORES.SelectedItem;
            ficha.Usuario = FichaUsuario;

            ficha.ClienteId = DocumentoCxC.IdAutCliente;
            ficha.ClienteCiRif = DocumentoCxC.ClienteCiRif ;
            ficha.ClienteCodigo  = DocumentoCxC.ClienteCodigo ;
            ficha.ClienteRazonSocial = DocumentoCxC.ClienteNombre ;
            ficha.ClienteDirFiscal  = FichaCliente.DirFiscal ;
            ficha.ClienteTelefono = FichaCliente.Telefonos;

            ficha.FechaRecibo=DTP_FECHA_RELACION.Value.Date;
            ficha.MontoRecibo=_montoRecibo;
            ficha.MontoRecibido=_montoPagado ;
            ficha.MontoAnticipos = _montoAnticipos ;
            ficha.MontoDescuentos=_montoDsctos  ;
            ficha.MontoRetenciones=_montoRetenciones ;
            ficha.Notas=TB_NOTAS.Text;

            ficha.MontoFavorCliente = _montoFavorCliente;
            ficha.GenerarNotaCreditoMontoFavorCliente = true;

            ficha.DocLiquidar = new List<OOB.CtxCobrar.Pago.DocLiquida>();
            foreach (var doc in Doc.Where(d=>d.IsSelected)) 
            {
                var it = new OOB.CtxCobrar.Pago.DocLiquida()
                {
                    IdDoc=doc.Ficha.IdAuto,
                    NumeroDoc=doc.Ficha.DocumentoNro,
                    FechaDoc=doc.Ficha.FechaEmision ,
                    MontoDoc=(doc.Ficha.Total*doc.Ficha.Signo),
                    TipoDoc= doc.Ficha.DocumentoTipo ,
                    fechaRecepcion=doc.FechaRecepcionMercancia ,
                    ToleranciaDias=doc.Ficha.DiasTolerancia ,
                    ComisionPorc=doc.Ficha.ComisionCobranzaP ,
                    CastigoPorc=doc.Ficha.CastigoP ,
                    TipoOeracion= doc.MontoAbonado == doc.Ficha.Saldo ? 
                    OOB.CtxCobrar.Enumerados.PorTipoOpreacion.Pago: 
                    OOB.CtxCobrar.Enumerados.PorTipoOpreacion.Abono,
                    MontoAbonado = (doc.MontoAbonado*doc.Ficha.Signo),
                };
                ficha.DocLiquidar.Add(it);
            }

            ficha.MediosPago = new List<OOB.CtxCobrar.Pago.MedioPago>();
            foreach (var mp in ListaMedios) 
            {
                var it = new OOB.CtxCobrar.Pago.MedioPago()
                {
                   IdClave=mp.ClaveId,
                   MedioId= mp.Medio.IdAuto ,
                   MedioCodigo=mp.Medio.Codigo,
                   MedioDescripcion=mp.Medio.Nombre,
                   BancoId=mp.Banco.Id ,
                   BancoCodigo=mp.Banco.Codigo,
                   BancoDescripcion=mp.Banco.Nombre,
                   BancoNroCta=mp.Banco.Numero,
                   MontoRecibido=mp.Importe,
                   FechaMovimiento=mp.Fecha,
                   NroReferencia=mp.Referencia,
                };
                ficha.MediosPago.Add(it);
            }

            ficha.Retenciones = new List<OOB.CtxCobrar.Pago.RetencionIva>();
            foreach (var doc in Doc.Where(d => d.IsSelected && d.MontoPorRetencionIva>0))
            {

                var VentaId="";
                var VentaControl="";
                var VentaNumero="";
                var VentaFechaEmision=new DateTime();
                var VentaTipo=OOB.Venta.Enumerados.TipoDocumento.SinDefinir;
                var VentaTasaIva_1 = 0.0m;

                VentaId = doc.Ficha.IdAutoDocumentoVenta;
                VentaControl = doc.RetencionPorIva.NroControl ;
                VentaNumero = doc.RetencionPorIva.DocumentoNro ;
                VentaFechaEmision = doc.RetencionPorIva.FechaEmision ;
                VentaTasaIva_1 = doc.RetencionPorIva.TasaIva ;
                switch (doc.Ficha.DocumentoTipo)
                {
                    case OOB.CtxCobrar.Enumerados.PorTipoDocumento.Factura:
                        VentaTipo = OOB.Venta.Enumerados.TipoDocumento.Factura;
                        break;
                    case OOB.CtxCobrar.Enumerados.PorTipoDocumento.NtDebito:
                        VentaTipo = OOB.Venta.Enumerados.TipoDocumento.NDebito;
                        break;
                    case OOB.CtxCobrar.Enumerados.PorTipoDocumento.NtCredito:
                        VentaTipo = OOB.Venta.Enumerados.TipoDocumento.NCredito;
                        break;
                }

                var it = new OOB.CtxCobrar.Pago.RetencionIva()
                {
                    DocumentoId= VentaId  ,
                    DocumentoControl=VentaControl,
                    DocumentoNro=VentaNumero,
                    DocumentoFecha=VentaFechaEmision,
                    DocumentoTasaIva=VentaTasaIva_1,
                    DocumentoTipo=VentaTipo,
                    ComprobanteNro=doc.RetencionPorIva.ComprobanteNro ,
                    DeFecha=doc.RetencionPorIva.FechaRetencion ,
                    MontoBase=doc.RetencionPorIva.MontoBase,
                    MontoExcento =doc.RetencionPorIva.MontoExcento ,
                    MontoImpuesto =doc.RetencionPorIva.MontoImpuesto ,
                    MontoRetencion =doc.RetencionPorIva.MontoRetencion ,
                    MontoTotal=doc.RetencionPorIva.MontoTotal , 
                    TasaRetencion = doc.RetencionPorIva.TasaRetencion ,
                };
                ficha.Retenciones.Add(it);
            }

            ficha.Comisiones = new List<OOB.CtxCobrar.Pago.Comision>();
            foreach (var doc in ComisionesVend.Comision)
            {
                var it = new OOB.CtxCobrar.Pago.Comision()
                {
                    ClaveIdRelMedioPago=doc.Pago.ClaveId,
                    IdDocCxc=doc.DocLiquidar.Ficha.IdAuto,
                    FechaDocCxc=doc.DocLiquidar.FechaEmi ,
                    FechaRecepcionMercDocCxc=doc.FechaRecepcionMercancia ,
                    MontoDocCxc=doc.DocLiquidar.Ficha.Total,
                    ComisionPorc=doc.DocLiquidar.Ficha.ComisionCobranzaP ,
                    CastigoPorc=doc.DocLiquidar.Ficha.CastigoP,
                    BaseCalculo=doc.BaseCalculo ,
                    MontoRecibido=doc.SobreEsteMontoRecibido ,
                    ToleranciaDias= doc.DocLiquidar.Ficha.DiasTolerancia ,
                    TotalComision=doc.ComisionMonto,
                    IsCastigado=doc.AplicaCastigo ,
                    DiasTranscurridos=doc.DiasTranscurridos ,
                };
                ficha.Comisiones.Add(it);
            }

            var r01 = Globals.MyData.CtaxCobrar_Pago_Procesar(ficha);
            if (r01.Result == OOB.Resultado.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Helpers.Msg.AgregarOk();
            this.Close();
        }

    }

}