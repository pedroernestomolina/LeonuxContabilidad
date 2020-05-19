using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Vendedores.Vendedor
{

    public class Ficha
    {

        public string IdAuto { get; set; }
        public string CiRif { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        

        public string Vendedor 
        {
            get 
            {
                return Codigo+Environment.NewLine+CiRif+Environment.NewLine+Nombre;
            }
        }

    }

}