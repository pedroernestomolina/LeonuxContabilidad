using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Productos.Movimiento
{

    public class Detalle
    {
        public string PrdCodigo { get; set; }
        public string PrdDescripcion { get; set; }
        public decimal Cantidad { get; set; }
        public string Empaque { get; set; }
        public decimal Contenido { get; set; }
        public decimal CantidadUnidades { get; set; }
        public decimal CostoCompra { get; set; }
        public decimal CostoUnd { get; set; }
        public decimal Importe { get; set;}
        public string DepartamentoDesc { get; set; }
        public string DepartamentoCodigo { get; set; }
        public int Signo { get; set; }
    }

}