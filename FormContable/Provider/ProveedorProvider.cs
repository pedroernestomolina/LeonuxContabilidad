using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.ResultadoLista<OOB.Proveedores.Proveedor.Ficha> Proveedores_Proveedor_Lista()
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.Proveedores.Proveedor.Ficha>();

            try
            {
                var filtroDTO = new DTO.Proveedores.Proveedor.Filtro();
                var resultDTO = _servicio.Proveedores_Proveedor_Lista(filtroDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var list = new List<OOB.Proveedores.Proveedor.Ficha>();
                if (resultDTO.Lista.Count > 0)
                {
                    foreach (var it in resultDTO.Lista)
                    {
                        var r = new OOB.Proveedores.Proveedor.Ficha()
                        {
                            Id = it.Id,
                            Codigo=it.Codigo,
                            CiRif = it.CiRif,
                            NombreRazonSocial = it.NombreRazonSocial,
                        };
                        list.Add(r);
                    }
                }

                rt.cntRegistro = resultDTO.cntRegistro;
                rt.Lista = list;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }
            return rt;
        }

    }
}
