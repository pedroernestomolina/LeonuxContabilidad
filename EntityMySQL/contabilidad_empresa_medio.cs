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
    
    public partial class contabilidad_empresa_medio
    {
        public int id { get; set; }
        public string auto_empresa_medio { get; set; }
        public int idPlanCta { get; set; }
    
        public virtual empresa_medios empresa_medios { get; set; }
        public virtual contabilidad_plancta contabilidad_plancta { get; set; }
    }
}
