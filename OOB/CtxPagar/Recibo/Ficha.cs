using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.CtxPagar.Recibo
{

    public class Ficha
    {
        public DateTime FechaEmision { get; set; }
        public string DocumentoNro { get; set; }
        public string ProvCodigo { get; set; }
        public string ProvNombreRazonSocial { get; set; }
        public string ProvCiRif { get; set; }
        public string ProvDireccionFiscal { get; set; }
        public string Usuario { get; set; }
        public string Estacion { get; set; }
        public decimal Importe { get; set; }
        public string Notas { get; set; }
        public List<Documento> Documentos { get; set; }
        public Pago FormaPago { get; set; }

        public string Proveedor
        {
            get
            {
                return ProvCiRif + Environment.NewLine + ProvNombreRazonSocial.Trim() + Environment.NewLine + ProvDireccionFiscal;
            }
        }

        public string UsuarioEstacion
        {
            get
            {
                return Usuario + Environment.NewLine + Estacion ;
            }
        }

    }

}
