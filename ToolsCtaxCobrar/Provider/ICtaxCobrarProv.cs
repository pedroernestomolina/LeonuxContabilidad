using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public interface ICtaxCobrarProv
    {

        ResultadoLista<OOB.CtxCobrar.Documentos.Pendiente.Ficha > CtaxCobrar_Documentos_Pendiente_Lista(OOB.CtxCobrar.Documentos.Pendiente.Filtro filtro);
        ResultadoEntidad<OOB.CtxCobrar.Documentos.Pendiente.Ficha> CtaxCobrar_Documentos_Pendiente_Get_ById(string auto);
        ResultadoLista<OOB.CtxCobrar.Documentos.Pago.Ficha> CtaxCobrar_Documentos_Pago_Lista(OOB.CtxCobrar.Documentos.Pago.Filtro filtro);

        ResultadoEntidad<string> CtaxCobrar_Pago_Procesar(OOB.CtxCobrar.Pago.Ficha pago);
        Resultado CtaxCobrar_Pago_Anular(OOB.CtxCobrar.Pago.Anular.Ficha ficha);

    }

}