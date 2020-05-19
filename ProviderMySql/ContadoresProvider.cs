using EntityMySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProviderMySql
{
    
    public partial class Provider : IProvider.InfraEstructura
    {
        public DTO.ResultadoEntidad<DTO.Contable.Contador.Ficha> Contable_Contadores_Get()
        {
            DTO.ResultadoEntidad<DTO.Contable.Contador.Ficha>  result = new  DTO.ResultadoEntidad<DTO.Contable.Contador.Ficha> ();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_contadores.FirstOrDefault(d => d.id == 1);
                    if (q == null)
                    {
                        result.Mensaje = "CONTADORES NO ENCONTRADO";
                        result.Entidad = null;
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }
                    result.Entidad = new DTO.Contable.Contador.Ficha() { 
                        CntAsiento = q.cnt_aisento, 
                        CntAsientoPreview=q.cnt_aisento_preview
                    };
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

    }

}
