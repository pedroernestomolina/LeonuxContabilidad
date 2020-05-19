using DTO;
using EntityMySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProviderMySql
{

    public partial class Provider : IProvider.InfraEstructura
    {

        public DTO.ResultadoEntidad<DTO.Venta.Ficha> Venta_GetById(string autoDoc)
        {
            var result = new ResultadoEntidad<DTO.Venta.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.ventas.Find(autoDoc);
                    if (ent == null)
                    {
                        result.Mensaje = "DOCUMENTO NO ENCONTRADO";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var entDet = ctx.ventas_detalle.Where(d => d.auto_documento == autoDoc).ToList();
                    var entPag = ctx.cxc_medio_pago.Where(d => d.auto_recibo == ent.auto_recibo).ToList();

                    DTO.Venta.Enumerados.TipoDocumento tipo = DTO.Venta.Enumerados.TipoDocumento.Factura;
                    switch (ent.tipo.Trim().ToUpper())
                    {
                        case "01":
                            tipo = DTO.Venta.Enumerados.TipoDocumento.Factura;
                            break;
                        case "02":
                            tipo = DTO.Venta.Enumerados.TipoDocumento.NDebito;
                            break;
                        case "03":
                            tipo = DTO.Venta.Enumerados.TipoDocumento.NCredito;
                            entPag = null;
                            break;
                    }

                    var doc = new DTO.Venta.Ficha()
                    {
                        Id = ent.auto,
                        FechaEmision = ent.fecha,
                        Hora = ent.hora,
                        CondicionPago = ent.condicion_pago.Trim().ToUpper() == "CONTADO" ? DTO.Venta.Enumerados.CondicionPago.Contado : DTO.Venta.Enumerados.CondicionPago.Credito,
                        DocumentoNro = ent.documento,
                        serialFiscal = ent.control,
                        RazonSocial = ent.razon_social,
                        CiRif = ent.ci_rif,
                        DireccionFiscal = ent.dir_fiscal,
                        Telefono = ent.telefono,
                        TipoDoc = tipo,
                        Usuario = ent.usuario,
                        Estacion = ent.estacion,
                        Decuento = 0,
                        SubTotal_01 = 0,
                        MontoExento = ent.exento,
                        MontoBase = ent.mbase,
                        SubTotal_02 = ent.subtotal_neto,
                        Impuesto = ent.impuesto,
                        Total = ent.total,
                        Renglones = ent.renglones,
                        TasaIva_1 = ent.tasa1,
                        TasaIva_2 = ent.tasa2,
                        TasaIva_3 = ent.tasa3,
                        CodigoSucursal=ent.codigo_sucursal,
                    };

                    if (entDet.Count() > 0)
                    {
                        var det = entDet.Select((d) =>
                        {
                            return new DTO.Venta.FichaDetalle()
                            {
                                Cantidad = d.cantidad,
                                Descripcion = d.nombre,
                                Precio = d.precio_neto,
                                Importe = d.total_neto,
                                Impuesto = d.impuesto,
                                TasaIva = d.tasa,
                                Total = d.total,
                                Departamento= d.empresa_departamentos.nombre,  
                            };
                        }).ToList();
                        doc.Detalles = det;
                    }

                    if (entPag != null)
                    {
                        if (entPag.Count > 0)
                        {
                            var list = entPag.Select(d =>
                            {
                                return new DTO.Venta.Pago
                                {
                                    Codigo = d.codigo,
                                    Descripcion = d.medio,
                                    Monto = d.monto_recibido,
                                    Lote = d.lote,
                                    Referencia = d.referencia
                                };
                            }).ToList();
                            doc.Pagos = list;
                        }
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

        public ResultadoEntidad<bool> Venta_Documento_Existe(string autoDoc)
        {
            var result = new ResultadoEntidad<bool>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.ventas.Find(autoDoc);
                    if (ent == null)
                    {
                        result.Entidad = false;
                    }
                    else
                    {
                        result.Entidad = true;
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Entidad = false;
            }

            return result;
        }

        public ResultadoEntidad<bool> Venta_Documento_Aplico_RetencionIva(string autoDoc)
        {
            var result = new ResultadoEntidad<bool>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.ventas_retenciones_detalle.FirstOrDefault(d => d.auto_documento == autoDoc);
                    if (ent == null)
                    {
                        result.Entidad = false;
                    }
                    else
                    {
                        result.Entidad = true;
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Entidad = false;
            }

            return result;
        }

        public ResultadoEntidad<bool> Venta_Documento_Aplico_RetencionIva_BuscaPorNumeroDocVenta(string numDocVenta)
        {
            var result = new ResultadoEntidad<bool>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.ventas_retenciones_detalle.FirstOrDefault(d => d.documento == numDocVenta);
                    if (ent == null)
                    {
                        result.Entidad = false;
                    }
                    else
                    {
                        result.Entidad = true;
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Entidad = false;
            }

            return result;
        }

    }

}