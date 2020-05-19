using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Contable.PlanCta
{

    public class Agregar
    {
        public int IdCtaPadre { get; set; }
        public int Nivel { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public Enumerados.Tipo Tipo { get; set; }
        public Enumerados.Naturaleza Naturaleza { get; set; }
        public Enumerados.EstadoSituacion Estado { get; set; }
    }

}
