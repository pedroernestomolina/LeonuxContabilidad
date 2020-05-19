using DTO;
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

        public ResultadoEntidad<DateTime> FechaDelServidor()
        {
            var result = new ResultadoEntidad<DateTime>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var FechaSistema = ctx.Database.SqlQuery<DateTime>("select NOW()").FirstOrDefault();
                    result.Entidad = FechaSistema;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }


        public DTO.ResultadoEntidad<string> DatosDelServidor()
        {
            var result = new ResultadoEntidad<string>();
            result.Entidad = _Instancia + @"\" + _BaseDatos;
            return result; 
        }

    }

}
