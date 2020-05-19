using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Bancos.Movimiento
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
        public string BancoCtaNro { get; set; }
        public string BancoNombre { get; set; }
        public string EntidadBeneficiario { get; set; }
        public Enumerados.OrigenMovimiento ModuloOrigen { get; set; }
        public string ComprobanteNro { get; set; }
        public DateTime FechaCheque { get; set; }

        public string BancoDescripcion 
        { 
            get 
            { 
                return BancoCodigo.Trim()+Environment.NewLine+BancoCtaNro.Trim()+Environment.NewLine+BancoNombre.Trim() ;
            } 
        }

        public string TipoMovimientoDescripcion
        {
            get
            {
                var tipo = "";
                switch (TipoMovimiento) 
                {
                    case Enumerados.TipMovimiento.DEPOSITO:
                        tipo="DEPOSITO";
                        break;
                    case Enumerados.TipMovimiento.CHEQUE:
                        tipo = "CHEQUE";
                        break;
                    case Enumerados.TipMovimiento.NOTA_CREDITO:
                        tipo = "NOTA DE CREDITO";
                        break;
                    case Enumerados.TipMovimiento.NOTA_DEBITO:
                        tipo = "NOTA DE DEBITO";
                        break;
                }
                return tipo;
            }
        }


    }

}