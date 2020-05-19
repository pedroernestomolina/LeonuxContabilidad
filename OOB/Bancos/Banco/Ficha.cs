using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Bancos.Banco
{

    public class Ficha
    {
        
        public string Id { get; set; }
        public string Numero { get; set; }
        public string Codigo { get; set; }
        public string Nombre{ get; set; }
        public OOB.Cuenta.Ficha CtaContable { get; set; }
        public OOB.Cuenta.Ficha CtaIGTF { get; set; }

        public string Banco
        {
            get
            {
                return Numero + Environment.NewLine + Nombre;
            }
        }

    }
}