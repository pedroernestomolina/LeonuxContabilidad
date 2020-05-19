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

        public ResultadoEntidad<DTO.Contable.PlanCta.Ficha> Contable_PlanCta_GetById(int id)
        {
            var result = new ResultadoEntidad<DTO.Contable.PlanCta.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_plancta.FirstOrDefault(d => (d.id == id));
                    if (q == null)
                    {
                        result.Mensaje = "ID CUENTA NO ENCONTRADA";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var _naturaleza = q.naturaleza == "D" ? DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora : DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora ;
                    var _estadosituacion = q.estado == "1" ? DTO.Contable.PlanCta.Enumerados.EstadoSituacion.Financiero : DTO.Contable.PlanCta.Enumerados.EstadoSituacion.Resultados ;
                    var _tipo = q.tipo == "1" ? DTO.Contable.PlanCta.Enumerados.Tipo.Auxiliar : DTO.Contable.PlanCta.Enumerados.Tipo.Totalizadora;
                    var r = new DTO.Contable.PlanCta.Ficha ()
                    {
                        Id = q.id ,
                        Codigo = q.codigo,
                        Nombre = q.descripcion ,
                        Tipo = _tipo, 
                        Naturaleza= _naturaleza,
                        Estado  = _estadosituacion,
                        SaldoActual = new DTO.Contable.PlanCta.Saldos() 
                        { 
                            Debe = q.debe, 
                            Haber = q.haber, 
                            SaldoAnterior = q.saldoAnterior
                        }
                    };

                    result.Entidad = r;
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

        public ResultadoLista<DTO.Contable.PlanCta.FichaResumen> Contable_PlanCta_Lista(DTO.Contable.PlanCta.Busqueda busq)
        {
            var result = new ResultadoLista<DTO.Contable.PlanCta.FichaResumen>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_plancta.ToList();
                    if (busq.Cadena != "")
                    {
                        q = q.Where(d =>
                            (d.codigo.Trim().ToUpper().Length >= busq.Cadena.Length) ).ToList();
                        q = q.Where(d =>
                        {
                            var l = busq.Cadena.Trim().Length;
                            var buscar = busq.Cadena.Trim().ToUpper();
                            var codigo = d.codigo.Trim().ToUpper();
                            var r = codigo.Substring(0, l) == buscar;
                            return (r);
                        }).ToList();

                        if (q.Count() == 0) 
                        {
                            q = ctx.contabilidad_plancta.Where(d => d.descripcion.Trim().ToUpper().Contains(busq.Cadena)).ToList();
                        }
                    }

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.Contable.PlanCta.FichaResumen()
                            {
                                Id = d.id,
                                Codigo = d.codigo,
                                Nombre = d.descripcion,
                                Tipo = d.tipo == "1" ? DTO.Contable.PlanCta.Enumerados.Tipo.Auxiliar : DTO.Contable.PlanCta.Enumerados.Tipo.Totalizadora,
                                Naturaleza = d.naturaleza == "D" ? DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora : DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora,
                                Estado = d.estado == "1" ? DTO.Contable.PlanCta.Enumerados.EstadoSituacion.Financiero : DTO.Contable.PlanCta.Enumerados.EstadoSituacion.Resultados ,
                                MontoDebe= d.debe,
                                MontoHaber= d.haber ,
                                SaldoAnterior=d.saldoAnterior,
                                SaldoApertura=d.saldoApertura,
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

        public ResultadoId Contable_PlanCta_Insertar(DTO.Contable.PlanCta.Insertar insertar)
        {
            var result = new ResultadoId();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var naturaleza = insertar.Naturaleza == DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora  ? "D" : "A";
                        var estado = insertar.Estado  == DTO.Contable.PlanCta.Enumerados.EstadoSituacion.Financiero ? "1" : "2";
                        var tipo = insertar.Tipo == DTO.Contable.PlanCta.Enumerados.Tipo.Auxiliar ? "1" : "2";

                        var ent = new contabilidad_plancta ()
                        {
                            codigo = insertar.Codigo,
                            descripcion = insertar.Nombre,
                            naturaleza = naturaleza,
                            tipo = tipo,
                            estado=estado,
                            nivel=insertar.Nivel,
                        };
                        if (insertar.IdCtaPadre == -1)
                        {
                            ent.idPadre = null;
                        }
                        else
                        {
                            ent.idPadre = insertar.IdCtaPadre;
                        }
                        ctx.contabilidad_plancta.Add(ent);

                        ctx.SaveChanges();
                        ts.Complete();
                        result.Id = ent.id;
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Id = -1;
            }

            return result;
        }

        public Resultado Contable_PlanCta_Editar(DTO.Contable.PlanCta.Editar editar)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var naturaleza = editar.Naturaleza == DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora  ? "D" : "A";
                        var estado = editar.Estado  == DTO.Contable.PlanCta.Enumerados.EstadoSituacion .Financiero ? "1" : "2";
                        var tipo = editar.Tipo == DTO.Contable.PlanCta.Enumerados.Tipo.Auxiliar ? "1" : "2";

                        var ent = ctx.contabilidad_plancta.Find(editar.Id);
                        if (ent == null)
                        {
                            result.Mensaje = "[ ID ] CUENTA NO ENCONTRADO";
                            result.Result = DTO.EnumResult.isError;
                            return result;
                        }

                        ent.descripcion = editar.Nombre;
                        ent.naturaleza = naturaleza;
                        ent.estado = estado;
                        ent.tipo = tipo;

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

        public Resultado Contable_PlanCta_Eliminar(int id)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.contabilidad_plancta.Find(id);
                    ctx.contabilidad_plancta.Remove(ent);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public Resultado Contable_PlanCta_VerificarInsertar(string codigoCta)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.contabilidad_plancta.FirstOrDefault(d => d.codigo == codigoCta);
                    if (ent != null)
                    {
                        result.Mensaje = "CODIGO CUENTA YA REGISTRADO";
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }

                    int x = 0;
                    if (codigoCta.Length > 1)
                    {
                        switch (codigoCta.Length)
                        {

                            //case 3:
                            //    x = 1;
                            //    break;
                            //case 6:
                            //    x = 3;
                            //    break;
                            //case 9:
                            //    x = 6;
                            //    break;
                            //case 13:
                            //    x = 9;
                            //    break;


                            case 3:
                                x = 1;
                                break;
                            case 5:
                                x = 3;
                                break;
                            case 8:
                                x = 5;
                                break;
                            case 11:
                                x = 8;
                                break;
                            case 15:
                                x = 11;
                                break;

                        }
                        var subCodigo = codigoCta.Substring(0, x);
                        var entPadre = ctx.contabilidad_plancta.FirstOrDefault(d => d.codigo == subCodigo);
                        if (entPadre == null)
                        {
                            result.Mensaje = "CODIGO PADRE CUENTA NO REGISTRADO";
                            result.Result = DTO.EnumResult.isError;
                            return result;
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

        public Resultado Contable_PlanCta_VerificarEliminar(int id)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.contabilidad_plancta.FirstOrDefault(d => d.id == id);
                    if (ent == null)
                    {
                        result.Mensaje = "ID CUENTA NO REGISTRADO";
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }

                    int x = ent.codigo.Length;
                    if (ctx.contabilidad_plancta.Count(d => d.codigo.Substring(0, x) == ent.codigo) > 1)
                    {
                        result.Mensaje = "CODIGO CUENTA NO PUEDE SER ELIMINADO. HAY CUENTAS QUE DEPENDEN DE ESTA";
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }

                    var entMov = ctx.contabilidad_asiento_detalle.FirstOrDefault(d => d.idPlanCta == id);
                    if (entMov != null) 
                    {
                        result.Mensaje = "CODIGO CUENTA NO PUEDE SER ELIMINADO. HAY MOVIMIENTOS";
                        result.Result = DTO.EnumResult.isError;
                        return result;
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

        public ResultadoEntidad<DTO.Contable.PlanCta.Padre> Contable_PlanCta_GetPadre(string codigoCta)
        {
            var result = new ResultadoEntidad<DTO.Contable.PlanCta.Padre>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    int x = 0;
                    var nivel=1;
                    var padre = new DTO.Contable.PlanCta.Padre() {  Id =-1, Nivel=nivel };

                    if (codigoCta.Length > 1)
                    {
                        switch (codigoCta.Length)
                        {
                            case 3:
                                x = 1;
                                nivel = 2;
                                break;
                            case 5:
                                x = 3;
                                nivel = 3;
                                break;
                            case 8:
                                x = 5;
                                nivel = 4;
                                break;
                            case 11:
                                x = 8;
                                nivel = 5;
                                break;
                            case 15:
                                x = 11;
                                nivel = 6;
                                break;
                        }
                        var subCodigo = codigoCta.Substring(0, x);
                        var entPadre = ctx.contabilidad_plancta.FirstOrDefault(d => d.codigo == subCodigo);
                        if (entPadre == null)
                        {
                            result.Mensaje = "CODIGO PADRE CUENTA NO REGISTRADO";
                            result.Result = DTO.EnumResult.isError;
                            return result;
                        }
                        padre.Id = entPadre.id;
                        padre.Nivel =nivel;
                    }

                    result.Entidad = padre;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public Resultado Contable_PlanCta_AsignarCtaPadre(int idCta, int idPadre, int nivel)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = ctx.contabilidad_plancta.Find(idCta );
                        if (ent == null)
                        {
                            result.Mensaje = "[ ID ] CUENTA NO ENCONTRADO";
                            result.Result = DTO.EnumResult.isError;
                            return result;
                        }

                        if (idPadre == -1)
                        {
                            ent.idPadre = null;
                            ent.nivel = 1;
                        }
                        else
                        {
                            ent.idPadre = idPadre;
                            ent.nivel = nivel;
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

    }

}