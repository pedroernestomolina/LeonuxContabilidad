using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public partial class MiServicio : IServicio
    {


        //CTAxCOBRAR/DOCUMENTOS/PENDIENTES
        public DTO.ResultadoLista<DTO.CtaxCobrar.Documentos.Pendientes.Resumen> CtaxCobrar_Documentos_Pendientes(DTO.CtaxCobrar.Documentos.Pendientes.Filtro filtro)
        {
            return provider.CtaxCobrar_Documentos_Pendientes(filtro);
        }

        public DTO.ResultadoEntidad<DTO.CtaxCobrar.Documentos.Pendientes.Ficha> CtaxCobrar_Documentos_Pendientes_Get_ById(string auto)
        {
            return provider.CtaxCobrar_Documentos_Pendientes_Get_ById (auto);
        }

        public DTO.ResultadoLista<DTO.CtaxCobrar.Documentos.Pagos.Resumen> CtaxCobrar_Documentos_Pagos(DTO.CtaxCobrar.Documentos.Pagos.Filtro filtro)
        {
            return provider.CtaxCobrar_Documentos_Pagos(filtro);
        }

        
        //CTAxCOBRAR/RECIBO 
        public DTO.ResultadoEntidad<DTO.CtaxCobrar.Recibo.Ficha> CtaxCobrar_Recibo_GetById(string autoRecibo)
        {
            return provider.CtaxCobrar_Recibo_GetById(autoRecibo);
        }


        //CTAxCOBRAR/PAGO
        public DTO.ResultadoEntidad<string> CtaxCobrar_Pago_Procesar(DTO.CtaxCobrar.Pago.Ficha pago)
        {
            return provider.CtaxCobrar_Pago_Procesar(pago);
        }

        public DTO.Resultado CtaxCobrar_Pago_Anular(DTO.CtaxCobrar.Pago.Anular ficha)
        {
            var result= provider.CtaxCobrar_Pago_Anular_Verificar(ficha.IdPago);
            if (result.Result == DTO.EnumResult.isError) 
            {
                return result;
            }
            return provider.CtaxCobrar_Pago_Anular(ficha);
        }


        //CTAxCOBRAR/GENERAR/DOCADM
        public DTO.ResultadoEntidad<string> CtaxCobrar_Generar_Documento_Adm_NotaCredito(DTO.CtaxCobrar.Generar.DocAdm.NtCredito ficha)
        {
            return provider.CtaxCobrar_Generar_Documento_Adm_NotaCredito (ficha);
        }

        public DTO.ResultadoEntidad<string> CtaxCobrar_Generar_Documento_Adm_NotaDebito(DTO.CtaxCobrar.Generar.DocAdm.NtDebito ficha)
        {
            return provider.CtaxCobrar_Generar_Documento_Adm_NotaDebito (ficha);
        }

    }

}