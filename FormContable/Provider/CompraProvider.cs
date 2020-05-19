using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {
     
        public OOB.Resultado.ResultadoEntidad<OOB.Compra.Compra.Ficha> Compra_Documento_GetById(string autoDoc)
        {
            var result = new OOB.Resultado.ResultadoEntidad<OOB.Compra.Compra.Ficha>();

            var resultDTO = _servicio.Compra_Documento_GetById(autoDoc);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            var doc = new OOB.Compra.Compra.Ficha()
            {
                Id = resultDTO.Entidad.Id,
                FechaEmision = resultDTO.Entidad.FechaEmision,
                FechaRegistro = resultDTO.Entidad.FechaRegistro,
                MesRelacion = resultDTO.Entidad.MesRelacion.ToString().Trim().PadLeft(2, '0'),
                AnoRelacion = resultDTO.Entidad.AnoRelacion.ToString(),
                Hora = resultDTO.Entidad.Hora,
                DocumentoNro = resultDTO.Entidad.DocumentoNro,
                ControlNro = resultDTO.Entidad.ControlNro,
                Concepto = resultDTO.Entidad.Concepto,
                CodigoProv = resultDTO.Entidad.CodigoProveedor,
                NombreRazonSocial = resultDTO.Entidad.Proveedor,
                CiRif = resultDTO.Entidad.CiRif,
                DireccionFiscal = resultDTO.Entidad.DireccionFiscal,
                Telefono = resultDTO.Entidad.Telefono,
                TipoDocumento = (OOB.Compra.Enumerados.TipoDocumento)resultDTO.Entidad.TipoDoc,
                Usuario = resultDTO.Entidad.Usuario,
                Estacion = resultDTO.Entidad.Estacion,
                Decuento = resultDTO.Entidad.Decuento,
                Cargo = resultDTO.Entidad.Cargo,
                SubTotal_01 = resultDTO.Entidad.SubTotal_01,
                MontoExento = resultDTO.Entidad.MontoExento,
                MontoBase = resultDTO.Entidad.MontoBase,
                SubTotal_02 = resultDTO.Entidad.SubTotal_02,
                Impuesto = resultDTO.Entidad.Impuesto,
                Total = resultDTO.Entidad.Total,
                Renglones = resultDTO.Entidad.Renglones,
                Notas = resultDTO.Entidad.Notas,
                CodigoSucursal=resultDTO.Entidad.CodigoSucursal,
            };

            if (resultDTO.Entidad.Detalles != null)
            {
                var det = resultDTO.Entidad.Detalles.Select((d) =>
                {
                    return new OOB.Compra.Compra.Detalle()
                    {
                        Cantidad = d.Cantidad,
                        Descripcion = d.Descripcion,
                        Precio = d.Precio,
                        Importe = d.Importe,
                        Impuesto = d.Impuesto,
                        TasaIva = d.TasaIva,
                        Total = d.Total,
                        Empaque = d.Empaque,
                        Contenido = d.Contenido,
                        DepartamentoDesc=d.DepartamentoDesc,
                    };
                }).ToList();
                doc.Detalles = det;
            }

            result.Entidad = doc;
            return result;
        }

        public OOB.Resultado.ResultadoEntidad<OOB.Compra.RetencionIva.Ficha> Compra_RetencionIva_GetById(string autoDoc)
        {
            var result = new OOB.Resultado.ResultadoEntidad<OOB.Compra.RetencionIva.Ficha>();

            var resultDTO = _servicio.Compra_RetencionIva_GetById(autoDoc);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            var doc = new OOB.Compra.RetencionIva.Ficha()
            {
                FechaEmision = resultDTO.Entidad.FechaEmision,
                FechaRegistro = resultDTO.Entidad.FechaProceso,
                DocumentoNro = resultDTO.Entidad.DocumentoNro,
                ProvCodigo = resultDTO.Entidad.ProvCodigo,
                ProvNombreRazonSocial = resultDTO.Entidad.ProvNombreRazonSocial,
                ProvCiRif = resultDTO.Entidad.ProvCiRif,
                ProvDireccionFiscal = resultDTO.Entidad.ProvDireccionFiscal,
                ProvTelefono = resultDTO.Entidad.ProvTelefono,
                MontoExento = resultDTO.Entidad.MontoExento,
                MontoBase = resultDTO.Entidad.MontoBase,
                MontoImpuesto = resultDTO.Entidad.MontoImpuesto,
                Total = resultDTO.Entidad.Total,
                TasaRetencion = resultDTO.Entidad.TasaRetencion,
                MontoRetencion = resultDTO.Entidad.MontoRetencion,
                MesRelacion = resultDTO.Entidad.MesRelacion.ToString().Trim().PadLeft(2, '0'),
                AnoRelacion = resultDTO.Entidad.AnoRelacion.ToString(),
                Renglones = resultDTO.Entidad.Renglones
            };

            if (resultDTO.Entidad.Detalles != null)
            {
                var det = resultDTO.Entidad.Detalles.Select((d) =>
                {
                    return new OOB.Compra.RetencionIva.Detalle()
                    {
                        DocumentoNro = d.DocumentoNro,
                        ControlNro = d.ControlNro,
                        TipoDocumento = (OOB.Compra.Enumerados.TipoDocumento)d.TipoDocumento,
                        Fecha = d.Fecha,
                        Aplica = d.Aplica,
                        Exento = d.Exento,
                        Base = d.Base,
                        Impuesto = d.Impuesto,
                        Total = d.Total,
                        Retencion = d.Retencion,
                        Signo = d.Signo
                    };
                }).ToList();
                doc.Detalles = det;
            }

            result.Entidad = doc;
            return result;
        }

        public OOB.Resultado.ResultadoEntidad<OOB.Compra.RetencionIslr.Ficha> Compra_RetencionIslr_GetById(string autoDoc)
        {
            var result = new OOB.Resultado.ResultadoEntidad<OOB.Compra.RetencionIslr.Ficha>();

            var resultDTO = _servicio.Compra_RetencionIslr_GetById(autoDoc);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            var doc = new OOB.Compra.RetencionIslr.Ficha()
            {
                FechaEmision = resultDTO.Entidad.FechaEmision,
                FechaRegistro = resultDTO.Entidad.FechaProceso,
                DocumentoNro = resultDTO.Entidad.DocumentoNro,
                ProvCodigo = resultDTO.Entidad.ProvCodigo,
                ProvNombreRazonSocial = resultDTO.Entidad.ProvNombreRazonSocial,
                ProvCiRif = resultDTO.Entidad.ProvCiRif,
                ProvDireccionFiscal = resultDTO.Entidad.ProvDireccionFiscal,
                ProvTelefono = resultDTO.Entidad.ProvTelefono,
                MontoExento = resultDTO.Entidad.MontoExento,
                MontoBase = resultDTO.Entidad.MontoBase,
                MontoImpuesto = resultDTO.Entidad.MontoImpuesto,
                Total = resultDTO.Entidad.Total,
                TasaRetencion = resultDTO.Entidad.TasaRetencion,
                MontoRetencion = resultDTO.Entidad.MontoRetencion,
                MesRelacion = resultDTO.Entidad.MesRelacion.ToString().Trim().PadLeft(2, '0'),
                AnoRelacion = resultDTO.Entidad.AnoRelacion.ToString(),
                Renglones = resultDTO.Entidad.Renglones
            };

            if (resultDTO.Entidad.Detalles != null)
            {
                var det = resultDTO.Entidad.Detalles.Select((d) =>
                {
                    return new OOB.Compra.RetencionIslr.Detalle()
                    {
                        DocumentoNro = d.DocumentoNro,
                        ControlNro = d.ControlNro,
                        TipoDocumento = (OOB.Compra.Enumerados.TipoDocumento)d.TipoDocumento,
                        Fecha = d.Fecha,
                        Aplica = d.Aplica,
                        Exento = d.Exento,
                        Base = d.Base,
                        Impuesto = d.Impuesto,
                        Total = d.Total,
                        Retencion = d.Retencion,
                        Signo = d.Signo
                    };
                }).ToList();
                doc.Detalles = det;
            }

            result.Entidad = doc;
            return result;
        }

        public OOB.Resultado.Resultado Compra_Actualizar(OOB.Compra.Compra.ActualizarData ficha)
        {
            var result = new OOB.Resultado.Resultado();

            var actualizarDTO = new DTO.Compras.Compra.ActualizarData() 
            {
                 AutoDocumento=ficha.AutoDocumento,
                 AutoCalificativo=ficha.Calificativo.Id
            };

            var resultDTO = _servicio.Compra_ActualizarData(actualizarDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            return result;
        }

    }

}