using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.ResultadoLista<OOB.Empresa.Departamento.Ficha> Empresa_Departamento_Lista()
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.Empresa.Departamento.Ficha>();

            try
            {
                var resultDTO = _servicio.Empresa_Departamento_Lista();
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var list = new List<OOB.Empresa.Departamento.Ficha>();
                if (resultDTO.Lista != null)
                {
                    if (resultDTO.Lista.Count > 0)
                    {
                        foreach (var it in resultDTO.Lista)
                        {
                            var r = new OOB.Empresa.Departamento.Ficha()
                            {
                                Id = it.Id,
                                Codigo = it.Codigo,
                                Descripcion = it.Descripcion,
                                Sucursal_1 = new OOB.Empresa.Departamento.Sucursal(),
                                Sucursal_2 = new OOB.Empresa.Departamento.Sucursal(),
                                Sucursal_3 = new OOB.Empresa.Departamento.Sucursal(),
                                Sucursal_4 = new OOB.Empresa.Departamento.Sucursal(),
                                Sucursal_5 = new OOB.Empresa.Departamento.Sucursal(),
                            };


                            //CTA INVENTARIO, PARA LAS DOS SUCUSALES
                            if (it.Sucursal_1.CtaInventario != null)
                            {
                                r.Sucursal_1.CtaInventario = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_1.CtaInventario.Codigo,
                                    DescripcionCta = it.Sucursal_1.CtaInventario.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_1.CtaInventario = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_2.CtaInventario != null)
                            {
                                r.Sucursal_2.CtaInventario = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_2.CtaInventario.Codigo,
                                    DescripcionCta = it.Sucursal_2.CtaInventario.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_2.CtaInventario = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_3.CtaInventario != null)
                            {
                                r.Sucursal_3.CtaInventario = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_3.CtaInventario.Codigo,
                                    DescripcionCta = it.Sucursal_3.CtaInventario.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_3.CtaInventario = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_4.CtaInventario != null)
                            {
                                r.Sucursal_4.CtaInventario = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_4.CtaInventario.Codigo,
                                    DescripcionCta = it.Sucursal_4.CtaInventario.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_4.CtaInventario = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_5.CtaInventario != null)
                            {
                                r.Sucursal_5.CtaInventario = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_5.CtaInventario.Codigo,
                                    DescripcionCta = it.Sucursal_5.CtaInventario.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_5.CtaInventario = new OOB.Cuenta.Ficha();
                            }


                            //CTA COST INVENTARIO, PARA LAS DOS SUCUSALES
                            if (it.Sucursal_1.CtaCosto != null)
                            {
                                r.Sucursal_1.CtaCosto = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_1.CtaCosto.Codigo,
                                    DescripcionCta = it.Sucursal_1.CtaCosto.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_1.CtaCosto = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_2.CtaCosto != null)
                            {
                                r.Sucursal_2.CtaCosto = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_2.CtaCosto.Codigo,
                                    DescripcionCta = it.Sucursal_2.CtaCosto.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_2.CtaCosto = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_3.CtaCosto != null)
                            {
                                r.Sucursal_3.CtaCosto = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_3.CtaCosto.Codigo,
                                    DescripcionCta = it.Sucursal_3.CtaCosto.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_3.CtaCosto = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_4.CtaCosto != null)
                            {
                                r.Sucursal_4.CtaCosto = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_4.CtaCosto.Codigo,
                                    DescripcionCta = it.Sucursal_4.CtaCosto.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_4.CtaCosto = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_5.CtaCosto != null)
                            {
                                r.Sucursal_5.CtaCosto = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_5.CtaCosto.Codigo,
                                    DescripcionCta = it.Sucursal_5.CtaCosto.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_5.CtaCosto = new OOB.Cuenta.Ficha();
                            }


                            //CTA VENTA , PARA LAS DOS SUCUSALES
                            if (it.Sucursal_1.CtaVenta != null)
                            {
                                r.Sucursal_1.CtaVenta = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_1.CtaVenta.Codigo,
                                    DescripcionCta = it.Sucursal_1.CtaVenta.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_1.CtaVenta = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_2.CtaVenta != null)
                            {
                                r.Sucursal_2.CtaVenta = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_2.CtaVenta.Codigo,
                                    DescripcionCta = it.Sucursal_2.CtaVenta.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_2.CtaVenta = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_3.CtaVenta != null)
                            {
                                r.Sucursal_3.CtaVenta = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_3.CtaVenta.Codigo,
                                    DescripcionCta = it.Sucursal_3.CtaVenta.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_3.CtaVenta = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_4.CtaVenta != null)
                            {
                                r.Sucursal_4.CtaVenta = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_4.CtaVenta.Codigo,
                                    DescripcionCta = it.Sucursal_4.CtaVenta.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_4.CtaVenta = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_5.CtaVenta != null)
                            {
                                r.Sucursal_5.CtaVenta = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_5.CtaVenta.Codigo,
                                    DescripcionCta = it.Sucursal_5.CtaVenta.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_5.CtaVenta = new OOB.Cuenta.Ficha();
                            }


                            //CTA MERMA, PARA LAS DOS SUCUSALES
                            if (it.Sucursal_1.CtaMerma != null)
                            {
                                r.Sucursal_1.CtaMerma = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_1.CtaMerma.Codigo,
                                    DescripcionCta = it.Sucursal_1.CtaMerma.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_1.CtaMerma = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_2.CtaMerma != null)
                            {
                                r.Sucursal_2.CtaMerma = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_2.CtaMerma.Codigo,
                                    DescripcionCta = it.Sucursal_2.CtaMerma.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_2.CtaMerma = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_3.CtaMerma != null)
                            {
                                r.Sucursal_3.CtaMerma = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_3.CtaMerma.Codigo,
                                    DescripcionCta = it.Sucursal_3.CtaMerma.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_3.CtaMerma = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_4.CtaMerma != null)
                            {
                                r.Sucursal_4.CtaMerma = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_4.CtaMerma.Codigo,
                                    DescripcionCta = it.Sucursal_4.CtaMerma.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_4.CtaMerma = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_5.CtaMerma != null)
                            {
                                r.Sucursal_5.CtaMerma = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_5.CtaMerma.Codigo,
                                    DescripcionCta = it.Sucursal_5.CtaMerma.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_5.CtaMerma = new OOB.Cuenta.Ficha();
                            }


                            //CTA CONSUMO INTERNO, PARA LAS DOS SUCUSALES
                            if (it.Sucursal_1.CtaConcumoInterno != null)
                            {
                                r.Sucursal_1.CtaConsumoInterno = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_1.CtaConcumoInterno.Codigo,
                                    DescripcionCta = it.Sucursal_1.CtaConcumoInterno.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_1.CtaConsumoInterno = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_2.CtaConcumoInterno != null)
                            {
                                r.Sucursal_2.CtaConsumoInterno = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_2.CtaConcumoInterno.Codigo,
                                    DescripcionCta = it.Sucursal_2.CtaConcumoInterno.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_2.CtaConsumoInterno = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_3.CtaConcumoInterno != null)
                            {
                                r.Sucursal_3.CtaConsumoInterno = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_3.CtaConcumoInterno.Codigo,
                                    DescripcionCta = it.Sucursal_3.CtaConcumoInterno.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_3.CtaConsumoInterno = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_4.CtaConcumoInterno != null)
                            {
                                r.Sucursal_4.CtaConsumoInterno = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_4.CtaConcumoInterno.Codigo,
                                    DescripcionCta = it.Sucursal_4.CtaConcumoInterno.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_4.CtaConsumoInterno = new OOB.Cuenta.Ficha();
                            }
                            if (it.Sucursal_5.CtaConcumoInterno != null)
                            {
                                r.Sucursal_5.CtaConsumoInterno = new OOB.Cuenta.Ficha()
                                {
                                    CodigoCta = it.Sucursal_5.CtaConcumoInterno.Codigo,
                                    DescripcionCta = it.Sucursal_5.CtaConcumoInterno.Descripcion,
                                };
                            }
                            else
                            {
                                r.Sucursal_5.CtaConsumoInterno = new OOB.Cuenta.Ficha();
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

        public OOB.Resultado.ResultadoEntidad<OOB.Empresa.Departamento.Ficha> Empresa_Departamento_GetById(string autoDep)
        {
            var rt = new OOB.Resultado.ResultadoEntidad<OOB.Empresa.Departamento.Ficha>();

            try
            {
                var resultDTO = _servicio.Empresa_Departamento_GetById(autoDep);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var r = new OOB.Empresa.Departamento.Ficha()
                      {
                          Id = resultDTO.Entidad.Id,
                          Codigo = resultDTO.Entidad.Codigo,
                          Descripcion = resultDTO.Entidad.Descripcion,
                          Sucursal_1=new OOB.Empresa.Departamento.Sucursal(),
                          Sucursal_2=new OOB.Empresa.Departamento.Sucursal(),
                          Sucursal_3 = new OOB.Empresa.Departamento.Sucursal(),
                          Sucursal_4 = new OOB.Empresa.Departamento.Sucursal(),
                          Sucursal_5 = new OOB.Empresa.Departamento.Sucursal(),
                      };

                //INVENTARIO
                var ctaInventario = resultDTO.Entidad.Sucursal_1.CtaInventario;
                if (ctaInventario  != null)
                {
                    r.Sucursal_1.CtaInventario = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = ctaInventario.CodigoCta,
                        DescripcionCta = ctaInventario.DescripcionCta,
                        IdPlanCta = ctaInventario.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_1.CtaInventario = new OOB.Cuenta.Ficha();
                }
                var ctaInventario2 = resultDTO.Entidad.Sucursal_2.CtaInventario;
                if (ctaInventario2 != null)
                {
                    r.Sucursal_2.CtaInventario = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = ctaInventario2.CodigoCta,
                        DescripcionCta = ctaInventario2.DescripcionCta,
                        IdPlanCta = ctaInventario2.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_2.CtaInventario = new OOB.Cuenta.Ficha();
                }
                var ctaInventario3 = resultDTO.Entidad.Sucursal_3.CtaInventario;
                if (ctaInventario3 != null)
                {
                    r.Sucursal_3.CtaInventario = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = ctaInventario3.CodigoCta,
                        DescripcionCta = ctaInventario3.DescripcionCta,
                        IdPlanCta = ctaInventario3.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_3.CtaInventario = new OOB.Cuenta.Ficha();
                }
                var ctaInventario4 = resultDTO.Entidad.Sucursal_4.CtaInventario;
                if (ctaInventario4 != null)
                {
                    r.Sucursal_4.CtaInventario = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = ctaInventario4.CodigoCta,
                        DescripcionCta = ctaInventario4.DescripcionCta,
                        IdPlanCta = ctaInventario4.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_4.CtaInventario = new OOB.Cuenta.Ficha();
                }
                var ctaInventario5 = resultDTO.Entidad.Sucursal_5.CtaInventario;
                if (ctaInventario5 != null)
                {
                    r.Sucursal_5.CtaInventario = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = ctaInventario5.CodigoCta,
                        DescripcionCta = ctaInventario5.DescripcionCta,
                        IdPlanCta = ctaInventario5.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_5.CtaInventario = new OOB.Cuenta.Ficha();
                }


                //COSTO DE LA MERCANCIA
                var ctaCosto = resultDTO.Entidad.Sucursal_1.CtaCosto;
                if (ctaCosto != null)
                {
                    r.Sucursal_1.CtaCosto = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = ctaCosto.CodigoCta,
                        DescripcionCta = ctaCosto.DescripcionCta,
                        IdPlanCta = ctaCosto.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_1.CtaCosto= new OOB.Cuenta.Ficha();
                }
                var ctaCosto2= resultDTO.Entidad.Sucursal_2.CtaCosto;
                if (ctaCosto2 != null)
                {
                    r.Sucursal_2.CtaCosto = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = ctaCosto2.CodigoCta,
                        DescripcionCta = ctaCosto2.DescripcionCta,
                        IdPlanCta = ctaCosto2.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_2.CtaCosto = new OOB.Cuenta.Ficha();
                }
                var ctaCosto3 = resultDTO.Entidad.Sucursal_3.CtaCosto;
                if (ctaCosto3 != null)
                {
                    r.Sucursal_3.CtaCosto = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = ctaCosto3.CodigoCta,
                        DescripcionCta = ctaCosto3.DescripcionCta,
                        IdPlanCta = ctaCosto3.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_3.CtaCosto = new OOB.Cuenta.Ficha();
                }
                var ctaCosto4 = resultDTO.Entidad.Sucursal_4.CtaCosto;
                if (ctaCosto4 != null)
                {
                    r.Sucursal_4.CtaCosto = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = ctaCosto4.CodigoCta,
                        DescripcionCta = ctaCosto4.DescripcionCta,
                        IdPlanCta = ctaCosto4.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_4.CtaCosto = new OOB.Cuenta.Ficha();
                }
                var ctaCosto5 = resultDTO.Entidad.Sucursal_5.CtaCosto;
                if (ctaCosto5 != null)
                {
                    r.Sucursal_5.CtaCosto = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = ctaCosto5.CodigoCta,
                        DescripcionCta = ctaCosto5.DescripcionCta,
                        IdPlanCta = ctaCosto5.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_5.CtaCosto = new OOB.Cuenta.Ficha();
                }


                //VENTA DE LA MERCANCIA
                var xctaVenta = resultDTO.Entidad.Sucursal_1.CtaVenta;
                if (xctaVenta != null)
                {
                    r.Sucursal_1.CtaVenta = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaVenta.CodigoCta,
                        DescripcionCta = xctaVenta.DescripcionCta,
                        IdPlanCta = xctaVenta.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_1.CtaVenta = new OOB.Cuenta.Ficha();
                }
                var xctaVenta2 = resultDTO.Entidad.Sucursal_2.CtaVenta ;
                if (xctaVenta2 != null)
                {
                    r.Sucursal_2.CtaVenta = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaVenta2.CodigoCta,
                        DescripcionCta = xctaVenta2.DescripcionCta,
                        IdPlanCta = xctaVenta2.IdPlanCta
                    };
                }
               else
                {
                    r.Sucursal_2.CtaVenta = new OOB.Cuenta.Ficha();
                }
                var xctaVenta3 = resultDTO.Entidad.Sucursal_3.CtaVenta;
                if (xctaVenta3 != null)
                {
                    r.Sucursal_3.CtaVenta = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaVenta3.CodigoCta,
                        DescripcionCta = xctaVenta3.DescripcionCta,
                        IdPlanCta = xctaVenta3.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_3.CtaVenta = new OOB.Cuenta.Ficha();
                }
                var xctaVenta4 = resultDTO.Entidad.Sucursal_4.CtaVenta;
                if (xctaVenta4 != null)
                {
                    r.Sucursal_4.CtaVenta = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaVenta4.CodigoCta,
                        DescripcionCta = xctaVenta4.DescripcionCta,
                        IdPlanCta = xctaVenta4.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_4.CtaVenta = new OOB.Cuenta.Ficha();
                }
                var xctaVenta5 = resultDTO.Entidad.Sucursal_5.CtaVenta;
                if (xctaVenta5 != null)
                {
                    r.Sucursal_5.CtaVenta = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaVenta5.CodigoCta,
                        DescripcionCta = xctaVenta5.DescripcionCta,
                        IdPlanCta = xctaVenta5.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_5.CtaVenta = new OOB.Cuenta.Ficha();
                }

                //MERMA DE LA MERCANCIA
                var xctaMerma = resultDTO.Entidad.Sucursal_1.CtaMerma ;
                if (xctaMerma != null)
                {
                    r.Sucursal_1.CtaMerma = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaMerma.CodigoCta,
                        DescripcionCta = xctaMerma.DescripcionCta,
                        IdPlanCta = xctaMerma.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_1.CtaMerma = new OOB.Cuenta.Ficha();
                }
                var xctaMerma2 = resultDTO.Entidad.Sucursal_2.CtaMerma;
                if (xctaMerma2 != null)
                {
                    r.Sucursal_2.CtaMerma = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaMerma2.CodigoCta,
                        DescripcionCta = xctaMerma2.DescripcionCta,
                        IdPlanCta = xctaMerma2.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_2.CtaMerma = new OOB.Cuenta.Ficha();
                }
                var xctaMerma3 = resultDTO.Entidad.Sucursal_3.CtaMerma;
                if (xctaMerma3 != null)
                {
                    r.Sucursal_3.CtaMerma = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaMerma3.CodigoCta,
                        DescripcionCta = xctaMerma3.DescripcionCta,
                        IdPlanCta = xctaMerma3.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_3.CtaMerma = new OOB.Cuenta.Ficha();
                }
                var xctaMerma4 = resultDTO.Entidad.Sucursal_4.CtaMerma;
                if (xctaMerma4 != null)
                {
                    r.Sucursal_4.CtaMerma = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaMerma4.CodigoCta,
                        DescripcionCta = xctaMerma4.DescripcionCta,
                        IdPlanCta = xctaMerma4.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_4.CtaMerma = new OOB.Cuenta.Ficha();
                }
                var xctaMerma5 = resultDTO.Entidad.Sucursal_5.CtaMerma;
                if (xctaMerma5 != null)
                {
                    r.Sucursal_5.CtaMerma = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaMerma5.CodigoCta,
                        DescripcionCta = xctaMerma5.DescripcionCta,
                        IdPlanCta = xctaMerma5.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_5.CtaMerma = new OOB.Cuenta.Ficha();
                }
                
                //CONSUMO INTERNO 
                var xctaConsumoInterno = resultDTO.Entidad.Sucursal_1.CtaConsumoInterno;
                if (xctaConsumoInterno != null)
                {
                    r.Sucursal_1.CtaConsumoInterno = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaConsumoInterno.CodigoCta,
                        DescripcionCta = xctaConsumoInterno.DescripcionCta,
                        IdPlanCta = xctaConsumoInterno.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_1.CtaConsumoInterno = new OOB.Cuenta.Ficha();
                }
                var xctaConsumoInterno2 = resultDTO.Entidad.Sucursal_2.CtaConsumoInterno;
                if (xctaConsumoInterno2 != null)
                {
                    r.Sucursal_2.CtaConsumoInterno = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaConsumoInterno2.CodigoCta,
                        DescripcionCta = xctaConsumoInterno2.DescripcionCta,
                        IdPlanCta = xctaConsumoInterno2.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_2.CtaConsumoInterno = new OOB.Cuenta.Ficha();
                }
                var xctaConsumoInterno3 = resultDTO.Entidad.Sucursal_3.CtaConsumoInterno;
                if (xctaConsumoInterno3 != null)
                {
                    r.Sucursal_3.CtaConsumoInterno = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaConsumoInterno3.CodigoCta,
                        DescripcionCta = xctaConsumoInterno3.DescripcionCta,
                        IdPlanCta = xctaConsumoInterno3.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_3.CtaConsumoInterno = new OOB.Cuenta.Ficha();
                }
                var xctaConsumoInterno4 = resultDTO.Entidad.Sucursal_4.CtaConsumoInterno;
                if (xctaConsumoInterno4 != null)
                {
                    r.Sucursal_4.CtaConsumoInterno = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaConsumoInterno4.CodigoCta,
                        DescripcionCta = xctaConsumoInterno4.DescripcionCta,
                        IdPlanCta = xctaConsumoInterno4.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_4.CtaConsumoInterno = new OOB.Cuenta.Ficha();
                }
                var xctaConsumoInterno5 = resultDTO.Entidad.Sucursal_5.CtaConsumoInterno;
                if (xctaConsumoInterno5 != null)
                {
                    r.Sucursal_5.CtaConsumoInterno = new OOB.Cuenta.Ficha()
                    {
                        CodigoCta = xctaConsumoInterno5.CodigoCta,
                        DescripcionCta = xctaConsumoInterno5.DescripcionCta,
                        IdPlanCta = xctaConsumoInterno5.IdPlanCta
                    };
                }
                else
                {
                    r.Sucursal_5.CtaConsumoInterno = new OOB.Cuenta.Ficha();
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

        public OOB.Resultado.Resultado Empresa_Departamento_Actualizar(OOB.Empresa.Departamento.Actualizar ficha)
        {
            var result = new OOB.Resultado.Resultado();

            var fichaDTO = new DTO.Empresa.Departamentos.Actualizar()
            {
                IdDepartamento =ficha.Id,
                IdSucursal=ficha.IdSucursal,
                IdCtaInv= ficha.CtaInventario.Id ,
                IdCtaCosto= ficha.CtaCosto.Id ,
                IdCtaVenta=ficha.CtaVenta.Id ,
                IdCtaMerma=ficha.CtaMerma.Id ,
                IdCtaConsumoInterno= ficha.CtaConsumo.Id, 
            };

            var resultDTO = _servicio.Empresa_Departamento_Actualizar(fichaDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Mensaje = resultDTO.Mensaje;
                result.Result = OOB.Resultado.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.Resultado.ResultadoLista<OOB.Empresa.SerialesFiscales.Ficha> Empresa_SerialesFiscales_Lista()
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.Empresa.SerialesFiscales.Ficha>();

            try
            {
                var resultDTO = _servicio.Empresa_SerialesFiscales_Lista();
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var list = new List<OOB.Empresa.SerialesFiscales.Ficha>();
                if (resultDTO.Lista.Count > 0)
                {
                    foreach (var it in resultDTO.Lista)
                    {
                        var r = new OOB.Empresa.SerialesFiscales.Ficha()
                        {
                            Descripcion = it.Descripcion,
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

        public OOB.Resultado.ResultadoEntidad<OOB.Empresa.DatosNegocio.Ficha> Empresa_DatosNegocio()
        {
            var rt = new OOB.Resultado.ResultadoEntidad<OOB.Empresa.DatosNegocio.Ficha>();

            try
            {
                var resultDTO = _servicio.Empresa_DatosNegocio();
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var r = new OOB.Empresa.DatosNegocio.Ficha()
                {
                     Rif= resultDTO.Entidad.Rif ,
                     NombreRazonSocial = resultDTO.Entidad.NombreRazonSocial ,
                     DireccionFiscal = resultDTO.Entidad.DireccionFiscal ,
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

    }

}