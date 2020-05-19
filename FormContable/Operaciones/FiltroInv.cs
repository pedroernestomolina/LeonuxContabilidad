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

    public partial class FiltroInv : Form
    {

        public class Filt
        {
            public string TipoDocumento { get; set; }
        };

        public event EventHandler<Filt> FiltrosInvOk;
        private Filt _f;


        public FiltroInv(Filt f)
        {
            InitializeComponent();
            _f = f;
        }

        private void Filtros_Load(object sender, EventArgs e)
        {
            CargarData();
            CB_TIPO_DOCUMENTO.SelectedIndex = -1;

            if (_f.TipoDocumento != null) 
            {
                CB_TIPO_DOCUMENTO.SelectedItem = _f.TipoDocumento;
            }
        }

        private void CargarData()
        {
        }

        private void L_TIPO_DOCUMENTO_Click(object sender, EventArgs e)
        {
            CB_TIPO_DOCUMENTO.SelectedIndex = -1;
        }

        private void L_SUCURSAL_Click(object sender, EventArgs e)
        {
            CB_SUCURSAL.SelectedIndex = -1;
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            var filt = new Filt();
            if (CB_TIPO_DOCUMENTO.SelectedItem != null) 
            {
                filt.TipoDocumento = CB_TIPO_DOCUMENTO.SelectedItem.ToString();
            }

            Disparar_Filtros(filt);
            Close();
        }

        private void Disparar_Filtros(Filt filt)
        {
            EventHandler<Filt> handler = FiltrosInvOk;
            if (handler != null)
            {
                handler(this, filt);
            }
        }

    }

}