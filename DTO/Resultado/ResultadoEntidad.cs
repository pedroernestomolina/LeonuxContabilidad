using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ResultadoEntidad<T> : Resultado
    {
        public T Entidad { get; set; }

        public ResultadoEntidad()
            : base()
        {
        }
    }
}
