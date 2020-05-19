using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Contable.Asiento
{

    public class Insertar
    {
        public OOB.Contable.Periodo.Ficha Periodo { get; set; }
        public string DocumentoRef { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public OOB.Contable.TipoDocumento.Ficha TipoDocumento { get; set;}
        public Enumerados.Tipo TipoAsiento { get; set; }
        public bool EstaProcesado {get; set;}
        public decimal Importe { get; set; }
        public List<InsertarDetalle> Detalles { get; set; }
    }

}
