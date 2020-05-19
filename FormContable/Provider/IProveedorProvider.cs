using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Provider
{

    public interface IProveedorProvider
    {

        ResultadoLista<OOB.Proveedores.Proveedor.Ficha> Proveedores_Proveedor_Lista();
      
    }

}