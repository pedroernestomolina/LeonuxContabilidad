using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.CtxCobrar.Documentos
{

    public abstract class BaseFiltro 
    {
        
        public string Cadena { get; set; }
        public Clientes.Cliente.Ficha Cliente { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }


        public virtual void Limpiar() 
        {
            Cadena = "";
            Cliente = null;
            Desde = null;
            Hasta = null;
        }

    }

}