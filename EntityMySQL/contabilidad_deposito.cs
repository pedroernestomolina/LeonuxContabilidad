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
    
    public partial class contabilidad_deposito
    {
        public int id { get; set; }
        public string auto_deposito { get; set; }
        public string codigo_sucursal { get; set; }
    
        public virtual empresa_depositos empresa_depositos { get; set; }
    }
}
