using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.PlanCta
{

    public class Ficha
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public Enumerados.Tipo Tipo { get; set; }
        public Enumerados.Naturaleza Naturaleza { get; set; }
        public Enumerados.EstadoSituacion Estado { get; set; }
        public Saldos SaldoActual { get; set; }

        public Ficha()
        {
            Id = -1;
            Codigo = "";
            Nombre = "";
            Tipo =  Enumerados.Tipo.SinDefinir ;
            Naturaleza =  Enumerados.Naturaleza.SinDefinir ;
            Estado = Enumerados.EstadoSituacion.SinDefinir;
            SaldoActual = new Saldos();
        }
    }

}
