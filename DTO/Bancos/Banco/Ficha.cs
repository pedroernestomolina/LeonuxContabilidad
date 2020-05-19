using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Bancos.Banco
{

    public class Ficha
    {

        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Numero { get; set; }
        public string Nombre { get; set; }
        public DTO.Cuenta.Ficha CtaContable { get; set; }
        public DTO.Cuenta.Ficha CtaIGTF { get; set; }

    }

}