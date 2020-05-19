using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Asiento.Generar
{

    public class FiltroInventario
    {

        public enum EnumTipoDocumento { Descargo = 1, AjustePorCargo, AjustePorDescargo , Ajuste, Cargo };
        public EnumTipoDocumento? TipoDocumento { get; set; }

    }

}
