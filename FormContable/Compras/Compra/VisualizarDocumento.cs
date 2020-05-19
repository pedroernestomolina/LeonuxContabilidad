using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.Compras.Compra
{

    public partial class VisualizarDocumento : Form
    {

        private OOB.Compra.Compra.Ficha FichaCompra;
        private BindingSource bs;
        private BindingList<OOB.Compra.Compra.Detalle> Detalles;

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
            c5.Width = 150;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format="n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "DepartamentoDesc";
            c6.HeaderText = "Departamento";
            c6.Visible = true;
            c6.Width = 150;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
        }

        public void CargarDocumento(string doc)
        {
            var r01 = Globals.MyData.Compra_Documento_GetById(doc);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            FichaCompra = r01.Entidad;
            TB_DOCUMENTO.Text = FichaCompra.DocumentoNro;
            TB_FECHA_EMISION.Text = FichaCompra.FechaEmision.ToShortDateString();
            TB_FECHA_REGISTRO.Text = FichaCompra.FechaRegistro.ToShortDateString();
            TB_MES_RELACION.Text = FichaCompra.MesRelacion;
            TB_ANO_RELACION.Text = FichaCompra.AnoRelacion;
            TB_PROVEEDOR.Text = FichaCompra.Proveedor;
            L_TIPO_DOCUMENTO.Text = FichaCompra.TipoDocumentoDesc;
            TB_USUARIO.Text = FichaCompra.UsuarioEquipo;
            TB_NOTAS.Text = FichaCompra.Notas;
            TB_CONTROL.Text = FichaCompra.ControlNro;
            TB_CONCEPTO.Text = FichaCompra.Concepto;
            TB_SUCURSAL.Text = FichaCompra.CodigoSucursal;

            L_DESCUENTO.Text = FichaCompra.Decuento.ToString("n2");
            L_SUBTOTAL_01.Text = FichaCompra.SubTotal_01.ToString("n2");
            L_SUBTOTAL.Text = FichaCompra.SubTotal_02.ToString("n2");
            L_IMPUESTO.Text = FichaCompra.Impuesto.ToString("n2");
            L_TOTAL.Text = FichaCompra.Total.ToString("n2");

            Detalles = new BindingList<OOB.Compra.Compra.Detalle>(FichaCompra.Detalles);
            bs.DataSource = Detalles;
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

        private void MenuIActualizarCalificativo_Click(object sender, EventArgs e)
        {
            ActualizarCailificativoCompra();
        }

        private void ActualizarCailificativoCompra()
        {
            var fCalificativo = new Calificactivo();
            fCalificativo.CalificativoOk +=fCalificativo_CalificativoOk;
            fCalificativo.ShowDialog();
        }

        private void fCalificativo_CalificativoOk(object sender, OOB.Bancos.Conceptos.Ficha e)
        {
            var msg = MessageBox.Show("Actualizar Data Del Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes) 
            {
                var ficha = new OOB.Compra.Compra.ActualizarData()
                {
                    AutoDocumento = FichaCompra.Id,
                    Calificativo = e
                };
                var r01 = Globals.MyData.Compra_Actualizar(ficha);
                if (r01.Result == OOB.Resultado.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                TB_CONCEPTO.Text = e.Descripcion ;
                Helpers.Msg.EditarOk();
            }
        }

    }

}