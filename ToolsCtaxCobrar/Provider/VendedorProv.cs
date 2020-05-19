using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public partial class Provider : IProvider
    {

        OOB.Resultado.ResultadoEntidad<OOB.Vendedores.Vendedor.Ficha> IVendedorProv.Vendedor_Get_ById(string auto)
        {
            var rt = new OOB.Resultado.ResultadoEntidad<OOB.Vendedores.Vendedor.Ficha>();

            try
            {
                var resultDTO = _servicio.Vendedor_Get_ById (auto);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var r = new OOB.Vendedores.Vendedor.Ficha ()
                {
                    IdAuto = resultDTO.Entidad.IdAuto,
                    Codigo = resultDTO.Entidad.Codigo,
                    Nombre =resultDTO.Entidad.Nombre ,
                    CiRif = resultDTO.Entidad.CiRif,
                };

                rt.Entidad = r;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }
            return rt;
        }

        public OOB.Resultado.ResultadoLista<OOB.Vendedores.Vendedor.Ficha> Vendedor_Lista()
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.Vendedores.Vendedor.Ficha>();

            try
            {
                var resultDTO = _servicio.Vendedor_Lista();
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var list = new List<OOB.Vendedores.Vendedor.Ficha>();
                if (resultDTO.Lista != null)
                {
                    if (resultDTO.Lista.Count > 0)
                    {
                        foreach (var it in resultDTO.Lista)
                        {
                            var r = new OOB.Vendedores.Vendedor.Ficha ()
                            {
                                 IdAuto = it.IdAuto,
                                Codigo = it.Codigo,
                                Nombre = it.Nombre,
                            };
                            list.Add(r);
                        }
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