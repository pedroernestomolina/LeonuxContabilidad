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

    public partial class FiltroCxC : Form
    {

        public class Filt
        {
            public string Sucursal { get; set; }
        };

        public event EventHandler<Filt> FiltrosCxCOk;
        private Filt _f;


        public FiltroCxC(Filt f)
        {
            InitializeComponent();
            _f = f;
        }

        private void FiltroCxC_Load(object sender, EventArgs e)
        {
            CargarData();
            CB_SUCURSAL.SelectedIndex = -1;

            if (_f.Sucursal != null) 
            {
                CB_SUCURSAL.SelectedItem = _f.Sucursal;
            }
        }

        private void CargarData()
        {
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            var filt = new Filt();
            if (CB_SUCURSAL.SelectedItem != null)
            {
                filt.Sucursal = CB_SUCURSAL.SelectedItem.ToString();
            }

            Disparar_Filtros(filt);
            Close();
        }

        private void Disparar_Filtros(Filt filt)
        {
            EventHandler<Filt> handler = FiltrosCxCOk;
            if (handler != null)
            {
                handler(this, filt);
            }
        }

        private void L_SUCURSAL_Click(object sender, EventArgs e)
        {
            CB_SUCURSAL.SelectedItem = null;
        }

    }

}