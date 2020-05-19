using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxCobrar.Documentos
{

    public class BaseFiltro: Busqueda
    {

        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public string IdCliente { get; set; }

    }

}