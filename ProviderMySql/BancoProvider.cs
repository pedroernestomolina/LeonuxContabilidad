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

        //BANCOS
        public DTO.ResultadoLista<DTO.Bancos.Banco.Resumen> Bancos_Banco_Lista()
        {
            var result = new ResultadoLista<DTO.Bancos.Banco.Resumen>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.bancos.ToList();
                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            var r = new DTO.Bancos.Banco.Resumen()
                            {
                                Id = d.auto,
                                Codigo = d.codigo,
                                Nombre = d.nombre,
                                Numero = d.numero_cuenta
                            };

                            var entContBanco = ctx.contabilidad_banco.FirstOrDefault(b => b.auto_banco == d.auto);
                            if (entContBanco != null)
                            {
                                if (entContBanco.idPlanCta.HasValue)
                                {
                                    r.CtaContable = new DTO.Cuenta.Resumen()
                                    {
                                        Codigo = entContBanco.contabilidad_plancta1.codigo,
                                        Descripcion = entContBanco.contabilidad_plancta1.descripcion,
                                    };
                                };

                                if (entContBanco.idPlanCta_IGTF.HasValue)
                                {
                                    r.CtaIGTF = new DTO.Cuenta.Resumen()
                                    {
                                        Codigo = entContBanco.contabilidad_plancta.codigo,
                                        Descripcion = entContBanco.contabilidad_plancta.descripcion, 
                                    };
                                }
                            }

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

        public ResultadoLista<DTO.Bancos.Banco.Resumen> Bancos_Banco_Lista_Resumen()
        {
            var result = new ResultadoLista<DTO.Bancos.Banco.Resumen>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.bancos.ToList();
                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            var r = new DTO.Bancos.Banco.Resumen()
                            {
                                Id = d.auto,
                                Codigo = d.codigo,
                                Nombre = d.nombre,
                                Numero = d.numero_cuenta
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

        public ResultadoEntidad<DTO.Bancos.Banco.Ficha> Bancos_Banco_GetById(string autoBanco)
        {
            var result = new ResultadoEntidad<DTO.Bancos.Banco.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var entDep = ctx.bancos.Find(autoBanco);
                    if (entDep == null)
                    {
                        result.Mensaje = "[ ID ] BANCO NO ENCONTRADO";
                        result.Result = EnumResult.isError;
                        return result;
                    }

                    var r = new DTO.Bancos.Banco.Ficha()
                    {
                        Id = entDep.auto,
                        Codigo = entDep.codigo,
                        Nombre = entDep.nombre,
                        Numero = entDep.numero_cuenta,
                    };

                    var entContBanco = ctx.contabilidad_banco.FirstOrDefault(b => b.auto_banco == entDep.auto);
                    if (entContBanco != null)
                    {
                        if (entContBanco.idPlanCta.HasValue) 
                        {
                            var cta = new DTO.Cuenta.Ficha()
                            {
                                Id = -1,
                                IdPlanCta = entContBanco.contabilidad_plancta1.id,
                                CodigoCta = entContBanco.contabilidad_plancta1.codigo,
                                DescripcionCta = entContBanco.contabilidad_plancta1.descripcion,
                            };
                            r.CtaContable = cta;
                        }

                        if (entContBanco.idPlanCta_IGTF.HasValue) 
                        {
                            var ctaIGTF = new DTO.Cuenta.Ficha()
                            {
                                Id = -1,
                                IdPlanCta = entContBanco.contabilidad_plancta.id,
                                CodigoCta = entContBanco.contabilidad_plancta.codigo,
                                DescripcionCta = entContBanco.contabilidad_plancta.descripcion,
                            };
                            r.CtaIGTF = ctaIGTF;
                        }
                    }

                    result.Entidad = r;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public Resultado Bancos_Banco_Actualizar(DTO.Bancos.Banco.Actualizar ficha)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {

                        //if (ficha.IdCtaContable.HasValue)
                        //{
                        //}
                        //else
                        //{
                        //    var entContBanco = ctx.contabilidad_banco.FirstOrDefault(b => b.auto_banco == ficha.AutoBanco);
                        //    ctx.contabilidad_banco.Remove(entContBanco);
                        //}

                        var entContBanco = ctx.contabilidad_banco.FirstOrDefault(b => b.auto_banco == ficha.AutoBanco);
                        if (entContBanco == null)
                        {
                            entContBanco = new contabilidad_banco()
                            {
                                idPlanCta = ficha.IdCtaContable.Value,
                                idPlanCta_IGTF = ficha.IdCtaIGTF.Value,
                                auto_banco = ficha.AutoBanco,
                            };
                            ctx.contabilidad_banco.Add(entContBanco);
                            ctx.SaveChanges();
                        }
                        else
                        {
                            var entReglaIntPago = ctx.contabilidad_reglas_integracion_detalle.FirstOrDefault(w => 
                                w.idReglaIntegracion == 3 &&
                                w.referencia.Trim().ToUpper() == "BANCO" &&
                                w.idPlanCta == entContBanco.idPlanCta);
                            if (entReglaIntPago != null) 
                            {
                                ctx.contabilidad_reglas_integracion_detalle.Remove(entReglaIntPago);
                                ctx.SaveChanges();
                            }

                            var entReglaIntBanco = ctx.contabilidad_reglas_integracion_detalle.FirstOrDefault(w =>
                                w.idReglaIntegracion == 6 &&
                                w.referencia.Trim().ToUpper()=="BANCO MOV" &&
                                w.idPlanCta == entContBanco.idPlanCta);
                            if (entReglaIntBanco != null)
                            {
                                ctx.contabilidad_reglas_integracion_detalle.Remove(entReglaIntBanco);
                                ctx.SaveChanges();
                            }
                            
                            entContBanco.idPlanCta=null;
                            if (ficha.IdCtaContable.HasValue)
                            {
                                entContBanco.idPlanCta=ficha.IdCtaContable.Value;
                            }
                            entContBanco.idPlanCta_IGTF=null;
                            if (ficha.IdCtaIGTF.HasValue)
                            {
                                entContBanco.idPlanCta_IGTF = ficha.IdCtaIGTF.Value;
                            }
                            ctx.SaveChanges();

                            if (ficha.IdCtaContable.HasValue) 
                            {
                                entContBanco.idPlanCta = ficha.IdCtaContable.Value;
                            }
                            if (ficha.IdCtaIGTF.HasValue) 
                            {
                                entContBanco.idPlanCta_IGTF = ficha.IdCtaIGTF.Value;
                            }
                            ctx.SaveChanges();
                        }

                        if (ficha.IdCtaContable.HasValue)
                        {
                            var reglaPago = new contabilidad_reglas_integracion_detalle()
                            {
                                idReglaIntegracion = 3,
                                idPlanCta = ficha.IdCtaContable.Value,
                                signo = -1,
                                referencia = "BANCO",
                                idSucursal = 0,
                            };
                            ctx.contabilidad_reglas_integracion_detalle.Add(reglaPago);
                            ctx.SaveChanges();

                            var reglaBanco = new contabilidad_reglas_integracion_detalle()
                            {
                                idReglaIntegracion = 6,
                                idPlanCta = ficha.IdCtaContable.Value,
                                signo = 1,
                                referencia = "BANCO MOV",
                                idSucursal = 0,
                            };
                            ctx.contabilidad_reglas_integracion_detalle.Add(reglaBanco);
                            ctx.SaveChanges();
                        }

                        ctx.SaveChanges();
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

        public Resultado Bancos_Banco_VerificaActualizar(DTO.Bancos.Banco.Actualizar ficha)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var det = ctx.bancos.Find(ficha.AutoBanco);
                    if (det == null)
                    {
                        result.Mensaje = "[ ID ] BANCO NO ENCONTRADO";
                        result.Result = EnumResult.isError;
                        return result;
                    }

                    if (ficha.IdCtaContable.HasValue)
                    {
                        var det2 = ctx.contabilidad_plancta.Find(ficha.IdCtaContable.Value);
                        if (det2 == null)
                        {
                            result.Mensaje = "[ ID ] CUENTA CONTABLE NO ENCONTRADO";
                            result.Result = EnumResult.isError;
                            return result;
                        }
                    }

                    if (ficha.IdCtaIGTF.HasValue)
                    {
                        if (ficha.IdCtaIGTF.Value != -1)
                        {
                            var det3 = ctx.contabilidad_plancta.Find(ficha.IdCtaIGTF.Value);
                            if (det3 == null)
                            {
                                result.Mensaje = "[ ID ] AUXILIAR CTA IGTF NO ENCONTRADO";
                                result.Result = EnumResult.isError;
                                return result;
                            }
                        }
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


        //CONCEPTOS
        public ResultadoEntidad<DTO.Bancos.Conceptos.Ficha> Banco_Concepto_GetById(string autoConcepto)
        {
            var result = new ResultadoEntidad<DTO.Bancos.Conceptos.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var entDep = ctx.bancos_movimientos_conceptos.Find(autoConcepto);
                    if (entDep == null)
                    {
                        result.Mensaje = "[ ID ] CONCEPTO NO ENCONTRADO";
                        result.Result = EnumResult.isError;
                        return result;
                    }

                    var r = new DTO.Bancos.Conceptos.Ficha()
                    {
                        Id = entDep.auto,
                        Codigo = entDep.codigo,
                        Descripcion = entDep.nombre,
                    };

                    var entContBancoConcepto = ctx.contabilidad_banco_conceptos.FirstOrDefault(cp => cp.autoMovimientoConcepto == autoConcepto);
                    if (entContBancoConcepto != null)
                    {
                        //CTA GASTO (5)
                        var entCtaGasto = ctx.contabilidad_plancta.Find(entContBancoConcepto.idCtaGasto);
                        if (entCtaGasto != null)
                        {
                            var cta = new DTO.Cuenta.Ficha()
                            {
                                Id = -1,
                                IdPlanCta = entCtaGasto.id,
                                CodigoCta = entCtaGasto.codigo,
                                DescripcionCta = entCtaGasto.descripcion,
                            };
                            r.CtaGasto = cta;
                        }

                        //CTA PASIVO (2)
                        var entCtaPasivo = ctx.contabilidad_plancta.Find(entContBancoConcepto.idCtaPasivo);
                        if (entCtaPasivo != null)
                        {
                            var cta = new DTO.Cuenta.Ficha()
                            {
                                Id = -1,
                                IdPlanCta = entCtaPasivo.id,
                                CodigoCta = entCtaPasivo.codigo,
                                DescripcionCta = entCtaPasivo.descripcion,
                            };
                            r.CtaPasivo = cta;
                        }

                        //CTA BANCO 
                        var entCtaBanco = ctx.contabilidad_plancta.Find(entContBancoConcepto.idCtaBanco);
                        if (entCtaBanco != null)
                        {
                            var cta = new DTO.Cuenta.Ficha()
                            {
                                Id = -1,
                                IdPlanCta = entCtaBanco.id,
                                CodigoCta = entCtaBanco.codigo,
                                DescripcionCta = entCtaBanco.descripcion,
                            };
                            r.CtaBanco = cta;
                        }
                    }

                    result.Entidad = r;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public Resultado Banco_Concepto_Actualizar(DTO.Bancos.Conceptos.Actualizar ficha)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {

                        var entBanConcepto = ctx.bancos_movimientos_conceptos.Find(ficha.AutoConcepto);
                        if (entBanConcepto == null)
                        {
                            result.Mensaje = "[ ID ] CONCEPTO NO ENCONTRADO";
                            result.Result = EnumResult.isError;
                            return result;
                        }

                        if (ficha.IdCtaGasto != -1)
                        {
                            var entCtaGasto = ctx.contabilidad_plancta.Find(ficha.IdCtaGasto);
                            if (entCtaGasto == null)
                            {
                                result.Mensaje = "[ ID CTA GASTO ] NO ENCONTRADO";
                                result.Result = EnumResult.isError;
                                return result;
                            }
                        }

                        if (ficha.IdCtaPasivo != -1)
                        {
                            var entCtaPasivo = ctx.contabilidad_plancta.Find(ficha.IdCtaPasivo);
                            if (entCtaPasivo == null)
                            {
                                result.Mensaje = "[ ID CTA PASIVO ] NO ENCONTRADO";
                                result.Result = EnumResult.isError;
                                return result;
                            }
                        }

                        if (ficha.IdCtaBanco != -1)
                        {
                            var entCtaBanco = ctx.contabilidad_plancta.Find(ficha.IdCtaBanco);
                            if (entCtaBanco == null)
                            {
                                result.Mensaje = "[ ID CTA BANCO ] NO ENCONTRADO";
                                result.Result = EnumResult.isError;
                                return result;
                            }
                        }

                        var entContBanConcepto = ctx.contabilidad_banco_conceptos.FirstOrDefault(ct => ct.autoMovimientoConcepto == ficha.AutoConcepto);
                        if (entContBanConcepto == null)
                        {
                            entContBanConcepto = new contabilidad_banco_conceptos()
                            {
                                autoMovimientoConcepto = ficha.AutoConcepto,
                                idCtaGasto = ficha.IdCtaGasto,
                                idCtaPasivo = ficha.IdCtaPasivo,
                                idCtaBanco = ficha.IdCtaBanco,
                                idSucursal = "",
                            };
                            ctx.contabilidad_banco_conceptos.Add(entContBanConcepto);
                        }
                        else
                        {
                            entContBanConcepto.idCtaGasto = ficha.IdCtaGasto;
                            entContBanConcepto.idCtaPasivo = ficha.IdCtaPasivo;
                            entContBanConcepto.idCtaBanco = ficha.IdCtaBanco;
                        }
                        ctx.SaveChanges();


                        if (ficha.IdCtaBanco != -1)
                        {
                            var modoRef = entContBanConcepto.bancos_movimientos_conceptos.clase.Trim().ToUpper() == "EGRESO" ? "NDB" : "DEP";
                            var entRegla = ctx.contabilidad_reglas_integracion_detalle.FirstOrDefault(dt =>
                                dt.idPlanCta == ficha.IdCtaBanco &&
                                dt.referencia == modoRef &&
                                dt.idReglaIntegracion == 6);
                            if (entRegla == null)
                            {
                                entRegla = new contabilidad_reglas_integracion_detalle()
                                {
                                    idReglaIntegracion = 6,
                                    idPlanCta = ficha.IdCtaBanco,
                                    signo = -1,
                                    referencia = modoRef,
                                    idSucursal = 0,
                                };
                                ctx.contabilidad_reglas_integracion_detalle.Add(entRegla);
                            }
                            else
                            {
                                entRegla.idPlanCta = ficha.IdCtaBanco;
                            }
                            ctx.SaveChanges();
                        }

                        if (ficha.IdCtaPasivo != -1)
                        {
                            var entRegla = ctx.contabilidad_reglas_integracion_detalle.FirstOrDefault(dt =>
                                dt.idPlanCta == ficha.IdCtaPasivo &&
                                dt.referencia == "MONTO POR PAGAR" &&
                                dt.idReglaIntegracion == 2);
                            if (entRegla == null)
                            {
                                entRegla = new contabilidad_reglas_integracion_detalle()
                                {
                                    idReglaIntegracion = 2,
                                    idPlanCta = ficha.IdCtaPasivo,
                                    signo = -1,
                                    referencia = "MONTO POR PAGAR",
                                    idSucursal=0,
                                };
                                ctx.contabilidad_reglas_integracion_detalle.Add(entRegla);
                            }
                            else
                            {
                                entRegla.idPlanCta = ficha.IdCtaPasivo;
                            }
                            ctx.SaveChanges();

                            entRegla = ctx.contabilidad_reglas_integracion_detalle.FirstOrDefault(dt =>
                                dt.idPlanCta == ficha.IdCtaPasivo &&
                                dt.referencia == "MONTO PAGADO" &&
                                dt.idReglaIntegracion == 3);
                            if (entRegla == null)
                            {
                                entRegla = new contabilidad_reglas_integracion_detalle()
                                {
                                    idReglaIntegracion = 3,
                                    idPlanCta = ficha.IdCtaPasivo,
                                    signo = 1,
                                    referencia = "MONTO PAGADO",
                                    idSucursal=0,
                                };
                                ctx.contabilidad_reglas_integracion_detalle.Add(entRegla);
                            }
                            else
                            {
                                entRegla.idPlanCta = ficha.IdCtaPasivo;
                            }
                            ctx.SaveChanges();
                        }

                        if (ficha.IdCtaGasto != -1)
                        {
                            var entRegla = ctx.contabilidad_reglas_integracion_detalle.FirstOrDefault(dt =>
                                dt.idPlanCta == ficha.IdCtaGasto &&
                                dt.referencia == "GASTO" &&
                                dt.idReglaIntegracion == 2);
                            if (entRegla == null)
                            {
                                entRegla = new contabilidad_reglas_integracion_detalle()
                                {
                                    idReglaIntegracion = 2,
                                    idPlanCta = ficha.IdCtaGasto,
                                    signo = 1,
                                    referencia = "GASTO",
                                    idSucursal=0,
                                };
                                ctx.contabilidad_reglas_integracion_detalle.Add(entRegla);
                            }
                            else
                            {
                                entRegla.idPlanCta = ficha.IdCtaGasto;
                            }
                            ctx.SaveChanges();
                        }

                        ctx.SaveChanges();
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

        public ResultadoLista<DTO.Bancos.Conceptos.Resumen> Banco_Concepto_Lista(DTO.Bancos.Conceptos.Filtro filtros)
        {
            var result = new ResultadoLista<DTO.Bancos.Conceptos.Resumen>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.bancos_movimientos_conceptos.ToList();

                    if (!string.IsNullOrEmpty(filtros.Cadena))
                    {
                        var cad = filtros.Cadena.Trim().ToUpper();
                        q = q.Where(c => c.nombre.Trim().ToUpper().Contains(cad)).ToList();
                    }
                    switch (filtros.tipoMovimiento)
                    {
                        case DTO.Bancos.Conceptos.Enumerados.TipoMovimiento.Ingreso:
                            q = q.Where(c => c.clase.Trim().ToUpper() == "INGRESO").ToList();
                            break;
                        case DTO.Bancos.Conceptos.Enumerados.TipoMovimiento.Egreso:
                            q = q.Where(c => c.clase.Trim().ToUpper() == "EGRESO").ToList();
                            break;
                    }

                    if (q.Count > 0)
                    {
                        var list = new List<DTO.Bancos.Conceptos.Resumen>();
                        foreach (var d in q) 
                        {
                            var r = new DTO.Bancos.Conceptos.Resumen()
                            {
                                Id = d.auto,
                                Codigo = d.codigo,
                                Descripcion = d.nombre,
                            };

                            if (filtros.tipoLista == DTO.Bancos.Conceptos.Enumerados.TipoLista.General)
                            {
                                var entContBancoConcepto = ctx.contabilidad_banco_conceptos.FirstOrDefault(cp => cp.autoMovimientoConcepto == d.auto);
                                if (entContBancoConcepto != null)
                                {
                                    //CTA GASTO (5)
                                    if (entContBancoConcepto.idCtaGasto != -1)
                                    {
                                        var entCtaGasto = ctx.contabilidad_plancta.Find(entContBancoConcepto.idCtaGasto);
                                        if (entCtaGasto != null)
                                        {
                                            r.CtaGasto = new DTO.Cuenta.Resumen()
                                            {
                                                Codigo = entCtaGasto.codigo,
                                                Descripcion = entCtaGasto.descripcion
                                            };
                                        }
                                    }

                                    //CTA PASIVO (2)
                                    if (entContBancoConcepto.idCtaPasivo != -1)
                                    {
                                        var entCtaPasivo = ctx.contabilidad_plancta.Find(entContBancoConcepto.idCtaPasivo);
                                        if (entCtaPasivo != null)
                                        {
                                            r.CtaPasivo = new DTO.Cuenta.Resumen()
                                            {
                                                Codigo = entCtaPasivo.codigo,
                                                Descripcion = entCtaPasivo.descripcion
                                            };
                                        }
                                    }

                                    //CTA BANCO
                                    if (entContBancoConcepto.idCtaBanco != -1)
                                    {
                                        var entCtaBanco = ctx.contabilidad_plancta.Find(entContBancoConcepto.idCtaBanco);
                                        if (entCtaBanco != null)
                                        {
                                            r.CtaBanco = new DTO.Cuenta.Resumen()
                                            {
                                                Codigo = entCtaBanco.codigo,
                                                Descripcion = entCtaBanco.descripcion
                                            };
                                        }
                                    }
                                }
                            }

                            list.Add(r);
                        }

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

        
        //MOVIMIENTOS

        public ResultadoEntidad<DTO.Bancos.Movimiento.Ficha> Bancos_Movimiento_GetById(string autoMov)
        {
            var result = new ResultadoEntidad<DTO.Bancos.Movimiento.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.bancos_movimientos.Find(autoMov);
                    if (ent == null)
                    {
                        result.Mensaje = "MOVIMIENTO NO ENCONTRADO";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var tipo = DTO.Bancos.Enumerados.TipMovimiento.SinDefinir;
                    switch (ent.tipo.Trim().ToUpper())
                    {
                        case "CHQ":
                            tipo = DTO.Bancos.Enumerados.TipMovimiento.CHEQUE;
                            break;
                        case "DEP":
                            tipo = DTO.Bancos.Enumerados.TipMovimiento.DEPOSITO;
                            break;
                        case "NCR":
                            tipo = DTO.Bancos.Enumerados.TipMovimiento.NOTA_CREDITO;
                            break;
                        case "NDB":
                            tipo = DTO.Bancos.Enumerados.TipMovimiento.NOTA_DEBITO;
                            break;
                    }

                    var origen = DTO.Bancos.Enumerados.OrigenMovimiento.SinDefinir;
                    switch (ent.origen.Trim().ToUpper())
                    {
                        case "BAN":
                            origen = DTO.Bancos.Enumerados.OrigenMovimiento.BANCO;
                            break;
                        case "CXP":
                            origen = DTO.Bancos.Enumerados.OrigenMovimiento.CTA_PAGAR;
                            break;
                    }

                    var doc = new DTO.Bancos.Movimiento.Ficha()
                    {
                        FechaEmision = ent.fecha,
                        TipoMovimiento = tipo,
                        DocumentoReferencia = ent.documento,
                        Signo = ent.signo,
                        Importe = ent.importe,
                        IsConciliado = (ent.estatus_conciliado == "0" ? false : true),
                        IsAnulado = (ent.estatus_anulado == "0" ? false : true),
                        DetalleMovimiento = ent.detalle,
                        BancoNombre = ent.banco,
                        BancoCodigo = ent.codigo_banco,
                        BancoCta = ent.numero_cuenta,
                        ModuloOrigen = origen,
                        EntidadBeneficiario = ent.entidad,
                        ComprobanteNro = ent.comprobante_egreso,
                        FechaCheque = ent.fecha_cheque
                    };

                    result.Entidad = doc;
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