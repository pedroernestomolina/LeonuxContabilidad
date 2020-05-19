using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ResultadoLista<T> : Resultado
    {
        public List<T> Lista {get; set;}
        public int cntRegistro {get; set;}

        public ResultadoLista()
            :base()
        {
            Lista = null;
            cntRegistro = 0;
        }
    }
}