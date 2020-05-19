using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public DTO.ResultadoLista<DTO.Contable.Asiento.Resumen> Contable_Asiento_Lista(DTO.Contable.Asiento.Busqueda busq)
        {
            return provider.Contable_Asiento_Lista(busq);
        }

        public DTO.ResultadoLista<DTO.Contable.Asiento.Generar.Ficha> Contable_Asiento_Generar(DTO.Contable.Asiento.Generar.Filtros filt)
        {
            switch (filt.Modulo) 
            {
                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Ventas:
                    return provider.Contable_Asiento_Venta_Generar(filt);
                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Compras:
                    return provider.Contable_Asiento_Compra_Generar(filt);
                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.PorPagar:
                    return provider.Contable_Asiento_CtasPorPagar_Generar(filt);
                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.PorCobrar:
                    return provider.Contable_Asiento_CtasPorCobrar_Generar(filt);
                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Inventario:
                    return provider.Contable_Asiento_Inventario_Generar(filt);
                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Bancos :
                    return provider.Contable_Asiento_Banco_Generar(filt);
                default:
                    throw new Exception("PROCESO NO DEFINIDO");
            }
        }

        public DTO.ResultadoId Contable_Asiento_Insertar_Integracion(DTO.Contable.Asiento.Generar.Insertar ficha)
        {
            var r01= provider.Contable_Asiento_Insertar_Integracion_Verificar(ficha);
            if (r01.Result == DTO.EnumResult.isError)
            {
                return new DTO.ResultadoId()
                {
                    Mensaje = r01.Mensaje,
                    Result = DTO.EnumResult.isError,
                };
            }
            else 
            {
                return provider.Contable_Asiento_Insertar_Integracion(ficha);
            }
        }

        public DTO.Resultado Contable_Asiento_EditarPreview_Integracion(DTO.Contable.Asiento.Generar.Editar ficha)
        {
            return provider.Contable_Asiento_EditarPreview_Integracion(ficha);
        }


        //APERTURA
        public DTO.ResultadoEntidad<bool> Contable_Asiento_Apertura_IsOk()
        {
            return provider.Contable_Asiento_Apertura_IsOk();
        }

        public DTO.ResultadoEntidad<int> Contable_Asiento_Apertura_Get_ID()
        {
            return provider.Contable_Asiento_Apertura_Get_ID();
        }

        public DTO.Resultado Contable_Asiento_Apertura_Guardar(DTO.Contable.Asiento.Apertura.Insertar ficha)
        {
            if (ficha.IsPreview)
            {
                return provider.Contable_Asiento_Apertura_Preview(ficha);
            }
            else
            {
                return provider.Contable_Asiento_Apertura_Insertar(ficha);
            }
        }

        //ASIENTO
        public DTO.ResultadoId Contable_Asiento_Guardar(DTO.Contable.Asiento.Insertar ficha)
        {
            if (ficha.IsPreview)
            {
                return provider.Contable_Asiento_Preview(ficha);
            }
            else 
            {
                if (ficha.IdAsientoEditado == -1)
                {
                    return provider.Contable_Asiento_Insertar(ficha);
                }
                else 
                {

                    var r01 = provider.Contable_Asiento_VerificarEditar(ficha.IdAsientoEditado);
                    if (r01.Result == DTO.EnumResult.isError)
                    {
                        var result = new DTO.ResultadoId();
                        result.Id = -1;
                        result.Mensaje = r01.Mensaje;
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }

                    return provider.Contable_Asiento_Editar(ficha);
                }
            }
        }

        public DTO.ResultadoEntidad<DTO.Contable.Asiento.Ficha> Contable_Asiento_GetById(int id)
        {
            return provider.Contable_Asiento_GetById(id);
        }

        public DTO.Resultado Contable_Asiento_Anular(DTO.Contable.Asiento.Anular ficha)
        {

            var r01 = provider.Contable_Asiento_VerificarAnular(ficha.Id);
            if (r01.Result == DTO.EnumResult.isError)
            {
                return r01;
            }

            switch (ficha.Tipo) 
            {
                case DTO.Contable.Asiento.Enumerados.TipoAsientoAnular.Preview:
                    return provider.Contable_Asiento_Anular_Preview(ficha.Id);
                case DTO.Contable.Asiento.Enumerados.TipoAsientoAnular.Asiento:
                    return provider.Contable_Asiento_Anular(ficha.Id);
                case DTO.Contable.Asiento.Enumerados.TipoAsientoAnular.Apertura:
                    return provider.Contable_Asiento_Anular_Apertura(ficha.Id);
                default:
                    {
                        var r = new DTO.Resultado();
                        r.Mensaje = "Tipo Asiento No Definido";
                        r.Result = DTO.EnumResult.isError;
                        return r;
                    }
            }
        }

    }

}