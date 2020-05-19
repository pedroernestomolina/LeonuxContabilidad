using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public DTO.ResultadoLista<DTO.Contable.Cuenta.Movimiento> Contable_Cuenta_GetMovimiento(DTO.Contable.Cuenta.Filtro filt)
        {
            return provider.Contable_Cuenta_GetMovimiento(filt);
        }

        public DTO.ResultadoLista<DTO.Contable.Cuenta.Balance> Contable_Cuenta_GetBalance(DTO.Contable.Cuenta.Filtro filt)
        {
            return provider.Contable_Cuenta_GetBalance(filt);
        }

        public DTO.ResultadoEntidad<decimal> Contable_Cuenta_GetSaldoAl(DTO.Contable.Cuenta.SaldoAl ficha)
        {
            return provider.Contable_Cuenta_GetSaldoAl(ficha.idCta, ficha.Al );
        }

    }

}