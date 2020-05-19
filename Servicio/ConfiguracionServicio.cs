using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public DTO.Resultado Contable_Configuracion_CuentaCierre_Editar(DTO.Contable.Configuracion.EditarCtasCierre ficha)
        {
            return provider.Contable_Configuracion_CuentaCierre_Editar(ficha);
        }

        public DTO.ResultadoEntidad<DTO.Contable.Configuracion.CuentasCierre> Contable_Configuracion_CuentasCierre_Get()
        {
            return provider.Contable_Configuracion_CuentasCierre_Get();
        }

    }

}