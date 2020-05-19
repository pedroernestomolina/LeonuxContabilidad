using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.ResultadoEntidad<OOB.Productos.Movimiento.Ficha> Productos_Movimiento_GetById(string autoDoc)
        {
            var result = new OOB.Resultado.ResultadoEntidad<OOB.Productos.Movimiento.Ficha>();

            var resultDTO = _servicio.Productos_Movimiento_GetById(autoDoc);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            var doc = new OOB.Productos.Movimiento.Ficha()
            {
                DocumentoNro=resultDTO.Entidad.DocumentoNro,
                Fecha = resultDTO.Entidad.Fecha,
                Hora = resultDTO.Entidad.Hora,
                Nota = resultDTO.Entidad.Nota,
                Usuario = resultDTO.Entidad.Usuario ,
                Estacion = resultDTO.Entidad.Estacion,
                ConceptoCodigo = resultDTO.Entidad.ConceptoCodigo,
                ConceptoDesc = resultDTO.Entidad.ConceptoDesc,
                DepositoCodigo = resultDTO.Entidad.DepositoCodigo,
                DepositoDesc=resultDTO.Entidad.DepositoDesc,
                DocumentoCodigo = resultDTO.Entidad.DocumentoCodigo,
                DocumentoDesc = resultDTO.Entidad.DocumentoDesc,
                Renglones = resultDTO.Entidad.Renglones,
                Importe = resultDTO.Entidad.Importe
            };

            if (resultDTO.Entidad.Detalles != null)
            {
                var det = resultDTO.Entidad.Detalles.Select((d) =>
                {
                    return new OOB.Productos.Movimiento.Detalle()
                    {
                        PrdCodigo=d.PrdCodigo,
                        PrdDescripcion=d.PrdDescripcion,
                        Cantidad=d.Cantidad,
                        Empaque=d.Empaque,
                        Contenido=d.Contenido,
                        CantidadUnidades=d.CantidadUnidades,
                        CostoCompra=d.CostoCompra,
                        CostoUnd=d.CostoUnd,
                        Importe=d.Importe,
                        DepartamentoCodigo=d.DepartamentoCodigo,
                        DepartamentoDesc=d.DepartamentoDesc,
                        Signo=d.Signo,
                    };
                }).ToList();
                doc.Detalles= det;
            }

            result.Entidad = doc;
            return result;
        }

    }

}