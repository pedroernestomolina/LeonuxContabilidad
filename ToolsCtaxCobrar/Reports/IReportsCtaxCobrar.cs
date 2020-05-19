using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Reports
{

    public interface IReportsCtaxCobrar
    {

        //CLIENTES
        void CtaxCobrar_Clientes_Maestro (IEnumerable<OOB.Reportes.CtaxCobrar.Clientes.Maestro> data);

        //VENTAS
        void CtaxCobrar_Ventas_LibroVenta (IEnumerable<OOB.Reportes.CtaxCobrar.Ventas.LibroVenta.Ficha> data);

        //CXC
        void CtaxCobrar_Documentos_Pendientes(IEnumerable<OOB.Reportes.CtaxCobrar.Documentos.Pendiente.Ficha> data);

        //VENDEDORES
        void CtaxCobrar_Vendedores_Consolidado(IEnumerable<OOB.Reportes.CtaxCobrar.Vendedores.Consolidado> data);
        void CtaxCobrar_Vendedores_Documentos(IEnumerable<OOB.Reportes.CtaxCobrar.Vendedores.Documento> data);
        void CtaxCobrar_Vendedores_Comisiones(IEnumerable<OOB.Reportes.CtaxCobrar.Vendedores.ComisionPagar> data);

    }

}