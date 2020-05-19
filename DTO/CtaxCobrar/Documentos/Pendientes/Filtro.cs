using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxCobrar.Documentos.Pendientes
{

    public class Filtro: BaseFiltro
    {

        public string IdVendedor { get; set; }
        public Enumerados.PorTipoDocumento PorTipoDocumento { get; set; }
        public Enumerados.PorVencimiento PorVencimiento { get; set; }


        public Filtro()
        {
            Cadena = "";
            IdCliente = "";
            IdVendedor = "";
            PorTipoDocumento = Enumerados.PorTipoDocumento.SinDefinir;
            PorVencimiento = Enumerados.PorVencimiento.SinDefinir;
        }

    }

}