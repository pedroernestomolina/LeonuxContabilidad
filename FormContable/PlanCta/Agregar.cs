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

    public partial class Agregar : Form
    {
        public event EventHandler<int> AgregarOK=null;
        public event EventHandler CerrarOk=null ;
        public bool SetReusarPlantilla { get; set; }
        
        public Agregar()
        {
            InitializeComponent();
            SetReusarPlantilla = true;
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            this.KeyDown+=Agregar_KeyDown;                 ;     
            MenuReusarPlantilla.Visible = SetReusarPlantilla;
            TB_CODIGO.Select();
            CB_NATURALEZA.SelectedIndex = 0;
            CB_TIPO.SelectedIndex = 0;
            CB_ESTADO.SelectedIndex = 0;
        }

        private void Handler_AgregarOK(int id)
        {
            EventHandler<int> handler = AgregarOK;
            if (handler != null)
            {
                handler(this, id);
            }
        }

        private void Handler_CerrarOK()
        {
            EventHandler handler = CerrarOk;
            if (handler != null)
            {
                handler(this, null);
            }
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            if (TB_CODIGO.Text.Trim() == "") { return; }
            if (TB_DESCRIPCION.Text.Trim() == "") { return; }
            if (CB_NATURALEZA.SelectedIndex == -1) { return; }
            if (CB_TIPO.SelectedIndex == -1) { return; }
            if (CB_ESTADO.SelectedIndex == -1) { return; }
                      
            var _tipo = CB_TIPO.SelectedIndex==0? OOB.Contable.PlanCta.Enumerados.Tipo.Auxiliar : OOB.Contable.PlanCta.Enumerados.Tipo.Totalizadora ;
            var _naturaleza = CB_NATURALEZA.SelectedIndex==0 ? OOB.Contable.PlanCta.Enumerados.Naturaleza.Deudora : OOB.Contable.PlanCta.Enumerados.Naturaleza.Acreedora ;
            var _estado = CB_ESTADO.SelectedIndex == 0 ? OOB.Contable.PlanCta.Enumerados.EstadoSituacion.Financiero : OOB.Contable.PlanCta.Enumerados.EstadoSituacion .Resultados ;
            var codigo = "";
            var tb = TB_CODIGO.Text.Trim();
            codigo = Helpers.Cuenta.ValidarCodigoCuenta(tb);

            if (codigo == "") 
            {
                Helpers.Msg.Error("CODIGO DE CUENTA INCORRECTO");
                return;
            }

            var r01 = Globals.MyData.PlanCta_GetPadre(codigo);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var FichaAgregar = new OOB.Contable.PlanCta.Agregar();
            FichaAgregar.IdCtaPadre = r01.Entidad.Id;
            FichaAgregar.Nivel = r01.Entidad.nivel ;
            FichaAgregar.Codigo = codigo;
            FichaAgregar.Descripcion = TB_DESCRIPCION.Text;
            FichaAgregar.Tipo = _tipo ;
            FichaAgregar.Naturaleza = _naturaleza ;
            FichaAgregar.Estado = _estado;

            var result_01 = Globals.MyData.PlanCta_Agregar(FichaAgregar);
            if (result_01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(result_01.Mensaje);
                return;
            }

            Helpers.Msg.AgregarOk();
            Handler_AgregarOK(result_01.Id);
            if (SetReusarPlantilla == false)
            {
                Handler_CerrarOK();
            }
            else
            {
                if (!MenuReusarPlantilla.Checked)
                {
                    Handler_CerrarOK();
                }
            }
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }

        private void Agregar_KeyDown(object sender, KeyEventArgs e)
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