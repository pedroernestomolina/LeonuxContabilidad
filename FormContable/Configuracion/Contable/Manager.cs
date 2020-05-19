using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.Configuracion.Contable
{

    public partial class Manager : Form
    {

        private OOB.Contable.PlanCta.Ficha CtaCierrePeriodo;

        public Manager()
        {
            InitializeComponent();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
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
            var r01 = Globals.MyData.Configuracion_CtasCierre();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            CtaCierrePeriodo = r01.Entidad.CtaCierreMes;
            TB_CUENTA.Text = CtaCierrePeriodo.Cuenta;
        }

        private void Refrescar()
        {
            CargarData();
        }

        private void EditarFicha()
        {
            var feditar = new EditarCuentas();
            feditar.EditarOk += feditar_EditarOk;
            feditar.ShowDialog();
        }

        private void feditar_EditarOk(object sender, EventArgs e)
        {
            Refrescar();
        }

    }

}