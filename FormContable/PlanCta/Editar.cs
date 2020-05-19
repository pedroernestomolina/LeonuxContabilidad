using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.PlanCta
{

    public partial class Editar : Form
    {

        public event EventHandler<int> EditarOk;
        OOB.Contable.PlanCta.Ficha  Ficha;

        public Editar(OOB.Contable.PlanCta.Ficha ficha)
        {
            InitializeComponent();
            Ficha = ficha ;
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            TB_CODIGO.Text = Ficha.Codigo;
            TB_DESCRIPCION.Text = Ficha.Nombre;
            CB_TIPO.SelectedIndex = 0;
            CB_NATURALEZA.SelectedIndex = 0;
            CB_ESTADO.SelectedIndex = 0;

            if (Ficha.Tipo == OOB.Contable.PlanCta.Enumerados.Tipo.Totalizadora)
            {
                CB_TIPO.SelectedIndex = 1;
            }
            if (Ficha.Naturaleza == OOB.Contable.PlanCta.Enumerados.Naturaleza.Acreedora)
            {
                CB_NATURALEZA.SelectedIndex = 1;
            }
            if (Ficha.Estado == OOB.Contable.PlanCta.Enumerados.EstadoSituacion.Resultados)
            {
                CB_ESTADO.SelectedIndex = 1;
            }
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            if (TB_DESCRIPCION.Text.Trim() == "") { return; }
            if (CB_NATURALEZA.SelectedIndex == -1) { return; }
            if (CB_TIPO.SelectedIndex == -1) { return; }
            if (CB_ESTADO.SelectedIndex == -1) { return; }

            var _tipo = CB_TIPO.SelectedIndex == 0 ? OOB.Contable.PlanCta.Enumerados.Tipo.Auxiliar : OOB.Contable.PlanCta.Enumerados.Tipo.Totalizadora;
            var _naturaleza = CB_NATURALEZA.SelectedIndex == 0 ? OOB.Contable.PlanCta.Enumerados.Naturaleza.Deudora : OOB.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
            var _estado = CB_ESTADO.SelectedIndex == 0 ? OOB.Contable.PlanCta.Enumerados.EstadoSituacion.Financiero : OOB.Contable.PlanCta.Enumerados.EstadoSituacion.Resultados;
            var fichaEditar = new OOB.Contable.PlanCta.Editar();
            fichaEditar.Id = Ficha.Id;
            fichaEditar.Descripcion = TB_DESCRIPCION.Text;
            fichaEditar.Tipo = _tipo;
            fichaEditar.Naturaleza = _naturaleza;
            fichaEditar.Estado = _estado;

            var r01 = Globals.MyData.PlanCta_Editar(fichaEditar);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Helpers.Msg.EditarOk();
            Handler_EditarOK(Ficha.Id);
            Close();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }

        private void Handler_EditarOK(int id)
        {
            EventHandler<int> handler = EditarOk;
            if (handler != null)
            {
                handler(this, id);
            }
        }

        private void Editar_KeyDown(object sender, KeyEventArgs e)
        {
            Control nextControl;
            //Checks if the Enter Key was Pressed
            if (e.KeyCode == Keys.Enter)
            {
                //If so, it gets the next control and applies the focus to it
                nextControl = GetNextControl(ActiveControl, !e.Shift);
                if (nextControl == null)
                {
                    nextControl = GetNextControl(null, true);
                }
                nextControl.Focus();
                //Finally - it suppresses the Enter Key
                e.SuppressKeyPress = true;
            }
        }

    }

}