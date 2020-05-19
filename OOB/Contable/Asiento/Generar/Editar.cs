using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Contable.Asiento.Generar
{

    public class Editar
    {

        public OOB.Contable.Asiento.Generar.Enumerados.ModuloGenerar Modulo { get; set; }
        public string Descripcion { get; set; }
        public OOB.Contable.TipoDocumento.Ficha TipoDocumento { get; set; }
        public OOB.Contable.Asiento.Enumerados.Tipo TipoAsiento { get; set; }
        public OOB.Contable.Periodo.Ficha Periodo { get; set; }
        public decimal Importe { get; set; }
        public bool EstaProcesado { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public List<Ficha> Data { get; set; }
        public List<Resumen> Ctas { get; set; }

    }
}
