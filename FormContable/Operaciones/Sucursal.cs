using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Operaciones
{

    public class Sucursal
    {

        public string Id { get; set; }
        public string Descripcion { get; set; }


        public string SucursalDesc 
        {
            get 
            {
                return Id + ", " + Descripcion;
            }
        }

    }


}