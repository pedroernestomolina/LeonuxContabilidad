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

        //DEPARTAMENTOS
        ResultadoLista<DTO.Empresa.Departamentos.Resumen> IProvider.IEmpresa.Empresa_Departamento_Lista()
        {
            var result = new ResultadoLista<DTO.Empresa.Departamentos.Resumen>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.empresa_departamentos.ToList();
                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.Empresa.Departamentos.Resumen()
                            {
                                Id = d.auto,
                                Codigo = d.codigo,
                                Descripcion = d.nombre, 
                                Sucursal_1 = new DTO.Empresa.Departamentos.SucursalResumen(),
                                Sucursal_2 = new DTO.Empresa.Departamentos.SucursalResumen(),
                                Sucursal_3 = new DTO.Empresa.Departamentos.SucursalResumen(),
                                Sucursal_4 = new DTO.Empresa.Departamentos.SucursalResumen(),
                                Sucursal_5 = new DTO.Empresa.Departamentos.SucursalResumen(),
                            };
                        }).ToList();

                        foreach (var dep in list)
                        {
                            var ctas = ctx.contabilidad_departamentos.Where(c => c.auto_departamento == dep.Id).ToList();
                            if (ctas.Count > 0)
                            {
                                foreach (var cta in ctas)
                                {
                                    DTO.Cuenta.Resumen ctaResumen = null;
                                    if (cta.idPlanCta!= null)
                                    {
                                        ctaResumen = new DTO.Cuenta.Resumen();
                                        ctaResumen.Codigo = cta.contabilidad_plancta2.codigo;
                                        ctaResumen.Descripcion = cta.contabilidad_plancta2.descripcion;
                                    }
                                    DTO.Cuenta.Resumen ctaResumen2 = null ;
                                    if (cta.idPlanCta_Sucursal_2 != null) 
                                    {
                                        ctaResumen2 = new DTO.Cuenta.Resumen();
                                        ctaResumen2.Codigo = cta.contabilidad_plancta.codigo;
                                        ctaResumen2.Descripcion = cta.contabilidad_plancta.descripcion;
                                    }
                                    DTO.Cuenta.Resumen ctaResumen3 = null;
                                    if (cta.idPlanCta_Sucursal_3 != null)
                                    {
                                        ctaResumen3 = new DTO.Cuenta.Resumen();
                                        ctaResumen3.Codigo = cta.contabilidad_plancta1.codigo;
                                        ctaResumen3.Descripcion = cta.contabilidad_plancta1.descripcion;
                                    }
                                    DTO.Cuenta.Resumen ctaResumen4 = null;
                                    if (cta.idPlanCta_Sucursal_4 != null)
                                    {
                                        ctaResumen4 = new DTO.Cuenta.Resumen();
                                        ctaResumen4.Codigo = cta.contabilidad_plancta3.codigo;
                                        ctaResumen4.Descripcion = cta.contabilidad_plancta3.descripcion;
                                    }
                                    DTO.Cuenta.Resumen ctaResumen5 = null;
                                    if (cta.idPlanCta_Sucursal_5 != null)
                                    {
                                        ctaResumen5 = new DTO.Cuenta.Resumen();
                                        ctaResumen5.Codigo = cta.contabilidad_plancta4.codigo;
                                        ctaResumen5.Descripcion = cta.contabilidad_plancta4.descripcion;
                                    }

                                    switch ((DTO.Empresa.Departamentos.Enumerados.Concepto)cta.Concepto)
                                    {
                                        case DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario:
                                            dep.Sucursal_1.CtaInventario = ctaResumen;
                                            dep.Sucursal_2.CtaInventario = ctaResumen2;
                                            dep.Sucursal_3.CtaInventario = ctaResumen3;
                                            dep.Sucursal_4.CtaInventario = ctaResumen4;
                                            dep.Sucursal_5.CtaInventario = ctaResumen5;
                                            break;
                                        case DTO.Empresa.Departamentos.Enumerados.Concepto.Costo:
                                            dep.Sucursal_1.CtaCosto = ctaResumen;
                                            dep.Sucursal_2.CtaCosto = ctaResumen2;
                                            dep.Sucursal_3.CtaCosto = ctaResumen3;
                                            dep.Sucursal_4.CtaCosto = ctaResumen4;
                                            dep.Sucursal_5.CtaCosto = ctaResumen5;
                                            break;
                                        case DTO.Empresa.Departamentos.Enumerados.Concepto.Venta:
                                            dep.Sucursal_1.CtaVenta = ctaResumen;
                                            dep.Sucursal_2.CtaVenta = ctaResumen2;
                                            dep.Sucursal_3.CtaVenta = ctaResumen3;
                                            dep.Sucursal_4.CtaVenta = ctaResumen4;
                                            dep.Sucursal_5.CtaVenta = ctaResumen5;
                                            break;
                                        case DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste:
                                            dep.Sucursal_1.CtaMerma = ctaResumen;
                                            dep.Sucursal_2.CtaMerma = ctaResumen2;
                                            dep.Sucursal_3.CtaMerma = ctaResumen3;
                                            dep.Sucursal_4.CtaMerma = ctaResumen4;
                                            dep.Sucursal_5.CtaMerma = ctaResumen5;
                                            break;
                                        case DTO.Empresa.Departamentos.Enumerados.Concepto.ConsumoInterno:
                                            dep.Sucursal_1.CtaConcumoInterno = ctaResumen;
                                            dep.Sucursal_2.CtaConcumoInterno = ctaResumen2;
                                            dep.Sucursal_3.CtaConcumoInterno = ctaResumen3;
                                            dep.Sucursal_4.CtaConcumoInterno = ctaResumen4;
                                            dep.Sucursal_5.CtaConcumoInterno = ctaResumen5;
                                            break;
                                    }
                                }
                            }
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

        public ResultadoEntidad<DTO.Empresa.Departamentos.Ficha> Empresa_Departamento_GetById(string autoDep)
        {
            var result = new ResultadoEntidad<DTO.Empresa.Departamentos.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var entDep = ctx.empresa_departamentos.Find(autoDep);
                    if (entDep == null)
                    {
                        result.Mensaje = "[ ID ] DEPARTAMENTO NO ENCONTADO";
                        result.Result = EnumResult.isError;
                        return result;
                    }

                    var r = new DTO.Empresa.Departamentos.Ficha()
                    {
                        Id = entDep.auto,
                        Codigo = entDep.codigo,
                        Descripcion = entDep.nombre,
                        Sucursal_1=new DTO.Empresa.Departamentos.Sucursal(),
                        Sucursal_2=new DTO.Empresa.Departamentos.Sucursal(),
                        Sucursal_3 = new DTO.Empresa.Departamentos.Sucursal(),
                        Sucursal_4 = new DTO.Empresa.Departamentos.Sucursal(),
                        Sucursal_5 = new DTO.Empresa.Departamentos.Sucursal(),
                    };

                    var ctas = ctx.contabilidad_departamentos.Where(c => c.auto_departamento == entDep.auto).ToList();
                    if (ctas.Count > 0)
                    {
                        foreach (var cta in ctas)
                        {

                            DTO.Cuenta.Ficha ctaResumen = null;
                            if (cta.idPlanCta != null) 
                            {
                                ctaResumen = new DTO.Cuenta.Ficha()
                                {
                                    Id = cta.id,
                                    IdPlanCta = cta.idPlanCta.Value,
                                    CodigoCta = cta.contabilidad_plancta2.codigo,
                                    DescripcionCta = cta.contabilidad_plancta2.descripcion,
                                };
                            }
                            DTO.Cuenta.Ficha ctaResumen2 = null;
                            if (cta.idPlanCta_Sucursal_2 != null)
                            {
                                ctaResumen2 = new DTO.Cuenta.Ficha()
                                {
                                    Id = cta.id,
                                    IdPlanCta = cta.idPlanCta_Sucursal_2.Value,
                                    CodigoCta = cta.contabilidad_plancta.codigo,
                                    DescripcionCta = cta.contabilidad_plancta.descripcion,
                                };
                            }
                            DTO.Cuenta.Ficha ctaResumen3 = null;
                            if (cta.idPlanCta_Sucursal_3 != null)
                            {
                                ctaResumen3 = new DTO.Cuenta.Ficha()
                                {
                                    Id = cta.id,
                                    IdPlanCta = cta.idPlanCta_Sucursal_3.Value,
                                    CodigoCta = cta.contabilidad_plancta1.codigo,
                                    DescripcionCta = cta.contabilidad_plancta1.descripcion,
                                };
                            }
                            DTO.Cuenta.Ficha ctaResumen4 = null;
                            if (cta.idPlanCta_Sucursal_4 != null)
                            {
                                ctaResumen4 = new DTO.Cuenta.Ficha()
                                {
                                    Id = cta.id,
                                    IdPlanCta = cta.idPlanCta_Sucursal_4.Value,
                                    CodigoCta = cta.contabilidad_plancta3.codigo,
                                    DescripcionCta = cta.contabilidad_plancta3.descripcion,
                                };
                            }
                            DTO.Cuenta.Ficha ctaResumen5 = null;
                            if (cta.idPlanCta_Sucursal_5 != null)
                            {
                                ctaResumen5 = new DTO.Cuenta.Ficha()
                                {
                                    Id = cta.id,
                                    IdPlanCta = cta.idPlanCta_Sucursal_5.Value,
                                    CodigoCta = cta.contabilidad_plancta4.codigo,
                                    DescripcionCta = cta.contabilidad_plancta4.descripcion,
                                };
                            }


                            switch ((DTO.Empresa.Departamentos.Enumerados.Concepto)cta.Concepto)
                            {
                                case DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario:
                                    r.Sucursal_1.CtaInventario = ctaResumen;
                                    r.Sucursal_2.CtaInventario = ctaResumen2;
                                    r.Sucursal_3.CtaInventario = ctaResumen3;
                                    r.Sucursal_4.CtaInventario = ctaResumen4;
                                    r.Sucursal_5.CtaInventario = ctaResumen5;
                                    break;
                                case DTO.Empresa.Departamentos.Enumerados.Concepto.Costo:
                                    r.Sucursal_1.CtaCosto = ctaResumen;
                                    r.Sucursal_2.CtaCosto = ctaResumen2;
                                    r.Sucursal_3.CtaCosto = ctaResumen3;
                                    r.Sucursal_4.CtaCosto = ctaResumen4;
                                    r.Sucursal_5.CtaCosto = ctaResumen5;
                                    break;
                                case DTO.Empresa.Departamentos.Enumerados.Concepto.Venta:
                                    r.Sucursal_1.CtaVenta = ctaResumen;
                                    r.Sucursal_2.CtaVenta = ctaResumen2;
                                    r.Sucursal_3.CtaVenta = ctaResumen3;
                                    r.Sucursal_4.CtaVenta = ctaResumen4;
                                    r.Sucursal_5.CtaVenta = ctaResumen5;
                                    break;
                                case DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste:
                                    r.Sucursal_1.CtaMerma = ctaResumen;
                                    r.Sucursal_2.CtaMerma = ctaResumen2;
                                    r.Sucursal_3.CtaMerma = ctaResumen3;
                                    r.Sucursal_4.CtaMerma = ctaResumen4;
                                    r.Sucursal_5.CtaMerma = ctaResumen5;
                                    break;
                                case DTO.Empresa.Departamentos.Enumerados.Concepto.ConsumoInterno:
                                    r.Sucursal_1.CtaConsumoInterno = ctaResumen;
                                    r.Sucursal_2.CtaConsumoInterno = ctaResumen2;
                                    r.Sucursal_3.CtaConsumoInterno = ctaResumen3;
                                    r.Sucursal_4.CtaConsumoInterno = ctaResumen4;
                                    r.Sucursal_5.CtaConsumoInterno = ctaResumen5;
                                    break;
                            }
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

        public Resultado Empresa_Departamento_Actualizar(DTO.Empresa.Departamentos.Actualizar ficha)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var dep = ctx.empresa_departamentos.Find(ficha.IdDepartamento);
                        if (dep == null) 
                        {
                            return new Resultado()
                            {
                                Mensaje = "[ ID ] DEPARTAMENTO NO ENCONTRADO",
                                Result = EnumResult.isError,
                            };
                        }

                        ///
                        var det = ctx.contabilidad_departamentos.FirstOrDefault(d =>
                            d.auto_departamento == ficha.IdDepartamento &&
                            d.Concepto == (int)DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                        if (det == null)
                        {
                            if (ficha.IdCtaInv != -1)
                            {
                                det = new contabilidad_departamentos()
                                {
                                    auto_departamento = ficha.IdDepartamento,
                                    Concepto = (int)DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario,
                                };
                                switch (ficha.IdSucursal)
                                {
                                    case 1:
                                        det.idPlanCta = ficha.IdCtaInv;
                                        det.idPlanCta_Sucursal_2 = null;
                                        det.idPlanCta_Sucursal_3 = null;
                                        det.idPlanCta_Sucursal_4 = null;
                                        det.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 2:
                                        det.idPlanCta = null;
                                        det.idPlanCta_Sucursal_2 = ficha.IdCtaInv;
                                        det.idPlanCta_Sucursal_4 = null;
                                        det.idPlanCta_Sucursal_5 = null;
                                        det.idPlanCta_Sucursal_3 = null;
                                        break;
                                    case 3:
                                        det.idPlanCta = null;
                                        det.idPlanCta_Sucursal_2 = null;
                                        det.idPlanCta_Sucursal_4 = null;
                                        det.idPlanCta_Sucursal_5 = null;
                                        det.idPlanCta_Sucursal_3 = ficha.IdCtaInv;
                                        break;
                                    case 4:
                                        det.idPlanCta = null;
                                        det.idPlanCta_Sucursal_2 = null;
                                        det.idPlanCta_Sucursal_3 = null;
                                        det.idPlanCta_Sucursal_5 = null;
                                        det.idPlanCta_Sucursal_4 = ficha.IdCtaInv;
                                        break;
                                    case 5:
                                        det.idPlanCta = null;
                                        det.idPlanCta_Sucursal_2 = null;
                                        det.idPlanCta_Sucursal_3 = null;
                                        det.idPlanCta_Sucursal_4 = null;
                                        det.idPlanCta_Sucursal_5 = ficha.IdCtaInv;
                                        break;
                                }
                                ctx.contabilidad_departamentos.Add(det);
                                ctx.SaveChanges();
                            }
                        }
                        else 
                        {
                            int idcta = -1;
                            switch (ficha.IdSucursal)
                            {
                                case 1:
                                    if (det.idPlanCta.HasValue) 
                                    {
                                        idcta = det.idPlanCta.Value;
                                    }
                                    break;
                                case 2:
                                    if (det.idPlanCta_Sucursal_2.HasValue) 
                                    {
                                        idcta = det.idPlanCta_Sucursal_2.Value;
                                    }
                                    break;
                                case 3:
                                    if (det.idPlanCta_Sucursal_3.HasValue)
                                    {
                                        idcta = det.idPlanCta_Sucursal_3.Value;
                                    }
                                    break;
                                case 4:
                                    if (det.idPlanCta_Sucursal_4.HasValue)
                                    {
                                        idcta = det.idPlanCta_Sucursal_4.Value;
                                    }
                                    break;
                                case 5:
                                    if (det.idPlanCta_Sucursal_5.HasValue)
                                    {
                                        idcta = det.idPlanCta_Sucursal_5.Value;
                                    }
                                    break;
                            }

                            //BUSCO REGLAS PARA ESE DEPARTAMENTO, ELIMINO
                            var entRegla = ctx.contabilidad_reglas_integracion_detalle.Where(r =>
                                (r.idReglaIntegracion == 1 || r.idReglaIntegracion == 2 || r.idReglaIntegracion == 5) &&
                                r.idPlanCta == idcta).ToList();
                            foreach (var n in entRegla) 
                            {
                                ctx.contabilidad_reglas_integracion_detalle.Remove(n);
                                ctx.SaveChanges();
                            }

                            switch (ficha.IdSucursal)
                            {
                                case 1:
                                    if (ficha.IdCtaInv == -1)
                                    {
                                        det.idPlanCta = null;
                                    }
                                    else
                                    {
                                        det.idPlanCta = ficha.IdCtaInv;
                                    }
                                    break;
                                case 2:
                                    if (ficha.IdCtaInv == -1)
                                    {
                                        det.idPlanCta_Sucursal_2 = null;
                                    }
                                    else
                                    {
                                        det.idPlanCta_Sucursal_2 = ficha.IdCtaInv;
                                    }
                                    break;
                                case 3:
                                    if (ficha.IdCtaInv == -1)
                                    {
                                        det.idPlanCta_Sucursal_3 = null;
                                    }
                                    else
                                    {
                                        det.idPlanCta_Sucursal_3 = ficha.IdCtaInv;
                                    }
                                    break;
                                case 4:
                                    if (ficha.IdCtaInv == -1)
                                    {
                                        det.idPlanCta_Sucursal_4 = null;
                                    }
                                    else
                                    {
                                        det.idPlanCta_Sucursal_4 = ficha.IdCtaInv;
                                    }
                                    break;
                                case 5:
                                    if (ficha.IdCtaInv == -1)
                                    {
                                        det.idPlanCta_Sucursal_5 = null;
                                    }
                                    else
                                    {
                                        det.idPlanCta_Sucursal_5 = ficha.IdCtaInv;
                                    }
                                    break;
                            }
                            ctx.SaveChanges();
                        }

                        if (ficha.IdCtaInv != -1)
                        {
                            var entRegl = new contabilidad_reglas_integracion_detalle()
                            {
                                idReglaIntegracion = 1,
                                idPlanCta = ficha.IdCtaInv,
                                signo = -1,
                                referencia = "COSTO DEPART",
                                idSucursal = ficha.IdSucursal,
                            };
                            ctx.contabilidad_reglas_integracion_detalle.Add(entRegl);
                            ctx.SaveChanges();

                            entRegl = new contabilidad_reglas_integracion_detalle()
                            {
                                idReglaIntegracion = 2,
                                idPlanCta = ficha.IdCtaInv,
                                signo = 1,
                                referencia = "COSTO DEPART",
                                idSucursal = ficha.IdSucursal,
                            };
                            ctx.contabilidad_reglas_integracion_detalle.Add(entRegl);
                            ctx.SaveChanges();

                            entRegl = new contabilidad_reglas_integracion_detalle()
                            {
                                idReglaIntegracion = 5,
                                idPlanCta = ficha.IdCtaInv,
                                signo = -1,
                                referencia = "DEPART AJUSTE",
                                idSucursal = ficha.IdSucursal,
                            };
                            ctx.contabilidad_reglas_integracion_detalle.Add(entRegl);
                            ctx.SaveChanges();

                            entRegl = new contabilidad_reglas_integracion_detalle()
                            {
                                idReglaIntegracion = 5,
                                idPlanCta = ficha.IdCtaInv,
                                signo = 1,
                                referencia = "INV",
                                idSucursal = ficha.IdSucursal,
                            };
                            ctx.contabilidad_reglas_integracion_detalle.Add(entRegl);
                            ctx.SaveChanges();
                        }
                        ///



                        ///
                        var det2 = ctx.contabilidad_departamentos.FirstOrDefault(d =>
                            d.auto_departamento == ficha.IdDepartamento &&
                            d.Concepto == (int)DTO.Empresa.Departamentos.Enumerados.Concepto.Costo);
                        if (det2 == null)
                        {
                            if (ficha.IdCtaCosto != -1)
                            {
                                det2 = new contabilidad_departamentos()
                                {
                                    auto_departamento = ficha.IdDepartamento,
                                    Concepto = (int)DTO.Empresa.Departamentos.Enumerados.Concepto.Costo,
                                };
                                switch (ficha.IdSucursal)
                                {
                                    case 1:
                                        det2.idPlanCta = ficha.IdCtaCosto;
                                        det2.idPlanCta_Sucursal_2 = null;
                                        det2.idPlanCta_Sucursal_3 = null;
                                        det2.idPlanCta_Sucursal_4 = null;
                                        det2.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 2:
                                        det2.idPlanCta = null;
                                        det2.idPlanCta_Sucursal_2 = ficha.IdCtaCosto;
                                        det2.idPlanCta_Sucursal_3 = null;
                                        det2.idPlanCta_Sucursal_4 = null;
                                        det2.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 3:
                                        det2.idPlanCta = null;
                                        det2.idPlanCta_Sucursal_2 = null;
                                        det2.idPlanCta_Sucursal_3 = ficha.IdCtaCosto;
                                        det2.idPlanCta_Sucursal_4 = null;
                                        det2.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 4:
                                        det2.idPlanCta = null;
                                        det2.idPlanCta_Sucursal_2 = null;
                                        det2.idPlanCta_Sucursal_3 = null;
                                        det2.idPlanCta_Sucursal_4 = ficha.IdCtaCosto;
                                        det2.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 5:
                                        det2.idPlanCta = null;
                                        det2.idPlanCta_Sucursal_2 = null;
                                        det2.idPlanCta_Sucursal_3 = null;
                                        det2.idPlanCta_Sucursal_4 = null;
                                        det2.idPlanCta_Sucursal_5 = ficha.IdCtaCosto;
                                        break;
                                }
                                ctx.contabilidad_departamentos.Add(det2);
                                ctx.SaveChanges();
                            }
                        }
                        else
                        {
                            int idcta = -1;
                            switch (ficha.IdSucursal)
                            {
                                case 1:
                                    if (det2.idPlanCta.HasValue)
                                    {
                                        idcta = det2.idPlanCta.Value;
                                    }
                                    break;
                                case 2:
                                    if (det2.idPlanCta_Sucursal_2.HasValue)
                                    {
                                        idcta = det2.idPlanCta_Sucursal_2.Value;
                                    }
                                    break;
                                case 3:
                                    if (det2.idPlanCta_Sucursal_3.HasValue)
                                    {
                                        idcta = det2.idPlanCta_Sucursal_3.Value;
                                    }
                                    break;
                                case 4:
                                    if (det2.idPlanCta_Sucursal_4.HasValue)
                                    {
                                        idcta = det2.idPlanCta_Sucursal_4.Value;
                                    }
                                    break;
                                case 5:
                                    if (det2.idPlanCta_Sucursal_5.HasValue)
                                    {
                                        idcta = det2.idPlanCta_Sucursal_5.Value;
                                    }
                                    break;
                            }

                            var entRegla = ctx.contabilidad_reglas_integracion_detalle.Where(r =>
                                (r.idReglaIntegracion == 1 || r.idReglaIntegracion == 5) &&
                                r.idPlanCta == idcta).ToList();
                            foreach (var n in entRegla)
                            {
                                ctx.contabilidad_reglas_integracion_detalle.Remove(n);
                                ctx.SaveChanges();
                            }

                            switch (ficha.IdSucursal)
                            {
                                case 1:
                                    if (ficha.IdCtaCosto  == -1)
                                    {
                                        det2.idPlanCta = null;
                                    }
                                    else
                                    {
                                        det2.idPlanCta = ficha.IdCtaCosto;
                                    }
                                    break;
                                case 2:
                                    if (ficha.IdCtaCosto == -1)
                                    {
                                        det2.idPlanCta_Sucursal_2 = null;
                                    }
                                    else
                                    {
                                        det2.idPlanCta_Sucursal_2 = ficha.IdCtaCosto;
                                    }
                                    break;
                                case 3:
                                    if (ficha.IdCtaCosto == -1)
                                    {
                                        det2.idPlanCta_Sucursal_3 = null;
                                    }
                                    else
                                    {
                                        det2.idPlanCta_Sucursal_3 = ficha.IdCtaCosto;
                                    }
                                    break;
                                case 4:
                                    if (ficha.IdCtaCosto == -1)
                                    {
                                        det2.idPlanCta_Sucursal_4 = null;
                                    }
                                    else
                                    {
                                        det2.idPlanCta_Sucursal_4 = ficha.IdCtaCosto;
                                    }
                                    break;
                                case 5:
                                    if (ficha.IdCtaCosto == -1)
                                    {
                                        det2.idPlanCta_Sucursal_5 = null;
                                    }
                                    else
                                    {
                                        det2.idPlanCta_Sucursal_5 = ficha.IdCtaCosto;
                                    }
                                    break;
                            }
                            ctx.SaveChanges();
                        }

                        if (ficha.IdCtaCosto != -1)
                        {
                            var entRegl = new contabilidad_reglas_integracion_detalle()
                            {
                                idReglaIntegracion = 1,
                                idPlanCta = ficha.IdCtaCosto,
                                signo = 1,
                                referencia = "COSTO DEPART",
                                idSucursal = ficha.IdSucursal,
                            };
                            ctx.contabilidad_reglas_integracion_detalle.Add(entRegl);
                            ctx.SaveChanges();

                            entRegl = new contabilidad_reglas_integracion_detalle()
                            {
                                idReglaIntegracion = 5,
                                idPlanCta = ficha.IdCtaCosto,
                                signo = -1,
                                referencia = "COST",
                                idSucursal = ficha.IdSucursal,
                            };
                            ctx.contabilidad_reglas_integracion_detalle.Add(entRegl);
                            ctx.SaveChanges();
                        }
                        ///



                        ///
                        var det3 = ctx.contabilidad_departamentos.FirstOrDefault(d =>
                            d.auto_departamento == ficha.IdDepartamento &&
                            d.Concepto == (int)DTO.Empresa.Departamentos.Enumerados.Concepto.Venta);
                        if (det3 == null)
                        {
                            if (ficha.IdCtaVenta != -1)
                            {
                                det3 = new contabilidad_departamentos()
                                {
                                    auto_departamento = ficha.IdDepartamento,
                                    Concepto = (int)DTO.Empresa.Departamentos.Enumerados.Concepto.Venta,
                                };
                                switch (ficha.IdSucursal)
                                {
                                    case 1:
                                        det3.idPlanCta = ficha.IdCtaVenta;
                                        det3.idPlanCta_Sucursal_2 = null;
                                        det3.idPlanCta_Sucursal_3 = null;
                                        det3.idPlanCta_Sucursal_4 = null;
                                        det3.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 2:
                                        det3.idPlanCta = null;
                                        det3.idPlanCta_Sucursal_2 = ficha.IdCtaVenta;
                                        det3.idPlanCta_Sucursal_3 = null;
                                        det3.idPlanCta_Sucursal_4 = null;
                                        det3.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 3:
                                        det3.idPlanCta = null;
                                        det3.idPlanCta_Sucursal_2 = null;
                                        det3.idPlanCta_Sucursal_3 = ficha.IdCtaVenta;
                                        det3.idPlanCta_Sucursal_4 = null;
                                        det3.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 4:
                                        det3.idPlanCta = null;
                                        det3.idPlanCta_Sucursal_2 = null;
                                        det3.idPlanCta_Sucursal_3 = null;
                                        det3.idPlanCta_Sucursal_4 = ficha.IdCtaVenta;
                                        det3.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 5:
                                        det3.idPlanCta = null;
                                        det3.idPlanCta_Sucursal_2 = null;
                                        det3.idPlanCta_Sucursal_3 = null;
                                        det3.idPlanCta_Sucursal_4 = null;
                                        det3.idPlanCta_Sucursal_5 = ficha.IdCtaVenta;
                                        break;
                                }
                                ctx.contabilidad_departamentos.Add(det3);
                                ctx.SaveChanges();
                            }
                        }
                        else
                        {
                            int idcta = -1;
                            switch (ficha.IdSucursal)
                            {
                                case 1:
                                    if (det3.idPlanCta.HasValue)
                                    {
                                        idcta = det3.idPlanCta.Value;
                                    }
                                    break;
                                case 2:
                                    if (det3.idPlanCta_Sucursal_2.HasValue)
                                    {
                                        idcta = det3.idPlanCta_Sucursal_2.Value;
                                    }
                                    break;
                                case 3:
                                    if (det3.idPlanCta_Sucursal_3.HasValue)
                                    {
                                        idcta = det3.idPlanCta_Sucursal_3.Value;
                                    }
                                    break;
                                case 4:
                                    if (det3.idPlanCta_Sucursal_4.HasValue)
                                    {
                                        idcta = det3.idPlanCta_Sucursal_4.Value;
                                    }
                                    break;
                                case 5:
                                    if (det3.idPlanCta_Sucursal_5.HasValue)
                                    {
                                        idcta = det3.idPlanCta_Sucursal_5.Value;
                                    }
                                    break;
                            }

                            var entRegla = ctx.contabilidad_reglas_integracion_detalle.Where(r =>
                                r.idReglaIntegracion == 1 &&
                                r.idPlanCta == idcta).ToList();
                            foreach (var n in entRegla)
                            {
                                ctx.contabilidad_reglas_integracion_detalle.Remove(n);
                                ctx.SaveChanges();
                            }

                            switch (ficha.IdSucursal)
                            {
                                case 1:
                                    if (ficha.IdCtaVenta == -1)
                                    {
                                        det3.idPlanCta = null;
                                    }
                                    else
                                    {
                                        det3.idPlanCta = ficha.IdCtaVenta;
                                    }
                                    break;
                                case 2:
                                    if (ficha.IdCtaVenta == -1)
                                    {
                                        det3.idPlanCta_Sucursal_2 = null;
                                    }
                                    else
                                    {
                                        det3.idPlanCta_Sucursal_2 = ficha.IdCtaVenta;
                                    }
                                    break;
                                case 3:
                                    if (ficha.IdCtaVenta == -1)
                                    {
                                        det3.idPlanCta_Sucursal_3 = null;
                                    }
                                    else
                                    {
                                        det3.idPlanCta_Sucursal_3 = ficha.IdCtaVenta;
                                    }
                                    break;
                                case 4:
                                    if (ficha.IdCtaVenta == -1)
                                    {
                                        det3.idPlanCta_Sucursal_4 = null;
                                    }
                                    else
                                    {
                                        det3.idPlanCta_Sucursal_4 = ficha.IdCtaVenta;
                                    }
                                    break;
                                case 5:
                                    if (ficha.IdCtaVenta == -1)
                                    {
                                        det3.idPlanCta_Sucursal_5 = null;
                                    }
                                    else
                                    {
                                        det3.idPlanCta_Sucursal_5 = ficha.IdCtaVenta;
                                    }
                                    break;
                            }
                            ctx.SaveChanges();
                        }
                        if (ficha.IdCtaVenta != -1)
                        {
                            var entRegl = new contabilidad_reglas_integracion_detalle()
                            {
                                idReglaIntegracion = 1,
                                idPlanCta = ficha.IdCtaVenta,
                                signo = -1,
                                referencia = "VENTA DEPART",
                                idSucursal = ficha.IdSucursal,
                            };
                            ctx.contabilidad_reglas_integracion_detalle.Add(entRegl);
                            ctx.SaveChanges();
                        }
                        ///




                        ///
                        var det4 = ctx.contabilidad_departamentos.FirstOrDefault(d =>
                            d.auto_departamento == ficha.IdDepartamento &&
                            d.Concepto == (int)DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste );
                        if (det4 == null)
                        {
                            if (ficha.IdCtaMerma != -1)
                            {
                                det4 = new contabilidad_departamentos()
                                {
                                    auto_departamento = ficha.IdDepartamento,
                                    Concepto = (int)DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste,
                                };
                                switch (ficha.IdSucursal)
                                {
                                    case 1:
                                        det4.idPlanCta = ficha.IdCtaMerma;
                                        det4.idPlanCta_Sucursal_2 = null;
                                        det4.idPlanCta_Sucursal_3 = null;
                                        det4.idPlanCta_Sucursal_4 = null;
                                        det4.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 2:
                                        det4.idPlanCta = null;
                                        det4.idPlanCta_Sucursal_2 = ficha.IdCtaMerma;
                                        det4.idPlanCta_Sucursal_3 = null;
                                        det4.idPlanCta_Sucursal_4 = null;
                                        det4.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 3:
                                        det4.idPlanCta = null;
                                        det4.idPlanCta_Sucursal_2 = null;
                                        det4.idPlanCta_Sucursal_3 = ficha.IdCtaMerma;
                                        det4.idPlanCta_Sucursal_4 = null;
                                        det4.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 4:
                                        det4.idPlanCta = null;
                                        det4.idPlanCta_Sucursal_2 = null;
                                        det4.idPlanCta_Sucursal_3 = null;
                                        det4.idPlanCta_Sucursal_4 = ficha.IdCtaMerma;
                                        det4.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 5:
                                        det4.idPlanCta = null;
                                        det4.idPlanCta_Sucursal_2 = null;
                                        det4.idPlanCta_Sucursal_3 = null;
                                        det4.idPlanCta_Sucursal_4 = null;
                                        det4.idPlanCta_Sucursal_5 = ficha.IdCtaMerma;
                                        break;
                                }
                                ctx.contabilidad_departamentos.Add(det4);
                                ctx.SaveChanges();
                            }
                        }
                        else
                        {
                            int idcta = -1;
                            switch (ficha.IdSucursal)
                            {
                                case 1:
                                    if (det4.idPlanCta.HasValue)
                                    {
                                        idcta = det4.idPlanCta.Value;
                                    }
                                    break;
                                case 2:
                                    if (det4.idPlanCta_Sucursal_2.HasValue)
                                    {
                                        idcta = det4.idPlanCta_Sucursal_2.Value;
                                    }
                                    break;
                                case 3:
                                    if (det4.idPlanCta_Sucursal_3.HasValue)
                                    {
                                        idcta = det4.idPlanCta_Sucursal_3.Value;
                                    }
                                    break;
                                case 4:
                                    if (det4.idPlanCta_Sucursal_4.HasValue)
                                    {
                                        idcta = det4.idPlanCta_Sucursal_4.Value;
                                    }
                                    break;
                                case 5:
                                    if (det4.idPlanCta_Sucursal_5.HasValue)
                                    {
                                        idcta = det4.idPlanCta_Sucursal_5.Value;
                                    }
                                    break;
                            }

                            var entRegla = ctx.contabilidad_reglas_integracion_detalle.Where(r =>
                                r.idReglaIntegracion == 5 &&
                                r.idPlanCta == idcta).ToList();
                            foreach (var n in entRegla)
                            {
                                ctx.contabilidad_reglas_integracion_detalle.Remove(n);
                                ctx.SaveChanges();
                            }

                            switch (ficha.IdSucursal)
                            {
                                case 1:
                                    if (ficha.IdCtaMerma == -1)
                                    {
                                        det4.idPlanCta = null;
                                    }
                                    else
                                    {
                                        det4.idPlanCta = ficha.IdCtaMerma;
                                    }
                                    break;
                                case 2:
                                    if (ficha.IdCtaMerma == -1)
                                    {
                                        det4.idPlanCta_Sucursal_2 = null;
                                    }
                                    else
                                    {
                                        det4.idPlanCta_Sucursal_2 = ficha.IdCtaMerma;
                                    }
                                    break;
                                case 3:
                                    if (ficha.IdCtaMerma == -1)
                                    {
                                        det4.idPlanCta_Sucursal_3 = null;
                                    }
                                    else
                                    {
                                        det4.idPlanCta_Sucursal_3 = ficha.IdCtaMerma;
                                    }
                                    break;
                                case 4:
                                    if (ficha.IdCtaMerma == -1)
                                    {
                                        det4.idPlanCta_Sucursal_4 = null;
                                    }
                                    else
                                    {
                                        det4.idPlanCta_Sucursal_4 = ficha.IdCtaMerma;
                                    }
                                    break;
                                case 5:
                                    if (ficha.IdCtaMerma == -1)
                                    {
                                        det4.idPlanCta_Sucursal_5 = null;
                                    }
                                    else
                                    {
                                        det4.idPlanCta_Sucursal_5 = ficha.IdCtaMerma;
                                    }
                                    break;
                            }
                            ctx.SaveChanges();
                        }
                        if (ficha.IdCtaMerma != -1)
                        {
                            var entRegl = new contabilidad_reglas_integracion_detalle()
                            {
                                idReglaIntegracion = 5,
                                idPlanCta = ficha.IdCtaMerma,
                                signo = 1,
                                referencia = "MONTO AJUSTE",
                                idSucursal = ficha.IdSucursal,
                            };
                            ctx.contabilidad_reglas_integracion_detalle.Add(entRegl);
                            ctx.SaveChanges();
                        }
                        ///



                        ///
                        var det5 = ctx.contabilidad_departamentos.FirstOrDefault(d =>
                            d.auto_departamento == ficha.IdDepartamento &&
                            d.Concepto == (int)DTO.Empresa.Departamentos.Enumerados.Concepto.ConsumoInterno);
                        if (det5 == null)
                        {
                            if (ficha.IdCtaConsumoInterno != -1)
                            {
                                det4 = new contabilidad_departamentos()
                                {
                                    auto_departamento = ficha.IdDepartamento,
                                    Concepto = (int)DTO.Empresa.Departamentos.Enumerados.Concepto.ConsumoInterno,
                                };
                                switch (ficha.IdSucursal)
                                {
                                    case 1:
                                        det.idPlanCta = ficha.IdCtaConsumoInterno;
                                        det.idPlanCta_Sucursal_2 = null;
                                        det.idPlanCta_Sucursal_3 = null;
                                        det.idPlanCta_Sucursal_4 = null;
                                        det.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 2:
                                        det.idPlanCta = null;
                                        det.idPlanCta_Sucursal_2 = ficha.IdCtaConsumoInterno;
                                        det.idPlanCta_Sucursal_3 = null;
                                        det.idPlanCta_Sucursal_4 = null;
                                        det.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 3:
                                        det.idPlanCta = null;
                                        det.idPlanCta_Sucursal_2 = null;
                                        det.idPlanCta_Sucursal_3 = ficha.IdCtaConsumoInterno;
                                        det.idPlanCta_Sucursal_4 = null;
                                        det.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 4:
                                        det.idPlanCta = null;
                                        det.idPlanCta_Sucursal_2 = null;
                                        det.idPlanCta_Sucursal_3 = null;
                                        det.idPlanCta_Sucursal_4 = ficha.IdCtaConsumoInterno;
                                        det.idPlanCta_Sucursal_5 = null;
                                        break;
                                    case 5:
                                        det.idPlanCta = null;
                                        det.idPlanCta_Sucursal_2 = null;
                                        det.idPlanCta_Sucursal_3 = null;
                                        det.idPlanCta_Sucursal_4 = null;
                                        det.idPlanCta_Sucursal_5 = ficha.IdCtaConsumoInterno;
                                        break;
                                }
                                ctx.contabilidad_departamentos.Add(det5);
                                ctx.SaveChanges();
                            }
                        }
                        else
                        {
                            int idcta = -1;
                            switch (ficha.IdSucursal)
                            {
                                case 1:
                                    if (det5.idPlanCta.HasValue)
                                    {
                                        idcta = det5.idPlanCta.Value;
                                    }
                                    break;
                                case 2:
                                    if (det5.idPlanCta_Sucursal_2.HasValue)
                                    {
                                        idcta = det5.idPlanCta_Sucursal_2.Value;
                                    }
                                    break;
                                case 3:
                                    if (det5.idPlanCta_Sucursal_3.HasValue)
                                    {
                                        idcta = det5.idPlanCta_Sucursal_3.Value;
                                    }
                                    break;
                                case 4:
                                    if (det5.idPlanCta_Sucursal_4.HasValue)
                                    {
                                        idcta = det5.idPlanCta_Sucursal_4.Value;
                                    }
                                    break;
                                case 5:
                                    if (det5.idPlanCta_Sucursal_5.HasValue)
                                    {
                                        idcta = det5.idPlanCta_Sucursal_5.Value;
                                    }
                                    break;
                            }

                            var entRegla = ctx.contabilidad_reglas_integracion_detalle.Where(r =>
                                r.idReglaIntegracion == 5 &&
                                r.idPlanCta == idcta).ToList();
                            foreach (var n in entRegla)
                            {
                                ctx.contabilidad_reglas_integracion_detalle.Remove(n);
                                ctx.SaveChanges();
                            }

                            switch (ficha.IdSucursal)
                            {
                                case 1:
                                    if (ficha.IdCtaConsumoInterno == -1)
                                    {
                                        det5.idPlanCta = null;
                                    }
                                    else
                                    {
                                        det5.idPlanCta = ficha.IdCtaConsumoInterno;
                                    }
                                    break;
                                case 2:
                                    if (ficha.IdCtaConsumoInterno == -1)
                                    {
                                        det5.idPlanCta_Sucursal_2 = null;
                                    }
                                    else
                                    {
                                        det5.idPlanCta_Sucursal_2 = ficha.IdCtaConsumoInterno;
                                    }
                                    break;
                                case 3:
                                    if (ficha.IdCtaConsumoInterno == -1)
                                    {
                                        det5.idPlanCta_Sucursal_3 = null;
                                    }
                                    else
                                    {
                                        det5.idPlanCta_Sucursal_3 = ficha.IdCtaConsumoInterno;
                                    }
                                    break;
                                case 4:
                                    if (ficha.IdCtaConsumoInterno == -1)
                                    {
                                        det5.idPlanCta_Sucursal_4 = null;
                                    }
                                    else
                                    {
                                        det5.idPlanCta_Sucursal_4 = ficha.IdCtaConsumoInterno;
                                    }
                                    break;
                                case 5:
                                    if (ficha.IdCtaConsumoInterno == -1)
                                    {
                                        det5.idPlanCta_Sucursal_5 = null;
                                    }
                                    else
                                    {
                                        det5.idPlanCta_Sucursal_5 = ficha.IdCtaConsumoInterno;
                                    }
                                    break;
                            }
                            ctx.SaveChanges();
                        }
                        if (ficha.IdCtaConsumoInterno != -1)
                        {
                            var entRegl = new contabilidad_reglas_integracion_detalle()
                            {
                                idReglaIntegracion = 5,
                                idPlanCta = ficha.IdCtaConsumoInterno,
                                signo = 1,
                                referencia = "MONTO",
                                idSucursal = ficha.IdSucursal,
                            };
                            ctx.contabilidad_reglas_integracion_detalle.Add(entRegl);
                            ctx.SaveChanges();
                        }
                        ///

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

        public Resultado Empresa_Departamento_VerificaActualizar(DTO.Empresa.Departamentos.Actualizar ficha)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var det = ctx.empresa_departamentos.Find(ficha.IdDepartamento );
                    if (det == null)
                    {
                        return new Resultado()
                        {
                            Mensaje = "[ ID ] DEPARTAMENTO NO ENCONTRADO",
                            Result = EnumResult.isError,
                        };
                    }

                    var det1 = ctx.contabilidad_plancta.Find(ficha.IdCtaInv);
                    if (det1 == null)
                    {
                        return new Resultado()
                        {
                            Mensaje = "[ ID ] PLAN DE CUENTA [ INVENTARIO ] NO ENCONTRADO",
                            Result = EnumResult.isError,
                        };
                    }

                    var det2 = ctx.contabilidad_plancta.Find(ficha.IdCtaCosto);
                    if (det2 == null)
                    {
                        return new Resultado()
                        {
                            Mensaje = "[ ID ] PLAN DE CUENTA [ COSTO ] NO ENCONTRADO",
                            Result = EnumResult.isError,
                        };
                    }

                    var det3 = ctx.contabilidad_plancta.Find(ficha.IdCtaVenta );
                    if (det3 == null)
                    {
                        return new Resultado()
                        {
                            Mensaje = "[ ID ] PLAN DE CUENTA [ VENTA ] NO ENCONTRADO",
                            Result = EnumResult.isError,
                        };
                    }

                    var det4 = ctx.contabilidad_plancta.Find(ficha.IdCtaMerma);
                    if (det4 == null)
                    {
                        return new Resultado()
                        {
                            Mensaje = "[ ID ] PLAN DE CUENTA [ MERMA ] NO ENCONTRADO",
                            Result = EnumResult.isError,
                        };
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


        //SERIES FISCALES
        public ResultadoLista<DTO.Empresa.SerialesFiscales.Ficha> Empresa_SerialesFiscales_Lista()
        {
            var result = new ResultadoLista<DTO.Empresa.SerialesFiscales.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.empresa_series_fiscales.
                        GroupBy(g => new { g.control }).
                        Select(s => new { descripcion = s.Key.control }).
                        ToList();

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.Empresa.SerialesFiscales.Ficha()
                            {
                                Descripcion = d.descripcion
                            };
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


        //DATOS DEL NEGOCIO
        public ResultadoEntidad<DTO.Empresa.Empresa.Ficha> Empresa_DatosNegocio()
        {
            var result = new ResultadoEntidad<DTO.Empresa.Empresa.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.empresa.FirstOrDefault(); 
                    if (ent == null)
                    {
                        result.Mensaje = "DATOS DEL NEGOCIO NO DEFINIDA";
                        result.Result = EnumResult.isError;
                        return result;
                    }

                    var r = new DTO.Empresa.Empresa.Ficha()
                    {
                         Rif = ent.rif,
                         NombreRazonSocial=ent.nombre,
                         DireccionFiscal=ent.direccion
                    };

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


        //COBRADORES
        public ResultadoLista<DTO.Empresa.Cobradores.Resumen> Empresa_Cobradores_Lista()
        {
            var result = new ResultadoLista<DTO.Empresa.Cobradores.Resumen >();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.empresa_cobradores.
                        ToList();

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.Empresa.Cobradores.Resumen ()
                            {
                                IdAuto=d.auto ,
                                Codigo=d.codigo,
                                Nombre=d.nombre,
                            };
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


        //MEDIOS DE PAGO
        public ResultadoLista<DTO.Empresa.MediosPago.Resumen> Empresa_Mediospago_Lista()
        {
            var result = new ResultadoLista<DTO.Empresa.MediosPago.Resumen>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.empresa_medios.
                        Where(w=>w.estatus_cobro=="1").
                        ToList();

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.Empresa.MediosPago.Resumen()
                            {
                                IdAuto = d.auto,
                                Codigo = d.codigo,
                                Nombre = d.nombre,
                            };
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