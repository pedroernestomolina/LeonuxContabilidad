using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Empresa.Departamento
{

    public class Actualizar
    {

        public string Id { get; set; }
        public int IdSucursal { get; set; }
        public OOB.Contable.PlanCta.Ficha CtaInventario { get; set; }
        public OOB.Contable.PlanCta.Ficha CtaCosto { get; set; }
        public OOB.Contable.PlanCta.Ficha CtaVenta { get; set; }
        public OOB.Contable.PlanCta.Ficha CtaMerma { get; set; }
        public OOB.Contable.PlanCta.Ficha CtaConsumo { get; set; }

    }

}