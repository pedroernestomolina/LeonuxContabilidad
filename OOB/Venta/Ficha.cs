using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Venta
{

    public class Ficha
    {

        public string Id { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Hora { get; set; }
        public Enumerados.CondicionPago CondicionPago { get; set; }
        public string DocumentoNro { get; set; }
        public string serialFiscal { get; set; }
        public string RazonSocial { get; set; }
        public string CiRif { get; set; }
        public string DireccionFiscal { get; set; }
        public string Telefono { get; set; }
        public Enumerados.TipoDocumento TipoDoc { get; set; }
        public string Usuario { get; set; }
        public string Estacion { get; set; }
        public decimal SubTotal_01 { get; set; }
        public decimal Decuento { get; set; }
        public decimal MontoExento { get; set; }
        public decimal MontoBase { get; set; }
        public decimal SubTotal_02 { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public int Renglones { get; set; }
        public decimal TasaIva_1 { get; set; }
        public decimal TasaIva_2 { get; set; }
        public decimal TasaIva_3 { get; set; }
        public string CodigoSucursal { get; set; }
        public List<FichaDetalle> Detalles { get; set; }
        public List<Pago> Pagos { get; set; }

        public string Cliente 
        {
            get
            {
                return CiRif + Environment.NewLine + RazonSocial + Environment.NewLine + DireccionFiscal;
            }
        }

        public string TipoDocumentoDesc
        {
            get
            {
                switch (TipoDoc)
                {
                    case Enumerados.TipoDocumento.Factura:
                        return "FACTURA";
                    case Enumerados.TipoDocumento.NCredito:
                        return "NOTA DE CREDITO";
                    case Enumerados.TipoDocumento.NDebito:
                        return "NOTA DE DEBITO";
                    default:
                        return "";
                }
            }
        }

        public string CondicionPagoDesc
        {
            get
            {
                switch (CondicionPago)
                {
                    case Enumerados.CondicionPago.Contado:
                        return "CONTADO";
                    case Enumerados.CondicionPago.Credito:
                        return "CREDITO";
                    default:
                        return "";
                }
            }
        }

        public string UsuarioEstacion 
        {
            get 
            {
                return Usuario + Environment.NewLine + Estacion;
            }
        }


    }
}