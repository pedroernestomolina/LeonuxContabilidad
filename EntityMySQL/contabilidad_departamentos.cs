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
    
    public partial class contabilidad_departamentos
    {
        public int id { get; set; }
        public string auto_departamento { get; set; }
        public int Concepto { get; set; }
        public Nullable<int> idPlanCta_Sucursal_2 { get; set; }
        public Nullable<int> idPlanCta_Sucursal_3 { get; set; }
        public Nullable<int> idPlanCta { get; set; }
        public Nullable<int> idPlanCta_Sucursal_4 { get; set; }
        public Nullable<int> idPlanCta_Sucursal_5 { get; set; }
    
        public virtual empresa_departamentos empresa_departamentos { get; set; }
        public virtual contabilidad_plancta contabilidad_plancta { get; set; }
        public virtual contabilidad_plancta contabilidad_plancta1 { get; set; }
        public virtual contabilidad_plancta contabilidad_plancta2 { get; set; }
        public virtual contabilidad_plancta contabilidad_plancta3 { get; set; }
        public virtual contabilidad_plancta contabilidad_plancta4 { get; set; }
    }
}
