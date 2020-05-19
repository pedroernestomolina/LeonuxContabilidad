using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Asiento.Apertura
{

    public class InsertarCta
    {
        public int Id { get; set; }
        public string codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoDebe { get; set; }
        public decimal MontoHaber { get; set; }
        public int Signo { get; set; }
        public decimal SaldoInicial
        {
            get
            {
                var saldo = MontoDebe == 0 ? MontoHaber : MontoDebe;
                return (saldo * Signo);
            }
        }
    }

}