using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.Banco.Movimiento
{

    public partial class VisualizarDocumento : Form
    {

        public VisualizarDocumento()
        {
            InitializeComponent();
        }

        public void CargarDocumento(string doc)
        {
            var r01 = Globals.MyData.Banco_Movimiento_GetById(doc);
            if (r01.Result == OOB.Resultado.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var FichaVenta = r01.Entidad;
            TB_DOCUMENTO.Text = FichaVenta.DocumentoReferencia;
            TB_FECHA.Text = FichaVenta.FechaEmision.ToShortDateString();
            TB_BANCO.Text = FichaVenta.BancoDescripcion;
            TB_DETALLE.Text = FichaVenta.DetalleMovimiento;
            TB_TIPO_MOVIMIENTO.Text = FichaVenta.TipoMovimientoDescripcion;
            L_TOTAL.Text = FichaVenta.Importe.ToString("n2");
            L_CONCILIADO.Text = "SI";
            if (!FichaVenta.IsConciliado) 
            {
                L_CONCILIADO.Text = "NO";
            }

            ShowDialog();
        }

        private void VisualizarDocumento_Load(object sender, EventArgs e)
        {
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }
     
    }

}