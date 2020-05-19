using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Resultado
{

    public class ResultadoId : Resultado
    {
        public int Id { get; set; }
        
        public ResultadoId()
            : base()
        {
            Id = -1;
        }
    }

}
