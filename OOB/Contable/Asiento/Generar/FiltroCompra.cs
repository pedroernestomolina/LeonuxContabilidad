using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Contable.Asiento.Generar
{
    
    public class FiltroCompra
    {

        public string TipoDocumento { get; set; }
        public OOB.Bancos.Conceptos.Ficha Concepto { get; set; }
        public OOB.Proveedores.Proveedor.Ficha Proveedor { get; set; }
        public int MesRelacion { get; set; }
        public int AnoRelacion { get; set; }
        public string CodigoSucursal { get; set; }


        public FiltroCompra()
        {
            MesRelacion = -1;
            AnoRelacion = -1;
            CodigoSucursal = "";
        }

    }

}
