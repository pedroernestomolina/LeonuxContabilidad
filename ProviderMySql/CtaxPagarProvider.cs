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

        public DTO.ResultadoEntidad<DTO.CtaxPagar.Recibo.Ficha> CtaxPagar_Recibo_GetById(string autoDoc)
        {
            var result = new ResultadoEntidad<DTO.CtaxPagar.Recibo.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.cxp_recibos.Find(autoDoc);
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] RECIBO DE PAGO NO ENCONTRADO";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var doc = new DTO.CtaxPagar.Recibo.Ficha()
                    {
                        FechaEmision = ent.fecha,
                        DocumentoNro = ent.documento,
                        ProvCodigo = ent.codigo ,
                        ProvNombre = ent.proveedor ,
                        ProvCiRif = ent.ci_rif,
                        ProvDireccionFiscal = ent.direccion,
                        Usuario=ent.usuario ,
                        Estacion="",
                        Importe=ent.importe,
                        Notas=ent.nota
                    };

                    var pago = new DTO.CtaxPagar.Recibo.Pago();
                    pago.MontoPorAnticipos = ent.anticipos;

                    var entMedioPago = ctx.cxp_medio_pago.FirstOrDefault(mp => mp.auto_recibo == ent.auto);
                    if (entMedioPago != null)
                    {
                        pago.MedioPago = new DTO.CtaxPagar.Recibo.Medio()
                        {
                            Descripcion = entMedioPago.medio,
                            Codigo = entMedioPago.codigo,
                            CtaCodigo = entMedioPago.codigo_banco,
                            CtaNumero=entMedioPago.cuenta,
                            Referencia=entMedioPago.documento,
                            MontoRecibido = entMedioPago.monto_recibido,
                        };
                    }
                    doc.FormaPago = pago;

                    var entDet = ctx.cxp_documentos.Where(d => d.auto_cxp_recibo == autoDoc).ToList();
                    if (entDet.Count() > 0)
                    {
                        var det = entDet.Select((d) =>
                        {
                            return new DTO.CtaxPagar.Recibo.Documento()
                            {
                                DocumentoNro = d.documento,
                                TipoDocumento = d.tipo_documento,
                                Fecha = d.fecha,
                                Importe=d.importe,
                                Operacion=d.operacion
                            };
                        }).ToList();
                        doc.Documentos = det;
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

    }

}