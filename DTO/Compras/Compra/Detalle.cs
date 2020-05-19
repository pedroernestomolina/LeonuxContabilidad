using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Compras.Compra
{

    public class Detalle
    {

        public string Descripcion { get; set; }
        public string Empaque { get; set; }
        public decimal Contenido { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public decimal TasaIva { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public string DepartamentoDesc { get; set; }

    }

}