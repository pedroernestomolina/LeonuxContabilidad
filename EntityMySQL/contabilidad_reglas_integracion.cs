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
    
    public partial class contabilidad_reglas_integracion
    {
        public contabilidad_reglas_integracion()
        {
            this.contabilidad_integraciones = new HashSet<contabilidad_integraciones>();
            this.contabilidad_reglas_integracion_detalle = new HashSet<contabilidad_reglas_integracion_detalle>();
        }
    
        public int id { get; set; }
        public string descripcion { get; set; }
        public string codigo { get; set; }
    
        public virtual ICollection<contabilidad_integraciones> contabilidad_integraciones { get; set; }
        public virtual ICollection<contabilidad_reglas_integracion_detalle> contabilidad_reglas_integracion_detalle { get; set; }
    }
}
