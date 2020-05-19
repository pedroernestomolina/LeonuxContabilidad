using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Contable.PlanCta
{

    public class Editar
    {
        public int Id {get; set;}
        public string Nombre { get; set; }
        public Enumerados.Tipo Tipo { get; set; }
        public Enumerados.Naturaleza Naturaleza { get; set; }
        public Enumerados.EstadoSituacion Estado { get; set; }

        public Editar ()
        {
            Id = -1;
            Nombre = "";
            Tipo = Enumerados.Tipo.SinDefinir ;
            Naturaleza = Enumerados.Naturaleza.SinDefinir ;
            Estado= Enumerados.EstadoSituacion.SinDefinir;
        }

    }

}