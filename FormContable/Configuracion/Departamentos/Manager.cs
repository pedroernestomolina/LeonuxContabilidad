using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.Configuracion.Departamentos
{

    public partial class Manager : Form
    {

        private BindingSource bs;
        private BindingList<OOB.Empresa.Departamento.Ficha> Departamentos;

        public Manager()
        {
            InitializeComponent();
            bs = new BindingSource();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }

        private void CargarData ()
        {
            var r01 = Globals.MyData.Empresa_Departamento_Lista ();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var l = r01.Lista.OrderBy(d => d.Descripcion).ToList();
            Departamentos = new BindingList<OOB.Empresa.Departamento.Ficha>(l);
            bs.CurrentChanged += bs_CurrentChanged;
            bs.DataSource = Departamentos;
            DGV.DataSource = bs;
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            TB_INV_1.Text = "";
            TB_COSTO_1.Text = "";
            TB_VENTA_1.Text = "";
            TB_MERMA_1.Text = "";
            TB_CONSUMO_INTERNO_1.Text = "";

            TB_INV_2.Text = "";
            TB_COSTO_2.Text = "";
            TB_VENTA_2.Text = "";
            TB_MERMA_2.Text = "";
            TB_CONSUMO_INTERNO_2.Text = "";

            TB_INV_3.Text = "";
            TB_COSTO_3.Text = "";
            TB_VENTA_3.Text = "";
            TB_MERMA_3.Text = "";
            TB_CONSUMO_INTERNO_3.Text = "";

            TB_INV_4.Text = "";
            TB_COSTO_4.Text = "";
            TB_VENTA_4.Text = "";
            TB_MERMA_4.Text = "";
            TB_CONSUMO_INTERNO_4.Text = "";

            TB_INV_5.Text = "";
            TB_COSTO_5.Text = "";
            TB_VENTA_5.Text = "";
            TB_MERMA_5.Text = "";
            TB_CONSUMO_INTERNO_5.Text = "";

            var it = (OOB.Empresa.Departamento.Ficha)bs.Current;
            TB_INV_1.Text = it.Sucursal_1.CtaInventario.Cuenta;
            TB_COSTO_1.Text = it.Sucursal_1.CtaCosto.Cuenta;
            TB_VENTA_1.Text = it.Sucursal_1.CtaVenta.Cuenta;
            TB_MERMA_1.Text = it.Sucursal_1.CtaMerma.Cuenta;
            TB_CONSUMO_INTERNO_1.Text = it.Sucursal_1.CtaConsumoInterno.Cuenta;

            TB_INV_2.Text = it.Sucursal_2.CtaInventario.Cuenta;
            TB_COSTO_2.Text = it.Sucursal_2.CtaCosto.Cuenta;
            TB_VENTA_2.Text = it.Sucursal_2.CtaVenta.Cuenta;
            TB_MERMA_2.Text = it.Sucursal_2.CtaMerma.Cuenta;
            TB_CONSUMO_INTERNO_2.Text = it.Sucursal_2.CtaConsumoInterno.Cuenta;

            TB_INV_3.Text = it.Sucursal_3.CtaInventario.Cuenta;
            TB_COSTO_3.Text = it.Sucursal_3.CtaCosto.Cuenta;
            TB_VENTA_3.Text = it.Sucursal_3.CtaVenta.Cuenta;
            TB_MERMA_3.Text = it.Sucursal_3.CtaMerma.Cuenta;
            TB_CONSUMO_INTERNO_3.Text = it.Sucursal_3.CtaConsumoInterno.Cuenta;

            TB_INV_4.Text = it.Sucursal_4.CtaInventario.Cuenta;
            TB_COSTO_4.Text = it.Sucursal_4.CtaCosto.Cuenta;
            TB_VENTA_4.Text = it.Sucursal_4.CtaVenta.Cuenta;
            TB_MERMA_4.Text = it.Sucursal_4.CtaMerma.Cuenta;
            TB_CONSUMO_INTERNO_4.Text = it.Sucursal_4.CtaConsumoInterno.Cuenta;

            TB_INV_5.Text = it.Sucursal_5.CtaInventario.Cuenta;
            TB_COSTO_5.Text = it.Sucursal_5.CtaCosto.Cuenta;
            TB_VENTA_5.Text = it.Sucursal_5.CtaVenta.Cuenta;
            TB_MERMA_5.Text = it.Sucursal_5.CtaMerma.Cuenta;
            TB_CONSUMO_INTERNO_5.Text = it.Sucursal_5.CtaConsumoInterno.Cuenta;
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.ReadOnly = true;

            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Descripcion";
            c2.HeaderText = "Descripción";
            c2.Visible = true;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c2);
            CargarData();
        }

        private void BT_REFRESH_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void Refrescar()
        {
            var r01 = Globals.MyData.Empresa_Departamento_Lista();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var l = r01.Lista.OrderBy(d => d.Descripcion).ToList();
            Departamentos = new BindingList<OOB.Empresa.Departamento.Ficha>(l);
            bs.DataSource = Departamentos;
        }

        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            EditarFicha();
        }

        private void EditarFicha()
        {
            if (bs.Current != null) 
            {
                var index = tabControl1.SelectedIndex;
                var it = (OOB.Empresa.Departamento.Ficha)bs.Current;
                var feditar = new EditarCuentas(it.Id,index);
                feditar.EditarOk +=feditar_EditarOk;
                feditar.ShowDialog();
            }
        }

        private void feditar_EditarOk(object sender, EventArgs e)
        {
            Refrescar();
        }

    }
}