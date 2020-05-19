using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public partial class Provider : IProvider
    {

        //CXC
        public OOB.Resultado.ResultadoLista<OOB.Reportes.CtaxCobrar.Documentos.Pendiente.Ficha> Reportes_CtxCobrar_Documentos_Pendientes(OOB.Reportes.CtaxCobrar.Vendedores.Filtro filtros)
        {
            var result = new OOB.Resultado.ResultadoLista<OOB.Reportes.CtaxCobrar.Documentos.Pendiente.Ficha>();
            try
            {
                var filtrosDTO = new DTO.Reportes.CtaxCobrar.Documentos.Pendiente.Filtro ();
                filtrosDTO.Desde = filtros.Desde;
                filtrosDTO.Hasta = filtros.Hasta;
                if (filtros.Vendedor != null)
                {
                    filtrosDTO.IdVendedor = filtros.Vendedor.IdAuto;
                }

                var resultDTO = _servicio.Reporte_CtaxCobrar_Documentos_Pendientes(filtrosDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    throw new Exception(resultDTO.Mensaje);
                }

                if (resultDTO.Lista != null)
                {
                    result.cntRegistro = resultDTO.cntRegistro;
                    result.Lista = resultDTO.Lista.Select(it =>
                    {
                        return new OOB.Reportes.CtaxCobrar.Documentos.Pendiente.Ficha()
                        {
                            DocFechaEmision=it.DocFechaEmision ,
                            DocFechaVencimiento=it.DocFechaVencimiento,
                            DocNumero=it.DocNumero,
                            DocImporte =it.DocImporte ,
                            DocResta =it.DocResta ,
                            DocSigno=it.DocSigno,
                            DocTipo=(OOB.CtxCobrar.Enumerados.PorTipoDocumento)it.DocTipo,
                            ClienteCiRif=it.ClienteCiRif,
                            ClienteCodigo=it.ClienteCodigo,
                            ClienteNombre=it.ClienteNombre,
                            VendedorCodigo=it.VendedorCodigo,
                            VendedorNombre=it.VendedorNombre,
                        };
                    }).ToList();
                }
                else
                {
                    result.Lista = new  List<OOB.Reportes.CtaxCobrar.Documentos.Pendiente.Ficha>(); 
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.EnumResult.isError;
            }
            return result;
        }


        //VENDEDORES
        public OOB.Resultado.ResultadoLista<OOB.Reportes.CtaxCobrar.Vendedores.Documento> Reporte_CtaxCobrar_Vendedores_Documentos(OOB.Reportes.CtaxCobrar.Vendedores.Filtro filtros)
        {
            var result = new OOB.Resultado.ResultadoLista<OOB.Reportes.CtaxCobrar.Vendedores.Documento>();
            try
            {
                var filtrosDTO = new DTO.Reportes.CtaxCobrar.Vendedores.Filtro();
                filtrosDTO.Desde = filtros.Desde;
                filtrosDTO.Hasta = filtros.Hasta;
                if (filtros.Vendedor != null)
                {
                    filtrosDTO.IdVendedor = filtros.Vendedor.IdAuto;
                }

                var resultDTO = _servicio.Reporte_CtaxCobrar_Vendedores_Documentos(filtrosDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    throw new Exception(resultDTO.Mensaje);
                }

                if (resultDTO.Lista != null)
                {
                    result.cntRegistro = resultDTO.cntRegistro;
                    result.Lista = resultDTO.Lista.Select(it =>
                    {
                        return new OOB.Reportes.CtaxCobrar.Vendedores.Documento()
                        {
                            DocFechaEmision=it.DocFechaEmision,
                            DocSerie=it.DocSerie,
                            DocNumero=it.DocNumero,
                            DocTipo= (OOB.Reportes.CtaxCobrar.Enumerados.DocVenta) it.DocTipo,
                            DocCondicionPago= (OOB.Reportes.CtaxCobrar.Enumerados.CondicionPago) it.DocCondicionPago,
                            DocDiasCredito=it.DocDiasCredito,
                            DocSubtotal=it.DocSubtotal,
                            DocTotal=it.DocTotal,
                            DocSigno=it.DocSigno,
                            ClienteCodigo=it.ClienteCodigo,
                            ClienteNombre=it.ClienteNombre,
                            ClienteRif=it.ClienteRif,
                            VendedorCodigo=it.VendedorCodigo,
                            VendedorNombre=it.VendedorNombre,
                            VendedorId=it.VendedorId,
                        };
                    }).ToList();
                }
                else
                {
                    result.Lista = new List<OOB.Reportes.CtaxCobrar.Vendedores.Documento>() ;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.EnumResult.isError;
            }
            return result;
        }

        public OOB.Resultado.ResultadoLista<OOB.Reportes.CtaxCobrar.Vendedores.Consolidado> Reporte_CtaxCobrar_Vendedores_Consolidado(OOB.Reportes.CtaxCobrar.Vendedores.Filtro filtros)
        {
            var result = new OOB.Resultado.ResultadoLista<OOB.Reportes.CtaxCobrar.Vendedores.Consolidado>();
            try
            {
                var filtrosDTO = new DTO.Reportes.CtaxCobrar.Vendedores.Filtro();
                filtrosDTO.Desde = filtros.Desde;
                filtrosDTO.Hasta = filtros.Hasta;
                if (filtros.Vendedor != null) 
                {
                    filtrosDTO.IdVendedor = filtros.Vendedor.IdAuto;
                }

                var resultDTO = _servicio.Reporte_CtaxCobrar_Vendedores_Consolidado(filtrosDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    throw new Exception(resultDTO.Mensaje);
                }

                if (resultDTO.Lista != null)
                {
                    result.cntRegistro = resultDTO.cntRegistro;
                    result.Lista = resultDTO.Lista.Select(it =>
                    {
                        return new OOB.Reportes.CtaxCobrar.Vendedores.Consolidado()
                        {
                            VendedorCodigo = it.VendedorCodigo,
                            VendedorNombre = it.VendedorNombre,
                            VendedorId = it.VendedorId,
                            MontoBaseVenta=it.MontoBaseVenta,
                            MontoExcentoVenta=it.MontoExcentoVenta,
                            MontoImpuestoVenta=it.MontoImpuestoVenta,
                            MontoBaseNcr=it.MontoBaseNcr,
                            MontoImpuestoNcr=it.MontoImpuestoNcr,
                            MontoTotalNcr=it.MontoTotalNcr,
                            MontoTotalVenta=it.MontoTotalVenta,
                        };
                    }).ToList();
                }
                else
                {
                    result.Lista = new List<OOB.Reportes.CtaxCobrar.Vendedores.Consolidado>();
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.EnumResult.isError;
            }
            return result;
        }

        public OOB.Resultado.ResultadoLista<OOB.Reportes.CtaxCobrar.Vendedores.ComisionPagar> Reporte_CtaxCobrar_Vendedores_ComisionesPagar(OOB.Reportes.CtaxCobrar.Vendedores.Filtro filtros)
        {
            var result = new OOB.Resultado.ResultadoLista<OOB.Reportes.CtaxCobrar.Vendedores.ComisionPagar>();
            try
            {
                var filtrosDTO = new DTO.Reportes.CtaxCobrar.Vendedores.Filtro();
                var resultDTO = _servicio.Reporte_CtaxCobrar_Vendedores_ComisionesPagar(filtrosDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    throw new Exception(resultDTO.Mensaje);
                }

                if (resultDTO.Lista != null)
                {
                    result.cntRegistro = resultDTO.cntRegistro;
                    result.Lista = resultDTO.Lista.Select(it =>
                    {
                        return new OOB.Reportes.CtaxCobrar.Vendedores.ComisionPagar()
                        {
                            ClienteCodigo=it.ClienteCodigo,
                            DocPagoNumero=it.DocPagoNumero,
                            DocVentaNumero=it.DocVentaNumero,
                            FechaRecepcionMerc=it.FechaRecepcionMerc,
                            FechaMovPago=it.FechaMovPago,
                            DiasTranscurrido=it.DiasTranscurrido,
                            BaseComision=it.BaseComision,
                            ComisionPorc=it.ComisionPorc,
                            ComisionCastigo=it.ComisionCastigo,
                            AplicaCastigo=it.AplicaCastigo,
                            Importe=it.Importe,
                            VendedorCodigo = it.VendedorCodigo,
                            VendedorNombre = it.VendedorNombre,
                            VendedorId = it.VendedorId,
                        };
                    }).ToList();
                }
                else
                {
                    result.Lista = new List<OOB.Reportes.CtaxCobrar.Vendedores.ComisionPagar>();
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.EnumResult.isError;
            }
            return result;
        }


        //VENTA
        public OOB.Resultado.ResultadoLista<OOB.Reportes.CtaxCobrar.Ventas.LibroVenta.Ficha> Reportes_CtxCobrar_Venta_LibroVenta(OOB.Reportes.CtaxCobrar.Vendedores.Filtro filtros)
        {
            var result = new OOB.Resultado.ResultadoLista<OOB.Reportes.CtaxCobrar.Ventas.LibroVenta.Ficha>();
            try
            {
                var filtrosDTO = new DTO.Reportes.CtaxCobrar.Ventas.Filtro ();
                filtrosDTO.Desde = filtros.Desde;
                filtrosDTO.Hasta = filtros.Hasta;

                var resultDTO = _servicio.Reporte_CtaxCobrar_Ventas_LibroVenta(filtrosDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    throw new Exception(resultDTO.Mensaje);
                }

                if (resultDTO.Lista != null)
                {
                    result.cntRegistro = resultDTO.cntRegistro;
                    result.Lista = resultDTO.Lista.Select(it =>
                    {
                        return new OOB.Reportes.CtaxCobrar.Ventas.LibroVenta.Ficha ()
                        {
                            IdAuto=it.IdAuto,
                            CiRif =it.CiRif,
                            ComprobanteRetencionNro=it.ComprobanteRetencionNro,
                            ControlNro=it.ControlNro,
                            DocumentoAfectaNro=it.DocumentoAfectaNro,
                            FacturaNro=it.FacturaNro,
                            FechaEmision=it.FechaEmision ,
                            FechaRetencion=it.FechaRetencion ,
                            IsRetencion=it.IsRetencion,
                            IsAnulado=it.IsAnulado,
                            NCreditoNro=it.NCreditoNro ,
                            NDebitoNro=it.NDebitoNro,
                            RazonSocial=it.RazonSocial,
                            Signo=it.Signo,
                            TasaAlicuota=it.TasaAlicuota,
                            TipoDocumento= (OOB.Venta.Enumerados.TipoDocumento) it.TipoDocumento,
                            TotalBase=it.TotalBase,
                            TotalExcento=it.TotalExcento,
                            TotalImpuesto=it.TotalImpuesto,
                            TotalIvaRetenido=it.TotalIvaRetenido,
                            TotalVenta=it.TotalVenta,
                        };
                    }).ToList();
                }
                else
                {
                    result.Lista = new List<OOB.Reportes.CtaxCobrar.Ventas.LibroVenta.Ficha >();
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.EnumResult.isError;
            }
            return result;
        }


        //CLIENTE
        public OOB.Resultado.ResultadoLista<OOB.Reportes.CtaxCobrar.Clientes.Maestro> Reportes_CtxCobrar_Cliente_Maestro(OOB.Reportes.CtaxCobrar.Vendedores.Filtro filtros)
        {
            var result = new OOB.Resultado.ResultadoLista<OOB.Reportes.CtaxCobrar.Clientes.Maestro>(); 
            try
            {
                var filtrosDTO = new DTO.Reportes.CtaxCobrar.Clientes.Maestro.Filtro ();
                if (filtros.Vendedor != null)
                {
                    filtrosDTO.IdVendedor = filtros.Vendedor.IdAuto;
                }

                var resultDTO = _servicio.Reporte_CtaxCobrar_Clientes_Maestro(filtrosDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    throw new Exception(resultDTO.Mensaje);
                }

                if (resultDTO.Lista != null)
                {
                    result.cntRegistro = resultDTO.cntRegistro;
                    result.Lista = resultDTO.Lista.Select(it =>
                    {
                        return new OOB.Reportes.CtaxCobrar.Clientes.Maestro()
                        {
                            Codigo=it.Codigo,
                            CiRif=it.CiRif,
                            NombreRazonSocial=it.NombreRazonSocial,
                            Telefono=it.Telefono,
                            DireccionFiscal=it.DireccionFiscal,
                            CodigoVendedor=it.CodigoVendedor,
                            NombreVendedor=it.NombreVendedor,
                        };
                    }).ToList();
                }
                else
                {
                    result.Lista = new List<OOB.Reportes.CtaxCobrar.Clientes.Maestro>();
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.EnumResult.isError;
            }
            return result;
        }

    }

}