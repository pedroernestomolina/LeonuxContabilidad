using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public interface IEmpresaProv
    {

        //EMPRESA
        ResultadoEntidad<OOB.Empresa.DatosNegocio.Ficha> Empresa_DatosNegocio();

        //COBRADORES
        ResultadoLista<OOB.Empresa.Cobradores.Ficha> Empresa_Cobradores_Lista();

        //MEDIOS DE PAGO
        ResultadoLista<OOB.Empresa.MediosPago.Ficha> Empresa_MediosPago_Lista();

    }
    
}