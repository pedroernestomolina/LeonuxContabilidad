using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Cuenta
{

    public class Resumen
    {

        public string Codigo { get; set; }
        public string Descripcion { get; set; }


        public Resumen()
        {
            Codigo = "";
            Descripcion = "";
        }
    }

}
