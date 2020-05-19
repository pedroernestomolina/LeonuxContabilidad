using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Productos.Movimiento
{

    public class Ficha
    {
        public string DocumentoNro { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Nota { get; set; }
        public string Usuario { get; set; }
        public string Estacion { get; set; }
        public string ConceptoCodigo { get; set; }
        public string ConceptoDesc { get; set; }
        public string DepositoCodigo { get; set; }
        public string DepositoDesc { get; set; }
        public string DocumentoCodigo { get; set; }
        public string DocumentoDesc { get; set; }
        public int Renglones { get; set; }
        public decimal Importe { get; set; }
        public IEnumerable<Detalle> Detalles { get; set; }
    }

}