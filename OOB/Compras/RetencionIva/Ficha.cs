using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Compra.RetencionIva
{
    public class Ficha
    {
        public DateTime FechaEmision { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string DocumentoNro { get; set; }
        public string ProvCodigo { get; set; }
        public string ProvNombreRazonSocial { get; set; }
        public string ProvCiRif { get; set; }
        public string ProvDireccionFiscal { get; set; }
        public string ProvTelefono { get; set; }
        public decimal MontoExento { get; set; }
        public decimal MontoBase { get; set; }
        public decimal MontoImpuesto { get; set; }
        public decimal Total { get; set; }
        public decimal TasaRetencion { get; set; }
        public decimal MontoRetencion { get; set; }
        public string MesRelacion { get; set; }
        public string AnoRelacion { get; set; }
        public int Renglones { get; set; }
        public List<Detalle> Detalles { get; set; }

        public string Proveedor
        {
            get 
            {
                return ProvCiRif + Environment.NewLine + ProvNombreRazonSocial + Environment.NewLine + ProvDireccionFiscal;
            }
        }

        public string Periodo
        {
            get 
            {
                return AnoRelacion + "-" + MesRelacion;
            }
        }

        public string TasaRetencionDesc 
        {
            get 
            {
                return TasaRetencion.ToString("n2")+"%";
            }
        }
      
    }
}