using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Asiento.Generar
{
    public class Ficha
    {
        public string Id { get; set; }
        public Enumerados.TipoDocumento TipoDoc { get; set; }
        public string DocumentoRef { get; set; }
        public DateTime FechaDoc { get; set; }
        public string DescripcionDoc { get; set; }
        public int Signo { get; set; }
        public List<FichaDetalle> Detalles { get; set; }
        public bool IsOk { get; set; }
    }
}