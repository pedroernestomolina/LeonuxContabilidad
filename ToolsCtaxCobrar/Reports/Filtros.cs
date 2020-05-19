using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ToolsCtaxCobrar.Reports
{
    
    public partial class Filtros : Form
    {

        public event EventHandler<FiltroBusqueda> FiltrosOK;
        private OOB.Empresa.DatosNegocio.Ficha DatosNegocio;
        private IFiltro TFiltro { get; set; }


        public Filtros(IFiltro tfiltro)
        {
            InitializeComponent();
            this.TFiltro = tfiltro;
        }

        private void Filtros_Load(object sender, EventArgs e)
        {
            CHB_DOC_DESDE.Enabled = TFiltro.IsDesdeHabilitado;
            CHB_DOC_HASTA.Enabled = TFiltro.IsHastaHabilitado;
            CB_VENDEDOR.Enabled = TFiltro.IsVendedorHabilitado;
            TB_CADENA.Enabled = TFiltro.IsClienteHabilitado;
            CB_TIPO_DOCUMENTO.Enabled = TFiltro.IsDocumentoHabilitado;
            CargarData();
        }

        public void Cerrar() 
        {
            this.Close();
        }

        private void CargarData()
        {
            var r02 = Globals.MyData.Empresa_DatosNegocio();
            if (r02.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }

            var r03 = Globals.MyData.Vendedor_Lista();
            if (r03.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return;
            }

            DatosNegocio = r02.Entidad;
            CB_VENDEDOR.DataSource = r03.Lista.OrderBy(v => v.Codigo).ToList();
            CB_VENDEDOR.DisplayMember = "Nombre";
            CB_VENDEDOR.ValueMember = "IdAuto";
            LimpiarFiltros();
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            CHB_DOC_DESDE.Checked = false;
            CHB_DOC_HASTA.Checked = false;
            DTP_DOC_DESDE.Value = DateTime.Now;
            DTP_DOC_HASTA.Value = DateTime.Now;

            CB_VENDEDOR.SelectedItem = null;
            CB_TIPO_DOCUMENTO.SelectedItem = null;
            TB_CADENA.Text = "";
        }

        private void CHB_DOC_DESDE_CheckedChanged(object sender, EventArgs e)
        {
            DTP_DOC_DESDE.Enabled = CHB_DOC_DESDE.Checked;
        }

        private void CHB_DOC_HASTA_CheckedChanged(object sender, EventArgs e)
        {
            DTP_DOC_HASTA.Enabled = CHB_DOC_HASTA.Checked;
        }

        private void LINK_POR_VENDEDOR_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CB_VENDEDOR.SelectedItem = null;
        }

        private void LINK_POR_TIPO_DOCUMENTO_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CB_TIPO_DOCUMENTO.SelectedItem = null;
        }

        private void LINK_POR_CLIENTE_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TB_CADENA.Text = "";
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            var busq = new FiltroBusqueda();
            if (CHB_DOC_DESDE.Checked) 
            {
                busq.Desde = DTP_DOC_DESDE.Value.Date;
            }
            if (CHB_DOC_HASTA.Checked)
            {
                busq.Hasta = DTP_DOC_HASTA.Value.Date;
            }
            if (CB_VENDEDOR.Enabled)
            {
                busq.Vendedor = (OOB.Vendedores.Vendedor.Ficha) CB_VENDEDOR.SelectedItem;
            }

            EventHandler<FiltroBusqueda> handler = FiltrosOK;
            if (handler != null)
            {
                handler(this, busq);
            }
        }
                  
    }

    public class FiltroBusqueda
    {
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public string Cliente { get; set; }
        public OOB.Vendedores.Vendedor.Ficha Vendedor { get; set; }
    }

}