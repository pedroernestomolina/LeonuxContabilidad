using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Contable.Asiento
{
    public class Enumerados
    {
        public enum Tipo { SinDefinir=-1,Apertura=0, Operativo, Ajuste, Cierre }
        public enum TipoAsientoAnular { SinDefinir = -1, Apertura = 0, Preview , Asiento }
    }
}
