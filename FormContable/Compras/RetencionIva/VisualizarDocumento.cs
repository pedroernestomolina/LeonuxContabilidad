using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormContable.Compras.RetencionIva
{
    public partial class VisualizarDocumento : Form
    {

        BindingSource bs;
        BindingList<OOB.Compra.RetencionIva.Detalle> Detalles;

        public VisualizarDocumento()
        {
            InitializeComponent();
            bs = new BindingSource();

            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.ReadOnly = true;

            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);
            var c1 = new DataGridViewTextBoxColumn();

            c1.DataPropertyName = "Fecha";
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "DocumentoNro";
            c2.HeaderText = "Documento";
            c2.Visible = true;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "TipoDocumentoDesc";
            c3.HeaderText = "Tipo";
            c3.Visible = true;
            c3.Width = 90;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Total";
            c4.HeaderText = "Total";
            c4.Visible = true;
            c4.Width = 90;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n2";

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Exento";
            c5.HeaderText = "Exento";
            c5.Visible = true;
            c5.Width = 90;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Base";
            c6.HeaderText = "Base";
            c6.Visible = true;
            c6.Width = 90;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "Impuesto";
            c7.HeaderText = "Impuesto";
            c7.Visible = true;
            c7.Width = 90;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n2";

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "Retencion";
            c8.HeaderText = "Retencion";
            c8.Visible = true;
            c8.Width = 90;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c8.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c8);
        }

        private void VisualizarDocumento_Load(object sender, EventArgs e)
        {
        }

        public void CargarDocumento(string doc)
        {
            var r01 = Globals.MyData.Compra_RetencionIva_GetById(doc);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var FichaRetencion = r01.Entidad;
            TB_COMPROBANTE.Text = FichaRetencion.DocumentoNro;
            TB_FECHA_EMISION.Text = FichaRetencion.FechaEmision.ToShortDateString();
            TB_PROVEEDOR.Text = FichaRetencion.Proveedor;
            TB_PERIODO.Text = FichaRetencion.Periodo;
            L_RETENCION.Text = FichaRetencion.MontoRetencion.ToString("n2");
            L_TASA_RETENCION.Text = FichaRetencion.TasaRetencionDesc;

            Detalles = new BindingList<OOB.Compra.RetencionIva.Detalle>(FichaRetencion.Detalles);
            bs.DataSource = Detalles;
            DGV.DataSource = bs;

            ShowDialog();
        }

        private void BT_SALIR_Click_1(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }

    }
}
