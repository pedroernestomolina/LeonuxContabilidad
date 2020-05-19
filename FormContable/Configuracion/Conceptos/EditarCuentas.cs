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

    public partial class EditarCuentas : Form
    {

        public event EventHandler<OOB.Bancos.Conceptos.Actualizar> EditarOk;
        private OOB.Bancos.Conceptos.Ficha Ficha;
        private string Id;
        private int IdControl;
        private OOB.Contable.PlanCta.Ficha CtaPasivo;
        private OOB.Contable.PlanCta.Ficha CtaGasto;
        private OOB.Contable.PlanCta.Ficha CtaBanco;
        private bool salidaOk;
        private PlanCta.Lista fPlanCta;

        public EditarCuentas(string id)
        {
            InitializeComponent();
            this.Id = id;
        }

        private void EditarCuentas_Load(object sender, EventArgs e)
        {
            L_CTA_PASIVO.Text = "";
            L_CTA_GASTO.Text = "";
            L_CTA_BANCO.Text = "";
            CargarData();
        }

        private void CargarData()
        {
            var r01 = Globals.MyData.Banco_Concepto_GetById(Id);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Ficha = r01.Entidad;
            L_CONCEPTO.Text = Ficha.Concepto;
            L_CTA_PASIVO.Text = Ficha.CtaPasivo.Cuenta;
            L_CTA_GASTO.Text = Ficha.CtaGasto.Cuenta;
            L_CTA_BANCO.Text = Ficha.CtaBanco.Cuenta;

            CtaPasivo = new OOB.Contable.PlanCta.Ficha() 
            { 
                Id = Ficha.CtaPasivo.IdPlanCta, 
                Codigo= Ficha.CtaPasivo.CodigoCta, 
                Nombre=Ficha.CtaPasivo.DescripcionCta 
            };
            CtaGasto = new OOB.Contable.PlanCta.Ficha() 
            {
                Id = Ficha.CtaGasto.IdPlanCta,
                Codigo = Ficha.CtaGasto .CodigoCta,
                Nombre = Ficha.CtaGasto.DescripcionCta 
            };
            CtaBanco = new OOB.Contable.PlanCta.Ficha() 
            {
                Id = Ficha.CtaBanco.IdPlanCta ,
                Codigo = Ficha.CtaBanco .CodigoCta,
                Nombre = Ficha.CtaBanco.DescripcionCta 
            };
        }

        private void BT_EDITAR_GASTO_Click(object sender, EventArgs e)
        {
            if (Ficha.Id != "0000000001")
            {
                IdControl = 1;
                CargarPlanCta();
            }
            else
            {
                Helpers.Msg.Alerta("CUENTA NO PUEDE SER CAMBIADA POR EL USUARIO");
            }
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
                        CtaPasivo = e;
                        L_CTA_PASIVO.Text = e.Cuenta;
                        break;
                    case 2:
                        CtaGasto = e;
                        L_CTA_GASTO.Text = e.Cuenta;
                        break;
                    case 3:
                        CtaBanco = e;
                        L_CTA_BANCO.Text = e.Cuenta;
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
                var ficha = new OOB.Bancos.Conceptos.Actualizar()
                {
                    Id = Ficha.Id,
                    CtaPasivo = this.CtaPasivo,
                    CtaGasto = this.CtaGasto,
                    CtaBanco=this.CtaBanco,
                };
                var r01 = Globals.MyData.Banco_Concepto_Actualizar(ficha);
                if (r01.Result == OOB.Resultado.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                salidaOk = true;
                Helpers.Msg.AgregarOk();
                Dispara_EventoEditarOk(ficha);
                Close();
            }
        }

        private void Dispara_EventoEditarOk(OOB.Bancos.Conceptos.Actualizar ficha)
        {
            EventHandler<OOB.Bancos.Conceptos.Actualizar> handler = EditarOk;
            if (handler != null)
            {
                handler(this, ficha);
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

        private void BT_EDITAR_GASTO_Click_1(object sender, EventArgs e)
        {
            if (Ficha.Id != "0000000001")
            {
                IdControl = 2;
                CargarPlanCta();
            }
            else
            {
                Helpers.Msg.Alerta("CUENTA NO PUEDE SER CAMBIADA POR EL USUARIO");
            }
        }

        private void BT_LIMPIAR_PASIVO_Click(object sender, EventArgs e)
        {
            L_CTA_PASIVO.Text = "";
            CtaPasivo = null;
        }

        private void BT_LIMPIAR_GASTO_Click(object sender, EventArgs e)
        {
            L_CTA_GASTO.Text = "";
            CtaGasto = null;
        }

        private void BT_EDITAR_BANCO_Click(object sender, EventArgs e)
        {
            if (Ficha.Id != "0000000001")
            {
                IdControl = 3;
                CargarPlanCta();
            }
            else
            {
                Helpers.Msg.Alerta("CUENTA NO PUEDE SER CAMBIADA POR EL USUARIO");
            }
        }

        private void BT_LIMPIAR_BANCO_Click(object sender, EventArgs e)
        {
            L_CTA_BANCO.Text = "";
            CtaBanco = null;
        }
       
    }

}