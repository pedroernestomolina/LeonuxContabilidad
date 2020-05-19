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

    public class PeriodoSeleccion
    {

        public OOB.Contable.Periodo.Ficha Desde { get; set; }
        public OOB.Contable.Periodo.Ficha Hasta { get; set; }

    }

    public partial class SeleccionarPeriodo : Form
    {

        public event EventHandler<PeriodoSeleccion> PeriodoSeleccionadoOk;
        private List<OOB.Contable.Periodo.Ficha> DESDE;
        private List<OOB.Contable.Periodo.Ficha> HASTA;

        public SeleccionarPeriodo()
        {
            InitializeComponent();
        }

        private void SeleccionarPeriodo_Load(object sender, EventArgs e)
        {
            if (CargarData())
            {
                CB_DESDE.ValueMember = "Id";
                CB_DESDE.DisplayMember = "Periodo";
                CB_DESDE.DataSource = DESDE;

                CB_HASTA.ValueMember = "Id";
                CB_HASTA.DisplayMember = "Periodo";
                CB_HASTA.DataSource = HASTA;
            }
        }

        private bool CargarData()
        {
            var r01 = Globals.MyData.Periodo_Lista();
            if (r01.Result == OOB.Resultado.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            DESDE = r01.Lista.OrderBy(o=>o.MesActual).OrderBy(o=>o.AnoActual).ToList();
            HASTA = r01.Lista.OrderBy(o => o.MesActual).OrderBy(o => o.AnoActual).ToList();
            return true;
        }

        private void BT_SELECCION_Click(object sender, EventArgs e)
        {
            if (CB_DESDE.SelectedItem != null && CB_HASTA.SelectedItem != null)
            {
                var desde = (OOB.Contable.Periodo.Ficha) CB_DESDE.SelectedItem;
                var hasta = (OOB.Contable.Periodo.Ficha) CB_HASTA.SelectedItem;
                var seleccion = new PeriodoSeleccion()
                {
                    Desde = desde,
                    Hasta = hasta,
                };

                EventHandler<PeriodoSeleccion> handler = PeriodoSeleccionadoOk;
                if (handler != null)
                {
                    handler(this, seleccion);
                }
                Close();
            }
        }

    }

}