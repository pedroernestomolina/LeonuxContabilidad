using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxCobrar.Documentos.Pendientes
{

    public class Ficha
    {

        public string IdAuto { get; set; }
        public string IdAutoVendedor { get; set; }
        public string IdAutoDocumentoVenta { get; set; }
        public string IdAutCliente {get;set;}
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaRecepcionMercancia { get; set; }
        public string DocumentoNro { get; set; }
        public string DocumentoSerie { get; set; }
        public Enumerados.PorTipoDocumento DocumentoTipo { get; set; }
        public decimal Importe { get; set; }
        public decimal Abonado { get; set; }
        public string Detalle { get; set; }
        public int Signo { get; set; }
        public bool IsAnulado { get; set; }
        public bool IsCancelado { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteCiRif { get; set; }
        public string ClienteCodigo { get; set; }
        public decimal ComisionCobranzaP { get; set; }
        public decimal ComisionVentaP { get; set; }
        public decimal CastigoP { get; set; }
        public decimal ImporteNeto { get; set; }
        public int DiasTolerancia { get; set; }

    }

}