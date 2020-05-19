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

    public partial class LiquidarDocForm : Form
    {

        public event EventHandler<Liquida> LiquidacionOk;
        private Liquida FichaLiquidar;
        private OOB.CtxCobrar.Documentos.Pendiente.Ficha Doc;
        private DateTime FechaSistema;
        private decimal MontoAbonado;
        private decimal MontoPorRetencionIva;
        private decimal MontoPorDescuento;
        private decimal MontoPorAnticipo;
        private RetencionIVa retencionPorIva;


        public decimal MontoRecibido
        {
            get
            {
                return (MontoAbonado - (MontoPorRetencionIva + MontoPorAnticipo + MontoPorDescuento));
            }
        }


        public LiquidarDocForm(Liquida doc)
        {
            InitializeComponent();
            this.FichaLiquidar = doc;
            MontoAbonado = 0;
            MontoPorAnticipo = 0;
            MontoPorDescuento = 0;
            MontoPorRetencionIva = 0;
        }

        public void CargarDoc()
        {
            var r01 = Globals.MyData.CtaxCobrar_Documentos_Pendiente_Get_ById(FichaLiquidar.Ficha.IdAuto);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var r02 = Globals.MyData.Servidor_GetFecha();
            if (r02.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }

            Doc = r01.Entidad;
            if (Doc.FechaRecepcionMercancia.HasValue)
            {
                DTP_FECHA_RECEPCION.Value = Doc.FechaRecepcionMercancia.Value;
            }
            MontoAbonado = Doc.Saldo;
            FechaSistema = r02.Entidad;

            if (Doc.DocumentoTipo == OOB.CtxCobrar.Enumerados.PorTipoDocumento.NtCredito)
            {
                FichaLiquidar.FechaRecepcionMercancia = Doc.FechaEmision.Date;
                FichaLiquidar.MontoAbonado = MontoAbonado;
                FichaLiquidar.MontoPorAnticipo = 0.0m;
                FichaLiquidar.MontoPorDescuento = 0.0m;
                FichaLiquidar.MontoPorRetencionIva = 0.0m;
                FichaLiquidar.Ficha = Doc;
                FichaLiquidar.RetencionPorIva = null;

                EventHandler<Liquida> handler = LiquidacionOk;
                if (handler != null)
                {
                    handler(this, FichaLiquidar);
                }
                Close();
            }
            else
            {
                ShowDialog();
            }
        }

        public void EditarDoc()
        {
            var r01 = Globals.MyData.Servidor_GetFecha();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Doc = FichaLiquidar.Ficha;
            DTP_FECHA_RECEPCION.Value = FichaLiquidar.FechaRecepcionMercancia;
            MontoAbonado = FichaLiquidar.MontoAbonado;
            MontoPorAnticipo = FichaLiquidar.MontoPorAnticipo;
            MontoPorDescuento = FichaLiquidar.MontoPorDescuento;
            MontoPorRetencionIva = FichaLiquidar.MontoPorRetencionIva;
            retencionPorIva = FichaLiquidar.RetencionPorIva;

            FechaSistema = r01.Entidad;
            ShowDialog();
        }

        private void LiquidarDocForm_Load(object sender, EventArgs e)
        {
            //if (Doc.HayFechaRecepcionMercancia) 
            //{
            //    DTP_FECHA_RECEPCION.Enabled = false;
            //}

            L_DOC_NRO.Text = Doc.DocumentoNro;
            L_DOC_FEMI.Text = Doc.FechaEmision.ToShortDateString();
            L_DOC_TIPO.Text = Doc.DocumentoTipoDesc;
            L_SALDO_PEND.Text = Doc.Saldo.ToString("n2");
            L_DOC_FVENC.Text = Doc.Vencimiento.ToShortDateString();
            L_DOC_DIAS_VENC.Text = Doc.DiasDeVencida(FechaSistema);

            TB_MONTO_ABONADO.Text = MontoAbonado.ToString();
            TB_MONTO_ANTICIPO.Text = MontoPorAnticipo.ToString("n2");
            TB_MONTO_DSCTO.Text = MontoPorDescuento.ToString("n2");
            TB_MONTO_RET_IVA.Text = MontoPorRetencionIva.ToString("n2");
            ActualizaMontoRecibido();
        }

        private void TB_MONTO_ABONADO_Validating(object sender, CancelEventArgs e)
        {
            decimal mt = 0.0m;
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            var culture = CultureInfo.CreateSpecificCulture("es-ES");
            if (!Decimal.TryParse(TB_MONTO_ABONADO.Text, style, culture, out mt))
            {
                errorProvider1.SetError(TB_MONTO_ABONADO, "NO ES UN VALOR NUMERICO");
                e.Cancel = true;
            }
            else
            {
                MontoAbonado = mt;
                errorProvider1.SetError(TB_MONTO_ABONADO, "");
                ActualizaMontoRecibido();
            }
        }

        private void TB_MONTO_DSCTO_Validating(object sender, CancelEventArgs e)
        {
            decimal mt = 0.0m;
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            var culture = CultureInfo.CreateSpecificCulture("es-ES");
            if (!Decimal.TryParse(TB_MONTO_DSCTO.Text, style, culture, out mt))
            {
                errorProvider1.SetError(TB_MONTO_DSCTO, "NO ES UN VALOR NUMERICO");
                e.Cancel = true;
            }
            else
            {
                MontoPorDescuento = mt;
                errorProvider1.SetError(TB_MONTO_DSCTO, "");
                ActualizaMontoRecibido();
            }
        }

        private void TB_MONTO_ANTICIPO_Validating(object sender, CancelEventArgs e)
        {
            decimal mt = 0.0m;
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            var culture = CultureInfo.CreateSpecificCulture("es-ES");
            if (!Decimal.TryParse(TB_MONTO_ANTICIPO.Text, style, culture, out mt))
            {
                errorProvider1.SetError(TB_MONTO_ANTICIPO, "NO ES UN VALOR NUMERICO");
                e.Cancel = true;
            }
            else
            {
                MontoPorAnticipo = mt;
                errorProvider1.SetError(TB_MONTO_ANTICIPO, "");
                ActualizaMontoRecibido();
            }
        }

        private void TB_MONTO_RET_IVA_Validating(object sender, CancelEventArgs e)
        {
            decimal mt = 0.0m;
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            var culture = CultureInfo.CreateSpecificCulture("es-ES");
            if (!Decimal.TryParse(TB_MONTO_RET_IVA.Text, style, culture, out mt))
            {
                errorProvider1.SetError(TB_MONTO_RET_IVA, "NO ES UN VALOR NUMERICO");
                e.Cancel = true;
            }
            else
            {
                MontoPorRetencionIva = mt;
                errorProvider1.SetError(TB_MONTO_RET_IVA, "");
                ActualizaMontoRecibido();
            }
        }

        private void ActualizaMontoRecibido()
        {
            TB_MONTO_RECIBIDO.Text = MontoRecibido.ToString("n2");
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            if (MontoRecibido < 0) { return; }

            if (MontoRecibido <= FichaLiquidar.Ficha.Saldo)
            {
                DialogResult msg = MessageBox.Show("Procesar Liquidación ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (msg == System.Windows.Forms.DialogResult.Yes)
                {
                    FichaLiquidar.FechaRecepcionMercancia = DTP_FECHA_RECEPCION.Value.Date;
                    FichaLiquidar.MontoAbonado = MontoAbonado;
                    FichaLiquidar.MontoPorAnticipo = MontoPorAnticipo;
                    FichaLiquidar.MontoPorDescuento = MontoPorDescuento;
                    FichaLiquidar.MontoPorRetencionIva = MontoPorRetencionIva;
                    FichaLiquidar.Ficha = Doc;
                    FichaLiquidar.RetencionPorIva = retencionPorIva;

                    EventHandler<Liquida> handler = LiquidacionOk;
                    if (handler != null)
                    {
                        handler(this, FichaLiquidar);
                    }

                    Close();
                }
            }
            else
            {
                Helpers.Msg.Error("Monto Recibido Mayor Al Saldo Pendiente");
            }
        }

        private void L_RETENCION_IVA_DoubleClick(object sender, EventArgs e)
        {
            RetencionIVa();
        }

        private void RetencionIVa()
        {
            var yaAplicoRetIva = false;

            if (Doc.IdAutoDocumentoVenta != "")
            {
                var r01 = Globals.MyData.Venta_Documento_Aplico_RetencionIva(Doc.IdAutoDocumentoVenta);
                if (r01.Result == OOB.Resultado.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                yaAplicoRetIva = r01.Entidad;
            }
            else 
            {
                var r01 = Globals.MyData.Venta_Documento_Aplico_RetencionIva("",Doc.DocumentoNro);
                if (r01.Result == OOB.Resultado.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                yaAplicoRetIva = r01.Entidad;
            }

            if (yaAplicoRetIva) // DOCUMENTO YA APLICO RETENCION
            {
                Helpers.Msg.Alerta("Mostrar Documento De Retencion");
            }
            else
            {
                var rtFrm = new RetencionIvaForm(Doc);
                rtFrm.RetencionIvaOk += rtFrm_RetencionIvaOk;
                if (retencionPorIva == null)
                {
                    rtFrm.CargarDocumento(Doc.IdAutoDocumentoVenta);
                }
                else
                {
                    rtFrm.EditarDocumento(retencionPorIva);
                }
            }
        }

        private void rtFrm_RetencionIvaOk(object sender, LiquidacionDoc.RetencionIVa e)
        {
            retencionPorIva = e;
            MontoPorRetencionIva = e.MontoRetencion;
            TB_MONTO_RET_IVA.Text = MontoPorRetencionIva.ToString("n2");
            ActualizaMontoRecibido();
        }

        private void LL_MONTO_POR_RET_IVA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RetencionIVa();
        }

        private void DTP_FECHA_RECEPCION_Validating(object sender, CancelEventArgs e)
        {
            if (DTP_FECHA_RECEPCION.Value.Date < Doc.FechaEmision || DTP_FECHA_RECEPCION.Value.Date > FechaSistema)
            {
                errorProvider1.SetError(DTP_FECHA_RECEPCION, "FECHA INCORRECTA");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(DTP_FECHA_RECEPCION, "");
            }
        }


    }

}