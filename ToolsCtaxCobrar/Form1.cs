using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ToolsCtaxCobrar
{

    public partial class Form1 : Form
    {

        private OOB.Empresa.DatosNegocio.Ficha DatosNegocio;
        private decimal Saldo;
        private int DocPendiente;
        private BindingSource bs;
        private BindingList<OOB.CtxCobrar.Documentos.Pendiente.Ficha> Doc;
        private OOB.CtxCobrar.Documentos.Pendiente.Filtro _filtro;
        //

        private BindingSource bsPago;
        private BindingList<OOB.CtxCobrar.Documentos.Pago.Ficha> Pagos;
        private OOB.CtxCobrar.Documentos.Pago.Filtro _filtroPago;
        private int _pagosEncontrados;


        public Form1()
        {
            InitializeComponent();

            bs = new BindingSource();
            bsPago = new BindingSource();
            Saldo = 0.0m;
            DocPendiente = 0;
            _filtro = new OOB.CtxCobrar.Documentos.Pendiente.Filtro();
            _filtroPago = new OOB.CtxCobrar.Documentos.Pago.Filtro();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CHB_PAGOS_DESDE.Checked = false;
            CHB_PAGOS_HASTA.Checked = false;
            DTP_PAGOS_DESDE.Enabled = false;
            DTP_PAGOS_HASTA.Enabled = false;

            CHB_DOC_DESDE.Checked = false;
            CHB_DOC_HASTA.Checked = false;
            DTP_DOC_DESDE.Enabled = false;
            DTP_DOC_HASTA.Enabled = false;

            L_SALDO.Text = "0.0";
            L_DOC_PENDIENTE.Text = "0";

            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.ReadOnly = true;
            DGV.DataBindingComplete+=DGV_DataBindingComplete;
            DGV.MouseClick+=DGV_MouseClick;

            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);
            var f2 = new Font("Serif", 8, FontStyle.Bold);

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "FechaEmision";
            c1.HeaderText = "Fecha/Emi";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "DocumentoTipoDesc";
            c2.HeaderText = "Tipo";
            c2.Visible = true;
            c2.Width = 40;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "DocumentoNro";
            c3.HeaderText = "Documento";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "FechaVencimiento";
            c4.HeaderText = "Fecha/Vto";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "ClienteNombre";
            c5.HeaderText = "Cliente";
            c5.Visible = true;
            c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f2;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Saldo";
            c6.HeaderText = "Saldo";
            c6.Visible = true;
            c6.Width = 120;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f2;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";
            c6.DefaultCellStyle.BackColor = Color.Yellow;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "Total";
            c7.HeaderText = "Importe";
            c7.Visible = true;
            c7.Width = 120;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f2;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c6);


            //

            L_PAGOS_ENCONTRADOS.Text = "0";

            DGV_PAGOS.AllowUserToAddRows = false;
            DGV_PAGOS.AutoGenerateColumns = false;
            DGV_PAGOS.AllowUserToResizeRows = false;
            DGV_PAGOS.AllowUserToResizeColumns = false;
            DGV_PAGOS.AllowUserToOrderColumns = false;
            DGV_PAGOS.ReadOnly = true;
            DGV_PAGOS.DataBindingComplete+=DGV_PAGOS_DataBindingComplete;

            var p1 = new DataGridViewTextBoxColumn();
            p1.DataPropertyName = "FechaEmision";
            p1.HeaderText = "Fecha/Emi";
            p1.Visible = true;
            p1.Width = 80;
            p1.HeaderCell.Style.Font = f;
            p1.DefaultCellStyle.Font = f1;

            var p2 = new DataGridViewTextBoxColumn();
            p2.DataPropertyName = "DocumentoNro";
            p2.HeaderText = "Documento";
            p2.Visible = true;
            p2.Width = 100;
            p2.HeaderCell.Style.Font = f;
            p2.DefaultCellStyle.Font = f1;

            var p3 = new DataGridViewTextBoxColumn();
            p3.DataPropertyName = "Importe";
            p3.HeaderText = "Importe";
            p3.Visible = true;
            p3.Width = 120;
            p3.HeaderCell.Style.Font = f;
            p3.DefaultCellStyle.Font = f2;
            p3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            p3.DefaultCellStyle.Format = "n2";
            p3.DefaultCellStyle.BackColor = Color.Yellow;

            var p4 = new DataGridViewTextBoxColumn();
            p4.DataPropertyName = "ClienteNombre";
            p4.HeaderText = "Cliente";
            p4.Visible = true;
            p4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            p4.HeaderCell.Style.Font = f;
            p4.DefaultCellStyle.Font = f2;

            var p5 = new DataGridViewTextBoxColumn();
            p5.DataPropertyName = "IsAnulado";
            p5.HeaderText = "";
            p5.Visible = false;
            p5.Width = 20;
            p5.HeaderCell.Style.Font = f;
            p5.DefaultCellStyle.Font = f2;

            DGV_PAGOS.Columns.Add(p2);
            DGV_PAGOS.Columns.Add(p1);
            DGV_PAGOS.Columns.Add(p3);
            DGV_PAGOS.Columns.Add(p4);
            DGV_PAGOS.Columns.Add(p5);


            //
            CargarData();
            this.WindowState = FormWindowState.Maximized;
        }

        private void DGV_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                int currentMouseOverRow = DGV.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem("Visualizar Documento", new EventHandler(VisualizarDocumento)));
                    m.MenuItems.Add(new MenuItem("Liquidar Documento", new EventHandler(LiquidarDocumewnto)));
                }
                m.Show(DGV, new Point(e.X, e.Y));
            }
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                row.DefaultCellStyle.ForeColor = (string)row.Cells[1].Value == "NCR" ? Color.Red : Color.Black;
            }
        }

        private void DGV_PAGOS_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV_PAGOS.Rows)
            {
                row.DefaultCellStyle.ForeColor = (bool)row.Cells[4].Value == true ? Color.Red : Color.Black;
            }
        }


        private void CargarData()
        {
            var r01 = Globals.MyData.Servidor_GetDatos();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var r02 = Globals.MyData.Empresa_DatosNegocio();
            if (r02.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }

            var r03 = Globals.MyData.Vendedor_Lista();
            if (r03.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return;
            }
           
            DatosNegocio = r02.Entidad;
            CB_VENDEDOR.DataSource = r03.Lista.OrderBy(v=>v.Codigo).ToList();
            CB_VENDEDOR.DisplayMember = "Nombre";
            CB_VENDEDOR.ValueMember = "IdAuto";
            LimpiarFiltros();
        }

        
        private void BT_LIQUIDACION_DOCUMENTOS_Click(object sender, EventArgs e)
        {
          //  Liquidar();
        }

        private void CargarDocumentos()
        {
            var r01 = Globals.MyData.CtaxCobrar_Documentos_Pendiente_Lista(_filtro);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var l = r01.Lista.OrderByDescending(d => d.FechaEmision).ToList();
            Doc = new BindingList<OOB.CtxCobrar.Documentos.Pendiente.Ficha>(l);
            bs.DataSource = Doc;
            DGV.DataSource = bs;
            ActualizarSaldo();
        }

        private void ActualizarSaldo()
        {
            Saldo = Doc.Sum(d => d.Saldo*d.Signo);
            DocPendiente = Doc.Count();;
            L_SALDO.Text = Saldo.ToString("N2");
            L_DOC_PENDIENTE.Text = DocPendiente.ToString();
        }
     
        private void LiquidarDocumewnto(object sender, EventArgs e)
        {
          //  Liquidar();
        }

        private void Liquidar()
        {
            if (bs.Current != null)
            {
                var fm = new LiquidacionDoc.LiquidarForm();
                fm.CargarDocumento((OOB.CtxCobrar.Documentos.Pendiente.Ficha)bs.Current);
                fm.ShowDialog();
            } 
        }

        private void VisualizarDocumento(object sender, EventArgs e)
        {
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            _filtro.Limpiar();
            if (CHB_DOC_DESDE.Checked)
            {
                _filtro.Desde = DTP_DOC_DESDE.Value.Date;
            }
            if (CHB_DOC_HASTA.Checked)
            {
                _filtro.Hasta = DTP_DOC_HASTA.Value.Date;
            }
            switch ((string)CB_TIPO_DOCUMENTO.SelectedItem)
            {
                case "Factura":
                    _filtro.PorTipoDocumento = OOB.CtxCobrar.Enumerados.PorTipoDocumento.Factura;
                    break;
                case "Nt/Debito":
                    _filtro.PorTipoDocumento = OOB.CtxCobrar.Enumerados.PorTipoDocumento.NtDebito;
                    break;
                case "Nt/Credito":
                    _filtro.PorTipoDocumento = OOB.CtxCobrar.Enumerados.PorTipoDocumento.NtCredito;
                    break;
            }
            _filtro.Cadena = TB_CADENA.Text;
            _filtro.Vendedor =(OOB.Vendedores.Vendedor.Ficha) CB_VENDEDOR.SelectedItem;
            CargarDocumentos();
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            CHB_DOC_DESDE.Checked = false;
            CHB_DOC_HASTA.Checked = false;
            DTP_DOC_DESDE.Value = DateTime.Now;
            DTP_DOC_HASTA.Value = DateTime.Now;

            CB_VENDEDOR.SelectedItem = null;
            CB_TIPO_DOCUMENTO.SelectedItem=null;
            TB_CADENA.Text = "";
            _filtro.Limpiar();
        }

        private void LINK_POR_VENDEDOR_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CB_VENDEDOR.SelectedItem = null;
        }

        private void LINK_POR_TIPO_DOCUMENTO_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CB_TIPO_DOCUMENTO.SelectedItem = null;
        }

        private void Menu_Calculadora_Click(object sender, EventArgs e)
        {
            Helpers.Utilitis.Calculadora();
        }

        private void Menu_Salida_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LINK_POR_CLIENTE_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TB_CADENA.Text="";
        }

        private void BT_BUSCAR_PAGOS_Click(object sender, EventArgs e)
        {
            _filtroPago.Limpiar();
            if (CHB_PAGOS_DESDE.Checked) 
            {
                _filtroPago.Desde = DTP_PAGOS_DESDE.Value.Date;
            }
            if (CHB_PAGOS_HASTA.Checked)
            {
                _filtroPago.Hasta = DTP_PAGOS_HASTA.Value.Date;
            }
            _filtroPago.Cadena = TB_PAGOS_CLIENTE.Text;
            CargarPagos();
        }

        private void CargarPagos()
        {
            var r01 = Globals.MyData.CtaxCobrar_Documentos_Pago_Lista(_filtroPago);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var l = r01.Lista.OrderByDescending(d => d.DocumentoNro).ToList();
            Pagos = new BindingList<OOB.CtxCobrar.Documentos.Pago.Ficha>(l);
            bsPago.DataSource = Pagos;
            DGV_PAGOS.DataSource = bsPago;
            ActualizarPagos();
        }

        private void ActualizarPagos()
        {
            _pagosEncontrados = Pagos.Count(); 
            L_PAGOS_ENCONTRADOS.Text = _pagosEncontrados.ToString();
        }

        private void BT_ANULAR_PAGO_Click(object sender, EventArgs e)
        {
          //  AnularPago();
        }

        private void AnularPago()
        {
            if (bsPago.Current != null)
            {
                var pag = (OOB.CtxCobrar.Documentos.Pago.Ficha)bsPago.Current;
                if (!pag.IsAnulado)
                {
                    var anularPago=new AnularPago.Anular();
                    anularPago.Anula(pag);
                }
            } 
        }
        
        private void CHB_PAGOS_DESDE_CheckedChanged(object sender, EventArgs e)
        {
            DTP_PAGOS_DESDE.Enabled = CHB_PAGOS_DESDE.Checked;
        }

        private void CHB_PAGOS_HASTA_CheckedChanged(object sender, EventArgs e)
        {
            DTP_PAGOS_HASTA.Enabled = CHB_PAGOS_HASTA.Checked;
        }

        private void BT_PAGOS_LIMPIAR_Click(object sender, EventArgs e)
        {
            TB_PAGOS_CLIENTE.Text = "";
            CHB_PAGOS_DESDE.Checked = false;
            CHB_PAGOS_HASTA.Checked = false;
            DTP_PAGOS_DESDE.Value = DateTime.Now;
            DTP_PAGOS_HASTA.Value = DateTime.Now;
        }

        private void LINK_PAGOS_CLIENTE_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TB_PAGOS_CLIENTE.Text = "";
        }

        private void BT_DOC_LIMPIAR_Click(object sender, EventArgs e)
        {
            if (Doc != null) 
            {
                Doc.Clear();
                ActualizarSaldo();
            }
        }

        private void CHB_DOC_DESDE_CheckedChanged(object sender, EventArgs e)
        {
            DTP_DOC_DESDE.Enabled = CHB_DOC_DESDE.Checked;
        }

        private void CHB_DOC_HASTA_CheckedChanged(object sender, EventArgs e)
        {
            DTP_DOC_HASTA.Enabled = CHB_DOC_HASTA.Checked;
        }


        Reports.Filtros frmFiltros;
        private int ReportGenerar;
        private void Menu_Reporte_CxC_Vendedores_ConsolidadoDocumento_Click(object sender, EventArgs e)
        {
            ReportGenerar = 1;
            frmFiltros = new Reports.Filtros(new ToolsCtaxCobrar.Reports.FiltroVendedor());
            frmFiltros.FiltrosOK += frmFiltros_FiltrosOK;
            frmFiltros.ShowDialog();
        }

        private void Menu_Reporte_CxC_Vendedores_Documentos_Click(object sender, EventArgs e)
        {
            ReportGenerar = 2;
            frmFiltros = new Reports.Filtros(new ToolsCtaxCobrar.Reports.FiltroVendedor());
            frmFiltros.FiltrosOK += frmFiltros_FiltrosOK;
            frmFiltros.ShowDialog();
        }

        private void Menu_Reporte_CxC_Vendedores_Comisiones_Click(object sender, EventArgs e)
        {
            ReportGenerar = 3;
            frmFiltros = new Reports.Filtros(new ToolsCtaxCobrar.Reports.FiltroVendedor());
            frmFiltros.FiltrosOK += frmFiltros_FiltrosOK;
            frmFiltros.ShowDialog();
        }

        private void Menu_CxC_Documentos_Pendientes_Click(object sender, EventArgs e)
        {
            ReportGenerar = 4;
            frmFiltros = new Reports.Filtros(new ToolsCtaxCobrar.Reports.FiltroCxC_DocumentosPend());
            frmFiltros.FiltrosOK += frmFiltros_FiltrosOK;
            frmFiltros.ShowDialog();
        }

        private void Menu_Reporte_Ventas_LibroVenta_Click(object sender, EventArgs e)
        {
            ReportGenerar = 5;
            frmFiltros = new Reports.Filtros(new ToolsCtaxCobrar.Reports.FiltroLibroVenta());
            frmFiltros.FiltrosOK += frmFiltros_FiltrosOK;
            frmFiltros.ShowDialog();
        }

        private void Menu_Reporte_Clientes_Maestro_Click(object sender, EventArgs e)
        {
            ReportGenerar = 6;
            frmFiltros = new Reports.Filtros(new ToolsCtaxCobrar.Reports.FiltroMaestroCliente());
            frmFiltros.FiltrosOK += frmFiltros_FiltrosOK;
            frmFiltros.ShowDialog();
        }

        private void frmFiltros_FiltrosOK(object sender, Reports.FiltroBusqueda e)
        {
            frmFiltros.Cerrar();
            if (ReportGenerar == 1) 
            {
                Reporte_CxC_Vendedores_Consolidado(e);
            }
            if (ReportGenerar == 2)
            {
                Reporte_CxC_Vendedores_Documentos(e);
            }
            if (ReportGenerar == 3) 
            {
                Reporte_CxC_Vendedores_Comisiones(e);
            }
            if (ReportGenerar == 4)
            {
                Reporte_CxC_Documentos_Pendientes(e);
            }
            if (ReportGenerar == 5)
            {
                Reporte_Venta_LibroVenta(e);
            }
            if (ReportGenerar == 6)
            {
                Reporte_Cliente_Maestro(e);
            }
        }

        private void Reporte_Cliente_Maestro(Reports.FiltroBusqueda filt)
        {
            var filtro = new OOB.Reportes.CtaxCobrar.Vendedores.Filtro();
            filtro.Vendedor = filt.Vendedor;

            var r01 = Globals.MyData.Reportes_CtxCobrar_Cliente_Maestro(filtro);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Globals.MyReports.CtaxCobrar_Clientes_Maestro (r01.Lista);
        }

        private void Reporte_Venta_LibroVenta(Reports.FiltroBusqueda filt)
        {
            var filtro = new OOB.Reportes.CtaxCobrar.Vendedores.Filtro();
            filtro.Desde = filt.Desde;
            filtro.Hasta = filt.Hasta;

            var r01 = Globals.MyData.Reportes_CtxCobrar_Venta_LibroVenta(filtro);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Globals.MyReports.CtaxCobrar_Ventas_LibroVenta(r01.Lista);
        }

        void Reporte_CxC_Documentos_Pendientes(Reports.FiltroBusqueda filt)
        {
            var filtro = new OOB.Reportes.CtaxCobrar.Vendedores.Filtro();
            filtro.Desde = filt.Desde;
            filtro.Hasta = filt.Hasta;
            filtro.Vendedor = filt.Vendedor;

            var r01 = Globals.MyData.Reportes_CtxCobrar_Documentos_Pendientes(filtro);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Globals.MyReports.CtaxCobrar_Documentos_Pendientes(r01.Lista);
        }

        private void Reporte_CxC_Vendedores_Consolidado(Reports.FiltroBusqueda filt)
        {
            var filtro = new OOB.Reportes.CtaxCobrar.Vendedores.Filtro();
            filtro.Desde = filt.Desde;
            filtro.Hasta = filt.Hasta;
            filtro.Vendedor = filt.Vendedor;

            var r01 = Globals.MyData.Reporte_CtaxCobrar_Vendedores_Consolidado(filtro);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    var tt = r01.Lista.GroupBy(g => new { key = g.VendedorId, codigo = g.VendedorCodigo, nombre=g.VendedorNombre}).Select(r =>
                        new OOB.Reportes.CtaxCobrar.Vendedores.Consolidado()
                        {
                            VendedorCodigo=r.Key.codigo,
                            VendedorId = r.Key.key,
                            VendedorNombre=r.Key.nombre,
                            MontoBaseVenta = r.Sum(t => t.MontoBaseVenta),
                            MontoExcentoVenta = r.Sum(t => t.MontoExcentoVenta),
                            MontoImpuestoVenta = r.Sum(t => t.MontoImpuestoVenta),
                            MontoBaseNcr = r.Sum(t => t.MontoBaseNcr),
                            MontoImpuestoNcr = r.Sum(t => t.MontoImpuestoNcr),
                            MontoTotalNcr = r.Sum(t => t.MontoTotalNcr),
                            MontoTotalVenta = r.Sum(t => t.MontoTotalVenta),
                        }).ToList();

                    Globals.MyReports.CtaxCobrar_Vendedores_Consolidado(tt);
                }
            }
        }

        private void Reporte_CxC_Vendedores_Documentos(Reports.FiltroBusqueda filt)
        {
            var filtro = new OOB.Reportes.CtaxCobrar.Vendedores.Filtro();
            filtro.Desde = filt.Desde;
            filtro.Hasta = filt.Hasta;
            filtro.Vendedor = filt.Vendedor;

            var r01 = Globals.MyData.Reporte_CtaxCobrar_Vendedores_Documentos(filtro);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                   Globals.MyReports.CtaxCobrar_Vendedores_Documentos(r01.Lista);
                }
            }
        }

        private void Reporte_CxC_Vendedores_Comisiones(Reports.FiltroBusqueda filt)
        {
            var filtro = new OOB.Reportes.CtaxCobrar.Vendedores.Filtro();
            filtro.Desde = filt.Desde;
            filtro.Hasta = filt.Hasta;
            filtro.Vendedor = filt.Vendedor;

            var r01 = Globals.MyData.Reporte_CtaxCobrar_Vendedores_ComisionesPagar(filtro);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    Globals.MyReports.CtaxCobrar_Vendedores_Comisiones(r01.Lista);
                }
            }
        }
      
    }

}