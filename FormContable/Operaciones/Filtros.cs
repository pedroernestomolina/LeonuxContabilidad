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

    public partial class Filtros : Form
    {

        public class Filt
        {
            public Sucursal Sucursal { get; set; }
            public string TipoDocumento { get; set; }
            public string CondicionPago { get; set; }
            public string DenominacionFiscal { get; set; }
            public OOB.Empresa.SerialesFiscales.Ficha SerialFiscal { get; set; }
        };


        public event EventHandler<Filt> FiltrosVentaOk;
        private Filt _f;
        private List<Sucursal> sucursales;


        public Filtros(Filt f, List<Sucursal> _sucursales)
        {
            InitializeComponent();
            _f = f;
            sucursales = _sucursales;
        }


        private void Filtros_Load(object sender, EventArgs e)
        {
            CB_SUCURSAL.ValueMember = "Id";
            CB_SUCURSAL.DisplayMember = "SucursalDesc";
            CB_SERIAL_FISCAL.ValueMember = "Descripcion";
            CB_SERIAL_FISCAL.DisplayMember = "Descripcion";

            CargarData();
            CB_SUCURSAL.DataSource = sucursales;

            CB_SUCURSAL.SelectedIndex = -1;
            CB_TIPO_DOCUMENTO.SelectedIndex = -1;
            CB_CONDICION_PAGO.SelectedIndex = -1;
            CB_DENOMINACION_FISCAL.SelectedIndex = -1;
            CB_SERIAL_FISCAL.SelectedIndex=-1;

            if (_f.TipoDocumento != null) 
            {
                CB_TIPO_DOCUMENTO.SelectedItem = _f.TipoDocumento;
            }
            if (_f.CondicionPago != null) 
            {
                CB_CONDICION_PAGO.SelectedItem = _f.CondicionPago;
            }
            if (_f.DenominacionFiscal != null)
            {
                CB_DENOMINACION_FISCAL.SelectedItem = _f.DenominacionFiscal;
            }
            if (_f.SerialFiscal != null)
            {
                CB_SERIAL_FISCAL.SelectedValue = _f.SerialFiscal.Descripcion;
            }
            if (_f.Sucursal != null)
            {
                CB_SUCURSAL.SelectedValue = _f.Sucursal.Id;
            }
        }

        private void CargarData()
        {
            var r01 = Globals.MyData.Empresa_SerialesFiscales_Lista();
            if (r01.Result == OOB.Resultado.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            CB_SERIAL_FISCAL.DataSource = r01.Lista.OrderBy(t=>t.Descripcion).ToList();
        }

        private void L_TIPO_DOCUMENTO_Click(object sender, EventArgs e)
        {
            CB_TIPO_DOCUMENTO.SelectedIndex = -1;
        }

        private void L_CONDICION_PAGO_Click(object sender, EventArgs e)
        {
            CB_CONDICION_PAGO.SelectedIndex = -1;
        }

        private void L_DENOMIACION_FISCAL_Click(object sender, EventArgs e)
        {
            CB_DENOMINACION_FISCAL.SelectedIndex = -1;
        }

        private void L_SERIAL_FISCAL_Click(object sender, EventArgs e)
        {
            CB_SERIAL_FISCAL.SelectedIndex = -1;
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
            if (CB_CONDICION_PAGO.SelectedItem != null)
            {
                filt.CondicionPago = CB_CONDICION_PAGO.SelectedItem.ToString();
            }
            if (CB_DENOMINACION_FISCAL.SelectedItem != null)
            {
                filt.DenominacionFiscal = CB_DENOMINACION_FISCAL.SelectedItem.ToString();
            }
            if (CB_SERIAL_FISCAL.SelectedItem != null)
            {
                var it = (OOB.Empresa.SerialesFiscales.Ficha)CB_SERIAL_FISCAL.SelectedItem;
                filt.SerialFiscal = it;
            }
            if (CB_SUCURSAL.SelectedItem != null)
            {
                filt.Sucursal = (Sucursal)CB_SUCURSAL.SelectedItem;
            }

            Disparar_Filtros(filt);
            Close();
        }

        private void Disparar_Filtros(Filt filt)
        {
            EventHandler<Filt> handler = FiltrosVentaOk;
            if (handler != null)
            {
                handler(this, filt);
            }
        }


    }

}