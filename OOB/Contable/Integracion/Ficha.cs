using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Contable.Integracion
{

    public class Ficha
    {

        public int Id { get; set; }
        public int IdAsiento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime DesdeFecha { get; set; }
        public DateTime HastaFecha { get; set; }
        public string Descripcion { get; set; }
        public bool EstaAnulado { get; set; }
        public string ModuloAfecta { get; set; }
        //
        public string Desde { get { return DesdeFecha.ToShortDateString(); } }
        public string Hasta { get { return HastaFecha.ToShortDateString(); } }

    }

}