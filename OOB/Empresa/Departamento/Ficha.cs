using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Empresa.Departamento
{

    public class Sucursal 
    {

        public OOB.Cuenta.Ficha CtaInventario { get; set; }
        public OOB.Cuenta.Ficha CtaCosto { get; set; }
        public OOB.Cuenta.Ficha CtaVenta { get; set; }
        public OOB.Cuenta.Ficha CtaMerma { get; set; }
        public OOB.Cuenta.Ficha CtaConsumoInterno { get; set; }


        public Sucursal()
        {
            CtaInventario = new Cuenta.Ficha();
            CtaCosto = new Cuenta.Ficha();
            CtaVenta = new Cuenta.Ficha();
            CtaMerma = new Cuenta.Ficha();
            CtaConsumoInterno = new Cuenta.Ficha();
        }

    }

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


        public Ficha()
        {
            Id = "";
            Codigo = "";
            Descripcion="";
            Sucursal_1 = new Sucursal();
            Sucursal_2 = new Sucursal();
            Sucursal_3 = new Sucursal();
            Sucursal_4 = new Sucursal();
            Sucursal_5 = new Sucursal();
        }


        public string Departamento
        {
            get
            {
                return Codigo + Environment.NewLine + Descripcion;
            }
        }

    }

}