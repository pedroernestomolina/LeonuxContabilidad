using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.Configuracion.Conceptos
{

    public partial class Manager : Form
    {
        private BindingSource bs;
        private BindingList<OOB.Bancos.Conceptos.Ficha> Conceptos;

        public Manager()
        {
            InitializeComponent();
            bs = new BindingSource();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            TB_BUSQUEDA.Select();

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
           // CargarData();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void BT_REFRESH_Click(object sender, EventArgs e)
        {
           // Refrescar();
        }

        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            EditarFicha();
        }

        private void Salir()
        {
            Close();
        }

        private void CargarData(string buscar)
        {
            var r01 = Globals.MyData.Banco_Concepto_Lista(buscar,
                OOB.Bancos.Conceptos.Enumerados.TipoLista.General,
                OOB.Bancos.Conceptos.Enumerados.TipoMovimiento.Todos);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var l = r01.Lista.OrderBy(d => d.Descripcion).ToList();
            Conceptos = new BindingList<OOB.Bancos.Conceptos.Ficha>(l);
            bs.CurrentChanged += bs_CurrentChanged;
            bs.DataSource = Conceptos;
            DGV.DataSource = bs;
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            TB_PASIVO.Text = "";
            TB_GASTO.Text = "";
            TB_BANCO.Text = "";

            var it = (OOB.Bancos.Conceptos.Ficha)bs.Current;
            TB_GASTO.Text = it.CtaGasto.Cuenta;
            TB_PASIVO.Text = it.CtaPasivo.Cuenta;
            TB_BANCO.Text = it.CtaBanco.Cuenta;
        }

        private void Refrescar()
        {
            var r01 = Globals.MyData.Banco_Concepto_Lista("",
                          OOB.Bancos.Conceptos.Enumerados.TipoLista.General,
                          OOB.Bancos.Conceptos.Enumerados.TipoMovimiento.Todos);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var l = r01.Lista.OrderBy(d => d.Descripcion).ToList();
            Conceptos = new BindingList<OOB.Bancos.Conceptos.Ficha>(l);
            bs.DataSource = Conceptos;
        }

        private void EditarFicha()
        {
            if (bs.Current != null)
            {
                var it = (OOB.Bancos.Conceptos.Ficha) bs.Current;
                var feditar = new EditarCuentas(it.Id);
                feditar.EditarOk += feditar_EditarOk;
                feditar.ShowDialog();
            }
        }

        private void feditar_EditarOk(object sender, OOB.Bancos.Conceptos.Actualizar e)
        {
            var ent=Conceptos.FirstOrDefault(ct => ct.Id == e.Id);

            if (e.CtaGasto != null)
            {
                ent.CtaGasto.IdPlanCta = e.CtaGasto.Id;
                ent.CtaGasto.CodigoCta = e.CtaGasto.Codigo;
                ent.CtaGasto.DescripcionCta = e.CtaGasto.Nombre;
            }
            else 
            {
                ent.CtaGasto.IdPlanCta = -1;
                ent.CtaGasto.CodigoCta = "";
                ent.CtaGasto.DescripcionCta = "";
            }

            if (e.CtaPasivo != null)
            {
                ent.CtaPasivo.IdPlanCta = e.CtaPasivo.Id;
                ent.CtaPasivo.CodigoCta = e.CtaPasivo.Codigo;
                ent.CtaPasivo.DescripcionCta = e.CtaPasivo.Nombre;
            }
            else
            {
                ent.CtaPasivo.IdPlanCta = -1;
                ent.CtaPasivo.CodigoCta = "";
                ent.CtaPasivo.DescripcionCta = "";
            }

            if (e.CtaBanco != null)
            {
                ent.CtaBanco.IdPlanCta = e.CtaBanco.Id;
                ent.CtaBanco.CodigoCta = e.CtaBanco.Codigo;
                ent.CtaBanco.DescripcionCta = e.CtaBanco.Nombre;
            }
            else
            {
                ent.CtaBanco.IdPlanCta = -1;
                ent.CtaBanco.CodigoCta = "";
                ent.CtaBanco.DescripcionCta = "";
            }

            bs.CurrencyManager.Refresh();
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TB_BUSQUEDA.Text)) 
            {
                CargarData(TB_BUSQUEDA.Text);
            }
            TB_BUSQUEDA.Text = "";
            TB_BUSQUEDA.Select();
        }

    }

}