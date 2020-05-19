using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Empresa.Departamentos
{

    public class Resumen
    {

        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public SucursalResumen Sucursal_1 { get; set; }
        public SucursalResumen Sucursal_2 { get; set; }
        public SucursalResumen Sucursal_3 { get; set; }
        public SucursalResumen Sucursal_4 { get; set; }
        public SucursalResumen Sucursal_5 { get; set; }

    }

}