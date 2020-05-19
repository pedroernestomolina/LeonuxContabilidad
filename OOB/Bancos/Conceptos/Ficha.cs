using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Bancos.Conceptos
{

    public class Ficha
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public OOB.Cuenta.Ficha CtaGasto { get; set; }
        public OOB.Cuenta.Ficha CtaPasivo { get; set; }
        public OOB.Cuenta.Ficha CtaBanco { get; set; }

        public string Concepto
        {
            get
            {
                return Codigo + Environment.NewLine + Descripcion;
            }
        }

    }

}