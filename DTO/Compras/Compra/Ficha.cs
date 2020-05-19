using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Compras.Compra
{

    public class Ficha
    {

        public string Id { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Hora { get; set; }
        public string DocumentoNro { get; set; }
        public string ControlNro { get; set; }
        public string CodigoProveedor { get; set; }
        public string Proveedor{ get; set; }
        public string CiRif { get; set; }
        public string DireccionFiscal { get; set; }
        public string Telefono { get; set; }
        public Enumerados.TipoDocumento TipoDoc { get; set; }
        public string Usuario { get; set; }
        public string Estacion { get; set; }
        public decimal SubTotal_01 { get; set; }
        public decimal Decuento { get; set; }
        public decimal Cargo { get; set; }
        public decimal MontoExento { get; set; }
        public decimal MontoBase { get; set; }
        public decimal SubTotal_02 { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public int Renglones { get; set; }
        public string Notas { get; set; }
        public int MesRelacion { get; set; }
        public int AnoRelacion { get; set; }
        public string Concepto { get; set; }
        public string CodigoSucursal { get; set; }
        public List<Detalle> Detalles { get; set; }

    }

}
