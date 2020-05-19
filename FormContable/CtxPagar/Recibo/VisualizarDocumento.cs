using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormContable.CtxPagar.Recibo
{

    public partial class VisualizarDocumento : Form
    {

        BindingSource bs;
        BindingList<OOB.CtxPagar.Recibo.Documento> Documentos;

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
            var f1 = new Font("Serif", 10, FontStyle.Regular);
            var c1 = new DataGridViewTextBoxColumn();

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Fecha";
            c2.HeaderText = "Fecha";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "DocumentoNro";
            c3.HeaderText = "Documento";
            c3.Visible = true;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "TipoDocumento";
            c4.HeaderText = "Tipo";
            c4.Visible = true;
            c4.Width = 100;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Operacion";
            c6.HeaderText = "Operacion";
            c6.Visible = true;
            c6.Width = 100;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Importe";
            c5.HeaderText = "Importe";
            c5.Visible = true;
            c5.Width = 150;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c5);

            //TPAGO
            TB_ANTICIPOS.Text = 0.ToString("n2");
            TB_CODIGO.Text = "";
            TB_DESCRIPCION.Text = "";
            TB_CODIGO_CTA.Text = "";
            TB_NUMERO_CTA.Text = "";
            TB_REFERENCIA.Text = "";
            TB_MONTO_RECIBIDO.Text = 0.ToString("n2");
        }

        public void CargarDocumento(string doc)
        {
            var r01 = Globals.MyData.CtxPagar_Recibo_GetById(doc);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var FichaCta = r01.Entidad;
            TB_DOCUMENTO.Text = FichaCta.DocumentoNro;
            TB_FECHA_EMISION.Text = FichaCta.FechaEmision.ToShortDateString();
            TB_PROVEEDOR.Text = FichaCta.Proveedor;
            TB_TIPO_DOCUMENTO.Text = "PAGO";
            TB_USUARIO.Text = FichaCta.UsuarioEstacion ;
            TB_NOTAS.Text = FichaCta.Notas;
            L_TOTAL.Text = FichaCta.Importe.ToString("n2");

            TB_ANTICIPOS.Text = FichaCta.FormaPago.MontoPorAnticipos.ToString("n2");
            TB_CODIGO.Text = FichaCta.FormaPago.MedioPago.CodigoMedio ;
            TB_DESCRIPCION.Text = FichaCta.FormaPago.MedioPago.DescripcionMedio;
            TB_CODIGO_CTA.Text = FichaCta.FormaPago.MedioPago.CtaCodigo ;
            TB_NUMERO_CTA.Text = FichaCta.FormaPago.MedioPago.CtaNumero;
            TB_REFERENCIA.Text = FichaCta.FormaPago.MedioPago.Referencia;
            TB_MONTO_RECIBIDO.Text = FichaCta.FormaPago.MedioPago.MontoRecibido.ToString("n2");

            Documentos  = new BindingList<OOB.CtxPagar.Recibo.Documento>(FichaCta.Documentos);
            bs.DataSource = Documentos ;
            DGV.DataSource = bs;

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