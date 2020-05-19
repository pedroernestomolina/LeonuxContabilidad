using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        //CXC
        DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Documentos.Pendiente.Ficha> IReportCtaxCobrarServicio.Reporte_CtaxCobrar_Documentos_Pendientes(DTO.Reportes.CtaxCobrar.Documentos.Pendiente.Filtro filtros)
        {
            return provider.Reporte_CtaxCobrar_Documentos_Pendientes(filtros);
        }


        // VENDEDORES
        public DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Vendedores.Documentos> Reporte_CtaxCobrar_Vendedores_Documentos(DTO.Reportes.CtaxCobrar.Vendedores.Filtro filtros)
        {
            return provider.Reporte_CtaxCobrar_Vendedores_Documentos(filtros);
        }

        public DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Vendedores.Consolidado> Reporte_CtaxCobrar_Vendedores_Consolidado(DTO.Reportes.CtaxCobrar.Vendedores.Filtro filtros)
        {
            return provider.Reporte_CtaxCobrar_Vendedores_Consolidado(filtros);
        }

        public DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Vendedores.ComisionesPagar> Reporte_CtaxCobrar_Vendedores_ComisionesPagar(DTO.Reportes.CtaxCobrar.Vendedores.Filtro filtros)
        {
            return provider.Reporte_CtaxCobrar_Vendedores_ComisionesPagar(filtros);
        }


        //VENTA
        public DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Ventas.LibroVenta> Reporte_CtaxCobrar_Ventas_LibroVenta(DTO.Reportes.CtaxCobrar.Ventas.Filtro filtros)
        {
            return provider.Reporte_CtaxCobrar_Ventas_LibroVenta(filtros);
        }


        //CLIENTE
        public DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Clientes.Maestro.Ficha> Reporte_CtaxCobrar_Clientes_Maestro(DTO.Reportes.CtaxCobrar.Clientes.Maestro.Filtro filtros)
        {
            return provider.Reporte_CtaxCobrar_Clientes_Maestro(filtros);
        }

    }

}