using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.LiquidacionDoc
{

    public class Comision
    {

        public Liquida DocLiquidar { get; set; }
        public MedioPago Pago { get; set; }
        public decimal SobreEsteMontoRecibido { get; set; }


        public string DocumentoLiq
        {
            get
            {
                return DocLiquidar.DocNro;
            }
        }

        public string Banco
        {
            get
            {
                return Pago.BancoDesc;
            }
        }

        public string RefBanco
        {
            get
            {
                return Pago.Referencia;
            }
        }

        public decimal MontoBanco
        {
            get
            {
                return Pago.Importe;
            }
        }


        public decimal BaseCalculo 
        {
            get 
            {
                var m = 0.0m;
                m = SobreEsteMontoRecibido / DocLiquidar.Ficha.Total * DocLiquidar.Ficha.ImporteNeto;
                return m;
            }
        }

        public decimal ComisionMonto 
        { 
            get
            {
                var m = 0.0m;

                if (AplicaCastigo)
                {
                    m = BaseCalculo * DocLiquidar.Ficha.CastigoP / 100;
                }
                else 
                {
                    m = BaseCalculo * DocLiquidar.Ficha.ComisionCobranzaP / 100;
                }

                return m;
            }
        }

        public decimal ComisionPorc 
        {
            get
            {
                var m = 0.0m;

                if (AplicaCastigo)
                {
                    m = DocLiquidar.Ficha.CastigoP ;
                }
                else
                {
                    m = DocLiquidar.Ficha.ComisionCobranzaP ;
                }

                return m;
            }
        }

        public bool AplicaCastigo 
        { 
            get
            {
                var r = true;
                if (Pago.Fecha <= DocLiquidar.FechaRecepcionMercancia.AddDays(DocLiquidar.Ficha.DiasTolerancia))
                {
                    r=false;
                }
                return r;
            } 
        }

        public string AplicaCastigoDesc
        {
            get 
            {
                return AplicaCastigo == true ? "SI" : "NO";
            }
        }

        public int DiasTranscurridos 
        {
            get 
            {
                var f1 = DocLiquidar.FechaRecepcionMercancia;
                var d= (int)Pago.Fecha.Subtract(f1).TotalDays;
                return (d+1);
            }
        }

        public DateTime FechaMovBanco
        {
            get 
            {
                return Pago.Fecha;
            }
        }

        public DateTime FechaRecepcionMercancia
        {
            get 
            {
                return DocLiquidar.FechaRecepcionMercancia;
            }
        }

    }

}