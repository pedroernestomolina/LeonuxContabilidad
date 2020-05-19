using DTO;
using EntityMySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace ProviderMySql
{

    public partial class Provider : IProvider.InfraEstructura
    {

        public DTO.Resultado Contable_Configuracion_CuentaCierre_Editar(DTO.Contable.Configuracion.EditarCtasCierre ficha)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        if (ficha.IdCtaCierreMes != -1) 
                        {
                            var det = ctx.contabilidad_configuracion.Find(1);
                            if (det == null) 
                            {
                                result.Mensaje = "[ CONFIGURACION ] NO ENCONTRADA";
                                result.Result = EnumResult.isError;
                            }

                            det.idCtaResultadoMes = ficha.IdCtaCierreMes ;
                            ctx.SaveChanges();
                        }

                        ts.Complete();
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public ResultadoEntidad<DTO.Contable.Configuracion.CuentasCierre> Contable_Configuracion_CuentasCierre_Get()
        {
            var result = new ResultadoEntidad<DTO.Contable.Configuracion.CuentasCierre>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_configuracion.Find(1);
                    if (q == null)
                    {
                        result.Entidad = null;
                        result.Result = EnumResult.isError;
                        result.Mensaje = "[ CONGIGURACION ] NO DEFINIDA";
                        return result;
                    }

                    var ctasCierre = new DTO.Contable.Configuracion.CuentasCierre();
                    if (q.idCtaResultadoMes != null)
                    {
                        var ctaCierrePeriodo = new DTO.Contable.Configuracion.Cuenta()
                        {
                            Id = q.contabilidad_plancta.id,
                            Codigo = q.contabilidad_plancta.codigo,
                            Descripcion = q.contabilidad_plancta.descripcion,
                        };

                        ctasCierre.CtaCierrePeriodo = ctaCierrePeriodo;
                        result.Entidad = ctasCierre;
                    }
                    else
                    {
                        result.Entidad = null;
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Entidad = null;
            }

            return result;
        }

    }

}