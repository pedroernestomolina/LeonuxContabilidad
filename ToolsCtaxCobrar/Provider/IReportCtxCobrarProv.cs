using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public interface IReportCtxCobrarProv
    {

        //CLIENTES
        ResultadoLista<OOB.Reportes.CtaxCobrar.Clientes.Maestro> Reportes_CtxCobrar_Cliente_Maestro(OOB.Reportes.CtaxCobrar.Vendedores.Filtro filtros);


        //VENTAS
        ResultadoLista<OOB.Reportes.CtaxCobrar.Ventas.LibroVenta.Ficha> Reportes_CtxCobrar_Venta_LibroVenta(OOB.Reportes.CtaxCobrar.Vendedores.Filtro filtros);

        //CXC
        ResultadoLista<OOB.Reportes.CtaxCobrar.Documentos.Pendiente.Ficha> Reportes_CtxCobrar_Documentos_Pendientes(OOB.Reportes.CtaxCobrar.Vendedores.Filtro filtros);

        //VENDEDORES
        ResultadoLista<OOB.Reportes.CtaxCobrar.Vendedores.Documento> Reporte_CtaxCobrar_Vendedores_Documentos(OOB.Reportes.CtaxCobrar.Vendedores.Filtro filtros);
        ResultadoLista<OOB.Reportes.CtaxCobrar.Vendedores.Consolidado> Reporte_CtaxCobrar_Vendedores_Consolidado(OOB.Reportes.CtaxCobrar.Vendedores.Filtro filtros);
        ResultadoLista<OOB.Reportes.CtaxCobrar.Vendedores.ComisionPagar> Reporte_CtaxCobrar_Vendedores_ComisionesPagar(OOB.Reportes.CtaxCobrar.Vendedores.Filtro filtros);

    }

}