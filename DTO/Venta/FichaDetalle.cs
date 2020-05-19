using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Venta
{

    public class FichaDetalle
    {

        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public decimal TasaIva { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public string Departamento { get; set; }

    }

}