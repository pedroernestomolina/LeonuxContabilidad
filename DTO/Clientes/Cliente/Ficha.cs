using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Clientes.Cliente
{

    public class Ficha
    {

        public string IdAuto { get; set; }
        public string IdAutoVendedor { get; set; }
        public string CiRif { get; set; }
        public string Codigo { get; set; }
        public string RazonSocial { get; set; }
        public string DirFiscal { get; set; }
        public string Telefonos { get; set; }
        public decimal MontoPorCreditos { get; set; }
        public decimal MontoPorDebitos { get; set; }
        public decimal MontoPorAnticipos { get; set; }
        public decimal SaldoActual { get; set; }

    }

}
