using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Bancos.Conceptos
{

    public class Actualizar
    {

        public string AutoConcepto { get; set; }
        public int IdCtaGasto { get; set; }
        public int IdCtaPasivo { get; set; }
        public int IdCtaBanco { get; set; }


        public Actualizar()
        {
            AutoConcepto = "";
            IdCtaGasto = -1;
            IdCtaPasivo = -1;
            IdCtaBanco = -1;
        }

    }

}
