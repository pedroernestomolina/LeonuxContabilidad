using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public DTO.ResultadoEntidad<DTO.Contable.Periodo.Actual> Contable_PeriodoActual_Get()
        {
            return provider.Contable_PeridoActual_Get();
        }

        public DTO.ResultadoLista<DTO.Contable.Periodo.CuentaTotales> Contable_Periodo_CalculoUtilidad()
        {
            return provider.Contable_Perido_Utilidad();
        }

        public DTO.Resultado Contable_Periodo_CerrarMes(DTO.Contable.Periodo.Cerrar ficha)
        {
            return provider.Contable_Perido_Cerrar(ficha);
        }

        public DTO.Resultado Contable_Periodo_Reversar(int IdPeriodoActual)
        {
            var r01 = provider.Contable_Periodo_VerificaSiHayMovimientos(IdPeriodoActual);
            if (r01.Result == DTO.EnumResult.isError)
            {
                return r01;
            }
            else 
            {
                return provider.Contable_Perido_Reversar(IdPeriodoActual);
            }
        }

        public DTO.ResultadoLista<DTO.Contable.Periodo.Ficha> Contable_Periodo_Lista()
        {
            return provider.Contable_Periodo_Lista();
        }

        public DTO.ResultadoLista<DTO.Contable.Periodo.Ficha> Contable_Utilidad_Acumulada()
        {
            return provider.Contable_Utilidad_Acumulada();
        }

    }

}