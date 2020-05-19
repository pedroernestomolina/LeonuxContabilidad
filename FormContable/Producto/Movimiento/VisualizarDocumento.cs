using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormContable.Producto.Movimiento
{

    public partial class VisualizarDocumento : Form
    {

        BindingSource bs;
        BindingList<OOB.Productos.Movimiento.Detalle> Detalles;

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
            c1.Width = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Producto";
            c2.HeaderText = "Producto";
            c2.Visible = true;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "CostoCompra";
            c3.HeaderText = "Costo";
            c3.Visible = true;
            c3.Width = 110;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "EmpaqueCont";
            c5.HeaderText = "Empaque";
            c5.Visible = true;
            c5.Width = 110;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Importe";
            c4.HeaderText = "Importe";
            c4.Visible = true;
            c4.Width = 120;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "DepartamentoDesc";
            c6.HeaderText = "Departamento";
            c6.Visible = true;
            c6.Width = 110;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.Width = 150;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c6);
        }

        public void CargarDocumento(string doc)
        {
            var r01 = Globals.MyData.Productos_Movimiento_GetById(doc);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var FichaMov = r01.Entidad;
            TB_DOC.Text = FichaMov.Documento;
            TB_CONCEPTO.Text = FichaMov.Concepto;
            TB_DEPOSITO.Text = FichaMov.Deposito;
            TB_FECHA.Text = FichaMov.FechaHora;
            TB_USUARIO.Text = FichaMov.UsuarioEstacion;
            TB_NOTA.Text = FichaMov.Nota;
            L_TOTAL.Text = FichaMov.Importe.ToString("n2");

            Detalles = new BindingList<OOB.Productos.Movimiento.Detalle>(r01.Entidad.Detalles);
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
     
    }
}
