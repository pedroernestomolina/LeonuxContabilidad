using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.Configuracion.Banco
{

    public partial class Manager : Form
    {

        private BindingSource bs;
        private BindingList<OOB.Bancos.Banco.Ficha> Bancos;

        public Manager()
        {
            InitializeComponent();
            bs = new BindingSource();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            TB_CUENTA.Text = "";
            TB_CTA_IGTF.Text = "";

            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.ReadOnly = true;

            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Nombre";
            c2.HeaderText = "Descripción";
            c2.Visible = true;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c2);
            CargarData();
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
            Refrescar();
        }

        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            EditarFicha();
        }

        private void Salir()
        {
            Close();
        }

        private void CargarData()
        {
            var r01 = Globals.MyData.Bancos_Banco_Lista();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var l = r01.Lista.OrderBy(d => d.Nombre).ToList();
            Bancos = new BindingList<OOB.Bancos.Banco.Ficha>(l);
            bs.CurrentChanged += bs_CurrentChanged;
            bs.DataSource = Bancos;
            DGV.DataSource = bs;
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            TB_CUENTA.Text = "";
            TB_CTA_IGTF.Text = "";

            var it = (OOB.Bancos.Banco.Ficha)bs.Current;
            TB_CUENTA.Text = it.CtaContable.Cuenta;
            TB_CTA_IGTF.Text = it.CtaIGTF.Cuenta;
        }

        private void Refrescar()
        {
            var r01 = Globals.MyData.Bancos_Banco_Lista();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var l = r01.Lista.OrderBy(d => d.Nombre).ToList();
            Bancos = new BindingList<OOB.Bancos.Banco.Ficha>(l);
            bs.DataSource = Bancos;
        }

        private void EditarFicha()
        {
            if (bs.Current != null)
            {
                var it = (OOB.Bancos.Banco.Ficha )bs.Current;
                var feditar = new EditarCuentas(it.Id);
                feditar.EditarOk += feditar_EditarOk;
                feditar.ShowDialog();
            }
        }

        private void feditar_EditarOk(object sender, EventArgs e)
        {
            Refrescar();
        }

    }
}