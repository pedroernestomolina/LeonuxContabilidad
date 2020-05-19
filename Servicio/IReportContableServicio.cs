using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public interface IReportContableServicio
    {

        //REPORTES
        ResultadoLista<DTO.Reportes.PlanCta.Maestro.Ficha> Reportes_PlanCta_Maestro();
        ResultadoLista<DTO.Reportes.Balances.Comprobacion.Ficha> Reportes_Balances_Comprobacion(DTO.Reportes.Balances.Comprobacion.Filtro filtro);
        ResultadoLista<DTO.Reportes.Balances.GananciaPerdida.Ficha> Reportes_Balances_GananciaPerdida(DTO.Reportes.Balances.GananciaPerdida.Filtro filtro);
        ResultadoLista<DTO.Reportes.Balances.General.Ficha> Reportes_Balances_General(DTO.Reportes.Balances.General.Filtro filtro);

        ResultadoEntidad<DTO.Reportes.Balances.ComprobanteDiario.Ficha> Reportes_Balances_ComprobanteDiario(int idComprobante);

    }

}