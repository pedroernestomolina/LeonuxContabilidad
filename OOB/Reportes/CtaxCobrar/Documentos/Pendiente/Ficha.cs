using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Reportes.CtaxCobrar.Documentos.Pendiente
{

    public class Ficha
    {

        public DateTime DocFechaEmision { get; set; }
        public DateTime DocFechaVencimiento { get; set; }
        public string DocNumero { get; set; }
        public OOB.CtxCobrar.Enumerados.PorTipoDocumento DocTipo { get; set; }
        public decimal DocImporte { get; set; }
        public decimal DocResta { get; set; }
        public int DocSigno { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteCiRif { get; set; }
        public string ClienteCodigo { get; set; }
        public string VendedorNombre { get; set; }
        public string VendedorCodigo { get; set; }


        public string Vendedor 
        {
            get 
            {
                return VendedorCodigo.Trim() + "/" + VendedorNombre.Trim();
            }
        }

        public string Cliente 
        {
            get 
            {
                return ClienteCodigo + "-" + ClienteNombre;
            }
        }

        public int DiasAtraso 
        {
            get 
            {
                return (int) new DateTime(2019,09,09).Subtract(DocFechaVencimiento).TotalDays;
            }
        }

        public string DocTipoDescripcion 
        {
            get 
            {
                var tipo = "";
                switch (DocTipo) 
                {
                    case CtxCobrar.Enumerados.PorTipoDocumento.Factura:
                        tipo = "FAC";
                        break;
                    case CtxCobrar.Enumerados.PorTipoDocumento.NtCredito:
                        tipo = "NCR";
                        break;
                    case CtxCobrar.Enumerados.PorTipoDocumento.NtDebito :
                        tipo = "NDB";
                        break;
                }

                return tipo;
            }
        }


    }

}