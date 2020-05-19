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

        public DTO.ResultadoEntidad<DTO.Vendedores.Vendedor.Ficha> Vendedores_Vendedor_GetById(string auto)
        {

            var result = new ResultadoEntidad<DTO.Vendedores.Vendedor.Ficha>();

            //try
            //{
            //    using (var ctx = new dBEntities(_cn.ConnectionString))
            //    {
            //        var entVendedor = ctx.vendedores.Find(auto);
            //        if (entVendedor == null)
            //        {
            //            result.Mensaje = "[ ID ] VENDEDOR NO ENCONTRADA";
            //            result.Result = DTO.EnumResult.isError;
            //            result.Entidad = null;
            //            return result;
            //        }

            //        var r = new DTO.Vendedores.Vendedor.Ficha()
            //        {
            //            IdAuto = entVendedor.auto,
            //            Nombre = entVendedor.nombre,
            //            CiRif = entVendedor.ci ,
            //            Codigo = entVendedor.codigo,
            //            CastigoP = entVendedor.castigop,
            //            DiasTolerancia = entVendedor.tolerancia, 
            //        };

            //        result.Entidad = r;
            //    }
            //}
            //catch (Exception e)
            //{
            //    result.Mensaje = e.Message;
            //    result.Result = DTO.EnumResult.isError;
            //    result.Entidad = null;
            //}

            return result;

        }

        public ResultadoLista<DTO.Vendedores.Vendedor.Resumen> Vendedores_Vendedor_Lista()
        {
            var result = new ResultadoLista<DTO.Vendedores.Vendedor.Resumen>();

            //try
            //{
            //    using (var ctx = new dBEntities(_cn.ConnectionString))
            //    {
            //        var q = ctx.vendedores.ToList();
            //        if (q.Count > 0)
            //        {
            //            var list = q.Select(d =>
            //            {
            //                var r = new DTO.Vendedores.Vendedor.Resumen()
            //                {
            //                    IdAuto = d.auto,
            //                    Codigo = d.codigo,
            //                    Nombre = d.nombre,
            //                };

            //                return r;
            //            }).ToList();

            //            result.cntRegistro = list.Count();
            //            result.Lista = list;
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    result.Mensaje = e.Message;
            //    result.Result = DTO.EnumResult.isError;
            //}

            return result;
        }

    }

}