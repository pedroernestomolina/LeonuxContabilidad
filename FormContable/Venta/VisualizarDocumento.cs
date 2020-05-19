using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.Venta
{

    public partial class VisualizarDocumento : Form
    {

        BindingSource bs;
        BindingList<OOB.Venta.FichaDetalle> Detalles;
        BindingSource bs_Pago;
        BindingList<OOB.Venta.Pago> Pagos;

        public VisualizarDocumento()
        {
            InitializeComponent();
            bs = new BindingSource();
            bs_Pago = new BindingSource();

            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.ReadOnly = true;

            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);
            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Cantidad";
            c1.HeaderText = "Cantidad";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Descripcion";
            c2.HeaderText = "Descripción";
            c2.Visible = true;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Precio";
            c3.HeaderText = "Precio";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "TasaIva";
            c4.HeaderText = "Iva";
            c4.Visible = true;
            c4.Width = 60;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n2";

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Importe";
            c5.HeaderText = "Importe";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format ="n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "DepartamentoDesc";
            c6.HeaderText = "Dep";
            c6.Visible = true;
            c6.Width = 110;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);


            DGV_PAGO.AllowUserToAddRows = false;
            DGV_PAGO.AutoGenerateColumns = false;
            DGV_PAGO.AllowUserToResizeRows = false;
            DGV_PAGO.AllowUserToResizeColumns = false;
            DGV_PAGO.AllowUserToOrderColumns = false;
            DGV_PAGO.ReadOnly = true;

            var c11 = new DataGridViewTextBoxColumn();
            c11.DataPropertyName = "Codigo";
            c11.HeaderText = "Codigo";
            c11.Visible = true;
            c11.Width = 40;
            c11.HeaderCell.Style.Font = f;
            c11.DefaultCellStyle.Font = f1;

            var c22 = new DataGridViewTextBoxColumn();
            c22.DataPropertyName = "Descripcion";
            c22.HeaderText = "Descripción";
            c22.Visible = true;
            c22.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c22.HeaderCell.Style.Font = f;
            c22.DefaultCellStyle.Font = f1;

            var c33 = new DataGridViewTextBoxColumn();
            c33.DataPropertyName = "Monto";
            c33.HeaderText = "Monto";
            c33.Visible = true;
            c33.Width = 100;
            c33.HeaderCell.Style.Font = f;
            c33.DefaultCellStyle.Font = f1;
            c33.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c33.DefaultCellStyle.Format="n2";

            var c44 = new DataGridViewTextBoxColumn();
            c44.DataPropertyName = "Lote";
            c44.HeaderText = "Lote";
            c44.Visible = true;
            c44.Width = 100;
            c44.HeaderCell.Style.Font = f;
            c44.DefaultCellStyle.Font = f1;

            var c55 = new DataGridViewTextBoxColumn();
            c55.DataPropertyName = "Referencia";
            c55.HeaderText = "Referencia";
            c55.Visible = true;
            c55.Width = 100;
            c55.HeaderCell.Style.Font = f;
            c55.DefaultCellStyle.Font = f1;

            DGV_PAGO.Columns.Add(c11);
            DGV_PAGO.Columns.Add(c22);
            DGV_PAGO.Columns.Add(c44);
            DGV_PAGO.Columns.Add(c55);
            DGV_PAGO.Columns.Add(c33);
        }

        public void CargarDocumento(string doc)
        {
            var r01 = Globals.MyData.Venta_GetById(doc);
            if (r01.Result == OOB.Resultado.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var FichaVenta = r01.Entidad;
            TB_DOCUMENTO.Text = FichaVenta.DocumentoNro;
            TB_TIPO.Text = FichaVenta.TipoDocumentoDesc;
            TB_FECHA.Text = FichaVenta.FechaEmision.ToShortDateString();
            TB_HORA.Text = FichaVenta.Hora;
            TB_CLIENTE.Text = FichaVenta.Cliente;
            TB_USUARIO.Text = FichaVenta.UsuarioEstacion;
            TB_SERIAL.Text = FichaVenta.serialFiscal;
            TB_CONDICION.Text = FichaVenta.CondicionPagoDesc;
            TB_SUCURSAL.Text = FichaVenta.CodigoSucursal;

            L_SUBTOTAL.Text = FichaVenta.SubTotal_02.ToString("n2");
            L_IMPUESTO.Text = FichaVenta.Impuesto.ToString("n2");
            L_TOTAL.Text = FichaVenta.Total.ToString("n2");
            L_PAGO.Text = FichaVenta.Pagos.Sum(p => p.Monto).ToString("n2");

            Detalles = new BindingList<OOB.Venta.FichaDetalle>(r01.Entidad.Detalles);
            bs.DataSource = Detalles;
            DGV.DataSource = bs;

            Pagos = new BindingList<OOB.Venta.Pago>(r01.Entidad.Pagos);
            bs_Pago.DataSource = Pagos;
            DGV_PAGO.DataSource = bs_Pago;

            ShowDialog();
        }

        private void VisualizarDocumento_Load(object sender, EventArgs e)
        {
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }
     
    }
}