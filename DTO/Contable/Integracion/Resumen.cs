using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Integracion
{

    public class Resumen
    {

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime DesdeFecha { get; set; }
        public DateTime HastaFecha { get; set; }
        public string Descripcion { get; set; }
        public string ModuloAfecta { get; set; }
        public bool EstaAnulado { get; set; }

    }

}