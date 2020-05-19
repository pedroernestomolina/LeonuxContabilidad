using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Productos.Producto
{

    public class Ficha
    {

        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Departamento { get; set; }
        public string Grupo { get; set; }
        public string Marca { get; set; }
        public string CaterogoriaAbc { get; set; }
        public bool EsExento { get; set; }
        public decimal TasaIva { get; set; }
        public string EmpaqueCompra { get; set; }
        public decimal ContEmpaqueCompra { get; set; }
        public decimal UltimoCosto { get; set; }
        public decimal CostoPromedio { get; set; }

    }

}
