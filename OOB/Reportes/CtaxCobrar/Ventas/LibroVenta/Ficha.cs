using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Reportes.CtaxCobrar.Ventas.LibroVenta
{

    public class Ficha
    {

        public string IdAuto { get; set; }
        public DateTime FechaEmision { get; set; }
        public string CiRif { get; set; }
        public string RazonSocial { get; set; }
        public string ComprobanteRetencionNro { get; set; }
        public string FacturaNro { get; set; }
        public string ControlNro { get; set; }
        public string NCreditoNro { get; set; }
        public string NDebitoNro { get; set; }
        public OOB.Venta.Enumerados.TipoDocumento TipoDocumento { get; set; }
        public string DocumentoAfectaNro { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal TotalExcento { get; set; }
        public decimal TotalBase { get; set; }
        public decimal TotalImpuesto { get; set; }
        public decimal TasaAlicuota { get; set; }
        public decimal TotalIvaRetenido { get; set; }
        public DateTime FechaRetencion { get; set; }
        public int Signo { get; set; }
        public bool IsRetencion { get; set; }
        public bool IsAnulado { get; set; }

        public bool AplicaRetencion 
        {
            get 
            {
                var r=false;
                if (IsRetencion == false) 
                {
                    if (!string.IsNullOrEmpty(ComprobanteRetencionNro.Trim())) 
                    {
                        r = true;
                    }
                }
                return r;
            }
        }

    }

}