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
    
    public partial class contabilidad_asiento
    {
        public contabilidad_asiento()
        {
            this.contabilidad_asiento_detalle = new HashSet<contabilidad_asiento_detalle>();
            this.contabilidad_asiento_resumen = new HashSet<contabilidad_asiento_resumen>();
            this.contabilidad_integraciones = new HashSet<contabilidad_integraciones>();
        }
    
        public int id { get; set; }
        public System.DateTime fechaEmision { get; set; }
        public int mesRelacion { get; set; }
        public int anoRelacion { get; set; }
        public string descripcion { get; set; }
        public int tipoAsiento { get; set; }
        public string autoGenerado { get; set; }
        public string estaAnulado { get; set; }
        public string estaProcesado { get; set; }
        public int numeroComprobante { get; set; }
        public int renglones { get; set; }
        public string tipoDocumento { get; set; }
        public Nullable<int> idTipoDocumento { get; set; }
        public string reglaIntegracionCod { get; set; }
        public string reglaIntegracionDesc { get; set; }
        public decimal importe { get; set; }
    
        public virtual ICollection<contabilidad_asiento_detalle> contabilidad_asiento_detalle { get; set; }
        public virtual ICollection<contabilidad_asiento_resumen> contabilidad_asiento_resumen { get; set; }
        public virtual ICollection<contabilidad_integraciones> contabilidad_integraciones { get; set; }
        public virtual contabilidad_tipo_documento contabilidad_tipo_documento { get; set; }
    }
}