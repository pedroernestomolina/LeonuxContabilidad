using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormContable.Provider
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

                            if (it.CtaIGTF != null)
                            {
                                r.CtaIGTF = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.CtaIGTF.Codigo,
                                    DescripcionCta = it.CtaIGTF.Descripcion,
                                };
                            }
                            else
                            {
                                r.CtaIGTF = new OOB.Cuenta.Ficha();
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

                if (resultDTO.Entidad.CtaIGTF != null)
                {
                    r.CtaIGTF = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = resultDTO.Entidad.CtaIGTF.CodigoCta,
                        DescripcionCta = resultDTO.Entidad.CtaIGTF.DescripcionCta,
                        IdPlanCta = resultDTO.Entidad.CtaIGTF.IdPlanCta
                    };
                }
                else
                {
                    r.CtaIGTF  = new OOB.Cuenta.Ficha();
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

        public OOB.Resultado.Resultado Bancos_Banco_Actualizar(OOB.Bancos.Banco.Actualizar ficha)
        {
            var result = new OOB.Resultado.Resultado();

            var fichaDTO = new DTO.Bancos.Banco.Actualizar()
            {
                AutoBanco = ficha.Id,
                IdCtaContable = null,
                IdCtaIGTF=null,
            };
            if (ficha.CtaContable != null)
            {
                if (ficha.CtaContable.Id != -1) 
                {
                    fichaDTO.IdCtaContable = ficha.CtaContable.Id;
                }
            }
            if (ficha.CtaIGTF != null)
            {
                if (ficha.CtaIGTF.Id != -1) 
                {
                    fichaDTO.IdCtaIGTF = ficha.CtaIGTF.Id;
                }
            }

            var resultDTO = _servicio.Bancos_Banco_Actualizar(fichaDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Mensaje = resultDTO.Mensaje;
                result.Result = OOB.Resultado.EnumResult.isError;
                return result;
            }

            return result;
        }


        //CONCEPTOS
        public OOB.Resultado.ResultadoLista<OOB.Bancos.Conceptos.Ficha> Banco_Concepto_Lista(
            string buscar,
            OOB.Bancos.Conceptos.Enumerados.TipoLista lista,
            OOB.Bancos.Conceptos.Enumerados.TipoMovimiento clase)
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.Bancos.Conceptos.Ficha>();

            try
            {
                var filtroDTO = new DTO.Bancos.Conceptos.Filtro()
                {
                    Cadena=buscar,
                    tipoMovimiento = (DTO.Bancos.Conceptos.Enumerados.TipoMovimiento)clase,
                    tipoLista = (DTO.Bancos.Conceptos.Enumerados.TipoLista)lista,
                };

                var resultDTO = _servicio.Banco_Concepto_Lista(filtroDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var list = new List<OOB.Bancos.Conceptos.Ficha>();
                if (resultDTO.Lista != null)
                {
                    if (resultDTO.Lista.Count > 0)
                    {
                        if (lista == OOB.Bancos.Conceptos.Enumerados.TipoLista.General)
                        {
                            foreach (var it in resultDTO.Lista)
                            {
                                //NO INCLUYO CONCEPTO MERCANCIA
                                if (it.Id != "0000000000")
                                {
                                    var r = new OOB.Bancos.Conceptos.Ficha()
                                    {
                                        Id = it.Id,
                                        Codigo = it.Codigo,
                                        Descripcion = it.Descripcion,
                                    };

                                    r.CtaGasto = new OOB.Cuenta.Ficha();
                                    if (it.CtaGasto != null)
                                    {
                                        r.CtaGasto.CodigoCta = it.CtaGasto.Codigo;
                                        r.CtaGasto.DescripcionCta = it.CtaGasto.Descripcion;
                                    }

                                    r.CtaPasivo = new OOB.Cuenta.Ficha();
                                    if (it.CtaPasivo != null)
                                    {
                                        r.CtaPasivo.CodigoCta = it.CtaPasivo.Codigo;
                                        r.CtaPasivo.DescripcionCta = it.CtaPasivo.Descripcion;
                                    }

                                    r.CtaBanco = new OOB.Cuenta.Ficha();
                                    if (it.CtaBanco != null)
                                    {
                                        r.CtaBanco.CodigoCta = it.CtaBanco.Codigo;
                                        r.CtaBanco.DescripcionCta = it.CtaBanco.Descripcion;
                                    }

                                    list.Add(r);
                                }
                            }
                        }
                        else
                        {
                            foreach (var it in resultDTO.Lista)
                            {
                                var r = new OOB.Bancos.Conceptos.Ficha()
                                {
                                    Id = it.Id,
                                    Codigo = it.Codigo,
                                    Descripcion = it.Descripcion,
                                };
                                r.CtaGasto = new OOB.Cuenta.Ficha();
                                r.CtaPasivo = new OOB.Cuenta.Ficha();
                                list.Add(r);
                            }
                        }
                    }
                }
                rt.cntRegistro = list.Count();
                rt.Lista = list;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }
            return rt;
        }

        public OOB.Resultado.ResultadoEntidad<OOB.Bancos.Conceptos.Ficha> Banco_Concepto_GetById(string auto)
        {
            var rt = new OOB.Resultado.ResultadoEntidad<OOB.Bancos.Conceptos.Ficha>();

            try
            {
                var resultDTO = _servicio.Banco_Concepto_GetById(auto);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var r = new OOB.Bancos.Conceptos.Ficha()
                {
                    Id = resultDTO.Entidad.Id,
                    Codigo = resultDTO.Entidad.Codigo,
                    Descripcion = resultDTO.Entidad.Descripcion,
                };

                r.CtaGasto = new OOB.Cuenta.Ficha();
                if (resultDTO.Entidad.CtaGasto != null)
                {
                    r.CtaGasto.CodigoCta = resultDTO.Entidad.CtaGasto.CodigoCta;
                    r.CtaGasto.DescripcionCta = resultDTO.Entidad.CtaGasto.DescripcionCta;
                    r.CtaGasto.IdPlanCta = resultDTO.Entidad.CtaGasto.IdPlanCta;
                }

                r.CtaPasivo = new OOB.Cuenta.Ficha();
                if (resultDTO.Entidad.CtaPasivo != null)
                {
                    r.CtaPasivo.CodigoCta = resultDTO.Entidad.CtaPasivo.CodigoCta;
                    r.CtaPasivo.DescripcionCta = resultDTO.Entidad.CtaPasivo.DescripcionCta;
                    r.CtaPasivo.IdPlanCta = resultDTO.Entidad.CtaPasivo.IdPlanCta;
                }

                r.CtaBanco = new OOB.Cuenta.Ficha();
                if (resultDTO.Entidad.CtaBanco != null)
                {
                    r.CtaBanco.CodigoCta = resultDTO.Entidad.CtaBanco.CodigoCta;
                    r.CtaBanco.DescripcionCta = resultDTO.Entidad.CtaBanco.DescripcionCta;
                    r.CtaBanco.IdPlanCta = resultDTO.Entidad.CtaBanco.IdPlanCta;
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

        public OOB.Resultado.Resultado Banco_Concepto_Actualizar(OOB.Bancos.Conceptos.Actualizar ficha)
        {
            var result = new OOB.Resultado.Resultado();

            var fichaDTO = new DTO.Bancos.Conceptos.Actualizar()
            {
                AutoConcepto = ficha.Id,
            };

            if (ficha.CtaPasivo != null) { fichaDTO.IdCtaPasivo = ficha.CtaPasivo.Id; }
            if (ficha.CtaGasto != null) { fichaDTO.IdCtaGasto = ficha.CtaGasto.Id; }
            if (ficha.CtaBanco != null) { fichaDTO.IdCtaBanco = ficha.CtaBanco.Id; }

            var resultDTO = _servicio.Banco_Concepto_Actualizar(fichaDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Mensaje = resultDTO.Mensaje;
                result.Result = OOB.Resultado.EnumResult.isError;
                return result;
            }

            return result;
        }


        //MOVIMIENTO
        public OOB.Resultado.ResultadoEntidad<OOB.Bancos.Movimiento.Ficha> Banco_Movimiento_GetById(string autoMov)
        {
            var result = new OOB.Resultado.ResultadoEntidad<OOB.Bancos.Movimiento.Ficha>();

            var resultDTO = _servicio.Bancos_Movimiento_GetById(autoMov);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            var ent = resultDTO.Entidad;
            var doc = new OOB.Bancos.Movimiento.Ficha()
            {
                FechaEmision = ent.FechaEmision,
                TipoMovimiento = (OOB.Bancos.Enumerados.TipMovimiento)ent.TipoMovimiento,
                DocumentoReferencia = ent.DocumentoReferencia,
                Signo = ent.Signo,
                Importe = ent.Importe,
                IsConciliado = ent.IsConciliado,
                IsAnulado = ent.IsAnulado,
                DetalleMovimiento = ent.DetalleMovimiento,
                BancoNombre = ent.BancoNombre,
                BancoCodigo = ent.BancoCodigo,
                BancoCtaNro = ent.BancoCta,
                ModuloOrigen = (OOB.Bancos.Enumerados.OrigenMovimiento)ent.ModuloOrigen,
                EntidadBeneficiario = ent.EntidadBeneficiario,
                ComprobanteNro = ent.ComprobanteNro,
                FechaCheque = ent.FechaCheque,
            };

            result.Entidad = doc;
            return result;
        }

    }

}