using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Periodo
{

    public class Ficha
    {
        public int Id { get; set; }
        public int MesActual { get; set; }
        public int AnoActual { get; set; }
        public bool IsCerrado { get; set; }
        public decimal Utilidad { get; set; }
    }

}