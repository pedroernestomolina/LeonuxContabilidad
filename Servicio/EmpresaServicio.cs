using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        //DEPARTAMENTOS
        DTO.ResultadoLista<DTO.Empresa.Departamentos.Resumen> IEmpresaServicio.Empresa_Departamento_Lista()
        {
            return provider.Empresa_Departamento_Lista();
        }

        public DTO.ResultadoEntidad <DTO.Empresa.Departamentos.Ficha> Empresa_Departamento_GetById(string autoDep)
        {
            return provider.Empresa_Departamento_GetById(autoDep);
        }

        public DTO.Resultado Empresa_Departamento_Actualizar(DTO.Empresa.Departamentos.Actualizar ficha)
        {
            return provider.Empresa_Departamento_Actualizar(ficha);
        }

        //SERIES FISCALES
        public DTO.ResultadoLista<DTO.Empresa.SerialesFiscales.Ficha> Empresa_SerialesFiscales_Lista()
        {
            return provider.Empresa_SerialesFiscales_Lista ();
        }

        //DATOS DEL NEGOCIO
        public DTO.ResultadoEntidad<DTO.Empresa.Empresa.Ficha> Empresa_DatosNegocio()
        {
            return provider.Empresa_DatosNegocio();
        }

        //COBRADORES
        public DTO.ResultadoLista<DTO.Empresa.Cobradores.Resumen> Empresa_Cobradores_Lista()
        {
            return provider.Empresa_Cobradores_Lista ();
        }

        //MEDIOS DE PAGO
        public DTO.ResultadoLista<DTO.Empresa.MediosPago.Resumen> Empresa_MediosPago_Lista()
        {
            return provider.Empresa_Mediospago_Lista();
        }

    }

}