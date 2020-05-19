using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Contable.Asiento.Apertura
{

    public class Insertar
    {
        public Ficha Asiento { get; set; }
        public OOB.Contable.Periodo.Ficha Periodo { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public bool IsPreview { get; set; }
        public decimal Importe { get; set; }
        public List<InsertarDetalles> Detalles { get; set; }
    }

}