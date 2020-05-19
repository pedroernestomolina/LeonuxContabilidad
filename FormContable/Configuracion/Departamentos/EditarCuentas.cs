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
   
    public partial class EditarCuentas : Form
    {

        public event EventHandler EditarOk;
        private OOB.Empresa.Departamento.Ficha Ficha;
        private string Id;
        private int TabActivo;
        private int IdControl;
        private OOB.Contable.PlanCta.Ficha CtaInventario;
        private OOB.Contable.PlanCta.Ficha CtaCosto;
        private OOB.Contable.PlanCta.Ficha CtaVenta;
        private OOB.Contable.PlanCta.Ficha CtaMerma;
        private OOB.Contable.PlanCta.Ficha CtaConsumo;
        private bool salidaOk;
        private PlanCta.Lista fPlanCta;
        private int Sucursal;


        public EditarCuentas(string id, int tabActivo )
        {
            InitializeComponent();
            this.Id = id;
            this.TabActivo = tabActivo;
        }

        private void EditarCuentas_Load(object sender, EventArgs e)
        {
            L_CTA_INV.Text = "";
            L_CTA_COSTO.Text = "";
            L_CTA_VENTA.Text = "";
            L_CTA_MERMA.Text = "";
            L_CTA_CONSUMO.Text = "";
            CargarData();
        }

        private void CargarData()
        {
            var r01 = Globals.MyData.Empresa_Departamento_GetById(Id);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Ficha = r01.Entidad;
            L_DEPARTAMENTO.Text = Ficha.Departamento;
            switch (TabActivo) 
            {
                case 0: //PRINCIPAL
                    L_CTA_INV.Text = Ficha.Sucursal_1.CtaInventario.Cuenta;
                    L_CTA_COSTO.Text = Ficha.Sucursal_1.CtaCosto.Cuenta;
                    L_CTA_VENTA.Text = Ficha.Sucursal_1.CtaVenta.Cuenta;
                    L_CTA_MERMA.Text = Ficha.Sucursal_1.CtaMerma.Cuenta;
                    L_CTA_MERMA.Text = Ficha.Sucursal_1.CtaMerma.Cuenta;
                    L_CTA_CONSUMO.Text = Ficha.Sucursal_1.CtaConsumoInterno.Cuenta;
                    CtaInventario = new OOB.Contable.PlanCta.Ficha() {  Id= Ficha.Sucursal_1.CtaInventario.IdPlanCta };
                    CtaCosto = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_1.CtaCosto.IdPlanCta };
                    CtaVenta = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_1.CtaVenta .IdPlanCta };
                    CtaMerma= new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_1.CtaMerma .IdPlanCta };
                    CtaConsumo = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_1.CtaConsumoInterno.IdPlanCta };
                    Sucursal = 1;
                    L_SUCURSAL.Text = "01";
                    break;

                case 1: //PARAPARAL
                    L_CTA_INV.Text = Ficha.Sucursal_2.CtaInventario.Cuenta;
                    L_CTA_COSTO.Text = Ficha.Sucursal_2.CtaCosto.Cuenta;
                    L_CTA_VENTA.Text = Ficha.Sucursal_2.CtaVenta.Cuenta;
                    L_CTA_MERMA.Text = Ficha.Sucursal_2.CtaMerma.Cuenta;
                    L_CTA_MERMA.Text = Ficha.Sucursal_2.CtaMerma.Cuenta;
                    L_CTA_CONSUMO.Text = Ficha.Sucursal_2.CtaConsumoInterno.Cuenta;
                    CtaInventario = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_2.CtaInventario.IdPlanCta };
                    CtaCosto = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_2.CtaCosto.IdPlanCta };
                    CtaVenta = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_2.CtaVenta.IdPlanCta };
                    CtaMerma = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_2.CtaMerma.IdPlanCta };
                    CtaConsumo = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_2.CtaConsumoInterno.IdPlanCta };
                    Sucursal = 2;
                    L_SUCURSAL.Text = "02";
                    break;

                case 2: //AGUA DORADA
                    L_CTA_INV.Text = Ficha.Sucursal_3.CtaInventario.Cuenta;
                    L_CTA_COSTO.Text = Ficha.Sucursal_3.CtaCosto.Cuenta;
                    L_CTA_VENTA.Text = Ficha.Sucursal_3.CtaVenta.Cuenta;
                    L_CTA_MERMA.Text = Ficha.Sucursal_3.CtaMerma.Cuenta;
                    L_CTA_MERMA.Text = Ficha.Sucursal_3.CtaMerma.Cuenta;
                    L_CTA_CONSUMO.Text = Ficha.Sucursal_3.CtaConsumoInterno.Cuenta;
                    CtaInventario = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_3.CtaInventario.IdPlanCta };
                    CtaCosto = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_3.CtaCosto.IdPlanCta };
                    CtaVenta = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_3.CtaVenta.IdPlanCta };
                    CtaMerma = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_3.CtaMerma.IdPlanCta };
                    CtaConsumo = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_3.CtaConsumoInterno.IdPlanCta };
                    Sucursal = 3;
                    L_SUCURSAL.Text = "03";
                    break;

                case 3: //NAGUANAGUA
                    L_CTA_INV.Text = Ficha.Sucursal_4.CtaInventario.Cuenta;
                    L_CTA_COSTO.Text = Ficha.Sucursal_4.CtaCosto.Cuenta;
                    L_CTA_VENTA.Text = Ficha.Sucursal_4.CtaVenta.Cuenta;
                    L_CTA_MERMA.Text = Ficha.Sucursal_4.CtaMerma.Cuenta;
                    L_CTA_MERMA.Text = Ficha.Sucursal_4.CtaMerma.Cuenta;
                    L_CTA_CONSUMO.Text = Ficha.Sucursal_4.CtaConsumoInterno.Cuenta;
                    CtaInventario = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_4.CtaInventario.IdPlanCta };
                    CtaCosto = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_4.CtaCosto.IdPlanCta };
                    CtaVenta = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_4.CtaVenta.IdPlanCta };
                    CtaMerma = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_4.CtaMerma.IdPlanCta };
                    CtaConsumo = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_4.CtaConsumoInterno.IdPlanCta };
                    Sucursal = 4;
                    L_SUCURSAL.Text = "04";
                    break;

                case 4: //SUCURSAL 05
                    L_CTA_INV.Text = Ficha.Sucursal_5.CtaInventario.Cuenta;
                    L_CTA_COSTO.Text = Ficha.Sucursal_5.CtaCosto.Cuenta;
                    L_CTA_VENTA.Text = Ficha.Sucursal_5.CtaVenta.Cuenta;
                    L_CTA_MERMA.Text = Ficha.Sucursal_5.CtaMerma.Cuenta;
                    L_CTA_MERMA.Text = Ficha.Sucursal_5.CtaMerma.Cuenta;
                    L_CTA_CONSUMO.Text = Ficha.Sucursal_5.CtaConsumoInterno.Cuenta;
                    CtaInventario = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_5.CtaInventario.IdPlanCta };
                    CtaCosto = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_5.CtaCosto.IdPlanCta };
                    CtaVenta = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_5.CtaVenta.IdPlanCta };
                    CtaMerma = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_5.CtaMerma.IdPlanCta };
                    CtaConsumo = new OOB.Contable.PlanCta.Ficha() { Id = Ficha.Sucursal_5.CtaConsumoInterno.IdPlanCta };
                    Sucursal = 5;
                    L_SUCURSAL.Text = "05";
                    break;
            }
        }
       
        private void BT_EDITAR_INV_Click(object sender, EventArgs e)
        {
            IdControl = 1;
            CargarPlanCta();
        }

        private void BT_EDITAR_COSTO_Click(object sender, EventArgs e)
        {
            IdControl = 2;
            CargarPlanCta();
        }

        private void BT_EDITAR_VENTA_Click(object sender, EventArgs e)
        {
            IdControl = 3;
            CargarPlanCta();
        }

        private void BT_EDITAR_MERMA_Click(object sender, EventArgs e)
        {
            IdControl = 4;
            CargarPlanCta();
        }

        private void BT_EDITAR_CONSUMO_Click(object sender, EventArgs e)
        {
            IdControl = 5;
            CargarPlanCta();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
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
                        CtaInventario = e;
                        L_CTA_INV.Text = e.Cuenta;
                        break;
                    case 2:
                        CtaCosto = e;
                        L_CTA_COSTO.Text = e.Cuenta;
                        break;
                    case 3:
                        CtaVenta = e;
                        L_CTA_VENTA.Text= e.Cuenta;
                        break;
                    case 4:
                        CtaMerma = e;
                        L_CTA_MERMA.Text= e.Cuenta;
                        break;
                    case 5:
                        CtaConsumo = e;
                        L_CTA_CONSUMO.Text = e.Cuenta;
                        break;
                }
            }
            else
            {
                Helpers.Msg.Error("Cuenta No Puede Ser Seleccionada"+ Environment.NewLine +"Debe Ser Una Cuenta Tipo Auxiliar");
                fPlanCta.Visible = true;
            }
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            //if (CtaInventario == null) 
            //{
            //    return;
            //}
            //if (CtaInventario.Id == -1)
            //{
            //    return;
            //}

            //if (CtaCosto == null)
            //{
            //    return;
            //}
            //if (CtaCosto.Id==-1)
            //{
            //    return;
            //}

            //if (CtaVenta == null)
            //{
            //    return;
            //}
            //if (CtaVenta.Id==-1)
            //{
            //    return;
            //}

            //if (CtaMerma == null)
            //{
            //    return;
            //}
            //if (CtaMerma.Id==-1)
            //{
            //    return;
            //}

            var msg = MessageBox.Show("Guardar Los Datos De La Ficha ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes) 
            {
                var ficha = new OOB.Empresa.Departamento.Actualizar()
                {
                    Id=Ficha.Id,
                    IdSucursal=Sucursal,
                    CtaInventario=this.CtaInventario,
                    CtaCosto=this.CtaCosto ,
                    CtaVenta=this.CtaVenta,
                    CtaMerma=this.CtaMerma,
                    CtaConsumo=this.CtaConsumo
                };

                var r01 = Globals.MyData.Empresa_Departamento_Actualizar(ficha);
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

        private void BT_LIMPIAR_VENTA_Click(object sender, EventArgs e)
        {
            CtaVenta.Id=-1;
            L_CTA_VENTA.Text = "";
        }

        private void BT_LIMPIAR_INV_Click(object sender, EventArgs e)
        {
            CtaInventario.Id = -1;
            L_CTA_INV.Text = "";
        }

        private void BT_LIMPIAR_COSTO_Click(object sender, EventArgs e)
        {
            CtaCosto.Id = -1;
            L_CTA_COSTO.Text = "";
        }

        private void BT_LIMPIAR_MERMA_Click(object sender, EventArgs e)
        {
            CtaMerma.Id = -1;
            L_CTA_MERMA.Text = "";
        }

        private void BT_LIMPIAR_CONSUMO_Click(object sender, EventArgs e)
        {
            CtaConsumo.Id = -1;
            L_CTA_CONSUMO.Text = "";
        }

    }

}