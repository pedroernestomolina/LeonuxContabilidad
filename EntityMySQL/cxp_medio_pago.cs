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
    
    public partial class cxp_medio_pago
    {
        public string auto_recibo { get; set; }
        public string medio { get; set; }
        public decimal monto_recibido { get; set; }
        public System.DateTime fecha { get; set; }
        public string estatus_anulado { get; set; }
        public string documento { get; set; }
        public string cuenta { get; set; }
        public string codigo { get; set; }
        public string numero { get; set; }
        public string agencia { get; set; }
        public string auto_usuario { get; set; }
        public string codigo_banco { get; set; }
    }
}