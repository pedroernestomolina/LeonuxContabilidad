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

    public partial class EditarCuentas : Form
    {

        public event EventHandler EditarOk;
        private OOB.Bancos.Banco.Ficha Ficha;
        private string Id;
        private int IdControl;
        private OOB.Contable.PlanCta.Ficha CtaContable;
        private OOB.Contable.PlanCta.Ficha CtaIGTF;
        private bool salidaOk;
        private PlanCta.Lista fPlanCta;

        public EditarCuentas(string id)
        {
            InitializeComponent();
            this.Id = id;
        }

        private void EditarCuentas_Load(object sender, EventArgs e)
        {
            L_CTA.Text = "";
            L_CTA_IGTF.Text = "";
            CargarData();
        }
        private void CargarData()
        {
            var r01 = Globals.MyData.Bancos_Banco_GetById(Id);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Ficha = r01.Entidad;
            L_BANCO.Text = Ficha.Banco;
            L_CTA.Text = Ficha.CtaContable.Cuenta;
            L_CTA_IGTF.Text = Ficha.CtaIGTF.Cuenta;

            CtaContable = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.CtaContable.IdPlanCta };
            CtaIGTF = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.CtaIGTF.IdPlanCta };
        }

        private void BT_EDITAR_CTA_Click(object sender, EventArgs e)
        {
            IdControl = 1;
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

                switch (IdControl)
                {
                    case 1:
                        CtaContable = e;
                        L_CTA.Text = e.Cuenta;
                        break;
                    case 2:
                        CtaIGTF = e;
                        L_CTA_IGTF.Text = e.Cuenta;
                        break;
                }
            }
            else
            {
                Helpers.Msg.Error("Cuenta No Puede Ser Seleccionada" + Environment.NewLine + "Debe Ser Una Cuenta Tipo Auxiliar");
                fPlanCta.Visible = true;
            }
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Guardar Los Datos De La Ficha ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var ficha = new OOB.Bancos.Banco.Actualizar ()
                {
                    Id = Ficha.Id,
                    CtaContable = this.CtaContable,
                    CtaIGTF=this.CtaIGTF,
                };
                var r01 = Globals.MyData.Bancos_Banco_Actualizar(ficha);
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

        private void BT_LIMPIAR_CTA_Click(object sender, EventArgs e)
        {
            CtaContable = null ;
            L_CTA.Text = "";
        }

        private void BT_LIMPIAR_CTA_IGTF_Click(object sender, EventArgs e)
        {
            CtaIGTF= null;
            L_CTA_IGTF.Text = "";
        }

        private void BT_EDITAR_CTA_IGTF_Click(object sender, EventArgs e)
        {
            IdControl = 2;
            CargarPlanCta();
        }

    }

}