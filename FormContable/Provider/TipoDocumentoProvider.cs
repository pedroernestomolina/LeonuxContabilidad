using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.ResultadoLista<OOB.Contable.TipoDocumento.Ficha> TipoDocumento_Lista()
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.Contable.TipoDocumento.Ficha>();

            try
            {
                var resultDTO = _servicio.Contable_TipoDocumento_Lista();
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje ;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                rt.cntRegistro = resultDTO.cntRegistro;
                rt.Lista = resultDTO.Lista.Select(item =>
                {
                    return new OOB.Contable.TipoDocumento .Ficha()
                    {
                        Id = item.Id,
                        Descripcion = item.Descripcion 
                    };
                }).ToList();
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }
            return rt;
        }

        public OOB.Resultado.ResultadoId TipoDocumento_Insertar(OOB.Contable.TipoDocumento.Insertar ficha)
        {
            var result = new OOB.Resultado.ResultadoId();

            var insertarDTO = new DTO.Contable.TipoDocumento.Insertar() {Descripcion= ficha.Descripcion};
            var resultDTO = _servicio.Contable_TipoDocumento_Insertar(insertarDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            result.Id = resultDTO.Id;
            return result;
        }

        public OOB.Resultado.Resultado TipoDocumento_Editar(OOB.Contable.TipoDocumento.Editar ficha)
        {
            var result = new OOB.Resultado.Resultado();
            var editarDTO = new DTO.Contable.TipoDocumento.Editar() { Id=ficha.Id, Descripcion=ficha.Descripcion };
            var resultDTO = _servicio.Contable_TipoDocumento_Editar(editarDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            return result;
        }

        public OOB.Resultado.Resultado TipoDocumento_Eliminar(OOB.Contable.TipoDocumento.Eliminar ficha)
        {
            var result = new OOB.Resultado.Resultado();

            var fichaDTO = new DTO.Contable.TipoDocumento.Eliminar() { Id= ficha.Item.Id };
            var resultDTO = _servicio.Contable_TipoDocumento_Eliminar(fichaDTO );
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
            }

            return result;
        }

        public OOB.Resultado.ResultadoEntidad<OOB.Contable.TipoDocumento.Ficha> TipoDocumento_Get(int id)
        {
            var result = new OOB.Resultado.ResultadoEntidad<OOB.Contable.TipoDocumento.Ficha>();
            var resultDTO = _servicio.Contable_TipoDocumento_Get(id);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            result.Entidad = new OOB.Contable.TipoDocumento.Ficha()
            {
                Id = resultDTO.Entidad.Id,
                Descripcion=resultDTO.Entidad.Descripcion
            };
            return result;
        }

    }

}