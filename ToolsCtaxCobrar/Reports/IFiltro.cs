using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Reports
{

    public interface IFiltro
    {

        bool IsDesdeHabilitado { get; set; }
        bool IsHastaHabilitado { get; set; }
        bool IsDocumentoHabilitado { get; set; }
        bool IsClienteHabilitado { get; set; }
        bool IsVendedorHabilitado { get; set; }

    }

}