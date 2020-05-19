using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Empresa.Departamentos
{

    public class Ficha
    {

        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public Sucursal Sucursal_1 { get; set; }
        public Sucursal Sucursal_2 { get; set; }
        public Sucursal Sucursal_3 { get; set; }
        public Sucursal Sucursal_4 { get; set; }
        public Sucursal Sucursal_5 { get; set; }

    }

}