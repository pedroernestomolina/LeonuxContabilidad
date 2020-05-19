using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{

    public class Busqueda
    {

        private string _cadena;

        public string Cadena 
        {
            get { return _cadena.Trim().ToUpper(); }
            set { _cadena = value; }
        }

        public Busqueda()
        {
            Cadena = "";
        }

    }

}