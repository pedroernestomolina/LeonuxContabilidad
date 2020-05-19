using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxCobrar.Pago
{

    public class Ficha
    {

        public DateTime FechaRecibo { get; set; }
        public decimal TotalMontoRecibo { get; set; }
        public decimal TotalMontoRecibido { get; set; }
        public decimal TotalMontoAnticipos { get; set; }
        public decimal TotalMontoDescuentos { get; set; }
        public decimal TotalMontoRetenciones { get; set; }

        public string ClienteId { get; set; }
        public string ClienteCodigo { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteRif { get; set; }
        public string ClienteDireccion { get; set; }
        public string ClienteTelefono { get; set; }

        public string CobradorId { get; set; }
        public string CobradorCodigo { get; set; }
        public string CobradorNombre { get; set; }

        public string VendedorId { get; set; }
        public string VendedorCiRif { get; set; }
        public string VendedorCodigo { get; set; }
        public string VendedorNombre { get; set; }

        public string UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }

        public string Notas { get; set; }

        public decimal MontoFavorCliente { get; set; }
        public bool GenerarNotaCreditoMontoFavorCliente { get; set; }

        public List<DocumentoCxC> DocumentosCxcPagar { get; set; }
        public List<MedioPago> MediosPago { get; set; }
        public List<RetencionIva> RetencionesIva { get; set; }
        public List<Comision> Comisiones { get; set; }


    }

}