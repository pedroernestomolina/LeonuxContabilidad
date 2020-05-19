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
    
    public partial class clientes
    {
        public clientes()
        {
            this.ventas_detalle = new HashSet<ventas_detalle>();
            this.cxc_recibos = new HashSet<cxc_recibos>();
            this.cxc = new HashSet<cxc>();
            this.ventas = new HashSet<ventas>();
        }
    
        public string auto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string ci_rif { get; set; }
        public string razon_social { get; set; }
        public string auto_grupo { get; set; }
        public string dir_fiscal { get; set; }
        public string dir_despacho { get; set; }
        public string contacto { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string pais { get; set; }
        public string denominacion_fiscal { get; set; }
        public string auto_estado { get; set; }
        public string auto_zona { get; set; }
        public string codigo_postal { get; set; }
        public decimal retencion_iva { get; set; }
        public decimal retencion_islr { get; set; }
        public string auto_vendedor { get; set; }
        public string tarifa { get; set; }
        public decimal descuento { get; set; }
        public decimal recargo { get; set; }
        public string estatus_credito { get; set; }
        public int dias_credito { get; set; }
        public decimal limite_credito { get; set; }
        public int doc_pendientes { get; set; }
        public string estatus_morosidad { get; set; }
        public string estatus_lunes { get; set; }
        public string estatus_martes { get; set; }
        public string estatus_miercoles { get; set; }
        public string estatus_jueves { get; set; }
        public string estatus_viernes { get; set; }
        public string estatus_sabado { get; set; }
        public string estatus_domingo { get; set; }
        public string auto_cobrador { get; set; }
        public System.DateTime fecha_alta { get; set; }
        public System.DateTime fecha_baja { get; set; }
        public System.DateTime fecha_ult_venta { get; set; }
        public System.DateTime fecha_ult_pago { get; set; }
        public decimal anticipos { get; set; }
        public decimal debitos { get; set; }
        public decimal creditos { get; set; }
        public decimal saldo { get; set; }
        public decimal disponible { get; set; }
        public string memo { get; set; }
        public string aviso { get; set; }
        public string estatus { get; set; }
        public string cuenta { get; set; }
        public string iban { get; set; }
        public string swit { get; set; }
        public string auto_agencia { get; set; }
        public string dir_banco { get; set; }
        public string auto_codigo_cobrar { get; set; }
        public string auto_codigo_ingresos { get; set; }
        public string auto_codigo_anticipos { get; set; }
        public string categoria { get; set; }
        public decimal descuento_pronto_pago { get; set; }
        public decimal importe_ult_pago { get; set; }
        public decimal importe_ult_venta { get; set; }
        public string telefono2 { get; set; }
        public string fax { get; set; }
        public string celular { get; set; }
        public string abc { get; set; }
    
        public virtual ICollection<ventas_detalle> ventas_detalle { get; set; }
        public virtual ICollection<cxc_recibos> cxc_recibos { get; set; }
        public virtual empresa_cobradores empresa_cobradores { get; set; }
        public virtual ICollection<cxc> cxc { get; set; }
        public virtual ICollection<ventas> ventas { get; set; }
    }
}
