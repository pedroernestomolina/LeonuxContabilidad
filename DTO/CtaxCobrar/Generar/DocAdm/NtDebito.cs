using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CtaxCobrar.Generar.DocAdm
{
    
    public class NtDebito
    {

        public string IdCliente { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Nota { get; set; }
        public decimal Monto { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string RifCliente { get; set; }

    }

}
