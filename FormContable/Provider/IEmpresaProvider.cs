using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Provider
{

    public interface IEmpresaProvider
    {

        ResultadoEntidad<OOB.Empresa.DatosNegocio.Ficha> Empresa_DatosNegocio();
        ResultadoLista<OOB.Empresa.Departamento.Ficha> Empresa_Departamento_Lista();
        ResultadoEntidad<OOB.Empresa.Departamento.Ficha> Empresa_Departamento_GetById(string autoDep);
        Resultado Empresa_Departamento_Actualizar(OOB.Empresa.Departamento.Actualizar ficha);
        ResultadoLista<OOB.Empresa.SerialesFiscales.Ficha> Empresa_SerialesFiscales_Lista();

    }

}