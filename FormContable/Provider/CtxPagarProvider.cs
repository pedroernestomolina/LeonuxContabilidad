using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.ResultadoEntidad<OOB.CtxPagar.Recibo.Ficha> CtxPagar_Recibo_GetById(string autoDoc)
        {
            var result = new OOB.Resultado.ResultadoEntidad<OOB.CtxPagar.Recibo.Ficha>();

            var resultDTO = _servicio.CtaxPagar_Recibo_GetById(autoDoc);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            var doc = new OOB.CtxPagar.Recibo.Ficha()
            {
                FechaEmision = resultDTO.Entidad.FechaEmision,
                DocumentoNro = resultDTO.Entidad.DocumentoNro,
                ProvCodigo = resultDTO.Entidad.ProvCodigo,
                ProvNombreRazonSocial = resultDTO.Entidad.ProvNombre,
                ProvCiRif = resultDTO.Entidad.ProvCiRif,
                ProvDireccionFiscal = resultDTO.Entidad.ProvDireccionFiscal,
                Estacion = resultDTO.Entidad.Estacion,
                Importe = resultDTO.Entidad.Importe,
                Notas = resultDTO.Entidad.Notas,
                Usuario = resultDTO.Entidad.Usuario
            };

            var pago = new OOB.CtxPagar.Recibo.Pago()
            {
                MontoPorAnticipos = resultDTO.Entidad.FormaPago.MontoPorAnticipos,
            };
            if (resultDTO.Entidad.FormaPago.MedioPago != null)
            {
                var medio = new OOB.CtxPagar.Recibo.Medio()
                {
                    CodigoMedio = resultDTO.Entidad.FormaPago.MedioPago.Codigo,
                    DescripcionMedio = resultDTO.Entidad.FormaPago.MedioPago.Descripcion,
                    CtaCodigo = resultDTO.Entidad.FormaPago.MedioPago.CtaCodigo,
                    CtaNumero = resultDTO.Entidad.FormaPago.MedioPago.CtaNumero,
                    Referencia = resultDTO.Entidad.FormaPago.MedioPago.Referencia ,
                    MontoRecibido = resultDTO.Entidad.FormaPago.MedioPago.MontoRecibido,
                };
                pago.MedioPago = medio;
            }
            else
            {
                pago.MedioPago = new OOB.CtxPagar.Recibo.Medio();
            }
            doc.FormaPago = pago;

            if (resultDTO.Entidad.Documentos   != null)
            {
                var det = resultDTO.Entidad.Documentos.Select((d) =>
                {
                    return new OOB.CtxPagar.Recibo.Documento()
                    {
                        DocumentoNro = d.DocumentoNro,
                        Fecha = d.Fecha,
                        Importe=d.Importe,
                        Operacion=d.Operacion,
                        TipoDocumento=d.TipoDocumento
                    };
                }).ToList();
                doc.Documentos = det;
            }

            result.Entidad = doc;
            return result;
        }

    }

}