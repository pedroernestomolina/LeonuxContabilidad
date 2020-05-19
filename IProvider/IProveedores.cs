using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IProvider
{

    public interface IProveedores
    {

        ResultadoLista<DTO.Proveedores.Proveedor.Resumen> Proveedores_Proveedor_Lista(DTO.Proveedores.Proveedor.Filtro filtro);

    }

}
