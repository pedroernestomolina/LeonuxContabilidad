using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.Periodo
{

    public partial class CerrarMes : Form
    {

        public event EventHandler CerrarOk;
        private OOB.Contable.Periodo.Ficha _periodo;

        public CerrarMes(OOB.Contable.Periodo.Ficha periodo)
        {
            InitializeComponent();
            _periodo = periodo;
        }

        private void CerrarMes_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Cerrar();
        }

        private void Cerrar()
        {
            var msg = MessageBox.Show("Udted Esta Inentando Hacer El Cierre, Ya Generó Los Libros ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                msg = MessageBox.Show("Cerrar El Mes Actual ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == System.Windows.Forms.DialogResult.Yes)
                {
                    var r01 = Globals.MyData.Periodo_Utilidad();
                    if (r01.Result == OOB.Resultado.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    var utilidad_periodo = r01.Entidad;

                    var r01_01 = Globals.MyData.Utilidad_Acumulada();
                    if (r01_01.Result == OOB.Resultado.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01_01.Mensaje);
                        return;
                    }
                    var utilidad_acumulada = r01_01.Entidad * (-1);

                    var r02 = Globals.MyData.Configuracion_CtasCierre();
                    if (r02.Result == OOB.Resultado.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02.Mensaje);
                        return;
                    }

                    if (r02.Entidad== null)
                    {
                        Helpers.Msg.Error("CUENTAS CIERRE NO DEFINIDA");
                        return;
                    }

                    if (r02.Entidad.CtaCierreMes  == null)
                    {
                        Helpers.Msg.Error("CUENTA CIERRE PERIODO NO DEFINIDA");
                        return;
                    }

                    //SALDO DE CUENTA UTILIDAD DEL EJERCICIO
                    var r02_01 = Globals.MyData.PlanCta_GetById(r02.Entidad.CtaCierreMes.Id);
                    if (r02_01.Result == OOB.Resultado.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02_01.Mensaje);
                        return;
                    }
                    var xmov = (r02_01.Entidad.Debe + r02_01.Entidad.Haber);

                    var utilidad=(utilidad_acumulada +utilidad_periodo)+xmov;
                    var ficha = new OOB.Contable.Periodo.CerrarMes()
                    {
                        PeriodoActual = _periodo,
                        UtilidadPeriodo = utilidad_periodo*(-1),
                        UtilidadAcumulada= utilidad*(-1),
                        CuentaCierreMes = r02.Entidad.CtaCierreMes,
                    };
                    var r03 = Globals.MyData.Periodo_Cerrar(ficha);
                    if (r03.Result == OOB.Resultado.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r03.Mensaje);
                        Close();
                    }

                    EventHandler handler = CerrarOk;
                    if (handler != null)
                    {
                        handler(this, null);
                    }

                    Helpers.Msg.OK("PROCESO REALIZADO EXITOSAMENTE ..... !!!!");
                    Close();
                }
                else
                {
                    button1.Enabled = true;
                }
            }
            else 
            {
                button1.Enabled = true;
            }
        }

    }

}