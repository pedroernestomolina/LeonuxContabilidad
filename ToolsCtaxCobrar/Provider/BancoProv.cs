using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public partial class Provider : IProvider
    {

        //BANCO
        public OOB.Resultado.ResultadoLista<OOB.Bancos.Banco.Ficha> Bancos_Banco_Lista()
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.Bancos.Banco.Ficha>();

            try
            {
                var resultDTO = _servicio.Bancos_Banco_Lista();
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var list = new List<OOB.Bancos.Banco.Ficha>();
                if (resultDTO.Lista != null)
                {
                    if (resultDTO.Lista.Count > 0)
                    {
                        foreach (var it in resultDTO.Lista)
                        {
                            var r = new OOB.Bancos.Banco.Ficha()
                            {
                                Id = it.Id,
                                Codigo = it.Codigo,
                                Nombre = it.Nombre,
                                Numero = it.Numero
                            };

                            if (it.CtaContable != null)
                            {
                                r.CtaContable = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.CtaContable.Codigo,
                                    DescripcionCta = it.CtaContable.Descripcion,
                                };
                            }
                            else
                            {
                                r.CtaContable = new OOB.Cuenta.Ficha();
                            }
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

        public OOB.Resultado.ResultadoLista<OOB.Bancos.Banco.Ficha> Bancos_Banco_Lista_Resumen()
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.Bancos.Banco.Ficha>();

            try
            {
                var resultDTO = _servicio.Bancos_Banco_Lista_Resumen();
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var list = new List<OOB.Bancos.Banco.Ficha>();
                if (resultDTO.Lista != null)
                {
                    if (resultDTO.Lista.Count > 0)
                    {
                        foreach (var it in resultDTO.Lista)
                        {
                            var r = new OOB.Bancos.Banco.Ficha()
                            {
                                Id = it.Id,
                                Codigo = it.Codigo,
                                Nombre = it.Nombre,
                                Numero = it.Numero
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

        public OOB.Resultado.ResultadoEntidad<OOB.Bancos.Banco.Ficha> Bancos_Banco_GetById(string autoBanco)
        {
            var rt = new OOB.Resultado.ResultadoEntidad<OOB.Bancos.Banco.Ficha>();

            try
            {
                var resultDTO = _servicio.Bancos_Banco_GetById(autoBanco);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var r = new OOB.Bancos.Banco.Ficha()
                {
                    Id = resultDTO.Entidad.Id,
                    Codigo = resultDTO.Entidad.Codigo,
                    Nombre = resultDTO.Entidad.Nombre,
                    Numero = resultDTO.Entidad.Numero,
                };

                if (resultDTO.Entidad.CtaContable != null)
                {
                    r.CtaContable = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = resultDTO.Entidad.CtaContable.CodigoCta,
                        DescripcionCta = resultDTO.Entidad.CtaContable.DescripcionCta,
                        IdPlanCta = resultDTO.Entidad.CtaContable.IdPlanCta
                    };
                }
                else
                {
                    r.CtaContable = new OOB.Cuenta.Ficha();
                }

                rt.Entidad = r;
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