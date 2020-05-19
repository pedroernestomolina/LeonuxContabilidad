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

    public partial class Contabilizar : Form
    {

        public event EventHandler<DatosEncabezado> EncabezadoOk;

        public class DatosEncabezado 
        {
            public string Descripcion { get; set; }
            public OOB.Contable.Asiento.Enumerados.Tipo TipoAsiento { get; set; }
            public OOB.Contable.TipoDocumento.Ficha TipoDoc { get; set; }
        }

        private OOB.Contable.Contadores.Ficha Contadores;
        private int Preview;

        public Contabilizar(int preview = 0)
        {
            InitializeComponent();

            this.Preview = preview;
            CB_TIPO.SelectedIndex = 0;
            CB_DOCUMENTO.ValueMember = "Id";
            CB_DOCUMENTO.DisplayMember = "Descripcion";
        }

        private void Contabilizar_Load(object sender, EventArgs e)
        {
            CargarData();
        }

        private void CargarData()
        {
            var r01 = Globals.MyData.Contadores_Get();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var r02 = Globals.MyData.TipoDocumento_Lista();
            if (r02.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }

            Contadores = r01.Entidad;
            CB_DOCUMENTO.DataSource = r02.Lista;
            if (this.Preview == 0)
            {
                L_NUMERO.Text = Contadores.CntAsiento;
            }
            else
            {
                L_NUMERO.Text = Contadores.CntAsientoPreview;
            }
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            if (TB_DESCRIPCION.Text.Trim() == "") { return; }
            var ficha = new DatosEncabezado()
            {
                Descripcion = TB_DESCRIPCION.Text.Trim(),
                TipoAsiento = (OOB.Contable.Asiento.Enumerados.Tipo) (CB_TIPO.SelectedIndex+1),
                TipoDoc = (OOB.Contable.TipoDocumento.Ficha) CB_DOCUMENTO.SelectedItem
            };

            var msg = MessageBox.Show("Procesar Asiento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                Handler_EncabezadoOk(ficha);
            }
        }

        private void Handler_EncabezadoOk(DatosEncabezado ficha)
        {
            EventHandler<DatosEncabezado> handler = EncabezadoOk;
            if (handler != null)
            {
                handler(this, ficha);
            }
        }

    }

}