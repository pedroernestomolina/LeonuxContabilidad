using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Clientes.Cliente
{

    public class Filtro: Busqueda
    {

        public Enumerados.PorEstatus PorEstatus { get; set; }
        public Enumerados.PorSaldo PorSaldo { get; set; }


        public Filtro(): base()
        {
            PorEstatus = Enumerados.PorEstatus.SinDefinir ;
            PorSaldo = Enumerados.PorSaldo.SinDefinir;
        }

    }

}