using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Cuenta
{
    public class Movimiento
    {
        public string tipoDocumento { get; set; }
        public string docRef { get; set; }
        public string docRefDescripcion { get; set; }
        public DateTime docRefFecha { get; set; }
        public decimal montoDebe { get; set; }
        public decimal montoHaber { get; set; }
        public int signo { get; set; }
    }
}