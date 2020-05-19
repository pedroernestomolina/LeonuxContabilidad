using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Bancos.Conceptos
{

    public class Ficha
    {

        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DTO.Cuenta.Ficha CtaGasto { get; set; }
        public DTO.Cuenta.Ficha CtaPasivo { get; set; }
        public DTO.Cuenta.Ficha CtaBanco { get; set; }

    }

}