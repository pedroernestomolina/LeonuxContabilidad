using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IProvider
{

    public interface IReportCtaxCobrar
    {

        //CLIENTES
        ResultadoLista<DTO.Reportes.CtaxCobrar.Clientes.Maestro.Ficha> Reporte_CtaxCobrar_Clientes_Maestro(DTO.Reportes.CtaxCobrar.Clientes.Maestro.Filtro filtros);

        //VENTAS
        ResultadoLista<DTO.Reportes.CtaxCobrar.Ventas.LibroVenta> Reporte_CtaxCobrar_Ventas_LibroVenta(DTO.Reportes.CtaxCobrar.Ventas.Filtro filtros);

        //CXC
        ResultadoLista<DTO.Reportes.CtaxCobrar.Documentos.Pendiente.Ficha> Reporte_CtaxCobrar_Documentos_Pendientes(DTO.Reportes.CtaxCobrar.Documentos.Pendiente.Filtro filtros);

        //VENDEDORES
        ResultadoLista<DTO.Reportes.CtaxCobrar.Vendedores.Documentos> Reporte_CtaxCobrar_Vendedores_Documentos(DTO.Reportes.CtaxCobrar.Vendedores.Filtro filtros);
        ResultadoLista<DTO.Reportes.CtaxCobrar.Vendedores.Consolidado> Reporte_CtaxCobrar_Vendedores_Consolidado(DTO.Reportes.CtaxCobrar.Vendedores.Filtro filtros);
        ResultadoLista<DTO.Reportes.CtaxCobrar.Vendedores.ComisionesPagar> Reporte_CtaxCobrar_Vendedores_ComisionesPagar(DTO.Reportes.CtaxCobrar.Vendedores.Filtro filtros);

    }

}