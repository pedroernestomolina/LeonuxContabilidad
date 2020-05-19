using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {

        async public Task<OOB.Resultado.ResultadoLista<OOB.Contable.PlanCta.Ficha>> PlanCta_Lista(OOB.Contable.PlanCta.Filtro filtro)
        {
            return await Task.Run<OOB.Resultado.ResultadoLista<OOB.Contable.PlanCta.Ficha>>(() =>
            {
                var rt = new OOB.Resultado.ResultadoLista<OOB.Contable.PlanCta.Ficha>();
                try
                {
                    var busqDTO = new DTO.Contable.PlanCta.Busqueda()
                    {
                        Cadena = filtro.Cadena
                    };
                    var resultDTO = _servicio.Contable_PlanCta_Lista(busqDTO);
                    if (resultDTO.Result == DTO.EnumResult.isError)
                    {
                        throw new Exception(resultDTO.Mensaje);
                    }

                    rt.cntRegistro = resultDTO.cntRegistro;
                    if (resultDTO.Lista != null)
                    {
                        rt.Lista = resultDTO.Lista.Select(item =>
                        {
                            return new OOB.Contable.PlanCta.Ficha()
                            {
                                Id = item.Id,
                                Codigo = item.Codigo,
                                Nombre = item.Nombre,
                                Tipo = item.Tipo == DTO.Contable.PlanCta.Enumerados.Tipo.Auxiliar ? OOB.Contable.PlanCta.Enumerados.Tipo.Auxiliar : OOB.Contable.PlanCta.Enumerados.Tipo.Totalizadora,
                                Naturaleza = item.Naturaleza == DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora ? OOB.Contable.PlanCta.Enumerados.Naturaleza.Deudora : OOB.Contable.PlanCta.Enumerados.Naturaleza.Acreedora,
                                Estado = item.Estado == DTO.Contable.PlanCta.Enumerados.EstadoSituacion.Financiero ? OOB.Contable.PlanCta.Enumerados.EstadoSituacion.Financiero : OOB.Contable.PlanCta.Enumerados.EstadoSituacion.Resultados,
                                SaldoActual = new OOB.Contable.PlanCta.Saldos()
                                {
                                    Apertura=item.SaldoApertura,
                                    Debe = item.MontoDebe ,
                                    Haber = item.MontoHaber ,
                                    Anterior = item.SaldoAnterior
                                }
                            };
                        }).ToList();
                    }
                    else
                    {
                        rt.Lista = new List<OOB.Contable.PlanCta.Ficha>();
                    }
                }
                catch (Exception e)
                {
                    rt.Mensaje = e.Message;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                }
                return rt;
            });
        }

        public OOB.Resultado.Resultado PlanCta_Eliminar(OOB.Contable.PlanCta.Ficha ficha)
        {
            var result = new OOB.Resultado.Resultado();

            var resultDTO = _servicio.Contable_PlanCta_Eliminar(ficha.Id);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
            }

            return result;
        }

        public OOB.Resultado.ResultadoId PlanCta_Agregar(OOB.Contable.PlanCta.Agregar ficha)
        {
            var result = new OOB.Resultado.ResultadoId();

            var insertarDTO = new DTO.Contable.PlanCta.Insertar();
            insertarDTO.IdCtaPadre = ficha.IdCtaPadre;
            insertarDTO.Nivel  = ficha.Nivel;
            insertarDTO.Codigo = ficha.Codigo;
            insertarDTO.Nombre = ficha.Descripcion;
            insertarDTO.Tipo = (DTO.Contable.PlanCta.Enumerados.Tipo)ficha.Tipo;
            insertarDTO.Naturaleza = (DTO.Contable.PlanCta.Enumerados.Naturaleza)ficha.Naturaleza;
            insertarDTO.Estado = (DTO.Contable.PlanCta.Enumerados.EstadoSituacion)ficha.Estado;

            var resultDTO = _servicio.Contable_PlanCta_Insertar(insertarDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            result.Id = resultDTO.Id;
            return result;
        }

        public OOB.Resultado.ResultadoEntidad<OOB.Contable.PlanCta.Ficha> PlanCta_GetById(int id)
        {
            var result = new OOB.Resultado.ResultadoEntidad<OOB.Contable.PlanCta.Ficha>();

            var resultDTO = _servicio.Contable_PlanCta_GetById(id);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            result.Entidad = new OOB.Contable.PlanCta.Ficha()
            {
                Id = resultDTO.Entidad.Id,
                Codigo = resultDTO.Entidad.Codigo,
                Nombre = resultDTO.Entidad.Nombre,
                Tipo = (OOB.Contable.PlanCta.Enumerados.Tipo)resultDTO.Entidad.Tipo,
                Naturaleza = (OOB.Contable.PlanCta.Enumerados.Naturaleza)resultDTO.Entidad.Naturaleza,
                SaldoActual = new OOB.Contable.PlanCta.Saldos()
                {
                    Apertura = 0, //resultDTO.Entidad.SaldoActual.SaldoAnterior,
                    Debe = resultDTO.Entidad.SaldoActual.Debe,
                    Haber = resultDTO.Entidad.SaldoActual.Haber,
                    Anterior= resultDTO.Entidad.SaldoActual.SaldoAnterior
                }
            };
            return result;
        }

        public OOB.Resultado.Resultado PlanCta_Editar(OOB.Contable.PlanCta.Editar ficha)
        {
            var result = new OOB.Resultado.Resultado();

            var editarDTO = new DTO.Contable.PlanCta.Editar();
            editarDTO.Id = ficha.Id;
            editarDTO.Nombre = ficha.Descripcion;
            editarDTO.Tipo = (DTO.Contable.PlanCta.Enumerados.Tipo)ficha.Tipo;
            editarDTO.Naturaleza = (DTO.Contable.PlanCta.Enumerados.Naturaleza)ficha.Naturaleza;
            editarDTO.Estado = (DTO.Contable.PlanCta.Enumerados.EstadoSituacion)ficha.Estado;

            var resultDTO = _servicio.Contable_PlanCta_Editar(editarDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            return result;
        }

        public OOB.Resultado.ResultadoEntidad<OOB.Contable.PlanCta.Padre> PlanCta_GetPadre(string codigoCta)
        {
            var result = new OOB.Resultado.ResultadoEntidad<OOB.Contable.PlanCta.Padre>();

            try
            {
                var resultDTO = _servicio.Contable_PlanCta_GetPadre(codigoCta) ;
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    throw new Exception(resultDTO.Mensaje);
                }

                result.Entidad = new OOB.Contable.PlanCta.Padre() { Id= resultDTO.Entidad.Id , nivel =resultDTO.Entidad.Nivel };
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Entidad=null;
            }

            return result;
        }
       
    }

}