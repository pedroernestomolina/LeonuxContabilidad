using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public interface IEmpresaServicio
    {

        //DATOS DEL NEGOCIO
        ResultadoEntidad<DTO.Empresa.Empresa.Ficha> Empresa_DatosNegocio();

        //DEPARTAMENTOS
        ResultadoLista<DTO.Empresa.Departamentos.Resumen> Empresa_Departamento_Lista();
        ResultadoEntidad<DTO.Empresa.Departamentos.Ficha> Empresa_Departamento_GetById(string autoDep);
        Resultado Empresa_Departamento_Actualizar(DTO.Empresa.Departamentos.Actualizar ficha);

        //SERIES FISCALES
        ResultadoLista<DTO.Empresa.SerialesFiscales.Ficha> Empresa_SerialesFiscales_Lista();

        //COBRADORES
        ResultadoLista<DTO.Empresa.Cobradores.Resumen> Empresa_Cobradores_Lista();

        //MEDIOS DE PAGO
        ResultadoLista<DTO.Empresa.MediosPago.Resumen> Empresa_MediosPago_Lista();

    }

}
