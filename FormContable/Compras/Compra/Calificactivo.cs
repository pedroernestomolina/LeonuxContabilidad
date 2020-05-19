using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.Compras.Compra
{

    public partial class Calificactivo : Form
    {

        public event EventHandler<OOB.Bancos.Conceptos.Ficha> CalificativoOk;
        
        public Calificactivo()
        {
            InitializeComponent();
        }

        private void Calificactivo_Load(object sender, EventArgs e)
        {
            CB_CALIFICATIVO.ValueMember = "Id";
            CB_CALIFICATIVO.DisplayMember = "Descripcion";
            CargarData();
        }

        private void CargarData()
        {
            var r01 = Globals.MyData.Banco_Concepto_Lista("",
                OOB.Bancos.Conceptos.Enumerados.TipoLista.Resumen, 
                OOB.Bancos.Conceptos.Enumerados.TipoMovimiento.Egreso);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            CB_CALIFICATIVO.DataSource = r01.Lista.OrderBy(t => t.Descripcion).ToList();
            CB_CALIFICATIVO.DisplayMember = "Descripcion";
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            if (CB_CALIFICATIVO.SelectedItem != null)
            {
                var calificativo = (OOB.Bancos.Conceptos.Ficha) CB_CALIFICATIVO.SelectedItem;

                EventHandler<OOB.Bancos.Conceptos.Ficha > handler = CalificativoOk;
                if (handler != null)
                {
                    handler(this, calificativo);
                }

                Close();
            }
        }

    }
}