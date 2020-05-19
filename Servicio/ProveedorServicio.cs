using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public DTO.ResultadoLista<DTO.Proveedores.Proveedor.Resumen> Proveedores_Proveedor_Lista(DTO.Proveedores.Proveedor.Filtro filtro)
        {
            return provider.Proveedores_Proveedor_Lista(filtro);
        }

    }

}