using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Contable.Asiento.Asiento
{

    public class Guardar
    {
        public OOB.Contable.Asiento.Ficha Asiento { get; set; }
        public OOB.Contable.Periodo.Ficha Periodo { get; set; }
        public string DocumentoRef { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public OOB.Contable.TipoDocumento.Ficha TipoDocumento { get; set; }
        public Enumerados.Tipo TipoAsiento { get; set; }
        public bool IsPreview { get; set; }
        public decimal Importe { get; set; }
        public List<Detalle> Detalles { get; set; }
    }

}