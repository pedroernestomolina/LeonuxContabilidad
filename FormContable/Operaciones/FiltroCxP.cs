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

    public partial class FiltroCxP : Form
    {

        public class Filt
        {
            public string TipoDocumento { get; set; }
            public OOB.Proveedores.Proveedor.Ficha Proveedor { get; set; }
            public OOB.Bancos.Conceptos.Ficha Concepto { get; set; }
        };

        public event EventHandler<Filt> FiltrosCxPOk;
        private Filt _f;

        public FiltroCxP(Filt f)
        {
            InitializeComponent();
            _f = f;
        }

        private void FiltroCompra_Load(object sender, EventArgs e)
        {
            CB_PROVEEDOR.ValueMember = "Id";
            CB_PROVEEDOR.DisplayMember = "NombreRazonSocial";
            CB_CONCEPTO.ValueMember = "Id";
            CB_CONCEPTO.DisplayMember = "Descripcion";

            CargarData();

            CB_CONCEPTO.SelectedIndex = -1;
            CB_PROVEEDOR.SelectedIndex  = -1;
            CB_TIPO_DOCUMENTO.SelectedIndex = -1;

            if (_f.TipoDocumento != null) 
            {
                CB_TIPO_DOCUMENTO.SelectedItem = _f.TipoDocumento;
            }
            if (_f.Proveedor  != null)
            {
                CB_PROVEEDOR.SelectedValue = _f.Proveedor.Id;
            }
            if (_f.Concepto != null)
            {
                CB_CONCEPTO.SelectedValue = _f.Concepto.Id;
            }
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

            var r02 = Globals.MyData.Proveedores_Proveedor_Lista() ;
            if (r02.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }

            CB_CONCEPTO.DataSource = r01.Lista.OrderBy(t => t.Descripcion).ToList();
            CB_CONCEPTO.DisplayMember = "Descripcion";
            CB_PROVEEDOR.DataSource = r02.Lista.OrderBy(t => t.NombreRazonSocial).ToList();
            CB_PROVEEDOR.DisplayMember = "NombreRazonSocial";
        }

        private void L_TIPO_DOCUMENTO_Click(object sender, EventArgs e)
        {
            CB_TIPO_DOCUMENTO.SelectedIndex = -1;
        }

        private void L_PROVEEDOR_Click(object sender, EventArgs e)
        {
            CB_PROVEEDOR.SelectedItem=null;
        }

        private void L_CONCEPTO_Click(object sender, EventArgs e)
        {
            CB_CONCEPTO.SelectedItem = null;
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            var filt = new Filt();
            if (CB_TIPO_DOCUMENTO.SelectedItem != null)
            {
                filt.TipoDocumento = CB_TIPO_DOCUMENTO.SelectedItem.ToString();
            }

            if (CB_PROVEEDOR.SelectedItem != null)
            {
                filt.Proveedor = (OOB.Proveedores.Proveedor.Ficha)CB_PROVEEDOR.SelectedItem;
            }

            if (CB_CONCEPTO.SelectedItem != null)
            {
                filt.Concepto = (OOB.Bancos.Conceptos.Ficha)CB_CONCEPTO.SelectedItem;
            }

            Disparar_Filtros(filt);
            Close();
        }

        private void Disparar_Filtros(Filt filt)
        {
            EventHandler<Filt> handler = FiltrosCxPOk;
            if (handler != null)
            {
                handler(this, filt);
            }
        }

        private void L_SUCURSAL_Click(object sender, EventArgs e)
        {
            CB_SUCURSAL.SelectedIndex = -1;
        }

    }

}