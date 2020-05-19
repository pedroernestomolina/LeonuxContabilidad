using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ToolsCtaxCobrar.LiquidacionDoc
{

    public partial class RetencionIvaForm : Form
    {

        public event EventHandler<RetencionIVa> RetencionIvaOk;
        private decimal TasaRetencion;
        private decimal MontoRetencion;
        private decimal MontoExcento;
        private decimal MontoImpuesto;
        private decimal MontoBase;
        private decimal TasaIva;
        private decimal Total;
        private DateTime FechaEmisionDoc;
        private OOB.Venta.Ficha DocVenta;
        private OOB.CtxCobrar.Documentos.Pendiente.Ficha DocCxCPend;
        private DateTime FechaSistema;


        public RetencionIvaForm(OOB.CtxCobrar.Documentos.Pendiente.Ficha doc)
        {
            InitializeComponent();
            Inicializar();
            this.DocCxCPend = doc;
        }

        private void Inicializar()
        {
            DocVenta = null;
            TasaRetencion = 75;
            TasaIva = 0.0m;
            MontoRetencion = 0.0m;
            L_MONTO_RETENCION.Text = MontoRetencion.ToString("n2");
            TB_TASA_RETENCION.Text = TasaRetencion.ToString("n2");
            TB_TASA_IVA.Text=TasaIva.ToString("n2");
        }

        public void CargarDocumento(string idDoc)
        {
            var r00 = Globals.MyData.Servidor_GetFecha();
            if (r00.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            FechaSistema = r00.Entidad;

            var r01 = Globals.MyData.Venta_Documento_Existe(idDoc);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            if (r01.Entidad == true)
            {
                var r02 = Globals.MyData.Venta_GetById(idDoc);
                if (r02.Result == OOB.Resultado.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }

                var doc = r02.Entidad;
                MontoExcento = doc.MontoExento;
                MontoImpuesto = doc.Impuesto;
                MontoBase = doc.MontoBase;
                Total = doc.Total;
                DocVenta = doc;
                FechaEmisionDoc = doc.FechaEmision;
                TasaIva = doc.TasaIva_1;

                TB_DOCUMENTO.Text = doc.DocumentoNro;
                TB_CONTROL.Text = doc.serialFiscal;
                TB_MONTO_EXCENTO.Text = MontoExcento.ToString("n2");
                TB_MONTO_BASE.Text = MontoBase.ToString("n2");
                TB_MONTO_IMPUESTO.Text = MontoImpuesto.ToString("n2");
                TB_TOTAL.Text = Total.ToString("n2");
                TB_TASA_IVA.Text = TasaIva.ToString("n2");
            }
            else
            {
                TB_CONTROL.Enabled = true;
                TB_CONTROL.ReadOnly = false;
                TB_TASA_IVA.Enabled = true;
                TB_TASA_IVA.ReadOnly = false;

                MontoExcento = 0.0m;
                MontoBase = DocCxCPend.ImporteNeto;
                Total = DocCxCPend.Total ;
                MontoImpuesto = Total-MontoBase ;
                FechaEmisionDoc = DocCxCPend.FechaEmision;
                TasaIva = Math.Round((MontoImpuesto / MontoBase) * 100, 2, MidpointRounding.AwayFromZero);

                TB_DOCUMENTO.Text = DocCxCPend.DocumentoNro; 
                TB_CONTROL.Text = "";
                TB_MONTO_EXCENTO.Text = MontoExcento.ToString("n2");
                TB_MONTO_BASE.Text = MontoBase.ToString("n2");
                TB_MONTO_IMPUESTO.Text = MontoImpuesto.ToString("n2");
                TB_TASA_IVA.Text = TasaIva.ToString("n2");
                TB_TOTAL.Text = Total.ToString("n2");
            }

            ShowDialog();
        }

        public void EditarDocumento(RetencionIVa doc)
        {
            var r00 = Globals.MyData.Servidor_GetFecha();
            if (r00.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            FechaSistema = r00.Entidad;

            MontoExcento = doc.MontoExcento ;
            MontoImpuesto = doc.MontoImpuesto ;
            MontoBase = doc.MontoBase;
            TasaRetencion=doc.TasaRetencion;
            MontoRetencion=doc.MontoRetencion;
            Total = doc.MontoTotal;
            TasaIva = doc.TasaIva;
            DocVenta = doc.Documento;

            if (DocVenta == null) 
            {
                TB_CONTROL.Enabled = true;
                TB_CONTROL.ReadOnly = false;
                TB_TASA_IVA.Enabled = true;
                TB_TASA_IVA.ReadOnly = false;
            }

            TB_COMPROBANTE.Text = doc.ComprobanteNro;
            TB_DOCUMENTO.Text = doc.DocumentoNro ;
            TB_CONTROL.Text = doc.NroControl ;
            TB_MONTO_EXCENTO.Text = MontoExcento.ToString("n2");
            TB_MONTO_BASE.Text = MontoBase.ToString("n2");
            TB_MONTO_IMPUESTO.Text = MontoImpuesto.ToString("n2");
            TB_TOTAL.Text = Total.ToString("n2");
            DTP_FECHA_RETENCION.Value = doc.FechaRetencion;
            TB_TASA_IVA.Text = TasaIva.ToString("n2");
            TB_TASA_RETENCION.Text = TasaRetencion.ToString("n2");
            ActualizarMonto();

            ShowDialog();
        }


        private void RetencionIvaForm_Load(object sender, EventArgs e)
        {
        }

        private void TB_TASA_RETENCION_Validating(object sender, CancelEventArgs e)
        {
            decimal mt = 0.0m;
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            var culture = CultureInfo.CreateSpecificCulture("es-ES");
            if (!Decimal.TryParse(TB_TASA_RETENCION.Text, style, culture, out mt))
            {
                errorProvider1.SetError(TB_TASA_RETENCION, "NO ES UN VALOR NUMERICO");
                e.Cancel = true;
            }
            else
            {
                TasaRetencion = mt;
                errorProvider1.SetError(TB_TASA_RETENCION, "");
                ActualizarMonto();
            }
        }

        private void ActualizarMonto()
        {
            MontoRetencion = MontoImpuesto * TasaRetencion / 100;
            L_MONTO_RETENCION.Text = MontoRetencion.ToString("n2");
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            if (MontoRetencion <= 0)
            { return; }

            if (string.IsNullOrEmpty(TB_COMPROBANTE.Text.Trim()))
            { return; }

            if (DTP_FECHA_RETENCION.Value.Date < FechaEmisionDoc || DTP_FECHA_RETENCION.Value.Date > FechaSistema)
            { return; }

            var retencion = new RetencionIVa()
            {
                ComprobanteNro = TB_COMPROBANTE.Text,
                FechaRetencion = DTP_FECHA_RETENCION.Value,
                MontoBase = MontoBase,
                MontoExcento = MontoExcento,
                MontoImpuesto = MontoImpuesto,
                MontoRetencion = MontoRetencion,
                MontoTotal=Total,
                TasaIva = this.TasaIva,
                TasaRetencion = TasaRetencion,
                DocumentoNro=TB_DOCUMENTO.Text,
                NroControl = TB_CONTROL.Text,
                FechaEmision=FechaEmisionDoc,
                Documento = DocVenta,
            };
            EventHandler<RetencionIVa> handler = RetencionIvaOk;
            if (handler != null)
            {
                handler(this, retencion);
            }

            Close();
        }

        private void DTP_FECHA_RETENCION_Validating(object sender, CancelEventArgs e)
        {
            if (DTP_FECHA_RETENCION.Value.Date < DocCxCPend.FechaEmision || DTP_FECHA_RETENCION.Value.Date  > FechaSistema)
            {
                errorProvider1.SetError(DTP_FECHA_RETENCION, "FECHA INCORRECTA");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(DTP_FECHA_RETENCION, "");
            }
        }

    }

}