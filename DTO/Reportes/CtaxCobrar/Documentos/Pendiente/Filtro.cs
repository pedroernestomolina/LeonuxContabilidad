using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Reportes.CtaxCobrar.Documentos.Pendiente
{

    public class Filtro: DTO.Reportes.Filtro
    {

        public string IdVendedor { get; set; }
        public string IdCliente { get; set; }

    }

}