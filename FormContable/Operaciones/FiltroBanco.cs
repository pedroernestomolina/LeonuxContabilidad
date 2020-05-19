using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.Operaciones
{

    public partial class FiltroBanco : Form
    {

        public class Filt
        {
            public OOB.Bancos.Enumerados.TipMovimiento TipoMovimiento { get; set; }

            public Filt()
            {
                TipoMovimiento = OOB.Bancos.Enumerados.TipMovimiento.SinDefinir;
            }
        };

        public event EventHandler<Filt> FiltrosBancoOk;
        private Filt _f;

        public FiltroBanco(Filt f)
        {
            InitializeComponent();
            _f = f;
        }

        private void FiltroBanco_Load(object sender, EventArgs e)
        {
            CargarData();

            CB_TIPO_MOVIMIENTO.SelectedIndex = -1;
            if (_f.TipoMovimiento != OOB.Bancos.Enumerados.TipMovimiento.SinDefinir)
            {
                CB_TIPO_MOVIMIENTO.SelectedIndex = ((int) _f.TipoMovimiento)-1 ;
            }
        }

        private void CargarData()
        {
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            var filt = new Filt();
            if ( CB_TIPO_MOVIMIENTO.SelectedItem != null)
            {
                filt.TipoMovimiento = (OOB.Bancos.Enumerados.TipMovimiento) (CB_TIPO_MOVIMIENTO.SelectedIndex + 1);
            }

            Disparar_Filtros(filt);
            Close();
        }

        private void Disparar_Filtros(Filt filt)
        {
            EventHandler<Filt> handler = FiltrosBancoOk;
            if (handler != null)
            {
                handler(this, filt);
            }
        }

        private void L_TIPO_MOVIMIENTO_Click(object sender, EventArgs e)
        {
            CB_TIPO_MOVIMIENTO.SelectedIndex = -1;
        }
       

    }

}