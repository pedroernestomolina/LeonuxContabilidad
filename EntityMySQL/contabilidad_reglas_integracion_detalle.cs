//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityMySQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class contabilidad_reglas_integracion_detalle
    {
        public int id { get; set; }
        public int idReglaIntegracion { get; set; }
        public int idPlanCta { get; set; }
        public int signo { get; set; }
        public string referencia { get; set; }
        public int idSucursal { get; set; }
    
        public virtual contabilidad_plancta contabilidad_plancta { get; set; }
        public virtual contabilidad_reglas_integracion contabilidad_reglas_integracion { get; set; }
    }
}
