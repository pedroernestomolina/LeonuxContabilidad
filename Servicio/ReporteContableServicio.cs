using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public DTO.ResultadoLista<DTO.Reportes.PlanCta.Maestro.Ficha> Reportes_PlanCta_Maestro()
        {
            return provider.Reporte_PlanCta_Maestro();
        }

        public DTO.ResultadoLista<DTO.Reportes.Balances.Comprobacion.Ficha> Reportes_Balances_Comprobacion(DTO.Reportes.Balances.Comprobacion.Filtro filtro)
        {
            return provider.Reporte_Balance_Comprobacion(filtro);
        }

        public DTO.ResultadoLista<DTO.Reportes.Balances.GananciaPerdida.Ficha> Reportes_Balances_GananciaPerdida(DTO.Reportes.Balances.GananciaPerdida.Filtro filtro)
        {
            return provider.Reporte_Balance_GananciaPerdida(filtro);
        }

        public DTO.ResultadoLista<DTO.Reportes.Balances.General.Ficha> Reportes_Balances_General(DTO.Reportes.Balances.General.Filtro filtro)
        {
            return provider.Reporte_Balance_General(filtro);
        }

        public DTO.ResultadoEntidad<DTO.Reportes.Balances.ComprobanteDiario.Ficha> Reportes_Balances_ComprobanteDiario(int idComprobante)
        {
            return provider.Reporte_Balance_ComprobanteDiario(idComprobante);
        }

    }

}