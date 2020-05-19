using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Asiento.Generar
{

    public class Insertar
    {

        public int IdAsientoPreview { get; set; }
        public int IdTipoDocumento { get; set; }
        public string DescripcionAsiento { get; set; }
        public DTO.Contable.Asiento.Enumerados.Tipo TipoAsiento { get; set; }
        public DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar Modulo { get; set; }
        public bool Procesado { get; set; }
        public int PeriodoMes { get; set; }
        public int PeriodoAno { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public decimal Importe { get; set; }
        public IEnumerable<InsertarDocumento> Documentos { get; set; }
        public IEnumerable<InsertarResumen> Resumen { get; set; }

    }

}
