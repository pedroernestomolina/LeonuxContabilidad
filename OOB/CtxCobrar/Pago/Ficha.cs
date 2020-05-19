using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.CtxCobrar.Pago
{

    public class Ficha
    {
   
        public OOB.Vendedores.Vendedor.Ficha Vendedor { get; set; }
        public OOB.Empresa.Cobradores.Ficha Cobrador { get; set; }
        public OOB.Usuarios.Usuario.Ficha Usuario { get; set; }

        public string ClienteId { get; set; }
        public string ClienteCiRif { get; set; }
        public string ClienteCodigo { get; set; }
        public string ClienteRazonSocial { get; set; }
        public string ClienteDirFiscal { get; set; }
        public string ClienteTelefono { get; set; }

        public DateTime FechaRecibo { get; set; }
        public decimal MontoRecibo { get; set; }
        public decimal MontoRecibido { get; set; }
        public decimal MontoAnticipos { get; set; }
        public decimal MontoDescuentos { get; set; }
        public decimal MontoRetenciones { get; set; }
        public string Notas { get; set; }

        public decimal MontoFavorCliente { get; set; }
        public bool GenerarNotaCreditoMontoFavorCliente { get; set; }

        public List<DocLiquida> DocLiquidar { get; set; }
        public List<MedioPago> MediosPago { get; set; }
        public List<RetencionIva> Retenciones { get; set; }
        public List<Comision> Comisiones { get; set; }

    }

}