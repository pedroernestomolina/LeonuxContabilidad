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
    
    public partial class productos_kardex
    {
        public string auto_producto { get; set; }
        public decimal total { get; set; }
        public string auto_deposito { get; set; }
        public string auto_concepto { get; set; }
        public string auto_documento { get; set; }
        public System.DateTime fecha { get; set; }
        public string hora { get; set; }
        public string documento { get; set; }
        public string modulo { get; set; }
        public string entidad { get; set; }
        public int signo { get; set; }
        public decimal cantidad { get; set; }
        public decimal cantidad_bono { get; set; }
        public decimal cantidad_und { get; set; }
        public decimal costo_und { get; set; }
        public string estatus_anulado { get; set; }
        public string nota { get; set; }
        public decimal precio_und { get; set; }
        public string codigo { get; set; }
        public string siglas { get; set; }
    
        public virtual productos productos { get; set; }
        public virtual empresa_depositos empresa_depositos { get; set; }
    }
}