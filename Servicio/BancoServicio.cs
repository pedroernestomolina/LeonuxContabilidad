using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{
    
    public partial class MiServicio : IServicio
    {

        //BANCOS
        public DTO.ResultadoLista<DTO.Bancos.Banco.Resumen> Bancos_Banco_Lista()
        {
            return provider.Bancos_Banco_Lista();
        }

        public DTO.ResultadoLista<DTO.Bancos.Banco.Resumen> Bancos_Banco_Lista_Resumen()
        {
            return provider.Bancos_Banco_Lista_Resumen();
        }

        public DTO.ResultadoEntidad<DTO.Bancos.Banco.Ficha> Bancos_Banco_GetById(string autoBanco)
        {
            return provider.Bancos_Banco_GetById(autoBanco);
        }

        public DTO.Resultado Bancos_Banco_Actualizar(DTO.Bancos.Banco.Actualizar ficha)
        {
            var r01 = provider.Bancos_Banco_VerificaActualizar(ficha);
            if (r01.Result == DTO.EnumResult.isError)
            {
                return new DTO.Resultado()
                {
                    Mensaje = r01.Mensaje,
                    Result = DTO.EnumResult.isError
                };
            }

            return provider.Bancos_Banco_Actualizar(ficha);
        }


        //CONCEPTOS
        public DTO.ResultadoLista<DTO.Bancos.Conceptos.Resumen> Banco_Concepto_Lista(DTO.Bancos.Conceptos.Filtro filtros)
        {
            return provider.Banco_Concepto_Lista(filtros);
        }

        public DTO.ResultadoEntidad<DTO.Bancos.Conceptos.Ficha> Banco_Concepto_GetById(string auto)
        {
            return provider.Banco_Concepto_GetById(auto);
        }

        public DTO.Resultado Banco_Concepto_Actualizar(DTO.Bancos.Conceptos.Actualizar ficha)
        {
            return provider.Banco_Concepto_Actualizar(ficha);
        }


        //MOVIMIENTOS
        public DTO.ResultadoEntidad<DTO.Bancos.Movimiento.Ficha> Bancos_Movimiento_GetById(string autoMov)
        {
            return provider.Bancos_Movimiento_GetById(autoMov);
        }

    }

}