using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.ResultadoEntidad<OOB.Venta.Ficha> Venta_GetById(string autoDoc)
        {
            var result = new OOB.Resultado.ResultadoEntidad<OOB.Venta.Ficha>();

            var resultDTO = _servicio.Venta_GetById(autoDoc);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            var doc = new OOB.Venta.Ficha()
            {
                Id = resultDTO.Entidad.Id,
                FechaEmision = resultDTO.Entidad.FechaEmision,
                Hora = resultDTO.Entidad.Hora,
                CondicionPago = (OOB.Venta.Enumerados.CondicionPago)resultDTO.Entidad.CondicionPago,
                DocumentoNro = resultDTO.Entidad.DocumentoNro,
                serialFiscal = resultDTO.Entidad.serialFiscal,
                RazonSocial = resultDTO.Entidad.RazonSocial,
                CiRif = resultDTO.Entidad.CiRif,
                DireccionFiscal = resultDTO.Entidad.DireccionFiscal,
                Telefono = resultDTO.Entidad.Telefono,
                TipoDoc = (OOB.Venta.Enumerados.TipoDocumento)resultDTO.Entidad.TipoDoc,
                Usuario = resultDTO.Entidad.Usuario,
                Estacion = resultDTO.Entidad.Estacion,
                Decuento = resultDTO.Entidad.Decuento,
                SubTotal_01 = resultDTO.Entidad.SubTotal_01,
                MontoExento = resultDTO.Entidad.MontoExento,
                MontoBase = resultDTO.Entidad.MontoBase,
                SubTotal_02 = resultDTO.Entidad.SubTotal_02,
                Impuesto = resultDTO.Entidad.Impuesto,
                Total = resultDTO.Entidad.Total,
                Renglones = resultDTO.Entidad.Renglones,
                TasaIva_1 = resultDTO.Entidad.TasaIva_1 ,
                TasaIva_2 = resultDTO.Entidad.TasaIva_2,
                TasaIva_3 = resultDTO.Entidad.TasaIva_3,
            };

            if (resultDTO.Entidad.Detalles != null)
            {
                var det = resultDTO.Entidad.Detalles.Select((d) =>
                {
                    return new OOB.Venta.FichaDetalle()
                    {
                        Cantidad = d.Cantidad,
                        Descripcion = d.Descripcion,
                        Precio = d.Precio,
                        Importe = d.Importe,
                        Impuesto = d.Impuesto,
                        TasaIva = d.TasaIva,
                        Total = d.Total
                    };
                }).ToList();
                doc.Detalles = det;
            }

            if (resultDTO.Entidad.Pagos != null)
            {
                var pag = resultDTO.Entidad.Pagos.Select((d) =>
                {
                    return new OOB.Venta.Pago()
                    {
                        Codigo = d.Codigo,
                        Descripcion = d.Descripcion,
                        Monto = d.Monto,
                        Lote = d.Lote,
                        Referencia = d.Referencia
                    };
                }).ToList();
                doc.Pagos = pag;
            }
            else
            {
                doc.Pagos = new List<OOB.Venta.Pago>();
            }

            result.Entidad = doc;
            return result;
        }

        public OOB.Resultado.ResultadoEntidad<bool> Venta_Documento_Existe(string autoDoc)
        {
            var result = new OOB.Resultado.ResultadoEntidad<bool>();

            var resultDTO = _servicio.Venta_Documento_Existe (autoDoc);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            result.Entidad = resultDTO.Entidad;
            return result;
        }

        public OOB.Resultado.ResultadoEntidad<bool> Venta_Documento_Aplico_RetencionIva(string autoDoc,string numDocVenta="")
        {
            var result = new OOB.Resultado.ResultadoEntidad<bool>();

            if (autoDoc!="")
            {
                var resultDTO = _servicio.Venta_Documento_Aplico_RetencionIva(autoDoc);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    result.Result = OOB.Resultado.EnumResult.isError;
                    result.Mensaje = resultDTO.Mensaje;
                    return result;
                }

                result.Entidad = resultDTO.Entidad;
            }
            else 
            {
                var resultDTO = _servicio.Venta_Documento_Aplico_RetencionIva_BuscaPorNumeroDocVenta(numDocVenta);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    result.Result = OOB.Resultado.EnumResult.isError;
                    result.Mensaje = resultDTO.Mensaje;
                    return result;
                }

                result.Entidad = resultDTO.Entidad;
            }

            return result;
        }

    }

}