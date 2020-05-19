using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Vendedores.Vendedor
{

    public class Ficha
    {

        public string IdAuto { get; set; }
        public string CiRif { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int DiasTolerancia { get; set; }
        public decimal CastigoP { get; set; }

    }

}