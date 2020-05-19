using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Bancos.Conceptos
{

    public class Filtro
    {

        public string Cadena { get; set; }
        public Enumerados.TipoLista tipoLista { get; set; }
        public Enumerados.TipoMovimiento tipoMovimiento { get; set; }

    }

}
