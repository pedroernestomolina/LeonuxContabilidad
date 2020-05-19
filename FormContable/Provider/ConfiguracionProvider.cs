using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {
        
        public OOB.Resultado.Resultado Configuracion_CtasCierre_Editar(OOB.Contable.Configuracion.CuentasCierre ficha)
        {
            var result = new OOB.Resultado.Resultado();

            var fichaDTO = new DTO.Contable.Configuracion.EditarCtasCierre();
            if (ficha.CtaCierreMes !=null)
            {
                fichaDTO.IdCtaCierreMes = ficha.CtaCierreMes.Id;
            }
            var resultDTO = _servicio.Contable_Configuracion_CuentaCierre_Editar(fichaDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            return result;
        }

        public OOB.Resultado.ResultadoEntidad<OOB.Contable.Configuracion.CuentasCierre> Configuracion_CtasCierre()
        {
            var result = new OOB.Resultado.ResultadoEntidad<OOB.Contable.Configuracion.CuentasCierre>();

            var resultDTO = _servicio.Contable_Configuracion_CuentasCierre_Get();
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            if (resultDTO.Entidad != null)
            {
                var Ctas = new OOB.Contable.Configuracion.CuentasCierre();
                if (resultDTO.Entidad.CtaCierrePeriodo != null)
                {
                    Ctas.CtaCierreMes = new OOB.Contable.PlanCta.Ficha()
                    {
                        Id = resultDTO.Entidad.CtaCierrePeriodo.Id,
                        Codigo = resultDTO.Entidad.CtaCierrePeriodo.Codigo,
                        Nombre = resultDTO.Entidad.CtaCierrePeriodo.Descripcion,
                    };
                }
                else 
                {
                    Ctas.CtaCierreMes = new OOB.Contable.PlanCta.Ficha();
                }

                result.Entidad = Ctas;
            }

            return result;
        }

    }

}