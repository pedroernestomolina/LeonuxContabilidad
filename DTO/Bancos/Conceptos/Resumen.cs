using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Bancos.Conceptos
{

    public class Resumen
    {

        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DTO.Cuenta.Resumen CtaGasto { get; set; }
        public DTO.Cuenta.Resumen CtaPasivo { get; set; }
        public DTO.Cuenta.Resumen CtaBanco { get; set; }

    }

}