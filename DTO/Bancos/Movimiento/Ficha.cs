using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Bancos.Movimiento
{

    public class Ficha
    {

        public DateTime FechaEmision { get; set; }
        public Enumerados.TipMovimiento TipoMovimiento { get; set; }
        public string DocumentoReferencia { get; set; }
        public int Signo { get; set; }
        public decimal Importe { get; set; }
        public bool IsConciliado { get; set; }
        public bool IsAnulado { get; set; }
        public string DetalleMovimiento { get; set; }
        public string BancoCodigo { get; set; }
        public string BancoCta { get; set; }
        public string BancoNombre { get; set; }
        public string EntidadBeneficiario { get; set; }
        public Enumerados.OrigenMovimiento ModuloOrigen { get; set; }
        public string ComprobanteNro { get; set; }
        public DateTime FechaCheque { get; set; }

    }

}