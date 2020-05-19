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

        public ResultadoEntidad<DTO.Compras.Compra.Ficha> Compras_Compra_GetById(string autoDoc)
        {
            var result = new ResultadoEntidad<DTO.Compras.Compra.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.compras.Find(autoDoc);
                    if (ent == null)
                    {
                        result.Mensaje = "DOCUMENTO NO ENCONTRADO";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var entDet = ctx.compras_detalle.Where(d => d.auto_documento == autoDoc).ToList();

                    var tipo = DTO.Compras.Enumerados.TipoDocumento.SinDefinir ;
                    switch (ent.tipo.Trim().ToUpper())
                    {
                        case "01":
                            tipo = DTO.Compras.Enumerados.TipoDocumento.Factura ;
                            break;
                        case "02":
                            tipo = DTO.Compras.Enumerados.TipoDocumento.NDebito ;
                            break;
                        case "03":
                            tipo = DTO.Compras.Enumerados.TipoDocumento.NCredito ;
                            break;
                    }

                    var doc = new DTO.Compras.Compra.Ficha()
                    {
                        Id=ent.auto,
                        FechaEmision = ent.fecha,
                        FechaRegistro = ent.fecha_registro,
                        Hora = ent.hora,
                        DocumentoNro = ent.documento,
                        ControlNro=ent.control,
                        CodigoProveedor=ent.codigo_proveedor,
                        Proveedor = ent.razon_social,
                        CiRif = ent.ci_rif,
                        DireccionFiscal = ent.dir_fiscal,
                        Telefono = ent.telefono,
                        TipoDoc = tipo,
                        Usuario = ent.usuario,
                        Estacion = ent.estacion,
                        Decuento = ent.descuento1 +ent.descuento2 ,
                        Cargo=ent.cargos,
                        SubTotal_01 = ent.subtotal_neto,
                        MontoExento = ent.exento,
                        MontoBase = ent.mbase,
                        SubTotal_02 = ent.neto,
                        Impuesto = ent.impuesto,
                        Total = ent.total,
                        Renglones = ent.renglones,
                        MesRelacion=int.Parse(ent.mes_relacion),
                        AnoRelacion=int.Parse(ent.ano_relacion),
                        Notas=ent.nota,
                        CodigoSucursal=ent.codigo_sucursal,
                    };

                    if (ent.auto_concepto != "") 
                    {
                        var entConcepto = ctx.bancos_movimientos_conceptos.Find(ent.auto_concepto);
                        if (entConcepto != null) 
                        {
                            doc.Concepto = entConcepto.nombre;
                        }
                    }

                    if (entDet.Count() > 0)
                    {
                        var det = entDet.Select((d) =>
                        {
                            return new DTO.Compras.Compra.Detalle()
                            {
                                Cantidad = d.cantidad,
                                Descripcion = d.nombre,
                                Empaque=d.empaque,
                                Contenido=d.contenido_empaque,
                                Precio =d.costo_und,
                                Importe = d.total_neto,
                                Impuesto = d.impuesto,
                                TasaIva = d.tasa,
                                Total = d.total,
                                DepartamentoDesc=d.empresa_departamentos.nombre,
                            };
                        }).ToList();
                        doc.Detalles = det;
                    }

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

        public ResultadoEntidad<DTO.Compras.RetencionIva.Ficha> Compras_RetencionIva_GetById(string autoDoc)
        {
            var result = new ResultadoEntidad<DTO.Compras.RetencionIva.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.compras_retenciones.Find(autoDoc);
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] DOCUMENTO RETENCION IVA NO ENCONTRADO";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var entDet = ctx.compras_retenciones_detalle.Where(d => d.auto == autoDoc).ToList();
                    var doc = new DTO.Compras.RetencionIva.Ficha()
                    {
                        FechaEmision = ent.fecha,
                        FechaProceso=ent.fecha_relacion ,
                        DocumentoNro = ent.documento,
                        ProvCodigo=ent.codigo_proveedor,
                        ProvNombreRazonSocial=ent.razon_social,
                        ProvCiRif=ent.ci_rif,
                        ProvDireccionFiscal=ent.dir_fiscal,
                        ProvTelefono="",
                        MontoExento = ent.exento,
                        MontoBase = ent.mbase,
                        MontoImpuesto=ent.impuesto,
                        Total = ent.total,
                        TasaRetencion=ent.tasa_retencion,
                        MontoRetencion=ent.retencion,
                        Renglones = ent.renglones,
                        MesRelacion = int.Parse(ent.mes_relacion),
                        AnoRelacion = int.Parse(ent.ano_relacion),
                    };

                    if (entDet.Count() > 0)
                    {
                        var det = entDet.Select((d) =>
                        {
                            var tipo =DTO.Compras.Enumerados.TipoDocumento.SinDefinir;
                            switch (d.tipo.Trim().ToUpper())
                            {
                                case "01":
                                    tipo = DTO.Compras.Enumerados.TipoDocumento.Factura;
                                    break;
                                case "02":
                                    tipo = DTO.Compras.Enumerados.TipoDocumento.NDebito;
                                    break;
                                case "03":
                                    tipo = DTO.Compras.Enumerados.TipoDocumento.NCredito;
                                    break;
                            }

                            return new DTO.Compras.RetencionIva.Detalle()
                            {
                                DocumentoNro=d.documento,
                                ControlNro=d.control,
                                TipoDocumento=tipo,
                                Fecha=d.fecha,
                                Aplica=d.aplica,
                                Exento=d.exento,
                                Base=d.mbase,
                                Impuesto=d.impuesto,
                                Total=d.total,
                                Retencion=d.retencion,
                                Signo=d.signo
                            };
                        }).ToList();
                        doc.Detalles = det;
                    }

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

        public ResultadoEntidad<DTO.Compras.RetencionIslr.Ficha> Compras_RetencionIslr_GetById(string autoDoc)
        {
            var result = new ResultadoEntidad<DTO.Compras.RetencionIslr.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.compras_retenciones.Find(autoDoc);
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] DOCUMENTO RETENCION ISLR NO ENCONTRADO";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var entDet = ctx.compras_retenciones_detalle.Where(d => d.auto == autoDoc).ToList();
                    var doc = new DTO.Compras.RetencionIslr.Ficha()
                    {
                        FechaEmision = ent.fecha,
                        FechaProceso = ent.fecha_relacion,
                        DocumentoNro = ent.documento,
                        ProvCodigo = ent.codigo_proveedor,
                        ProvNombreRazonSocial = ent.razon_social,
                        ProvCiRif = ent.ci_rif,
                        ProvDireccionFiscal = ent.dir_fiscal,
                        ProvTelefono = "",
                        MontoExento = ent.exento,
                        MontoBase = ent.mbase,
                        MontoImpuesto = ent.impuesto,
                        Total = ent.total,
                        TasaRetencion = ent.tasa_retencion,
                        MontoRetencion = ent.retencion,
                        Renglones = ent.renglones,
                        MesRelacion = int.Parse(ent.mes_relacion),
                        AnoRelacion = int.Parse(ent.ano_relacion),
                    };

                    if (entDet.Count() > 0)
                    {
                        var det = entDet.Select((d) =>
                        {
                            var tipo =DTO.Compras.Enumerados.TipoDocumento.SinDefinir;
                            switch (d.tipo.Trim().ToUpper())
                            {
                                case "01":
                                    tipo = DTO.Compras.Enumerados.TipoDocumento.Factura;
                                    break;
                                case "02":
                                    tipo = DTO.Compras.Enumerados.TipoDocumento.NDebito;
                                    break;
                                case "03":
                                    tipo = DTO.Compras.Enumerados.TipoDocumento.NCredito;
                                    break;
                            }

                            return new DTO.Compras.RetencionIslr.Detalle()
                            {
                                DocumentoNro = d.documento,
                                ControlNro = d.control,
                                TipoDocumento = tipo,
                                Fecha = d.fecha,
                                Aplica = d.aplica,
                                Exento = d.exento,
                                Base = d.mbase,
                                Impuesto = d.impuesto,
                                Total = d.total,
                                Retencion = d.retencion,
                                Signo = d.signo
                            };
                        }).ToList();
                        doc.Detalles = det;
                    }

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

        public Resultado Compras_Compra_ActualizarData(DTO.Compras.Compra.ActualizarData ficha)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = ctx.compras.Find(ficha.AutoDocumento);
                        if (ent == null)
                        {
                            result.Mensaje = "[ ID ] DOCUMENTO NO ENCONTRADO";
                            result.Result = DTO.EnumResult.isError;
                            return result;
                        }

                        ent.auto_concepto = ficha.AutoCalificativo ;
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