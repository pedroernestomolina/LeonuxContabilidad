using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Contable.Asiento.Generar
{

    public class Enumerados
    {

        //public enum TipoDocumento { Venta, Compra, Pago, RetencionIva, RetencionIslr, Cobro, InvAutoConsumo, InvAjustePorDescargo, InvAjustePorCargo, MovBanco };
        public enum TipoDocumento { Venta, Compra, Pago, RetencionIva, RetencionIslr, Cobro, InvCargo, InvAutoConsumo, InvAjustePorDescargo, InvAjustePorCargo, InvAjuste, MovBanco };
        public enum ModuloGenerar { SinDefinir=-1, Inventario=0, Ventas, Compras, PorCobrar, PorPagar, Bancos };

    }

}
