using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Asiento
{

    public class FichaResumen
    {

        public int IdCta { get; set; }
        public string CodigoCta { get; set; }
        public string DescripcionCta { get; set; }
        public decimal MontoDebe { get; set; }
        public decimal MontoHaber { get; set; }

    }

}
