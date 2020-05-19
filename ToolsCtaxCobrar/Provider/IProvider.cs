using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public interface IProvider: IServidorProv, IEmpresaProv, IClienteProv, ICtaxCobrarProv, IVendedorProv, IBancoProv, IVenta,
        IReportCtxCobrarProv
    {

    }

}