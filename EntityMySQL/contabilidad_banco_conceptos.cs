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
    
    public partial class contabilidad_banco_conceptos
    {
        public int id { get; set; }
        public int idCtaPasivo { get; set; }
        public int idCtaGasto { get; set; }
        public int idCtaBanco { get; set; }
        public string autoMovimientoConcepto { get; set; }
        public string idSucursal { get; set; }
    
        public virtual bancos_movimientos_conceptos bancos_movimientos_conceptos { get; set; }
    }
}
