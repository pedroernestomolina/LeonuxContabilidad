using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Resultado
{
    public enum EnumResult { isOk, isError };

    public class Resultado
    {
        public EnumResult Result { get; set; }
        public string Mensaje { get; set; }

        public Resultado()
        {
            Result = EnumResult.isOk;
            Mensaje = "";
        }
    }
}