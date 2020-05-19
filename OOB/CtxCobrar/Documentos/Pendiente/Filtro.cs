using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.CtxCobrar.Documentos.Pendiente
{

    public class Filtro:BaseFiltro
    {

        public Vendedores.Vendedor.Ficha Vendedor { get; set; }
        public Enumerados.PorTipoDocumento PorTipoDocumento { get; set; }
        public Enumerados.PorVencimiento PorVencimiento { get; set; }


        public Filtro()
        {
            Limpiar();
        }

        public override void Limpiar()
        {
            base.Limpiar();
            Vendedor = null;
            PorTipoDocumento = Enumerados.PorTipoDocumento.SinDefinir;
            PorVencimiento = Enumerados.PorVencimiento.SinDefinir;
       }

    }

}
