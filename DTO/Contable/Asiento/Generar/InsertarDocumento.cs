using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Asiento.Generar
{

    public class InsertarDocumento
    {
        public string IdDocumento { get; set; }
        public DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento TipoDocumento { get; set; }
        public string DocumentoRef { get; set; }
        public DateTime FechaDocRef { get; set; }
        public string DescDocRef { get; set; }
        public int Signo { get; set; }
        public bool Incluir { get; set; }
        public IEnumerable<InsertarDetalle> Detalles { get; set; }
    }

}