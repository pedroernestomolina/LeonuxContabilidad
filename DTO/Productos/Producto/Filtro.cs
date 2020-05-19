using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Productos.Producto
{

    public class Filtro: DTO.Busqueda
    {

        public string IdDepartamento { get; set; }
        public string IdMarca { get; set; }
        public string IdGrupo { get; set; }
        public string IdProveedor { get; set; }
        public Enumerados.Estatus? Estatus { get; set; }
        public string ClasificacionABC { get; set; }

    }

}
