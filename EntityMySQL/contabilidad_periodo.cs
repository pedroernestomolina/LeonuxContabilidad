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
    
    public partial class contabilidad_periodo
    {
        public int id { get; set; }
        public int mes { get; set; }
        public int ano { get; set; }
        public string estatusCierre { get; set; }
        public decimal utilidad { get; set; }
        public decimal utilidad_acumulada { get; set; }
    }
}