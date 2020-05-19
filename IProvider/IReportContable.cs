using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IProvider
{

    public interface IReportContable
    {

        ResultadoLista<DTO.Reportes.PlanCta.Maestro.Ficha> Reporte_PlanCta_Maestro();
        ResultadoLista<DTO.Reportes.Balances.Comprobacion.Ficha> Reporte_Balance_Comprobacion(DTO.Reportes.Balances.Comprobacion.Filtro filtro);
        ResultadoLista<DTO.Reportes.Balances.GananciaPerdida.Ficha> Reporte_Balance_GananciaPerdida(DTO.Reportes.Balances.GananciaPerdida.Filtro filtro);
        ResultadoLista<DTO.Reportes.Balances.General.Ficha> Reporte_Balance_General(DTO.Reportes.Balances.General.Filtro filtro);
        ResultadoEntidad<DTO.Reportes.Balances.ComprobanteDiario.Ficha> Reporte_Balance_ComprobanteDiario(int idComprobante);

    }

}
