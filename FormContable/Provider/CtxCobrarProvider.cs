using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.ResultadoEntidad<OOB.CtxCobrar.Recibo.Ficha> CtxCobrar_Recibo_GetById(string autoDoc)
        {
            var result = new OOB.Resultado.ResultadoEntidad<OOB.CtxCobrar.Recibo.Ficha>();

            var resultDTO = _servicio.CtaxCobrar_Recibo_GetById(autoDoc);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            var doc = new OOB.CtxCobrar.Recibo.Ficha()
            {
                FechaEmision = resultDTO.Entidad.FechaEmision,
                Hora = resultDTO.Entidad.Hora,
                DocumentoNro = resultDTO.Entidad.DocumentoNro,
                ClienteCodigo = resultDTO.Entidad.CliCodigo,
                ClienteNombreRazonSocial = resultDTO.Entidad.CliNombre,
                ClienteCiRif = resultDTO.Entidad.CliCiRif,
                ClienteDireccionFiscal = resultDTO.Entidad.CliDireccionFiscal,
                ClienteTelefono = resultDTO.Entidad.CliTelefono,
                CobradorCodigo = resultDTO.Entidad.CobCodigo,
                CobradorNombre = resultDTO.Entidad.CobNombre,
                Estacion = resultDTO.Entidad.Estacion,
                Importe = resultDTO.Entidad.Importe,
                Notas = resultDTO.Entidad.Notas,
                Usuario = resultDTO.Entidad.Usuario,
            };

            var pago = new OOB.CtxCobrar.Recibo.Pago()
            {
                MontoPorAnticipos = resultDTO.Entidad.FormaPago.MontoPorAnticipos,
                MontoPorDescuento = resultDTO.Entidad.FormaPago.MontoPorDescuento,
                MontoPorRetenciones = resultDTO.Entidad.FormaPago.MontoPorRetenciones,
            };
            if (resultDTO.Entidad.FormaPago.MedioPago != null)
            {
                var medio = new OOB.CtxCobrar.Recibo.Medio()
                {
                     Codigo =resultDTO.Entidad.FormaPago.MedioPago.Codigo ,
                     Descripcion  = resultDTO.Entidad.FormaPago.MedioPago.Descripcion,
                     Agencia  = resultDTO.Entidad.FormaPago.MedioPago.Agencia ,
                     MontoRecibido= resultDTO.Entidad.FormaPago.MedioPago.MontoRecibido ,
                };
                pago.MedioPago=medio;
            }
            else 
            {
                pago.MedioPago = new OOB.CtxCobrar.Recibo.Medio();
            }
            doc.FormaPago = pago;

            if (resultDTO.Entidad.Documentos != null)
            {
                var det = resultDTO.Entidad.Documentos.Select((d) =>
                {
                    return new OOB.CtxCobrar.Recibo.Documento()
                    {
                        DocumentoNro = d.DocumentoNro,
                        Fecha = d.Fecha,
                        Importe = d.Importe,
                        Operacion = d.Operacion,
                        TipoDocumento = d.TipoDocumento
                    };
                }).ToList();
                doc.Documentos = det;
            }

            result.Entidad = doc;
            return result;
        }

    }

}