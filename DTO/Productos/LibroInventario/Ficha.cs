using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Productos.LibroInventario
{

    public class Ficha
    {

        public string DepId { get; set; }
        public string DepNombre { get; set; }
        public decimal MontoPorEntrada { get; set; }
        public decimal MontoPorSalida { get; set; }
        public decimal MontoPorAjuste { get; set; }
        public decimal MontoPorConsumoInterno { get; set; }

    }

}
