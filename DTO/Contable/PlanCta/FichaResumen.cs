using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Contable.PlanCta
{
    public class FichaResumen
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public Enumerados.Tipo Tipo {get; set;}
        public Enumerados.Naturaleza Naturaleza { get; set; }
        public Enumerados.EstadoSituacion Estado { get; set; }
        public decimal MontoDebe { get; set; }
        public decimal MontoHaber { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal SaldoApertura { get; set; }

        public FichaResumen()
        {
            Id = -1;
            Codigo = "";
            Nombre = "";
            Tipo = Enumerados.Tipo.SinDefinir ;
            Naturaleza = Enumerados.Naturaleza.SinDefinir ;
            MontoDebe = 0.0m;
            MontoHaber = 0.0m;
            SaldoAnterior = 0.0m;
            SaldoApertura = 0.0m;
        }
    }
}