using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public partial class Provider : IProvider
    {

        //DATOS DEL NEGOCIO
        public OOB.Resultado.ResultadoEntidad<OOB.Empresa.DatosNegocio.Ficha> Empresa_DatosNegocio()
        {
            var rt = new OOB.Resultado.ResultadoEntidad<OOB.Empresa.DatosNegocio.Ficha>();

            try
            {
                var resultDTO = _servicio.Empresa_DatosNegocio();
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var r = new OOB.Empresa.DatosNegocio.Ficha()
                {
                    Rif = resultDTO.Entidad.Rif,
                    NombreRazonSocial = resultDTO.Entidad.NombreRazonSocial,
                    DireccionFiscal = resultDTO.Entidad.DireccionFiscal,
                };

                rt.Entidad = r;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }
            return rt;
        }


        //COBRADORES
        public OOB.Resultado.ResultadoLista<OOB.Empresa.Cobradores.Ficha> Empresa_Cobradores_Lista()
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.Empresa.Cobradores.Ficha >();

            try
            {
                var resultDTO = _servicio.Empresa_Cobradores_Lista() ;
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var list = new List<OOB.Empresa.Cobradores.Ficha>();
                if (resultDTO.Lista.Count > 0)
                {
                    foreach (var it in resultDTO.Lista)
                    {
                        var r = new OOB.Empresa.Cobradores.Ficha()
                        {
                            IdAuto = it.IdAuto,
                            Codigo = it.Codigo,
                            Nombre=it.Nombre,
                        };
                        list.Add(r);
                    }
                }

                rt.cntRegistro = resultDTO.cntRegistro;
                rt.Lista = list;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }

            return rt;
        }

        //MEDIOS DE PAGO
        public OOB.Resultado.ResultadoLista<OOB.Empresa.MediosPago.Ficha> Empresa_MediosPago_Lista()
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.Empresa.MediosPago.Ficha>();

            try
            {
                var resultDTO = _servicio.Empresa_MediosPago_Lista();
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var list = new List<OOB.Empresa.MediosPago.Ficha>();
                if (resultDTO.Lista.Count > 0)
                {
                    foreach (var it in resultDTO.Lista)
                    {
                        var r = new OOB.Empresa.MediosPago.Ficha()
                        {
                            IdAuto = it.IdAuto,
                            Codigo = it.Codigo,
                            Nombre = it.Nombre,
                        };
                        list.Add(r);
                    }
                }

                rt.cntRegistro = resultDTO.cntRegistro;
                rt.Lista = list;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }

            return rt;
        }

    }

}