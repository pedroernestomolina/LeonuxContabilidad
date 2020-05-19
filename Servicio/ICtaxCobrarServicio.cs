using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public interface ICtaxCobrarServicio
    {

        //CTAxCOBRAR/DOCUMENTOS/PENDIENTES
        ResultadoLista<DTO.CtaxCobrar.Documentos.Pendientes.Resumen> CtaxCobrar_Documentos_Pendientes(DTO.CtaxCobrar.Documentos.Pendientes.Filtro filtro);
        ResultadoEntidad<DTO.CtaxCobrar.Documentos.Pendientes.Ficha> CtaxCobrar_Documentos_Pendientes_Get_ById(string auto);
        ResultadoLista<DTO.CtaxCobrar.Documentos.Pagos.Resumen> CtaxCobrar_Documentos_Pagos(DTO.CtaxCobrar.Documentos.Pagos.Filtro filtro);


        //CTAxCOBRAR/PAGO 
        ResultadoEntidad<string> CtaxCobrar_Pago_Procesar(DTO.CtaxCobrar.Pago.Ficha pago);
        Resultado CtaxCobrar_Pago_Anular(DTO.CtaxCobrar.Pago.Anular ficha);


        //CTAxCOBRAR - RECIBO
        ResultadoEntidad<DTO.CtaxCobrar.Recibo.Ficha> CtaxCobrar_Recibo_GetById(string autoRecibo);


        //CTAxCOBRAR/GENERAR/DOC/ADM
        ResultadoEntidad<string> CtaxCobrar_Generar_Documento_Adm_NotaCredito(DTO.CtaxCobrar.Generar.DocAdm.NtCredito ficha);
        ResultadoEntidad<string> CtaxCobrar_Generar_Documento_Adm_NotaDebito(DTO.CtaxCobrar.Generar.DocAdm.NtDebito ficha);

    }

}