using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public interface IBancoServicio
    {

        //BANCO
        ResultadoLista<DTO.Bancos.Banco.Resumen> Bancos_Banco_Lista();
        ResultadoLista<DTO.Bancos.Banco.Resumen> Bancos_Banco_Lista_Resumen();
        ResultadoEntidad<DTO.Bancos.Banco.Ficha> Bancos_Banco_GetById(string autoBanco);
        Resultado Bancos_Banco_Actualizar(DTO.Bancos.Banco.Actualizar ficha);

        //BANCO CONCEPTOS
        ResultadoLista<DTO.Bancos.Conceptos.Resumen> Banco_Concepto_Lista(DTO.Bancos.Conceptos.Filtro filtros);
        ResultadoEntidad<DTO.Bancos.Conceptos.Ficha> Banco_Concepto_GetById(string auto);
        Resultado Banco_Concepto_Actualizar(DTO.Bancos.Conceptos.Actualizar ficha);

        //BANCO MOVIMIENTO
        ResultadoEntidad<DTO.Bancos.Movimiento.Ficha> Bancos_Movimiento_GetById(string autoMov);

    }

}