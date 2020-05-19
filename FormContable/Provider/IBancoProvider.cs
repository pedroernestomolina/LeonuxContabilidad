using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Provider
{

    public interface IBancoProvider
    {

        //BANCO
        ResultadoLista<OOB.Bancos.Banco.Ficha> Bancos_Banco_Lista();
        ResultadoEntidad<OOB.Bancos.Banco.Ficha> Bancos_Banco_GetById(string autoBanco);
        Resultado Bancos_Banco_Actualizar(OOB.Bancos.Banco.Actualizar ficha);

        //BANCO/CONCEPTOS
        ResultadoLista<OOB.Bancos.Conceptos.Ficha> Banco_Concepto_Lista(
            string buscar,
            OOB.Bancos.Conceptos.Enumerados.TipoLista lista,
            OOB.Bancos.Conceptos.Enumerados.TipoMovimiento clase);
        ResultadoEntidad<OOB.Bancos.Conceptos.Ficha> Banco_Concepto_GetById(string auto);
        Resultado Banco_Concepto_Actualizar(OOB.Bancos.Conceptos.Actualizar ficha);

        //BANCO/MOVIMIENTO 
        ResultadoEntidad<OOB.Bancos.Movimiento.Ficha> Banco_Movimiento_GetById(string autoMov);

    }

}
