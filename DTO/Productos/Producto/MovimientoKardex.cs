using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Productos.Producto
{

    public class MovimientoKardex
    {

        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }
        public int Signo { get; set; }
        public string Concepto { get; set; }
        public string Modulo { get; set; }

    }

}
