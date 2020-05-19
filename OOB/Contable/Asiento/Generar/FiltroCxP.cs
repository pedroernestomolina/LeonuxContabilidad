using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Contable.Asiento.Generar
{

    public class FiltroCxP
    {

        public string TipoDocumento { get; set; }
        public OOB.Bancos.Conceptos.Ficha Concepto { get; set; }
        public OOB.Proveedores.Proveedor.Ficha Proveedor { get; set; }

    }

}