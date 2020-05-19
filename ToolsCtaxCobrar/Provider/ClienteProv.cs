using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.ResultadoEntidad<OOB.Clientes.Cliente.Ficha> Cliente_Get_ById(string auto)
        {
            var rt = new OOB.Resultado.ResultadoEntidad<OOB.Clientes.Cliente.Ficha>();

            try
            {
                var resultDTO = _servicio.Cliente_Get_ById(auto);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var r = new OOB.Clientes.Cliente.Ficha ()
                {
                    IdAuto = resultDTO.Entidad.IdAuto,
                    IdAutoVendedor=resultDTO.Entidad.IdAutoVendedor,
                    Codigo = resultDTO.Entidad.Codigo,
                    RazonSocial = resultDTO.Entidad.RazonSocial,
                    DirFiscal = resultDTO.Entidad.DirFiscal,
                    CiRif = resultDTO.Entidad.CiRif,
                    Telefonos=resultDTO.Entidad.Telefonos,
                    MontoPorAnticipos = resultDTO.Entidad.MontoPorAnticipos,
                    MontoPorCreditos = resultDTO.Entidad.MontoPorCreditos,
                    MontoPorDebitos = resultDTO.Entidad.MontoPorDebitos,
                    SaldoActual = resultDTO.Entidad.SaldoActual,
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

        public OOB.Resultado.ResultadoLista<OOB.Clientes.Cliente.Ficha> Cliente_Lista(OOB.Clientes.Cliente.Filtro filtro)
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.Clientes.Cliente.Ficha>();

            try
            {
                var filtroDTO = new DTO.Clientes.Cliente.Filtro()
                { 
                     Cadena=filtro.Cadena,
                };
                var resultDTO = _servicio.Cliente_Lista(filtroDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var list = new List<OOB.Clientes.Cliente.Ficha>();
                if (resultDTO.Lista != null)
                {
                    if (resultDTO.Lista.Count > 0)
                    {
                        foreach (var it in resultDTO.Lista)
                        {
                            var r = new OOB.Clientes.Cliente.Ficha()
                            {
                                IdAuto = it.IdAuto,
                                Codigo = it.Codigo,
                                CiRif = it.CiRif,
                                RazonSocial = it.RazonSocial,
                                DirFiscal = it.DirFiscal
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