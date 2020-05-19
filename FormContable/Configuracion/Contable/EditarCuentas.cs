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

    public partial class EditarCuentas : Form
    {

        public event EventHandler EditarOk;
        private bool salidaOk;
        private PlanCta.Lista fPlanCta;
        private OOB.Contable.PlanCta.Ficha CtaCierrePeriodo;


        public EditarCuentas()
        {
            InitializeComponent();
        }

        private void EditarCuentas_Load(object sender, EventArgs e)
        {
            L_CTA_1.Text = "";
        }

        private void CargarData()
        {
        }

        private void BT_EDITAR_GASTO_Click(object sender, EventArgs e)
        {
            CargarPlanCta();
        }

        private void CargarPlanCta()
        {
            fPlanCta = new PlanCta.Lista();
            fPlanCta.ItemSeleccionadoOk += fPlanCta_ItemSeleccionadoOk;
            fPlanCta.ShowDialog();
        }

        private void fPlanCta_ItemSeleccionadoOk(object sender, OOB.Contable.PlanCta.Ficha e)
        {
            if (e.Tipo == OOB.Contable.PlanCta.Enumerados.Tipo.Auxiliar)
            {
                fPlanCta.Close();
                CtaCierrePeriodo = e;
                L_CTA_1.Text = e.Cuenta;
            }
            else
            {
                Helpers.Msg.Error("Cuenta No Puede Ser Seleccionada" + Environment.NewLine + "Debe Ser Una Cuenta Tipo Auxiliar");
                fPlanCta.Visible = true;
            }
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            if (CtaCierrePeriodo == null)
            {
                return;
            }
            if (CtaCierrePeriodo.Id == -1)
            {
                return;
            }

            var msg = MessageBox.Show("Guardar Los Datos De La Ficha ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var ficha = new OOB.Contable.Configuracion.CuentasCierre();
                ficha.CtaCierreMes= CtaCierrePeriodo;

                var r01 = Globals.MyData.Configuracion_CtasCierre_Editar(ficha);
                if (r01.Result == OOB.Resultado.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                salidaOk = true;
                Helpers.Msg.AgregarOk();
                Dispara_EventoEditarOk();
                Close();
            }
        }

        private void Dispara_EventoEditarOk()
        {
            EventHandler handler = EditarOk;
            if (handler != null)
            {
                handler(this, null);
            }
        }

        private void EditarCuentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salidaOk == false)
            {
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
        }

    }

}