using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Integraciones
{

    public class Documento
    {

        public string Id { get; set; }
        public OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento Tipo { get; set; }
        public string DocumentoRef { get; set; }
        public DateTime FechaDoc { get; set; }
        public string DescripcionDoc { get; set; }
        public List<Detalle> Detalles { get; set; }

    }

}