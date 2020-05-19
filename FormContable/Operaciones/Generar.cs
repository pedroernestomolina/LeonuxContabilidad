using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.Operaciones
{

    public partial class Generar : Form
    {

        enum Guardar { Preview = 1, Contabilizado }
        enum Modo { AgregarFicha = 1, EditarFicha, ExportarFicha };


        private OOB.Contable.Asiento.Ficha AsientoPreview;
        private BindingSource bs;
        private BindingList<OOB.Contable.Asiento.Generar.Ficha> Asientos;
        private BindingSource bsDet;
        private BindingList<OOB.Contable.Asiento.Generar.FichaDetalle> AsientosDet;
        private bool CONTABILIZAR_ISOK = false;
        private OOB.Contable.Periodo.Ficha Periodo;
        private List<OOB.Contable.Asiento.Generar.Resumen> grup;
        private Filtros.Filt filtVenta;
        private FiltroCompra.Filt filtCompra;
        private FiltroCxP.Filt filtCxP;
        private FiltroInv.Filt filtInv ;
        private FiltroBanco.Filt filtBanco;
        private FiltroCxC.Filt filtCxC; 
        private Guardar GuardarComo;
        private int IdAsientoCargar;
        private bool Procesado;
        private Modo ModoFicha;
        private List<Sucursal> _sucursales;


        public Generar(OOB.Contable.Periodo.Ficha periodo)
        {
            InitializeComponent();

            this.Periodo = periodo;
            bs = new BindingSource();
            bs.CurrentChanged += bs_CurrentChanged;
            bsDet = new BindingSource();
            GuardarComo = Guardar.Contabilizado;

            _sucursales=new List<Sucursal>(){};
            _sucursales.Add(new Sucursal(){ Id="01", Descripcion="PRINCIPAL" });
            _sucursales.Add(new Sucursal(){ Id="02", Descripcion="PARAPARAL" });
            _sucursales.Add(new Sucursal(){ Id="03", Descripcion="AGUA DORADA" });
            _sucursales.Add(new Sucursal(){ Id="04", Descripcion="NAGUANAGUA" });
            _sucursales.Add(new Sucursal() { Id = "05", Descripcion = "ALM SUC 05" });
        }

        public void Nuevo()
        {
            ModoFicha = Modo.AgregarFicha;
        }

        public void Editar(int idAsiento)
        {
            ModoFicha = Modo.EditarFicha;
            this.IdAsientoCargar  = idAsiento;
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            if (AsientosDet != null)
            {
                Limpiar_AsientoDetalles();
            }
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            if (CB_MODULO_GENERAR.SelectedIndex != -1)
            {
                var msg = MessageBox.Show("Iniciar Proceso ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == System.Windows.Forms.DialogResult.Yes)
                {
                    Limpiar();
                    GenerarDoc();
                }
            }
        }

        private void Limpiar()
        {
            if (Asientos != null) { Asientos.Clear(); }
            if (AsientosDet != null) { AsientosDet.Clear(); }

            L_TDOC.Text = "0";
            L_TOK.Text = "0";
            L_TNOOK.Text = "0";

            L_DEBE.Text = "0.0";
            L_HABER.Text = "0.0";
            L_DIFERENCIA.Text = "0.0";

            L_R_DEBE.Text = "0.0";
            L_R_HABER.Text = "0.0";
            L_R_DIFERENCIA.Text = "0.0";

            DGV_RESUMEN.DataSource = null;

            CONTABILIZAR_ISOK = false;
        }

        async private void GenerarDoc()
        {

            P_PROCESAR.Enabled = false;

            OOB.Contable.Asiento.Generar.Enumerados.ModuloGenerar modulo = OOB.Contable.Asiento.Generar.Enumerados.ModuloGenerar.SinDefinir;
            switch (CB_MODULO_GENERAR.SelectedIndex)
            {
                case 0:
                    modulo = OOB.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Inventario;
                    break;
                case 1:
                    modulo = OOB.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Ventas;
                    break;
                case 2:
                    modulo = OOB.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Compras;
                    break;
                case 4:
                    modulo = OOB.Contable.Asiento.Generar.Enumerados.ModuloGenerar.PorPagar;
                    break;
                case 3:
                    modulo = OOB.Contable.Asiento.Generar.Enumerados.ModuloGenerar.PorCobrar;
                    break;
                case 5:
                    modulo = OOB.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Bancos;
                    break;
            };

            var filt = new OOB.Contable.Asiento.Generar.Filtro()
            {
                Desde = DTP_DESDE.Value.Date,
                Hasta = DTP_HASTA.Value.Date,
                Modulo = modulo,
            };

            if (filtBanco != null)
            {
                var Banco = new OOB.Contable.Asiento.Generar.FiltroBanco();
                if (filtBanco.TipoMovimiento != OOB.Bancos.Enumerados.TipMovimiento.SinDefinir) 
                {
                    Banco.TipoMovimiento = filtBanco.TipoMovimiento;
                }
                filt.Banco = Banco;
            }

            if (filtVenta != null) 
            {
                var codSucursal = "";
                if (filtVenta.Sucursal != null)
                {
                    codSucursal = filtVenta.Sucursal.Id;
                }
                var Venta = new OOB.Contable.Asiento.Generar.FiltroVenta()
                {
                    CodSucursal=codSucursal,
                    TipoDocumento = filtVenta.TipoDocumento,
                    CondicionPago = filtVenta.CondicionPago,
                    DenominacionFiscal = filtVenta.DenominacionFiscal,
                    SerialFiscal = filtVenta.SerialFiscal,
                };
                filt.Venta = Venta;
            }

            if (filtCompra != null)
            {
                var mesR = -1;
                var anoR = -1;
                var codSucursal="";
                if (filtCompra.MesRelacion != -1) { mesR = filtCompra.MesRelacion + 1; }
                if (filtCompra.AnoRelacion != -1) { anoR = (2015+filtCompra.AnoRelacion); }
                if (filtCompra.Sucursal !=null)
                {
                    codSucursal=filtCompra.Sucursal.Id;
                }

                var Compra = new OOB.Contable.Asiento.Generar.FiltroCompra()
                {
                    TipoDocumento = filtCompra.TipoDocumento,
                    Concepto = filtCompra.Concepto,
                    Proveedor = filtCompra.Proveedor,
                    MesRelacion = mesR,
                    AnoRelacion = anoR,
                    CodigoSucursal=codSucursal,
                };
                filt.Compra = Compra;
            }
            else 
            {
                filt.Compra = new OOB.Contable.Asiento.Generar.FiltroCompra();
            }

            if (filtCxP != null)
            {
                var CxP = new OOB.Contable.Asiento.Generar.FiltroCxP()
                {
                    TipoDocumento = filtCxP.TipoDocumento,
                    Concepto = filtCxP.Concepto,
                    Proveedor = filtCxP.Proveedor
                };
                filt.CxP = CxP;
            }
            else 
            {
                filt.CxP = new OOB.Contable.Asiento.Generar.FiltroCxP();
            }

            if (filtInv != null)
            {
                filt.Inventario = new OOB.Contable.Asiento.Generar.FiltroInventario();
                if (filtInv.TipoDocumento != null)
                {
                    switch (filtInv.TipoDocumento.Trim().ToUpper())
                    {
                        case "DESCARGOS":
                            filt.Inventario.TipoDocumento = OOB.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.Descargo;
                            break;
                        case "AJUSTE POR CARGOS":
                            filt.Inventario.TipoDocumento = OOB.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.AjustePorCargo;
                            break;
                        case "AJUSTE POR DESCARGOS":
                            filt.Inventario.TipoDocumento = OOB.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.AjustePorDescargo;
                            break;
                        case "AJUSTE":
                            filt.Inventario.TipoDocumento = OOB.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.Ajuste;
                            break;
                        case "CARGOS":
                            filt.Inventario.TipoDocumento = OOB.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.Cargo;
                            break;
                    }
                }
            }
            else 
            {
                filt.Inventario = new OOB.Contable.Asiento.Generar.FiltroInventario();
            }
           
            progressBar1.Style = ProgressBarStyle.Marquee;
            var r01 = await Globals.MyData.Asiento_Generar(filt);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                P_PROCESAR.Enabled = true;
                progressBar1.Style = ProgressBarStyle.Blocks;
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            progressBar1.Style = ProgressBarStyle.Blocks;

            if (CB_MODULO_GENERAR.SelectedIndex == 0)
            {
                Asientos = new BindingList<OOB.Contable.Asiento.Generar.Ficha>(r01.Lista.OrderBy(d => d.DocumentoRef).ToList());
            }
            if (CB_MODULO_GENERAR.SelectedIndex == 1)
            {
                Asientos = new BindingList<OOB.Contable.Asiento.Generar.Ficha>(r01.Lista.OrderBy(d => d.DocumentoRef).ToList());
            }
            if (CB_MODULO_GENERAR.SelectedIndex == 2)
            {
                Asientos = new BindingList<OOB.Contable.Asiento.Generar.Ficha>(r01.Lista.OrderBy(d => d.FechaDoc).ToList());
            }
            if (CB_MODULO_GENERAR.SelectedIndex == 3)
            {
                Asientos = new BindingList<OOB.Contable.Asiento.Generar.Ficha>(r01.Lista.OrderBy(d => d.FechaDoc).ToList());
            }
            if (CB_MODULO_GENERAR.SelectedIndex == 4)
            {
                Asientos = new BindingList<OOB.Contable.Asiento.Generar.Ficha>(r01.Lista.OrderBy(d => d.FechaDoc).ToList());
            }
            if (CB_MODULO_GENERAR.SelectedIndex == 5)
            {
                Asientos = new BindingList<OOB.Contable.Asiento.Generar.Ficha>(r01.Lista.OrderBy(d => d.FechaDoc).ToList());
            }

            bs.DataSource = Asientos;
            DGV.DataSource = bs;

            AsientosDet = new BindingList<OOB.Contable.Asiento.Generar.FichaDetalle>();
            bsDet.DataSource = AsientosDet;
            DGV_DETALLE.DataSource = bsDet;

            ActualizarTotales();
            tabControl1.SelectedIndex = 1;
            P_PROCESAR.Enabled = true;
        }

        private void Generar_Load(object sender, EventArgs e)
        {
            CB_MODULO_GENERAR.SelectedIndex = 0;

            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.ReadOnly = true;
           // DGV.CellFormatting += DGV_CellFormatting;

            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);
            var c0 = new DataGridViewTextBoxColumn();
            c0.DataPropertyName = "DocumentoRef";
            c0.HeaderText = "Documento";
            c0.Visible = true;
            c0.Width = 100;
            c0.HeaderCell.Style.Font = f;
            c0.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "FechaDoc";
            c2.HeaderText = "Fecha";
            c2.Visible = true;
            c2.Width = 90;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "DescripcionDoc";
            c3.HeaderText = "Descripción";
            c3.Visible = true;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewCheckBoxColumn();
            c4.DataPropertyName = "Incluir";
            c4.Name = "";
            c4.HeaderText = "";
            c4.Width = 30;
            c4.Visible = true;

            var c5 = new DataGridViewImageColumn();
            c5.Width = 30;
            c5.Visible = true;
            c5.Image = Properties.Resources.ver;

            var c6 = new DataGridViewCheckBoxColumn();
            c6.DataPropertyName = "IsOk";
            c6.Name = "IsOk";
            c6.HeaderText = "Es OK";
            c6.Width = 60;
            c6.Visible = false;

            DGV.Columns.Add(c0);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);

            //DETALLES
            DGV_DETALLE.AllowUserToAddRows = false;
            DGV_DETALLE.AutoGenerateColumns = false;
            DGV_DETALLE.AllowUserToResizeRows = false;
            DGV_DETALLE.AllowUserToResizeColumns = false;
            DGV_DETALLE.AllowUserToOrderColumns = false;
            DGV_DETALLE.ReadOnly = true;

            var c1d = new DataGridViewTextBoxColumn();
            c1d.DataPropertyName = "CodigoCta";
            c1d.HeaderText = "Código";
            c1d.Visible = true;
            c1d.Width = 100;

            var c2d = new DataGridViewTextBoxColumn();
            c2d.DataPropertyName = "DescripcionCta";
            c2d.HeaderText = "Descripción";
            c2d.Visible = true;
            c2d.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var fd = new Font("Serif", 10, FontStyle.Bold);
            var c3d = new DataGridViewTextBoxColumn();
            c3d.DefaultCellStyle.BackColor = Color.Blue;
            c3d.DataPropertyName = "MontoDebe";
            c3d.HeaderText = "Debe";
            c3d.Visible = true;
            c3d.Width = 150;
            c3d.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3d.DefaultCellStyle.ForeColor = Color.White;
            c3d.DefaultCellStyle.Font = fd;
            c3d.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3d.DefaultCellStyle.Format = "n2";

            var c4d = new DataGridViewTextBoxColumn();
            c4d.DefaultCellStyle.BackColor = Color.Red;
            c4d.DataPropertyName = "MontoHaber";
            c4d.HeaderText = "Haber";
            c4d.Visible = true;
            c4d.Width = 150;
            c4d.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4d.DefaultCellStyle.ForeColor = Color.White;
            c4d.DefaultCellStyle.Font = fd;
            c4d.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4d.DefaultCellStyle.Format = "n2";

            DGV_DETALLE.Columns.Add(c1d);
            DGV_DETALLE.Columns.Add(c2d);
            DGV_DETALLE.Columns.Add(c3d);
            DGV_DETALLE.Columns.Add(c4d);

            L_TDOC.Text = "0";
            L_TOK.Text = "0";
            L_TNOOK.Text = "0";

            //CTAS RESUMEN
            DGV_RESUMEN.AllowUserToAddRows = false;
            DGV_RESUMEN.AutoGenerateColumns = false;
            DGV_RESUMEN.AllowUserToResizeRows = false;
            DGV_RESUMEN.AllowUserToResizeColumns = false;
            DGV_RESUMEN.AllowUserToOrderColumns = false;
            DGV_RESUMEN.ReadOnly = true;

            var c1r = new DataGridViewTextBoxColumn();
            c1r.DataPropertyName = "CodigoCta";
            c1r.HeaderText = "Código";
            c1r.Visible = true;
            c1r.Width = 100;

            var c2r = new DataGridViewTextBoxColumn();
            c2r.DataPropertyName = "DescripcionCta";
            c2r.HeaderText = "Descripción";
            c2r.Visible = true;
            c2r.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var fr = new Font("Serif", 10, FontStyle.Bold);
            var c3r = new DataGridViewTextBoxColumn();
            c3r.DefaultCellStyle.BackColor = Color.Blue;
            c3r.DataPropertyName = "MontoDebe";
            c3r.HeaderText = "Debe";
            c3r.Visible = true;
            c3r.Width = 150;
            c3r.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3r.DefaultCellStyle.ForeColor = Color.White;
            c3r.DefaultCellStyle.Font = fr;
            c3r.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3r.DefaultCellStyle.Format = "n2";

            var c4r = new DataGridViewTextBoxColumn();
            c4r.DefaultCellStyle.BackColor = Color.Red;
            c4r.DataPropertyName = "MontoHaber";
            c4r.HeaderText = "Haber";
            c4r.Visible = true;
            c4r.Width = 150;
            c4r.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4r.DefaultCellStyle.ForeColor = Color.White;
            c4r.DefaultCellStyle.Font = fr;
            c4r.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4r.DefaultCellStyle.Format = "n2";

            DGV_RESUMEN.Columns.Add(c1r);
            DGV_RESUMEN.Columns.Add(c2r);
            DGV_RESUMEN.Columns.Add(c3r);
            DGV_RESUMEN.Columns.Add(c4r);

            if (ModoFicha== Modo.EditarFicha)
            {
                CargarData(IdAsientoCargar);
            }
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                row.DefaultCellStyle.ForeColor = (bool)row.Cells["IsOk"].Value ? Color.Black : Color.White;
                row.DefaultCellStyle.BackColor = (bool)row.Cells["IsOk"].Value ? Color.White : Color.Red;
            }
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var detalle = (OOB.Contable.Asiento.Generar.Ficha)bs.Current;
                AsientosDet.Clear();
                foreach (var det in detalle.Detalles)
                {
                    AsientosDet.Add(det);
                }

                L_DEBE.Text = detalle.Detalles.Sum(d => d.MontoDebe).ToString("n2");
                L_HABER.Text = detalle.Detalles.Sum(d => d.MontoHaber).ToString("n2");
                L_DIFERENCIA.Text = detalle.Detalles.Sum(d => d.Diferencia).ToString("n2");
            }
        }

        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            DTP_HASTA.Value = DTP_DESDE.Value;
        }

        private void DGV_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                //m.MenuItems.Add(new MenuItem("Cut"));
                //m.MenuItems.Add(new MenuItem("Copy"));
                //m.MenuItems.Add(new MenuItem("Paste"));

                int currentMouseOverRow = DGV.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    //m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                    m.MenuItems.Add(new MenuItem("Ver Documento", new EventHandler(VerDocumento)));
                }
                m.Show(DGV, new Point(e.X, e.Y));
            }
        }

        private void DGV_RESUMEN_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                int currentMouseOverRow = DGV_RESUMEN.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem("Exportar Asiento", new EventHandler(ExportarAsientoResumen)));
                }
                m.Show(DGV_RESUMEN, new Point(e.X, e.Y));
            }
        }

        private void DGV_DETALLE_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                int currentMouseOverRow = DGV_DETALLE.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem("Exportar Asiento", new EventHandler(ExportarAsientoDetalle)));
                }
                m.Show(DGV_DETALLE, new Point(e.X, e.Y));
            }
        }


        private void VerDocumento(object sender, EventArgs e)
        {
            var doc = (OOB.Contable.Asiento.Generar.Ficha)bs.Current;
            switch (doc.TipoDoc)
            {
                case OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento.Venta:
                    VisualizarDocVenta(doc.Id);
                    break;
                case OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento.Compra :
                    VisualizarDocCompra(doc.Id);
                    break;
                case OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento.RetencionIva:
                    VisualizarDocRetencionIva (doc.Id);
                    break;
                case OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento.RetencionIslr:
                    VisualizarDocRetencionIslr(doc.Id);
                    break;
                case OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento.Pago:
                    VisualizarDocPago(doc.Id);
                    break;
                case OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento.Cobro:
                    VisualizarDocCobro(doc.Id);
                    break;
                case OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjuste:
                    VisualizarDocInv(doc.Id);
                    break;
                case OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjustePorCargo:
                    VisualizarDocInv(doc.Id);
                    break;
                case OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjustePorDescargo:
                    VisualizarDocInv(doc.Id);
                    break;
                case OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAutoConsumo:
                    VisualizarDocInv(doc.Id);
                    break;
                case OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvCargo:
                    VisualizarDocInv(doc.Id);
                    break;
                case OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento.MovBanco:
                    VisualizarDocBanco(doc.Id);
                    break;
            }
        }

        private void VisualizarDocBanco(string doc)
        {
            var visualizar = new Banco.Movimiento.VisualizarDocumento();
            visualizar.CargarDocumento(doc);
        }

        private void VisualizarDocInv(string doc)
        {
            var visualizar = new Producto.Movimiento.VisualizarDocumento();
            visualizar.CargarDocumento(doc);
        }

        private void VisualizarDocCobro(string doc)
        {
            var visualizar = new CtxCobrar.Recibo.VisualizarDocumento();
            visualizar.CargarDocumento(doc);
        }

        private void VisualizarDocPago(string doc)
        {
            var visualizar = new CtxPagar.Recibo.VisualizarDocumento ();
            visualizar.CargarDocumento(doc);
        }

        private void VisualizarDocRetencionIslr(string doc)
        {
            var visualizar = new Compras.RetencionIslr.VisualizarDocumento();
            visualizar.CargarDocumento(doc);
        }

        private void VisualizarDocRetencionIva(string doc)
        {
            var visualizar = new Compras.RetencionIva.VisualizarDocumento();
            visualizar.CargarDocumento(doc);
        }

        private void VisualizarDocCompra(string doc)
        {
            var visualizar = new  Compras.Compra.VisualizarDocumento();
            visualizar.CargarDocumento(doc);
        }

        private void VisualizarDocVenta(string doc)
        {
            var visualizar = new Venta.VisualizarDocumento();
            visualizar.CargarDocumento(doc);
        }

        private void MenuCalculadora_Click(object sender, EventArgs e)
        {
            Calculadora();
        }

        Contabilizar fCont;
        private void ContabilizarAsiento(int prev=0)
        {
            fCont = new Contabilizar(prev);
            fCont.EncabezadoOk += fCont_EncabezadoOk;
            fCont.ShowDialog();
        }

        private void fCont_EncabezadoOk(object sender, Contabilizar.DatosEncabezado e)
        {
            fCont.Close();

            var mdebe = grup.Sum(g => g.MontoDebe);
            var mhaber = grup.Sum(g => g.MontoHaber);

            var ficha = new OOB.Contable.Asiento.Generar.Insertar();
            ficha.AsientoPreview = AsientoPreview;
            ficha.Modulo = (OOB.Contable.Asiento.Generar.Enumerados.ModuloGenerar)CB_MODULO_GENERAR.SelectedIndex;
            ficha.Descripcion = e.Descripcion;
            ficha.Desde = DTP_DESDE.Value;
            ficha.Hasta = DTP_HASTA.Value;
            ficha.Periodo = Periodo;
            ficha.TipoAsiento = e.TipoAsiento;
            ficha.TipoDocumento = e.TipoDoc;
            ficha.EstaProcesado = Procesado;
            ficha.Data = (List<OOB.Contable.Asiento.Generar.Ficha>)Asientos.Where(f => f.Incluir).ToList();
            if (Procesado)
            {
                ficha.Importe = grup.Sum(g => g.MontoDebe);
            }
            else
            {
                ficha.Importe = mdebe>mhaber? mdebe:mhaber ;
            }
            ficha.Ctas = grup;

            var r01 = Globals.MyData.Asiento_Insertar_Integracion(ficha);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Helpers.Msg.AgregarOk();
            Inicializar();
        }
     
        private void Salir()
        {
            Close();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void MenuLimpiar_Click(object sender, EventArgs e)
        {
            OpcionLimpiar();
        }

        private void OpcionLimpiar()
        {
            var msg = MessageBox.Show("Limpiar Datos Obtenidos ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                Inicializar();
            }
        }

        private void Inicializar()
        {
            Limpiar();
            DTP_DESDE.Value = DateTime.Now.Date;
            DTP_HASTA.Value = DateTime.Now.Date;
            CB_MODULO_GENERAR.SelectedIndex = -1;
            tabControl1.SelectedIndex = 0;
        }

        private void MenuAdministradorIntegraciones_Click(object sender, EventArgs e)
        {
            ManagerIntegraciones();
        }

        private void ManagerIntegraciones()
        {
            var fManager = new Integraciones.Manager();
            fManager.ShowDialog();
        }

        private void BT_ELIMINAR_Click(object sender, EventArgs e)
        {
            EliminarDocumento();
        }

        private void EliminarDocumento()
        {
            if (bs.Current != null)
            {
                var doc = (OOB.Contable.Asiento.Generar.Ficha)bs.Current;
                var msg = MessageBox.Show("Incluir Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == System.Windows.Forms.DialogResult.Yes)
                {
                    doc.Incluir = true;
                }
                else if (msg== System.Windows.Forms.DialogResult.No)
                {
                    doc.Incluir = false;
                }
                DGV.Refresh();
                ActualizarTotales();
            }
        }

        private void ActualizarTotales()
        {
            CONTABILIZAR_ISOK = false;

            if (Asientos != null)
            {
                var list = Asientos.Where(f=>f.Incluir).ToList();

                L_TDOC.Text = list.Count().ToString().Trim();
                L_TOK.Text = list.Count(d => d.IsOk).ToString().Trim();
                L_TNOOK.Text = list.Count(d => d.IsOk == false).ToString().Trim();

                var det = new List<OOB.Contable.Asiento.Generar.FichaDetalle>();
                foreach (var ent in list)
                {
                    foreach (var entdet in ent.Detalles)
                    {
                        det.Add(entdet);
                    }
                }

                grup = det.GroupBy(d => new { id = d.IdCta, cta = d.CodigoCta, desCta = d.DescripcionCta, natCta=d.Naturaleza  })
                    .Select(g => new OOB.Contable.Asiento.Generar.Resumen()
                    { 
                        IdCta = g.Key.id, 
                        CodigoCta = g.Key.cta, 
                        DescripcionCta = g.Key.desCta, 
                        Naturaleza=g.Key.natCta,
                        MontoDebe = g.Sum(t => t.MontoDebe * t.Signo), 
                        MontoHaber = g.Sum(t => t.MontoHaber * t.Signo)
                    })
                    .OrderBy(o => o.CodigoCta)
                    .ToList();

                var mdebe = grup.Sum(d => d.MontoDebe);
                var mhaber = grup.Sum(d => d.MontoHaber);
                var difer = mdebe - mhaber;

                L_R_DEBE.Text = mdebe.ToString("n2");
                L_R_HABER.Text = mhaber.ToString("n2");
                L_R_DIFERENCIA.Text = difer.ToString("n2");

                DGV_RESUMEN.DataSource = grup;

                if (difer == 0) 
                {
                    CONTABILIZAR_ISOK = true;
                }
            }
        }

        private void BT_CALCULADORA_Click(object sender, EventArgs e)
        {
            Calculadora();
        }

        private void Calculadora()
        {
            Helpers.Utilitis.Calculadora();
        }

        private void BT_MAS_FILTROS_Click(object sender, EventArgs e)
        {
            if (CB_MODULO_GENERAR.SelectedIndex == 1)
            {
                FiltrosParaVenta(); 
            }
            if (CB_MODULO_GENERAR.SelectedIndex == 2)
            {
                FiltrosParaCompra();
            }
            if (CB_MODULO_GENERAR.SelectedIndex == 4)
            {
                FiltrosParaCxP();
            }
            if (CB_MODULO_GENERAR.SelectedIndex == 0)
            {
                FiltrosParaInventario();
            }
            if (CB_MODULO_GENERAR.SelectedIndex == 5)
            {
                FiltrosParaBanco();
            }
            if (CB_MODULO_GENERAR.SelectedIndex == 3)
            {
                FiltrosParaCxC();
            }

        }

        private void FiltrosParaBanco()
        {
            if (filtBanco == null)
            {
                filtBanco = new FiltroBanco.Filt();
            }

            var fMasFiltros = new FiltroBanco(filtBanco);
            fMasFiltros.FiltrosBancoOk +=fMasFiltros_FiltrosBancoOk; 
            fMasFiltros.ShowDialog();
        }

        private void fMasFiltros_FiltrosBancoOk(object sender, FiltroBanco.Filt e)
        {
            filtBanco = e;
        }

        private void FiltrosParaInventario()
        {
            if (filtInv == null)
            {
                filtInv = new FiltroInv.Filt();
            }

            var fMasFiltros = new FiltroInv(filtInv);
            fMasFiltros.FiltrosInvOk+=fMasFiltros_FiltrosInvOk; ;
            fMasFiltros.ShowDialog();
        }

        private void fMasFiltros_FiltrosInvOk(object sender, FiltroInv.Filt e)
        {
            filtInv = e;
        }

        private void FiltrosParaCxP()
        {
            if (filtCxP== null)
            {
                filtCxP = new FiltroCxP.Filt();
            }

            var fMasFiltros = new FiltroCxP(filtCxP);
            fMasFiltros.FiltrosCxPOk+=fMasFiltros_FiltrosCxPOk;
            fMasFiltros.ShowDialog();
        }

        private void fMasFiltros_FiltrosCxPOk(object sender, FiltroCxP.Filt e)
        {
            filtCxP = e;
        }

        private void FiltrosParaCxC()
        {
            if (filtCxC == null)
            {
                filtCxC = new FiltroCxC.Filt();
            }

            var fMasFiltros = new FiltroCxC(filtCxC);
            fMasFiltros.FiltrosCxCOk += fMasFiltros_FiltrosCxCOk;
            fMasFiltros.ShowDialog();
        }

        private void fMasFiltros_FiltrosCxCOk(object sender, FiltroCxC.Filt e)
        {
            filtCxC = e;
        }

        private void FiltrosParaCompra()
        {
            if (filtCompra == null)
            {
                filtCompra= new FiltroCompra.Filt();
            }

            var fMasFiltros = new FiltroCompra(filtCompra, _sucursales);
            fMasFiltros.FiltrosCompraOk += fMasFiltros_FiltrosCompraOk;
            fMasFiltros.ShowDialog();
        }

        private void fMasFiltros_FiltrosCompraOk(object sender, FiltroCompra.Filt e)
        {
            filtCompra = e;
        }

        private void FiltrosParaVenta()
        {
            if (filtVenta == null) 
            {
                filtVenta = new Filtros.Filt();
            }

            var fMasFiltros = new Filtros(filtVenta, _sucursales);
            fMasFiltros.FiltrosVentaOk += fMasFiltros_FiltrosVentaOk;
            fMasFiltros.ShowDialog();
        }

        private void fMasFiltros_FiltrosVentaOk(object sender, Filtros.Filt e)
        {
            filtVenta = e;
        }

        private void Generar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Asientos == null || Asientos.Count() == 0)
            {
                e.Cancel = false;
                return;
            }

            var msg = MessageBox.Show("Salir Sin Guardar Datos ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void BT_LIMPIAR_FILTROS_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            var msg = MessageBox.Show("Limpiar Filtros ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes) 
            {
                filtVenta = new Filtros.Filt();
                filtCompra = new FiltroCompra.Filt();
                filtCxP= new FiltroCxP.Filt();
                filtInv = new FiltroInv.Filt();
                filtBanco = new FiltroBanco.Filt();
            }
        }

        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            EditarCuenta();
        }

        private void EditarCuenta()
        {
            if (bs.Current != null)
            {
                var ficha = (OOB.Contable.Asiento.Generar.Ficha)bs.Current;
                var fEditar = new EditarAsiento(ficha);
                fEditar.AsientoDetalleOk += fEditar_AsientoDetalleOk; 
                fEditar.ShowDialog();
            }
        }

        private void fEditar_AsientoDetalleOk(object sender, List<Detalle> e)
        {
            var ficha = (OOB.Contable.Asiento.Generar.Ficha)bs.Current;
            var ln = new List<OOB.Contable.Asiento.Generar.FichaDetalle>();
            int nr = 1;
            foreach (var it in e)
            {
                var nit = new OOB.Contable.Asiento.Generar.FichaDetalle() 
                { 
                     IdCta =it.Cta.Id,
                     CodigoCta =  it.Codigo ,
                     DescripcionCta = it.Descripcion,
                     Naturaleza= it.Cta.Naturaleza,
                     MontoDebe = it.Debe,
                     MontoHaber=it.Haber,
                     Renglon = nr,
                     Signo=ficha.Signo,
                };
                ln.Add(nit);
            }
            ficha.IsOk = true;
            ficha.Detalles = ln;
            DGV.Refresh();
            Limpiar_AsientoDetalles();
            ActualizarTotales();
        }

        private void Limpiar_AsientoDetalles()
        {
            AsientosDet.Clear();
            L_DEBE.Text = "0.0";
            L_HABER.Text = "0.0";
            L_DIFERENCIA.Text = "0.0";
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            if (GuardarComo == Guardar.Contabilizado)
            {
                if (CONTABILIZAR_ISOK)
                {
                    Procesado = true;
                    ContabilizarAsiento();
                }
            }
            else
            {
                if (Asientos != null && Asientos.Count > 0)
                {
                    Procesado = false;
                    ContabilizarAsiento(1);
                }
            }
        }

        private void MenuGuardarPreview_CheckedChanged(object sender, EventArgs e)
        {
            var bt = (ToolStripMenuItem)sender;
            GuardarComo = bt.Checked ? Guardar.Preview : Guardar.Contabilizado;
        }

        private void ExportarAsientoDetalle(object sender, EventArgs e)
        {
            fCont = new Contabilizar(1);
            fCont.EncabezadoOk += fCont_ExportarDetalleOk;
            fCont.ShowDialog();
        }

        private void ExportarAsientoResumen(object sender, EventArgs e)
        {
            fCont = new Contabilizar(1);
            fCont.EncabezadoOk += fCont_ExportarResumenOk;
            fCont.ShowDialog();
        }

        private void fCont_ExportarDetalleOk(object sender, Contabilizar.DatosEncabezado e)
        {
            fCont.Close();

            var list = AsientosDet.ToList();
            var mdebe = AsientosDet.Sum(d => d.MontoDebe);
            var mhaber = AsientosDet.Sum(d => d.MontoHaber);
            var ficha = new OOB.Contable.Asiento.Asiento.Guardar()
            {
                IsPreview = true,
                Periodo = this.Periodo,
                TipoAsiento = e.TipoAsiento,
                TipoDocumento = e.TipoDoc,
                Descripcion = e.Descripcion,
                DocumentoRef = "",
                Fecha = DateTime.Now,
                Importe = mdebe > mhaber ? mdebe : mhaber,
                Asiento = null,
            };

            var ldet = list.Select(cta =>
            {
                
                var det = new OOB.Contable.Asiento.Asiento.Detalle();
                det.Cta = new OOB.Contable.PlanCta.Ficha()
                {
                    Id = cta.IdCta,
                    Codigo = cta.CodigoCta,
                    Nombre = cta.DescripcionCta,
                    Naturaleza=cta.Naturaleza,
                };
                det.Debe = cta.MontoDebe;
                det.Haber = cta.MontoHaber;
                det.Codigo = cta.CodigoCta;
                det.Descripcion = cta.DescripcionCta;

                return det;
            }).ToList();

            ficha.Detalles = ldet;
            Insertar(ficha);
        }

        private void fCont_ExportarResumenOk(object sender, Contabilizar.DatosEncabezado e)
        {
            fCont.Close();

            var mdebe = grup.Sum(d => d.MontoDebe);
            var mhaber = grup.Sum(d => d.MontoHaber);
            var ficha = new OOB.Contable.Asiento.Asiento.Guardar()
            {
                IsPreview = true,
                Periodo = this.Periodo,
                TipoAsiento = e.TipoAsiento,
                TipoDocumento = e.TipoDoc,
                Descripcion = e.Descripcion,
                DocumentoRef = "",
                Fecha = DateTime.Now,
                Importe = mdebe > mhaber ? mdebe : mhaber,
                Asiento = null,
            };

            var ldet = grup.Select(cta => 
            {
                var det = new OOB.Contable.Asiento.Asiento.Detalle();
                det.Cta = new OOB.Contable.PlanCta.Ficha()
                {
                    Id = cta.IdCta,
                    Codigo = cta.CodigoCta,
                    Nombre = cta.DescripcionCta,
                    Naturaleza=cta.Naturaleza,
                };
                det.Codigo = cta.CodigoCta;
                det.Descripcion = cta.DescripcionCta;
                det.Debe = cta.MontoDebe;
                det.Haber = cta.MontoHaber;

                return  det ;
            }).ToList();

            ficha.Detalles = ldet;
            Insertar(ficha);
        }

        private void Insertar(OOB.Contable.Asiento.Asiento.Guardar ficha)
        {
            var result = Globals.MyData.Asiento_Guardar(ficha);
            if (result.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(result.Mensaje);
                return;
            }

            Helpers.Msg.AgregarOk();
        }

        private void CargarData(int IdAsientoCargar)
        {
            var r01 = Globals.MyData.Asiento_GetById(IdAsientoCargar);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            MenuGuardarPreview.Enabled = true;
            MenuGuardarPreview.Checked = true;

            var lit =  new List<OOB.Contable.Asiento.Generar.Ficha>();
            foreach (var doc in r01.Entidad.Documentos)
            {
                var it = new OOB.Contable.Asiento.Generar.Ficha()
                {
                    DescripcionDoc = doc.Descripcion,
                    DocumentoRef = doc.Documento,
                    FechaDoc = doc.Fecha,
                    Signo = doc.Signo,
                    TipoDoc = (OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento)r01.Entidad.TipoDocumento.Id,
                    Incluir = true,
                    Id = "",
                };

                var nr = 1;
                var detalles = new List<OOB.Contable.Asiento.Generar.FichaDetalle>();
                var mdebe=0.0m;
                var mhaber=0.0m;
                foreach (var det in doc.Cuentas) 
                {
                    var cta = new OOB.Contable.Asiento.Generar.FichaDetalle();
                    cta.IdCta = det.Cuenta.IdPlanCta;
                    cta.CodigoCta = det.Cuenta.CodigoCta;
                    cta.DescripcionCta = det.Cuenta.DescripcionCta;
                    cta.MontoDebe = det.MontoDebe;
                    cta.MontoHaber = det.MontoHaber;
                    cta.Signo = doc.Signo;
                    cta.Renglon = nr;
                    cta.Naturaleza = det.Cuenta.NaturalezaCta;
                    nr++;
                    mdebe+=det.MontoDebe ;
                    mhaber+=det.MontoHaber;
                    detalles.Add(cta);
                }

                it.IsOk = (mdebe - mhaber == 0);
                it.Detalles= detalles;
                lit.Add(it);
            }
            
            Asientos = new BindingList<OOB.Contable.Asiento.Generar.Ficha>(lit);
            bs.DataSource = Asientos;
            DGV.DataSource = bs;

            AsientosDet = new BindingList<OOB.Contable.Asiento.Generar.FichaDetalle>();
            bsDet.DataSource = AsientosDet;
            DGV_DETALLE.DataSource = bsDet;

            ActualizarTotales();
            tabControl1.SelectedIndex = 1;
            P_PROCESAR.Enabled = true;
        }

        private void MENU_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            DepartamentosInv();
        }

        private void DepartamentosInv()
        {
           var fDep = new Configuracion.Departamentos.Manager();
            fDep.ShowDialog();
        }

        private void MENU_CONCEPTOS_Click(object sender, EventArgs e)
        {
            Conceptos();
        }

        private void Conceptos()
        {
            var fConcepto= new Configuracion.Conceptos.Manager();
            fConcepto.ShowDialog();
        }

        private void LINK_FILTRAR_NO_OK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FiltrarNoOk();
        }

        private void FiltrarNoOk()
        {
            if (Asientos != null)
            {
                var list = Asientos.Where(f => f.Incluir).ToList();
                if (list.Count(d => d.IsOk == false)>0)
                {


                    bs.DataSource = Asientos.Where(d => d.IsOk == false);
                    DGV.DataSource = bs;

                    AsientosDet = new BindingList<OOB.Contable.Asiento.Generar.FichaDetalle>();
                    bsDet.DataSource = AsientosDet;
                    DGV_DETALLE.DataSource = bsDet;

                    ActualizarTotales();

                }
            }
        }

        private void LINK_FILTRAR_ENCONTRADOS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Encontrados();
        }

        private void Encontrados()
        {
            if (Asientos != null)
            {
                var list = Asientos.Where(f => f.Incluir).ToList();
                if (list.Count(d => d.IsOk == false) > 0)
                {
                    bs.DataSource = Asientos.ToList();
                    DGV.DataSource = bs;

                    AsientosDet = new BindingList<OOB.Contable.Asiento.Generar.FichaDetalle>();
                    bsDet.DataSource = AsientosDet;
                    DGV_DETALLE.DataSource = bsDet;

                    ActualizarTotales();
                }
            }
        }

        private void MENU_BANCOS_Click(object sender, EventArgs e)
        {
            Bancos();
        }

        private void Bancos()
        {
            var fBancos = new Configuracion.Banco.Manager ();
            fBancos.ShowDialog();
        }

    }

}