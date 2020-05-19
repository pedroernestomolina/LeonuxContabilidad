using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Contable.Asiento
{

    public class Insertar
    {

        public int IdAsientoPreview { get; set; }
        public int IdAsientoEditado { get; set; }
        public int IdTipoDocumento { get; set; }
        public string DescTipoDocumento { get; set; }
        public Enumerados.Tipo TipoAsiento { get; set; }
        public bool IsPreview { get; set; }
        public int PeriodoMes { get; set; }
        public int PeriodoAno { get; set; }
        public decimal Importe { get; set; }
        public string DocumentoRef {get;set;}
        public DateTime FechaDocumentoRef {get;set;}
        public string DescripcionDocumentoRef {get;set;}
        public IEnumerable<InsertarCta> Ctas { get; set; }

    }

}