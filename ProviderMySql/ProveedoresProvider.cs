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

        public ResultadoLista<DTO.Proveedores.Proveedor.Resumen> Proveedores_Proveedor_Lista(DTO.Proveedores.Proveedor.Filtro filtro)
        {
            var result = new ResultadoLista<DTO.Proveedores.Proveedor.Resumen>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.proveedores.ToList();

                    if (filtro.Cadena != "")
                    {
                        q = q.Where(p =>
                            p.codigo.Trim().ToUpper().Contains(filtro.Cadena) ||
                            p.nombre.Trim().ToUpper().Contains(filtro.Cadena))
                            .ToList();
                    }
                    
                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            var r = new DTO.Proveedores.Proveedor.Resumen()
                            {
                                Id = d.auto,
                                Codigo = d.codigo,
                                CiRif=d.ci_rif,
                                NombreRazonSocial = d.razon_social
                            };

                            return r;
                        }).ToList();

                        result.cntRegistro = list.Count();
                        result.Lista = list;
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
    
    }

}