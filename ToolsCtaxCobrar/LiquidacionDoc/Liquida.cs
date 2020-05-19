using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.LiquidacionDoc
{

    public class Liquida
    {

        public OOB.CtxCobrar.Documentos.Pendiente.Ficha Ficha { get; set; }
        public DateTime FechaRecepcionMercancia { get; set; }
        public decimal MontoAbonado { get; set; }
        public decimal MontoPorRetencionIva { get; set; }
        public decimal MontoPorDescuento { get; set; }
        public decimal MontoPorAnticipo { get; set; }
        public bool IsSelected { get; set; }
        public RetencionIVa RetencionPorIva { get; set; }


        public Liquida()
        {
            IsSelected = false;
        }

        
        public decimal MontoRecibido
        { 
            get
            {
                return (MontoAbonado - (MontoPorRetencionIva + MontoPorAnticipo + MontoPorDescuento));
            } 
        }

        public string DocNro
        {
            get
            {
                return Ficha.DocumentoNro;
            }
        }

        public string DocTipo
        {
            get
            {
                return Ficha.DocumentoTipoDesc;
            }
        }

        public DateTime FechaEmi 
        {
            get 
            {
                return Ficha.FechaEmision;
            }
        }

        public DateTime FechaVto
        {
            get
            {
                return Ficha.FechaVencimiento;
            }
        }

        public decimal Saldo 
        {
            get
            {
                return (Ficha.Saldo);
            }
        }

        public decimal Total
        {
            get
            {
                return Ficha.Total;
            }
        }



    }

}
