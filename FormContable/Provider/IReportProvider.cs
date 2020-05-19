using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Provider
{

    public interface IReportProvider
    {

        ResultadoLista<OOB.Reportes.PlanCta.Maestro.Ficha> Reportes_PlanCta_Maestro();
        ResultadoLista<OOB.Reportes.Balances.Comprobacion.Ficha> Reportes_Balance_Comprobacion(OOB.Reportes.Balances.Comprobacion.Filtro filtro);
        ResultadoLista<OOB.Reportes.Balances.GananciaPerdida.Ficha> Reportes_Balance_GananciaPerdida(OOB.Reportes.Balances.GananciaPerdida.Filtro filtro);
        ResultadoLista<OOB.Reportes.Balances.General.Ficha> Reportes_Balance_General(OOB.Reportes.Balances.General.Filtro filtro);
        ResultadoEntidad<OOB.Reportes.Balances.ComprobanteDiario.Ficha> Reportes_Balance_ComprobanteDiario(int IdComprobante);

    }

}
