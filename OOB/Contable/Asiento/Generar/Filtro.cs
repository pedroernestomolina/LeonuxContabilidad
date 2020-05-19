using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Contable.Asiento.Generar
{

    public class Filtro
    {

        public DateTime Desde {get;set;}
        public DateTime Hasta {get;set;}
        public Enumerados.ModuloGenerar Modulo {get;set;}
        public FiltroVenta Venta {get;set;}
        public FiltroCompra Compra { get; set; }
        public FiltroCxP CxP { get; set; }
        public FiltroInventario Inventario { get; set; }
        public FiltroBanco Banco { get; set; }

    }

}
