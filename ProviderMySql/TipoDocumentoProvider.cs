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

        public DTO.ResultadoLista<DTO.Contable.TipoDocumento.Ficha> Contable_TipoDocumento_Lista()
        {
            ResultadoLista<DTO.Contable.TipoDocumento.Ficha> result = new ResultadoLista<DTO.Contable.TipoDocumento.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_tipo_documento.ToList();
                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.Contable.TipoDocumento.Ficha()
                            {
                                Id = d.id,
                                Descripcion=d.descripcion
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

        public ResultadoId Contable_TipoDocumento_Insertar(DTO.Contable.TipoDocumento.Insertar ficha)
        {
            var result = new ResultadoId();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = new contabilidad_tipo_documento()
                        {
                            descripcion = ficha.Descripcion ,
                        };
                        ctx.contabilidad_tipo_documento.Add(ent);

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

        public Resultado Contable_TipoDocumento_Editar(DTO.Contable.TipoDocumento.Editar ficha)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = ctx.contabilidad_tipo_documento.Find(ficha.Id);
                        if (ent == null)
                        {
                            result.Mensaje = "[ ID ] DOCUMENTO NO ENCONTRADO";
                            result.Result = DTO.EnumResult.isError;
                            return result;
                        }

                        ent.descripcion = ficha.Descripcion ;
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

        public Resultado Contable_TipoDocumento_Eliminar(DTO.Contable.TipoDocumento.Eliminar ficha)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.contabilidad_tipo_documento.Find (ficha.Id);
                    ctx.contabilidad_tipo_documento.Remove(ent);
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

        public ResultadoEntidad<DTO.Contable.TipoDocumento.Ficha> Contable_TipoDocumento_Get(int id)
        {
            var result = new ResultadoEntidad<DTO.Contable.TipoDocumento.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_tipo_documento.Find(id);
                    if (q == null)
                    {
                        result.Mensaje = "[ ID ] DOCUMENTO NO ENCONTRADO";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var r = new DTO.Contable.TipoDocumento.Ficha()
                    {
                        Id = q.id,
                        Descripcion = q.descripcion,
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

        public Resultado Contable_TipoDocumento_VerificarEliminar(int id)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.contabilidad_tipo_documento.Find(id);
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] DOCUMENTO NO REGISTRADO";
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }

                    var ct = ctx.contabilidad_asiento.FirstOrDefault(d => d.idTipoDocumento == id);
                    if (ct != null )
                    {
                        result.Mensaje = "TIPO DE DOCUMENTO NO PUEDE SER ELIMINADO";
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

    }

}